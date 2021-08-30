using System;
using System.Runtime.InteropServices;

namespace System.IO
{
    public static class StreamExtension
    {
 
        /// <summary>
        /// 从流中读取出一个类型
        /// </summary>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object StreamReadStruct(Stream s, long offset, Type type)
        {
            if (offset >= 0)
            {
                s.Seek(offset, SeekOrigin.Begin);
            }
            int size = Marshal.SizeOf(type);
            byte[] bytes = new byte[size];
            s.Read(bytes, 0, size);
            return BytesExtension.ByteToStruct(bytes, 0, type);
        }

        /// <summary>
        /// 从流中读取出一个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T StreamReadStruct<T>(Stream s, long offset)
        {
            return (T)StreamReadStruct(s, offset, typeof(T));
        }


        /// <summary>
        /// 从流中读取出一个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T ReadStruct<T>(this Stream s, long offset = -1)
        {
            return StreamReadStruct<T>(s, offset);
        }

        /// <summary>
        /// 从流中读取出一组数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T[] ReadStructs<T>(this Stream s, long offset = -1, int count = 1)
        {
            T[] datas = new T[count];
            for (int i = 0; i < count; i++)
            {
                datas[i] = s.ReadStruct<T>();
            }
            return datas;
        }

        /// <summary>
        /// 读取指定长度的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ReadString(this Stream s, long offset = -1, int size = 0)
        {
            if (offset >= 0)
            {
                s.Seek(offset, SeekOrigin.Begin);
            }
            byte[] bytes = new byte[size];
            s.Read(bytes, 0, size);
            return Text.Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// 读取一个通过前置 1 byte 来说明长度的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ReadStringByPreByte(this Stream s, long offset = -1)
        {
            if (offset >= 0)
            {
                s.Seek(offset, SeekOrigin.Begin);
            }
            int size = s.ReadByte();
            byte[] bytes = new byte[size];
            s.Read(bytes, 0, size);
            return Text.Encoding.ASCII.GetString(bytes);
        }


        /// <summary>
        /// 对于非偶长度进行补位（直接补位）
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <param name="padDefault"></param>
        public static void Pad(this Stream s, int len, int padDefault = 1)
        {
            if (len % 2 > 0)
            {
                s.Seek(padDefault, SeekOrigin.Current);
            }
        }

        /// <summary>
        /// 对于非偶长度进行对齐
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <param name="padDefault"></param>
        public static int Align(this Stream s, int len, int alignTarget)
        {
            int r = (alignTarget - len % alignTarget) % alignTarget;
            s.Seek(r, SeekOrigin.Current);
            return r;
        }

        public static string ToHexString(this byte[] bs)
        {
            string r = "0x ";
            for (int i = 0; i < bs.Length; i++)
            {
                r += string.Format("{0:X2} ", bs[i]);
                if (i != 0 && i % 16 == 0)
                {
                    r += "\n";
                }
            }

            return r;
        }
    }
}
