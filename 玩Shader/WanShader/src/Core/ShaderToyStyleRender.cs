using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace bluebean.ShaderToyOffline
{
    class ShaderToyStyleRender
    {
        private OpenGL GL { get { return m_openGL; } } 
        public bool HasError { get { return m_hasError; } }
        public Exception Exception { get { return m_exception; } }

        private bool m_hasError = false;
        private Exception m_exception;

        private int m_width;
        private int m_height;
        private float m_iTime;
        private float m_iTimeDelta;
        private Vec2 m_iResolution;
        private Vec3 m_iMouse;

        private ShaderData m_shaderData;
        private const uint AttributeIndexPosition = 0;
        private SharpGL.OpenGL m_openGL;

        /// <summary>
        /// 着色器
        /// </summary>
        private ShaderProgram[] m_shaderPrograms;
        private ShaderProgram m_errorShader;
        /// <summary>
        /// fbo 离屏渲染对象
        /// </summary>
        private uint m_frameBufferID;
        /// <summary>
        /// buffer纹理数组
        /// </summary>
        private uint[] m_frameBufferTextures = new uint[4];
        /// <summary>
        /// 输入纹理,根据inputs设定，包括frameBufferTexture,图片纹理，cubmap,输入数据等
        /// </summary>
        private uint[] m_inputChannels;
        /// <summary>
        /// 缓存的使用到的图片纹理
        /// </summary>
        private List<Texture> m_cachePictureTextures = new List<Texture>();
        /// <summary>
        /// vbo顶点缓存
        /// </summary>
        private VertexBufferArray m_vertexBufferArray;

        #region 内部方法
        /// <summary>
        /// 移除注释,但保持行号不变
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string RemoveComment(string content)
        {
            StringBuilder sb = new StringBuilder();
            var chars = content.ToCharArray();
            int index = 0;

            for (index = 0; index < chars.Length;)
            {
                if (chars[index] == '/' && chars[index + 1] == '/')
                {
                    index += 2;
                    while (true)
                    {
                        if (chars[index] == '\n')
                        {
                            index += 1;
                            sb.Append('\n');
                            break;
                        }
                        if (chars[index] == '\r' && chars[index + 1] == '\n')
                        {
                            index += 2;
                            sb.Append('\r').Append('\n');
                            break;
                        }
                        index++;
                    }
                }
                else if (chars[index] == '/' && chars[index + 1] == '*')
                {
                    index += 2;
                    while (true)
                    {
                        if (chars[index] == '*' && chars[index + 1] == '/')
                        {
                            index += 2;
                            break;
                        }
                        if (chars[index] == '\n')
                        {
                            sb.Append('\n');
                        }else if (chars[index] == '\r' && chars[index + 1] == '\n')
                        {
                            sb.Append('\r').Append('\n');
                            index++;
                        }
                        index++;
                    }
                }
                else
                {
                    sb.Append(chars[index]);
                    index++;
                }
            }
            return sb.ToString();
        }

        private static int GetRenderPassPriority(RenderPassData renderPass)
        {
            if (renderPass.name == "Image")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private static int RenderPassSorter(RenderPassData a, RenderPassData b)
        {
            return GetRenderPassPriority(a) - GetRenderPassPriority(b);
        }
        #endregion

        #region 初始化
        
        private void CreateFrameBufferTextures()
        {
            uint[] ids = new uint[1];
            //初始化fbo
            GL.GenFramebuffersEXT(1, ids);
            m_frameBufferID = ids[0];
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, m_frameBufferID);
            //初始化四个buff纹理
            GL.GenTextures(4, m_frameBufferTextures);
            for (int i = 0; i < 4; i++)
            {
                GL.BindTexture(OpenGL.GL_TEXTURE_2D, m_frameBufferTextures[i]);
                GL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGB, 256, 256, 0, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
                GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                GL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                GL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
                GL.FramebufferTexture2DEXT(OpenGL.GL_FRAMEBUFFER_EXT, OpenGL.GL_COLOR_ATTACHMENT0_EXT + (uint)i, OpenGL.GL_TEXTURE_2D, m_frameBufferTextures[i], 0);
            }
            var checkResult = GL.CheckFramebufferStatusEXT(OpenGL.GL_FRAMEBUFFER_EXT);
            if (checkResult != OpenGL.GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                var dialog = MessageBox.Show("GL.CheckFramebufferStatusEXT(OpenGL.GL_FRAMEBUFFER_EXT) error");
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void CreateErrorShader()
        {
            //创建错误时显示的shader
            var vertex = ResourceLoader.LoadTextFile(Setting.VertShaderPath);
            var fragment = ResourceLoader.LoadTextFile(Setting.FragShaderForErrorPath);
            m_errorShader = CreateShader(vertex, fragment);
        }

        private ShaderProgram CreateShader(string vertex, string fragment)
        {
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(GL, vertex, fragment, null);
            shaderProgram.BindAttributeLocation(GL, AttributeIndexPosition, "in_position");
            shaderProgram.AssertValid(GL);
            return shaderProgram;
        }

        private ShaderProgram CreateShader(RenderPassData renderPassData)
        {
            var vertexShaderSource = ResourceLoader.LoadTextFile(Setting.VertShaderPath);
            var fragmentShaderTemplate = ResourceLoader.LoadTextFile(Setting.FragShaderPath);
            string fragmentShaderSource = TemplateHelper.Parse(fragmentShaderTemplate, "passData", renderPassData);
            vertexShaderSource = RemoveComment(vertexShaderSource);
            fragmentShaderSource = RemoveComment(fragmentShaderSource);

            return CreateShader(vertexShaderSource, fragmentShaderSource);
        }

        /// <summary>
        /// Creates the geometry for the square, also creating the vertex buffer array.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
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
            m_vertexBufferArray = new VertexBufferArray();
            m_vertexBufferArray.Create(GL);
            m_vertexBufferArray.Bind(GL);

            //  Create a vertex buffer for the vertex data.
            var vertexDataBuffer = new VertexBuffer();
            vertexDataBuffer.Create(GL);
            vertexDataBuffer.Bind(GL);
            vertexDataBuffer.SetData(GL, 0, vertices, false, 3);

            //  Unbind the vertex array, we've finished specifying data for it.
            m_vertexBufferArray.Unbind(GL);
        }

        private void InitInputChannels()
        {
            if (m_shaderData.Inputs.Count != 0)
            {
                m_inputChannels = new uint[4];
                foreach (var input in m_shaderData.Inputs)
                {
                    if (input.type == "buffer")
                    {
                        int buffIndex = 0;
                        if (input.filepath.EndsWith("buffer00.png"))
                        {
                            buffIndex = 0;
                        }
                        else if (input.filepath.EndsWith("buffer01.png"))
                        {
                            buffIndex = 1;
                        }
                        else if (input.filepath.EndsWith("buffer02.png"))
                        {
                            buffIndex = 2;
                        }
                        else if (input.filepath.EndsWith("buffer03.png"))
                        {
                            buffIndex = 3;
                        }
                        m_inputChannels[input.channel] = m_frameBufferTextures[buffIndex];
                    }
                    else if (input.type == "texture")
                    {
                        string fullPath = Setting.AssetPath + input.filepath.Replace('/', '\\');
                        if (File.Exists(fullPath) && !input.filepath.EndsWith("none.png"))
                        {
                            Texture texture = new Texture();
                            texture.Create(GL, fullPath);
                            m_inputChannels[input.channel] = texture.TextureName;
                            m_cachePictureTextures.Add(texture);
                        }
                        else
                        {
                            m_inputChannels[input.channel] = 0;
                        }

                    }
                }
            }
        }

        public ShaderToyStyleRender(OpenGL openGL,Vec2 size)
        {
            m_openGL = openGL;
            m_width = (int)size.x;
            m_height = (int)size.y;
            CreateVerticesForSquare();
            CreateFrameBufferTextures();
        }

        public void CompileShader(ShaderData shaderData)
        {
            m_shaderData = shaderData;
            m_shaderData.renderpass.Sort(RenderPassSorter);
            m_hasError = false;

            DisposeShaders();
            try
            {
                //初始化着色器
                m_shaderPrograms = new ShaderProgram[m_shaderData.renderpass.Count];
                for (int i = 0; i < m_shaderData.renderpass.Count; i++)
                {
                    var renderPass = m_shaderData.renderpass[i];
                    try
                    {
                        var shader = CreateShader(renderPass);
                        m_shaderPrograms[i] = shader;
                    }
                    catch (Exception e)
                    {
                        ShaderCompilationException compilationException = e as ShaderCompilationException;
                        if (compilationException != null)
                            throw new ShaderCompileError(compilationException.CompilerOutput, renderPass.name);
                        throw e;
                    }
                }

                //初始化输入
                DisposeCacheTextures();
                InitInputChannels();

                uint ero;
                if ((ero = GL.GetError()) != OpenGL.GL_NO_ERROR)
                {
                    var errorString = GL.GetErrorDescription((uint)GL.GetErrorCode());
                    throw new Exception(errorString);
                }
            }
            catch (Exception e)
            {
                m_hasError = true;
                //保证这里正确
                CreateErrorShader();
                m_exception = e;
            } 
        }
        #endregion

        #region 资源释放

        private void DisposeCacheTextures()
        {
            //删除加载的图片
            foreach (var texture in m_cachePictureTextures)
            {
                texture.Destroy(GL);
            }
            m_cachePictureTextures.Clear();
        }

        private void DisposeShaders()
        {
            if (m_shaderPrograms != null)
            {
                foreach (var shaderProgram in m_shaderPrograms)
                {
                    if (shaderProgram != null)
                    {
                        shaderProgram.Unbind(GL);
                        shaderProgram.Delete(GL);
                    }
                }
                m_shaderPrograms = null;
            }
        }

        public void Dispose()
        {
            DisposeCacheTextures();
            //删除着色器程序
            DisposeShaders();
            if (m_errorShader != null)
            {
                m_errorShader.Delete(GL);
                m_errorShader = null;
            }

            //删除顶点数组
            m_vertexBufferArray.Delete(GL); m_vertexBufferArray = null;
            //删除frameBufferTextures
            GL.DeleteFramebuffersEXT(1, new uint[] { m_frameBufferID }); m_frameBufferID = 0;
            GL.DeleteTextures(4, m_frameBufferTextures); m_frameBufferTextures = null;
            
        }
        #endregion

        #region 渲染

        private void RenderPassError()
        {
            m_errorShader.Bind(GL);
            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, 0);
            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);
            m_errorShader.Unbind(GL);
        }

        /// <summary>
        /// 设置shader输入参数
        /// </summary>
        /// <param name="shader"></param>
        private void SetShaderUniformParams(ShaderProgram shader)
        {
            shader.SetUniform3(GL, "iResolution", m_iResolution.x, m_iResolution.y, 0.0f);
            shader.SetUniform1(GL, "iTime", m_iTime);
            shader.SetUniform1(GL, "iTimeDelta", m_iTimeDelta);
            GL.Uniform4(shader.GetUniformLocation(GL, "iMouse"), m_iMouse.x, m_iMouse.y, m_iMouse.z, 0.0f);
            var now = DateTime.Now;
            GL.Uniform4(shader.GetUniformLocation(GL, "iDate"), now.Year, now.Month, now.Day, (float)now.TimeOfDay.TotalSeconds);
            for (int j = 0; j < m_shaderData.Inputs.Count; j++)
            {
                var input = m_shaderData.Inputs[j];
                GL.ActiveTexture(OpenGL.GL_TEXTURE0 + (uint)j);
                GL.BindTexture(OpenGL.GL_TEXTURE_2D, m_inputChannels[input.channel]);
                GL.Uniform1(shader.GetUniformLocation(GL, "iChannel" + input.channel), j);
            }
        }

        private void RenderPassBuffer(ShaderProgram shader, int attachment)
        {
            var attachmentTarget = OpenGL.GL_COLOR_ATTACHMENT0_EXT + (uint)attachment;

            shader.Bind(GL);

            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, m_frameBufferID);
            GL.DrawBuffersARB(1, new uint[] { attachmentTarget });

            SetShaderUniformParams(shader);

            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            shader.Unbind(GL);
        }

        private void RenderPassImage(ShaderProgram shader)
        {
            shader.Bind(GL);

            GL.BindFramebufferEXT(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            SetShaderUniformParams(shader);

            GL.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            shader.Unbind(GL);
        }

        private void RenderBody()
        {
            GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
            m_vertexBufferArray.Bind(GL);

            if (HasError)
                RenderPassError();
            else
            {
                for (int i = m_shaderData.renderpass.Count - 1; i >= 0; i--)
                {
                    var renderPass = m_shaderData.renderpass[i];
                    var shader = m_shaderPrograms[i];
                    if (renderPass.type == "buffer")
                    {
                        int bufferIndex = 0;
                        if (renderPass.name == "Buf A")
                        {
                            bufferIndex = 0;
                        }
                        else if (renderPass.name == "Buf B")
                        {
                            bufferIndex = 1;
                        }
                        else if (renderPass.name == "Buf C")
                        {
                            bufferIndex = 2;
                        }
                        else if (renderPass.name == "Buf D")
                        {
                            bufferIndex = 3;
                        }
                        RenderPassBuffer(shader, bufferIndex);
                    }
                    else if (renderPass.type == "image")
                    {
                        RenderPassImage(shader);
                    }
                }
            }

            m_vertexBufferArray.Unbind(GL);
        }

        public void Render(float iTime,float iTimeDelta, Vec2 iResolution, Vec3 iMouse)
        {
            m_iTime = iTime;
            m_iTimeDelta = iTimeDelta;
            m_iResolution = iResolution;
            m_iMouse = iMouse;
            try
            {
                RenderBody();
            }
            catch (Exception e)
            {
                m_hasError = true;
                m_exception = e;
                if (m_errorShader == null)
                {
                    CreateErrorShader();
                }
            }
        }
        #endregion

        public void ReadTexture(out Color[] colors,out int width,out int height)
        {
            byte[] bytes = new byte[m_width*m_height*4];
            GL.ReadPixels(0, 0, m_width, m_height, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, bytes);
            width = m_width; height = m_height;
            colors = new Color[m_width * m_height];
            for(int i=0;i< m_width * m_height; i++)
            {
                int j = i * 4;
                Color c = Color.FromArgb(bytes[j+3], bytes[j], bytes[j + 1], bytes[j + 2]);
                colors[i] = c;
            }
        }
    }
}
