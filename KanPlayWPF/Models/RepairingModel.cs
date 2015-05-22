using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace KanPlayWPF.Models
{
    public enum ReparingState
    {
        NotSet,
        None,
        Repairing,
    }
        
    public class RepairingModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        public static string getRepairingString()
        {
            return "渠";
        }
    }
}
