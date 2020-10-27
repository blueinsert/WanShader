using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bluebean.ShaderToyOffline
{
    public partial class ShaderListItemUIController : UserControl
    {
        public event Action<ShaderListItemUIController> EventOnDeleteButtonClick;
        public event Action<ShaderListItemUIController> EventOnClick;

        public ShaderData m_shaderData;

        public ShaderListItemUIController()
        {
            InitializeComponent();
            //pictureBox.Controls.Add(this.nameText);
        }

        private bool LoadThumb()
        {
            string thumbPath = string.Format("{0}/{1}.png", Setting.ThumbPath, m_shaderData.info.id);
            if (!File.Exists(thumbPath))
            {
                Console.WriteLine(String.Format("thumb {0} not exit", thumbPath));
                return false;
            }
            //pictureBox.Load(thumbPath);
            pictureBox.LoadAsync(thumbPath);
            return true;
        }

        public void Init(ShaderData shaderData)
        {
            m_shaderData = shaderData;
            nameText.Text = m_shaderData.info.name;
            LoadThumb();
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

    }
}
