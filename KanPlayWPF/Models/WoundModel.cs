using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows.Media;
using System.Windows;

namespace KanPlayWPF.Models
{
    public enum WoundState
    {
        None,               // hp full
        Minor,              // not full
        Slight,
        Moderate,
        Severe,
        Dead,
    }
    public class WoundModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        public static WoundState getWoundStateFromHP(int nowHp, int maxHp)
        {
            Double val = (Double)nowHp / (Double)maxHp;
            if (val <= 0.0)
            {
                return WoundState.Dead;
            }
            else if (val < 0.25)
            {
                return WoundState.Severe;
            }
            else if (val < 0.5)
            {
                return WoundState.Moderate;
            }
            else if (val < 0.75)
            {
                return WoundState.Slight;
            }
            else if (val < 1.0)
            {
                return WoundState.Minor;
            }
            return WoundState.None;
        }

        public static SolidColorBrush getWoundColorBrushFromWoundState(WoundState woundState)
        {
            TextBrushType type = TextBrushType.White;
            switch (woundState)
            {
                case WoundState.Minor:
                    type = TextBrushType.Gray;
                    break;
                case WoundState.Slight:
                    type = TextBrushType.Yellow;
                    break;
                case WoundState.Moderate:
                    type = TextBrushType.Orange;
                    break;
                case WoundState.Severe:
                    type = TextBrushType.Red;
                    break;
                case WoundState.Dead:
                    type = TextBrushType.Blue;
                    break;
            }
            return BrushModel.getTextColorStaticResource(type);
        }

        public static string getStateStringFromWoundState(WoundState woundState)
        {
            switch (woundState)
            {
                case WoundState.Slight:
                    return "小";
                case WoundState.Moderate:
                    return "中";
                case WoundState.Severe:
                    return "大";
                case WoundState.Dead:
                    return "沈";
            }
            return "";
        }
    }
}
