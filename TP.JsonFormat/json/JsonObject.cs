using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TP.JsonFormat.json {
    /// <summary>
    /// JSON字符串对象（直接操作JSON字符串）
    /// </summary>
    public class JsonObject {
        /// <summary>
        /// 初始化JSON
        /// </summary>
        public String json { set; get; }
        /// <summary>
        /// 当前选中Json 字符串（就是 . 出来的）
        /// </summary>
        public String value { set; get; }
        /// <summary>
        /// value值在json中定位
        /// </summary>
        public int index { set; get; }
        /// <summary>
        /// 追踪检索路径
        /// </summary>
        public String router { set; get; }
        /// <summary>
        /// 要返回的value值在 json 中定位
        /// </summary>
        public int returnIndex { set; get; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="json"></param>
        public JsonObject(String json) {
            json = trimSpace(json);
            this.json = json;
            this.value = json;
            this.index = 0;
            this.returnIndex = 0;
        }

        private String trimSpace(string json) {
            if (json.LastIndexOf('"')==-1) { 
                return json;
            }
            StringBuilder sb = new StringBuilder();
            Boolean markFlag = false;
            foreach (Char item in json) {
                if (item == '"' && markFlag == true) {
                    markFlag = false;
                } else if (item == '"' && markFlag == false) {
                    markFlag = true;
                }
                if (item == ' ' && markFlag == false) {
                    continue;
                }
                sb.Append(item);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 当前JSON 对象为数组 [] 的时候，传入数字字符串，以数字 0 为数组中第一个对象，获取第key +1 个对象
        /// 当前JSON 对象是 {} 对象集合的时候,传入键值获取value值
        /// </summary>
        /// <param name="key"> 键 / 序列 </param>
        /// <returns></returns>
        public JsonObject this[String key] {
            get {
                String router = this.router + key + ',';
                StringBuilder sb = new StringBuilder();
                StringBuilder checkKey = new StringBuilder();
                int braces = 0;  //大括号
                int bracesIndex = 0;
                int bracket = 0; // 中括号
                int bracketIndex = 0;
                Boolean keyFlag = false;
                Boolean keyInFlag = false;
                Boolean valueFlag = false;
                Boolean valueInlag = false;
                Boolean returnFlag = false;
                // 反斜杠转译字符
                Boolean turnFlag = false;
 
                for (int i = 0; i < value.Length; i++) {
                    Char item = value[i];
                    if (item == ' ' && keyInFlag == false  && returnFlag == false) {
                        continue;
                    }
                    if (item == '[') {
                        if (i == 0) {
                            if (!IsNumber(key)) {
                                throw new Exception(" 应该填写数字字符串，以数字 0 为数组中第一个对象 开始获取数组中第 key+1 个对象！");
                            } else {
                                bracesIndex = Convert.ToInt32(key);
                                bracketIndex = 1;
                            }
                        }
                        bracket++;
                    }
                    if (item == '{') {
                        braces++;
                        bracesIndex--;
                        if (i == 0) {
                            keyFlag = true;
                            checkKey.Clear();
                        }
                    }
                    if (bracesIndex == -1 && bracket == 1 && bracketIndex == 1 && valueFlag == false) {
                        valueFlag = true;
                        returnFlag = true;
                        returnIndex = index + i;
                    } else if ((item == ',' || value[i] == ']') && bracesIndex <= -1 && bracket == 1 && braces == 0 && bracketIndex == 1) {
                        JsonObject jb = new JsonObject(sb.ToString().Trim());
                        jb.json = json;
                        jb.index = returnIndex;
                        jb.router = router;
                        return jb;
                    }
                    if (item == '\\' && !turnFlag) { 
                        turnFlag = true;
                        continue;
                    } else if (item == '"' && braces == 1 && keyInFlag == false && keyFlag == true && turnFlag == false && bracketIndex == 0) {
                        keyInFlag = true;
                    } else if (item == '"' && braces == 1 && keyInFlag == true && keyFlag == true && turnFlag == false && bracketIndex == 0) {
                        keyInFlag = false;
                    } else if (item == ':' && braces == 1 && keyInFlag == false && keyFlag == true) {
                        keyFlag = false;
                        valueFlag = true;
                        if (checkKey.ToString() == key) {
                            returnFlag = true;
                            returnIndex = index + i + 1;
                        }
                    } else if (item == '"' && braces == 1 && valueFlag == true && valueInlag == false && turnFlag == false && bracketIndex == 0) {
                        valueInlag = true;
                    } else if (item == '"' && braces == 1 && valueFlag == true && valueInlag == true && turnFlag == false && bracketIndex == 0) {
                        valueInlag = false;
                    }else if ((item == ',' || value[i] == '}') && braces == 1 && valueFlag == true && valueInlag == false && bracket == 0) {
                        valueFlag = false;
                        keyFlag = true;
                        checkKey.Clear();
                        if (returnFlag) {
                            JsonObject jb = new JsonObject(sb.ToString());
                            jb.json = json;
                            jb.index = returnIndex;
                            jb.router = router;
                            return jb;
                        }
                    } else if (keyInFlag) {
                        checkKey.Append(item);
                    } else if (valueFlag && returnFlag) {
                        sb.Append(item);
                    }
                    if (item == ']' && keyInFlag == false && valueInlag == false) {
                        bracket--;
                    }
                    if (item == '}' && keyInFlag == false && valueInlag == false) {
                        braces--;
                    }
                    if(turnFlag) { 
                        turnFlag = false;    
                    }
                }
                return new JsonObject("");
            }
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="values"> 为传入的基本数据类型String int 等等</param>
        /// <returns></returns>
        public JsonObject setValue(Object values) {
            String value = values.ToString();
            if (value == "True") { value = "true"; }
            if (value == "False") { value = "false"; }
            JsonObject jo = new JsonObject(this.value);
            jo.json = this.json;
            jo.index = this.index;
        on: if (jo.json[jo.index] == ' ') {
                jo.index++;
                goto on;
            }
            if (jo.json[jo.index] == '"') {
                jo.json = jo.json.Remove(jo.index, this.value.Length + 2);
                jo.json = jo.json.Insert(jo.index, '"' + value + '"');
            } else {
                jo.json = jo.json.Remove(jo.index, this.value.Length);
                jo.json = jo.json.Insert(jo.index, value);
            }
            jo.value = value;
            JsonObject tmp = backLevel(jo);
            return tmp;
        }
        /// <summary>
        /// 返回上一阶
        /// </summary>
        /// <param name="jo"></param>
        /// <returns></returns>
        public JsonObject backLevel(JsonObject jo) {
            String[] arr = this.router.Split(',');
            JsonObject jsonObject = new JsonObject(jo.json);
            for (int i = 0; i < arr.Length - 2; i++) {
                jsonObject = jsonObject[arr[i]];
            }
            return jsonObject;
        }
        /// <summary>
        /// 返回当前阶层（如为数组，中包含的数组对象）
        /// </summary>
        /// <returns></returns>
        public int getArrCounts() { 
            if(value.Length <= 2) { 
                return 0;
            }
            string keyWord = "{";
            int index = 0;
            int count = 0;
            if(value.LastIndexOf('{') == -1) { 
                keyWord = ",";
                count++;
            }
            while ((index = value.IndexOf(keyWord,index)) != -1){
                count++;
                index = index + keyWord.Length;
            }
            return count;
        }
        /// <summary>
        /// 判断传值是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Boolean IsNumber(string str) {
            string regextext = @"^(-?\d+)(\.\d+)?$";
            Regex regex = new Regex(regextext, RegexOptions.None);
            return regex.IsMatch(str.Trim());
        }
        //
        private String trimQuotation(String str) {
            if (str.First() == '"' && str.Last() == '"') {
                str = str.Substring(1, str.Length - 2);
            }
            return str;
        }
    }
}
