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
    public partial class MainPageUIController : Form
    {
        private List<ShaderListItemUIController> m_shaderUICtrlList = new List<ShaderListItemUIController>();

        public MainPageUIController()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void OnLoad(object sender, EventArgs e)
        {
            UserData.Instance.EventOnShaderUpdated += UserData_OnShaderUpdated;
            UserData_OnShaderUpdated();
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

        private void OnNeedRePaint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("MainPageUIController:OnNeedRePaint");
            foreach(var listItem in m_shaderUICtrlList)
            {
                if ((listItem.Location.Y > 0 && listItem.Location.Y < flowLayoutPanel1.Height)
                    || (listItem.Location.Y + listItem.Height > 0 && listItem.Location.Y + listItem.Height < flowLayoutPanel1.Height))
                {
                    listItem.OnNeedRePaint(sender, e);
                }  
            }
        }
    }
}
