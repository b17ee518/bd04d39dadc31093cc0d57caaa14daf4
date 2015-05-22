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
        private List<FleetTeamViewModel>  _fleetTables = new List<FleetTeamViewModel>();
        private List<RepairTableViewModel> _repairTableItems = new List<RepairTableViewModel>();
        private MainWindow _mainWindow = null;

        private InfoMainWindowViewModel _infoMainWindowVM = new InfoMainWindowViewModel();
        
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
            #region MissionTableColumns
            missionTable.foldableListView.Style = Application.Current.FindResource("KMissionTableListViewDefine") as Style;

            missionTable.setExpandableColumn(1);

            missionTable.toggleButton.Style = Application.Current.FindResource("KMissionTableToggleButtonDefine") as Style;
            missionTable.toggleButton.DataContext = _infoMainWindowVM;

            _infoMainWindowVM.missionCount = 4;

            #region SampleData
            MissionTableViewModel item = new MissionTableViewModel() { missionName = "abc", progress = 5 };
            _missionTableItems.Add(item);
            missionTable.setItemSource(_missionTableItems);
            #endregion

            #endregion

            #region FleetTablesColumns
            List<KFoldableListView.KFoldableListView> fleetTables = new List<KFoldableListView.KFoldableListView>();
            fleetTables.Add(fleetTable_1);
            fleetTables.Add(fleetTable_2);
            fleetTables.Add(fleetTable_3);
            fleetTables.Add(fleetTable_4);

            _fleetTables.Add(new FleetTeamViewModel());
            _fleetTables.Add(new FleetTeamViewModel());
            _fleetTables.Add(new FleetTeamViewModel());
            _fleetTables.Add(new FleetTeamViewModel());

            #region SampleData
            _fleetTables[0].AddVM(new FleetTableViewModel()
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
            _fleetTables[0].AddVM(new FleetTableViewModel()
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
                it.v.setItemSource(_fleetTables[it.i].shipsViewModel);
                it.v.setExpandableColumn(3);
                if (it.i != 0)
                {
                    it.v.setFold(true);
                }

                it.v.toggleButton.DataContext = _fleetTables[it.i];
                it.v.toggleButton.Style = Application.Current.FindResource("KFleetTableToggleButtonDefine") as Style;
            }
            #endregion

            #region repairTableColumns
            repairTable.foldableListView.Style = Application.Current.FindResource("KRepairTableListViewDefine") as Style;

            repairTable.setExpandableColumn(3);
            repairTable.setItemSource(_repairTableItems);

            #region SampleData
            _repairTableItems.Add(new RepairTableViewModel()
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

        }
    }
}