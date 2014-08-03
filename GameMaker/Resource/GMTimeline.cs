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
    public class GMTimeline : GMResource
    {
        #region Fields

        private GMMoment[] _moments = null;

        #endregion

        #region Properties

        public GMMoment[] Moments
        {
            get { return _moments; }
            set { _moments = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads all GMX timelines from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of timelines</returns>
        public static GMList<GMTimeline> ReadTimelinesGMX(string directory, List<string> assets)
        {
            // A list of timelines
            GMList<GMTimeline> timelines = new GMList<GMTimeline>();
            timelines.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the timeline
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of object properties
                Dictionary<string, string> objectProperties = new Dictionary<string, string>();
                foreach (GMXObjectProperty property in Enum.GetValues(typeof(GMXObjectProperty)))
                    objectProperties.Add(GMXEnumString(property), "");

                // Create a dictionary of action properties
                Dictionary<string, string> actionProperties = new Dictionary<string, string>();
                foreach (GMXActionProperty property in Enum.GetValues(typeof(GMXActionProperty)))
                    actionProperties.Add(GMXEnumString(property), "");

                // Create a dictionary of argument properties
                Dictionary<string, string> argumentProperties = new Dictionary<string, string>();
                foreach (GMXArgumentProperty property in Enum.GetValues(typeof(GMXArgumentProperty)))
                    argumentProperties.Add(GMXEnumString(property), "");

                // Local variables
                List<GMMoment> moments = new List<GMMoment>();

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

                        // Create a new moment and get it's properties
                        GMMoment moment = new GMMoment();

                        // If the element is an event
                        if (nodeName.ToLower() == GMXEnumString(GMXObjectProperty.Event).ToLower())
                        {
                            // Action list
                            List<GMAction> actions = new List<GMAction>();

                            // Seek to content
                            reader.MoveToContent();

                            // Create a reader for the actions
                            using (XmlReader reader2 = reader.ReadSubtree())
                            {
                                // Argument list
                                List<GMArgument> arguments = new List<GMArgument>();

                                // Read in action properties
                                while (reader2.Read())
                                {
                                    // If the node is not an element, continue
                                    if (reader.NodeType != XmlNodeType.Element)
                                        continue;

                                    // Get the element name
                                    string nodeName2 = reader2.Name;

                                    // If the node is an argument
                                    if (nodeName2.ToLower() == EnumString.GetEnumString(GMXObjectProperty.Argument).ToLower())
                                    {
                                        // Seek to content
                                        reader2.MoveToContent();

                                        // Create a reader for the arguments
                                        using (XmlReader reader3 = reader2.ReadSubtree())
                                        {
                                            // Read in argument properties
                                            while (reader3.Read())
                                            {
                                                // If the node is not an element, continue
                                                if (reader.NodeType != XmlNodeType.Element)
                                                    continue;

                                                // Get the element name
                                                string nodeName3 = reader3.Name;

                                                // Read element
                                                reader3.Read();

                                                // If the element value is null or empty, continue
                                                if (String.IsNullOrEmpty(reader3.Value))
                                                    continue;

                                                // Set the property value
                                                argumentProperties[nodeName3] = reader3.Value;
                                            }

                                            // Create a new argument
                                            GMArgument argument = new GMArgument();
                                            argument.Type = GMXInt(argumentProperties[GMXEnumString(GMXArgumentProperty.Kind)], argument.Type);
                                            argument.Value = GMXString(argumentProperties[GMXEnumString(GMXArgumentProperty.String)], argument.Value);

                                            // Add argument to the list
                                            arguments.Add(argument);
                                        }
                                    }

                                    // Read element
                                    reader2.Read();

                                    // If the element value is null or empty, continue
                                    if (String.IsNullOrEmpty(reader2.Value))
                                        continue;

                                    // Set the property value
                                    actionProperties[nodeName2] = reader2.Value;
                                }

                                // Create a new action
                                GMAction action = new GMAction();
                                action.LibraryId = GMXInt(actionProperties[GMXEnumString(GMXActionProperty.LibId)], action.LibraryId);
                                action.ActionId = GMXInt(actionProperties[GMXEnumString(GMXActionProperty.Id)], action.ActionId);
                                action.ActionKind = GMXInt(actionProperties[GMXEnumString(GMXActionProperty.Kind)], action.ActionKind);
                                action.AllowRelative = GMXBool(actionProperties[GMXEnumString(GMXActionProperty.UseRelative)], action.AllowRelative);
                                action.Question = GMXBool(actionProperties[GMXEnumString(GMXActionProperty.IsQuestion)], action.Question);
                                action.CanApplyTo = GMXBool(actionProperties[GMXEnumString(GMXActionProperty.UseApplyTo)], action.CanApplyTo);
                                action.ExecuteMode = GMXInt(actionProperties[GMXEnumString(GMXActionProperty.ExeType)], action.ExecuteMode);
                                action.FunctionName = GMXString(actionProperties[GMXEnumString(GMXActionProperty.FunctionName)], action.FunctionName);
                                action.ExecuteCode = GMXString(actionProperties[GMXEnumString(GMXActionProperty.CodeString)], action.ExecuteCode);
                                action.AppliesToName = GMXString(actionProperties[GMXEnumString(GMXActionProperty.WhoName)], action.AppliesToName);
                                action.AppliesTo = action.AppliesToName == "" ? -1 : GetIdFromName(action.AppliesToName);
                                action.Relative = GMXBool(actionProperties[GMXEnumString(GMXActionProperty.Relative)], action.Relative);
                                action.Not = GMXBool(actionProperties[GMXEnumString(GMXActionProperty.IsNot)], action.Not);
                                action.Arguments = arguments.ToArray();

                                // Add action to the list
                                actions.Add(action);
                            }

                            // Set the events actions
                            moment.Actions = actions.ToArray();
                            moments.Add(moment);
                        }

                        if (nodeName.ToLower() == "step")
                        {
                            // Read element
                            reader.Read();

                            // If the element value is null or empty, continue
                            if (String.IsNullOrEmpty(reader.Value))
                                continue;

                            moment.StepIndex = GMXInt(reader.Value, moment.StepIndex);
                            moments.Add(moment);
                        }

                        // Set the property value
                        objectProperties[nodeName] = reader.Value;
                    }
                }

                // Create a new timeline, set properties
                GMTimeline timeline = new GMTimeline();
                timeline.Moments = moments.ToArray();

                // Add the timeline
                timelines.Add(timeline);
            }

            // Return the list of timelines
            return timelines;
        }

        /// <summary>
        /// Reads timelines from GM file.
        /// </summary>
        public static GMList<GMTimeline> ReadTimelines(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 500 && version != 800)
                throw new Exception("Unsupported Pre-Timeline object version.");

            // Create a new timeline list.
            GMList<GMTimeline> timelines = new GMList<GMTimeline>();

            // Amount of timeline ids.
            int num = reader.ReadGMInt();

            // Iterate through timelines
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the timeline at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    timelines.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new timeline object.
                GMTimeline timeline = new GMTimeline();

                // Set timeline id.
                timeline.Id = i;

                // Read timeline data.
                timeline.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    timeline.LastChanged = reader.ReadGMDouble();

                // Get version.
                int version2 = reader.ReadGMInt();

                // Check version.
                if (version2 != 500)
                    throw new Exception("Unsupported Timeline object version.");

                // Get number of timeline moments.
                timeline.Moments = new GMMoment[reader.ReadGMInt()];

                // Iterate through moments.
                for (int j = 0; j < timeline.Moments.Length; j++)
                {
                    // Create a new timeline moment object.
                    GMMoment moment = new GMMoment();

                    // Moment step number
                    moment.StepIndex = reader.ReadGMInt();

                    // Read moment actions.
                    moment.Actions = GMAction.ReadActions(reader);

                    // Add moment to timeline.
                    timeline.Moments[j] = moment;
                }

                // End object inflate.
                reader.EndDecompress();

                // Add timeline.
                timelines.Add(timeline);
            }

            // Return timelines.
            return timelines;
        }

        #endregion
    }

    [Serializable]
    public class GMMoment
    {
        #region Fields

        private GMAction[] _actions = null;
        private int _stepIndex = 0;

        #endregion

        #region Properties

        public GMAction[] Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public int StepIndex
        {
            get { return _stepIndex; }
            set { _stepIndex = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 4;

            if (_actions != null)
            {
                foreach (GMAction action in _actions)
                    size += action.GetSize();
            }

            return size;
        }

        #endregion
    }

    [Serializable]
    public class GMEntry
    {
        #region Fields

        private GMEvent[] _events = null;
        private int _stepIndex = 0;

        #endregion

        #region Properties

        public GMEvent[] Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public int StepIndex
        {
            get { return _stepIndex; }
            set { _stepIndex = value; }
        }

        #endregion
    }
}