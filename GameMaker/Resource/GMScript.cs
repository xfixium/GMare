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
using System.Xml;
using System.Collections.Generic;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMScript : GMResource
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
        /// Reads scripts from Game Maker Studio project file
        /// </summary>
        /// <param name="directory">The directory the shaders are placed</param>
        /// <param name="assets">Collection of project assets</param>
        public static GMList<GMScript> ReadScriptsGMX(string directory, ref List<string> assets)
        {
            // A list of scripts
            GMList<GMScript> scripts = new GMList<GMScript>();
            scripts.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gml"))
            {
                // Set name of the script
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a stream to the script file
                using (StreamReader streamReader = new StreamReader(file))
                {
                    // Create a new script
                    GMScript script = new GMScript();
                    script.Name = name;
                    script.Id = GetIdFromName(name);
                    script.Code = streamReader.ReadToEnd();

                    // Add the script
                    scripts.Add(script);
                }
            }

            // Return the list of scripts
            return scripts;
        }

        /// <summary>
        /// Reads all scripts from a GM file reader stream.
        /// </summary>
        public static GMList<GMScript> ReadScripts(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Script object version.");

            // Create a new list of scripts.
            GMList<GMScript> scripts = new GMList<GMScript>();

            // Amount of script ids.
            int num = reader.ReadGMInt();

            // Iterate through scripts.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the script at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    scripts.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new script object.
                GMScript script = new GMScript();

                // Set script id.
                script.Id = i;

                // Read script data.
                script.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    script.LastChanged = reader.ReadGMDouble();

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 400 && version != 800)
                    throw new Exception("Unsupported Script object version.");

                // Read script data.
                script.Code = reader.ReadGMString();

                // End object inflate.
                reader.EndDecompress();

                // Add script.
                scripts.Add(script);
            }

            // Return scripts.
            return scripts;
        }

        #endregion
    }
}