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
    public class GMPackage
    {
        #region Fields

        private string _name = "";

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return _name.Length;
        }

        /// <summary>
        /// Reads game packages from GM file.
        /// </summary>
        public static GMPackage[] ReadPackages(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version
            if (version != 700)
                throw new Exception("Unsupported Extension object version.");

            // Get the number of packages.
            GMPackage[] packages = new GMPackage[reader.ReadGMInt()];

            // Read packages.
            for (int i = 0; i < packages.Length; i++)
            {
                // Create a new package.
                GMPackage package = new GMPackage();

                // Read package name.
                package.Name = reader.ReadGMString();

                // Set package.
                packages[i] = package;
            }

            return packages;
        }

        #endregion
    }
}
