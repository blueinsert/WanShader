using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluebean.ShaderToyOffline
{
    public partial class FullScreenEffectUIController : Form
    {
        ShaderData m_shaderData;
        ShaderToyStyleRender m_render;
        Timer m_renderTicker;
        Timer m_fpsTimer;

        private DateTime m_lastRenderTime = DateTime.Now;
        private int m_iFrame = 0;
        private int m_iFrameLast = 0;
        private float m_iTime = 0;
        private Vec3 m_iMouse;
        private bool m_isStop = false;

        public FullScreenEffectUIController(ShaderData shaderData)
        {
            InitializeComponent();
            m_shaderData = shaderData;
            m_render = new ShaderToyStyleRender(openGLCanvas.OpenGL,new Vec2(openGLCanvas.Width,openGLCanvas.Height));
        }

        private void StartTickRender()
        {
            if (m_renderTicker != null)
                m_renderTicker.Stop();
            m_renderTicker = new Timer();
            m_renderTicker.Interval = (int)(1.0 / 100.0 * 1000);
            m_renderTicker.Tick += (object sender, EventArgs e) => {
                openGLCanvas.DoRender();
                sizeText.Text = string.Format("{0}x{1}", openGLCanvas.Width, openGLCanvas.Height);
            };
            m_renderTicker.Start();
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

        private void OnLoaded(object sender, EventArgs e)
        {
            m_render.CompileShader(m_shaderData);
            StartTickRender();
            StartFpsTimer();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if (m_renderTicker != null)
            {
                m_renderTicker.Stop();
                m_renderTicker.Dispose();
                m_renderTicker = null;
            }
            if (m_fpsTimer != null)
            {
                m_fpsTimer.Stop();
                m_fpsTimer.Dispose();
                m_fpsTimer = null;
            }
            /*
            if (m_render != null)
            {
                m_render.Dispose();
                m_render = null;
            }
            */
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
                m_iMouse.y = openGLCanvas.Height - e.Y;
            }
            Console.WriteLine(string.Format("x:{0} y:{1}", e.X, e.Y));
        }

        private void OpenGLCanvas_OnMouseUp(object sender, MouseEventArgs e)
        {
            m_iMouse.z = 0.0f;
        }

        private void OpenGLCanvas_OnDraw(object sender, SharpGL.RenderEventArgs args)
        {
            DateTime now = DateTime.Now;
            float deltaTime = (float)(now - m_lastRenderTime).TotalSeconds;
            m_iFrame++;
            if (!m_isStop)
                m_iTime += deltaTime;
            m_lastRenderTime = now;
            if (m_render != null)
                m_render.Render(m_iTime, deltaTime, new Vec2(openGLCanvas.Width, openGLCanvas.Height), m_iMouse);
        }

        private void OnExportImgButtonClick(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "图像文件(*.png)|*.png";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            var bitmap = m_render.ExportBitmap();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveDialog.FileName.ToString();
                bitmap.Save(path);
            }
        }
    }
}
