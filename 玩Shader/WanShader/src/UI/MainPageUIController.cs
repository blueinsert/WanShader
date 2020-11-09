using System;
using System.Collections;
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
    public partial class MainPageUIController : Form
    {
        private List<ShaderListItemUIController> m_shaderUICtrlList = new List<ShaderListItemUIController>();

        private List<ShaderData> m_shaderList = new List<ShaderData>();
        private ShaderToyStyleRender m_render;

        private CoroutineScheduler m_coroutineScheduler;
        private Timer m_coroutineTicker;

        public MainPageUIController()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void OnLoad(object sender, EventArgs e)
        {
            PanelMainPage.Visible = false;
            PanelLoading.Visible = true;
            GenerateThumbs(() => {
                PanelMainPage.Visible = true;
                PanelLoading.Visible = false;
                UserData.Instance.EventOnShaderUpdated += UserData_OnShaderUpdated;
                UserData_OnShaderUpdated();
            });
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            UserData.Instance.EventOnShaderUpdated -= UserData_OnShaderUpdated;
        }

        private void UserData_OnShaderUpdated()
        {
            var allShaders = UserData.Instance.GetShaders();
            int i = 0;
            for(i = 0; i < allShaders.Count; i++)
            {
                var shader = allShaders[i];
                ShaderListItemUIController uiCtrl = null;
                if (i < m_shaderUICtrlList.Count)
                {
                    uiCtrl = m_shaderUICtrlList[i];
                }
                else
                {
                    uiCtrl = new ShaderListItemUIController();
                    //uiCtrl.EventOnLoaded += (ctrl) => {
                    //    ctrl.Init(shaderData);
                    //};
                    uiCtrl.EventOnClick += ShaderListItemUIController_OnClick;
                    uiCtrl.EventOnDeleteButtonClick += ShaderListItemUIController_OnDeleteButtonClick;
                    m_shaderUICtrlList.Add(uiCtrl);
                    flowLayoutPanel1.Controls.Add(uiCtrl);
                }
                uiCtrl.Visible = true;
                uiCtrl.Init(shader);
            }
            if (i < m_shaderUICtrlList.Count)
            {
                for (; i < m_shaderUICtrlList.Count; i++)
                {
                    m_shaderUICtrlList[i].Visible = false;
                }
            }    
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine("MainPageUIController:OnScroll");
            flowLayoutPanel1.VerticalScroll.Value = e.NewValue;
        }

        private void ShaderListItemUIController_OnClick(ShaderListItemUIController uiCtrl)
        {
            DetailPageUIController detailPageForm = new DetailPageUIController(uiCtrl.m_shaderData, false);
            detailPageForm.Show();
        }

        private void ShaderListItemUIController_OnDeleteButtonClick(ShaderListItemUIController uiCtrl) {
            var shaderName = uiCtrl.m_shaderData.info.name;
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            var res = MessageBox.Show(string.Format("确定删除《{0}》吗？", shaderName),"是否真的", messButton);
            if(res == DialogResult.OK)
            {
                UserData.Instance.DeleteShader(shaderName);
            }   
        }

        private void OnNewButtonClick(object sender, EventArgs e)
        {
            ShaderData newShaderData = new ShaderData();
            DetailPageUIController detailPageForm = new DetailPageUIController(newShaderData, true);
            detailPageForm.Show();
        }

        IEnumerator Co_GenThumbs(Action onEnd)
        {
            for (int i = 0; i < m_shaderList.Count; i++)
            {
                var shaderData = m_shaderList[i];
                m_render.CompileShader(shaderData);
                glCanvas.DoRender();
                m_render.Render(4, 0.33f, new Vec2(glCanvas.Width, glCanvas.Height), new Vec3(0, 0, 0));
                var bitmap = m_render.ExportBitmap();
                var bitmapPath = string.Format("{0}/{1}.png", Setting.ThumbPath, shaderData.info.id);
                if (!Directory.Exists(Setting.ThumbPath))
                {
                    Directory.CreateDirectory(Setting.ThumbPath);
                }
                bitmap.Save(bitmapPath);
                string loading = "loading";
                switch (i % 3)
                {
                    case 0:
                        loading = "loading.";
                        break;
                    case 1:
                        loading = "loading..";
                        break;
                    case 2:
                        loading = "loading...";
                        break;
                }

                loadingText.Text = loading;
                yield return new WaitForFrames(2);
            }
            if (onEnd != null)
            {
                onEnd();
            }
        }

        private void OnGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            if (m_render != null)
                m_render.Render(4, 0.33f, new Vec2(glCanvas.Width, glCanvas.Height), new Vec3(0, 0, 0));
        }

        private void GenerateThumbs(Action onEnd)
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
                if (onEnd != null)
                {
                    onEnd();
                }
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

            m_coroutineScheduler.StartCorcoutine(Co_GenThumbs(() => {
                if (onEnd != null)
                {
                    onEnd();
                }
            }));
        }
 
}
}
