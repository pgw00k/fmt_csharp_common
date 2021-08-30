using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System
{
    public static class BytesExtension
    {
        /// <summary>
        /// 将Byte转换为结构体类型
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ByteToStruct(byte[] bytes, int offset, Type type)
        {
            int size = Marshal.SizeOf(type);
            //分配结构体内存空间
            IntPtr structPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, offset);

            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            //Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        /// <summary>
        /// 将Byte转换为结构体类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T ByteToStruct<T>(byte[] bytes, int offset = 0)
        {
            return (T)ByteToStruct(bytes, offset, typeof(T));
        }

        public static T ByteTo<T>(this byte[] bytes, int offset = 0)
        {
            return (T)ByteToStruct(bytes, offset, typeof(T));
        }

    }
}
