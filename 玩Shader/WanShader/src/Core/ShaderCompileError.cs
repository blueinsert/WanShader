using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bluebean.ShaderToyOffline
{
    class ShaderCompileError:Exception
    {
        private string m_passName;
        private string m_error;
        public string Error { get { return m_error; } }
        public string PassName { get { return m_passName; } }

        public ShaderCompileError(string error,string passName) {
            m_error = error;
            m_passName = passName;
            string pattern = @"(\d+)\((\d+)\)";//()代表一个捕获组，整体是第一个捕获组
            //progarmId替换成passName,错误行号替换为相对值
            m_error = Regex.Replace(m_error, pattern, (match) =>
            {
                var errorLine = int.Parse(match.Groups[2].Value) - 14;
                return string.Format("{0}({1})", m_passName, errorLine);
            });
        }
    }
}
