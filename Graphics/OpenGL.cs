/* 
 * File: OpenGL.cs
 *
 * This source file contains the declaration of the OpenGL class, which
 * contains the declarations of all native opengl fucntions and constants.
 *
 * Copyright (c) Timothy Leonard,  Binary Phoenix. All rights reserved.
 */

using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GMare.Graphics
{
    public enum GLPolygonFaces : uint
    {
        Front = OpenGL.GL_FRONT,
        Back = OpenGL.GL_BACK,
        FrontAndBack = OpenGL.GL_FRONT_AND_BACK,
    }
    public enum GLPolygonMode : uint
    {
        Point = OpenGL.GL_POINT,
        Line = OpenGL.GL_LINE,
        Fill = OpenGL.GL_FILL,
    }

    public enum GLOption : uint
    {
        AlphaTest = OpenGL.GL_ALPHA_TEST,		// If enabled, do alpha testing. See glAlphaFunc. 
        AutoNormal = OpenGL.GL_AUTO_NORMAL,		// If enabled, compute surface normal vectors analytically when either GL_MAP2_VERTEX_3 or GL_MAP2_VERTEX_4 has generated vertices. See glMap2.  
        Blend = OpenGL.GL_BLEND,			// If enabled, blend the incoming RGBA color values with the values in the color buffers. See glBlendFunc. 
        ClipPlane0 = OpenGL.GL_CLIP_PLANE0,		// If enabled, clip geometry against user-defined clipping plane 0. See glClipPlane.  
        ClipPlane1 = OpenGL.GL_CLIP_PLANE1,		// If enabled, clip geometry against user-defined clipping plane 1. See glClipPlane.  
        ClipPlane2 = OpenGL.GL_CLIP_PLANE2,		// If enabled, clip geometry against user-defined clipping plane 2. See glClipPlane.  
        ClipPlane3 = OpenGL.GL_CLIP_PLANE3,		// If enabled, clip geometry against user-defined clipping plane 3. See glClipPlane.  
        ClipPlane4 = OpenGL.GL_CLIP_PLANE4,		// If enabled, clip geometry against user-defined clipping plane 4. See glClipPlane.  
        ClipPlane5 = OpenGL.GL_CLIP_PLANE5,		// If enabled, clip geometry against user-defined clipping plane 5. See glClipPlane.  
        ColorLogicOp = OpenGL.GL_COLOR_LOGIC_OP,	// If enabled, apply the current logical operation to the incoming RGBA color and color buffer values. See glLogicOp. 
        ColorMaterial = OpenGL.GL_COLOR_MATERIAL,	// If enabled, have one or more material parameters track the current color. See glColorMaterial.  
        CullFace = OpenGL.GL_CULL_FACE,		// If enabled, cull polygons based on their winding in window coordinates. See glCullFace. 
        DepthTest = OpenGL.GL_DEPTH_TEST,		// If enabled, do depth comparisons and update the depth buffer. See glDepthFunc and glDepthRange. 
        Dither = OpenGL.GL_DITHER,			// If enabled, dither color components or indexes before they are written to the color buffer.  
        Fog = OpenGL.GL_FOG,				// If enabled, blend a fog color into the post-texturing color. See glFog. 
        IndexLogicOp = OpenGL.GL_INDEX_LOGIC_OP,	// If enabled, apply the current logical operation to the incoming index and color buffer indices. See glLogicOp. 
        Light0 = OpenGL.GL_LIGHT0,			// If enabled, include light 0 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light1 = OpenGL.GL_LIGHT1,			// If enabled, include light 1 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light2 = OpenGL.GL_LIGHT2,			// If enabled, include light 2 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light3 = OpenGL.GL_LIGHT3,			// If enabled, include light 3 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light4 = OpenGL.GL_LIGHT4,			// If enabled, include light 4 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light5 = OpenGL.GL_LIGHT5,			// If enabled, include light 5 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light6 = OpenGL.GL_LIGHT6,			// If enabled, include light 6 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Light7 = OpenGL.GL_LIGHT7,			// If enabled, include light 7 in the evaluation of the lighting equation. See glLightModel and glLight. 
        Lighting = OpenGL.GL_LIGHTING,			// If enabled, use the current lighting parameters to compute the vertex color or index. If disabled, associate the current color or index with each vertex. See glMaterial, glLightModel, and glLight.
        LineSmooth = OpenGL.GL_LINE_SMOOTH,		// If enabled, draw lines with correct filtering. If disabled, draw aliased lines. See glLineWidth. 
        LineStipple = OpenGL.GL_LINE_STIPPLE,		// If enabled, use the current line stipple pattern when drawing lines. See glLineStipple.  
        LogicOp = OpenGL.GL_LOGIC_OP,			// If enabled, apply the currently selected logical operation to the incoming and color-buffer indexes. See glLogicOp.  
        PolygonOffsetFill = OpenGL.GL_POLYGON_OFFSET_FILL,	// If enabled, and if the polygon is rendered in GL_FILL mode, an offset is added to depth values of a polygon's fragments before the depth comparison is performed. See glPolygonOffset. 
        PolygonOffsetLine = OpenGL.GL_POLYGON_OFFSET_LINE,	// If enabled, and if the polygon is rendered in GL_LINE mode, an offset is added to depth values of a polygon's fragments before the depth comparison is performed. See glPolygonOffset. 
        PolygonOffsetPoint = OpenGL.GL_POLYGON_OFFSET_POINT,	// If enabled, an offset is added to depth values of a polygon's fragments before the depth comparison is performed, if the polygon is rendered in GL_POINT mode. See glPolygonOffset. 
        PolygonSmooth = OpenGL.GL_POLYGON_SMOOTH,		// If enabled, draw polygons with proper filtering. If disabled, draw aliased polygons. See glPolygonMode. 
        PolygonStipple = OpenGL.GL_POLYGON_STIPPLE,			// If enabled, use the current polygon stipple pattern when rendering polygons. See glPolygonStipple.  
        PointSmooth = OpenGL.GL_POINT_SMOOTH,			// If enabled, draw points with proper filtering. If disabled, draw aliased points. See glPointSize. 
        Map1Color4 = OpenGL.GL_MAP1_COLOR_4,			// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate RGBA values. See also glMap1.  
        Map1Index = OpenGL.GL_MAP1_INDEX,			// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate color indexes. See also glMap1.  
        Map1Normal = OpenGL.GL_MAP1_NORMAL,			// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate normals. See also glMap1.  
        Map1TextureCoord1 = OpenGL.GL_MAP1_TEXTURE_COORD_1,	// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s texture coordinates. See also glMap1.  
        Map1TextureCoord2 = OpenGL.GL_MAP1_TEXTURE_COORD_2,	// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s and t texture coordinates. See also glMap1.  
        Map1TextureCoord3 = OpenGL.GL_MAP1_TEXTURE_COORD_3,	// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s, t, and r texture coordinates. See also glMap1.  
        Map1TextureCoord4 = OpenGL.GL_MAP1_TEXTURE_COORD_4,	// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate s, t, r, and q texture coordinates. See also glMap1.  
        Map1Vertex3 = OpenGL.GL_MAP1_VERTEX_3,		// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate x, y, and z vertex coordinates. See also glMap1.  
        Map1Vertex4 = OpenGL.GL_MAP1_VERTEX_4,		// If enabled, calls to glEvalCoord1, glEvalMesh1, and glEvalPoint1 generate homogeneous x, y, z, and w vertex coordinates. See also glMap1.  
        Map2Color4 = OpenGL.GL_MAP2_COLOR_4,			// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate RGBA values. See also glMap2.  
        Map2Index = OpenGL.GL_MAP2_INDEX,			// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate color indexes. See also glMap2.  
        Map2Normal = OpenGL.GL_MAP2_NORMAL,			// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate normals. See also glMap2.  
        Map2TextureCoord1 = OpenGL.GL_MAP2_TEXTURE_COORD_1,	// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s texture coordinates. See also glMap2.  
        Map2TextureCoord2 = OpenGL.GL_MAP2_TEXTURE_COORD_2,	// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s and t texture coordinates. See also glMap2.  
        Map2TextureCoord3 = OpenGL.GL_MAP2_TEXTURE_COORD_3,	// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s, t, and r texture coordinates. See also glMap2.  
        Map2TextureCoord4 = OpenGL.GL_MAP2_TEXTURE_COORD_4,	// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate s, t, r, and q texture coordinates. See also glMap2.  
        Map2Vertex3 = OpenGL.GL_MAP2_VERTEX_3,		// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate x, y, and z vertex coordinates. See also glMap2.  
        Map2Vertex4 = OpenGL.GL_MAP2_VERTEX_4,		// If enabled, calls to glEvalCoord2, glEvalMesh2, and glEvalPoint2 generate homogeneous x, y, z, and w vertex coordinates. See also glMap2.  
        Normalize = OpenGL.GL_NORMALIZE,		// If enabled, normal vectors specified with glNormal are scaled to unit length after transformation. See glNormal. 
        ScissorTest = OpenGL.GL_SCISSOR_TEST,		// If enabled, discard fragments that are outside the scissor rectangle. See glScissor.
        StencilTest = OpenGL.GL_STENCIL_TEST,		// If enabled, do stencil testing and update the stencil buffer. See glStencilFunc and glStencilOp.
        Texture1D = OpenGL.GL_TEXTURE_1D,		// If enabled, one-dimensional texturing is performed (unless two-dimensional texturing is also enabled). See glTexImage1D. 
        Texture2D = OpenGL.GL_TEXTURE_2D,		// If enabled, two-dimensional texturing is performed. See glTexImage2D.
        TextureGenQ = OpenGL.GL_TEXTURE_GEN_Q,	// If enabled, the q texture coordinate is computed using the texture-generation function defined with glTexGen. Otherwise, the current q texture coordinate is used.
        TextureGenR = OpenGL.GL_TEXTURE_GEN_R,	// If enabled, the r texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current r texture coordinate is used.  
        TextureGenS = OpenGL.GL_TEXTURE_GEN_S,	// If enabled, the s texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current s texture coordinate is used.  
        TextureGenT = OpenGL.GL_TEXTURE_GEN_T,	// If enabled, the t texture coordinate is computed using the texture generation function defined with glTexGen. If disabled, the current t texture coordinate is used.  
    }

    public enum GLAlphaFunc : uint
    {
        Never = OpenGL.GL_NEVER,	// Never passes.  
        Less = OpenGL.GL_LESS,		// Passes if the incoming alpha value is less than the reference value.  
        Equal = OpenGL.GL_EQUAL,		// Passes if the incoming alpha value is equal to the reference value.  
        LessOrEqual = OpenGL.GL_LEQUAL,		// Passes if the incoming alpha value is less than or equal to the reference value.  
        Greater = OpenGL.GL_GREATER,		//  Passes if the incoming alpha value is greater than the reference value.  
        NotEqual = OpenGL.GL_NOTEQUAL,	// Passes if the incoming alpha value is not equal to the reference value.  
        GreaterOrEqual = OpenGL.GL_GEQUAL,		// Passes if the incoming alpha value is greater than or equal to the reference value.  
        Always = OpenGL.GL_ALWAYS,		// Always passes. This is the default. 
    }

    public enum GLTexture : uint
    {
        Texture1D = OpenGL.GL_TEXTURE_1D,
        Texture2D = OpenGL.GL_TEXTURE_2D
    }

    public enum GLTexEnvTarget : uint
    {
        TextureEnv = OpenGL.GL_TEXTURE_ENV
    }

    public enum GLTexEnvPName : uint
    {
        TextureEnvMode = OpenGL.GL_TEXTURE_ENV_MODE
    }

    public enum GLTexEnvParam : uint
    {
        Modulate = OpenGL.GL_MODULATE,
        Decal = OpenGL.GL_DECAL,
        Blend = OpenGL.GL_BLEND,
        Replace = OpenGL.GL_REPLACE
    }
    public enum GLTexParamPName : uint
    {
        TextureMinFilter = OpenGL.GL_TEXTURE_MIN_FILTER,
        TextureMagFilter = OpenGL.GL_TEXTURE_MAG_FILTER,
        TextureWrapS = OpenGL.GL_TEXTURE_WRAP_S,
        TextureWrapT = OpenGL.GL_TEXTURE_WRAP_T,
        TextureBorderColor = OpenGL.GL_TEXTURE_BORDER_COLOR,
        TexturePriority = OpenGL.GL_TEXTURE_PRIORITY,
    }

    public enum GLTextureFilter : uint
    {
        Nearest = OpenGL.GL_NEAREST,
        Linear = OpenGL.GL_LINEAR,
        NearestMipmapNearest = OpenGL.GL_NEAREST_MIPMAP_NEAREST,
        LinearMipmapNearest = OpenGL.GL_LINEAR_MIPMAP_NEAREST,
        NearestMipmapLinear = OpenGL.GL_NEAREST_MIPMAP_LINEAR,
        LinearMipmapLinear = OpenGL.GL_LINEAR_MIPMAP_LINEAR,
    }

    public enum GLPrimative : uint
    {
        Points = OpenGL.GL_POINTS,
        Lines = OpenGL.GL_LINES,
        Polygon = OpenGL.GL_POLYGON,
        Triangles = OpenGL.GL_TRIANGLES,
        Quads = OpenGL.GL_QUADS,
        LineStrip = OpenGL.GL_LINE_STRIP,
        LineLoop = OpenGL.GL_LINE_LOOP,
        TriangleStrip = OpenGL.GL_TRIANGLE_STRIP,
        TriangleFan = OpenGL.GL_TRIANGLE_FAN,
        QuadStrip = OpenGL.GL_QUAD_STRIP
    }

    public enum GLHint : uint
    {
        PointSmooth = OpenGL.GL_POINT_SMOOTH_HINT,
        LineSmooth = OpenGL.GL_LINE_SMOOTH_HINT,
        PolygonSmooth = OpenGL.GL_POLYGON_SMOOTH_HINT,
        Fog = OpenGL.GL_FOG_HINT,
        PerspectiveCorrection = OpenGL.GL_PERSPECTIVE_CORRECTION_HINT
    }
    public enum GLQuality : uint
    {
        Fastest = OpenGL.GL_FASTEST,
        Nicest = OpenGL.GL_NICEST,
        DontCare = OpenGL.GL_DONT_CARE
    }

    public enum GLMatrixMode : uint
    {
        Projection = OpenGL.GL_PROJECTION,
        ModelView = OpenGL.GL_MODELVIEW,
        Texture = OpenGL.GL_TEXTURE
    }

    public enum GLBuffers : uint
    {
        Color = OpenGL.GL_COLOR_BUFFER_BIT,
        Depth = OpenGL.GL_DEPTH_BUFFER_BIT,
        Accum = OpenGL.GL_ACCUM_BUFFER_BIT,
        Stencil = OpenGL.GL_STENCIL_BUFFER_BIT
    }

    public enum GLDepthFunc : uint
    {
        Less = OpenGL.GL_LESS,
        LessOrEqual = OpenGL.GL_LEQUAL,
        Equal = OpenGL.GL_EQUAL,
        GreaterOrEqual = OpenGL.GL_GEQUAL,
        Greater = OpenGL.GL_GREATER
    }

    public enum GLShadeModel : uint
    {
        Smooth = OpenGL.GL_SMOOTH,
        Flat = OpenGL.GL_FLAT,
    }

    public enum GLBlendSrc : uint
    {
        Zero = OpenGL.GL_ZERO,
        One = OpenGL.GL_ONE,
        DestColor = OpenGL.GL_DST_COLOR,
        OneMinusDestColor = OpenGL.GL_ONE_MINUS_DST_COLOR,
        SrcAlpha = OpenGL.GL_SRC_ALPHA,
        OneMinusSrcAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,
        DestAlpha = OpenGL.GL_DST_ALPHA,
        OneMinusDestAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,
        SrcAlphaSaturate = OpenGL.GL_SRC_ALPHA_SATURATE
    }

    public enum GLBlendDest : uint
    {
        Zero = OpenGL.GL_ZERO,
        One = OpenGL.GL_ONE,
        SrcAlpha = OpenGL.GL_SRC_ALPHA,
        OneMinusSrcAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,
        DestAlpha = OpenGL.GL_DST_ALPHA,
        OneMinusDestAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,
        SrcColor = OpenGL.GL_SRC_COLOR,
        OneMinusSrcColor = OpenGL.GL_ONE_MINUS_SRC_COLOR
    }

    public enum GLInternalFormat : uint
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,

        Alpha = OpenGL.GL_ALPHA,
        Alpha4 = OpenGL.GL_ALPHA4,
        Alpha8 = OpenGL.GL_ALPHA8,
        Alpha12 = OpenGL.GL_ALPHA12,
        Alpha16 = OpenGL.GL_ALPHA16,
        Luminance = OpenGL.GL_LUMINANCE,
        Luminance4 = OpenGL.GL_LUMINANCE4,
        Luminance8 = OpenGL.GL_LUMINANCE8,
        Luminance12 = OpenGL.GL_LUMINANCE12,
        Luminance16 = OpenGL.GL_LUMINANCE16,
        Luminance_Alpha = OpenGL.GL_LUMINANCE_ALPHA,
        Luminance4_Alpha4 = OpenGL.GL_LUMINANCE4_ALPHA4,
        Luminance6_Alpha2 = OpenGL.GL_LUMINANCE6_ALPHA2,
        Luminance8_Alpha8 = OpenGL.GL_LUMINANCE8_ALPHA8,
        Luminance12_Alpha4 = OpenGL.GL_LUMINANCE12_ALPHA4,
        Luminance12_Alpha12 = OpenGL.GL_LUMINANCE12_ALPHA12,
        Luminance16_Alpha16 = OpenGL.GL_LUMINANCE16_ALPHA16,
        Intensity = OpenGL.GL_INTENSITY,
        Intensity4 = OpenGL.GL_INTENSITY4,
        Intensity8 = OpenGL.GL_INTENSITY8,
        Intensity12 = OpenGL.GL_INTENSITY12,
        Intensity16 = OpenGL.GL_INTENSITY16,
        R3G3B2 = OpenGL.GL_R3_G3_B2,
        RGB = OpenGL.GL_RGB,
        RGB4 = OpenGL.GL_RGB4,
        RGB5 = OpenGL.GL_RGB5,
        RGB8 = OpenGL.GL_RGB8,
        RGB10 = OpenGL.GL_RGB10,
        RGB12 = OpenGL.GL_RGB12,
        RGB16 = OpenGL.GL_RGB16,
        RGBA = OpenGL.GL_RGBA,
        RGBA2 = OpenGL.GL_RGBA2,
        RGBA4 = OpenGL.GL_RGBA4,
        RGB5_A1 = OpenGL.GL_RGB5_A1,
        RGBA8 = OpenGL.GL_RGBA8,
        RGBA12 = OpenGL.GL_RGBA12,
        RGB10_A2 = OpenGL.GL_RGB10_A2,
        RGBA16 = OpenGL.GL_RGBA16
    }

    public enum GLPixelFormat : uint
    {
        ColorIndex = OpenGL.GL_COLOR_INDEX,
        Red = OpenGL.GL_RED,
        Green = OpenGL.GL_GREEN,
        Blue = OpenGL.GL_BLUE,
        Alpha = OpenGL.GL_ALPHA,
        RGB = OpenGL.GL_RGB,
        RGBA = OpenGL.GL_RGBA,
        BGRExt = OpenGL.GL_BGR_EXT,
        BGRAExt = OpenGL.GL_BGRA_EXT,
        Luminance = OpenGL.GL_LUMINANCE,
        LuminanceAlpha = OpenGL.GL_LUMINANCE_ALPHA
    }

    public enum GLDataType : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        Byte = OpenGL.GL_BYTE,
        Bitmap = OpenGL.GL_BITMAP,
        UnsignedShort = OpenGL.GL_UNSIGNED_SHORT,
        Short = OpenGL.GL_SHORT,
        UnsignedInt = OpenGL.GL_UNSIGNED_INT,
        Int = OpenGL.GL_INT,
        Float = OpenGL.GL_FLOAT
    }

    public enum GLUnsignedDataType : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        UnsignedShort = OpenGL.GL_UNSIGNED_SHORT,
        UnsignedInt = OpenGL.GL_UNSIGNED_INT
    }

    public enum GLPixelStore : uint
    {
        PackSwapBytes = OpenGL.GL_PACK_SWAP_BYTES,
        PackRowLength = OpenGL.GL_PACK_ROW_LENGTH,
        PackSkipRows = OpenGL.GL_PACK_SKIP_ROWS,
        PackSkipPixels = OpenGL.GL_PACK_SKIP_PIXELS,
        PackAlignment = OpenGL.GL_PACK_ALIGNMENT,
        UnpackSwapBytes = OpenGL.GL_UNPACK_SWAP_BYTES,
        UnpackLSBFirst = OpenGL.GL_UNPACK_LSB_FIRST,
        UnpackRowLength = OpenGL.GL_UNPACK_ROW_LENGTH,
        UnpackSkipRows = OpenGL.GL_UNPACK_SKIP_ROWS,
        UnpackSkipPixels = OpenGL.GL_UNPACK_SKIP_PIXELS,
        UnpackAlighment = OpenGL.GL_UNPACK_ALIGNMENT,
    }

    public enum GLStringName : uint
    {
        Vendor = OpenGL.GL_VENDOR,
        Renderer = OpenGL.GL_RENDERER,
        Version = OpenGL.GL_VERSION,
        Extensions = OpenGL.GL_EXTENSIONS,
    }

    /// standart error for 3D exception which, though rare, could
    /// occur, generaly in some init process
    public class OpenGLException : SystemException
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern int GetLastError();
        [DllImport("csogl")]
        public static extern string GetLastErrorString();

        /// when called it automatically initialize from system last error
        public OpenGLException() : base(GetLastError() + ": " + GetLastErrorString()) { }
        public OpenGLException(string s) : base(s) { }
        public OpenGLException(string s, Exception e) : base(s, e) { }
    }

    /// <summary>
    ///     Contains te definitions of all native openGL functions and constants.
    /// </summary>
    public class OpenGL
    {
        /* Extensions */
        public const uint GL_VERSION_1_1 = 1;
        public const uint GL_EXT_abgr = 1;
        public const uint GL_EXT_bgra = 1;
        public const uint GL_EXT_packed_pixels = 1;
        public const uint GL_EXT_paletted_texture = 1;
        public const uint GL_EXT_vertex_array = 1;
        public const uint GL_SGI_compiled_vertex_array = 1;
        public const uint GL_SGI_cull_vertex = 1;
        public const uint GL_SGI_index_array_formats = 1;
        public const uint GL_SGI_index_func = 1;
        public const uint GL_SGI_index_material = 1;
        public const uint GL_SGI_index_texture = 1;
        public const uint GL_WIN_swap_hint = 1;

        /* AttribMask */
        public const uint GL_CURRENT_BIT = 0x00000001;
        public const uint GL_POINT_BIT = 0x00000002;
        public const uint GL_LINE_BIT = 0x00000004;
        public const uint GL_POLYGON_BIT = 0x00000008;
        public const uint GL_POLYGON_STIPPLE_BIT = 0x00000010;
        public const uint GL_PIXEL_MODE_BIT = 0x00000020;
        public const uint GL_LIGHTING_BIT = 0x00000040;
        public const uint GL_FOG_BIT = 0x00000080;
        public const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
        public const uint GL_ACCUM_BUFFER_BIT = 0x00000200;
        public const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
        public const uint GL_VIEWPORT_BIT = 0x00000800;
        public const uint GL_TRANSFORM_BIT = 0x00001000;
        public const uint GL_ENABLE_BIT = 0x00002000;
        public const uint GL_COLOR_BUFFER_BIT = 0x00004000;
        public const uint GL_HINT_BIT = 0x00008000;
        public const uint GL_EVAL_BIT = 0x00010000;
        public const uint GL_LIST_BIT = 0x00020000;
        public const uint GL_TEXTURE_BIT = 0x00040000;
        public const uint GL_SCISSOR_BIT = 0x00080000;
        public const uint GL_ALL_ATTRIB_BITS = 0x000fffff;

        /* ClientAttribMask */
        public const uint GL_CLIENT_PIXEL_STORE_BIT = 0x00000001;
        public const uint GL_CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        public const uint GL_CLIENT_ALL_ATTRIB_BITS = 0xFFFFFFFF;

        /* Boolean */
        public const uint GL_FALSE = 0;
        public const uint GL_TRUE = 1;

        /* BeginMode */
        public const uint GL_POINTS = 0x0000;
        public const uint GL_LINES = 0x0001;
        public const uint GL_LINE_LOOP = 0x0002;
        public const uint GL_LINE_STRIP = 0x0003;
        public const uint GL_TRIANGLES = 0x0004;
        public const uint GL_TRIANGLE_STRIP = 0x0005;
        public const uint GL_TRIANGLE_FAN = 0x0006;
        public const uint GL_QUADS = 0x0007;
        public const uint GL_QUAD_STRIP = 0x0008;
        public const uint GL_POLYGON = 0x0009;

        /* AccumOp */
        public const uint GL_ACCUM = 0x0100;
        public const uint GL_LOAD = 0x0101;
        public const uint GL_RETURN = 0x0102;
        public const uint GL_MULT = 0x0103;
        public const uint GL_ADD = 0x0104;

        /* AlphaFunction */
        public const uint GL_NEVER = 0x0200;
        public const uint GL_LESS = 0x0201;
        public const uint GL_EQUAL = 0x0202;
        public const uint GL_LEQUAL = 0x0203;
        public const uint GL_GREATER = 0x0204;
        public const uint GL_NOTEQUAL = 0x0205;
        public const uint GL_GEQUAL = 0x0206;
        public const uint GL_ALWAYS = 0x0207;

        /* BlendingFactorDest */
        public const uint GL_ZERO = 0;
        public const uint GL_ONE = 1;
        public const uint GL_SRC_COLOR = 0x0300;
        public const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
        public const uint GL_SRC_ALPHA = 0x0302;
        public const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const uint GL_DST_ALPHA = 0x0304;
        public const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;

        /* BlendingFactorSrc */
        public const uint GL_DST_COLOR = 0x0306;
        public const uint GL_ONE_MINUS_DST_COLOR = 0x0307;
        public const uint GL_SRC_ALPHA_SATURATE = 0x0308;

        /* DrawBufferMode */
        public const uint GL_NONE = 0;
        public const uint GL_FRONT_LEFT = 0x0400;
        public const uint GL_FRONT_RIGHT = 0x0401;
        public const uint GL_BACK_LEFT = 0x0402;
        public const uint GL_BACK_RIGHT = 0x0403;
        public const uint GL_FRONT = 0x0404;
        public const uint GL_BACK = 0x0405;
        public const uint GL_LEFT = 0x0406;
        public const uint GL_RIGHT = 0x0407;
        public const uint GL_FRONT_AND_BACK = 0x0408;
        public const uint GL_AUX0 = 0x0409;
        public const uint GL_AUX1 = 0x040A;
        public const uint GL_AUX2 = 0x040B;
        public const uint GL_AUX3 = 0x040C;

        /* ErrorCode */
        public const uint GL_NO_ERROR = 0;
        public const uint GL_INVALID_ENUM = 0x0500;
        public const uint GL_INVALID_VALUE = 0x0501;
        public const uint GL_INVALID_OPERATION = 0x0502;
        public const uint GL_STACK_OVERFLOW = 0x0503;
        public const uint GL_STACK_UNDERFLOW = 0x0504;
        public const uint GL_OUT_OF_MEMORY = 0x0505;

        /* FeedbackType */
        public const uint GL_2D = 0x0600;
        public const uint GL_3D = 0x0601;
        public const uint GL_3D_COLOR = 0x0602;
        public const uint GL_3D_COLOR_TEXTURE = 0x0603;
        public const uint GL_4D_COLOR_TEXTURE = 0x0604;

        /* FeedBackToken */
        public const uint GL_PASS_THROUGH_TOKEN = 0x0700;
        public const uint GL_POINT_TOKEN = 0x0701;
        public const uint GL_LINE_TOKEN = 0x0702;
        public const uint GL_POLYGON_TOKEN = 0x0703;
        public const uint GL_BITMAP_TOKEN = 0x0704;
        public const uint GL_DRAW_PIXEL_TOKEN = 0x0705;
        public const uint GL_COPY_PIXEL_TOKEN = 0x0706;
        public const uint GL_LINE_RESET_TOKEN = 0x0707;

        public const uint GL_EXP = 0x0800;
        public const uint GL_EXP2 = 0x0801;

        /* FrontFaceDirection */
        public const uint GL_CW = 0x0900;
        public const uint GL_CCW = 0x0901;

        /* GetMapQuery */
        public const uint GL_COEFF = 0x0A00;
        public const uint GL_ORDER = 0x0A01;
        public const uint GL_DOMAIN = 0x0A02;

        /* GetPixelMap */
        public const uint GL_PIXEL_MAP_I_TO_I = 0x0C70;
        public const uint GL_PIXEL_MAP_S_TO_S = 0x0C71;
        public const uint GL_PIXEL_MAP_I_TO_R = 0x0C72;
        public const uint GL_PIXEL_MAP_I_TO_G = 0x0C73;
        public const uint GL_PIXEL_MAP_I_TO_B = 0x0C74;
        public const uint GL_PIXEL_MAP_I_TO_A = 0x0C75;
        public const uint GL_PIXEL_MAP_R_TO_R = 0x0C76;
        public const uint GL_PIXEL_MAP_G_TO_G = 0x0C77;
        public const uint GL_PIXEL_MAP_B_TO_B = 0x0C78;
        public const uint GL_PIXEL_MAP_A_TO_A = 0x0C79;

        /* GetPointervPName */
        public const uint GL_VERTEX_ARRAY_POINTER = 0x808E;
        public const uint GL_NORMAL_ARRAY_POINTER = 0x808F;
        public const uint GL_COLOR_ARRAY_POINTER = 0x8090;
        public const uint GL_INDEX_ARRAY_POINTER = 0x8091;
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const uint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;

        /* GetPName */
        public const uint GL_CURRENT_COLOR = 0x0B00;
        public const uint GL_CURRENT_INDEX = 0x0B01;
        public const uint GL_CURRENT_NORMAL = 0x0B02;
        public const uint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
        public const uint GL_CURRENT_RASTER_COLOR = 0x0B04;
        public const uint GL_CURRENT_RASTER_INDEX = 0x0B05;
        public const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        public const uint GL_CURRENT_RASTER_POSITION = 0x0B07;
        public const uint GL_CURRENT_RASTER_POSITION_VALID = 0x0B08;
        public const uint GL_CURRENT_RASTER_DISTANCE = 0x0B09;
        public const uint GL_POINT_SMOOTH = 0x0B10;
        public const uint GL_POINT_SIZE = 0x0B11;
        public const uint GL_POINT_SIZE_RANGE = 0x0B12;
        public const uint GL_POINT_SIZE_GRANULARITY = 0x0B13;
        public const uint GL_LINE_SMOOTH = 0x0B20;
        public const uint GL_LINE_WIDTH = 0x0B21;
        public const uint GL_LINE_WIDTH_RANGE = 0x0B22;
        public const uint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const uint GL_LINE_STIPPLE = 0x0B24;
        public const uint GL_LINE_STIPPLE_PATTERN = 0x0B25;
        public const uint GL_LINE_STIPPLE_REPEAT = 0x0B26;
        public const uint GL_LIST_MODE = 0x0B30;
        public const uint GL_MAX_LIST_NESTING = 0x0B31;
        public const uint GL_LIST_BASE = 0x0B32;
        public const uint GL_LIST_INDEX = 0x0B33;
        public const uint GL_POLYGON_MODE = 0x0B40;
        public const uint GL_POLYGON_SMOOTH = 0x0B41;
        public const uint GL_POLYGON_STIPPLE = 0x0B42;
        public const uint GL_EDGE_FLAG = 0x0B43;
        public const uint GL_CULL_FACE = 0x0B44;
        public const uint GL_CULL_FACE_MODE = 0x0B45;
        public const uint GL_FRONT_FACE = 0x0B46;
        public const uint GL_LIGHTING = 0x0B50;
        public const uint GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const uint GL_LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const uint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
        public const uint GL_SHADE_MODEL = 0x0B54;
        public const uint GL_COLOR_MATERIAL_FACE = 0x0B55;
        public const uint GL_COLOR_MATERIAL_PARAMETER = 0x0B56;
        public const uint GL_COLOR_MATERIAL = 0x0B57;
        public const uint GL_FOG = 0x0B60;
        public const uint GL_FOG_INDEX = 0x0B61;
        public const uint GL_FOG_DENSITY = 0x0B62;
        public const uint GL_FOG_START = 0x0B63;
        public const uint GL_FOG_END = 0x0B64;
        public const uint GL_FOG_MODE = 0x0B65;
        public const uint GL_FOG_COLOR = 0x0B66;
        public const uint GL_DEPTH_RANGE = 0x0B70;
        public const uint GL_DEPTH_TEST = 0x0B71;
        public const uint GL_DEPTH_WRITEMASK = 0x0B72;
        public const uint GL_DEPTH_CLEAR_VALUE = 0x0B73;
        public const uint GL_DEPTH_FUNC = 0x0B74;
        public const uint GL_ACCUM_CLEAR_VALUE = 0x0B80;
        public const uint GL_STENCIL_TEST = 0x0B90;
        public const uint GL_STENCIL_CLEAR_VALUE = 0x0B91;
        public const uint GL_STENCIL_FUNC = 0x0B92;
        public const uint GL_STENCIL_VALUE_MASK = 0x0B93;
        public const uint GL_STENCIL_FAIL = 0x0B94;
        public const uint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const uint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const uint GL_STENCIL_REF = 0x0B97;
        public const uint GL_STENCIL_WRITEMASK = 0x0B98;
        public const uint GL_MATRIX_MODE = 0x0BA0;
        public const uint GL_NORMALIZE = 0x0BA1;
        public const uint GL_VIEWPORT = 0x0BA2;
        public const uint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
        public const uint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
        public const uint GL_TEXTURE_STACK_DEPTH = 0x0BA5;
        public const uint GL_MODELVIEW_MATRIX = 0x0BA6;
        public const uint GL_PROJECTION_MATRIX = 0x0BA7;
        public const uint GL_TEXTURE_MATRIX = 0x0BA8;
        public const uint GL_ATTRIB_STACK_DEPTH = 0x0BB0;
        public const uint GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        public const uint GL_ALPHA_TEST = 0x0BC0;
        public const uint GL_ALPHA_TEST_FUNC = 0x0BC1;
        public const uint GL_ALPHA_TEST_REF = 0x0BC2;
        public const uint GL_DITHER = 0x0BD0;
        public const uint GL_BLEND_DST = 0x0BE0;
        public const uint GL_BLEND_SRC = 0x0BE1;
        public const uint GL_BLEND = 0x0BE2;
        public const uint GL_LOGIC_OP_MODE = 0x0BF0;
        public const uint GL_INDEX_LOGIC_OP = 0x0BF1;
        public const uint GL_LOGIC_OP = GL_INDEX_LOGIC_OP;
        public const uint GL_COLOR_LOGIC_OP = 0x0BF2;
        public const uint GL_AUX_BUFFERS = 0x0C00;
        public const uint GL_DRAW_BUFFER = 0x0C01;
        public const uint GL_READ_BUFFER = 0x0C02;
        public const uint GL_SCISSOR_BOX = 0x0C10;
        public const uint GL_SCISSOR_TEST = 0x0C11;
        public const uint GL_INDEX_CLEAR_VALUE = 0x0C20;
        public const uint GL_INDEX_WRITEMASK = 0x0C21;
        public const uint GL_COLOR_CLEAR_VALUE = 0x0C22;
        public const uint GL_COLOR_WRITEMASK = 0x0C23;
        public const uint GL_INDEX_MODE = 0x0C30;
        public const uint GL_RGBA_MODE = 0x0C31;
        public const uint GL_DOUBLEBUFFER = 0x0C32;
        public const uint GL_STEREO = 0x0C33;
        public const uint GL_RENDER_MODE = 0x0C40;
        public const uint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        public const uint GL_POINT_SMOOTH_HINT = 0x0C51;
        public const uint GL_LINE_SMOOTH_HINT = 0x0C52;
        public const uint GL_POLYGON_SMOOTH_HINT = 0x0C53;
        public const uint GL_FOG_HINT = 0x0C54;
        public const uint GL_TEXTURE_GEN_S = 0x0C60;
        public const uint GL_TEXTURE_GEN_T = 0x0C61;
        public const uint GL_TEXTURE_GEN_R = 0x0C62;
        public const uint GL_TEXTURE_GEN_Q = 0x0C63;
        public const uint GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        public const uint GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        public const uint GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        public const uint GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        public const uint GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        public const uint GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        public const uint GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        public const uint GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        public const uint GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        public const uint GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        public const uint GL_UNPACK_SWAP_BYTES = 0x0CF0;
        public const uint GL_UNPACK_LSB_FIRST = 0x0CF1;
        public const uint GL_UNPACK_ROW_LENGTH = 0x0CF2;
        public const uint GL_UNPACK_SKIP_ROWS = 0x0CF3;
        public const uint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
        public const uint GL_UNPACK_ALIGNMENT = 0x0CF5;
        public const uint GL_PACK_SWAP_BYTES = 0x0D00;
        public const uint GL_PACK_LSB_FIRST = 0x0D01;
        public const uint GL_PACK_ROW_LENGTH = 0x0D02;
        public const uint GL_PACK_SKIP_ROWS = 0x0D03;
        public const uint GL_PACK_SKIP_PIXELS = 0x0D04;
        public const uint GL_PACK_ALIGNMENT = 0x0D05;
        public const uint GL_MAP_COLOR = 0x0D10;
        public const uint GL_MAP_STENCIL = 0x0D11;
        public const uint GL_INDEX_SHIFT = 0x0D12;
        public const uint GL_INDEX_OFFSET = 0x0D13;
        public const uint GL_RED_SCALE = 0x0D14;
        public const uint GL_RED_BIAS = 0x0D15;
        public const uint GL_ZOOM_X = 0x0D16;
        public const uint GL_ZOOM_Y = 0x0D17;
        public const uint GL_GREEN_SCALE = 0x0D18;
        public const uint GL_GREEN_BIAS = 0x0D19;
        public const uint GL_BLUE_SCALE = 0x0D1A;
        public const uint GL_BLUE_BIAS = 0x0D1B;
        public const uint GL_ALPHA_SCALE = 0x0D1C;
        public const uint GL_ALPHA_BIAS = 0x0D1D;
        public const uint GL_DEPTH_SCALE = 0x0D1E;
        public const uint GL_DEPTH_BIAS = 0x0D1F;
        public const uint GL_MAX_EVAL_ORDER = 0x0D30;
        public const uint GL_MAX_LIGHTS = 0x0D31;
        public const uint GL_MAX_CLIP_PLANES = 0x0D32;
        public const uint GL_MAX_TEXTURE_SIZE = 0x0D33;
        public const uint GL_MAX_PIXEL_MAP_TABLE = 0x0D34;
        public const uint GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        public const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        public const uint GL_MAX_NAME_STACK_DEPTH = 0x0D37;
        public const uint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        public const uint GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        public const uint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
        public const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        public const uint GL_SUBPIXEL_BITS = 0x0D50;
        public const uint GL_INDEX_BITS = 0x0D51;
        public const uint GL_RED_BITS = 0x0D52;
        public const uint GL_GREEN_BITS = 0x0D53;
        public const uint GL_BLUE_BITS = 0x0D54;
        public const uint GL_ALPHA_BITS = 0x0D55;
        public const uint GL_DEPTH_BITS = 0x0D56;
        public const uint GL_STENCIL_BITS = 0x0D57;
        public const uint GL_ACCUM_RED_BITS = 0x0D58;
        public const uint GL_ACCUM_GREEN_BITS = 0x0D59;
        public const uint GL_ACCUM_BLUE_BITS = 0x0D5A;
        public const uint GL_ACCUM_ALPHA_BITS = 0x0D5B;
        public const uint GL_NAME_STACK_DEPTH = 0x0D70;
        public const uint GL_AUTO_NORMAL = 0x0D80;
        public const uint GL_MAP1_COLOR_4 = 0x0D90;
        public const uint GL_MAP1_INDEX = 0x0D91;
        public const uint GL_MAP1_NORMAL = 0x0D92;
        public const uint GL_MAP1_TEXTURE_COORD_1 = 0x0D93;
        public const uint GL_MAP1_TEXTURE_COORD_2 = 0x0D94;
        public const uint GL_MAP1_TEXTURE_COORD_3 = 0x0D95;
        public const uint GL_MAP1_TEXTURE_COORD_4 = 0x0D96;
        public const uint GL_MAP1_VERTEX_3 = 0x0D97;
        public const uint GL_MAP1_VERTEX_4 = 0x0D98;
        public const uint GL_MAP2_COLOR_4 = 0x0DB0;
        public const uint GL_MAP2_INDEX = 0x0DB1;
        public const uint GL_MAP2_NORMAL = 0x0DB2;
        public const uint GL_MAP2_TEXTURE_COORD_1 = 0x0DB3;
        public const uint GL_MAP2_TEXTURE_COORD_2 = 0x0DB4;
        public const uint GL_MAP2_TEXTURE_COORD_3 = 0x0DB5;
        public const uint GL_MAP2_TEXTURE_COORD_4 = 0x0DB6;
        public const uint GL_MAP2_VERTEX_3 = 0x0DB7;
        public const uint GL_MAP2_VERTEX_4 = 0x0DB8;
        public const uint GL_MAP1_GRID_DOMAIN = 0x0DD0;
        public const uint GL_MAP1_GRID_SEGMENTS = 0x0DD1;
        public const uint GL_MAP2_GRID_DOMAIN = 0x0DD2;
        public const uint GL_MAP2_GRID_SEGMENTS = 0x0DD3;
        public const uint GL_TEXTURE_1D = 0x0DE0;
        public const uint GL_TEXTURE_2D = 0x0DE1;
        public const uint GL_FEEDBACK_BUFFER_POINTER = 0x0DF0;
        public const uint GL_FEEDBACK_BUFFER_SIZE = 0x0DF1;
        public const uint GL_FEEDBACK_BUFFER_TYPE = 0x0DF2;
        public const uint GL_SELECTION_BUFFER_POINTER = 0x0DF3;
        public const uint GL_SELECTION_BUFFER_SIZE = 0x0DF4;
        public const uint GL_POLYGON_OFFSET_UNITS = 0x2A00;
        public const uint GL_POLYGON_OFFSET_POINT = 0x2A01;
        public const uint GL_POLYGON_OFFSET_LINE = 0x2A02;
        public const uint GL_POLYGON_OFFSET_FILL = 0x8037;
        public const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
        public const uint GL_TEXTURE_BINDING_1D = 0x8068;
        public const uint GL_TEXTURE_BINDING_2D = 0x8069;
        public const uint GL_VERTEX_ARRAY = 0x8074;
        public const uint GL_NORMAL_ARRAY = 0x8075;
        public const uint GL_COLOR_ARRAY = 0x8076;
        public const uint GL_INDEX_ARRAY = 0x8077;
        public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
        public const uint GL_EDGE_FLAG_ARRAY = 0x8079;
        public const uint GL_VERTEX_ARRAY_SIZE = 0x807A;
        public const uint GL_VERTEX_ARRAY_TYPE = 0x807B;
        public const uint GL_VERTEX_ARRAY_STRIDE = 0x807C;
        public const uint GL_NORMAL_ARRAY_TYPE = 0x807E;
        public const uint GL_NORMAL_ARRAY_STRIDE = 0x807F;
        public const uint GL_COLOR_ARRAY_SIZE = 0x8081;
        public const uint GL_COLOR_ARRAY_TYPE = 0x8082;
        public const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
        public const uint GL_INDEX_ARRAY_TYPE = 0x8085;
        public const uint GL_INDEX_ARRAY_STRIDE = 0x8086;
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C;

        public const uint GL_TEXTURE_WIDTH = 0x1000;
        public const uint GL_TEXTURE_HEIGHT = 0x1001;
        public const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const uint GL_TEXTURE_COMPONENTS = GL_TEXTURE_INTERNAL_FORMAT;
        public const uint GL_TEXTURE_BORDER_COLOR = 0x1004;
        public const uint GL_TEXTURE_BORDER = 0x1005;
        public const uint GL_TEXTURE_RED_SIZE = 0x805C;
        public const uint GL_TEXTURE_GREEN_SIZE = 0x805D;
        public const uint GL_TEXTURE_BLUE_SIZE = 0x805E;
        public const uint GL_TEXTURE_ALPHA_SIZE = 0x805F;
        public const uint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const uint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
        public const uint GL_TEXTURE_PRIORITY = 0x8066;
        public const uint GL_TEXTURE_RESIDENT = 0x8067;

        /* HintMode */
        public const uint GL_DONT_CARE = 0x1100;
        public const uint GL_FASTEST = 0x1101;
        public const uint GL_NICEST = 0x1102;

        /* LightParameter */
        public const uint GL_AMBIENT = 0x1200;
        public const uint GL_DIFFUSE = 0x1201;
        public const uint GL_SPECULAR = 0x1202;
        public const uint GL_POSITION = 0x1203;
        public const uint GL_SPOT_DIRECTION = 0x1204;
        public const uint GL_SPOT_EXPONENT = 0x1205;
        public const uint GL_SPOT_CUTOFF = 0x1206;
        public const uint GL_CONSTANT_ATTENUATION = 0x1207;
        public const uint GL_LINEAR_ATTENUATION = 0x1208;
        public const uint GL_QUADRATIC_ATTENUATION = 0x1209;

        /* ListMode */
        public const uint GL_COMPILE = 0x1300;
        public const uint GL_COMPILE_AND_EXECUTE = 0x1301;

        /* DataType */
        public const uint GL_BYTE = 0x1400;
        public const uint GL_UNSIGNED_BYTE = 0x1401;
        public const uint GL_SHORT = 0x1402;
        public const uint GL_UNSIGNED_SHORT = 0x1403;
        public const uint GL_INT = 0x1404;
        public const uint GL_UNSIGNED_INT = 0x1405;
        public const uint GL_FLOAT = 0x1406;
        public const uint GL_2_BYTES = 0x1407;
        public const uint GL_3_BYTES = 0x1408;
        public const uint GL_4_BYTES = 0x1409;
        public const uint GL_DOUBLE = 0x140A;
        public const uint GL_DOUBLE_EXT = 0x140A;

        /* LogicOp */
        public const uint GL_CLEAR = 0x1500;
        public const uint GL_AND = 0x1501;
        public const uint GL_AND_REVERSE = 0x1502;
        public const uint GL_COPY = 0x1503;
        public const uint GL_AND_INVERTED = 0x1504;
        public const uint GL_NOOP = 0x1505;
        public const uint GL_XOR = 0x1506;
        public const uint GL_OR = 0x1507;
        public const uint GL_NOR = 0x1508;
        public const uint GL_EQUIV = 0x1509;
        public const uint GL_INVERT = 0x150A;
        public const uint GL_OR_REVERSE = 0x150B;
        public const uint GL_COPY_INVERTED = 0x150C;
        public const uint GL_OR_INVERTED = 0x150D;
        public const uint GL_NAND = 0x150E;
        public const uint GL_SET = 0x150F;

        /* MaterialParameter */
        public const uint GL_EMISSION = 0x1600;
        public const uint GL_SHININESS = 0x1601;
        public const uint GL_AMBIENT_AND_DIFFUSE = 0x1602;
        public const uint GL_COLOR_INDEXES = 0x1603;

        /* MatrixMode */
        public const uint GL_MODELVIEW = 0x1700;
        public const uint GL_PROJECTION = 0x1701;
        public const uint GL_TEXTURE = 0x1702;

        /* PixelCopyType */
        public const uint GL_COLOR = 0x1800;
        public const uint GL_DEPTH = 0x1801;
        public const uint GL_STENCIL = 0x1802;

        /* PixelFormat */
        public const uint GL_COLOR_INDEX = 0x1900;
        public const uint GL_STENCIL_INDEX = 0x1901;
        public const uint GL_DEPTH_COMPONENT = 0x1902;
        public const uint GL_RED = 0x1903;
        public const uint GL_GREEN = 0x1904;
        public const uint GL_BLUE = 0x1905;
        public const uint GL_ALPHA = 0x1906;
        public const uint GL_RGB = 0x1907;
        public const uint GL_RGBA = 0x1908;
        public const uint GL_LUMINANCE = 0x1909;
        public const uint GL_LUMINANCE_ALPHA = 0x190A;

        /* PixelType */
        public const uint GL_BITMAP = 0x1A00;

        /* PolygonMode */
        public const uint GL_POINT = 0x1B00;
        public const uint GL_LINE = 0x1B01;
        public const uint GL_FILL = 0x1B02;

        /* RenderingMode */
        public const uint GL_RENDER = 0x1C00;
        public const uint GL_FEEDBACK = 0x1C01;
        public const uint GL_SELECT = 0x1C02;

        /* ShadingModel */
        public const uint GL_FLAT = 0x1D00;
        public const uint GL_SMOOTH = 0x1D01;

        /* StencilOp */
        public const uint GL_KEEP = 0x1E00;
        public const uint GL_REPLACE = 0x1E01;
        public const uint GL_INCR = 0x1E02;
        public const uint GL_DECR = 0x1E03;

        /* StringName */
        public const uint GL_VENDOR = 0x1F00;
        public const uint GL_RENDERER = 0x1F01;
        public const uint GL_VERSION = 0x1F02;
        public const uint GL_EXTENSIONS = 0x1F03;

        /* TextureCoordName */
        public const uint GL_S = 0x2000;
        public const uint GL_T = 0x2001;
        public const uint GL_R = 0x2002;
        public const uint GL_Q = 0x2003;

        /* TextureEnvMode */
        public const uint GL_MODULATE = 0x2100;
        public const uint GL_DECAL = 0x2101;

        /* TextureEnvParameter */
        public const uint GL_TEXTURE_ENV_MODE = 0x2200;
        public const uint GL_TEXTURE_ENV_COLOR = 0x2201;

        /* TextureEnvTarget */
        public const uint GL_TEXTURE_ENV = 0x2300;

        /* TextureGenMode */
        public const uint GL_EYE_LINEAR = 0x2400;
        public const uint GL_OBJECT_LINEAR = 0x2401;
        public const uint GL_SPHERE_MAP = 0x2402;

        /* TextureGenParameter */
        public const uint GL_TEXTURE_GEN_MODE = 0x2500;
        public const uint GL_OBJECT_PLANE = 0x2501;
        public const uint GL_EYE_PLANE = 0x2502;

        /* TextureMagFilter */
        public const uint GL_NEAREST = 0x2600;
        public const uint GL_LINEAR = 0x2601;

        /* TextureMinFilter */
        public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;

        /* TextureParameterName */
        public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
        public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
        public const uint GL_TEXTURE_WRAP_S = 0x2802;
        public const uint GL_TEXTURE_WRAP_T = 0x2803;

        /* TextureTarget */
        public const uint GL_PROXY_TEXTURE_1D = 0x8063;
        public const uint GL_PROXY_TEXTURE_2D = 0x8064;

        /* TextureWrapMode */
        public const uint GL_CLAMP = 0x2900;
        public const uint GL_REPEAT = 0x2901;

        /* PixelInternalFormat */
        public const uint GL_R3_G3_B2 = 0x2A10;
        public const uint GL_ALPHA4 = 0x803B;
        public const uint GL_ALPHA8 = 0x803C;
        public const uint GL_ALPHA12 = 0x803D;
        public const uint GL_ALPHA16 = 0x803E;
        public const uint GL_LUMINANCE4 = 0x803F;
        public const uint GL_LUMINANCE8 = 0x8040;
        public const uint GL_LUMINANCE12 = 0x8041;
        public const uint GL_LUMINANCE16 = 0x8042;
        public const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
        public const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
        public const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
        public const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
        public const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
        public const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
        public const uint GL_INTENSITY = 0x8049;
        public const uint GL_INTENSITY4 = 0x804A;
        public const uint GL_INTENSITY8 = 0x804B;
        public const uint GL_INTENSITY12 = 0x804C;
        public const uint GL_INTENSITY16 = 0x804D;
        public const uint GL_RGB4 = 0x804F;
        public const uint GL_RGB5 = 0x8050;
        public const uint GL_RGB8 = 0x8051;
        public const uint GL_RGB10 = 0x8052;
        public const uint GL_RGB12 = 0x8053;
        public const uint GL_RGB16 = 0x8054;
        public const uint GL_RGBA2 = 0x8055;
        public const uint GL_RGBA4 = 0x8056;
        public const uint GL_RGB5_A1 = 0x8057;
        public const uint GL_RGBA8 = 0x8058;
        public const uint GL_RGB10_A2 = 0x8059;
        public const uint GL_RGBA12 = 0x805A;
        public const uint GL_RGBA16 = 0x805B;

        /* InterleavedArrayFormat */
        public const uint GL_V2F = 0x2A20;
        public const uint GL_V3F = 0x2A21;
        public const uint GL_C4UB_V2F = 0x2A22;
        public const uint GL_C4UB_V3F = 0x2A23;
        public const uint GL_C3F_V3F = 0x2A24;
        public const uint GL_N3F_V3F = 0x2A25;
        public const uint GL_C4F_N3F_V3F = 0x2A26;
        public const uint GL_T2F_V3F = 0x2A27;
        public const uint GL_T4F_V4F = 0x2A28;
        public const uint GL_T2F_C4UB_V3F = 0x2A29;
        public const uint GL_T2F_C3F_V3F = 0x2A2A;
        public const uint GL_T2F_N3F_V3F = 0x2A2B;
        public const uint GL_T2F_C4F_N3F_V3F = 0x2A2C;
        public const uint GL_T4F_C4F_N3F_V4F = 0x2A2D;

        /* ClipPlaneName */
        public const uint GL_CLIP_PLANE0 = 0x3000;
        public const uint GL_CLIP_PLANE1 = 0x3001;
        public const uint GL_CLIP_PLANE2 = 0x3002;
        public const uint GL_CLIP_PLANE3 = 0x3003;
        public const uint GL_CLIP_PLANE4 = 0x3004;
        public const uint GL_CLIP_PLANE5 = 0x3005;

        /* LightName */
        public const uint GL_LIGHT0 = 0x4000;
        public const uint GL_LIGHT1 = 0x4001;
        public const uint GL_LIGHT2 = 0x4002;
        public const uint GL_LIGHT3 = 0x4003;
        public const uint GL_LIGHT4 = 0x4004;
        public const uint GL_LIGHT5 = 0x4005;
        public const uint GL_LIGHT6 = 0x4006;
        public const uint GL_LIGHT7 = 0x4007;

        /* EXT_abgr */
        public const uint GL_ABGR_EXT = 0x8000;

        /* EXT_packed_pixels */
        public const uint GL_UNSIGNED_BYTE_3_3_2_EXT = 0x8032;
        public const uint GL_UNSIGNED_SHORT_4_4_4_4_EXT = 0x8033;
        public const uint GL_UNSIGNED_SHORT_5_5_5_1_EXT = 0x8034;
        public const uint GL_UNSIGNED_INT_8_8_8_8_EXT = 0x8035;
        public const uint GL_UNSIGNED_INT_10_10_10_2_EXT = 0x8036;

        /* EXT_vertex_array */
        public const uint GL_VERTEX_ARRAY_EXT = 0x8074;
        public const uint GL_NORMAL_ARRAY_EXT = 0x8075;
        public const uint GL_COLOR_ARRAY_EXT = 0x8076;
        public const uint GL_INDEX_ARRAY_EXT = 0x8077;
        public const uint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
        public const uint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
        public const uint GL_VERTEX_ARRAY_SIZE_EXT = 0x807A;
        public const uint GL_VERTEX_ARRAY_TYPE_EXT = 0x807B;
        public const uint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807C;
        public const uint GL_VERTEX_ARRAY_COUNT_EXT = 0x807D;
        public const uint GL_NORMAL_ARRAY_TYPE_EXT = 0x807E;
        public const uint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807F;
        public const uint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
        public const uint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
        public const uint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
        public const uint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
        public const uint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
        public const uint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
        public const uint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
        public const uint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808A;
        public const uint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B;
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808C;
        public const uint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D;
        public const uint GL_VERTEX_ARRAY_POINTER_EXT = 0x808E;
        public const uint GL_NORMAL_ARRAY_POINTER_EXT = 0x808F;
        public const uint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
        public const uint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
        public const uint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;

        /* EXT_color_table */
        public const uint GL_TABLE_TOO_LARGE_EXT = 0x8031;
        public const uint GL_COLOR_TABLE_FORMAT_EXT = 0x80D8;
        public const uint GL_COLOR_TABLE_WIDTH_EXT = 0x80D9;
        public const uint GL_COLOR_TABLE_RED_SIZE_EXT = 0x80DA;
        public const uint GL_COLOR_TABLE_GREEN_SIZE_EXT = 0x80DB;
        public const uint GL_COLOR_TABLE_BLUE_SIZE_EXT = 0x80DC;
        public const uint GL_COLOR_TABLE_ALPHA_SIZE_EXT = 0x80DD;
        public const uint GL_COLOR_TABLE_LUMINANCE_SIZE_EXT = 0x80DE;
        public const uint GL_COLOR_TABLE_INTENSITY_SIZE_EXT = 0x80DF;

        /* EXT_bgra */
        public const uint GL_BGR_EXT = 0x80E0;
        public const uint GL_BGRA_EXT = 0x80E1;

        /* EXT_paletted_texture */
        public const uint GL_COLOR_INDEX1_EXT = 0x80E2;
        public const uint GL_COLOR_INDEX2_EXT = 0x80E3;
        public const uint GL_COLOR_INDEX4_EXT = 0x80E4;
        public const uint GL_COLOR_INDEX8_EXT = 0x80E5;
        public const uint GL_COLOR_INDEX12_EXT = 0x80E6;
        public const uint GL_COLOR_INDEX16_EXT = 0x80E7;

        /* SGI_compiled_vertex_array */
        public const uint GL_ARRAY_ELEMENT_LOCK_FIRST_SGI = 0x81A8;
        public const uint GL_ARRAY_ELEMENT_LOCK_COUNT_SGI = 0x81A9;

        /* SGI_cull_vertex */
        public const uint GL_CULL_VERTEX_SGI = 0x81AA;
        public const uint GL_CULL_VERTEX_EYE_POSITION_SGI = 0x81AB;
        public const uint GL_CULL_VERTEX_OBJECT_POSITION_SGI = 0x81AC;

        /* SGI_index_array_formats */
        public const uint GL_IUI_V2F_SGI = 0x81AD;
        public const uint GL_IUI_V3F_SGI = 0x81AE;
        public const uint GL_IUI_N3F_V2F_SGI = 0x81AF;
        public const uint GL_IUI_N3F_V3F_SGI = 0x81B0;
        public const uint GL_T2F_IUI_V2F_SGI = 0x81B1;
        public const uint GL_T2F_IUI_V3F_SGI = 0x81B2;
        public const uint GL_T2F_IUI_N3F_V2F_SGI = 0x81B3;
        public const uint GL_T2F_IUI_N3F_V3F_SGI = 0x81B4;

        /* SGI_index_func */
        public const uint GL_INDEX_TEST_SGI = 0x81B5;
        public const uint GL_INDEX_TEST_FUNC_SGI = 0x81B6;
        public const uint GL_INDEX_TEST_REF_SGI = 0x81B7;

        /* SGI_index_material */
        public const uint GL_INDEX_MATERIAL_SGI = 0x81B8;
        public const uint GL_INDEX_MATERIAL_PARAMETER_SGI = 0x81B9;
        public const uint GL_INDEX_MATERIAL_FACE_SGI = 0x81BA;

        public unsafe static void glGetIntegera(uint pname, int[] someParams)
        {
            fixed (int* pParams = someParams)
            {
                glGetIntegerv(pname, pParams);
            }
        }
        public unsafe static void glGetFloata(uint pname, float[] someParams)
        {
            fixed (float* pParams = someParams)
            {
                glGetFloatv(pname, pParams);
            }
        }
        public unsafe static void glGetDoublea(uint pname, double[] someParams)
        {
            fixed (double* pParams = someParams)
            {
                glGetDoublev(pname, pParams);
            }
        }

        [DllImport("opengl32")]
        public unsafe static extern void glAccum(uint op, float value);
        [DllImport("opengl32")]
        public unsafe static extern void glAlphaFunc(uint func, float aRef);
        [DllImport("opengl32")]
        public unsafe static extern byte glAreTexturesResident(int n, uint* textures, byte* residences);
        [DllImport("opengl32")]
        public unsafe static extern void glArrayElement(int i);
        [DllImport("opengl32")]
        public unsafe static extern void glBegin(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glBindTexture(uint target, uint texture);
        [DllImport("opengl32")]
        public unsafe static extern void glBitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte* bitmap);
        [DllImport("opengl32")]
        public unsafe static extern void glBlendFunc(uint sfactor, uint dfactor);
        [DllImport("opengl32")]
        public unsafe static extern void glCallList(uint list);
        [DllImport("opengl32")]
        public unsafe static extern void glCallLists(int n, uint type, void* lists);
        [DllImport("opengl32")]
        public unsafe static extern void glClear(uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glClearAccum(float red, float green, float blue, float alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glClearColor(float red, float green, float blue, float alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glClearDepth(double depth);
        [DllImport("opengl32")]
        public unsafe static extern void glClearIndex(float c);
        [DllImport("opengl32")]
        public unsafe static extern void glClearStencil(int s);
        [DllImport("opengl32")]
        public unsafe static extern void glClipPlane(uint plane, double* equation);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3b(sbyte red, sbyte green, sbyte blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3bv(sbyte* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3d(double red, double green, double blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3f(float red, float green, float blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3i(int red, int green, int blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3s(short red, short green, short blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3ub(byte red, byte green, byte blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3ubv(byte* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3ui(uint red, uint green, uint blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3uiv(uint* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3us(ushort red, ushort green, ushort blue);
        [DllImport("opengl32")]
        public unsafe static extern void glColor3usv(ushort* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4b(sbyte red, sbyte green, sbyte blue, sbyte alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4bv(sbyte* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4d(double red, double green, double blue, double alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4f(float red, float green, float blue, float alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4i(int red, int green, int blue, int alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4s(short red, short green, short blue, short alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4ubv(byte* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4uiv(uint* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColor4usv(ushort* v);
        [DllImport("opengl32")]
        public unsafe static extern void glColorMask(byte red, byte green, byte blue, byte alpha);
        [DllImport("opengl32")]
        public unsafe static extern void glColorMaterial(uint face, uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glColorPointer(int size, uint type, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glCopyPixels(int x, int y, int width, int height, uint type);
        [DllImport("opengl32")]
        public unsafe static extern void glCopyTexImage1D(uint target, int level, uint internalformat, int x, int y, int width, int border);
        [DllImport("opengl32")]
        public unsafe static extern void glCopyTexImage2D(uint target, int level, uint internalformat, int x, int y, int width, int height, int border);
        [DllImport("opengl32")]
        public unsafe static extern void glCopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width);
        [DllImport("opengl32")]
        public unsafe static extern void glCopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        [DllImport("opengl32")]
        public unsafe static extern void glCullFace(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glDeleteLists(uint list, int range);
        [DllImport("opengl32")]
        public unsafe static extern void glDeleteTextures(int n, uint* textures);
        [DllImport("opengl32")]
        public unsafe static extern void glDepthFunc(uint func);
        [DllImport("opengl32")]
        public unsafe static extern void glDepthMask(byte flag);
        [DllImport("opengl32")]
        public unsafe static extern void glDepthRange(double zNear, double zFar);
        [DllImport("opengl32")]
        public unsafe static extern void glDisable(uint cap);
        [DllImport("opengl32")]
        public unsafe static extern void glDisableClientState(uint array);
        [DllImport("opengl32")]
        public unsafe static extern void glDrawArrays(uint mode, int first, int count);
        [DllImport("opengl32")]
        public unsafe static extern void glDrawBuffer(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glDrawElements(uint mode, int count, uint type, void* indices);
        [DllImport("opengl32")]
        public unsafe static extern void glDrawPixels(int width, int height, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glEdgeFlag(byte flag);
        [DllImport("opengl32")]
        public unsafe static extern void glEdgeFlagPointer(int stride, byte* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glEdgeFlagv(byte* flag);
        [DllImport("opengl32")]
        public unsafe static extern void glEnable(uint cap);
        [DllImport("opengl32")]
        public unsafe static extern void glEnableClientState(uint array);
        [DllImport("opengl32")]
        public unsafe static extern void glEnd();
        [DllImport("opengl32")]
        public unsafe static extern void glEndList();
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord1d(double u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord1dv(double* u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord1f(float u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord1fv(float* u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord2d(double u, double v);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord2dv(double* u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord2f(float u, float v);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalCoord2fv(float* u);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalMesh1(uint mode, int i1, int i2);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalMesh2(uint mode, int i1, int i2, int j1, int j2);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalPoint1(int i);
        [DllImport("opengl32")]
        public unsafe static extern void glEvalPoint2(int i, int j);
        [DllImport("opengl32")]
        public unsafe static extern void glFeedbackBuffer(int size, uint type, float* buffer);
        [DllImport("opengl32")]
        public unsafe static extern void glFinish();
        [DllImport("opengl32")]
        public unsafe static extern void glFlush();
        [DllImport("opengl32")]
        public unsafe static extern void glFogf(uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glFogfv(uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glFogi(uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glFogiv(uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glFrontFace(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glFrustum(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport("opengl32")]
        public unsafe static extern uint glGenLists(int range);
        [DllImport("opengl32")]
        public unsafe static extern void glGenTextures(int n, uint* textures);
        [DllImport("opengl32")]
        public unsafe static extern void glGetBooleanv(uint pname, byte* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetClipPlane(uint plane, double* equation);
        [DllImport("opengl32")]
        public unsafe static extern void glGetDoublev(uint pname, double* someParams);
        [DllImport("opengl32")]
        public unsafe static extern uint glGetError();
        [DllImport("opengl32")]
        public unsafe static extern void glGetFloatv(uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetIntegerv(uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetLightfv(uint light, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetLightiv(uint light, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetMapdv(uint target, uint query, double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glGetMapfv(uint target, uint query, float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glGetMapiv(uint target, uint query, int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glGetMaterialfv(uint face, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetMaterialiv(uint face, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetPixelMapfv(uint map, float* values);
        [DllImport("opengl32")]
        public unsafe static extern void glGetPixelMapuiv(uint map, uint* values);
        [DllImport("opengl32")]
        public unsafe static extern void glGetPixelMapusv(uint map, ushort* values);
        [DllImport("opengl32")]
        public unsafe static extern void glGetPointerv(uint pname, void** someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetPolygonStipple(byte* mask);
        [DllImport("opengl32")]
        public unsafe static extern byte* glGetString(uint name);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexEnvfv(uint target, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexEnviv(uint target, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexGendv(uint coord, uint pname, double* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexGenfv(uint coord, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexGeniv(uint coord, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexImage(uint target, int level, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexLevelParameterfv(uint target, int level, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexLevelParameteriv(uint target, int level, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexParameterfv(uint target, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glGetTexParameteriv(uint target, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glHint(uint target, uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexMask(uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexPointer(uint type, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexd(double c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexdv(double* c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexf(float c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexfv(float* c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexi(int c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexiv(int* c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexs(short c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexsv(short* c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexub(byte c);
        [DllImport("opengl32")]
        public unsafe static extern void glIndexubv(byte* c);
        [DllImport("opengl32")]
        public unsafe static extern void glInitNames();
        [DllImport("opengl32")]
        public unsafe static extern void glInterleavedArrays(uint format, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern byte glIsEnabled(uint cap);
        [DllImport("opengl32")]
        public unsafe static extern byte glIsList(uint list);
        [DllImport("opengl32")]
        public unsafe static extern byte glIsTexture(uint texture);
        [DllImport("opengl32")]
        public unsafe static extern void glLightModelf(uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glLightModelfv(uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glLightModeli(uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glLightModeliv(uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glLightf(uint light, uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glLightfv(uint light, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glLighti(uint light, uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glLightiv(uint light, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glLineStipple(int factor, ushort pattern);
        [DllImport("opengl32")]
        public unsafe static extern void glLineWidth(float width);
        [DllImport("opengl32")]
        public unsafe static extern void glListBase(uint aBase);
        [DllImport("opengl32")]
        public unsafe static extern void glLoadIdentity();
        [DllImport("opengl32")]
        public unsafe static extern void glLoadMatrixd(double* m);
        [DllImport("opengl32")]
        public unsafe static extern void glLoadMatrixf(float* m);
        [DllImport("opengl32")]
        public unsafe static extern void glLoadName(uint name);
        [DllImport("opengl32")]
        public unsafe static extern void glLogicOp(uint opcode);
        [DllImport("opengl32")]
        public unsafe static extern void glMap1d(uint target, double u1, double u2, int stride, int order, double* points);
        [DllImport("opengl32")]
        public unsafe static extern void glMap1f(uint target, float u1, float u2, int stride, int order, float* points);
        [DllImport("opengl32")]
        public unsafe static extern void glMap2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double* points);
        [DllImport("opengl32")]
        public unsafe static extern void glMap2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float* points);
        [DllImport("opengl32")]
        public unsafe static extern void glMapGrid1d(int un, double u1, double u2);
        [DllImport("opengl32")]
        public unsafe static extern void glMapGrid1f(int un, float u1, float u2);
        [DllImport("opengl32")]
        public unsafe static extern void glMapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);
        [DllImport("opengl32")]
        public unsafe static extern void glMapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);
        [DllImport("opengl32")]
        public unsafe static extern void glMaterialf(uint face, uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glMaterialfv(uint face, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glMateriali(uint face, uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glMaterialiv(uint face, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glMatrixMode(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glMultMatrixd(double* m);
        [DllImport("opengl32")]
        public unsafe static extern void glMultMatrixf(float* m);
        [DllImport("opengl32")]
        public unsafe static extern void glNewList(uint list, uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3b(sbyte nx, sbyte ny, sbyte nz);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3bv(sbyte* v);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3d(double nx, double ny, double nz);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3f(float nx, float ny, float nz);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3i(int nx, int ny, int nz);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3s(short nx, short ny, short nz);
        [DllImport("opengl32")]
        public unsafe static extern void glNormal3sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glNormalPointer(uint type, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport("opengl32")]
        public unsafe static extern void glPassThrough(float token);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelMapfv(uint map, int mapsize, float* values);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelMapuiv(uint map, int mapsize, uint* values);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelMapusv(uint map, int mapsize, ushort* values);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelStoaRef(uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelStorei(uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelTransferf(uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelTransferi(uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glPixelZoom(float xfactor, float yfactor);
        [DllImport("opengl32")]
        public unsafe static extern void glPointSize(float size);
        [DllImport("opengl32")]
        public unsafe static extern void glPolygonMode(uint face, uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glPolygonOffset(float factor, float units);
        [DllImport("opengl32")]
        public unsafe static extern void glPolygonStipple(byte* mask);
        [DllImport("opengl32")]
        public unsafe static extern void glPopAttrib();
        [DllImport("opengl32")]
        public unsafe static extern void glPopClientAttrib();
        [DllImport("opengl32")]
        public unsafe static extern void glPopMatrix();
        [DllImport("opengl32")]
        public unsafe static extern void glPopName();
        [DllImport("opengl32")]
        public unsafe static extern void glPrioritizeTextures(int n, uint* textures, float* priorities);
        [DllImport("opengl32")]
        public unsafe static extern void glPushAttrib(uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glPushClientAttrib(uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glPushMatrix();
        [DllImport("opengl32")]
        public unsafe static extern void glPushName(uint name);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2d(double x, double y);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2f(float x, float y);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2i(int x, int y);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2s(short x, short y);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos2sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3d(double x, double y, double z);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3f(float x, float y, float z);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3i(int x, int y, int z);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3s(short x, short y, short z);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos3sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4d(double x, double y, double z, double w);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4f(float x, float y, float z, float w);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4i(int x, int y, int z, int w);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4s(short x, short y, short z, short w);
        [DllImport("opengl32")]
        public unsafe static extern void glRasterPos4sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glReadBuffer(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glRectd(double x1, double y1, double x2, double y2);
        [DllImport("opengl32")]
        public unsafe static extern void glRectdv(double* v1, double* v2);
        [DllImport("opengl32")]
        public unsafe static extern void glRectf(float x1, float y1, float x2, float y2);
        [DllImport("opengl32")]
        public unsafe static extern void glRectfv(float* v1, float* v2);
        [DllImport("opengl32")]
        public unsafe static extern void glRecti(int x1, int y1, int x2, int y2);
        [DllImport("opengl32")]
        public unsafe static extern void glRectiv(int* v1, int* v2);
        [DllImport("opengl32")]
        public unsafe static extern void glRects(short x1, short y1, short x2, short y2);
        [DllImport("opengl32")]
        public unsafe static extern void glRectsv(short* v1, short* v2);
        [DllImport("opengl32")]
        public unsafe static extern int glRenderMode(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glRotated(double angle, double x, double y, double z);
        [DllImport("opengl32")]
        public unsafe static extern void glRotatef(float angle, float x, float y, float z);
        [DllImport("opengl32")]
        public unsafe static extern void glScaled(double x, double y, double z);
        [DllImport("opengl32")]
        public unsafe static extern void glScalef(float x, float y, float z);
        [DllImport("opengl32")]
        public unsafe static extern void glScissor(int x, int y, int width, int height);
        [DllImport("opengl32")]
        public unsafe static extern void glSelectBuffer(int size, uint* buffer);
        [DllImport("opengl32")]
        public unsafe static extern void glShadeModel(uint mode);
        [DllImport("opengl32")]
        public unsafe static extern void glStencilFunc(uint func, int aRef, uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glStencilMask(uint mask);
        [DllImport("opengl32")]
        public unsafe static extern void glStencilOp(uint fail, uint zfail, uint zpass);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1d(double s);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1f(float s);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1i(int s);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1s(short s);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord1sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2d(double s, double t);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2f(float s, float t);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2i(int s, int t);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2s(short s, short t);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord2sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3d(double s, double t, double r);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3f(float s, float t, float r);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3i(int s, int t, int r);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3s(short s, short t, short r);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord3sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4d(double s, double t, double r, double q);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4f(float s, float t, float r, float q);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4i(int s, int t, int r, int q);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4s(short s, short t, short r, short q);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoord4sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glTexCoordPointer(int size, uint type, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glTexEnvf(uint target, uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexEnvfv(uint target, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexEnvi(uint target, uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexEnviv(uint target, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGend(uint coord, uint pname, double param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGendv(uint coord, uint pname, double* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGenf(uint coord, uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGenfv(uint coord, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGeni(uint coord, uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexGeniv(uint coord, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexImage1D(uint target, int level, int components, int width, int border, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glTexImage2D(uint target, int level, int components, int width, int height, int border, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glTexParameterf(uint target, uint pname, float param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexParameterfv(uint target, uint pname, float* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexParameteri(uint target, uint pname, int param);
        [DllImport("opengl32")]
        public unsafe static extern void glTexParameteriv(uint target, uint pname, int* someParams);
        [DllImport("opengl32")]
        public unsafe static extern void glTexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels);
        [DllImport("opengl32")]
        public unsafe static extern void glTranslated(double x, double y, double z);
        [DllImport("opengl32")]
        public unsafe static extern void glTranslatef(float x, float y, float z);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2d(double x, double y);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2f(float x, float y);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2i(int x, int y);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2s(short x, short y);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex2sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3d(double x, double y, double z);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3f(float x, float y, float z);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3i(int x, int y, int z);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3s(short x, short y, short z);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex3sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4d(double x, double y, double z, double w);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4dv(double* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4f(float x, float y, float z, float w);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4fv(float* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4i(int x, int y, int z, int w);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4iv(int* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4s(short x, short y, short z, short w);
        [DllImport("opengl32")]
        public unsafe static extern void glVertex4sv(short* v);
        [DllImport("opengl32")]
        public unsafe static extern void glVertexPointer(int size, uint type, int stride, void* pointer);
        [DllImport("opengl32")]
        public unsafe static extern void glViewport(int x, int y, int width, int height);

        // Hand added function
        [DllImport("opengl32")]
        public static extern void glTexImage2D(uint target, int level, int components, int width, int height, int border, uint format, uint type, IntPtr pixels);
        [DllImport("opengl32")]
        public static extern void glGenTextures(int n, uint[] textures);
        [DllImport("opengl32")]
        public static extern void glDeleteTextures(int n, uint[] textures);
        [DllImport("opengl32")]
        public static extern void glTexParameteri(uint target, uint pname, uint param);
        [DllImport("opengl32")]
        public static extern void glNormal3bv(sbyte[] v);
        [DllImport("opengl32")]
        public static extern void glNormal3dv(double[] v);
        [DllImport("opengl32")]
        public static extern void glNormal3fv(float[] v);
        [DllImport("opengl32")]
        public static extern void glNormal3iv(int[] v);
        [DllImport("opengl32")]
        public static extern void glNormal3sv(short[] v);
        [DllImport("opengl32")]
        public static extern void glVertex2dv(double[] v);
        [DllImport("opengl32")]
        public static extern void glVertex2fv(float[] v);
        [DllImport("opengl32")]
        public static extern void glVertex2iv(int[] v);
        [DllImport("opengl32")]
        public static extern void glVertex2sv(short[] v);
        [DllImport("opengl32")]
        public static extern void glVertex3dv(double[] v);
        [DllImport("opengl32")]
        public static extern void glVertex3fv(float[] v);
        [DllImport("opengl32")]
        public static extern void glVertex3iv(int[] v);
        [DllImport("opengl32")]
        public static extern void glVertex3sv(short[] v);
        [DllImport("opengl32")]
        public static extern void glVertex4dv(double[] v);
        [DllImport("opengl32")]
        public static extern void glVertex4fv(float[] v);
        [DllImport("opengl32")]
        public static extern void glVertex4iv(int[] v);
        [DllImport("opengl32")]
        public static extern void glVertex4sv(short[] v);
        [DllImport("opengl32")]
        public static extern void glLightModelfv(uint pname, float[] someParams);
        [DllImport("opengl32")]
        public static extern void glLightModeliv(uint pname, int[] someParams);
        [DllImport("opengl32")]
        public static extern void glLightfv(uint light, uint pname, float[] someParams);
        [DllImport("opengl32")]
        public static extern void glLightiv(uint light, uint pname, int[] someParams);
        [DllImport("opengl32")]
        public static extern void glMultMatrixd(double[] m);
        [DllImport("opengl32")]
        public static extern void glMultMatrixf(float[] m);
        [DllImport("opengl32")]
        public static extern void glGetBooleanv(uint pname, byte[] someParams);
        [DllImport("opengl32")]
        public static extern void glGetDoublev(uint pname, double[] someParams);
        [DllImport("opengl32")]
        public static extern void glGetFloatv(uint pname, float[] someParams);
        [DllImport("opengl32")]
        public static extern void glGetIntegerv(uint pname, int[] someParams);
        [DllImport("opengl32")]
        public static extern void glLoadMatrixd(double[] m);
        [DllImport("opengl32")]
        public static extern void glLoadMatrixf(float[] m);



        //The glAlphaFunc function enables your application to set the alpha test function.
        static public void glAlphaFunc(GLAlphaFunc alphaFunc, float clamp)
        {
            OpenGL.glAlphaFunc((uint)alphaFunc, clamp);
        }
        static public void glBegin(GLPrimative primative)
        {
            OpenGL.glBegin((uint)primative);
        }
        static public void glBlendFunc(GLBlendSrc src, GLBlendDest dest)
        {
            OpenGL.glBlendFunc((uint)src, (uint)dest);
        }

        static public void glPolygonMode(GLPolygonFaces faces, GLPolygonMode mode)
        {
            OpenGL.glPolygonMode((uint)faces, (uint)mode);
        }

        static public void glBindTexture(GLTexture texture, uint hTexture)
        {
            OpenGL.glBindTexture((uint)texture, hTexture);
        }
        static public void glClear(GLBuffers buffers)
        {
            OpenGL.glClear((uint)buffers);
        }
        static public void glClearColor(Color color)
        {
            float ratio = 1.0f / 255;
            OpenGL.glClearColor(color.R * ratio, color.G * ratio, color.B * ratio, color.A * ratio);
        }
        static public void glColor3(Color color)
        {
            OpenGL.glColor3ub(color.R, color.G, color.B);
        }
        static public void glColor4(Color color)
        {
            OpenGL.glColor4ub(color.R, color.G, color.B, color.A);
        }
        static public void glCullFace(GLPolygonFaces polygonFaces)
        {
            OpenGL.glCullFace((uint)polygonFaces);
        }
        static public void glDrawArrays(GLPrimative primative, int first, int count)
        {
            OpenGL.glDrawArrays((uint)primative, first, count);
        }
        static public void glDrawBuffer(GLPrimative primative)
        {
            OpenGL.glDrawBuffer((uint)primative);
        }
        static unsafe public void glDrawElements(GLPrimative primative, int count, GLUnsignedDataType type, byte[] indices)
        {
            fixed (byte* pIndices = &(indices[0]))
            {
                OpenGL.glDrawElements(primative, count, type, pIndices);
            }
        }
        static unsafe public void glDrawElements(GLPrimative primative, int count, GLUnsignedDataType type, short[] indices)
        {
            fixed (short* pIndices = &(indices[0]))
            {
                OpenGL.glDrawElements(primative, count, type, pIndices);
            }
        }
        static unsafe public void glDrawElements(GLPrimative primative, int count, GLUnsignedDataType type, int[] indices)
        {
            fixed (int* pIndices = &(indices[0]))
            {
                OpenGL.glDrawElements(primative, count, type, pIndices);
            }
        }
        static unsafe public void glDrawElements(GLPrimative primative, int count, GLUnsignedDataType type, void* indices)
        {
            OpenGL.glDrawElements((uint)primative, count, (uint)type, indices);
        }
        static public void glDepthFunc(GLDepthFunc depthFunction)
        {
            OpenGL.glDepthFunc((uint)depthFunction);
        }
        static public void glDisable(GLOption option)
        {
            OpenGL.glDisable((uint)option);
        }
        static public void glEnable(GLOption option)
        {
            OpenGL.glEnable((uint)option);
        }
        static public void glEnable(GLOption option, bool enable)
        {
            if (enable)
            {
                OpenGL.glEnable((uint)option);
            }
            else
            {
                OpenGL.glDisable((uint)option);
            }
        }
        static public void glHint(GLHint hint, GLQuality quality)
        {
            OpenGL.glHint((uint)hint, (uint)quality);
        }
        //static public void glLoadMatrix( Transform3D xfrm ) {
        //	OpenGL.glLoadMatrixf( (float[]) xfrm );
        //}
        //static public void glMultMatrix( Transform3D xfrm ) {
        //	OpenGL.glMultMatrixf( (float[]) xfrm );
        //}
        static public void glMatrixMode(GLMatrixMode matrixmode)
        {
            OpenGL.glMatrixMode((uint)matrixmode);
        }
        static public void glPixelStorei(GLPixelStore pixelStore, int param)
        {
            OpenGL.glPixelStorei((uint)pixelStore, param);
        }
        static public void glShadeModel(GLShadeModel shademodel)
        {
            OpenGL.glShadeModel((uint)shademodel);
        }
        static public void glTexCoord2(float s, float t)
        {
            OpenGL.glTexCoord2f(s, t);
        }
        static public void glTexEnvi(GLTexEnvTarget target, GLTexEnvPName paramName, GLTexEnvParam param)
        {
            OpenGL.glTexEnvi((uint)target, (uint)paramName, (int)param);
        }
        static public void glTexImage2D(GLTexture texture,
            int iMipmapLevel, GLInternalFormat internalFormat, int iWidth, int iHeight,
            int iBorder, GLPixelFormat pixelFormat, GLDataType dataType, IntPtr data)
        {
            OpenGL.glTexImage2D((uint)texture, iMipmapLevel, (int)internalFormat, iWidth, iHeight,
                iBorder, (uint)pixelFormat, (uint)dataType, data);
        }
        static unsafe public void glTexImage2D(GLTexture texture,
            int iMipmapLevel, GLInternalFormat internalFormat, int iWidth, int iHeight,
            int iBorder, GLPixelFormat pixelFormat, GLDataType dataType, void* data)
        {
            OpenGL.glTexImage2D((uint)texture, iMipmapLevel, (int)internalFormat, iWidth, iHeight,
                iBorder, (uint)pixelFormat, (uint)dataType, data);
        }
        static public void glTexParameteri(GLTexture texture, GLTexParamPName paramName, GLTextureFilter filter)
        {
            OpenGL.glTexParameteri((uint)texture, (uint)paramName, (int)filter);
        }
        static public void glVertex3(float x, float y, float z)
        {
            OpenGL.glVertex3f(x, y, z);
        }

        static public float glGetFloat(uint pname)
        {
            float[] f = new float[1];
            OpenGL.glGetFloatv(pname, f);
            return f[0];
        }
        static public int glGetInteger(uint pname)
        {
            int[] i = new int[1];
            OpenGL.glGetIntegerv(pname, i);
            return i[0];
        }
        static public double glGetDouble(uint pname)
        {
            double[] d = new double[1];
            OpenGL.glGetDoublev(pname, d);
            return d[0];
        }

        public static unsafe string glGetString(GLStringName name)
        {
            return Marshal.PtrToStringAnsi(new IntPtr(glGetString((uint)name)));
        }

        static public bool EnableExceptions = true;

        //[Conditional("DEBUG")]
        static public void glErrorCheck()
        {
            uint error = OpenGL.GL_NO_ERROR;
            int errorCount = 0;
            string firstDescription = null;
            while (
                (errorCount < 10) &&
                ((error = OpenGL.glGetError()) != OpenGL.GL_NO_ERROR))
            {
                string description = OpenGL.glGetErrorString(error);
                Debug.WriteLine("OpenGL Error: " + description);

                if (firstDescription == null)
                {
                    firstDescription = description;
                }

                errorCount++;
            }
            if ((errorCount > 0) &&
                (OpenGL.EnableExceptions == true))
            {
                Debug.Assert(firstDescription != null);
                throw new OpenGLException(firstDescription + "(1 of " + errorCount + ")");
            }
        }

        static public string glGetErrorString(uint error)
        {
            switch (error)
            {
                case OpenGL.GL_NO_ERROR:
                    return "GL_NO_ERROR: No error has been recorded. The value of this " +
                        "symbolic constant is guaranteed to be zero.";
                case OpenGL.GL_INVALID_ENUM:
                    return "GL_INVALID_ENUM: An unacceptable value is specified for an " +
                        "enumerated argument. The offending function is ignored, having no " +
                        "side effect other than to set the error flag.";
                case OpenGL.GL_INVALID_VALUE:
                    return "GL_INVALID_VALUE: A numeric argument is out of range. The " +
                        "offending function is ignored, having no side effect other than to " +
                        "set the error flag.";
                case OpenGL.GL_INVALID_OPERATION:
                    return "GL_INVALID_OPERATION: The specified operation is not allowed in " +
                        "the current state. The offending function is ignored, having no side " +
                        "effect other than to set the error flag.";
                case OpenGL.GL_STACK_OVERFLOW:
                    return "GL_STACK_OVERFLOW: This function would cause a stack overflow. " +
                        "The offending function is ignored, having no side effect other than " +
                        "to set the error flag.";
                case OpenGL.GL_STACK_UNDERFLOW:
                    return "GL_STACK_UNDERFLOW: This function would cause a stack underflow. " +
                        "The offending function is ignored, having no side effect other than " +
                        "to set the error flag. ";
                case OpenGL.GL_OUT_OF_MEMORY:
                    return "GL_OUT_OF_MEMORY: There is not enough memory left to execute the " +
                        "function. The state of OpenGL is undefined, except for the state of " +
                        "the error flags, after this error is recorded.";
                default:
                    return "Unknown error code (" + error + ")";
            }
        }


        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct WGLSWAP
        {
            public int hdc;
            public int uiFlags;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct POINTFLOAT
        {
            public float x;
            public float y;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct GLYPHMETRICSFLOAT
        {
            public float gmfBlackBoxX;
            public float gmfBlackBoxY;
            public POINTFLOAT gmfptGlyphOrigin;
            public float gmfCellIncX;
            public float gmfCellIncY;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct LAYERPLANEDESCRIPTOR
        {
            public short nSize;
            public short nVersion;
            public int dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerPlane;
            public byte bReserved;
            public int colorrefTransparent;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PIXELFORMATDESCRIPTOR
        {
            public short nSize;
            public short nVersion;
            public int dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public int dwLayerMask;
            public int dwVisibleMask;
            public int dwDamageMask;
        }

        public const int PFD_TYPE_RGBA = 0;
        public const int PFD_TYPE_COLORINDEX = 1;
        public const int PFD_MAIN_PLANE = 0;
        public const int PFD_OVERLAY_PLANE = 1;
        public const int PFD_UNDERLAY_PLANE = 0xff;
        public const int PFD_DOUBLEBUFFER = 0x00000001;
        public const int PFD_STEREO = 0x00000002;
        public const int PFD_DRAW_TO_WINDOW = 0x00000004;
        public const int PFD_DRAW_TO_BITMAP = 0x00000008;
        public const int PFD_SUPPORT_GDI = 0x00000010;
        public const int PFD_SUPPORT_OPENGL = 0x00000020;
        public const int PFD_GENERIC_FORMAT = 0x00000040;
        public const int PFD_NEED_PALETTE = 0x00000080;
        public const int PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        public const int PFD_SWAP_EXCHANGE = 0x00000200;
        public const int PFD_SWAP_COPY = 0x00000400;
        public const int PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        public const int PFD_GENERIC_ACCELERATED = 0x00001000;
        public const int PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        public const int PFD_DEPTH_DONTCARE = 0x20000000;
        public const int PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        public const int PFD_STEREO_DONTCARE = unchecked((int)0x80000000);

        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "GetDC", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "ReleaseDC", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [System.Runtime.InteropServices.DllImport("opengl32", EntryPoint = "wglGetProcAddress", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetProcAddress([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] String functionName);

        [System.Runtime.InteropServices.DllImport("opengl32", EntryPoint = "wglCreateContext", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        [System.Runtime.InteropServices.DllImport("opengl32", EntryPoint = "wglDeleteContext", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern int wglDeleteContext(IntPtr hglrc);

        [System.Runtime.InteropServices.DllImport("opengl32", EntryPoint = "wglMakeCurrent", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        [System.Runtime.InteropServices.DllImport("opengl32", EntryPoint = "wglSwapBuffers", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern int wglSwapBuffers(IntPtr hdc);

        [System.Runtime.InteropServices.DllImport("gdi32", EntryPoint = "ChoosePixelFormat", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref PIXELFORMATDESCRIPTOR pfd);

        [System.Runtime.InteropServices.DllImport("gdi32", EntryPoint = "SetPixelFormat", SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
        public static extern int SetPixelFormat(IntPtr hdc, int pixelFormat, ref PIXELFORMATDESCRIPTOR pfd);
    }
}
