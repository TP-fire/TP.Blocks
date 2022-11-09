[TOC]

#### 时间组件（TP在英雄联盟里面是支援的意思）

##### 一、使用

​	本功能插件使用了非静态类，所以使用的时候需要创建类对象

- ​	在管理nuget程序包界面搜索，TP.DateFormat，选择最新版本安装

- ​    在类中方法外创建对象以使用

  ```c#
  private ConvertDateToStr cdt = new ConvertDateToStr();
  ```

  或者 直接创建对象

  ```c#
  ConvertDateToStr cdt2 = new ConvertDateToStr();
  int month = cdt2.currentMonth();
  ```

  来使用

##### 二、功能

- 类 **ConvertDateToStr** 获取指定或特定时间 的 指定字符串
  - `int currentSecond()` 获取当前秒针数
  - `int currentMinute()`获取当前分钟数
  - `int currentHour() `获取当前小时数
  - `int currentDay()`获取当前天为每月的几号
  - `int currentMonth()` 获取当前月
  - `int currentYear()`获取当前年份
  - `String currentDayStr()`获取当天凌晨时间字符串
  - `String yesterdayStr()`获取昨天凌晨时间字符串
  - `String tomorrowStr()`获取明天凌晨时间
  - `String currentDateTimeStr(String endStr = null)`<u>返回当前时间字符串</u>
    - endStr：可填写 hour，minute，second ，或者不填 ，eg：默认返回当前时间字符串 2021-12-22 13:14:11 ，传参endStr 'hour' 时，返回 2021-12-22 13:00:00
  - `currentDateAndHourAdd(int hour,Boolean isNull = false,Boolean isZero = true)`<u>当前小时加上多少个小时</u>
    - hour： 当前小时加上多少个小时 
    - isNull：小时之后的时间数值是否去除 eg：true(2021-09-09 08)  false(2021-09-09 08:00:00)  isNull 为true时 isZero 设定无效
    - isZero：小时之后的数据是否为0
  - `String targetDate(int dayAdd,Boolean isNull = false,Boolean isZero = true)`<u>在当前时间加上 dayAdd  个天数之后， 返回字符串时间</u>  eg：2021-09-09 00:00:00
    - dayAdd：在当前时间上加上几天
    - isNull：天之后的时间数值是否去除 eg：true(2021-09-09)  false(2021-09-09 00:00:00)  isNull 为true时 isZero 设定无效
    - isZero：天之后的时间数值是否为 00:00:00 eg：true(2021-09-09 00:00:00)  false(2021-09-09 07:11:08)
  - `String targetDateAndHour(int dayAdd, int hourSet,Boolean isNull = false,Boolean isZero = true)`<u>在当前时间加上 dayAdd  天之后，设定小时为  hourSet  ，然后返回字符串</u> eg：2021-11-02 16:37:10     dayAdd = -1 hourSet = 8  结果 2021-11-01 08:00:00
    - dayAdd ：当前时间加上 dayAdd 天
    - hourSet ：设置小时为 hourSet
    - isNull ：小时之后的时间数值是否去除 eg：true(2021-09-09 07)  false(2021-09-09 07:00:00)  isNull 为true时 isZero 设定无效
    - isZero ：小时之后的分秒是否为 设为 00:00 eg：true(2021-09-09 08:00:00)  false(2021-09-09 08:11:08)
  - `String targetDateAndHourAndMin(int dayAdd, int hourSet,int minSet,Boolean isNull = false,Boolean isZero = true)`在当前时间加上 dayAdd  <u>天之后，设定小时为  hourSet  ，设定分钟为minSet 然后返回字符串</u> eg：2021-11-02 16:37:10     dayAdd = -1 hourSet = 8 minSet = 30  结果 2021-11-01 08:30:00
    - dayAdd ：当前时间加上 dayAdd 天
    - hourSet ：设置小时为 hourSet
    - minSet ：设置分钟为 minSet
    - isNull :  分钟之后的时间数值是否去除 eg：true(2021-09-09 08:30)  false(2021-09-09 08:30:00)  isNull 为true时 isZero 设定无效
    - isZero : 分钟之后的分秒是否为 设为 00 eg：true(2021-09-09 08:30:00)  false(2021-09-09 08:30:02)  isNull 为true时 isZero 设定无效

##### 三、同比增加

- `currentDateAndHourAdd(int hour,Boolean isNull = false,Boolean isZero = true)`<u>当前小时加上多少个小时</u>
  - hour： 当前小时加上多少个小时 
  - isNull：小时之后的时间数值是否去除 eg：true(2021-09-09 08)  false(2021-09-09 08:00:00)  isNull 为true时 isZero 设定无效
  - isZero：小时之后的数据是否为0

##### 四、同比修改

​	无

##### 五、同比修复

​	无

​	

