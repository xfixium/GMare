#region MIT

// 
// GMare.
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
using System.Windows.Forms;
using System.ComponentModel;
using GameMaker.Project;

namespace GMare.Forms
{
    /// <summary>
    /// A dialog that reads and writes Game Maker projects and shows the progression
    /// </summary>
    public partial class GMProjectLoadForm : Form
    {
        #region Fields

        private GMProject _project = null;  // The read in Game Maker project

        #endregion

        #region Properties

        /// <summary>
        /// Gets the read in Game Maker project
        /// </summary>
        public GMProject Project
        {
            get { return _project; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GM project form for reading
        /// </summary>
        /// <param name="path">Path to the Game Maker project file</param>
        public GMProjectLoadForm(string path)
        {
            InitializeComponent();

            // Set text
            this.Text = "Project Read";

            // Read project
            bgwProjectReader.RunWorkerAsync(path);
        }

        /// <summary>
        /// Constructs a new project form for writing
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="path">The path to write to</param>
        public GMProjectLoadForm(GMProject project, string path)
        {
            // Set text
            this.Text = "Project Write";

            // Set project to write
            _project = project;

            // Write project
            bgwProjectReader.RunWorkerAsync(path);
        }

        #endregion

        #region Events

        /// <summary>
        /// Project reader do work
        /// </summary>
        private void bgwProjectReader_DoWork(object sender, DoWorkEventArgs e)
        {
            // Create new Game Maker project, hook progress changed event, start reading project
            _project = new GMProject();
            _project.OnProgressChanged += new GMProject.ProgressChangedHandler(ReaderProgressChanged);
            _project.ReadProject(e.Argument.ToString());            
        }

        /// <summary>
        /// Project reader progress changed
        /// </summary>
        private void ReaderProgressChanged(string message, int position)
        {
            // Report progress 
            bgwProjectReader.ReportProgress(position, message);
        }

        /// <summary>
        /// Project reader progress changed
        /// </summary>
        private void bgwProjectReader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update UI
            this.Invalidate();

            // Set progress bar progress amount
            lblStatus.Text = e.UserState.ToString();

            // If still at minimum, return
            if (e.ProgressPercentage == barProgress.Minimum)
                return;

            // Hackish value jumping
            barProgress.Value = e.ProgressPercentage;
            barProgress.Value = e.ProgressPercentage - 1;
            barProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Preoject reader work completed
        /// </summary>
        private void bgwProjectReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Close the form
            tmrClose.Start();
        }

        /// <summary>
        /// Close timer
        /// </summary>
        private void tmrClose_Tick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
