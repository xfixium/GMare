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
    public class GMPath : GMResource
    {
        #region Fields

        private GMPoint[] _points = null;
        private ActionAtTheEnd _actionAtTheEnd = ActionAtTheEnd.MoveToStart;
        private string _roomName = "";
        private int _precision = 4;
        private int _roomId = -1;
        private int _snapX = 16;
        private int _snapY = 16;
        private bool _smooth = false;
        private bool _closed = true;

        #endregion

        #region Properties

        public GMPoint[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public ActionAtTheEnd ActionAtTheEnd
        {
            get { return _actionAtTheEnd; }
            set { _actionAtTheEnd = value; }
        }

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        public int Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public int SnapX
        {
            get { return _snapX; }
            set { _snapX = value; }
        }

        public int SnapY
        {
            get { return _snapY; }
            set { _snapY = value; }
        }

        public bool Smooth
        {
            get { return _smooth; }
            set { _smooth = value; }
        }

        public bool Closed
        {
            get { return _closed; }
            set { _closed = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads all GMX paths from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of paths</returns>
        public static GMList<GMPath> ReadPathsGMX(string directory, ref List<string> assets)
        {
            // A list of paths
            GMList<GMPath> paths = new GMList<GMPath>();
            paths.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the path
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of path properties
                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach (GMXPathProperty property in Enum.GetValues(typeof(GMXPathProperty)))
                    properties.Add(GMXEnumString(property), "");

                // Local variables
                List<GMPoint> points = new List<GMPoint>();

                // Create an xml reader
                using (XmlReader reader = XmlReader.Create(file))
                {
                    // Seek to content
                    reader.MoveToContent();

                    // Read the GMX file
                    while (reader.Read())
                    {
                        // If the node is not an element, continue
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = reader.Name;

                        // Read element
                        reader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(reader.Value))
                            continue;

                        // If the element is a point element, else normal property
                        if (nodeName.ToLower() == GMXEnumString(GMXPathProperty.Point).ToLower())
                        {
                            // Get the point data and add it to the points list
                            GMPoint point = new GMPoint();
                            string[] data = reader.Value.Split(',');
                            point.X = GMXDouble(data[0], point.X);
                            point.Y = GMXDouble(data[1], point.Y);
                            point.Speed = GMXDouble(data[2], point.Speed);
                            points.Add(point);
                        }
                        else
                        {
                            // Set the property value
                            properties[nodeName] = reader.Value;
                        }
                    }
                }

                // Create a new path, set properties
                GMPath path = new GMPath();
                path.Id = GetIdFromName(name);
                path.Name = name;
                path.Smooth = GMXBool(properties[GMXEnumString(GMXPathProperty.Kind)], path.Smooth);
                path.Closed = GMXBool(properties[GMXEnumString(GMXPathProperty.Closed)], path.Closed);
                path.Precision = GMXInt(properties[GMXEnumString(GMXPathProperty.Precision)], path.Precision);
                path.RoomName = GMXString(properties[GMXEnumString(GMXPathProperty.Backroom)], path.RoomName);
                path.RoomId = path.RoomName == "" ? -1 : GetIdFromName(path.RoomName);
                path.SnapX = GMXInt(properties[GMXEnumString(GMXPathProperty.HSnap)], path.SnapX);
                path.SnapY = GMXInt(properties[GMXEnumString(GMXPathProperty.VSnap)], path.SnapY);
                path.Points = points.ToArray();

                // Add the path
                paths.Add(path);
            }

            // Return the list of paths
            return paths;
        }

        /// <summary>
        /// Reads all paths from a GM file reader stream.
        /// </summary>
        public static GMList<GMPath> ReadPaths(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 420 && version != 800)
                throw new Exception("Unsupported Pre-Path object version.");

            // Create a new list of paths.
            GMList<GMPath> paths = new GMList<GMPath>();

            // Amount of path indexes.
            int num = reader.ReadGMInt();

            // Iterate through paths.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the path at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    paths.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new path object.
                GMPath path = new GMPath();

                // Set path id.
                path.Id = i;

                // Read path data.
                path.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    path.LastChanged = reader.ReadGMDouble();

                // Get version.
                int version2 = reader.ReadGMInt();

                // Check version.
                if (version2 != 420 && version2 != 530)
                    throw new Exception("Unsupported Path object version.");

                // Check version.
                if (version2 > 420)
                {
                    // Read path data.
                    path.Smooth = reader.ReadGMBool();
                    path.Closed = reader.ReadGMBool();
                    path.Precision = reader.ReadGMInt();
                    path.RoomId = reader.ReadGMInt();
                    path.SnapX = reader.ReadGMInt();
                    path.SnapY = reader.ReadGMInt();
                }
                else
                {
                    // Read path data.
                    path.Smooth = reader.ReadGMBool();
                    path.ActionAtTheEnd = (ActionAtTheEnd)reader.ReadGMInt();
                    reader.ReadGMBytes(4);
                }

                // Number of path points.
                path.Points = new GMPoint[reader.ReadGMInt()];

                // Iterate through path points.
                for (int j = 0; j < path.Points.Length; j++)
                {
                    // Create a new point.
                    GMPoint point = new GMPoint();

                    // Read point data.
                    point.X = reader.ReadGMDouble();
                    point.Y = reader.ReadGMDouble();
                    point.Speed = reader.ReadGMDouble();

                    // Set point.
                    path.Points[j] = point;
                }

                // End object inflate.
                reader.EndDecompress();

                // Add path.
                paths.Add(path);
            }

            // Return paths.
            return paths;
        }

        #endregion
    }

    [Serializable]
    public class GMPoint
    {
        #region Fields

        private double _x = 0.0d;
        private double _y = 0.0d;
        private double _speed = 100.0d;

        #endregion

        #region Properties

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        #endregion
    }
}
