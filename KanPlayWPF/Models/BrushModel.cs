using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows;
using System.Windows.Media;

namespace KanPlayWPF.Models
{
    public enum TextBrushType
    {
        White,
        Yellow,
        Orange,
        Red,
        Gray,
        Blue,
        Aqua,
    }
    public class BrushModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        static public SolidColorBrush getWhiteColorBrush()
        {
            return getTextColorStaticResource(TextBrushType.White);
        }
        static public SolidColorBrush getTextColorStaticResource(TextBrushType type)
        {
            string resourceName = "WhiteTextBrush";
            switch (type)
            {
                case TextBrushType.Yellow:
                    resourceName = "YellowTextBrush";
                    break;
                case TextBrushType.Orange:
                    resourceName = "OrangeTextBrush";
                    break;
                case TextBrushType.Red:
                    resourceName = "RedTextBrush";
                    break;
                case TextBrushType.Gray:
                    resourceName = "GrayTextBrush";
                    break;
                case TextBrushType.Blue:
                    resourceName = "BlueTextBrush";
                    break;
                case TextBrushType.Aqua:
                    resourceName = "AquaTextBrush";
                    break;
            }
            return Application.Current.FindResource(resourceName) as SolidColorBrush;
        }

        static public SolidColorBrush getExpeditionTextColorStaticResource(int areaId)
        {
            string resourceName = string.Format("Expedition{0}TextBrush", areaId);
            Object res = Application.Current.TryFindResource(resourceName);
            if (res == null)
            {
                res = Application.Current.FindResource("ExpeditionExTextBrush");
            }
            return res as SolidColorBrush;
        }

        static public SolidColorBrush getProgressBarColorStaticResource(ProgressBarState state)
        {
            string resourceName = "BrownProgressBrush";
            switch (state)
            {
                case ProgressBarState.LessThanOneHourLeft:
                    resourceName = "LimeProgressBrush";
                    break;
                case ProgressBarState.Done:
                    resourceName = "GreenProgressBrush";
                    break;
            }
            return Application.Current.FindResource(resourceName) as SolidColorBrush;
        }
    }
}
