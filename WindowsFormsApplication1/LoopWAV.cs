using NAudio.Wave;

namespace loopTester
{
    class LoopWAV :WaveStream
    {
        WaveStream sourceStream;       

        public LoopWAV(WaveStream source)
        {
            this.sourceStream = source;
            looplength = sourceStream.Length;
        }

        public long loopstart { get;set;}

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }        
        public long looplength { get; set; }
        public override long Length
        {
            get {//return long.MaxValue / 32; 
                return sourceStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return sourceStream.Position;
            }
            set
            {
                sourceStream.Position = value;
            }
        }

        public override bool HasData(int count)
        {
            // infinite loop
            return true;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = 0;
            while (read < count)
            {
                int required = count - read;
                int readThisTime = sourceStream.Read(buffer, offset + read, required);
                if (readThisTime < required)
                {
                    sourceStream.Position = loopstart;
                }

                if (sourceStream.Position >= looplength)
                {
                    sourceStream.Position = loopstart;
                }
                read += readThisTime;
            }
            return read;
        }

        protected override void Dispose(bool disposing)
        {
            sourceStream.Dispose();
            base.Dispose(disposing);
        }
    }
}
