using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KanPlayWPF.ControlBase
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    abstract public class KWindowBase : Window
    {
        public KWindowBase()
        {
            LoadWindowPos();

            this.StateChanged += new EventHandler(onWindowStateChanged);
            this.Activated += KWindowBase_Activated;

            this.Closed += KWindowBase_Closed;
        }

        void KWindowBase_Closed(object sender, EventArgs e)
        {
            SaveWindowPos();
        }

        void KWindowBase_Activated(object sender, EventArgs e)
        {
            activateAllWindows();
        }

        private void onWindowStateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                minimumAllWindows();
            }
            else if (this.WindowState == System.Windows.WindowState.Normal)
            {
                restoreAllWindows();
            }
        }

        private void shutDownApplication()
        {
            Application.Current.Shutdown();
        }

        private void minimumAllWindows()
        {
            foreach (Window window in Application.Current.Windows)
            {
                window.WindowState = System.Windows.WindowState.Minimized;
            }
        }

        private void restoreAllWindows()
        {
            //TODO check subWindowHideState
            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsVisible)
                {
                    window.WindowState = System.Windows.WindowState.Normal;
                }
            }
        }

        private void activateAllWindows()
        {
            //TODO check subWindowHideState
            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsVisible)
                {
                    window.Activate();
                }
            }
        }

        protected virtual void onCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            //TODO: add confirm dialog
            shutDownApplication();
        }

        protected virtual void onMinimumButtonClicked(object sender, RoutedEventArgs e)
        {
            minimumAllWindows();
        }


        abstract protected void LoadWindowPos();
        abstract protected void SaveWindowPos();
    }
}
