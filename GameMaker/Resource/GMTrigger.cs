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
    public class GMTrigger : GMResource
    {
        #region Fields

        private static double _lastChanged = 0;          // Last time the trigger as a whole was changed.
        private MomentType _moment = MomentType.Middle;  // What step the trigger happens on.
        private string _condition = "";                  // The condition script.
        private string _constant = "";                   // Naming constant.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the last time the trigger as a whole was changed.
        /// </summary>
        public static double TriggerLastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        /// <summary>
        /// Gets or sets the step the trigger happens on.
        /// </summary>
        public MomentType Moment
        {
            get { return _moment; }
            set { _moment = value; }
        }

        /// <summary>
        /// Gets or sets the condition script.
        /// </summary>
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        /// <summary>
        /// Gets or sets the naming constant.
        /// </summary>
        public string Constant
        {
            get { return _constant; }
            set { _constant = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads all triggers from GM file reader stream.
        /// </summary>
        public static GMList<GMTrigger> ReadTriggers(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 800)
                throw new Exception("Unsupported Pre-Trigger object version.");

            // Create a new trigger list.
            GMList<GMTrigger> triggers = new GMList<GMTrigger>();

            // Amount of trigger ids.
            int num = reader.ReadGMInt();

            // Iterate through triggers.
            for (int i = 0; i < num; i++)
            {
                // Start inflate.
                reader.Decompress();

                // If the trigger at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    triggers.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 800)
                    throw new Exception("Unsupported trigger object version.");

                // Create a new trigger.
                GMTrigger trigger = new GMTrigger();

                // Read trigger data.
                trigger.Name = reader.ReadGMString();
                trigger.Condition = reader.ReadGMString();
                trigger.Moment = (MomentType)reader.ReadGMInt();
                trigger.Constant = reader.ReadGMString();

                // End object inflate.
                reader.EndDecompress();

                // Add trigger.
                triggers.Add(trigger);
            }

            // Get last changed.
            GMTrigger.TriggerLastChanged = reader.ReadGMDouble();

            // Return triggers.
            return triggers;
        }

        #endregion
    }
}
