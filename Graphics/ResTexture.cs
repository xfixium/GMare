#region MIT

// 
// GMare.
// Copyright (C) 2011 Michael Mercado
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GMare.Graphics
{
    /// <summary>
    /// A texture resource class.
    /// </summary>
    public class ResTexture : IDisposable
    {
        #region Fields

        private int[,] _pixels = null; // Pixel data.
        private uint _textureId = 0;   // OpenGL texture id.
        private int _textureSize = 0;  // The size of the texture in powers of 2.
        private int _width = 0;        // Original image width.
        private int _height = 0;       // Original image height.

        #endregion

        #region Properties

        /// <summary>
        /// The OpenGL texture id of this texture.
        /// </summary>
        public uint TextureId
        {
            get { return _textureId; }
        }

        /// <summary>
        /// The size of the texture within OpenGL. (Powers of 2)
        /// </summary>
        public int TextureSize
        {
            get { return _textureSize; }
        }

        /// <summary>
        /// The width of the original image this texture derives from in pixels.
        /// </summary>
        public int Width
        {
            get { return _width; }
        }

        /// <summary>
        /// The height of the original image this texture derives from in pixels.
        /// </summary>
        public int Height
        {
            get { return _height; }
        }

        /// <summary>
        /// The size of the original image this texture derives from in pixels.
        /// </summary>
        public Size Size
        {
            get { return new Size(_width, _height); }
        }

        /// <summary>
        /// Gets the pixel data.
        /// </summary>
        public int[,] Pixels
        {
            get { return _pixels; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new texture resource.
        /// </summary>
        /// <param name="image">The pixel map to use for the texture.</param>
        public ResTexture(Bitmap image)
        {
            PixelMap map = new PixelMap(image);
            _pixels = (int[,])map.Pixels.Clone();

            SetTexture(map);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the texture id.
        /// </summary>
        /// <param name="pixelMap">Pixel map to use as a texture.</param>
        private unsafe void SetTexture(PixelMap pixelMap)
        {
            // Original size.
            _width = pixelMap.Width;
            _height = pixelMap.Height;

            // Get a power of 2.
            if (_width > _height)
                _textureSize = MathMethods.Pow(_width, 2);
            else
                _textureSize = MathMethods.Pow(_height, 2);

            // Copy the pixel map and resize it.
            PixelMap copy = new PixelMap(_textureSize, _textureSize, Color.Black);
            copy.Paste(pixelMap, 0, 0);

            byte[] data = copy.ToOpenGLTexture();

            // Get texture pointer.
            fixed (uint* id = &_textureId) { OpenGL.glGenTextures(1, id); }

            // If a valid texture was created.
            if (_textureId != 0)
            {
                // Bind the new opengl texture.
                OpenGL.glBindTexture(GLTexture.Texture2D, _textureId);

                // Allocate some native memory to store data in.
                IntPtr textureData = Marshal.AllocHGlobal(data.Length);
                Marshal.Copy(data, 0, textureData, data.Length);

                // Set filters.
                OpenGL.glTexParameteri(GLTexture.Texture2D, GLTexParamPName.TextureMinFilter, GLTextureFilter.Nearest);
                OpenGL.glTexParameteri(GLTexture.Texture2D, GLTexParamPName.TextureMagFilter, GLTextureFilter.Nearest);

                
                // Place data into video memory.
                OpenGL.glTexImage2D(GLTexture.Texture2D, 0, GLInternalFormat.RGBA8, _textureSize, _textureSize, 0, GLPixelFormat.RGBA, GLDataType.UnsignedByte, textureData);

                // Deallocate native memory.
                Marshal.FreeHGlobal(textureData);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            // Create a texture array.
            uint[] texture = new uint[1];
            texture[0] = _textureId;

            // Delete texture.
            OpenGL.glDeleteTextures(1, texture);
        }

        #endregion
    }
}
