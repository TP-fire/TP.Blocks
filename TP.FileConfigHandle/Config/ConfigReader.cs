using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TP.FileConfigHandle.Config {
    /// <summary>
    /// App.config 配置文件读取
    /// </summary>
    public class ConfigReader {

        /// <summary>
        /// 读取 AppSettings 下的配置信息
        /// </summary>
        /// <param name="key">设定的参数key</param>
        /// <returns>返回设定</returns>
        public static String getAppSetting(String key) { 
            return ConfigurationManager.AppSettings[key]; 
        }
        /// <summary>
        /// 读取 AppSettings 下的配置信息并返回 String[]  数组
        /// </summary>
        /// <param name="key">设定的参数key</param>
        /// <returns>返回设定</returns>
        public static String[] getAppSettingArr(String key) { 
            return ConfigurationManager.AppSettings[key].Split(','); 
        }
        /// <summary>
        /// 读取 AppSettings 下的配置信息并返回 int 数字
        /// </summary>
        /// <param name="key">设定的参数key</param>
        /// <returns>返回设定</returns>
        public static int getAppSettingInt(String key) { 
            return Convert.ToInt32(ConfigurationManager.AppSettings[key]);
        }
    }
}
