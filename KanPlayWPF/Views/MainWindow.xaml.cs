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
using KanPlayWPF.KanData;

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
        TimerMainWindow _timerWindow = null;

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

            _timerWindow = new TimerMainWindow(this);
            _timerWindow.Show();

            Fiddler.FiddlerApplication.AfterSessionComplete
                        += new Fiddler.SessionStateHandler(FiddlerApplication_AfterSessionComplete);

            Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.ChainToUpstreamGateway);

            Fiddler.URLMonInterop.SetProxyInProcess(string.Format("127.0.0.1:{0}",
                        Fiddler.FiddlerApplication.oProxy.ListenPort), "<local>");

            webBrowser.Source = new Uri("http://www.google.com");

            //
            //test
            /*
            string text = System.IO.File.ReadAllText(@"C:\apilog.txt");
            string[] splited = text.Split(new char[]{'\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0; i<splited.Length/4; i++)
            {
                KanDataConnector.Instance.Parse(splited[i * 4 + 1], splited[i * 4 + 2], splited[i * 4 + 3]);
            }
             */
        }

        public void onInfoMainWindowClosed()
        {
            btnInfo.IsChecked = false;
        }
        public void onTimerMainWindowClosed()
        {
            btnTimer.IsChecked = false;
        }

        private void onWeaponToggleClicked(object sender, RoutedEventArgs e)
        {
        }

        private void onTimerToggleClicked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                _timerWindow.WindowState = WindowState.Normal;
                _timerWindow.Show();
            }
            else
            {
                _timerWindow.Hide();
            }
        }

        private void onInfoToggleClicked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                _infoWindow.WindowState = WindowState.Normal;
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


        #region Fiddler
        void FiddlerApplication_AfterSessionComplete(Fiddler.Session oSession)
        {
            if (oSession.PathAndQuery.StartsWith("/kcsapi"))
            {
                if (oSession.oResponse.MIMEType == "text/plain")
                {
                    string requestBody = System.Text.Encoding.UTF8.GetString(oSession.RequestBody);
                    string responseBody = System.Text.Encoding.UTF8.GetString(oSession.ResponseBody);
                    KanDataConnector.Instance.Parse(oSession.PathAndQuery, requestBody, responseBody);
                }
            }
            /*
            System.Diagnostics.Debug.WriteLine(string.Format("Session {0}({3}):HTTP {1} for {2}",
                    oSession.id, oSession.responseCode, oSession.fullUrl, oSession.oResponse.MIMEType));
             */
        }
        #endregion
    }
}
