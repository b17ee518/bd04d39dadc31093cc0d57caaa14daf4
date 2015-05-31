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
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

using KanPlayWPF.ViewModels;
using System.Windows.Threading;

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
        private List<MissionTableViewModel> _missionTableVMs = new List<MissionTableViewModel>(); public List<MissionTableViewModel> missionTableVMs { get { return _missionTableVMs; } set { _missionTableVMs = value; } }
        private List<FleetTeamViewModel> _fleetTableVMs = new List<FleetTeamViewModel>(); public List<FleetTeamViewModel> fleetTableVMs { get { return _fleetTableVMs; } set { _fleetTableVMs = value; } }
        private List<RepairTableViewModel> _repairTableVMs = new List<RepairTableViewModel>(); public List<RepairTableViewModel> repairTableVMs { get { return _repairTableVMs; } set { _repairTableVMs = value; } }

        private MainWindow _mainWindow = null;
        private InfoMainWindowViewModel _infoMainWindowVM = new InfoMainWindowViewModel(); public InfoMainWindowViewModel infoMainWindowVM { get { return _infoMainWindowVM; } set { _infoMainWindowVM = value; } }
        
        public KOverviewTableViewModel getOverViewTableVM()
        {
            return overviewTable.overviewTableVM;
        }

        public InfoMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }
        
        protected override void onCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _mainWindow.onInfoMainWindowClosed();
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
        #endregion

        private void KWindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            //BindingOperations.EnableCollectionSynchronization(this._missionTableVMs, new object());
            //BindingOperations.EnableCollectionSynchronization(this._fleetTableVMs, new object());
            //BindingOperations.EnableCollectionSynchronization(this._repairTableVMs, new object());

            #region MissionTableColumns
            missionTable.foldableListView.Style = Application.Current.FindResource("KMissionTableListViewDefine") as Style;

            missionTable.setExpandableColumn(1);

            missionTable.toggleButton.Style = Application.Current.FindResource("KMissionTableToggleButtonDefine") as Style;
            missionTable.toggleButton.DataContext = infoMainWindowVM;

            //infoMainWindowVM.missionCount = 4;

            #region SampleData
            //MissionTableViewModel item = new MissionTableViewModel() { missionName = "abc", progress = "5" };
            //missionTableVMs.Add(item); 
            //item = new MissionTableViewModel() { missionName = "abcaa", progress = "5" };
            //_missionTableVMs.Add(item); item = new MissionTableViewModel() { missionName = "abc", progress = "5" };
            //missionTableVMs.Add(item); item = new MissionTableViewModel() { missionName = "abc", progress = "5" };
            //missionTableVMs.Add(item); item = new MissionTableViewModel() { missionName = "abc", progress = "5" };
            //missionTableVMs.Add(item); item = new MissionTableViewModel() { missionName = "abcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", progress = "500" };
            //missionTableVMs.Add(item);
            missionTable.setItemSource(missionTableVMs);
            //BindingOperations.EnableCollectionSynchronization(this._missionTableVMs, new object());
            #endregion

            #endregion

            #region FleetTablesColumns
            List<KFoldableListView.KFoldableListView> fleetTables = new List<KFoldableListView.KFoldableListView>();
            fleetTables.Add(fleetTable_1);
            fleetTables.Add(fleetTable_2);
            fleetTables.Add(fleetTable_3);
            fleetTables.Add(fleetTable_4);

            fleetTableVMs.Add(new FleetTeamViewModel());
            fleetTableVMs.Add(new FleetTeamViewModel());
            fleetTableVMs.Add(new FleetTeamViewModel());
            fleetTableVMs.Add(new FleetTeamViewModel());

            #region SampleData
            fleetTableVMs[0].AddVM(new FleetTableViewModel()
            {
                index = 1,
                shipName = "aaa",
                level = 10,
                cond = 50,
                nextExp = 100,
                fuel = 80,
                bullet = 80,
                fuelMax = 100,
                bulletMax = 100,
                nowHp = 5,
                maxHp = 80,
            });
            fleetTableVMs[0].AddVM(new FleetTableViewModel()
            {
                index = 2,
                shipName = "bbb",
                level = 10,
                cond = 50,
                nextExp = 100,
                fuel = 80,
                bullet = 80,
                fuelMax = 100,
                bulletMax = 100,
                nowHp = 5,
                maxHp = 80,
            });
            #endregion

            foreach (var it in fleetTables.Select((v, i) => new { v, i }))
            {
                it.v.applyTableStyle("KFleetTableListViewDefine");
                it.v.setItemSource(fleetTableVMs[it.i].shipsViewModel);
                it.v.setExpandableColumn(3);
                if (it.i != 0)
                {
                    it.v.setFold(true);
                }

                it.v.toggleButton.DataContext = fleetTableVMs[it.i];
                it.v.toggleButton.Style = Application.Current.FindResource("KFleetTableToggleButtonDefine") as Style;
            }
            #endregion

            #region repairTableColumns
            repairTable.foldableListView.Style = Application.Current.FindResource("KRepairTableListViewDefine") as Style;

            repairTable.setExpandableColumn(3);
            repairTable.setItemSource(repairTableVMs);

            repairTable.toggleButton.Style = Application.Current.FindResource("KRepairTableToggleButtonDefine") as Style;
            repairTable.toggleButton.DataContext = infoMainWindowVM;

            #region SampleData
            repairTableVMs.Add(new RepairTableViewModel()
            {
                shipName = "aaa",
                level = 40,
                cond = 0,
                repairTime = 10968401561,
                nowHp = 50,
                maxHp = 80
            });
            #endregion

            #endregion



            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 1);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
        }
    }
}