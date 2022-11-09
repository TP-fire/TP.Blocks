[TOC]

#### 数据库连接

##### 一、使用

```
本功能插件使用了静态类，所以使用的时候很方便
```

- 在管理nuget程序包界面搜索，TP.OracleManage，选择最新版本安装
- 直接创建对象

```c#
OracleExecute orc = OracleExecute.openConn(dbStr); // 这里只是创建数据库连接对象，具体方法具体实现
```

来使用

##### 二、功能

​	类 **OracleExecute**  创建数据库链接执行数据库相关操作

1.  `static OracleConnection OpenConn(String dbStr)` 根据指定 dbStr 连接串创建数据库连接，并返回OracleExecute对象
2.  `DataTable getDataTable(String sql)`执行指定sql 并返回 DataTable
3.  `int getNoDataTable(String sql)`执行指定  sql  并返回受影响的行数 
4.  `void CloseConn()`关闭数据库连接conn

##### 三、同比增加

无

##### 四、同比修改

1. 修改方法：`OracleConnection OpenConn(String dbStr)`  ==》 static OracleConnection OpenConn(String dbStr)  方法改为静态对象，由返回连接对象改为返回工具类对象，更加容易创建，使用更加方便，数据库连接改为使用工具类管理
2. 修改方法 `DataTable getDataTable(String sql ，OracleConnection con)` ==》`DataTable getDataTable(String sql)` 删除参数 OracleConnection 
3. 修改方法 `int getNoDataTable(String sql ，OracleConnection con)` ==》`int getNoDataTable(String sql)` 删除参数 OracleConnection 
4. 修改方法 `void CloseConn(OracleConnection con)` ==》`void CloseConn()` 删除参数 OracleConnection 

##### 五、同比修复

无

