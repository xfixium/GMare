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
    public class GMObject : GMResource
    {
        #region Fields

        private List<GMEvent>[] _events = new List<GMEvent>[12];
        private GMPoint[] _physicsShapePoints = null;
        private PhysicsShapeType _physicsObjectShape = 0;
        private string _spriteName = "";
        private string _parentName = "";
        private string _maskName = "";
        private double _physicsObjectDensity = 0.5;
        private double _physicsObjectRestitution = 0.100000001490116;
        private double _physicsObjectLinearDamping = 0.100000001490116;
        private double _physicsObjectAngularDamping = 0.100000001490116;
        private double _physicsObjectFriction = 0.200000002980232;
        private int _spriteId = -1;
        private int _mask = -1;
        private int _parent = -1;
        private int _depth = 0;
        private int _physicsObjectGroup = 0;
        private bool _solid = false;
        private bool _visible = true;
        private bool _persistent = false;
        private bool _physicsObject = false;
        private bool _physicsObjectSensor = false;
        private bool _physicsObjectStartAwake = false;
        private bool _physicsObjectKinematic = true;

        #endregion

        #region Properties

        public List<GMEvent>[] Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public GMPoint[] PhysicsShapePoints
        {
            get { return _physicsShapePoints; }
            set { _physicsShapePoints = value; }
        }

        public PhysicsShapeType PhysicsObjectShape
        {
            get { return _physicsObjectShape; }
            set { _physicsObjectShape = value; }
        }

        public string SpriteName
        {
            get { return _spriteName; }
            set { _spriteName = value; }
        }

        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }

        public string MaskName
        {
            get { return _maskName; }
            set { _maskName = value; }
        }

        public double PhysicsObjectDensity
        {
            get { return _physicsObjectDensity; }
            set { _physicsObjectDensity = value; }
        }

        public double PhysicsObjectRestitution
        {
            get { return _physicsObjectRestitution; }
            set { _physicsObjectRestitution = value; }
        }

        public double PhysicsObjectLinearDamping
        {
            get { return _physicsObjectLinearDamping; }
            set { _physicsObjectLinearDamping = value; }
        }

        public double PhysicsObjectAngularDamping
        {
            get { return _physicsObjectAngularDamping; }
            set { _physicsObjectAngularDamping = value; }
        }

        public double PhysicsObjectFriction
        {
            get { return _physicsObjectFriction; }
            set { _physicsObjectFriction = value; }
        }

        public int SpriteId
        {
            get { return _spriteId; }
            set { _spriteId = value; }
        }

        public int Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public int Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public int PhysicsObjectGroup
        {
            get { return _physicsObjectGroup; }
            set { _physicsObjectGroup = value; }
        }

        public bool Solid
        {
            get { return _solid; }
            set { _solid = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool Persistent
        {
            get { return _persistent; }
            set { _persistent = value; }
        }

        public bool PhysicsObject
        {
            get { return _physicsObject; }
            set { _physicsObject = value; }
        }

        public bool PhysicsObjectSensor
        {
            get { return _physicsObjectSensor; }
            set { _physicsObjectSensor = value; }
        }

        public bool PhysicsObjectStartAwake
        {
            get { return _physicsObjectStartAwake; }
            set { _physicsObjectStartAwake = value; }
        }

        public bool PhysicsObjectKinematic
        {
            get { return _physicsObjectKinematic; }
            set { _physicsObjectKinematic = value; }
        }

        #endregion

        #region Constructor

        public GMObject()
        {
            for (int i = 0; i < _events.Length; i++)
                _events[i] = new List<GMEvent>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads objects from GM file
        /// </summary>
        public static GMList<GMObject> ReadObjects(GMFileReader reader)
        {
            // Get version
            int version = reader.ReadGMInt();

            // Check version
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Object object version.");

            // The number of objects
            GMList<GMObject> objects = new GMList<GMObject>();

            // Amount of object ids
            int num = reader.ReadGMInt();

            // Iterate through objects
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate
                if (version == 800)
                    reader.Decompress();

                // If the object at index does not exists, continue
                if (reader.ReadGMBool() == false)
                {
                    objects.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new script object
                GMObject obj = new GMObject();

                // Set script id
                obj.Id = i;

                // Read script data.
                obj.Name = reader.ReadGMString();

                // If version is 8.0, get last changed
                if (version == 800)
                    obj.LastChanged = reader.ReadGMDouble();

                // Get version
                int version2 = reader.ReadGMInt();

                // Check version
                if (version2 != 430)
                    throw new Exception("Unsupported Object object version.");

                // Read object data
                obj.SpriteId = reader.ReadGMInt();
                obj.Solid = reader.ReadGMBool();
                obj.Visible = reader.ReadGMBool();
                obj.Depth = reader.ReadGMInt();
                obj.Persistent = reader.ReadGMBool();
                obj.Parent = reader.ReadGMInt();
                obj.Mask = reader.ReadGMInt();

                // Skip data
                reader.ReadGMBytes(4);

                // The amount of main event types
                int amount = 11;

                // If version 8.0, there are 12 main event types
                if (version == 800)
                    amount = 12;

                // Iterate through events
                for (int j = 0; j < amount; j++)
                {
                    // Not done processing
                    bool done = false;

                    // While not done processing events
                    while (!done)
                    {
                        // Check for event
                        int eventNum = reader.ReadGMInt();

                        // If the event exists
                        if (eventNum != -1)
                        {
                            // Create new event
                            GMEvent ev = new GMEvent();

                            // Set type of event
                            ev.MainType = (EventType)(j);

                            // If a collision type of event set other object id
                            if (ev.MainType == EventType.Collision)
                                ev.OtherId = eventNum;
                            else
                                ev.SubType = eventNum;

                            // Read event actions
                            ev.Actions = GMAction.ReadActions(reader);

                            // Add new event
                            obj.Events[j].Add(ev);
                        }
                        else
                            done = true;
                    }
                }

                // End object inflate
                reader.EndDecompress();

                // Add object to list
                objects.Add(obj);
            }

            // Return objects
            return objects;
        }

        /// <summary>
        /// Reads all GMX objects from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of objects</returns>
        public static GMList<GMObject> ReadObjectsGMX(string directory, List<string> assets)
        {
            // A list of objects
            GMList<GMObject> objects = new GMList<GMObject>();

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the object
                string name = GMFileReader.GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of object properties
                Dictionary<GMXObjectProperty, string> objectProperties = new Dictionary<GMXObjectProperty, string>();

                foreach (GMXObjectProperty property in Enum.GetValues(typeof(GMXObjectProperty)))
                    objectProperties.Add(property, "");

                // Create a dictionary of action properties
                Dictionary<GMXActionProperty, string> actionProperties = new Dictionary<GMXActionProperty, string>();

                foreach (GMXActionProperty property in Enum.GetValues(typeof(GMXActionProperty)))
                    actionProperties.Add(property, "");

                // Create a dictionary of action properties
                Dictionary<GMXArgumentProperty, string> argumentProperties = new Dictionary<GMXArgumentProperty, string>();

                foreach (GMXArgumentProperty property in Enum.GetValues(typeof(GMXArgumentProperty)))
                    argumentProperties.Add(property, "");

                // Local variables
                List<GMEvent>[] events = new List<GMEvent>[12];
                List<GMPoint> physicsPoints = new List<GMPoint>();

                // Create an xml reader
                using (XmlReader xmlReader = XmlReader.Create(file))
                {
                    // Seek to content
                    xmlReader.MoveToContent();

                    // Read the GMX file
                    while (xmlReader.Read())
                    {
                        // If the node is not an element, continue
                        if (xmlReader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = xmlReader.Name;

                        // If the element is a event
                        if (nodeName.ToLower() == EnumString.GetEnumString(GMXObjectProperty.Event).ToLower())
                        {
                            // Create a new event and get it's properties
                            GMEvent gmEvent = new GMEvent();
                            int type = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXEventProperty.Eventtype)));
                            gmEvent.MainType = (EventType)type;

                            // If the event is a collision event, set the other name, else use subtype value
                            if (gmEvent.MainType == EventType.Collision)
                                gmEvent.OtherName = xmlReader.GetAttribute(EnumString.GetEnumString(GMXEventProperty.EName));
                            else
                                gmEvent.SubType = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXEventProperty.ENumb)));

                            // Action list
                            List<GMAction> actions = new List<GMAction>();

                            // Seek to content
                            xmlReader.MoveToContent();

                            // Create a reader for the actions
                            using (XmlReader xmlReader2 = xmlReader.ReadSubtree())
                            {
                                // Argument list
                                List<GMArgument> arguments = new List<GMArgument>();

                                // Read in action properties
                                while (xmlReader2.Read())
                                {
                                    // If the node is not an element, continue
                                    if (xmlReader.NodeType != XmlNodeType.Element)
                                        continue;

                                    // Get the element name
                                    string nodeName2 = xmlReader2.Name;

                                    // If the node is an argument
                                    if (nodeName2.ToLower() == EnumString.GetEnumString(GMXObjectProperty.Argument).ToLower())
                                    {
                                        // Seek to content
                                        xmlReader2.MoveToContent();

                                        // Create a reader for the arguments
                                        using (XmlReader xmlReader3 = xmlReader2.ReadSubtree())
                                        {
                                            // Read in argument properties
                                            while (xmlReader3.Read())
                                            {
                                                // If the node is not an element, continue
                                                if (xmlReader.NodeType != XmlNodeType.Element)
                                                    continue;

                                                // Get the element name
                                                string nodeName3 = xmlReader3.Name;

                                                // Read element
                                                xmlReader3.Read();

                                                // If the element value is null or empty, continue
                                                if (String.IsNullOrEmpty(xmlReader3.Value))
                                                    continue;

                                                // Get the enumeration based on the node name
                                                GMXArgumentProperty? property3 = EnumString.GetEnumFromString<GMXArgumentProperty>(nodeName3);

                                                // If no match was found, continue
                                                if (property3 == null)
                                                    continue;

                                                // Set the property value
                                                argumentProperties[(GMXArgumentProperty)property3] = xmlReader3.Value;
                                            }

                                            // Create a new argument
                                            GMArgument argument = new GMArgument();
                                            argument.Type = (ArgumentType)GMFileReader.ReadGMXInt(argumentProperties[GMXArgumentProperty.Kind]);
                                            argument.Value = argumentProperties[GMXArgumentProperty.String];
                                            
                                            // Add argument to the list
                                            arguments.Add(argument);
                                        }
                                    }

                                    // Read element
                                    xmlReader2.Read();

                                    // If the element value is null or empty, continue
                                    if (String.IsNullOrEmpty(xmlReader2.Value))
                                        continue;

                                    // Get the enumeration based on the node name
                                    GMXActionProperty? property2 = EnumString.GetEnumFromString<GMXActionProperty>(nodeName2);

                                    // If no match was found, continue
                                    if (property2 == null)
                                        continue;

                                    // Set the property value
                                    actionProperties[(GMXActionProperty)property2] = xmlReader2.Value;
                                }

                                // Create a new action
                                GMAction action = new GMAction();
                                action.LibraryId = GMFileReader.ReadGMXInt(actionProperties[GMXActionProperty.LibId]);
                                action.ActionId = GMFileReader.ReadGMXInt(actionProperties[GMXActionProperty.Id]);
                                action.ActionKind = (ActionType)GMFileReader.ReadGMXInt(actionProperties[GMXActionProperty.Kind]);
                                action.AllowRelative = GMFileReader.ReadGMXBool(actionProperties[GMXActionProperty.UseRelative]);
                                action.Question = GMFileReader.ReadGMXBool(actionProperties[GMXActionProperty.IsQuestion]);
                                action.CanApplyTo = GMFileReader.ReadGMXBool(actionProperties[GMXActionProperty.UseApplyTo]);
                                action.ExecuteMode = (ExecutionType)GMFileReader.ReadGMXInt(actionProperties[GMXActionProperty.ExeType]);
                                action.FunctionName = actionProperties[GMXActionProperty.FunctionName];
                                action.ExecuteCode = actionProperties[GMXActionProperty.CodeString];
                                action.AppliesToName = actionProperties[GMXActionProperty.WhoName];
                                action.Relative = GMFileReader.ReadGMXBool(actionProperties[GMXActionProperty.Relative]);
                                action.Not = GMFileReader.ReadGMXBool(actionProperties[GMXActionProperty.IsNot]);
                                action.Arguments = arguments.ToArray();

                                // Add action to the list
                                actions.Add(action);
                            }

                            // Set the events actions
                            gmEvent.Actions = actions.ToArray();

                            // If the event type list has not been generated, create it
                            if (events[type] == null)
                                events[type] = new List<GMEvent>();

                            // Add the event of the event type
                            events[type].Add(gmEvent);
                        }

                        // Read element
                        xmlReader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(xmlReader.Value))
                            continue;

                        // Get the enumeration based on the node name
                        GMXObjectProperty? property = EnumString.GetEnumFromString<GMXObjectProperty>(nodeName);

                        // If no match was found, continue
                        if (property == null)
                            continue;

                        // Set the property value
                        objectProperties[(GMXObjectProperty)property] = xmlReader.Value;
                    }
                }

                // Create a new object and set its properties
                GMObject obj = new GMObject();
                obj.Id = GMResource.GetIdFromName(name);
                obj.Name = name;
                obj.SpriteName = objectProperties[GMXObjectProperty.SpriteName];
                obj.Solid = GMFileReader.ReadGMXBool(objectProperties[GMXObjectProperty.Solid]);
                obj.Visible = GMFileReader.ReadGMXBool(objectProperties[GMXObjectProperty.Visible]);
                obj.Depth = GMFileReader.ReadGMXInt(objectProperties[GMXObjectProperty.Depth]);
                obj.Persistent = GMFileReader.ReadGMXBool(objectProperties[GMXObjectProperty.Persistent]);
                obj.ParentName = objectProperties[GMXObjectProperty.ParentName];
                obj.MaskName = objectProperties[GMXObjectProperty.MaskName];
                obj.Events = events;

                // Add the object
                objects.Add(obj);
            }
            
            // Return the list of objects
            return objects;
        }

        #endregion
    }
}