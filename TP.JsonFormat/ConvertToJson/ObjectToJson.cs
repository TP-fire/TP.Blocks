using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TP.JsonFormat.ConvertToJson {
    /// <summary>
    /// 将数据，集合，对象类型的东西转化为JSON字符串
    /// </summary>
    public class ObjectToJson {

        /// <summary>
        /// 将传入的 Dictionary  转化为JSON 字符串
        /// </summary>
        /// <param name="dic">传入一个 Dictionary  </param>
        /// <returns></returns>
        public String convertDicJson(Dictionary<String ,Object> dic) { 
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\n");
            foreach (KeyValuePair<String,Object> item in dic) {
                sb.Append("\"");
                sb.Append(item.Key);
                sb.Append("\": \"");
                sb.Append(item.Value);
                sb.Append("\",");
                sb.Append("\n");
            }
            sb = sb.Remove(sb.Length-2,1);
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 将DataTable 转化为 JSON 字符串
        /// </summary>
        /// <returns></returns>
        public String dataTableToJson(DataTable dt) { 
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            for (int i = 0; i < dt.Rows.Count; i++) { 
                sb.Append('{');
                for (int j = 0; j < dt.Columns.Count; j++) { 
                    sb.Append('"');
                    sb.Append(dt.Columns[j].ColumnName);
                    sb.Append("\": \"");
                    sb.Append(dt.Rows[i][j]);
                    sb.Append('"');
                    sb.Append(',');
                }
                sb = sb.Remove(sb.Length-1,1);
                sb.Append('}');
                sb.Append(',');
            }
            sb = sb.Remove(sb.Length-1,1);
            sb.Append(']');
            return sb.ToString();
        }

    }
}
