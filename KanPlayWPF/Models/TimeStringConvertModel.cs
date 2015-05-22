using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace KanPlayWPF.Models
{
    public class TimeStringConvertModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        static public string convertMSToString(Int64 ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            string str = string.Format("{0:D2} : {1:D2} : {2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds);
            return str;
        }
    }
}
