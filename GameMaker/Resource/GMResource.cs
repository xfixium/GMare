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
using System.Xml;
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
        /// Gets the GMX property string for the given string enum
        /// </summary>
        /// <param name="e">The numeration to extract the property srting from</param>
        /// <returns>A string representation of an enumeration elelment</returns>
        public static string GMXEnumString(Enum e)
        {
            return EnumString.GetEnumString(e);
        }

        /// <summary>
        /// Creates an id from a name
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <returns>An integer id</returns>
        public static int GetIdFromName(string name)
        {
            // If the nme is empty, so is the id
            if (string.IsNullOrWhiteSpace(name))
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

        /// <summary>
        /// Gets the resource name from a file path
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns>Resource name</returns>
        public static string GetResourceName(string file)
        {
            // Set name of the room
            string name = file.Remove(0, file.LastIndexOf("\\"));
            return name.Remove(name.IndexOf(".")).Replace("\\", "");
        }

        /// <summary>
        /// Converts a string to a boolean
        /// </summary>
        /// <returns>A boolean.</returns>
        public static bool GMXBool(string boolean, bool defaultBool)
        {
            // Read a boolean from stream
            return boolean == "" ? defaultBool : boolean == "-1";
        }

        /// <summary>
        /// Converts a string to an integer
        /// </summary>
        /// <returns>A boolean.</returns>
        public static string GMXString(string str, string defaultString)
        {
            // If string empty use default value
            return str == "" ? defaultString : str;
        }

        /// <summary>
        /// Converts a string to an integer
        /// </summary>
        /// <returns>A boolean.</returns>
        public static int GMXInt(string integer, int defaultInt)
        {
            // Convert string to int
            return integer == "" ? defaultInt : Convert.ToInt32(integer);
        }

        /// <summary>
        /// Converts a string to an unsigned integer
        /// </summary>
        /// <returns>A boolean.</returns>
        public static uint GMXUInt(string unsignedInt, uint defaultUInt)
        {
            // Convert string to uint
            return unsignedInt == "" ? defaultUInt : Convert.ToUInt32(unsignedInt);
        }

        /// <summary>
        /// Converts a string to an integer
        /// </summary>
        /// <returns>A boolean.</returns>
        public static double GMXDouble(string d, double defaultDouble)
        {
            // Read a boolean from stream.
            return d == "" ? defaultDouble : Convert.ToDouble(d);
        }

        /// <summary>
        /// Gets a string value of a boolean from the given boolean
        /// </summary>
        /// <param name="b">The boolean to convert to a string</param>
        /// <returns>Either -1 for true or 0 for false</returns>
        public static string GetGMXBool(bool b)
        {
            return b ? "-1" : "0";
        }

        /// <summary>
        /// Write a fully tagged element
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void XMLWriteFullElement(XmlTextWriter writer, string element, string value)
        {
            // Write an element with a forced closed element tag
            writer.WriteStartElement(element);
            writer.WriteRaw(value);
            writer.WriteFullEndElement();
        }

        /// <summary>
        /// Write a fully tagged element with an attribute
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="attribute"></param>
        /// <param name="attributeValue"></param>
        public static void XMLWriteFullElement(XmlTextWriter writer, string element, string value, string attribute, string attributeValue)
        {
            // Write an element with a forced closed element tag
            writer.WriteStartElement(element);
            writer.WriteAttributeString(attribute, attributeValue);
            writer.WriteRaw(value);
            writer.WriteFullEndElement();
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