using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiscUtil.Conversion;

namespace System.IO
{
    public static class BinaryReaderExtension
    {

        #region BigEndian Convert

        public static Int32 ReadInt32_BE(this BinaryReader br)
        {
            byte[] tdata = br.ReadBytes(4);
            return BigEndianBitConverter.Big.ToInt32(tdata, 0);
        }

        public static Int16 ReadInt16_BE(this BinaryReader br)
        {
            byte[] tdata = br.ReadBytes(2);
            return BigEndianBitConverter.Big.ToInt16(tdata, 0);
        }

        public static Int64 ReadInt64_BE(this BinaryReader br)
        {
            byte[] tdata = br.ReadBytes(8);
            return BigEndianBitConverter.Big.ToInt64(tdata, 0);
        }

        public static Single ReadSingle_BE(this BinaryReader br)
        {
            byte[] tdata = br.ReadBytes(4);
            return BigEndianBitConverter.Big.ToSingle(tdata, 0);
        }

        public static Double ReadDouble_BE(this BinaryReader br)
        {
            byte[] tdata = br.ReadBytes(8);
            return BigEndianBitConverter.Big.ToDouble(tdata, 0);
        }

        #endregion

    }
}
