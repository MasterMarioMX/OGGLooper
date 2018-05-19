namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lenguajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esMXlang = new System.Windows.Forms.ToolStripMenuItem();
            this.enUSlang = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.but_Play = new System.Windows.Forms.Button();
            this.but_Staph = new System.Windows.Forms.Button();
            this.but_Pause = new System.Windows.Forms.Button();
            this.audioView = new System.Windows.Forms.GroupBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label_AudioData = new System.Windows.Forms.Label();
            this.radioTime = new System.Windows.Forms.RadioButton();
            this.radioSamples = new System.Windows.Forms.RadioButton();
            this.text_LoopLength = new System.Windows.Forms.TextBox();
            this.label_LoopLenght = new System.Windows.Forms.Label();
            this.text_LoopStart = new System.Windows.Forms.TextBox();
            this.label_LoopStart = new System.Windows.Forms.Label();
            this.Volumen = new NAudio.Gui.Pot();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBar_Pitch = new System.Windows.Forms.TrackBar();
            this.label_Pitch = new System.Windows.Forms.Label();
            this.trackUpdater = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.audioView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Pitch)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "ogg";
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ayudaToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarToolStripMenu,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            resources.ApplyResources(this.abrirToolStripMenuItem, "abrirToolStripMenuItem");
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            resources.ApplyResources(this.guardarToolStripMenuItem, "guardarToolStripMenuItem");
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            // 
            // guardarComoToolStripMenuItem
            // 
            resources.ApplyResources(this.guardarComoToolStripMenuItem, "guardarComoToolStripMenuItem");
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            // 
            // cerrarToolStripMenu
            // 
            resources.ApplyResources(this.cerrarToolStripMenu, "cerrarToolStripMenu");
            this.cerrarToolStripMenu.Name = "cerrarToolStripMenu";
            this.cerrarToolStripMenu.Click += new System.EventHandler(this.cerrarToolStripMenu_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenguajeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // lenguajeToolStripMenuItem
            // 
            this.lenguajeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esMXlang,
            this.enUSlang});
            this.lenguajeToolStripMenuItem.Name = "lenguajeToolStripMenuItem";
            resources.ApplyResources(this.lenguajeToolStripMenuItem, "lenguajeToolStripMenuItem");
            // 
            // esMXlang
            // 
            this.esMXlang.Name = "esMXlang";
            resources.ApplyResources(this.esMXlang, "esMXlang");
            this.esMXlang.Tag = "es-MX";
            this.esMXlang.Click += new System.EventHandler(this.esMXlang_Click);
            // 
            // enUSlang
            // 
            this.enUSlang.Name = "enUSlang";
            resources.ApplyResources(this.enUSlang, "enUSlang");
            this.enUSlang.Tag = "en-US";
            this.enUSlang.Click += new System.EventHandler(this.enUSlang_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            resources.ApplyResources(this.ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            resources.ApplyResources(this.acercaDeToolStripMenuItem, "acercaDeToolStripMenuItem");
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // but_Play
            // 
            resources.ApplyResources(this.but_Play, "but_Play");
            this.but_Play.Name = "but_Play";
            this.but_Play.UseVisualStyleBackColor = true;
            this.but_Play.Click += new System.EventHandler(this.but_Play_Click);
            // 
            // but_Staph
            // 
            resources.ApplyResources(this.but_Staph, "but_Staph");
            this.but_Staph.Name = "but_Staph";
            this.but_Staph.UseVisualStyleBackColor = true;
            this.but_Staph.Click += new System.EventHandler(this.but_Staph_Click);
            // 
            // but_Pause
            // 
            resources.ApplyResources(this.but_Pause, "but_Pause");
            this.but_Pause.Name = "but_Pause";
            this.but_Pause.UseVisualStyleBackColor = true;
            this.but_Pause.Click += new System.EventHandler(this.but_Pause_Click);
            // 
            // audioView
            // 
            this.audioView.Controls.Add(this.label_Time);
            this.audioView.Controls.Add(this.trackBar1);
            this.audioView.Controls.Add(this.label_AudioData);
            this.audioView.Controls.Add(this.radioTime);
            this.audioView.Controls.Add(this.radioSamples);
            this.audioView.Controls.Add(this.text_LoopLength);
            this.audioView.Controls.Add(this.label_LoopLenght);
            this.audioView.Controls.Add(this.text_LoopStart);
            this.audioView.Controls.Add(this.label_LoopStart);
            resources.ApplyResources(this.audioView, "audioView");
            this.audioView.Name = "audioView";
            this.audioView.TabStop = false;
            // 
            // label_Time
            // 
            resources.ApplyResources(this.label_Time, "label_Time");
            this.label_Time.Name = "label_Time";
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_Up);
            // 
            // label_AudioData
            // 
            resources.ApplyResources(this.label_AudioData, "label_AudioData");
            this.label_AudioData.Name = "label_AudioData";
            // 
            // radioTime
            // 
            resources.ApplyResources(this.radioTime, "radioTime");
            this.radioTime.Checked = true;
            this.radioTime.Name = "radioTime";
            this.radioTime.TabStop = true;
            this.radioTime.UseVisualStyleBackColor = true;
            // 
            // radioSamples
            // 
            resources.ApplyResources(this.radioSamples, "radioSamples");
            this.radioSamples.Name = "radioSamples";
            this.radioSamples.UseVisualStyleBackColor = true;
            this.radioSamples.CheckedChanged += new System.EventHandler(this.radioSamples_CheckedChanged);
            // 
            // text_LoopLength
            // 
            resources.ApplyResources(this.text_LoopLength, "text_LoopLength");
            this.text_LoopLength.Name = "text_LoopLength";
            // 
            // label_LoopLenght
            // 
            resources.ApplyResources(this.label_LoopLenght, "label_LoopLenght");
            this.label_LoopLenght.Name = "label_LoopLenght";
            // 
            // text_LoopStart
            // 
            resources.ApplyResources(this.text_LoopStart, "text_LoopStart");
            this.text_LoopStart.Name = "text_LoopStart";
            this.text_LoopStart.TextChanged += new System.EventHandler(this.text_LoopStart_TextChanged);
            this.text_LoopStart.Leave += new System.EventHandler(this.loopTextScanner);
            // 
            // label_LoopStart
            // 
            resources.ApplyResources(this.label_LoopStart, "label_LoopStart");
            this.label_LoopStart.Name = "label_LoopStart";
            // 
            // Volumen
            // 
            resources.ApplyResources(this.Volumen, "Volumen");
            this.Volumen.Maximum = 1D;
            this.Volumen.Minimum = 0D;
            this.Volumen.Name = "Volumen";
            this.Volumen.Value = 1D;
            this.Volumen.ValueChanged += new System.EventHandler(this.Volumen_VolumeChanged);
            // 
            // labelVolume
            // 
            resources.ApplyResources(this.labelVolume, "labelVolume");
            this.labelVolume.Name = "labelVolume";
            // 
            // trackBar_Pitch
            // 
            resources.ApplyResources(this.trackBar_Pitch, "trackBar_Pitch");
            this.trackBar_Pitch.Name = "trackBar_Pitch";
            this.trackBar_Pitch.Value = 5;
            this.trackBar_Pitch.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label_Pitch
            // 
            resources.ApplyResources(this.label_Pitch, "label_Pitch");
            this.label_Pitch.Name = "label_Pitch";
            // 
            // trackUpdater
            // 
            this.trackUpdater.Tick += new System.EventHandler(this.trackUpdater_Tick);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Pitch);
            this.Controls.Add(this.trackBar_Pitch);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.Volumen);
            this.Controls.Add(this.audioView);
            this.Controls.Add(this.but_Pause);
            this.Controls.Add(this.but_Staph);
            this.Controls.Add(this.but_Play);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AudioCheck);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.AudioReceive);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.audioView.ResumeLayout(false);
            this.audioView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Pitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lenguajeToolStripMenuItem;
        private System.Windows.Forms.Button but_Play;
        private System.Windows.Forms.Button but_Staph;
        private System.Windows.Forms.Button but_Pause;
        private System.Windows.Forms.ToolStripMenuItem esMXlang;
        private System.Windows.Forms.ToolStripMenuItem enUSlang;
        private System.Windows.Forms.GroupBox audioView;
        private System.Windows.Forms.Label label_LoopLenght;
        private System.Windows.Forms.Label label_LoopStart;
        private System.Windows.Forms.RadioButton radioTime;
        private System.Windows.Forms.RadioButton radioSamples;
        private System.Windows.Forms.Label label_AudioData;
        private NAudio.Gui.Pot Volumen;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TextBox text_LoopLength;
        private System.Windows.Forms.TextBox text_LoopStart;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar_Pitch;
        private System.Windows.Forms.Label label_Pitch;
        private System.Windows.Forms.Timer trackUpdater;
        private System.Windows.Forms.Label label_Time;
    }
}

