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

using KanPlayWPF.ControlBase;
using System.Windows.Controls.Primitives;

namespace KanPlayWPF.Views
{
    /* 
     * ViewModelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedWeakEventListenerや
     * CollectionChangedWeakEventListenerを使うと便利です。独自イベントの場合はLivetWeakEventListenerが使用できます。
     * クローズ時などに、LivetCompositeDisposableに格納した各種イベントリスナをDisposeする事でイベントハンドラの開放が容易に行えます。
     *
     * WeakEventListenerなので明示的に開放せずともメモリリークは起こしませんが、できる限り明示的に開放するようにしましょう。
     */

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : KWindowBase
    {
        InfoMainWindow _infoWindow = null;

        static private MainWindow _mainWindow = null;
        static public MainWindow getMainWindow()
        {
            return _mainWindow;
        }

        public MainWindow()
        {
            _mainWindow = this;

            InitializeComponent();

            _infoWindow = new InfoMainWindow(this);
            _infoWindow.Show();
        }

        public void onInfoMainWindowClosed()
        {
            btnInfo.IsChecked = false;
        }

        private void onWeaponToggleClicked(object sender, RoutedEventArgs e)
        {
        }

        private void onTimerToggleClicked(object sender, RoutedEventArgs e)
        {

        }

        private void onInfoToggleClicked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                _infoWindow.Show();
            }
            else
            {
                _infoWindow.Hide();
            }

        }

        protected override void LoadWindowPos()
        {
            this.Top = Properties.Settings.Default.MainWindowTop;
            this.Left = Properties.Settings.Default.MainWindowLeft;
        }
        protected override void SaveWindowPos()
        {
            if (this.WindowState != System.Windows.WindowState.Minimized)
            {
                Properties.Settings.Default.MainWindowTop = this.Top;
                Properties.Settings.Default.MainWindowLeft = this.Left;
                Properties.Settings.Default.Save();
            }
        }
    }
}
