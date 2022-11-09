using System;
using System.IO;
using System.Text;

namespace TP.JsonFormat.FileToJson {
    /// <summary>
    /// 读取JSON 文件
    /// </summary>
    public class JsonFileReader {
        /// <summary>
        /// 读取txt文件内容
        /// </summary>
        /// <param name="Path">文件地址</param>
        public String readTxtContent(string Path){
            if(!File.Exists(Path)) { 
               return null;     
            };
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            String content;
            StringBuilder sb = new StringBuilder();
            while ((content = sr.ReadLine()) != null){
                sb.Append(content);
                //Console.WriteLine(content.ToString());
            }
            return sb.ToString();
        }
    }
}
