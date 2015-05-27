using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows.Media;


namespace KanPlayWPF.Models
{
    public enum ProgressBarState
    {
        Empty,
        MoreThanOneHourLeft,
        LessThanOneHourLeft,
        Done,
    }

    public class ProgressBarModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
    }
}
