using SharpGL;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBOTest
{
    public partial class Form1 : Form
    {
        private OpenGL GL { get { return openGLControl1.OpenGL; } }
        private ShaderProgram shader1;
        private ShaderProgram shader2;
        private ShaderProgram shader3;
        private VertexBufferArray vertexBufferArray;
        private const uint attributeIndexPosition = 0;
        uint frameBufferID;
        uint colourRenderBufferID;
        uint depthRenderBufferID;

        uint colourFrameTextureID1;
        uint colourFrameTextureID2;

        public Form1()
        {
            InitializeComponent();
        }

        private ShaderProgram CreateShader(string vertex, string fragment)
        {
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(GL, vertex, fragment, null);
            shaderProgram.BindAttributeLocation(GL, attributeIndexPosition, "in_position");
            shaderProgram.AssertValid(GL);
            return shaderProgram;
        }

        private void CreateVerticesForSquare()
        {
            var vertices = new float[18];
            vertices[0] = -0.5f; vertices[1] = -0.5f; vertices[2] = 0.0f; // Bottom left corner  
            vertices[3] = -0.5f; vertices[4] = 0.5f; vertices[5] = 0.0f; // Top left corner  
            vertices[6] = 0.5f; vertices[7] = 0.5f; vertices[8] = 0.0f; // Top Right corner  
            vertices[9] = 0.5f; vertices[10] = -0.5f; vertices[11] = 0.0f; // Bottom right corner  
            vertices[12] = -0.5f; vertices[13] = -0.5f; vertices[14] = 0.0f; // Bottom left corner  
            vertices[15] = 0.5f; vertices[16] = 0.5f; vertices[17] = 0.0f; // Top Right corner  

            //  Create the vertex array object.
            vertexBufferArray = new VertexBufferArray();
            vertexBufferArray.Create(GL);
            vertexBufferArray.Bind(GL);

            //  Create a vertex buffer for the vertex data.
            var vertexDataBuffer = new VertexBuffer();
            vertexDataBuffer.Create(GL);
            vertexDataBuffer.Bind(GL);
            vertexDataBuffer.SetData(GL, 0, vertices, false, 3);

            //  Unbind the vertex array, we've finished specifying data for it.
            vertexBufferArray.Unbind(GL);
        }

        
        private void CreateRenderBuffer() {
            uint[] ids = new uint[1];

            //  First, create the frame buffer and bind it.
            ids = new uint[1];
            GL.GenFramebuffersEXT(1, ids);
            frameBufferID = ids[0];
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, frameBufferID);

            //	Create the colour render buffer and bind it, then allocate storage for it.
            GL.GenRenderbuffersEXT(1, ids);
            colourRenderBufferID = ids[0];
            GL.BindRenderbufferEXT(OpenGL.GL_RENDERBUFFER_EXT, colourRenderBufferID);
            GL.RenderbufferStorageEXT(OpenGL.GL_RENDERBUFFER_EXT, OpenGL.GL_RGBA, openGLControl1.Width, openGLControl1.Height);

            //	Create the depth render buffer and bind it, then allocate storage for it.
            //GL.GenRenderbuffersEXT(1, ids);
            //depthRenderBufferID = ids[0];
            //GL.BindRenderbufferEXT(OpenGL.GL_RENDERBUFFER_EXT, depthRenderBufferID);
            //GL.RenderbufferStorageEXT(OpenGL.GL_RENDERBUFFER_EXT, OpenGL.GL_DEPTH_COMPONENT24, openGLControl1.Width, openGLControl1.Height);

            //  Set the render buffer for colour and depth.
            GL.FramebufferRenderbufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT0_EXT,
                OpenGL.GL_RENDERBUFFER_EXT, colourRenderBufferID);
            //GL.FramebufferRenderbufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_DEPTH_ATTACHMENT_EXT,
             //   OpenGL.GL_RENDERBUFFER_EXT, depthRenderBufferID);
        }


        private void CreateFramebufferTexture() {
            uint[] ids = new uint[1];

            GL.GenFramebuffersEXT(1, ids);
            frameBufferID = ids[0];
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, frameBufferID);

            ids = new uint[2];
            GL.GenTextures(2, ids);
            colourFrameTextureID1 = ids[0];
            colourFrameTextureID2 = ids[1];

            GL.BindTexture(OpenGL.GL_TEXTURE_2D, colourFrameTextureID1);
            GL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGB, openGLControl1.Width, openGLControl1.Height, 0, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            GL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);

            GL.BindTexture(OpenGL.GL_TEXTURE_2D, colourFrameTextureID2);
            GL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGB, openGLControl1.Width, openGLControl1.Height, 0, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            GL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);

            GL.FramebufferTexture2DEXT(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT0_EXT, OpenGL.GL_TEXTURE_2D, colourFrameTextureID1, 0);
            GL.FramebufferTexture2DEXT(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT1_EXT, OpenGL.GL_TEXTURE_2D, colourFrameTextureID2, 0);
        }

        private void OpenGL_OnInited(object sender, EventArgs e)
        {
            CreateVerticesForSquare();
            var vertex = ManifestResourceLoader.LoadTextFile("Shader.vert");
            var fragment = ManifestResourceLoader.LoadTextFile("Shader1.frag");
            shader1 = CreateShader(vertex, fragment);
             vertex = ManifestResourceLoader.LoadTextFile("Shader.vert");
             fragment = ManifestResourceLoader.LoadTextFile("Shader2.frag");
            shader2 = CreateShader(vertex, fragment);
            vertex = ManifestResourceLoader.LoadTextFile("Shader.vert");
            fragment = ManifestResourceLoader.LoadTextFile("Shader3.frag");
            shader3 = CreateShader(vertex, fragment);
            //CreateRenderBuffer();
            CreateFramebufferTexture();

            openGLControl1.DoRender();
        }

        private void OpenGL_OnDraw(object sender, SharpGL.RenderEventArgs args)
        {
            RenderBody();
        }

        private void RenderBody()
        {
            GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            vertexBufferArray.Bind(GL);

            //pass1
            shader1.Bind(GL);
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, frameBufferID);
            GL.DrawBuffersARB(1, new uint[] { OpenGL.GL_COLOR_ATTACHMENT0_EXT });

            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            GL.ReadBuffer(OpenGL.GL_COLOR_ATTACHMENT0_EXT);
            byte[] pixels = new byte[openGLControl1.Width * openGLControl1.Height * 3];
            GL.ReadPixels(0, 0, openGLControl1.Width, openGLControl1.Height, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, pixels);
            shader1.Unbind(GL);

            //pass2
            shader2.Bind(GL);
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, frameBufferID);
            GL.DrawBuffersARB(1, new uint[] { OpenGL.GL_COLOR_ATTACHMENT1_EXT });

            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            GL.ReadBuffer(OpenGL.GL_COLOR_ATTACHMENT1_EXT);
            pixels = new byte[openGLControl1.Width * openGLControl1.Height * 3];
            GL.ReadPixels(0, 0, openGLControl1.Width, openGLControl1.Height, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, pixels);
            shader2.Unbind(GL);

            //pass3
            shader3.Bind(GL);
            
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            GL.ActiveTexture(OpenGL.GL_TEXTURE0);
            GL.BindTexture(OpenGL.GL_TEXTURE_2D, colourFrameTextureID1);
            GL.ActiveTexture(OpenGL.GL_TEXTURE1);
            GL.BindTexture(OpenGL.GL_TEXTURE_2D, colourFrameTextureID2);
            GL.Uniform1(shader3.GetUniformLocation(GL, "iChannel0"), 1);

            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            shader3.Unbind(GL);

            vertexBufferArray.Unbind(GL);
            
        }
    }
}
