using System;

namespace System.IO
{
    public abstract class BaseStreamReader
    {

        protected BinaryReader _br;

        public BaseStreamReader(Stream s,long offset = -1,bool isAutoRead = true)
        {
            if(offset>0)
            {
                s.Seek(offset,SeekOrigin.Begin);
            }
            _br = new BinaryReader(s);

            if (isAutoRead)
            {
                Read();
            }

        }

        protected virtual void Read()
        {
            Init();
            _br = null;
        }

        protected virtual void Init()
        {

        }
    }
}
