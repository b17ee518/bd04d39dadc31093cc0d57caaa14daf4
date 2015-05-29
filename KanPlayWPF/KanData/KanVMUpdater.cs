using KanPlayWPF.Models;
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
        }
        public void updateRepairTable()
        { 
        }
        public void updateFleetTable() 
        {
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
