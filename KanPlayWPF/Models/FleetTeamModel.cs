using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows.Media;

namespace KanPlayWPF.Models
{
    public enum FleetTeamState
    {
        NotSet,
        Normal,
        NeedChargeOrLowCond,
        AllKira,
        HaveKira,
    }
    public class FleetTeamModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        public static SolidColorBrush getFleetTeamColorBrushFromState(FleetTeamState fleetTeamState)
        {
            TextBrushType type = TextBrushType.White;
            switch (fleetTeamState)
            {
                case FleetTeamState.NeedChargeOrLowCond:
                    type = TextBrushType.Orange;
                    break;
                case FleetTeamState.AllKira:
                    type = TextBrushType.Yellow;
                    break;
                case FleetTeamState.HaveKira:
                    type = TextBrushType.Aqua;
                    break;
            }
            return BrushModel.getTextColorStaticResource(type);
            
        }
    }
}
