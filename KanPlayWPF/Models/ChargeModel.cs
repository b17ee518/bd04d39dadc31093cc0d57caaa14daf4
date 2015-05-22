using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows.Media;

namespace KanPlayWPF.Models
{
    public enum ChargeState
    {
        Full,
        GreaterThanHalf,
        Half,
        Quarter,
        Empty,
    }

    public class ChargeModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        public static ChargeState getChargeStateFromValue(int curVal, int maxVal)
        {
            Double val = (Double)curVal / (Double)maxVal;
            if (val <= 0.0)
            {
                return ChargeState.Empty;
            }
            else if (val < 0.25)
            {
                return ChargeState.Quarter;
            }
            else if (val < 0.5)
            {
                return ChargeState.Half;
            }
            else if (val < 1.0)
            {
                return ChargeState.GreaterThanHalf;
            }
            return ChargeState.Full;
        }

        public static SolidColorBrush getChargeColorBrushFromState(ChargeState chargeState)
        {
            TextBrushType type = TextBrushType.White;
            switch (chargeState)
            {
                case ChargeState.GreaterThanHalf:
                    type = TextBrushType.Yellow;
                    break;
                case ChargeState.Half:
                    type = TextBrushType.Orange;
                    break;
                case ChargeState.Quarter:
                    type = TextBrushType.Red;
                    break;
                case ChargeState.Empty:
                    type = TextBrushType.Blue;
                    break;
            }
            return BrushModel.getTextColorStaticResource(type);
        }
    }
}
