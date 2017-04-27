﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PeNet.Utilities
{
    /// <summary>
    /// Useful extension method to work with
    /// primitive data types, arrays etc.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        ///     Convert a two bytes in a byte array to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Position of the high byte. Low byte is i+1.</param>
        /// <returns>UInt16 of the bytes in the buffer at position i and i+1.</returns>
        public static ushort BytesToUInt16(this byte[] buff, ulong offset)
        {
            return BytesToUInt16(buff[offset], buff[offset + 1]);
        }
        

        /// <summary>
        ///     Convert 4 consecutive bytes out of a buffer to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt32 of 4 bytes.</returns>
        public static uint BytesToUInt32(this byte[] buff, ulong offset)
        {
            return BytesToUInt32(buff[offset], buff[offset + 1], buff[offset + 2], buff[offset + 3]);
        }

        /// <summary>
        ///     Convert 8 consecutive byte in a buffer to an
        ///     64 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt64 of the byte sequence at offset i.</returns>
        public static ulong BytesToUInt64(this byte[] buff, ulong offset)
        {
            return BytesToUInt64(buff[offset], buff[offset + 1], buff[offset + 2],
                buff[offset + 3], buff[offset + 4], buff[offset + 5], buff[offset + 6],
                buff[offset + 7]);
        }

        /// <summary>
        ///     Convert up to 8 bytes out of a buffer to an 64 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt64 of numOfBytes bytes.</returns>
        public static ulong BytesToUInt64(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[8];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        ///  Convert an ushort array to 
        ///  an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Byte array.</returns>
        public static byte[] ToBytes(this ushort[] value)
        {
            var bytes = new byte[value.Length * 2];
            for (var i = 0; i < value.Length; i++)
            {
                var b1 = value[i].ToBytes()[0];
                var b2 = value[i].ToBytes()[1];

                bytes[i * 2] = b1;
                bytes[i * 2 + 1] = b2;
            }

            return bytes;
        }

        /// <summary>
        ///     Convert an UIn16 to an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Two byte array of the input value.</returns>
        public static byte[] ToBytes(this ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Convert an UInt32 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>4 byte array of the value.</returns>
        public static byte[] ToBytes(this uint value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Convert an UInt64 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>4 byte array of the value.</returns>
        public static byte[] ToBytes(this ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Compares the quality of the elements of two lists.
        /// </summary>
        /// <param name="first">First list.</param>
        /// <param name="second">Second list.</param>
        /// <returns>True if all elements are equal, else false.</returns>
        public static bool ListCompare<lType>(this IList<lType> first, IList<lType> second)
        {
            if (first.Count != second.Count)
                return false;

            return !first.Where((t, i) => !t.Equals(second[i])).Any();
        }

        /// <summary>
        ///     Convert to bytes to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="b1">High byte.</param>
        /// <param name="b2">Low byte.</param>
        /// <returns>UInt16 of the input bytes.</returns>
        private static ushort BytesToUInt16(byte b1, byte b2)
        {
            return BitConverter.ToUInt16(new[] { b1, b2 }, 0);
        }

        /// <summary>
        ///     Convert 4 bytes to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second highest byte.</param>
        /// <param name="b3">Second lowest byte.</param>
        /// <param name="b4">Lowest byte.</param>
        /// <returns>UInt32 representation of the input bytes.</returns>
        private static uint BytesToUInt32(byte b1, byte b2, byte b3, byte b4)
        {
            return BitConverter.ToUInt32(new[] { b1, b2, b3, b4 }, 0);
        }

        /// <summary>
        ///     Converts 8 bytes to an 64 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second byte.</param>
        /// <param name="b3">Third byte.</param>
        /// <param name="b4">Fourth byte.</param>
        /// <param name="b5">Fifth byte.</param>
        /// <param name="b6">Sixth byte.</param>
        /// <param name="b7">Seventh byte.</param>
        /// <param name="b8">Lowest byte.</param>
        /// <returns>UInt64 of the input bytes.</returns>
        private static ulong BytesToUInt64(byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
        {
            return BitConverter.ToUInt64(new[] { b1, b2, b3, b4, b5, b6, b7, b8 }, 0);
        }
    }
}