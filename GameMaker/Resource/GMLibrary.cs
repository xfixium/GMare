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
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMLibrary
    {
        #region Fields

        private string _code = "";

        #endregion

        #region Properties

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return _code.Length;
        }

        /// <summary>
        /// Reads all the libraries in a GM file reader stream.
        /// </summary>
        public static GMList<GMLibrary> ReadLibraries(GMFileReader reader)
        {
            // Create a new list of libraries.
            GMList<GMLibrary> libraries = new GMList<GMLibrary>();

            // Get number of libraries.
            int num = reader.ReadGMInt();

            // Read libraries.
            for (int j = 0; j < num; j++)
            {
                // Create a new library.
                GMLibrary library = new GMLibrary();

                // Read the library code.
                library.Code = reader.ReadGMString();

                // Add the library.
                libraries.Add(library);
            }

            // Return libraries.
            return libraries;
        }

        #endregion
    }
}
