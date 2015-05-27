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
using KanPlayWPF.ViewModels.TimerMainWindow;
using KanPlayWPF.ViewModels;
using Codeplex.Data;

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
    /// TimerMainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TimerMainWindow : KWindowBase
    {
        private MainWindow _mainWindow = null;
        private TimerMainWindowViewModel _timerMainWindowVM = null;

        private List<KTimerProgressViewModel> _expeditionVMs = new List<KTimerProgressViewModel>();
        private List<KTimerProgressViewModel> _repairVMs = new List<KTimerProgressViewModel>();
        private List<KTimerProgressViewModel> _buildVMs = new List<KTimerProgressViewModel>();
        
        private int _expeditionCount = 3;
        private int _repairCount = 4;
        private int _buildCount = 2;

        public TimerMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            _timerMainWindowVM = this.DataContext as TimerMainWindowViewModel;
        }

        #region Save/Load WindowPos
        protected override void LoadWindowPos()
        {
            Double mainTop = 0;
            Double mainLeft = 0;
            if (_mainWindow == null)
            {
                mainTop = Properties.Settings.Default.MainWindowTop;
                mainLeft = Properties.Settings.Default.MainWindowLeft;
            }
            else
            {
                mainTop = _mainWindow.Top;
                mainLeft = _mainWindow.Left;
            }
            this.Top = Properties.Settings.Default.TimerWindowRelTop + mainTop;
            this.Left = Properties.Settings.Default.TimerWindowRelLeft + mainLeft;
        }
        protected override void SaveWindowPos()
        {
            if (this.WindowState != System.Windows.WindowState.Minimized &&
                _mainWindow.WindowState != System.Windows.WindowState.Minimized)
            {
                Properties.Settings.Default.TimerWindowRelTop = this.Top - _mainWindow.Top;
                Properties.Settings.Default.TimerWindowRelLeft = this.Left - _mainWindow.Left;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        protected override void onCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _mainWindow.onTimerMainWindowClosed();

        }

        private void KWindowBase_Loaded(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < _expeditionCount; i++)
            {
                _expeditionVMs.Add(new KTimerProgressViewModel());
            }
            for (int i = 0; i < _repairCount; i++)
            {
                _repairVMs.Add(new KTimerProgressViewModel());
            }
            for (int i = 0; i < _buildCount; i++)
            {
                _buildVMs.Add(new KTimerProgressViewModel());
            }

            expedition2TimeProgress.DataContext = _expeditionVMs[0];
            expedition3TimeProgress.DataContext = _expeditionVMs[1];
            expedition4TimeProgress.DataContext = _expeditionVMs[2];

            repair1TimeProgress.DataContext = _repairVMs[0];
            repair2TimeProgress.DataContext = _repairVMs[1];
            repair3TimeProgress.DataContext = _repairVMs[2];
            repair4TimeProgress.DataContext = _repairVMs[3];

            build1TimeProgress.DataContext = _buildVMs[0];
            build2TimeProgress.DataContext = _buildVMs[1];

            if (KanPlayWPF.Models.DebugModel.isUsingSampleData)
            {
                flushSampleData();
            }
            else
            {
                flushData();
            }

        }

        #region SampleData
        private void flushSampleData()
        {
            string notSetString = "-- : -- : --";
            for (int i = 0; i < _expeditionCount; i++)
            {
                _expeditionVMs[i].leftString = notSetString;
                _expeditionVMs[i].rightString = notSetString;
            }
            for (int i = 0; i < _repairCount; i++)
            {
                _repairVMs[i].leftString = notSetString;
                _repairVMs[i].rightString = notSetString;
            }
            for (int i = 0; i < _buildCount; i++)
            {
                _buildVMs[i].leftString = notSetString;
                _buildVMs[i].rightString = "";
            }

        }
        #endregion

        public void flushData(/*data*/)
        {

        }
    }
}