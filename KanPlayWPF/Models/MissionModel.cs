using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace KanPlayWPF.Models
{
    public enum MissionTakenState
    {
        Unknown = 0,
        NotTaken = 1,
        Taken = 2,
        Completed = 3,
    }
    public enum MissionProgressState
    {
        Zero = 0,
        Half = 1,
        Eighty = 2,
        Completed,
    }
    public class MissionModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        public static string getMissionProgressStringFromValue(int progress, int takenflag)
        {
            if (takenflag == (int) MissionTakenState.Completed)
            {
                return "完遂";
            }
            if (takenflag != (int) MissionTakenState.Taken)
            {
                return "";
            }

            MissionProgressState state = (MissionProgressState)progress;
            switch (state)
            {
                case MissionProgressState.Zero:
                    return "0%";
                case MissionProgressState.Half:
                    return "50%";
                case MissionProgressState.Eighty:
                    return "80%";
                case MissionProgressState.Completed:
                    return "完遂";
            }
            return "";
        }
    }
}
