using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using SharpGL.Shaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluebean.ShaderToyOffline
{
  
    public partial class DetailPageUIController : Form
    {
        private bool m_isNew = false;
        private ShaderData m_shaderData;
        private Timer m_timer;
        private Timer m_fpsTimer;

        private ShaderToyStyleRender m_render;
        private TextEditorControl m_codeTextEditor;

        private DateTime m_lastRenderTime;
        private int m_iFrame;
        private int m_iFrameLast;
        private float m_iTime;
        private Vec3 m_iMouse;
        private bool m_isStop = false;

        public DetailPageUIController(ShaderData shaderData, bool isNew)
        {
            m_isNew = isNew;
            m_shaderData = shaderData;
            
            m_lastRenderTime = DateTime.Now;
            StartFpsTimer();
            InitializeComponent();
            resulationText.Text = string.Format("{0}x{1}", openGLControl1.Width, openGLControl1.Height);
        }

        #region 内部方法

        private void GenerateThumb()
        {
            var bitmap = m_render.ExportBitmap();
            if (!Directory.Exists(Setting.ThumbPath))
            {
                Directory.CreateDirectory(Setting.ThumbPath);
            }
            var filePath = string.Format("{0}/{1}.png", Setting.ThumbPath, m_shaderData.info.id);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            bitmap.Save(filePath);
        }

        private void TryStopTickRender()
        {
            if (m_timer != null)
            {
                m_timer.Stop();
                m_timer = null;
            }
        }

        private void StartTickRender()
        {
            if (m_timer != null)
                m_timer.Stop();
            m_timer = new Timer();
            m_timer.Interval = (int)(1.0 / 100.0 * 1000);
            m_timer.Tick += (object sender, EventArgs e) => {
                openGLControl1.DoRender();
            };
            m_timer.Start();
        }

        private void StartFpsTimer()
        {
            if (m_fpsTimer != null)
                m_fpsTimer.Stop();
            m_fpsTimer = new Timer();
            m_fpsTimer.Interval = 1000;
            m_fpsTimer.Tick += (object sender, EventArgs e) => {
                fpsText.Text = string.Format("fps:{0}", m_iFrame - m_iFrameLast);
                m_iFrameLast = m_iFrame;
            };
            m_fpsTimer.Start();
        }

        private void CompileShader()
        {
            m_render.CompileShader(m_shaderData.Clone());
            if (m_render.HasError)
            {
                var e = m_render.Exception;
                var compileE = e as ShaderCompileError;
                if (compileE != null)
                {
                    compileOutputTextBox.Text = compileE.Error.ToString();
                }
                else
                {
                    compileOutputTextBox.Text = e.Message + e.StackTrace;
                }
            }
            else
            {
                compileOutputTextBox.Text = "compile success!";
            }
        }

        private string ConcatStringArray(string[] strs, string concat)
        {
            if (strs == null)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                sb.Append(strs[i]);
                if (i < strs.Length - 1)
                {
                    sb.Append(concat);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region UI显示更新

        private void SetEditArea() {
            var renderPass = m_shaderData.renderpass.Find((elem) => { return elem.name == "Image"; });
            TabPage tabPage = new TabPage("Image");
            m_codeTextEditor = new TextEditorControl();
            m_codeTextEditor.Encoding = Encoding.GetEncoding("utf-8");
            m_codeTextEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
            m_codeTextEditor.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            m_codeTextEditor.Text = renderPass.code;
            tabPage.Controls.Add(m_codeTextEditor);
            m_codeTextEditor.Size = tabPage.Size;
            codeEditorTabControl.Controls.Add(tabPage);
        }

        private void SetShaderInfo()
        {
            shaderNameTextBox.Text = m_shaderData.info.name;
            shaderTagsTextBox.Text = ConcatStringArray(m_shaderData.info.tags, ",");
            shaderDescTextBox.Text = m_shaderData.info.description;
        }

        private void SetDetailPage()
        {
            SetShaderInfo();
            SetEditArea();
            m_render = new ShaderToyStyleRender(openGLControl1.OpenGL,new Vec2(openGLControl1.Width,openGLControl1.Height));
            CompileShader();
            StartTickRender();
        }
        #endregion

        #region UI事件监听
        private void OpenGL_OnInited(object sender, EventArgs e)
        {
            SetDetailPage();
        }

        private void OpenGL_OnDraw(object sender, SharpGL.RenderEventArgs args)
        {
            DateTime now = DateTime.Now;
            float deltaTime = (float) (now - m_lastRenderTime).TotalSeconds;
            m_iFrame++;
            if(!m_isStop)
                m_iTime += deltaTime;
            m_lastRenderTime = now;
            if (m_render != null)
                m_render.Render(m_iTime, deltaTime,new Vec2(openGLControl1.Width,openGLControl1.Height), m_iMouse);
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            m_shaderData.info.name = shaderNameTextBox.Text;
            m_shaderData.info.tags = shaderTagsTextBox.Text.Split(new char[] { ',' });
            m_shaderData.info.description = shaderDescTextBox.Text;

            if (m_isNew)
            {
                string error;
                bool res = UserData.Instance.AddShader(m_shaderData, out error);
                if (!res)
                {
                    MessageBox.Show(error);
                }
                m_isNew = false;
            }
            else
            {
                UserData.Instance.UpdateShader(m_shaderData);
            }
            GenerateThumb();
        }

        private void OnCompileButtonClick(object sender, EventArgs e)
        {
            m_shaderData.renderpass[0].code = m_codeTextEditor.Text;
            CompileShader();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            TryStopTickRender();
            if (m_render != null)
            {
                m_render.Dispose();
                m_render = null;
            }
        }

        private void OnRenderPassDeleteButtonClick(object sender, EventArgs e)
        {
            var index = codeEditorTabControl.SelectedIndex;
            if (m_shaderData.renderpass[index].name == "Image")
                return;
            codeEditorTabControl.TabPages.Remove(codeEditorTabControl.SelectedTab);
            codeEditorTabControl.SelectedIndex = codeEditorTabControl.Controls.Count - 1;
            m_shaderData.renderpass.RemoveAt(index);
        }

        private void OpenGLCanvas_OnMouseDown(object sender, MouseEventArgs e)
        {
            m_iMouse.z = 1.0f;
        }

        private void OpenGLCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            m_iMouse.x = 0;
            m_iMouse.y = 0;
            if (m_iMouse.z > 0)
            {
                m_iMouse.x = e.X;
                m_iMouse.y = openGLControl1.Height - e.Y;
            }
            Console.WriteLine(string.Format("x:{0} y:{1}", e.X, e.Y));
        }

        private void OpenGLCanvas_OnMouseUp(object sender, MouseEventArgs e)
        {
            m_iMouse.z = 0.0f;
        }

        private void OnResetButtonClick(object sender, EventArgs e)
        {
            m_iTime = 0;
        }

        private void OnStopOrContinueButtonClick(object sender, EventArgs e)
        {
            m_isStop = !m_isStop;
            stopOrContinueButton.Text = m_isStop ? "Continue" : "Stop";
        }

        private void OnFullButtonClick(object sender, EventArgs e)
        {
            var fullUICtrl = new FullScreenEffectUIController(m_shaderData);
            //this.Hide();
            fullUICtrl.Show();
            //fullUICtrl.FormClosed += (sender1,e1) => {
            //    this.Show();
            //};
        }

        #endregion

    }
}
