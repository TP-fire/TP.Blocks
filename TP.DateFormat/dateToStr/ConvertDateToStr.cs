
using System;
using System.Text;

namespace TP.DateFormat.dateToStr {
    /// <summary>
    /// 根据指定时间获取你需要的时间字符串
    /// </summary>
    public class ConvertDateToStr {
        /// <summary>
        /// 获取当前秒针数
        /// </summary>
        /// <returns></returns>
        public int currentSecond() {
            return DateTime.Now.Second;
        }
        /// <summary>
        /// 获取当前分钟数
        /// </summary>
        /// <returns></returns>
        public int currentMinute() {
            return DateTime.Now.Minute;
        }
        /// <summary>
        /// 获取当前小时数
        /// </summary>
        /// <returns></returns>
        public int currentHour() {
            return DateTime.Now.Hour;
        }
        /// <summary>
        /// 获取当前天为每月的几号
        /// </summary>
        /// <returns></returns>
        public int currentDay() {
            return DateTime.Now.Day;
        }
        /// <summary>
        /// 获取当前月
        /// </summary>
        /// <returns></returns>
        public int currentMonth() {
            return DateTime.Now.Month;
        }
        /// <summary>
        /// 获取当前年份
        /// </summary>
        /// <returns></returns>
        public int currentYear() {
            return DateTime.Now.Year;
        }
        /// <summary>
        /// 获取当天凌晨时间
        /// </summary>
        /// <returns></returns>
        public String currentDayStr() {
            DateTime date = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" 00:00:00");

            return sb.ToString();
        }

        /// <summary>
        /// 获取昨天凌晨时间
        /// </summary>
        /// <returns></returns>
        public String yesterdayStr() {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" 00:00:00");

