using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluebean.ShaderToyOffline
{
    public partial class ShaderListItemUIController : UserControl
    {
        public event Action<ShaderListItemUIController> EventOnLoaded;
        public event Action<ShaderListItemUIController> EventOnDeleteButtonClick;
        public event Action<ShaderListItemUIController> EventOnClick;

        private ShaderToyStyleRender m_render;
        public ShaderData m_shaderData;

        private Timer m_timer;
        private float m_iTimeDelta = 0;
        private float m_iTime = 0;

        public ShaderListItemUIController()
        {
            InitializeComponent();
        }

        public void Init(ShaderData shaderData)
        {
            if (m_render != null)
            {
                m_render.Dispose();
                m_render = null;
            }
            if (shaderData == null)
            {
                return;
            }
            m_shaderData = shaderData;
            nameText.Text = m_shaderData.info.name;
            m_render = new ShaderToyStyleRender(glCanvas.OpenGL,new Vec2(glCanvas.Width,glCanvas.Height));
            m_render.CompileShader(m_shaderData.Clone());
            glCanvas.DoRender();
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            if (EventOnLoaded != null)
            {
                EventOnLoaded(this);
                EventOnLoaded = null;
            }
        }

        private void OpenGL_OnDraw(object sender, SharpGL.RenderEventArgs args)
        {
            if (m_render != null)
            {
                m_render.Render(m_iTime, m_iTimeDelta, new Vec2(glCanvas.Width,glCanvas.Height),new Vec3(0,0,0));
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            m_timer = new Timer();
            m_timer.Interval = 33;
            m_timer.Tick += (object sender1, EventArgs e1) => {
                m_iTimeDelta = 0.033f * 4;
                m_iTime += m_iTimeDelta;
                glCanvas.DoRender();
            };
            m_timer.Start();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (m_timer != null)
            {
                m_timer.Dispose();
                m_timer = null;
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (EventOnClick != null)
            {
                EventOnClick(this);
            }
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            if (EventOnDeleteButtonClick != null)
            {
                EventOnDeleteButtonClick(this);
            }
        }

        public void OnNeedRePaint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("ShaderListItemUIController:OnNeedRePaint");
            glCanvas.DoRender();
        }
    }
}
