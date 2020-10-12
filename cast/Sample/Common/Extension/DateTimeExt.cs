using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extension
{

    public static class DateTimeExt
    {
        /// <summary>  
        /// 时间戳Timestamp转换成日期  
        /// </summary>  
        /// <param name="timeStamp"></param>  
        /// <returns></returns>  
        public static DateTime GetDateTime(this int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)timeStamp * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return targetDt;
        }

        /// <summary>
        /// 日期转timespan
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(this DateTime time)
        {
            return time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }

    }
}
