using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP.FileManage.fileLog {
    /// <summary>
    /// 添加本地日志文件
    /// </summary>
    public class LoggingInLocal {
        /// <summary>
        /// 日志部分，按年区分，一年一个文件夹，每天一个日志文件
        /// </summary>
        /// <param name="directoryName">日志文件相对路径，在项目文件夹下创建一个文件夹</param>
        /// <param name="type">日志类型</param>
        /// <param name="content">需要记录的日志内容</param>
        public void writeLogs(string directoryName, string type, string content) {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path)) {
                path = AppDomain.CurrentDomain.BaseDirectory + directoryName;
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                path = path + "/" + DateTime.Now.ToString("yyyy");
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                path = path + "/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path)) {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                if (File.Exists(path)) {
                    StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + type + "-->" + content);
                    //  sw.WriteLine("----------------------------------------");
                    sw.Close();
                }
            }
        }
    }
}
