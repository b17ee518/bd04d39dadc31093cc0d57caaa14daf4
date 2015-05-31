using KanPlayWPF.Models;
using KanPlayWPF.ViewModels;
using KanPlayWPF.ViewModels.InfoMainWindow;
using KanPlayWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    public class KanVMUpdater
    {
        #region Singleton
        private static KanVMUpdater _instance = null;
        private KanVMUpdater() 
        {
        }
        public static KanVMUpdater Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KanVMUpdater();
                }
                return _instance;
            }
        }
        #endregion

        private void resizeList<T>(int size, List<T> l)
        {
            int nowcount = l.Count;
            if (size < nowcount)
            {
                l.RemoveRange(size, nowcount-size);
            }
            else if (size > nowcount)
            {
                for (int i=nowcount; i<size; i++)
                { 
                    l.Add((T)Activator.CreateInstance(typeof(T)));
                }
            }
        }

        public void updateOverviewTable()
        {
            KOverviewTableViewModel vm = MainWindow.getMainWindow().infoWindow.getOverViewTableVM();
            
	        KanSaveData pksd = KanSaveData.Instance;

	        int kancount = pksd.portdata.api_ship.Count()+pksd.shipcountoffset;
	        int kanmaxcount = pksd.portdata.api_basic.api_max_chara;
	        int slotitemcount = pksd.slotitemdata.Count()+pksd.slotitemcountoffset;
	        int slotitemmaxcount = pksd.portdata.api_basic.api_max_slotitem;
	        int instantrepaircount = pksd.portdata.api_material[(int)MaterialDataIndex.InstantRepair].api_value;
	        int instantbuildcount = pksd.portdata.api_material[(int)MaterialDataIndex.InstantBuild].api_value;
	        int lv = pksd.portdata.api_basic.api_level;
//	        int nextexp = KanDataCalc::GetAdmiralNextLevelExp(pksd.portdata.api_basic.api_experience, lv);
	        int fcoin = pksd.portdata.api_basic.api_fcoin;

            vm.kanCount = kancount;
            vm.kanMaxCount = kanmaxcount;
            vm.slotitemCount = slotitemcount;
            vm.slotitemMaxCount = slotitemmaxcount;
            vm.instantRepairCount = instantrepaircount;
            vm.instantBuildCount = instantbuildcount;
            vm.playerLevel = lv;
            vm.playerExpNext = 0;
            vm.furnitureCoin = fcoin;

	        //
	        if (kanmaxcount == kancount)
	        {
                vm.kanCountColorBrush = BrushModel.getTextColorStaticResource(TextBrushType.Red);
	        }
	        else if (kanmaxcount - kancount < 5)
	        {
                vm.kanCountColorBrush = BrushModel.getTextColorStaticResource(TextBrushType.Orange);
	        }
	        else
	        {
                vm.kanCountColorBrush = BrushModel.getWhiteColorBrush();
	        }
	        //
	        if (slotitemmaxcount == slotitemcount)
	        {
                vm.slotitemCountColorBrush = BrushModel.getTextColorStaticResource(TextBrushType.Red);
	        }
	        else if (slotitemmaxcount - slotitemcount < 20)
	        {
                vm.slotitemCountColorBrush = BrushModel.getTextColorStaticResource(TextBrushType.Orange);
	        }
	        else
	        {
                vm.slotitemCountColorBrush = BrushModel.getTextColorStaticResource(TextBrushType.White);
	        }
        }
        public void updateMissionTable()
        { 
            List<MissionTableViewModel> vms = MainWindow.getMainWindow().infoWindow.missionTableVMs;
            InfoMainWindowViewModel infoVM = MainWindow.getMainWindow().infoWindow.infoMainWindowVM;

	        KanSaveData pksd = KanSaveData.Instance;

            int questcount = pksd.questdata.Count;
            //if (questcount < vms.Count)
            //{
            //    vms.RemoveRange(questcount, vms.Count-questcount);
            //}
            //else if (questcount > vms.Count)
            //{
            //    int vmscount = vms.Count;
            //    for (int i=vmscount; i<questcount; i++)
            //    {
            //        vms.Add(new MissionTableViewModel());
            //    }
            //}
            resizeList<MissionTableViewModel>(questcount, vms);
            
            for (int i=0; i<questcount; i++)
	        {
                vms[i].missionName = pksd.questdata[i].api_title;
                vms[i].missionTips = pksd.questdata[i].api_detail;
                vms[i].progress = MissionModel.getMissionProgressStringFromValue(pksd.questdata[i].api_progress_flag, pksd.questdata[i].api_state);
	        }
            infoVM.missionCount = questcount;
        }
        public void updateRepairTable()
        { 
        }
        public void updateFleetTable() 
        {
            List<FleetTeamViewModel> vms = MainWindow.getMainWindow().infoWindow.fleetTableVMs;
	        KanSaveData pksd = KanSaveData.Instance;
            KanDataConnector pkdc = KanDataConnector.Instance;
            
            int teamindex = 0;
	        foreach (kcsapi_deck v in pksd.portdata.api_deck_port)
	        {
		        int shipcount = 0;

		        foreach(int shipno in v.api_ship)
		        {
			        if (shipno <= 0)
			        {
				        break;
			        }
			        shipcount++;
                }
                resizeList<FleetTableViewModel>(shipcount, vms[teamindex].shipsViewModel);

                int shipindex = 0;
		        foreach(int shipno in v.api_ship)
		        {
			        if (shipno <= 0)
			        {
				        break;
			        }

			        kcsapi_ship2 pship = pkdc.findShipFromShipno(shipno);
			        if (pship == null)
			        {
				        continue;
			        }
			        int shipid = pship.api_ship_id;
			        kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(shipid);
            
			        int nextexp = pship.api_exp[1];
                    FleetTableViewModel shipvm = vms[teamindex].shipsViewModel[shipindex];
                    shipvm.index = shipindex;
                    shipvm.shipName = pmstship.api_name;
                    shipvm.level = pship.api_lv;
                    shipvm.cond = pship.api_cond;
                    shipvm.nextExp = nextexp;
                    shipvm.fuel = pship.api_fuel;
                    shipvm.bullet = pship.api_bull;
                    shipvm.fuelMax = pmstship.api_fuel_max;
                    shipvm.bulletMax = pmstship.api_bull_max;
                    shipvm.nowHp = pship.api_nowhp;
                    shipvm.maxHp = pship.api_maxhp;
                    // TODO
                    shipvm.repairingState = ReparingState.None;

                    shipindex++;
		        }
                teamindex++;
	        }
        }
        public void updateExpeditionTable()
        { 
        }
        public void updateRepairDockTable()
        { 
        }
        public void updateBuildDockTable()
        { 
        }
        public void updateInfoTitleBattle(bool bBattle = false, List<int> enemyhps = null)
        { 
        }
        public void updateInfoTitleCond()
        { 
        }
        public void updateWeaponTable()
        { 
        }
    }
}
