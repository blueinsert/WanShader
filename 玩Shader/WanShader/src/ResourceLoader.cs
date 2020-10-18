using System.IO;
using System.Reflection;

namespace bluebean.ShaderToyOffline
{
    /// <summary>
    /// A small helper class to load manifest resource files.
    /// </summary>
    public static class ResourceLoader
    {       
        public static string LoadTextFile(string textFilePath)
        {
            string res = null;
            if (File.Exists(textFilePath))
            {
                var file = File.OpenText(textFilePath);
                res = file.ReadToEnd();
                file.Close();
            }
            return res;
        }
    }
}
