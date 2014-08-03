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
using GameMaker.Project;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMNode : GMResource
    {
        #region Fields

        private GMNodeType _nodeType = GMNodeType.Parent;
        private GMResourceType _resourceType = GMResourceType.None;
        private GMResourceSubType _resourceSubType = GMResourceSubType.None;
        private GMNode[] _nodes = null;
        private object _tag = null;
        private string _filePath = "";
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

        public GMResourceSubType ResourceSubType
        {
            get { return _resourceSubType; }
            set { _resourceSubType = value; }
        }

        public GMNode[] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public int Children
        {
            get { return _children; }
            set { _children = value; }
        }

        #endregion

        #region Methods

        #region Read

        #region Game Maker 5 - 8.1

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

        #endregion

        #region Game Maker Studio

        /// <summary>
        /// Gets the given resource type's project node
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static GMNode ReadTreeNodeGMX(string file, GMResourceType type)
        {
            // Get all the project nodes
            Dictionary<string, string> assets = new Dictionary<string, string>();
            GMNode parent = ReadTreeGMX(file);

            // Iterate through nodes till we find the desired type
            foreach (GMNode node in parent.Nodes)
                if (node.ResourceType == type)
                    return node;

            // The resource type could not be found
            return null;
        }

        /// <summary>
        /// Reads a project tree from a GMX project file
        /// </summary>
        /// <param name="file">Path to the project file</param>
        /// <returns>A root project node</returns>
        public static GMNode ReadTreeGMX(string file)
        {
            // Set the asset list
            List<string> assets = new List<string>();

            // Create the project node
            GMNode root = new GMNode();
            
            // Create an xml document from the file
            XmlDocument document = new XmlDocument();
            document.Load(file);

            // Iterate through child nodes
            foreach (XmlNode node in document.ChildNodes)
            {
                // If not a valid node, continue
                if (!IsValidXmlNode(node))
                    continue;

                // Read the child nodes
                ReadNodes(node, root, GMResourceType.None, assets);
            }

            // Return the project node
            root.Name = Path.GetFileNameWithoutExtension(file);
            root.NodeType = GMNodeType.Root;
            root.Tag = assets;
            return root;
        }

        /// <summary>
        /// Reads nodes recursively
        /// </summary>
        /// <param name="xmlNode">The current xml node</param>
        /// <param name="gmNode">The current Game Maker node</param>
        /// <param name="type">The current resource type</param>
        /// <param name="assets">The asset list to add any assets to</param>
        private static void ReadNodes(XmlNode xmlNode, GMNode gmNode, GMResourceType type, List<string> assets)
        {
            // If not a valid node, continue
            if (!IsValidXmlNode(xmlNode))
                return;

            // Read node data
            gmNode.NodeType = GetNodeType(xmlNode);
            gmNode.FilePath = gmNode.NodeType == GMNodeType.Child ? xmlNode.Value : "";
            gmNode.ResourceType = gmNode.NodeType == GMNodeType.Parent ? GetResourceType(xmlNode.Name) : type;
            gmNode.ResourceSubType = GetResourceSubType(xmlNode.ParentNode.Name);
            gmNode.Name = GetNodeName(xmlNode, gmNode);
            gmNode.Id = gmNode.NodeType == GMNodeType.Child ? GetIdFromName(gmNode.Name) : -1;
            gmNode.Children = xmlNode.HasChildNodes ? xmlNode.ChildNodes.Count : 0;
            gmNode.Nodes = gmNode.Children == 0 ? null : new GMNode[gmNode.Children];

            // If the node is a child and a major game resource, add to asset list
            if (gmNode.NodeType == GMNodeType.Child && gmNode.ResourceSubType != GMResourceSubType.None)
                assets.Add(gmNode.Name);

            // If there are no children, return
            if (gmNode.Children == 0)
                return;

            // Iterate through children
            for (int i = 0; i < gmNode.Children; i++)
            {
                gmNode.Nodes[i] = new GMNode();
                GMResourceSubType sub = GetResourceSubType(xmlNode.ChildNodes[i].Name);

                // If the next node is a resource subtype node, skip it and just get its text value, else read as usual
                if (sub != GMResourceSubType.None)
                {
                    gmNode.Nodes[i].Tag = GetChildNodeAttribute(xmlNode.ChildNodes[i]);

                    if (sub == GMResourceSubType.DataFile)
                        ReadNodes(xmlNode.ChildNodes[i].ChildNodes[0].ChildNodes[0], gmNode.Nodes[i], gmNode.ResourceType, assets);
                    else
                        ReadNodes(xmlNode.ChildNodes[i].ChildNodes[0], gmNode.Nodes[i], gmNode.ResourceType, assets);
                }
                else
                    ReadNodes(xmlNode.ChildNodes[i], gmNode.Nodes[i], gmNode.ResourceType, assets);
            }
        }

        /// <summary>
        /// Gets the resource type of the node
        /// </summary>
        /// <returns></returns>
        private static GMResourceType GetResourceType(string name)
        {
            // Iterate through resource type enumerations
            foreach (string enumeration in EnumString.GetEnumStrings(typeof(GMResourceType)))
                if (name == enumeration)
                    return (GMResourceType)EnumString.GetEnumFromString<GMResourceType>(name);

            // No match, set to none
            return GMResourceType.None;
        }

        /// <summary>
        /// Gets the resource subtype of the node
        /// </summary>
        /// <returns></returns>
        private static GMResourceSubType GetResourceSubType(string name)
        {
            // Iterate through resource subtype enumerations
            foreach (string enumeration in EnumString.GetEnumStrings(typeof(GMResourceSubType)))
                if (name == enumeration)
                    return (GMResourceSubType)EnumString.GetEnumFromString<GMResourceSubType>(name);

            // No match, set to none
            return GMResourceSubType.None;
        }

        /// <summary>
        /// Determines what kind of role the node has
        /// </summary>
        /// <param name="node">The given xml node to check</param>
        /// <returns>If the node is a parent, group, or child</returns>
        private static GMNodeType GetNodeType(XmlNode node)
        {
            // If the node is a text type, it carries a value so it is a child node
            // Else if the node's parent is the asset node, it is major resource parent node
            // Else it is a group node
            return node.NodeType == XmlNodeType.Text ? GMNodeType.Child :
                node.ParentNode.Name == EnumString.GetEnumString(GMResourceType.Assets) ? GMNodeType.Parent : GMNodeType.Group;
        }

        /// <summary>
        /// Looking for text and elements only
        /// </summary>
        /// <param name="node">The given xml node to validify</param>
        /// <returns>If the xml node is a valid node to use</returns>
        private static bool IsValidXmlNode(XmlNode node)
        {
            return !((String.IsNullOrEmpty(node.Name) && node.NodeType != XmlNodeType.Text) ||
                node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.Whitespace ||
                node.NodeType == XmlNodeType.EndElement);
        }

        /// <summary>
        /// Gets the name for the GMNode based on node type
        /// </summary>
        /// <param name="xmlNode">The xml node to extract the name from</param>
        /// <param name="gmNode">The Game Maker node to determine how to extract the name</param>
        /// <returns></returns>
        private static string GetNodeName(XmlNode xmlNode, GMNode gmNode)
        {
            // Get the node name based on node type
            switch (gmNode.NodeType)
            {
                case GMNodeType.Child: return xmlNode.Value.Substring(xmlNode.Value.LastIndexOf("\\") + 1); ;
                case GMNodeType.Group: return xmlNode.Attributes.Count > 0 ? xmlNode.Attributes[0].Value : xmlNode.Name;
                default: return xmlNode.Name;
            }
        }

        /// <summary>
        /// For now gets the first attribute node of a child node, if one exists
        /// This is for child nodes like shaders and extensions
        /// </summary>
        /// <param name="xmlNode">The xml node to check</param>
        /// <returns></returns>
        private static object GetChildNodeAttribute(XmlNode xmlNode)
        {
            // If the child node has an attribute
            if (xmlNode.Attributes != null && xmlNode.Attributes.Count > 0)
                return new KeyValuePair<string, string>(xmlNode.Attributes[0].Name, xmlNode.Attributes[0].Value);
            else
                return null;
        }

        #endregion

        #endregion

        #region Write

        #region Game Maker Studio

        /// <summary>
        /// Writes a project tree to the given file path
        /// </summary>
        /// <param name="file">The file path to write to</param>
        /// <param name="project">Project reference</param>
        /// <returns></returns>
        public static void WriteNodesGMX(string file, ref GMProject project)
        {
            // Create a file stream and xml text writer to create project tree file
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(sw))
                    {
                        // Same setup as Game Maker
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;

                        // GMX standard header comment and start of assets
                        writer.WriteComment(GMUtilities.GMXHeaderComment);
                        writer.WriteStartElement(GMXEnumString(GMResourceType.Assets));

                        // If the project has a hash number, write it as an attribute
                        if (project.Settings.Hash != "")
                            writer.WriteAttributeString(GMXEnumString(GMResourceType.Hash), project.Settings.Hash);

                        // Iterate through parent nodes
                        foreach (GMNode node in project.ProjectTree.Nodes)
                        {
                            // If the data files node, and it has data files
                            if (node.ResourceType == GMResourceType.DataFiles && node.Nodes != null)
                            {
                                // Write data files node and attributes
                                writer.WriteStartElement(GMXEnumString(GMResourceType.DataFiles));
                                writer.WriteAttributeString(GMXEnumString(GMXDataFileProperty.Number), node.Nodes.Length.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXDataFileProperty.Name), GMXEnumString(GMResourceType.DataFiles));

                                // Go through data file nodes
                                foreach (GMNode dataNode in node.Nodes)
                                {
                                    // Get the data file object
                                    GMDataFile dataFile = project.DataFiles.Find(d => d.Name == dataNode.Name);

                                    // If there is no datafile, continue
                                    if (dataFile == null)
                                        continue;

                                    // Write the data file
                                    writer.WriteStartElement(GMXEnumString(GMResourceSubType.DataFile));
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Name), dataFile.Name);
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Exists), GetGMXBool(dataFile.Exists));
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Size), dataFile.Size.ToString());
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.ExportAction), dataFile.ExportAction.ToString());
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.ExportDir), dataFile.ExportDirectory);
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Overwrite), GetGMXBool(dataFile.OverwriteFile));
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.FreeData), GetGMXBool(dataFile.FreeDataMemory));
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.RemoveEnd), GetGMXBool(dataFile.RemoveAtGameEnd));
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Store), GetGMXBool(dataFile.Store));

                                    // Write the configs for the datafile
                                    writer.WriteStartElement(GMXEnumString(GMResourceType.ConfigOptions));
                                    foreach (GMConfig config in dataFile.Configs)
                                    {
                                        writer.WriteStartElement(GMXEnumString(GMResourceSubType.Config));
                                        writer.WriteAttributeString(GMXEnumString(GMXDataFileProperty.Name), config.Name);
                                        XMLWriteFullElement(writer, GMXEnumString(GMXConfigProperty.CopyToMask), config.CopyToMask.ToString());
                                        writer.WriteEndElement();
                                    }
                                    writer.WriteEndElement();

                                    // Finish writing the datafile
                                    XMLWriteFullElement(writer, GMXEnumString(GMXDataFileProperty.Filename), dataFile.FileName);
                                    writer.WriteEndElement();
                                }
                                
                                writer.WriteEndElement();
                                continue;
                            }

                            // If the tutorial node, write out values and continue
                            if (node.ResourceType == GMResourceType.TutorialState)
                            {
                                writer.WriteStartElement(GMXEnumString(node.ResourceType));
                                XMLWriteFullElement(writer, GMXEnumString(GMXTutorialStateProperty.IsTutorial), GetGMXBool(project.Settings.IsTutorial));
                                XMLWriteFullElement(writer, GMXEnumString(GMXTutorialStateProperty.TutorialName), project.Settings.TutorialName);
                                XMLWriteFullElement(writer, GMXEnumString(GMXTutorialStateProperty.TutorialPage), project.Settings.TutorialPage.ToString());
                                writer.WriteEndElement();
                                continue;
                            }

                            // If the parent node has children, write recursively
                            if (node.Children > 0)
                                WriteTreeRecursiveGMX(writer, node);
                            // If a default node that has no children, but that needs to be written anyways
                            else if (IsDefaultNode(node.ResourceType))
                            {
                                writer.WriteStartElement(GMXEnumString(node.ResourceType));

                                // If a resource that has a name attribute, write it
                                if (HasNameAttribute(node.ResourceType))
                                    writer.WriteAttributeString("name", GetParentName(node.ResourceType));
                                
                                writer.WriteEndElement();
                            }
                        }

                        // Done writing asset tree
                        writer.WriteEndElement();
                    }
                }
            }
        }

        /// <summary>
        /// Reads an XML recursively
        /// </summary>
        /// <param name="xmlNode">The given xml node</param>
        /// <param name="node">The given GM node to set up</param>
        private static void WriteTreeRecursiveGMX(XmlTextWriter writer, GMNode node)
        {
            // If a child, write out value and return
            if (node.NodeType == GMNodeType.Child)
            {
                // If the child has an attribute
                if (node.Tag != null)
                {
                    KeyValuePair<string, string> attribute = (KeyValuePair<string, string>)node.Tag;
                    XMLWriteFullElement(writer, GMXEnumString(node.ResourceSubType), node.FilePath,
                        attribute.Key, attribute.Value);
                }
                else
                    XMLWriteFullElement(writer, GMXEnumString(node.ResourceSubType), node.FilePath);
                return;
            }

            // Start writing the element
            writer.WriteStartElement(GMXEnumString(node.ResourceType));

            // If not a parent node that has no attribute name, write the name attribute
            if (!(node.NodeType == GMNodeType.Parent && !HasNameAttribute(node.ResourceType)))
                writer.WriteAttributeString("name", node.NodeType == GMNodeType.Group ? node.Name : GetParentName(node.ResourceType));

            // If the node has children
            if (node.Nodes != null && node.Nodes.Length > 0)
            {
                // Write all children
                for (int i = 0; i < node.Nodes.Length; i++)
                    WriteTreeRecursiveGMX(writer, node.Nodes[i]);
            }

            // End writing the element
            writer.WriteEndElement();
        }

        /// <summary>
        /// If the Game Maker resource gets written to file regardless of if it has resources or not
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsDefaultNode(GMResourceType type)
        {
            return (type == GMResourceType.Configs || type == GMResourceType.NewExtensions ||
                    type == GMResourceType.Sounds || type == GMResourceType.Sprites ||
                    type == GMResourceType.Backgrounds || type == GMResourceType.Paths ||
                    type == GMResourceType.TutorialState);
        }

        /// <summary>
        /// If a parent node has a name attribute for their resource type
        /// </summary>
        /// <param name="type">The resource type of the parent node</param>
        /// <returns>Id the parent node has a name attribute</returns>
        private static bool HasNameAttribute(GMResourceType type)
        {
            return !(type == GMResourceType.NewExtensions || type == GMResourceType.Help);
        }

        /// <summary>
        /// Gets the name attribute of a parent node
        /// </summary>
        /// <param name="type">The resource type of the parent node</param>
        /// <returns>The name attribute value of the parent node</returns>
        private static string GetParentName(GMResourceType type)
        {
            // Get the name value of the resource type
            string name = GMXEnumString(type).ToLower();

            // Shave off the 's' character at the end of the string
            if (type == GMResourceType.Sounds || type == GMResourceType.Backgrounds)
                name = name.Remove(name.Length - 1);

            // Return the resource name of the parent
            return name;
        }

        #endregion

        #endregion

        #endregion
    }
}