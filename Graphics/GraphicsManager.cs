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
using System.Collections.Generic;

namespace GMare.Graphics
{
    public static class GraphicsManager
    {
        #region Fields

        /// <summary>
        /// This enumeration stores identifiers for the different types of blend modes.
        /// </summary>
        public enum BlendType
        {
            Solid,
            Mask,
            Alpha,
            Lighten,
            Darken,
            Invert
        };
        private static readonly Stack<Line> _lines = new Stack<Line>();                           // A list of drawing lines.
        private static List<Quad> _quads = new List<Quad>();                                      // A list of drawing quads.
        private static List<ResTexture[,]> _tileMaps = new List<ResTexture[,]>();                 // Room's tiles.
        private static GraphicsCanvas _canvas = null;                                             // Rendering canvas.
        private static Dictionary<int, ResTexture> _sprites = new Dictionary<int, ResTexture>();  // A dictionary of sprites.
        private static BlendType _blendMode = BlendType.Alpha;                                    // Renderer's blend mode.
        private static Color _blendColor = Color.White;                                           // Renderer's blend color.
        private static Rectangle _viewport = Rectangle.Empty;                                     // Canvas viewport.
        private static Rectangle _scissor = Rectangle.Empty;                                      // Canvas scissor.
        private static float _screenScale = 1.0f;                                                 // Canvas scale.
        private static int _offsetX = 0;                                                          // Canvas horizontal drawing offset.
        private static int _offsetY = 0;                                                          // Canvas vertical drawing offset.
        private static bool _initialized = false;                                                 // Whether the renderer has been initialized. 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the dictionary of sprite textures.
        /// </summary>
        public static Dictionary<int, ResTexture> Sprites
        {
            get { return _sprites; }
        }

