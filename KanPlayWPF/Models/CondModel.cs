using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows.Media;
using System.Windows;

namespace KanPlayWPF.Models
{
    public enum CondState
    {
        NotSet,
        Kira,
        Normal,
        Slight,
        Moderate,
        Severe,
    }

    public class CondModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        static public CondState getCondStateFromCond(int cond)
        {
            if (cond < 20)
            {
                return CondState.Severe;
            }
            else if (cond < 30)
            {
                return CondState.Moderate;
            }
            else if (cond < 40)
            {
                return CondState.Slight;
            }
            else if (cond < 50)
            {
                return CondState.Normal;
            }
            return CondState.Kira;
        }

        static public SolidColorBrush getCondColorBrushFromCondState(CondState condState)
        {
            TextBrushType type = TextBrushType.White;
            switch (condState)
            {
                case CondState.Kira:
                    type = TextBrushType.Yellow;
                    break;
                case CondState.Slight:
                    type = TextBrushType.Gray;
                    break;
                case CondState.Moderate:
                    type = TextBrushType.Orange;
                    break;
                case CondState.Severe:
                    type = TextBrushType.Red;
                    break;
            }
            return BrushModel.getTextColorStaticResource(type);
        }
    }
}
