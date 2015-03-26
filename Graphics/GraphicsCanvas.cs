/* 
 * File: GraphicsCanvas.cs
 *
 * This source and general concepts mostly copied from:
 *
 * Copyright (c) Timothy Leonard,  Binary Phoenix. All rights reserved.
 * 
 */

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GMare.Graphics
{
    /// <summary>
    /// An OpenGL rendering control
    /// </summary>
    public class GraphicsCanvas
    {
        #region Fields

        private readonly Control _control = null;               // Windows control
        private IntPtr _deviceContext = IntPtr.Zero;            // Device context
        private IntPtr _renderingContext = IntPtr.Zero;         // Rendering context
        private IntPtr _currentRenderingContext = IntPtr.Zero;  // Current rendering context
        private bool _refresh = true;                           // If the control needs to invalidate the first time

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new canvas
        /// </summary>
        /// <param name="control">Control to render to</param>
        public GraphicsCanvas(System.Windows.Forms.Control control)
        {
            // Set control canvas
            _control = control;

            // Setup windows components and show it
            _control.Disposed += new EventHandler(Disposed);

            // Set OpenGL
            OpenGL.glShadeModel(GLShadeModel.Flat);
            OpenGL.glHint(GLHint.PerspectiveCorrection, GLQuality.Fastest);
            OpenGL.glCullFace(GLPolygonFaces.Back);
            OpenGL.glDisable(GLOption.Lighting);
            OpenGL.glDisable(GLOption.DepthTest);
            OpenGL.glDisable(GLOption.Dither);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Setup OpenGL
        /// </summary>
        public void SetOpenGL()
        {
            // Default to alpha blending
            OpenGL.glEnable(GLOption.Blend);
            OpenGL.glEnable(GLOption.AlphaTest);
            OpenGL.glAlphaFunc(GLAlphaFunc.Greater, 0f);
            OpenGL.glBlendFunc(GLBlendSrc.SrcAlpha, GLBlendDest.OneMinusSrcAlpha);

            // If there is no rendering context or device context
            if (_deviceContext == IntPtr.Zero || _renderingContext == IntPtr.Zero)
            {
                // Make current
                OpenGL.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);

                // Create a buffer descriptor
                OpenGL.PIXELFORMATDESCRIPTOR pfd = new OpenGL.PIXELFORMATDESCRIPTOR();
                pfd.nSize = (short)Marshal.SizeOf(pfd);
                pfd.nVersion = 1;
                pfd.dwFlags = OpenGL.PFD_DRAW_TO_WINDOW | OpenGL.PFD_SUPPORT_OPENGL | OpenGL.PFD_DOUBLEBUFFER;
                pfd.iPixelType = OpenGL.PFD_TYPE_RGBA;
                pfd.cColorBits = 32;
                pfd.cRedBits = 0;
                pfd.cRedShift = 0;
                pfd.cGreenBits = 0;
                pfd.cGreenShift = 0;
                pfd.cBlueBits = 0;
                pfd.cBlueShift = 0;
                pfd.cAlphaBits = 0;
                pfd.cAlphaShift = 0;
                pfd.cAccumBits = 0;
                pfd.cAccumRedBits = 0;
                pfd.cAccumGreenBits = 0;
                pfd.cAccumBlueBits = 0;
                pfd.cAccumAlphaBits = 0;
                pfd.cDepthBits = 0;
                pfd.cStencilBits = 0;
                pfd.cAuxBuffers = 0;
                pfd.iLayerType = OpenGL.PFD_MAIN_PLANE;
                pfd.bReserved = 0;
                pfd.dwLayerMask = 0;
                pfd.dwVisibleMask = 0;
                pfd.dwDamageMask = 0;

                // Grab the device context
                _deviceContext = OpenGL.GetDC(_control.Handle);

                if (_deviceContext == IntPtr.Zero)
                    throw new Exception("An error occured while attempting to allocate device context for OpenGL canvas.");

                // Choose our pixel format
                int pixelFormat = OpenGL.ChoosePixelFormat(_deviceContext, ref pfd);

                if (pixelFormat == 0)
                    throw new Exception("An error occured while attempting to choose pixel format for OpenGL canvas.");

                // Set our pixel format
                if (OpenGL.SetPixelFormat(_deviceContext, pixelFormat, ref pfd) == 0)
                    throw new Exception("An error occured while attempting to set pixel format for OpenGL canvas.");

                // Grab our rendering context
                _renderingContext = OpenGL.wglCreateContext(_deviceContext);

                if (_renderingContext == IntPtr.Zero)
                    throw new Exception("An error occured while attempting to allocate rendering context for OpenGL canvas (win32 error code: " + OpenGL.glGetError().ToString() + ", " + Marshal.GetLastWin32Error().ToString() + ").");
            }

            // If the current context is not the rendering context.
            if (_currentRenderingContext != _renderingContext)
            {
                if (OpenGL.wglMakeCurrent(_deviceContext, _renderingContext) == 0)
                    throw new Exception("An error occured while attempting to set current OpenGL canvas (" + Marshal.GetLastWin32Error() + ").");

                // Make this context our current one.
                _currentRenderingContext = _renderingContext;
            }
        }

        /// <summary>
        /// Begins rendering the scene to this canvas
        /// </summary>
        public void BeginScene()
        {
            // Set up OpenGL
            SetOpenGL();

            // Set view
            OpenGL.glMatrixMode(GLMatrixMode.Projection);
            OpenGL.glLoadIdentity();
            OpenGL.glOrtho(0, _control.ClientSize.Width, _control.ClientSize.Height, 0, -1.0f, 0.0f);
            OpenGL.glMatrixMode(GLMatrixMode.ModelView);
            OpenGL.glLoadIdentity();
            OpenGL.glTranslated(0.375, 0.375, 0);
            OpenGL.glScalef(GraphicsManager.ScreenScale, GraphicsManager.ScreenScale, 0);
            OpenGL.glViewport(0, 0, _control.ClientSize.Width, _control.ClientSize.Height);
            OpenGL.glLineWidth(GraphicsManager.ScreenScale);
        }

        /// <summary>
        /// Presents the screen to the front buffer
        /// </summary>
        public void EndScene()
        {
            // If the device context and rendering context pointers exist
            if (_deviceContext != IntPtr.Zero && _renderingContext != IntPtr.Zero)
            {
                // Flip to screen
                OpenGL.wglSwapBuffers(_deviceContext);

                // Avoids crashes on super fast rendering
                OpenGL.glFlush();

                // If the control needs a push to invalidate
                if (_refresh)
                {
                    _refresh = false;
                    _control.Invalidate();
                }
            }
        }

        /// <summary>
        ///	Called when the user disposes this control
        /// </summary>
        void Disposed(object sender, EventArgs e)
        {
            // Call the graphics manager's dispose
            GraphicsManager.Dispose();

            if (_deviceContext != IntPtr.Zero && _renderingContext != IntPtr.Zero)
            {
                // Delete the rendering context
                OpenGL.wglDeleteContext(_renderingContext);

                // Release the device context
                OpenGL.ReleaseDC(_control.Handle, _deviceContext);

                _renderingContext = IntPtr.Zero;
                _deviceContext = IntPtr.Zero;
            }
        }

        #endregion
    }
}