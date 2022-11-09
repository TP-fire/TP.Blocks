[TOC]

##### 文件管理

###### 一、使用

本功能插件使用了非静态类，所以使用的时候需要创建类对象

- 在管理nuget程序包界面搜索，TP.DateFormat，选择最新版本安装

- 在类中方法外创建对象以使用

  ```
  private FileClear fc = new FileClear();
  ```

- 直接创建对象使用

  ```
  FileClear fc = new FileClear()
  ```

  []()

###### 二、功能

1. 类 **FileClean**  删除指定文件夹下的指定文件
   方法一：`DeleteOldFiles(String filePath, int days)`   // 删除文件夹 strDir 中 Days 天以前的文件
2. 类 **LoggingInLocal**  在指定文件夹目录上生成日志文件
   方法一：`WriteLogs(string directoryName, string type, string content)`   //日志部分，按年区分，在directoryName 文件夹下 ，一年一个文件夹，每天一个日志文件，每次换行写入数据，日期+ 类型（type）+  内容（content）



