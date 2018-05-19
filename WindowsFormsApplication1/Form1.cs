using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Resources;
using System.Threading;
using System.Globalization;

using NVorbis;
using NAudio.Wave;
using loopTester;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }      
        
        //stuff 4 da prugram        
        String[] formatList = { ".ogg", ".wav", ".mp3" };//formatos disponibles
        String[] formatComments = { "OGG Files (.ogg)", "WAV Files (.wav)", "MP3 Songs(.mp3)" };
        String[] languageList = { "es-MX","en-US" };
        enum formats : byte { ogg, wav ,mp3};
        Color defaultColor = Color.Black;
        //sound containers for proccessing your precious audio file
        string currentFile = "";
        Stream archivoActual = null; //loads the RAW, compressed data. hue hue hue.
        WaveOutEvent waveOut = new NAudio.Wave.WaveOutEvent(); //your default audio device, and your virtual Speaker in the prog's logic.
        LoopWAV wove; //the thing that control and MAKES the actual sound, at least in WAV.
        WaveStream emp3;
        NAudio.Vorbis.VorbisWaveReader vorb; //the thing that control and Makes the sound as an OGG. better convert on the fly.
        //data about current file being vissected. Needed for proper Sample to Time convertion and viceversa.
        long sampleRate = 44100;
        long sampleStart = 0;
        long sampleLength = 0;
        long sampleTotal = 0;
                       
        byte pitch = 100;
        byte channels = 1;

        sbyte currentFormat;
        sbyte lastFormatOpened = 0;
        

        private int getLoopStart()
        {

            if(sampleStart>0)
            {
                
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        private int getLoopLength()
        {
            
            return 0;
        }
        private void enabler_main(Boolean choise)
        {
            /*trackBar_Pitch.Enabled = */Volumen.Enabled = cerrarToolStripMenu.Enabled = guardarComoToolStripMenuItem.Enabled = guardarToolStripMenuItem.Enabled = but_Pause.Enabled = but_Play.Enabled =  but_Staph.Enabled = Volumen.Enabled=trackBar1.Enabled = choise;
        }
        private void enabler_edits(Boolean choise)
        {
            text_LoopLength.Enabled = text_LoopStart.Enabled= but_Play.Enabled= choise;
        }
        private void languageChoise(string objetivo)
        {

            if (Thread.CurrentThread.CurrentUICulture.Name != objetivo)
            {
                var recurso = new ResourceManager(typeof(Form1));//accedemos al recurso local            
                var mensaje = recurso.GetString("warning_lng");//agarramos el mensaje de que si cambias, ya valió
                var advertencia = MessageBox.Show(mensaje, "uh oh...", MessageBoxButtons.YesNo);

                if (advertencia == DialogResult.Yes)
                {                                        
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(objetivo);
                    this.Controls.Clear();
                    this.InitializeComponent();
                }
            }else { MessageBox.Show("Ok...", "NOPE!!!"); }
        }
        private void FileOpener(object sender, EventArgs e)
        {
            //open a new file, ready to operate!            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Supported Audio Files|*.ogg;*.wav;*.mp3|OGG Files (.ogg)|*.ogg|WAV Files (wav)|*.wav|MP3 Files|*.mp3";
            dialog.FilterIndex = lastFormatOpened+1;
            DialogResult respuesta = dialog.ShowDialog();
            lastFormatOpened = (sbyte)(dialog.FilterIndex - 1);     
            
            
            if (respuesta == DialogResult.OK)
            {
                if (vorb!=null) vorb.Dispose();
                if (wove!=null) wove.Dispose();
                waveOut.Dispose();

                currentFile = dialog.FileName;

                //OGG               
                if(dialog.FileName.Substring((dialog.FileName.Length-4),4).ToUpperInvariant() == formatList[(int)formats.ogg].ToUpperInvariant())
                {
                    try
                    {

                        archivoActual = dialog.OpenFile();
                        var v = new VorbisReader(archivoActual, true);
                        sampleRate = v.SampleRate;                        
                        sampleTotal = v.TotalSamples;
                        channels = (byte)v.Channels;
                        string[] tags = v.Comments;
                        string tagTITLE = "";
                        //seek tags here.
                        
                        tagTITLE = tagSeeker.getOggTagValue(v.Comments, "TITLE");
                        if (tagTITLE != "") audioView.Text = tagTITLE; else audioView.Text = dialog.SafeFileName;
                        sampleStart = Convert.ToInt64(tagSeeker.getOggTagValue(v.Comments, "LOOPSTART",true));
                        sampleLength = Convert.ToInt64(tagSeeker.getOggTagValue(v.Comments, "LOOPLENGTH", true));
                        vorb = new NAudio.Vorbis.VorbisWaveReader(dialog.FileName); 
                                               
                        wove = new LoopWAV(vorb);
                        wove.loopstart = (long)(((float)sampleStart / (float)sampleRate)*((float)wove.Length / (((float)sampleTotal / (float)sampleRate)) ));//calculamos los bytes donde se regresa la música en base a los samples que tenemos.
                        if (sampleLength > 0) { wove.looplength = ((long)(((float)(sampleLength+sampleStart) / (float)sampleRate) * ((float)wove.Length / (((float)sampleTotal / (float)sampleRate))))); }
                        Console.WriteLine("SampleTotal:{0,2} SampleStart:{1,3} Calculated Start Byte: {2} Calculated Length Byte: {3} Bytes: {4}",sampleTotal,sampleStart,wove.loopstart,wove.looplength,wove.Length);
                        waveOut.Init(wove);
                        trackBar1.Maximum = (int)(((float)sampleTotal / (float)sampleRate)*1000f);Console.WriteLine("track max: "+trackBar1.Maximum);
                        label_AudioData.Text = String.Format("{0} Kbits {1} KHz {2} Channels", (v.NominalBitrate / 1000), ((float)sampleRate / 1000), (channels));
                        currentFormat = (int)formats.ogg;
                        lastFormatOpened = (ushort)formats.ogg + 1;
                        radioSamples_CheckedChanged(sender, e);

                        enabler_main(true);
                    }
                    catch (Exception ouch)
                    {
                        MessageBox.Show("Error on loading OGG...\n" + ouch.ToString(), "Load error");
                        cerrarToolStripMenu_Click(sender, e);
                    }
                }
                else if ((dialog.FileName.Substring((dialog.FileName.Length - 4), 4).ToUpperInvariant() == formatList[(int)formats.wav].ToUpperInvariant()))
                {
                    //WAV
                    archivoActual = dialog.OpenFile();                    
                    try
                    {
                        //wavs are diferent, I can get their (aproximate) total time so we use that instead.
                        WaveFileReader temp = new WaveFileReader(archivoActual);
                        wove = new LoopWAV(temp);                        
                        waveOut = new WaveOutEvent();                        
                        waveOut.Init(wove);                                     
                        trackBar1.Maximum = (((int)wove.TotalTime.TotalSeconds)+1)*1000 ;//miliseconds precise?
                        audioView.Text = "";
                        enabler_main(true);
                        //MessageBox.Show("Loading a WAVe of sound!", "Incredibly LAME pun!");
                        label_AudioData.Text = waveOut.OutputWaveFormat.ToString();
                        audioView.Text = dialog.SafeFileName;
                        currentFormat = (int)formats.wav;
                        lastFormatOpened = (ushort)formats.wav+1;
                        
                        Console.WriteLine("Samples: {0} \tLength(bytes): {1}",temp.SampleCount,temp.Length);
                    }
                    catch (Exception horror)
                    {
                        MessageBox.Show("Error on loading FILE...it was that bad of a file.\n\n"+horror.Message,"Load error");
                        cerrarToolStripMenu_Click(sender, e);
                    }
                }else if ((dialog.FileName.Substring((dialog.FileName.Length - 4), 4).ToUpperInvariant() == formatList[(int)formats.mp3].ToUpperInvariant()))
                {
                    try
                    {
                        //H4R0X the MP3 to make it a WAV instead! way to evade a LAME royalty ;-)
                        //also it's easier to transform to OGG if the user desires.
                        //IF I MANAGE TO TURN IT INTO AN OGG THAT IS!!!
                        archivoActual = dialog.OpenFile();
                        Mp3FileReader rad = new Mp3FileReader(archivoActual);                        
                        emp3 = WaveFormatConversionStream.CreatePcmStream(rad);
                        wove = new LoopWAV(emp3);
                        waveOut = new WaveOutEvent();
                        waveOut.Init(wove);
                        trackBar1.Maximum = (((int)wove.TotalTime.TotalSeconds) + 1) * 1000;//miliseconds precise?
                        currentFormat = (sbyte)formats.mp3;
                        label_AudioData.Text = waveOut.OutputWaveFormat.ToString();
                        audioView.Text = dialog.SafeFileName;                        
                        enabler_main(true);
                    }
                    catch (Exception horror)
                    {
                        MessageBox.Show("Error on loading FILE...\n\n" + horror.Message, "Load error");
                        cerrarToolStripMenu_Click(sender, e);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong File tipe, how did you do that?","You dirty hacker!");
                }



            }
            else
            {
                //normally chech if error but nope, not for now.
            }

            dialog.Dispose();  
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpener(sender,e);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cosa = new loopTester.helpForm();            
            cosa.ShowDialog(this);            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void cerrarToolStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                switch (currentFormat)
                {
                    case ((sbyte)formats.wav): wove.Dispose(); break;
                    case ((sbyte)formats.mp3): emp3.Dispose(); break;
                    case ((sbyte)formats.ogg): vorb.Dispose(); break;
                }
                if (archivoActual != null)archivoActual.Dispose();
                trackUpdater.Stop();
                trackBar1.Value = 0;
            }
            catch { }
            waveOut.Stop();
            waveOut.Dispose();
            audioView.Text = "X_X";
            label_AudioData.Text = "[DATA EXPUNGED]";
            enabler_main(false);
            lastFormatOpened = 0;
            label_Time.Text = "Time: ";            
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void but_Play_Click(object sender, EventArgs e)
        {
            but_Play.ForeColor = Color.Red;
            but_Pause.ForeColor = defaultColor;
            waveOut.Play();
            trackUpdater.Start();     
        }

        private void but_Staph_Click(object sender, EventArgs e)
        {
            if (!text_LoopStart.Enabled)
            {
                enabler_edits(!false);
            }
            but_Play.ForeColor = defaultColor;
            but_Pause.ForeColor = defaultColor;
            waveOut.Stop();
            trackUpdater.Stop();
            trackBar1.Value = 0;
            switch (currentFormat)
            {
                case ((int)formats.ogg):vorb.Position = 0;break;
                case ((int)formats.mp3):emp3.Position = 0; break;
                default:wove.Position = 0;break;
            }
            
        }

        private void but_Pause_Click(object sender, EventArgs e)
        {
            but_Pause.ForeColor = Color.Blue;
            waveOut.Pause();
            trackUpdater.Stop();
            Console.WriteLine("Staph at: {0:t} at byte: {1}", wove.CurrentTime,wove.Position);
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void esMXlang_Click(object sender, EventArgs e)
        {
            cerrarToolStripMenu_Click(sender, e);
            languageChoise("es-MX");
        }

        private void enUSlang_Click(object sender, EventArgs e)
        {
            cerrarToolStripMenu_Click(sender, e);
            languageChoise("en-US");
        }

        private void radioSamples_CheckedChanged(object sender, EventArgs e)
        {
            float tempTime;
            if (radioSamples.Checked)
            {
                text_LoopStart.Text = sampleStart.ToString();
                text_LoopLength.Text = sampleLength.ToString();
            }
            else if (radioTime.Checked)
            {
                try
                {
                    tempTime = (float)sampleStart / (float)sampleRate;
                    text_LoopStart.Text = string.Format("{0:N3}",tempTime);
                }
                catch
                {
                    text_LoopStart.Text = "";                    
                }
                try
                {
                    tempTime = (float)sampleLength / (float)sampleRate;
                    text_LoopLength.Text = string.Format("{0:N3}", tempTime);
                }
                catch
                {
                    text_LoopLength.Text = "";
                }
            } }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            waveOut.Dispose();
                        
        }

        private void Volumen_VolumeChanged(object sender, EventArgs e)
        {
            float voluminado = (float)Volumen.Value;
#pragma warning disable CS0612 // Type or member is obsolete
            waveOut.Volume = voluminado;
#pragma warning restore CS0612 // Type or member is obsolete            
            labelVolume.Text = String.Format("Volume\n{0:0%}", voluminado);
        }    
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            pitch = (byte)(100 + (trackBar_Pitch.Value * 10 - 50));
            label_Pitch.Text = String.Format("Pitch: {0}%",pitch);
        }

        private void trackUpdater_Tick(object sender, EventArgs e)
        {
            if (currentFormat == (int)formats.ogg)
                trackBar1.Value = (int)(((float)wove.Position / (float)wove.Length) * (((float)sampleTotal / (float)sampleRate) * 1000f));
            else 
                trackBar1.Value = (wove.CurrentTime.Minutes*60000)+(wove.CurrentTime.Seconds*1000)+wove.CurrentTime.Milliseconds;//ludicrous precision and taking account that a wav/mp3 might not be LONGER than 60 Minutes somehow? Just don't try with podcasts that last THAT long or more!
            label_Time.Text = string.Format( "Time: {0:D2}:{1:D2}:{2:D3}",wove.CurrentTime.Minutes,wove.CurrentTime.Seconds,wove.CurrentTime.Milliseconds);
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (but_Play.ForeColor == Color.Red) { trackUpdater.Stop(); }
        }

        private void trackBar1_Up(object sender, MouseEventArgs e)
        {
            wove.Position = (long)(((float)trackBar1.Value / (float)trackBar1.Maximum) * (float)wove.Length);
            if (but_Play.ForeColor == Color.Red) { trackUpdater.Start(); }
        }

        private void AudioDrop(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent("Stream"))
            {
                MessageBox.Show("It is an Audio File?");
            }
            else
            {
                MessageBox.Show("NOPE.");
            }
            //menuStrip1.DoDragDrop(archivoActual, DragDropEffects.Link);
        }

        private void AudioCheck(object sender, DragEventArgs e)
        {

        }

        private void AudioReceive(object sender, DragEventArgs e)
        {
            
        }

        private void text_LoopStart_TextChanged(object sender, EventArgs e)
        {

        }
        private void loopTextScanner(object sender, EventArgs e)
        {
            /*try
            {
                wove.loopstart = Convert.ToInt32(text_LoopStart.Text);
            }
            catch
            {
                MessageBox.Show("Error converting scribble to actual numbers.","N/A Error");
            }*/
        }
    }
}