        /// <summary>
        /// Gets or sets the blend mode.
        /// </summary>
        public static BlendType BlendMode
        {
            get { return _blendMode; }
            set
            {
                _blendMode = value;
                OpenGL.glDisable(GLOption.ColorLogicOp);

                switch (value)
                {
                    case BlendType.Solid:
                        OpenGL.glDisable(GLOption.Blend);
                        OpenGL.glDisable(GLOption.AlphaTest);
                        break;

                    case BlendType.Mask:
                        OpenGL.glDisable(GLOption.Blend);
                        OpenGL.glEnable(GLOption.AlphaTest);
                        OpenGL.glAlphaFunc(GLAlphaFunc.Greater, 0f);
                        break;

                    case BlendType.Alpha:
                        OpenGL.glEnable(GLOption.Blend);
                        OpenGL.glEnable(GLOption.AlphaTest);
                        OpenGL.glAlphaFunc(GLAlphaFunc.Greater, 0f);
                        OpenGL.glBlendFunc(GLBlendSrc.SrcAlpha, GLBlendDest.OneMinusSrcAlpha);
                        break;

                    case BlendType.Lighten:
                        OpenGL.glEnable(GLOption.Blend);
                        OpenGL.glBlendFunc(GLBlendSrc.SrcAlpha, GLBlendDest.One);
                        OpenGL.glDisable(GLOption.AlphaTest);
                        break;

                    case BlendType.Darken:
                        OpenGL.glEnable(GLOption.Blend);
                        OpenGL.glBlendFunc(GLBlendSrc.DestColor, GLBlendDest.Zero);
                        OpenGL.glDisable(GLOption.AlphaTest);
                        break;

                    case BlendType.Invert:
                        OpenGL.glEnable(GLOption.AlphaTest);
                        OpenGL.glEnable(GLOption.ColorLogicOp);
                        OpenGL.glLogicOp(5388);
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the rendering tile maps.
        /// </summary>
        public static List<ResTexture[,]> TileMaps
        {
            get { return _tileMaps; }
        }

        /// <summary>
        /// Gets or sets the graphics blend color.
        /// </summary>
        public static Color BlendColor
        {
            get { return _blendColor; }
            set { _blendColor = value; }
        }

        /// <summary>
        /// Gets or sets the viewport.
        /// </summary>
        public static Rectangle Viewport
        {
            get { return _viewport; }
            set { _viewport = value; }
        }

        /// <summary>
        /// Gets or sets the scissor rectangle.
        /// </summary>
        public static Rectangle Scissor
        {
            get { return _scissor; }
            set
            {
                // Set the scissor.
                _scissor = value;

                // Set scissor rectangle.
                OpenGL.glEnable(GLOption.ScissorTest);
                OpenGL.glScissor(_scissor.X, _scissor.Y, _scissor.Width, _scissor.Height);
            }
        }

        /// <summary>
        /// Gets or sets the canvas scaling.
        /// </summary>
        public static float ScreenScale
        {
            get { return _screenScale; }
            set { _screenScale = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal offset.
        /// </summary>
        public static int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        /// <summary>
        /// Gets or sets the vertical offset.
        /// </summary>
        public static int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        /// <summary>
        /// Gets whether the OpenGL graphics were intialized.
        /// </summary>
        public static bool Initialized
        {
            get { return _initialized; }
        }

        #endregion

        #region Methods

        #region Graphics

        /// <summary>
        /// Initializes graphics to a desired control.
        /// </summary>
        /// <param name="control">The control to render to.</param>
        public static void Initialize(System.Windows.Forms.Control control)
        {
            // If the graphics system has been already initialized, return.
            if (_initialized)
                return;

            // Create a new drawing canvas.
            _canvas = new GraphicsCanvas(control);

            // Everything is ok.
            _initialized = true;
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public static void Dispose()
        {
            // Delete tilemaps.
            DeleteTilemaps();

            // Deletes all normal textures.
            DeleteTextures();
        }

        #endregion

        #region Drawing

        #region Draw

        /// <summary>
        /// Begins rendering to the current graphics canvas.
        /// </summary>
        public static void BeginScene()
        {
            // Call the canvas's begin scene.
            _canvas.BeginScene();
        }

        /// <summary>
        /// Finishes rendering to the current graphics canvas.
        /// </summary>
        public static void EndScene()
        {
            // Call the canvas's end scene.
            _canvas.EndScene();
        }

        /// <summary>
        /// Clears the canvas in the desired color.
        /// </summary>
        /// <param name="color">Color to clear the screen with.</param>
        public static void DrawClear(Color color)
        {
            OpenGL.glClearColor(color);
            OpenGL.glClear(GLBuffers.Color);
        }

        #endregion

        #region DrawLine

        /// <summary>
        /// Draws a line, in the desired color.
        /// </summary>
        /// <param name="x">The starting x coordinate.</param>
        /// <param name="y">The starting y coordinate.</param>
        /// <param name="x2">The ending x coordinate.</param>
        /// <param name="y2">The ending y coordinate.</param>
        /// <param name="color2">The line color.</param>
        public static void DrawLineCache(int x1, int y1, int x2, int y2, Color color)
        {
            // Set offsets.
            x1 -= _offsetX;
            y1 -= _offsetY;
            x2 -= _offsetX;
            y2 -= _offsetY;

            // Create a new vector array.
            Line line = new Line(new Point(x1, y1), new Point(x2, y2), color);

            // Add a new line.
            _lines.Push(line);
        }

        /// <summary>
        /// Draws all cached lines at once with defined stipple pattern
        /// </summary>
        /// <param name="offset">Stipple pattern offset</param>
        public static void DrawStippledLineBatch(int offset, int factor)
        {
            // 4 dashed bit pattern that supports bit wrapping on offset
            ushort pattern = (ushort)(0xAAAA << offset | 0xAAAA >> (8 - offset));

            // Enable line stipple
            OpenGL.glEnable(GLOption.LineStipple);

            // Set stipple pattern
            OpenGL.glLineStipple(factor * (int)_screenScale, pattern);

            // Draw lines
            DrawLineBatch();

            // Disable line stipple.
            OpenGL.glDisable(GLOption.LineStipple);
        }

        /// <summary>
        /// Draws all cached lines at once.
        /// </summary>
        public static void DrawLineBatch()
        {
            // Render.
            OpenGL.glBindTexture(GLTexture.Texture2D, 0);
            OpenGL.glDisable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.Back, GLPolygonMode.Line);
            OpenGL.glBegin(GLPrimative.Lines);

            // Iterate through colored lines.
            while (_lines.Count > 0)
            {
                // Pop off a line object.
                Line line = _lines.Pop();

                // Draw line.
                OpenGL.glColor4(line.Color);
                OpenGL.glVertex2i(line.Start.X, line.Start.Y);
                OpenGL.glVertex2i(line.End.X, line.End.Y);
            }
            
            OpenGL.glEnd();
        }

        #endregion

        #region DrawRectangle

        /// <summary>
        /// Draws a standard stippled rectangle. (Not very flexible at this point)
        /// </summary>
        public static void DrawStippledRectangle(Rectangle rectangle, Color color, int offset, int factor)
        {
            // 4 dashed bit pattern that supports bit wrapping on offset.
            ushort pattern = (ushort)(0xF0F << offset | 0xF0F >> (8 - offset));

            // Enable line stipple.
            OpenGL.glEnable(GLOption.LineStipple);

            // Set stipple pattern.
            OpenGL.glLineStipple(factor * (int)_screenScale, pattern);

            // Draw the rectangle.
            DrawRectangle(rectangle, color, true);

            // Disable line stipple.
            OpenGL.glDisable(GLOption.LineStipple);
        }

        /// <summary>
        /// Draws a rectangle.
        /// </summary>
        public static void DrawRectangle(Rectangle rectangle, Color color, bool outline)
        {
            // Calculate positions.
            float x0 = rectangle.X - _offsetX;
            float y0 = rectangle.Y - _offsetY;
            float x1 = (rectangle.Width + x0) - 1;  // Inclusive offset.
            float y1 = (rectangle.Height + y0) - 1; // Inclusive offset.

            // Draw rectangle.
            OpenGL.glBindTexture(GLTexture.Texture2D, 0);
            OpenGL.glDisable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.FrontAndBack, outline == false ? GLPolygonMode.Fill : GLPolygonMode.Line);
            OpenGL.glColor4(color);

            OpenGL.glBegin(GLPrimative.Quads);

            OpenGL.glVertex2f(x0, y0);
            OpenGL.glVertex2f(x1, y0);
            OpenGL.glVertex2f(x1, y1);
            OpenGL.glVertex2f(x0, y1);
            
            OpenGL.glEnd();
        }

        /// <summary>
        /// Draws a rectangle.
        /// </summary>
        public static void DrawRectangle(Point[] points, Color color, bool outline)
        {
            // Draw rectangle.
            OpenGL.glBindTexture(GLTexture.Texture2D, 0);
            OpenGL.glDisable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.FrontAndBack, outline == false ? GLPolygonMode.Fill : GLPolygonMode.Line);
            OpenGL.glColor4(color);

            OpenGL.glBegin(GLPrimative.Quads);

            OpenGL.glVertex2f(points[0].X, points[0].Y);
            OpenGL.glVertex2f(points[1].X, points[1].Y);
            OpenGL.glVertex2f(points[2].X, points[2].Y);
            OpenGL.glVertex2f(points[3].X, points[3].Y);

            OpenGL.glEnd();
        }

        /// <summary>
        /// Draws an array of rectangles.
        /// </summary>
        public static void DrawRectangles(Rectangle[] rectangles, Color color, bool outline)
        {
            // Iterate through rectangles.
            foreach (Rectangle rect in rectangles)
            {
                // Draw rectangle.
                DrawRectangle(rect, color, outline);
            }
        }

        #endregion

        #region DrawTriangle

        /// <summary>
        /// Draws a triangle.
        /// </summary>
        public static void DrawTriangle(Point[] points, Color color, bool outline)
        {
            // Calculate positions.
            float x0 = points[0].X - _offsetX;
            float y0 = points[0].Y - _offsetY;
            float x1 = points[1].X - _offsetX;
            float y1 = points[1].Y - _offsetY;
            float x2 = points[2].X - _offsetX;
            float y2 = points[2].Y - _offsetY;

            OpenGL.glBindTexture(GLTexture.Texture2D, 0);
            OpenGL.glDisable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.FrontAndBack, outline == false ? GLPolygonMode.Fill : GLPolygonMode.Line);
            OpenGL.glBegin(GLPrimative.Triangles);
            OpenGL.glColor4(color);
            OpenGL.glVertex2f(x0, y0);
            OpenGL.glVertex2f(x1, y1);
            OpenGL.glVertex2f(x2, y2);
            OpenGL.glEnd();
        }

        #endregion

        #region DrawPolygon

        public static void DrawPolygon(Point[] points, Color color, bool outline)
        {
        }

        #endregion

        #region DrawSprite

        /// <summary>
        /// Draws a sprite.
        /// </summary>
        /// <param name="id">The texture resource id.</param>
        /// <param name="x">The horizontal coordinate.</param>
        /// <param name="y">The vertical coordinate.</param>
        /// <param name="color">The blend color.</param>
        public static void DrawSprite(int id, int x, int y, Color color)
        {
            // If the sprite does not exist, return.
            if (_sprites.ContainsKey(id) == false)
                return;

            // Get the resource.
            ResTexture texture = _sprites[id];

            // If the texture is empty return.
            if (texture == null)
                return;

            // Add a textured quad.
            Quad quad = new Quad(texture, new PointF(x, y), new PointF(1, 1), 0, color);

            OpenGL.glEnable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.Back, GLPolygonMode.Fill);
            OpenGL.glBindTexture(GLTexture.Texture2D, quad.TextureId);
            OpenGL.glBegin(GLPrimative.Quads);
            OpenGL.glColor4(quad.Color);

            OpenGL.glTexCoord2f(quad.TextureCoordinates[0].X, quad.TextureCoordinates[0].Y);
            OpenGL.glVertex2f(quad.Vertices[0].X - _offsetX, quad.Vertices[0].Y - _offsetY);
            OpenGL.glTexCoord2f(quad.TextureCoordinates[1].X, quad.TextureCoordinates[1].Y);
            OpenGL.glVertex2f(quad.Vertices[1].X - _offsetX, quad.Vertices[1].Y - _offsetY);
            OpenGL.glTexCoord2f(quad.TextureCoordinates[2].X, quad.TextureCoordinates[2].Y);
            OpenGL.glVertex2f(quad.Vertices[2].X - _offsetX, quad.Vertices[2].Y - _offsetY);
            OpenGL.glTexCoord2f(quad.TextureCoordinates[3].X, quad.TextureCoordinates[3].Y);
            OpenGL.glVertex2f(quad.Vertices[3].X - _offsetX, quad.Vertices[3].Y - _offsetY);

            OpenGL.glEnd();
        }

        /// <summary>
        /// Stores a sprite in a cached batch.
        /// </summary>
        /// <param name="id">The texture resource id.</param>
        /// <param name="x">The horizontal coordinate.</param>
        /// <param name="y">The vertical coordinate.</param>
        /// <param name="color">The blend color.</param>
        public static void DrawSpriteCached(int id, int x, int y, Color color)
        {
            // If the sprite does not exist, return.
            if (_sprites.ContainsKey(id) == false)
                return;

            // Get the resource.
            ResTexture texture = _sprites[id];

            // If the texture is empty return.
            if (texture == null)
                return;

            // Add a textured quad.
            _quads.Add(new Quad(texture, new PointF(x, y), new PointF(1, 1), 0, color));
        }

        /// <summary>
        /// Draws a part of an image resource with the desired, scale, rotation, and blend colors.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public static void DrawTile(ResTexture texture, int x, int y, float scaleX, float scaleY, float rotation, Color color)
        {
            // Add a textured quad.
            _quads.Add(new Quad(texture, new PointF(x, y), new PointF(scaleX, scaleY), rotation, color));
        }

        /// <summary>
        /// Draws a list of image parts in one pass.
        /// </summary>
        /// <param name="vertices">The vertices to draw.</param>
        public static void DrawSpriteBatch(bool optimize)
        {
            uint last = 0;
            OpenGL.glEnable(GLOption.Texture2D);
            OpenGL.glPolygonMode(GLPolygonFaces.Back, GLPolygonMode.Fill);

            // If the sprites should be batched by texture to minimize texture binding.
            if (optimize == true)
                _quads.Sort(delegate(Quad quad1, Quad quad2) { return quad2.TextureId.CompareTo(quad1.TextureId); });

            // Iterate through textured quads.
            foreach (Quad quad in _quads)
            {
                // If the quad has a different texture id, bind texture.
                if (last != quad.TextureId)
                {
                    OpenGL.glBindTexture(GLTexture.Texture2D, quad.TextureId);
                    last = quad.TextureId;
                }

                OpenGL.glBegin(GLPrimative.Quads);
                OpenGL.glColor4(quad.Color);

                OpenGL.glTexCoord2f(quad.TextureCoordinates[0].X, quad.TextureCoordinates[0].Y);
                OpenGL.glVertex2f(quad.Vertices[0].X - _offsetX, quad.Vertices[0].Y - _offsetY);
                OpenGL.glTexCoord2f(quad.TextureCoordinates[1].X, quad.TextureCoordinates[1].Y);
                OpenGL.glVertex2f(quad.Vertices[1].X - _offsetX, quad.Vertices[1].Y - _offsetY);
                OpenGL.glTexCoord2f(quad.TextureCoordinates[2].X, quad.TextureCoordinates[2].Y);
                OpenGL.glVertex2f(quad.Vertices[2].X - _offsetX, quad.Vertices[2].Y - _offsetY);
                OpenGL.glTexCoord2f(quad.TextureCoordinates[3].X, quad.TextureCoordinates[3].Y);
                OpenGL.glVertex2f(quad.Vertices[3].X - _offsetX, quad.Vertices[3].Y - _offsetY);

                OpenGL.glEnd();
            }

            _quads.Clear();
        }

        #endregion

        #endregion

        #region Textures

        /// <summary>
        /// Loads a texture to the texture list
        /// </summary>
        /// <param name="image">The bitmap image used as a texture</param>
        /// <param name="id">The id of the texture.</param>
        public static void LoadTexture(PixelMap image, int id)
        {
            // If the key already exists
            if (_sprites.ContainsKey(id))
            {
                // Dispose of old texture
                _sprites[id].Dispose();

                // Create a new texture
                _sprites[id] = new ResTexture(image);
            }
            else  // Add a texture to the list
                _sprites.Add(id, new ResTexture(image));
        }

        /// <summary>
        /// Deletes all textures from memory
        /// </summary>
        public static void DeleteTextures()
        {
            // Iterate through textures, and dispose of them
            foreach (ResTexture texture in _sprites.Values)
                texture.Dispose();

            // Clear all texture elements
            _sprites.Clear();
        }

        /// <summary>
        /// Deletes a texture from memory by id
        /// </summary>
        public static void DeleteTexture(int id)
        {
            // Dispose of desired texture
            _sprites[id].Dispose();
            _sprites.Remove(id);
        }

        /// <summary>
        /// Deletes all the tilemap textures
        /// </summary>
        public static void DeleteTilemaps()
        {
            // If the tile map is empty, return
            if (_tileMaps == null)
                return;

            // Iterate through textures, and dispose of them
            for (int i = 0; i < _tileMaps.Count; i++)
                for (int x = 0; x < _tileMaps[i].GetLength(0); x++)
                    for (int y = 0; y < _tileMaps[i].GetLength(1); y++)
                        _tileMaps[i][x, y].Dispose();

            // Clear elements
            _tileMaps.Clear();
        }

        /// <summary>
        /// Loads a tile map from a bitmap
        /// </summary>
        /// <param name="bitmap">The bitmap to create a tile map from.</param>
        public static void LoadTileMap(Bitmap image, int tileWidth, int tileHeight)
        {
            // Get the columns and row amount for the tile grid
            int cols = image.Width / tileWidth;
            int rows = image.Height / tileHeight;

            // Create a new texture grid
            ResTexture[,] map = new ResTexture[cols, rows];

            // Iterate through columns
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows
                for (int row = 0; row < rows; row++)
                {
                    // Copy image part rectangle
                    Rectangle rect = new Rectangle(col * tileWidth, row * tileHeight, tileWidth, tileHeight);

                    // Create tile texture
                    map[col, row] = new ResTexture(image.Clone(rect, image.PixelFormat));
                }
            }
            
            // Add tile map
            _tileMaps.Add(map);
        }

        #endregion

        #endregion
    }
}