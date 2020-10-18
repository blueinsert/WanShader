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
    public partial class InputChannelSelectUIController : Form
    {
        //type,path
        public Action<string,string> EventOnTargetClick;
        public Action<Point> EventOnFormClose;

        private static InputChannelSelectUIController sInstance;
        public static InputChannelSelectUIController GetInstance() {
            if (sInstance == null) {
                sInstance = new InputChannelSelectUIController();
            }
            sInstance.EventOnTargetClick = null;
            sInstance.EventOnFormClose = null;
            return sInstance;
        }

        private InputChannelSelectUIController()
        {
            InitializeComponent();
        }

        private void OnTextureClick(string subpath,string fileName) {
            
            if (EventOnTargetClick != null)
            {
                string path = subpath + "\\"+ fileName;
                string type = "texture";
                switch (fileName) {
                    case "buffer00.png":
                    case "buffer01.png":
                    case "buffer02.png":
                    case "buffer03.png":
                        type = "buffer";
                        break;
                    default:
                        type = "texture";
                        break;
                }
                EventOnTargetClick(type, path);
            }
        }

        private void LoadTextures(string subPath,Control parent) {
            
            var textureDirPath = Directory.GetCurrentDirectory() + subPath;
            DirectoryInfo directory = new DirectoryInfo(textureDirPath);
            FileInfo[] files = directory.GetFiles();
            string fileName;
            List<FileInfo> textureFiles = new List<FileInfo>();
            for (int i = 0; i < files.Length; i++)
            {
                fileName = files[i].Name.ToLower();
                if (fileName.EndsWith(".png") || fileName.EndsWith(".jpg") || fileName.EndsWith(".bmp"))
                {
                    textureFiles.Add(files[i]);
                }
            }
            foreach (var file in textureFiles)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.LoadAsync(file.FullName);
                pictureBox.Size = new Size(140, 100);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Click += (s,e) => { OnTextureClick(subPath, file.Name); };
                pictureBox.MouseEnter += (s, e) => { pictureBox.BackColor = Color.Black; };
                pictureBox.MouseLeave += (s, e) => { pictureBox.BackColor = Color.White; };
                parent.Controls.Add(pictureBox);
            }
        }

        private void OnMouseHoverOnPicture(object sender, EventArgs e)
        {

        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            LoadTextures( Setting.MediaPath+"/texture",textureFlowLayoutPanel);
            LoadTextures(Setting.MediaPath + "/misc", miscFlowLayoutPanel);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            sInstance = null;
            if (EventOnFormClose != null) {
                EventOnFormClose(this.Location);
            }
        }

        private void OnFormLocationChanged(object sender, EventArgs e)
        {
        }
    }
}
