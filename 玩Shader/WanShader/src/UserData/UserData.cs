using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace bluebean.ShaderToyOffline
{
    [Serializable]
    public class RenderPassInputSampler {
        public string filter;
        public string wrap;
        public string vflip;
        public string srgb;
        public string @internal;
    }

    [Serializable]
    public class RenderPassInput {
        public string id;
        public string filepath;
        public string type;
        public int channel;
        public RenderPassInputSampler sampler;
        public int published;
    }

    [Serializable]
    public class RenderPassOutput {
        public string id;
        public int channel;
    }

    [Serializable]
    public class RenderPassData {
        public string Code { get { return code; } }

        public List<RenderPassInput> inputs;
        public List<RenderPassOutput> outputs;
        public string code;
        public string name;
        public string description;
        public string type;

        public RenderPassData() {
            inputs = new List<RenderPassInput>();
            outputs = new List<RenderPassOutput>();
        }
    }

    [Serializable]
    public class ShaderInfo {
        public string Name { get { return name; } }

        public string id;
        public string date;
        public int viewed;
        public string name;
        public string description;
        public int likes;
        public string published;
        public string[] tags;
    }

    [Serializable]
    public class ShaderData {
        public string Ver { get { return ver; } }
        public RenderPassData ImageRenderpass {
            get {
                return renderpass.Find((e) => { return e.type == "image"; });
            }
        }
        public List<RenderPassInput> Inputs { get { return ImageRenderpass.inputs; } }
        public ShaderInfo Info { get { return info; } }

        public string ver;
        public ShaderInfo info;
        public List<RenderPassData> renderpass;

        public ShaderData() {
            info = new ShaderInfo() { name = "a new shader",id = Guid.NewGuid().ToString("N") };
            renderpass = new List<RenderPassData>();
            renderpass.Add(new RenderPassData() { code = ResourceLoader.LoadTextFile(Setting.ShaderToyShaderDefaultPath),name = "Image",type = "image"});
        }

        public ShaderData Clone() {
            var obj = JsonMapper.ToObject<ShaderData>(JsonMapper.ToJson(this));
            return obj;
        }
    }

    public class UserDataDS
    {
        public string userName;
        public string date;
        public int numShaders;
        public List<ShaderData> shaders;

        public UserDataDS()
        {
            shaders = new List<ShaderData>();
        }
    }

    [Serializable]
    public class UserData
    {
        private string m_filePath = null;
        private UserDataDS m_ds = null;

        private static UserData s_instance = null;
        public static UserData Instance { get { return s_instance; } }

        public event Action EventOnShaderUpdated;

        private int ShaderSorter(ShaderData shader1,ShaderData shader2)
        {
            return string.Compare(shader1.Info.Name, shader2.Info.Name);
        }

        public UserData(string filePath)
        {
            m_filePath = filePath;
            string content = ResourceLoader.LoadTextFile(filePath);
            if (content == null)
            {
                Console.WriteLine(string.Format("{0} not exit", filePath));
                m_ds = new UserDataDS();
            }
            else
            {
                m_ds = JsonMapper.ToObject<UserDataDS>(content);
                m_ds.shaders.Sort(ShaderSorter);
            }
        }

        public static void CreateInstance(string filePath)
        {
            s_instance = new UserData(filePath); 
        }

        public List<ShaderData> GetShaders()
        {
            return m_ds.shaders;
        }

        public void DeleteShader(string name)
        {
            var targetIndex = m_ds.shaders.FindIndex((shader) => { return shader.Info.Name == name; });
            if (targetIndex != -1)
            {
                m_ds.shaders.RemoveAt(targetIndex);
                Save();
                if (EventOnShaderUpdated != null)
                    EventOnShaderUpdated();
            }
        }

        public void UpdateShader(ShaderData shader)
        {
           var target = m_ds.shaders.Find((elem) => { return elem.Info.Name == shader.Info.Name; });
            if (target != null)
            {
                m_ds.shaders.Remove(target);
            }
            m_ds.shaders.Add(shader.Clone());
            m_ds.shaders.Sort(ShaderSorter);
            Save();
            if (EventOnShaderUpdated != null)
                EventOnShaderUpdated();
        }

        public bool AddShader(ShaderData newShader, out string error)
        {
            error = null;
            foreach(var shader in m_ds.shaders)
            {
                if(shader.Info.Name == newShader.Info.Name)
                {
                    error = "名字已存在";
                    return false;
                }
            }
            m_ds.shaders.Add(newShader);
            m_ds.shaders.Sort(ShaderSorter);
            if (EventOnShaderUpdated != null)
                EventOnShaderUpdated();
            Save();
            return true;
        }

        private void Save()
        {
            var p = m_filePath;
            string json = JsonMapper.ToJson(m_ds);
            var stream = File.CreateText(p);
            stream.Write(json);
            stream.Close();
            Console.WriteLine(string.Format("save to {0} success", p));
        }
    }
}
