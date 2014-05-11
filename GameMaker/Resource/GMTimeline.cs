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
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 12 + Name.Length;

            if (_moments != null)
            {
                foreach (GMMoment moment in _moments)
                    size += moment.GetSize();
            }

            return size;
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
}