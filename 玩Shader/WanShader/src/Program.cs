using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluebean.ShaderToyOffline
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserData.CreateInstance("./Assets/shaders.json");
            //预处理,只保留image Pass
            foreach (var shader in UserData.Instance.GetShaders())
            {
                if (shader.renderpass.Count > 1)
                {
                    var imgPass = shader.renderpass.Find((elem) => { return elem.name == "Image"; });
                    if (imgPass == null)
                    {
                        imgPass = new RenderPassData() { code = ResourceLoader.LoadTextFile(Setting.ShaderToyShaderDefaultPath), name = "Image", type = "image" };
                    }
                    shader.renderpass.Clear();
                    shader.renderpass.Add(imgPass);
                }
                shader.Inputs.Clear();
            }
            Application.Run(new MainPageUIController());
        }
    }
}
