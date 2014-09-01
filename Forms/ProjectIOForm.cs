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
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;
using GameMaker.Project;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// A dialog that reads and writes Game Maker and GMare projects, shows the progression
    /// </summary>
    public partial class ProjectIOForm : Form
    {
        #region Fields

        private GMProject _gmProject = null;     // The read in Game Maker project
        private GMareRoom _gmareProject = null;  // The read in GMare room
        private string _path = "";               // Path to the project file
        private bool _gameMaker = false;         // If loading a game maker project

        #endregion

        #region Properties

        /// <summary>
        /// Gets the read in Game Maker project
        /// </summary>
        public GMProject GMProject
        {
            get { return _gmProject; }
        }

        /// <summary>
        /// Gets the read in Game Maker project
        /// </summary>
        public GMareRoom GMareProject
        {
            get { return _gmareProject; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new project IO form
        /// </summary>
        /// <param name="path">Path to the Game Maker project file</param>
        /// <param name="gameMaker">If loading a Game Maker project, else a GMare project</param>
        public ProjectIOForm(string path, bool gameMaker)
        {
            InitializeComponent();

            // Set text
            this.Text = gameMaker ? "Project Read" : "Loading...";
            _gameMaker = gameMaker;

            // Read project
            if (gameMaker)
                bgwGMProjectReader.RunWorkerAsync(path);
            else
                _path = path;
        }

        /// <summary>
        /// Constructs a new project form for writing
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="path">The path to write to</param>
        public ProjectIOForm(GMProject project, string path)
        {
            // Set text
            this.Text = "Project Write";

            // Set project to write
            _gmProject = project;

            // Write project
            bgwGMProjectReader.RunWorkerAsync(path);
        }

        /// <summary>
        /// Constructs a new project form for writing
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="path">The path to write to</param>
        public ProjectIOForm(GMareRoom project, string path)
        {
            // Set text
            this.Text = "Saving...";

            // Set project to write
            _gmareProject = project;

            // Write project
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On load
        /// </summary>
        protected override void OnCreateControl()
        {
            // Call base load
            base.OnCreateControl();

            // If game maker loading, return
            if (_gameMaker)
                return;

            // Read the room in
            var reader = new ReadProgressStream(new FileStream(_path, FileMode.Open));
            _gmareProject = ContainerStream.Deserialize<GMareRoom>(reader, reader_ProgressChanged);

            // Close the form
            tmrClose.Interval = 500;
            tmrClose.Start();
        }

        #endregion

        #region Events

        /// <summary>
        /// GMare reader progress changed event
        /// </summary>
        private void reader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Set progress bar progress amount
            lblStatus.Text = "Reading GMare project";

            // Hackish value jumping
            barProgress.Value = e.ProgressPercentage;
            barProgress.Value = e.ProgressPercentage - 1;
            barProgress.Value = e.ProgressPercentage;

            Invalidate();
        }

        /// <summary>
        /// Project reader do work
        /// </summary>
        private void bgwGMProjectReader_DoWork(object sender, DoWorkEventArgs e)
        {
            // Create new Game Maker project, hook progress changed event, start reading project
            _gmProject = new GMProject();
            _gmProject.OnProgressChanged += new GMProject.ProgressChangedHandler(bgwGMProjectReader_ReaderProgressChanged);
            _gmProject.ReadProject(e.Argument.ToString());
        }

        /// <summary>
        /// Project reader progress changed
        /// </summary>
        private void bgwGMProjectReader_ReaderProgressChanged(string message, int position)
        {
            // Report progress 
            bgwGMProjectReader.ReportProgress(position, message);
        }

        /// <summary>
        /// Project reader progress changed
        /// </summary>
        private void bgwGMProjectReader_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

    #region ContainerStream

    /// <summary>
    /// 
    /// </summary>
    public abstract class ContainerStream : Stream
    {
        private Stream _stream;

        public override long Length
        {
            get { return _stream.Length; }
        }

        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }

        protected Stream ContainedStream
        {
            get { return _stream; }
        }

        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }

        protected ContainerStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            _stream = stream;
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public static T Deserialize<T>(Stream stream, ProgressChangedEventHandler callback)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (ReadProgressStream cs = new ReadProgressStream(stream))
            {
                cs.ProgressChanged += callback;
                const int defaultBufferSize = 4096;
                int onePercentSize = (int)Math.Ceiling(stream.Length / 100.0);

                using (BufferedStream bs = new BufferedStream(cs, onePercentSize > defaultBufferSize ? defaultBufferSize : onePercentSize))
                {
                    XmlSerializer reader = new XmlSerializer(typeof(T));
                    return (T)reader.Deserialize(bs);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReadProgressStream : ContainerStream
    {
        private int _lastProgress = 0;

        public ReadProgressStream(Stream stream)
            : base(stream)
        {
            if (!stream.CanRead || !stream.CanSeek || stream.Length <= 0)
                throw new ArgumentException("stream");
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int amountRead = base.Read(buffer, offset, count);

            if (ProgressChanged != null)
            {
                int newProgress = (int)(Position * 100.0 / Length);

                if (newProgress > _lastProgress)
                {
                    _lastProgress = newProgress;
                    ProgressChanged(this, new ProgressChangedEventArgs(_lastProgress, null));
                }
            }

            return amountRead;
        }

        public event ProgressChangedEventHandler ProgressChanged;

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
