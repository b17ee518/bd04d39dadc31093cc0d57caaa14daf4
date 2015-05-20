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

using KanPlayWPF.ViewModels.InfoMainWindow;

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
    /// InfoMainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class InfoMainWindow : KWindowBase
    {
        private List<MissionTableViewModel> _missionTableItems = new List<MissionTableViewModel>();
        private MainWindow _mainWindow = null;

        public InfoMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            
            missionTable.addColumn(new Binding() {Path = new PropertyPath("prefix")});
            missionTable.addColumn(new Binding() { Path = new PropertyPath("missionName") });
            missionTable.addColumn(new Binding() {Path = new PropertyPath("progress")});

            missionTable.setExpandableColumn(1);

            MissionTableViewModel item = new MissionTableViewModel() { missionName = "abc", progress = 5 };
            _missionTableItems.Add(item);
            missionTable.setItemSource(_missionTableItems);
        }

        protected override void onCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _mainWindow.onInfoMainWindowClosed();
        }

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
            this.Top = Properties.Settings.Default.InfoWindowRelTop + mainTop;
            this.Left = Properties.Settings.Default.InfoWindowRelLeft + mainLeft;
        }
        protected override void SaveWindowPos()
        {
            if (this.WindowState != System.Windows.WindowState.Minimized && 
                _mainWindow.WindowState != System.Windows.WindowState.Minimized)
            {
                Properties.Settings.Default.InfoWindowRelTop = this.Top - _mainWindow.Top;
                Properties.Settings.Default.InfoWindowRelLeft = this.Left - _mainWindow.Left;
                Properties.Settings.Default.Save();
            }
        }
    }
}