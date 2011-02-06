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
using System.Drawing;
using System.Drawing.Imaging;

namespace GMare.Graphics
{
    [Serializable]
    public class PixelMap
    {
        #region Fields

        private Color _colorKey = Color.FromArgb(0, 0, 0, 0);  // Color key used, if any.
        private bool _useKey = false;                          // Whether the image uses a color key.
        private int[,] _pixels = null;                         // Raw pixel data.
        private int _width = 0;                                // Width of the image.
        private int _height = 0;                               // Height of the image.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the image's transparent color.
        /// </summary>
        public Color ColorKey
        {
            get { return _colorKey; }
            set { _colorKey = value; }
        }

        /// <summary>
        /// Gets or sets a pixel within the pixel array.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return _pixels[x, y]; }
            set { _pixels[x, y] = value; }
        }

        /// <summary>
        /// Gets the entire array of pixel data.
        /// </summary>
        public int[,] Pixels
        {
            get { return _pixels; }
        }

        /// <summary>
        /// Width of the pixel map in pixels.
        /// </summary>
        public int Width
        {
            get { return _width; }
        }

        /// <summary>
        /// Height of the pixel map in pixels.
        /// </summary>
        public int Height
        {
            get { return _height; }
        }

        /// <summary>
        /// Gets or sets whether the color key is used for this image.
        /// </summary>
        public bool UseKey
        {
            get { return _useKey; }
            set { _useKey = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new empty pixel map.
        /// </summary>
        /// <param name="width">Width of the pixel map.</param>
        /// <param name="height">Height of the pixel map.</param>
        /// <param name="color">Base color of the pixel map.</param>
        public PixelMap(int width, int height, Color color)
        {
            _pixels = new int[width, height];
            _width = width;
            _height = height;

            // Fill pixels with color.
            Fill(color);
        }

        /// <summary>
        /// Constructs a new pixel map from a bitmap.
        /// </summary>
        /// <param name="image">Bitmap to create pixel map from.</param>
        public PixelMap(Bitmap image)
        {
            _pixels = GetPixels(image, new Rectangle(0, 0, image.Width, image.Height));
            _width = image.Width;
            _height = image.Height;
        }

        /// <summary>
        /// Constructs a new pixel map from pixel data.
        /// </summary>
        /// <param name="pixels">raw pixel data to use.</param>
        public PixelMap(int[,] pixels)
        {
            _width = pixels.GetLength(0);
            _height = pixels.GetLength(1);
            _pixels = pixels;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a shallow copy of the pixel map.
        /// </summary>
        /// <returns>A shallow copy of the pixel map.</returns>
        public PixelMap Clone()
        {
            // Clone pixel map.
            PixelMap map = new PixelMap((int[,])_pixels.Clone());
            map.ColorKey = _colorKey;
            map.UseKey = _useKey;

            // Return shallow copy.
            return map;
        }

        /// <summary>
        ///	Fills the pixel array with a specific ARGB color.
        /// </summary>
        /// <param name="color">Color to fill pixels with.</param>
        public void Fill(Color color)
        {
            // Set pixels to desired color.
            for (int x = 0; x < _width; x++)
                for (int y = 0; y < _height; y++)
                    _pixels[x, y] = color.ToArgb();
        }

        /// <summary>
        /// Pastes a pixel map at the desired position.
        /// </summary>
        /// <param name="pixelMap">The pixel map to paste.</param>
        /// <param name="x">The horizontal coordinate to start pasting.</param>
        /// <param name="y">The vertical coordinate to start pasting.</param>
        public void Paste(PixelMap pixelMap, int originX, int originY)
        {
            // Iterate through the pixels horizontally.
            for (int x = 0; x < pixelMap.Width; x++)
            {
                // Iterate through the pixels vertically.
                for (int y = 0; y < pixelMap.Height; y++)
                {
                    // Calculate index.
                    int posX = originX + x;
                    int posY = originY + y;

                    // Set pixel if within bounds.
                    if (posX >= 0 && posY >= 0 && posX < _width && posY < _height)
                        _pixels[posX, posY] = pixelMap.Pixels[x, y];
                }
            }
        }

        /// <summary>
        /// Gets the raw pixel data from a bitmap. Converts to internal standard 32bppPArgb.
        /// </summary>
        /// <param name="image">Bitmap to get raw pixel data from.</param>
        /// <param name="rect">Region to get pixels from.</param>
        /// <returns>32bit pixels data, in a 2d array.</returns>
        public static int[,] GetPixels(Bitmap image, Rectangle rect)
        {
            // Pallet data.
            Color[] pallet = null;

            // The pixel bits.
            int bits = 4;

            // Check pixel format.
            switch (image.PixelFormat)
            {
                case PixelFormat.Format24bppRgb: bits = 3; break;
                case PixelFormat.Format32bppArgb: bits = 4; break;
                case PixelFormat.Format32bppPArgb: bits = 4; break;
                case PixelFormat.Format8bppIndexed: bits = 1; pallet = image.Palette.Entries; break;
                default: throw new Exception("The image's pixel format is not supported.");
            }

            // Create a new array of pixels.
            int[,] pixels = new int[rect.Width, rect.Height];

            // Lock the bitmap for writing.
            BitmapData data = image.LockBits(rect, ImageLockMode.ReadOnly, image.PixelFormat);

            // Begin image read.
            unsafe
            {
                // Get stride offset.
                int offset = data.Stride - data.Width * bits;

                // Get pointer to pixel data.
                byte* imgPtr = (byte*)(void*)(data.Scan0);

                // Iterate through vertical pixels.
                for (int y = 0; y < data.Height; ++y)
                {
                    // Iterate through horizontal pixels.
                    for (int x = 0; x < data.Width; ++x)
                    {
                        byte[] pixel = new byte[4];

                        if (bits == 3) // 24bit, get rgb data, alpha is defaulted to 255.
                        {
                            pixel[0] = 255;
                            pixel[1] = imgPtr[0];
                            pixel[2] = imgPtr[1];
                            pixel[3] = imgPtr[2];
                        }
                        else if (bits == 4) // 32bit, get argb data.
                        {
                            pixel[0] = imgPtr[3];
                            pixel[1] = imgPtr[0];
                            pixel[2] = imgPtr[1];
                            pixel[3] = imgPtr[2];
                        }
                        else if (bits == 1)  // 8bit, indexed colors.
                        {
                            int index = imgPtr[0];
                            Color color = pallet[index];

                            pixel[0] = 255;
                            pixel[1] = color.B;
                            pixel[2] = color.G;
                            pixel[3] = color.R;
                        }

                        // Set bitmap pixel.
                        pixels[x, y] = BitConverter.ToInt32(pixel, 0);

                        // Increment the image pointer.
                        imgPtr += bits;
                    }

                    // Offset image pointer.
                    imgPtr += offset;
                }
            }

            // Unlock the bitmap.
            image.UnlockBits(data);

            // Return the read pixels.
            return pixels;
        }

        /// <summary>
        /// Converts pixel data to a bitmap. Only supports internal standard 32bppPArgb.
        /// </summary>
        /// <returns>A GDI+ bitmap.</returns>
        public static Bitmap PixelDataToBitmap(int[,] pixels)
        {
            // Create new GDI+ bitmap with no alpha values. 
            Bitmap image = new Bitmap(pixels.GetLength(0), pixels.GetLength(1), PixelFormat.Format32bppPArgb );

            // Lock the bitmap for writing.
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            // Begin image write.
            unsafe
            {
                // Get stride offset.
                int offset = data.Stride - data.Width * 4;

                // Get pointer to pixel data.
                byte* imgPtr = (byte*)(void*)(data.Scan0);

                // Iterate through vertical pixels.
                for (int y = 0; y < data.Height; ++y)
                {
                    // Iterate through horizontal pixels.
                    for (int x = 0; x < data.Width; ++x)
                    {
                        byte[] pixel = BitConverter.GetBytes(pixels[x, y]);

                        // Set bitmap pixel.
                        imgPtr[3] = pixel[0];
                        imgPtr[0] = pixel[1];
                        imgPtr[1] = pixel[2];
                        imgPtr[2] = pixel[3];

                        // Increment the image pointer.
                        imgPtr += 4;
                    }

                    // Offset image pointer.
                    imgPtr += offset;
                }
            }

            // Unlock the bitmap.
            image.UnlockBits(data);

            // Return the GDI+ version of the image resource.
            return image;
        }

        /// <summary>
        /// Convert's this pixel map into a bitmap with the color key.
        /// </summary>
        /// <returns></returns>
        public Bitmap ToBitmap()
        {
            // Get a bitmap from pixel data.
            Bitmap image = PixelDataToBitmap(_pixels);

            // If the color key is not empty, use the color key.
            if (_useKey == true)
                image.MakeTransparent(_colorKey);

            // Return the converted pixel data.
            return image;
        }

        /// <summary>
        /// Checks if two pixel maps are the same.
        /// </summary>
        /// <param name="map1">The first pixel map to check.</param>
        /// <param name="map2">The second pixel map to check.</param>
        /// <returns>If the two pixel maps are the same.</returns>
        public static bool Same(PixelMap map1, PixelMap map2)
        {
            // If the pixel map sizes are different, then these pixel maps are not the same.
            if (map1.Width != map2.Width || map1.Height != map2.Height)
                return false;

            // Check all the pixels for a mismatch.
            for (int y = 0; y < map1.Pixels.GetLength(1); y++)
                for (int x = 0; x < map1.Pixels.GetLength(0); x++)
                    if (map1.Pixels[x, y] != map2.Pixels[x, y])
                        return false;

            // The pixel maps are the same.
            return true;
        }

        /// <summary>
        /// Changes a bitmap's brightness.
        /// </summary>
        /// <param name="image">The bitmap to change the brightness on.</param>
        /// <param name="amount">The desired brightness.</param>
        /// <returns>A bitmap with new brightness values.</returns>
        public static Bitmap BitmapBrightness(Bitmap image, float amount)
        {
            // Create a new bitmap to draw on.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bm);

            // Brightness changing color matrix.
            ColorMatrix cm = new ColorMatrix(new float[][] {
                new float[]{ 1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 0.0f, 0.0f, 1.0f, 0.0f},
                new float[]{ amount, amount, amount, 0.0f, 1.0f} });

            // Create new image attributes.
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            // Draw the original image with new image attributes.
            gfx.DrawImage(image, new Rectangle(0, 0, bm.Width, bm.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

            // Dispose.
            gfx.Dispose();
            ia.Dispose();

            return bm;
        }

        /// <summary>
        /// Changes a bitmap's transparency.
        /// </summary>
        /// <param name="image">The bitmap to change the transparency on.</param>
        /// <param name="amount">The desired transparency.</param>
        /// <returns>A bitmap with new transparency values.</returns>
        public static Bitmap BitmapTransparency(Bitmap image, float amount)
        {
            // Create a new bitmap to draw on.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bm);

            // Alpha changing color matrix.
            ColorMatrix cm = new ColorMatrix(new float[][] {
                new float[]{ 1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                new float[]{ 0.0f, 0.0f, 0.0f, amount, 0.0f},
                new float[]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f} });

            // Create new image attributes.
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            // Draw the original image with new image attributes.
            gfx.DrawImage(image, new Rectangle(0, 0, bm.Width, bm.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

            // Dispose.
            gfx.Dispose();
            ia.Dispose();

            // Return changed bitmap.
            return bm;
        }

        /// <summary>
        /// Converts pixel data to a compatible OpenGL texture data.
        /// </summary>
        /// <returns>Texture data.</returns>
        public byte[] ToOpenGLTexture()
        {
            // Flip the data so its in the correct format that opengl wants.
            int i = 0;
            byte[] data = new byte[(_pixels.GetLength(0) * _pixels.GetLength(1)) * 4];

            // Iterate through horizontal pixels.
            for (int y = 0; y < _pixels.GetLength(1); y++)
            {
                // Iterate through vertical pixels.
                for (int x = 0; x < _pixels.GetLength(0); x++)
                {
                    // Set pixel data.
                    data[i] = (byte)((_pixels[x, y] >> 24) & 0xFF);
                    data[i + 1] = (byte)((_pixels[x, y] >> 16) & 0xFF);
                    data[i + 2] = (byte)((_pixels[x, y] >> 8) & 0xFF);
                    data[i + 3] = (byte)(_pixels[x, y] & 0xFF);

                    // Increment pixel index.
                    i += 4;
                }
            }

            // Return texture data.
            return data;
        }

        #endregion
    }
}