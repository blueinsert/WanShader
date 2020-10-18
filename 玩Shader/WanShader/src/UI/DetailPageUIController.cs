using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using SharpGL.Shaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private DateTime m_lastRenderTime;
        private int m_iFrame;
        private int m_iFrameLast;
        private float m_iTime;
        private float m_iTimeDelta;
        private Vec3 m_iMouse;
        private bool m_isStop = false;

        private Point m_lastInputChannelSelectFormLocation;

        public DetailPageUIController(ShaderData shaderData, bool isNew)
        {
            m_isNew = isNew;
            m_shaderData = shaderData;
            m_lastRenderTime = DateTime.Now;
            StartFpsTimer();
            InitializeComponent();
        }

        #region 内部方法
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
                    MessageBox.Show(compileE.Error);
                }
                else
                {
                    MessageBox.Show(e.Message + e.StackTrace, "error");
                }
            }
        }

        private void AddRenderPass(string passName)
        {
            RenderPassData newPass = new RenderPassData()
            {
                code = @"void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
                    fragColor = texture(iChannel0, fragCoord / iResolution.xy);
        }",
                name = passName,
            };
            m_shaderData.renderpass.Add(newPass);
            var tabPage = AddCodeEditorTabPage(newPass);
            codeEditorTabControl.SelectedIndex = codeEditorTabControl.Controls.Count - 1;
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

        private TabPage AddCodeEditorTabPage(RenderPassData renderPass) {
            TabPage tabPage = new TabPage(renderPass.name);
            TextEditorControl textEditor = new TextEditorControl();
            textEditor.Encoding = Encoding.GetEncoding("utf-8");
            textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
            textEditor.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            textEditor.Text = renderPass.code;
            tabPage.Controls.Add(textEditor);
            textEditor.Size = tabPage.Size;
            codeEditorTabControl.Controls.Add(tabPage);
            //m_codeEditorTabControl.Controls.SetChildIndex(tabPage, 0);
            return tabPage;
        }

        private void SetEditArea() {
            for (int i = 0; i < m_shaderData.renderpass.Count; i++) {
                var renderPass = m_shaderData.renderpass[i];
                AddCodeEditorTabPage(renderPass);
            }
        }

        private void SetInputChannelPicture(int channelIndex, string picPath)
        {

            PictureBox pic = null;
            Button deleteButton = null;
            switch (channelIndex)
            {
                case 0:
                    pic = iChannel0PictureBox; deleteButton = iChannel0DeleteButton;
                    break;
                case 1:
                    pic = iChannel1PictureBox; deleteButton = iChannel1DeleteButton;
                    break;
                case 2:
                    pic = iChannel2PictureBox; deleteButton = iChannel2DeleteButton;
                    break;
                case 3:
                    pic = iChannel3PictureBox; deleteButton = iChannel3DeleteButton;
                    break;
            }
            if (string.IsNullOrEmpty(picPath))
            {
                deleteButton.Visible = false;
                string fullPath = Directory.GetCurrentDirectory() + "\\media\\misc\\none.png";
                pic.LoadAsync(fullPath);
            }
            else
            {
                deleteButton.Visible = true;
                string fullPath = Directory.GetCurrentDirectory() + picPath;
                pic.LoadAsync(fullPath);
            }
        }

        private void SetInputChannelPictures()
        {
            int[] channels = new int[4];
            foreach (var input in m_shaderData.Inputs)
            {
                SetInputChannelPicture(input.channel, input.filepath);
                channels[input.channel] = 1;
            }
            for (int i = 0; i < 4; i++)
            {
                if (channels[i] == 0)
                {
                    SetInputChannelPicture(i, "");
                }
            }
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
            m_render = new ShaderToyStyleRender(openGLControl1.OpenGL);
            CompileShader();
            StartTickRender();
            SetInputChannelPictures();
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
        }

        private void OnCompileButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < codeEditorTabControl.Controls.Count; i++)
            {
                var renderPass = m_shaderData.renderpass[i];
                var textEditor = codeEditorTabControl.TabPages[i].Controls[0] as TextEditorControl;
                renderPass.code = textEditor.Text;
            }
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

        private void OnRenderPassAddButtonClick(object sender, EventArgs e)
        {
            List<string> allPassName = new List<string>() { "Common", "Buf A", "Buf B", "Buf C", "Buf D", "Cube A", "Sound", "Image" };
            List<string> addablePassName = new List<string>();
            foreach (var passName in allPassName)
            {
                if (m_shaderData.renderpass.Find((elem) => { return elem.name == passName; }) == null)
                {
                    addablePassName.Add(passName);
                }
            }
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            foreach (var passName in addablePassName)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(passName);
                toolStripMenuItem.Click += (sender1, e1) => {
                    AddRenderPass(passName);
                };
                contextMenuStrip.Items.Add(toolStripMenuItem);
            }
            contextMenuStrip.Show(renderPassOperGroup, m_renderPassAddButton.Location);
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

        private void OnChannelDeleteButtonClick(int channelIndex)
        {
            var input = m_shaderData.Inputs.Find((e) => { return e.channel == channelIndex; });
            if (input != null)
            {
                m_shaderData.Inputs.Remove(input);
                SetInputChannelPictures();
                CompileShader();
            }
        }

        private void OnSelectInputChannelFinish(int channelIndex, string type, string path)
        {
            var input = m_shaderData.Inputs.Find((e) => { return e.channel == channelIndex; });
            if (input == null)
            {
                input = new RenderPassInput();
                input.channel = channelIndex;
                m_shaderData.Inputs.Add(input);
            }
            input.type = type;
            input.filepath = path;
            SetInputChannelPicture(channelIndex, path);
            CompileShader();
        }

        private void SelectInputChannel(int channelIndex)
        {
            var form = InputChannelSelectUIController.GetInstance();
            form.Show();
            form.Location = m_lastInputChannelSelectFormLocation;
            form.Focus();
            form.EventOnTargetClick += (t, p) => {
                OnSelectInputChannelFinish(channelIndex, t, p);
            };
            form.EventOnFormClose += (l) => { m_lastInputChannelSelectFormLocation = l; };
        }

        private void OnInputChannel0Click(object sender, EventArgs e)
        {
            SelectInputChannel(0);
        }

        private void OnInputChannel1Click(object sender, EventArgs e)
        {
            SelectInputChannel(1);
        }

        private void OnInputChannel2Click(object sender, EventArgs e)
        {
            SelectInputChannel(2);
        }

        private void OnInputChannel3Click(object sender, EventArgs e)
        {
            SelectInputChannel(3);
        }

        private void OnChannel0DeleteButtonClick(object sender, EventArgs e)
        {
            OnChannelDeleteButtonClick(0);
        }

        private void OnChannel1DeleteButtonClick(object sender, EventArgs e)
        {
            OnChannelDeleteButtonClick(1);
        }

        private void OnChannel2DeleteButtonClick(object sender, EventArgs e)
        {
            OnChannelDeleteButtonClick(2);
        }

        private void OnChannel3DeleteButtonClick(object sender, EventArgs e)
        {
            OnChannelDeleteButtonClick(3);
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
