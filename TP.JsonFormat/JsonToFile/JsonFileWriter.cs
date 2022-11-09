using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TP.JsonFormat.ConvertToJson;

namespace TP.JsonFormat.JsonToFile {
    /// <summary>
    /// 将json对象存储到文件中
    /// </summary>
    public class JsonFileWriter {
        /// <summary>
        /// 将DataTable 对象转化为JSON 并存储到指定文件中！
        /// </summary>
        /// <param name="filePath">将要存储的文件路径，无需文件存在</param>
        /// <param name="dt">DataTable对象</param>
        /// <returns></returns>
        public String writeJsonFile(String filePath,DataTable dt) { 
            ObjectToJson objectToJson = new ObjectToJson();
            String json = objectToJson.dataTableToJson(dt);

            if(!File.Exists(filePath)) { 
                File.Create(filePath).Close();
            }
            if(File.Exists(filePath)) {
                StreamWriter streamWriter = new StreamWriter(filePath, append: false, Encoding.Default);
                streamWriter.WriteLine(json);
                streamWriter.Close();
            }
            return json.ToString();
        }
    }
}
