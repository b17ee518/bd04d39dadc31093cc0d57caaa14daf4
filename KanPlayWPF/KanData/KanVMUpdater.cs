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
