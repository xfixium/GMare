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
    public class GMNode : GMResource
    {
        #region Fields

        private GMNodeType _nodeType = GMNodeType.Parent;
        private GMResourceType _resourceType = GMResourceType.None;
        private GMNode[] _nodes = null;
        private int _children = 0;

        #endregion

        #region Properties

        public GMNodeType NodeType
        {
            get { return _nodeType; }
            set { _nodeType = value; }
        }

        public GMResourceType ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }

        public GMNode[] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        public int Children
        {
            get { return _children; }
            set { _children = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads an object Tree from a GM file reader stream
        /// </summary>
        public static GMNode ReadTree(string name, GMFileReader reader)
        {
            // Get version
            int version = reader.ReadGMInt();

            // Check version
            if (version != 500 && version != 540 && version != 700)
                throw new Exception("Unsupported Project Tree object version.");

            // Room execution Order
            reader.ReadGMBytes(reader.ReadGMInt() * 4);

            // Set the number of main resource nodes
            int rootNum = (version > 540) ? 12 : 11;

            // Create a project node
            GMNode projectTree = new GMNode();
            projectTree.Nodes = new GMNode[rootNum];
            projectTree.Name = name;
            projectTree.NodeType = GMNodeType.Parent;
            projectTree.Children = projectTree.Nodes.Length;

            // Iterate through Game Maker project root nodes
            for (int i = 0; i < rootNum; i++)
            {
                // Create new node
                GMNode node = new GMNode();

                // Read node data
                node.NodeType = (GMNodeType)(reader.ReadGMInt());
                node.ResourceType = (GMResourceType)(reader.ReadGMInt());
                node.Id = reader.ReadGMInt();
                node.Name = reader.ReadGMString();
                node.Children = reader.ReadGMInt();

                // If there is at least one child node
                if (node.Children > 0)
                {
                    // Create a new node array
                    node.Nodes = new GMNode[node.Children];

                    // Iterate through children
                    for (int j = 0; j < node.Children; j++)
                    {
                        // Add new node
                        node.Nodes[j] = new GMNode();
                    }

                    // Read in child nodes recursively
                    ReadNodeRecursive(node, reader);
                }

                // Add new main node
                projectTree.Nodes[i] = node;
            }

            // Return project tree
            return projectTree;
        }

        /// <summary>
        /// Reads a Game Maker tree node recursively
        /// </summary>
        private static void ReadNodeRecursive(GMNode parent, GMFileReader reader)
        {
            // Iterate through child nodes
            foreach (GMNode node in parent.Nodes)
            {
                // Read node data
                node.NodeType = (GMNodeType)(reader.ReadGMInt());
                node.ResourceType = (GMResourceType)(reader.ReadGMInt());
                node.Id = reader.ReadGMInt();
                node.Name = reader.ReadGMString();
                node.Children = reader.ReadGMInt();

                // If the node has child nodes
                if (node.Children > 0)
                {
                    // Create a new node array
                    node.Nodes = new GMNode[node.Children];

                    // Iterate through children
                    for (int i = 0; i < node.Children; i++)
                    {
                        // Add new node
                        node.Nodes[i] = new GMNode();
                    }

                    // Read in child nodes recursively
                    ReadNodeRecursive(node, reader);
                }
            }
        }

        /// <summary>
        /// Reads an object Tree from a GMX file
        /// </summary>
        /// <param name="file">The Assets GMX file path</param>
        public static GMNode ReadTreeGMX(string file, out List<string> assets)
        {
            try
            {
                // Set the asset list
                assets = new List<string>();

                // Create an xml document from the file
                XmlDocument document = new XmlDocument();
                document.Load(file);
                
                // Create the project node
                GMNode projectTree = new GMNode();
                projectTree.Name = Path.GetFileName(file);
                projectTree.Name = projectTree.Name.Remove(projectTree.Name.IndexOf("."));

                // Get all child nodes
                ReadTreeRecursiveGMX(document.DocumentElement, projectTree, GMResourceType.None, assets);
                projectTree.NodeType = GMNodeType.Parent;

                // Return the project node
                return projectTree;
            }
            catch (XmlException xmlEx)
            {
                throw new Exception("Could not read GMX file: " + file + ".");
            }
            catch (Exception ex)
            {
                throw new Exception("Could not read GMX file: " + file + ".");
            }
        }

        /// <summary>
        /// Reads an XML recursively
        /// </summary>
        /// <param name="xmlNode">The given xml node</param>
        /// <param name="node">The given GM node to set up</param>
        private static void ReadTreeRecursiveGMX(XmlNode xmlNode, GMNode node, GMResourceType type, List<string> assets)
        {
            // If the node's parent is the root node
            if (xmlNode.ParentNode.Name == "assets")
                type = GetResourceType(xmlNode.Name);

            // If the current xmlnode has children
            if (xmlNode.HasChildNodes)
            {
                // Set node properties
                node.Nodes = new GMNode[xmlNode.ChildNodes.Count];
                node.Children = node.Nodes.Length;
                node.NodeType = xmlNode.ParentNode.Name != "assets" ? GMNodeType.Group : GMNodeType.Parent;
                node.ResourceType = type;

                // Iterate through the list of child xml nodes
                for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                {
                    // Create a new xml node
                    XmlNode newXMLNode = xmlNode.ChildNodes[i];

                    // Flag to use the parent node for the value
                    bool avoid = xmlNode.ChildNodes[i].Name == "#text";

                    // If not avoiding setting a node
                    if (!avoid)
                    {
                        // Create a new GM node
                        GMNode newNode = new GMNode();
                        newNode.Name = CleanNodeName(newXMLNode.Name);
                        node.Nodes[i] = newNode;
                    }

                    // Run through the node recursively, use previous node for next node if avoiding
                    ReadTreeRecursiveGMX(newXMLNode, avoid ? node : node.Nodes[i], type, assets);
                }
            }
            else
            {
                // Set node properties
                node.Name = CleanNodeName((xmlNode.OuterXml).Trim());
                node.NodeType = (xmlNode.OuterXml).Trim().Contains("<") ? GMNodeType.Parent : GMNodeType.Child;
                node.Nodes = null;
                node.ResourceType = type;

                // If a child node, set node Id and add to asset list
                if (node.NodeType == GMNodeType.Child && type != GMResourceType.None)
                {
                    node.Id = GMResource.GetIdFromName(node.Name);
                    assets.Add(node.Name);
                }
            }
        }

        /// <summary>
        /// Cleans the xml node name to represent only the resource name
        /// </summary>
        /// <param name="name">The name to clean up</param>
        /// <returns>A clean up name</returns>
        private static string CleanNodeName(string name)
        {
            // If there is resource pathing, remove it
            if (name.Contains("\\"))
                name = name.Remove(0, name.LastIndexOf("\\")).Replace("\\", "");

            // Replace xml tag syntax
            name = name.Replace(".gml", "");
            name = name.Replace("<", "").Replace(">", "");
            name = name.Replace("NewExtensions /", "Extensions");
            name = name.Replace("<NewExtensions />", "Extensions");
            name = name.Replace("backgrounds name=\"background\" /", "Backgrounds");
            name = name.Replace("objects name=\"objects\" /", "Objects");
            name = name.Replace("paths name=\"paths\" /", "Paths");
            name = name.Replace("rooms name=\"rooms\" /", "Rooms");
            name = name.Replace("scripts name=\"scripts\" /", "Scripts");
            name = name.Replace("shaders name=\"shaders\" /", "Shaders");
            name = name.Replace("sounds name=\"sounds\" /", "Sounds");
            name = name.Replace("sprites name=\"sprites\" /", "Sprites");
            name = name.Replace("backgrounds", "Backgrounds");
            name = name.Replace("fonts", "Fonts");
            name = name.Replace("objects", "Objects");
            name = name.Replace("paths", "Paths");
            name = name.Replace("rooms", "Rooms");
            name = name.Replace("scripts", "Scripts");
            name = name.Replace("shaders", "Shaders");
            name = name.Replace("sounds", "Sounds");
            name = name.Replace("sprites", "Sprites");
            name = name.Replace("constants", "Constants");
            name = name.Replace("help", "Help");
            return name;
        }

        /// <summary>
        /// Gets a GM resource type based on the resource name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static GMResourceType GetResourceType(string name)
        {
            // Get resource type based on resource name
            switch (name.ToLower())
            {
                case "backgrounds": return GMResourceType.Backgrounds;
                case "objects": return GMResourceType.Objects;
                case "paths": return GMResourceType.Paths;
                case "rooms": return GMResourceType.Rooms;
                case "scripts": return GMResourceType.Scripts;
                case "shaders": return GMResourceType.Shaders;
                case "sounds": return GMResourceType.Sounds;
                case "sprites": return GMResourceType.Sprites;
                default: return GMResourceType.None;
            }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>A custom name for the object</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}