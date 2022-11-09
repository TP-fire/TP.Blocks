using System;
using System.Collections.Generic;
using System.Text;

namespace TP.StringFormat.sqlGenerate {
    public class SqlGenerate {
        /// <summary>
        /// 直接创建一个公共的StringBuilder 成员变量
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        /// 讲数据转化为 sql 语句中的 in 条件下的括号中的参数 eg：[1,2,3]  => '1','2','3'
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public String createInStr(String[] arr) {
            sb.Clear();
            for(int i = 0; i < arr.Length; i++) {
				sb.Append('\'');
				sb.Append(arr[i]);
				sb.Append('\'');
				sb.Append(',');
            }
            return sb.ToString();
        }
    }
}
