#region MIT

// 
// GMLib.
// Copyright (C) 2011, 2012, 2013, 2014 Michael Mercado
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

#endregion

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace GameMaker.Common
{
    public class GMFileReader : BinaryReader
    {
        #region Fields

        private MemoryStream _zipStream = null;  // A zip stream used for decompressing data.
        private int[,] _swapTable = null;        // Table used for decryption.

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public GMFileReader(Stream stream) : base(stream)
        {
        }

        #endregion

        #region Methods

        #region General

        /// <summary>
        /// Reads a single byte, also decrypts GM 7 byte.
        /// </summary>
        /// <returns>A byte.</returns>
        public byte ReadGMByte()
        {
            // Return a single byte.
            if (_swapTable != null)
            {
                // data.
                int t = (byte)BaseStream.ReadByte() & 0xFF;

                // Return the decrypted byte.
                return (byte)((_swapTable[1, t] - BaseStream.Position + 1) & 0xFF);
            }
            else
            {
                // If a zip stream exists.
                if (_zipStream != null)
                    return (byte)_zipStream.ReadByte();
                else
                    // Normal stream read.
                    return (byte)BaseStream.ReadByte();
            }
        }

        /// <summary>
        /// Reads a desired amount of bytes.
        /// </summary>
        /// <param name="amount">The amount of bytes to read.</param>
        /// <returns>The read byte array.</returns>
        public byte[] ReadGMBytes(int amount)
        {
            // Create a new byte array.
            byte[] bytes = new byte[amount];

            // Iterate through stream bytes.
            for (int i = 0; i < amount; i++)
            {
                // Set byte.
                bytes[i] = ReadGMByte();
            }

            // Return a byte array.
            return bytes;
        }

        /// <summary>
        /// Reads a boolean from stream.
        /// </summary>
        /// <returns>A boolean.</returns>
        public bool ReadGMBool()
        {
            // Read a boolean from stream.
            return Convert.ToBoolean(ReadGMInt());
        }

        /// <summary>
        /// Reads a short from file.
        /// </summary>
        /// <returns>An integer.</returns>
        public int ReadGMShort()
        {
            // Create a new byte array.
            byte[] bytes = new byte[2];

            // Read 4 bytes.
            bytes[0] = ReadGMByte();
            bytes[1] = ReadGMByte();

            // Return short from bytes.
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Reads an integer from file.
        /// </summary>
        /// <returns>An integer.</returns>
        public int ReadGMInt()
        {
            // Create a new byte array.
            byte[] bytes = new byte[4];

            // Read 4 bytes.
            bytes[0] = ReadGMByte();
            bytes[1] = ReadGMByte();
            bytes[2] = ReadGMByte();
            bytes[3] = ReadGMByte();

            // Return integer from bytes.
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Reads an integer from file. With a pre-existing first byte.
        /// </summary>
        /// <returns>An integer.</returns>
        public int ReadGMInt(byte i)
        {
            // Create a new byte array.
            byte[] bytes = new byte[4];

            // Set first byte, read the rest.
            bytes[0] = i;
            bytes[1] = ReadGMByte();
            bytes[2] = ReadGMByte();
            bytes[3] = ReadGMByte();

            // Return integer from bytes.
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Reads a double from file.
        /// </summary>
        /// <returns>A double.</returns>
        public double ReadGMDouble()
        {
            // Create new byte array.
            byte[] bytes = new byte[8];

            // Read eight bytes.
            bytes[0] = ReadGMByte();
            bytes[1] = ReadGMByte();
            bytes[2] = ReadGMByte();
            bytes[3] = ReadGMByte();
            bytes[4] = ReadGMByte();
            bytes[5] = ReadGMByte();
            bytes[6] = ReadGMByte();
            bytes[7] = ReadGMByte();

            // Return double from bytes.
            return BitConverter.ToDouble(bytes, 0);
        }

        /// <summary>
        /// Reads a string from file.
        /// </summary>
        public string ReadGMString()
        {
            // Length of string.
            int length = ReadGMInt();

            // Array of characters.
            char[] chars = new char[length];

            // Iterate through characters.
            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)ReadGMByte();
            }

            // Return string.
            return new string(chars);
        }

        #endregion

        #region Decompression

        /// <summary>
        /// Start decompression.
        /// </summary>
        public void Decompress()
        {
            Inflater inf = new Inflater();
            int size = ReadGMInt();

            inf.SetInput(ReadGMBytes(size));
            byte[] result = new byte[size * 4];
            _zipStream = new MemoryStream();

            while (!inf.IsFinished)
            {
                int length = inf.Inflate(result);
                _zipStream.Write(result, 0, length);
            }

            _zipStream.Position = 0;
        }

        /// <summary>
        /// End decompression.
        /// </summary>
        public void EndDecompress()
        {
            // If not decompressing, ignore.
            if (_zipStream == null)
                return;

            _zipStream.Close();
            _zipStream = null;
        }

        #endregion

        #region Decryption

        /// <summary>
        /// Sets the swap table seed.
        /// </summary>
        /// <param name="s">The almighty seed.</param>
        public void SetSeed(int seed)
        {
            if (seed >= 0)
                _swapTable = MakeSwapTable(seed);
            else
                _swapTable = null;
        }

        /// <summary>
        /// Makes an encryption swap table.
        /// </summary>
        /// <param name="seed">The seed used to make the swap table.</param>
        /// <returns>A new swap table.</returns>
        private int[,] MakeSwapTable(int seed)
        {
            int[,] table = new int[2, 256];
            int a = 6 + (seed % 250);
            int b = seed / 250;

            for (int i = 0; i < 256; i++)
            {
                table[0, i] = i;
            }

            for (int i = 1; i < 10001; i++)
            {
                int j = 1 + ((i * a + b) % 254);
                int t = table[0, j];

                table[0, j] = table[0, j + 1];
                table[0, j + 1] = t;
            }

            for (int i = 1; i < 256; i++)
            {
                table[1, table[0, i]] = i;
            }

            return table;
        }

        #endregion

        #endregion
    }
}
