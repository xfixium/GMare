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
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMResource
    {
        #region Fields

        private string _name = "";        // Personal identifier
        private double _lastChanged = 0;  // Last changed date
        private int _id = -1;             // Unique identifier

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the personal identifier
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the last changed date
        /// </summary>
        public double LastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an id from a name
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <returns>An integer id</returns>
        public static int GetIdFromName(string name)
        {
            // If the nme is empty, so is the id
            if (name == "")
                return -1;

            // Id varible
            int id = 0;

            // Get the bytes of the string characters
            byte[] byteContents = Encoding.Unicode.GetBytes(name);

            // Create a new hash object
            SHA256 hash = new SHA256CryptoServiceProvider();

            // Compute the hash
            byte[] hashText = hash.ComputeHash(byteContents);

            // Convert parts of the hash in integer
            int hashCodeStart = BitConverter.ToInt32(hashText, 0);
            int hashCodeMiddle = BitConverter.ToInt32(hashText, 8);
            int hashCodeEnd = BitConverter.ToInt32(hashText, 24);

            // Combine for interger
            id = hashCodeStart ^ hashCodeMiddle ^ hashCodeEnd;

            // Return int representing string
            return (id);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Custom string</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}