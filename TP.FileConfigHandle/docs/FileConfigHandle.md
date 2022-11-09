[TOC]

#### 文件管理

##### 一、使用

本功能插件使用了静态类

- 在管理nuget程序包界面搜索，TP.FileConfigHandle，选择最新版本安装

- 直接  类名 + 点  使用

  ```
  String value = ConfigReader.getConfig(key)
  ```

##### 二、功能

1. 类 **ConfigReader**  App.config 配置文件读取
   - `static String getConfig(String key)`   // 读取 AppSettings 下的配置信息
   - `static String[] getConfigArr(String key)` 	//读取 AppSettings 下的配置信息并返回 String[]  数组
   - `static int getConfigInt(String key)`               //读取 AppSettings 下的配置信息并返回 int 数字

##### 三、同比增加

无

##### 四、同比修改

1. 功能下所有的方法改为静态方法

##### 五、同比修复

无