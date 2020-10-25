using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace bluebean.ShaderToyOffline
{
    public partial class ThumbGenUIController : Form
    {
        public event Action EventOnClose; 

        private List<ShaderData> m_shaderList = new List<ShaderData>();
        private ShaderToyStyleRender m_render;

        private CoroutineScheduler m_coroutineScheduler;
        private Timer m_coroutineTicker;

        public ThumbGenUIController()
        {
            InitializeComponent();
        }

        private void CloseUICtrl()
        {
            Close();
            if (EventOnClose != null)
            {
                EventOnClose();
            }
        }

        IEnumerator Co_GenThumbs(Action onEnd)
        {
            for(int i = 0; i < m_shaderList.Count; i++)
            {
                var shaderData = m_shaderList[i];
                m_render.CompileShader(shaderData);
                glCanvas.DoRender();
                m_render.Render(4, 0.33f, new Vec2(glCanvas.Width, glCanvas.Height), new Vec3(0, 0, 0));
                var bitmap = m_render.ExportBitmap();
                var bitmapPath = string.Format("{0}/{1}.png", Setting.ThumbPath, shaderData.info.id);
                bitmap.Save(bitmapPath);

                yield return new WaitForFrames(2);
            }
            if (onEnd != null)
            {
                onEnd();
            }
        }


        private void OnGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
           if(m_render!=null)
               m_render.Render(4, 0.33f, new Vec2(glCanvas.Width, glCanvas.Height), new Vec3(0, 0, 0));   
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            foreach (var shaderData in UserData.Instance.GetShaders())
            {
                var thumbPath = string.Format("{0}/{1}.png", Setting.ThumbPath, shaderData.info.id);
                if (!File.Exists(thumbPath))
                {
                    m_shaderList.Add(shaderData);
                }
            }
            if (m_shaderList.Count == 0)
            {
                CloseUICtrl();
                return;
            }
            m_render = new ShaderToyStyleRender(glCanvas.OpenGL, new Vec2(glCanvas.Width, glCanvas.Height));
           
            m_coroutineTicker = new Timer();
            m_coroutineScheduler = new CoroutineScheduler();

            m_coroutineTicker.Interval = 33;
            m_coroutineTicker.Tick += (object sender1, EventArgs e1) => {
                m_coroutineScheduler.Tick();
            };
            m_coroutineTicker.Start();
            
            m_coroutineScheduler.StartCorcoutine(Co_GenThumbs(()=> {
                CloseUICtrl();
            }));
        }
    }
}
