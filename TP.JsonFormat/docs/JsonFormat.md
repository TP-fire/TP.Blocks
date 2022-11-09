[TOC]

#### json组件

##### 一、使用

	本功能插件使用了非静态类，所以使用的时候需要创建类对象

- 在管理nuget程序包界面搜索，TP.JsonFormat，选择最新版本安装

- 直接创建对象

  ```c#
  JsonObject jb = new JsonObject(jsonStr); // jsonStr 为指定的Json字符串
  ```

  来使用

##### 二、功能

1. class  **JsonObject**
   通过创建对象来解析对象

   ###### 首先创建一个JSON 字符串  如下

   ```json
         	{
               "aa":"qwer",
               "bb":true,
               "cc":[
                       {
                           "aa":1,
                           "bb":12
                       },
                       {
                           "aa":13,
                           "bb":6
                       },
                       {
                           "a a":19,
                           "bb":"  1  "
                       }
               ]
       	}
   ```

   ###### 如下为demo代码，一些基本的查询和操作

   ```c#
   			//创建JSON 对象
               JsonObject jb = new JsonObject(result);
               // 根据键获取值
               JsonObject tmp2 = jb["aa"];
               String value1 = tmp2.value; //qwer
               //或者
               String value2 = jb["aa"].value; //qwer
   
               // 根据键获取值 多级获取
               JsonObject tmp3 = jb["cc"];
               // 键值对中的数组取值使用数字字符串 索引从0 开始
               JsonObject tmp4 = tmp3["1"]; 
               String value3 = tmp4["aa"].value; //13
               //或者
               String value4 = jb["cc"]["1"]["aa"].value; //13
   
               // 根据键修改值 （大括号，或者中括号包裹的信息叫做层级，你要查询的键值对，距最外层有几个括号就事第几层级）
               //第一层级键值对修改,返回第一层级对象本身
               JsonObject tmp5 = jb["aa"].setValue("rewq");
               JsonObject tmp6 = tmp5["bb"].setValue(false);
               String json2 = tmp6.json;
               //或者等同于
               JsonObject tmp7 = jb["aa"].setValue("rewq")["bb"].setValue(false);
               String json3 = tmp7.json;
   
               //根据键修改值 多层级修改
               //先获取多层级对象  jb 是第一层级（"{"）tmp8 是第二层级("[") tmp9 是第三层级("{")
               JsonObject tmp8 = jb["cc"];
               JsonObject tmp9 = tmp8["1"];
               JsonObject tmp10 = tmp9["aa"].setValue(100)["bb"].setValue(200);
               String json4 = tmp10.json;
               // 或者  
               JsonObject tmp11 = jb["cc"]["1"]["aa"].setValue(100)["bb"].setValue(200);
               String json5 = tmp11.json;
   ```

   ###### 以下为 json2  json3 json4 json5 的值

   ```json
   {
   "aa":"rewq",
   "bb":false,
   "cc":[
   {
   "aa":1,
   "bb":12
   },
   {
   "aa":13,
   "bb":6
   },
   {
   "a a":19,
   "bb":"  1  "
   }
   ]
   }
   #-------------------
   {
   "aa":"rewq",
   "bb":false,
   "cc":[
   {
   "aa":1,
   "bb":12
   },
   {
   "aa":13,
   "bb":6
   },
   {
   "a a":19,
   "bb":"  1  "
   }
   ]
   }
   #-------------------
   {
   "aa":"qwer",
   "bb":true,
   "cc":[
   {
   "aa":1,
   "bb":12
   },
   {
   "aa":100,
   "bb":200
   },
   {
   "a a":19,
   "bb":"  1  "
   }
   ]
   }
   #-------------------
   {
   "aa":"qwer",
   "bb":true,
   "cc":[
   {
   "aa":1,
   "bb":12
   },
   {
   "aa":100,
   "bb":200
   },
   {
   "a a":19,
   "bb":"  1  "
   }
   ]
   }
   ```

   - 方法：`int getArrCounts()` 返回当前阶层（如为数组，中包含的数组对象）

2. 类 **ObjectToJson**  将数据，集合，对象类型的东西转化为JSON字符串

   - 方法：`String ConvertDicJson(Dictionary<String ,Object> dic)` <u>将传入的 Dictionary  转化为JSON 字符串</u>
   - 方法： `String dataTableToJson(DataTable dt)` <u>将DataTable 转化为 JSON 字符串</u> 

3. 类 **JsonFileReader** 读取JSON 文件

   - 方法：`String ReadTxtContent(string Path)`	<u>读取txt文件内容</u>

4. 类 **JsonFileWriter** 将json对象存储到文件中

   - 方法：`String writeJsonFile(String filePath,DataTable dt)`<u>将DataTable 对象转化为JSON 并存储到指定文件中！</u>
     - filePath 将要存储的文件路径，无需文件存在
     - dt DataTable对象


##### 三、同比增加

无

##### 四、同比修改

无

##### 五、同比修复

无