            return sb.ToString();
        }

        /// <summary>
        /// 获取明天凌晨时间
        /// </summary>
        /// <returns></returns>
        public String tomorrowStr() {
            DateTime date = DateTime.Now;
            date = date.AddDays(1);
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" 00:00:00");

            return sb.ToString();
        }
        /// <summary>
        /// 返回当前时间串
        /// </summary>
        /// <param name="endStr">可填写 hour，minute，second ，或者不填 ，eg：默认返回当前时间字符串 2021-12-22 13:14:11 ，传参endStr 'hour' 时，返回 2021-12-22 13:00:00</param>
        /// <returns></returns>
        public String currentDateTimeStr(String endStr = null) { 
            DateTime date = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            switch (endStr) { 
                case "hour":
                    sb.Append(" ");
                    sb.Append(date.Hour < 10 ? "0" : "");
                    sb.Append(date.Hour);
                    sb.Append(":00:00");
                    break;
                case "minute":
                    sb.Append(" ");
                    sb.Append(date.Hour < 10 ? "0" : "");
                    sb.Append(date.Hour);
                    sb.Append(":");
                    sb.Append(date.Minute < 10 ? "0" : "");
                    sb.Append(date.Minute);
                    sb.Append(":00");
                    break;
                case "second":
                    sb.Append(" ");
                    sb.Append(date.Hour < 10 ? "0" : "");
                    sb.Append(date.Hour);
                    sb.Append(":");
                    sb.Append(date.Minute < 10 ? "0" : "");
                    sb.Append(date.Minute);
                    sb.Append(":");
                    sb.Append(date.Second < 10 ? "0" : "");
                    sb.Append(date.Second);
                    break;
                default:
                    sb.Append(" ");
                    sb.Append(date.Hour < 10 ? "0" : "");
                    sb.Append(date.Hour);
                    sb.Append(":");
                    sb.Append(date.Minute < 10 ? "0" : "");
                    sb.Append(date.Minute);
                    sb.Append(":");
                    sb.Append(date.Second < 10 ? "0" : "");
                    sb.Append(date.Second);
                break;
            }
            return sb.ToString();
        }
        /// <summary>
        /// 在当前时间加上 hour  个小时之后， 返回字符串时间  eg：2021-09-09 08:00:00 
        /// </summary>
        /// <param name="hour">当前小时加上多少个小时</param>
        /// <param name="isNull">小时之后的时间数值是否去除 eg：true(2021-09-09 08)  false(2021-09-09 08:00:00)  isNull 为true时 isZero 设定无效</param>
        /// <param name="isZero">小时之后的数据是否为0</param>
        /// <returns></returns>
        public String currentDateAndHourAdd(int hour,Boolean isNull = false,Boolean isZero = true) { 
            DateTime date = DateTime.Now;
            date = date.AddHours(hour);
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" ");
            sb.Append(date.Hour < 10 ? "0" : "");
            sb.Append(date.Hour);
            if (isNull) { 
                // 不执行后续逻辑
            }else if (isZero) {
                sb.Append(":00:00");
            } else {
                sb.Append(":");
                sb.Append(date.Minute < 10 ? "0" : "");
                sb.Append(date.Minute);
                sb.Append(":");
                sb.Append(date.Second < 10 ? "0" : "");
                sb.Append(date.Second);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 在当前时间加上 dayAdd  个天数之后， 返回字符串时间  eg：2021-09-09 00:00:00
        /// </summary>
        /// <param name="dayAdd">在当前时间上加上几天</param>
        /// <param name="isNull">天之后的时间数值是否去除 eg：true(2021-09-09)  false(2021-09-09 00:00:00)  isNull 为true时 isZero 设定无效</param>
        /// <param name="isZero">天之后的时间数值是否为 00:00:00 eg：true(2021-09-09 00:00:00)  false(2021-09-09 07:11:08)  </param>
        /// <returns></returns>
        public String targetDate(int dayAdd,Boolean isNull = false,Boolean isZero = true) {
            DateTime date = DateTime.Now.AddDays(dayAdd);
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10?"0":""); 
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            if (isNull) { 
                // 不执行后续逻辑
            }else if (isZero) {
                sb.Append(" 00:00:00");
            } else {
                sb.Append(" ");
                sb.Append(date.Hour < 10 ? "0" : "");
                sb.Append(date.Hour);
                sb.Append(":");
                sb.Append(date.Minute < 10 ? "0" : "");
                sb.Append(date.Minute);
                sb.Append(":");
                sb.Append(date.Second < 10 ? "0" : "");
                sb.Append(date.Second);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 在当前时间加上 dayAdd  天之后，设定小时为  hourSet  ，然后返回字符串 
        /// eg：2021-11-02 16:37:10     dayAdd = -1 hourSet = 8  结果 2021-11-01 08:00:00
        /// </summary>
        /// <param name="dayAdd">当前时间加上 dayAdd 天</param>
        /// <param name="hourSet">设置小时为 hourSet</param>
        /// <param name="isNull">小时之后的时间数值是否去除 eg：true(2021-09-09 07)  false(2021-09-09 07:00:00)  isNull 为true时 isZero 设定无效</param>
        /// <param name="isZero">小时之后的分秒是否为 设为 00:00 eg：true(2021-09-09 08:00:00)  false(2021-09-09 08:11:08)</param>
        /// <returns></returns>
        public String targetDateAndHour(int dayAdd, int hourSet,Boolean isNull = false,Boolean isZero = true) {
            DateTime date = DateTime.Now.AddDays(dayAdd);
            date = date.AddHours(hourSet - currentHour());
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" ");
            sb.Append(date.Hour < 10 ? "0" : "");
            sb.Append(date.Hour);
            if (isNull) { 
                // 不执行后续逻辑
            }else if (isZero) {
                sb.Append(":00:00");
            } else {
                sb.Append(":");
                sb.Append(date.Minute < 10 ? "0" : "");
                sb.Append(date.Minute);
                sb.Append(":");
                sb.Append(date.Second < 10 ? "0" : "");
                sb.Append(date.Second);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 在当前时间加上 dayAdd  天之后，设定小时为  hourSet  ，设定分钟为minSet 然后返回字符串 
        /// eg：2021-11-02 16:37:10     dayAdd = -1 hourSet = 8 minSet = 30  结果 2021-11-01 08:30:00
        /// </summary>
        /// <param name="dayAdd">当前时间加上 dayAdd 天</param>
        /// <param name="hourSet">设置小时为 hourSet</param>
        /// <param name="minSet">设置分钟为 minSet</param>
        /// <param name="isNull">分钟之后的时间数值是否去除 eg：true(2021-09-09 08:30)  false(2021-09-09 08:30:00)  isNull 为true时 isZero 设定无效</param>
        /// <param name="isZero">分钟之后的分秒是否为 设为 00 eg：true(2021-09-09 08:30:00)  false(2021-09-09 08:30:02)  isNull 为true时 isZero 设定无效</param>
        /// <returns></returns>
        public String targetDateAndHourAndMin(int dayAdd, int hourSet,int minSet,Boolean isNull = false,Boolean isZero = true) {
            DateTime date = DateTime.Now.AddDays(dayAdd);
            date = date.AddHours(hourSet - currentHour());
            date = date.AddMinutes(minSet- currentMinute());
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month < 10 ? "0" : "");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day < 10 ? "0" : "");
            sb.Append(date.Day);
            sb.Append(" ");
            sb.Append(date.Hour < 10 ? "0" : "");
            sb.Append(date.Hour);
            sb.Append(":");
            sb.Append(date.Minute < 10 ? "0" : "");
            sb.Append(date.Minute);
            if (isNull) { 
                // 不执行后续逻辑
            }else if (isZero) {
                sb.Append(":00");
            } else {
                sb.Append(":");
                sb.Append(date.Second < 10 ? "0" : "");
                sb.Append(date.Second);
            }
            return sb.ToString();
        }
    }
}
