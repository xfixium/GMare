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
using System.Xml;
using System.Collections.Generic;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMShader : GMResource
    {
        #region Fields

        public const string Divider = @"//######################_==_YOYO_SHADER_MARKER_==_######################@~//";
        private string _code = "";
        private string _type = "";

        #endregion

        #region Properties

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

        #region Constructors

        public GMShader()
        {
            // Set base code
            _code = @"//
                    // Simple passthrough vertex shader
                    //
                    attribute vec3 in_Position;                  // (x,y,z)
                    //attribute vec3 in_Normal;                  // (x,y,z)     unused in this shader.	
                    attribute vec4 in_Colour;                    // (r,g,b,a)
                    attribute vec2 in_TextureCoord;              // (u,v)

                    varying vec2 v_vTexcoord;
                    varying vec4 v_vColour;

                    void main()
                    {
                    vec4 object_space_pos = vec4( in_Position.x, in_Position.y, in_Position.z, 1.0);
                    gl_Position = gm_Matrices[MATRIX_WORLD_VIEW_PROJECTION] * object_space_pos;
    
                    v_vColour = in_Colour;
                    v_vTexcoord = in_TextureCoord;
                    }

                    //######################_==_YOYO_SHADER_MARKER_==_######################@~//
                    // Simple passthrough fragment shader
                    //
                    varying vec2 v_vTexcoord;
                    varying vec4 v_vColour;

                    void main()
                    {
                    gl_FragColor = v_vColour * texture2D( gm_BaseTexture, v_vTexcoord );
                    }";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads shaders from Game Maker Studio project file
        /// </summary>
        /// <param name="directory">The directory the shaders are placed</param>
        /// <param name="assets">Collection of project assets</param>
        public static GMList<GMShader> ReadShadersGMX(string directory, ref List<string> assets)
        {
            // A list of shader
            GMList<GMShader> shaders = new GMList<GMShader>();
            shaders.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.shader"))
            {
                // Set name of the shader
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a stream to the shader file
                using (StreamReader streamReader = new StreamReader(file))
                {
                    // Create a new shader
                    GMShader shader = new GMShader();
                    shader.Name = name;
                    shader.Id = GetIdFromName(name);
                    shader.Code = streamReader.ReadToEnd();
                    shader.Type = name;
                    
                    // Add the shader
                    shaders.Add(shader);
                }
            }

            // Return the list of shaders
            return shaders;
        }

        #endregion
    }
}