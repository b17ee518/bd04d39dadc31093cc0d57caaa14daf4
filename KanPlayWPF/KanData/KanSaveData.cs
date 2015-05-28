using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    
    public class CreateShipSaveData
    {
	    public void setValue(int fuel, int bull, int steel, int bauxite, int dev, int kdock)
        {
            usefuel = fuel;
            usebull = bull;
            usesteel = steel;
            usebauxite = bauxite;
            usedevelopment = dev;
            kdockid = kdock;
            flag = 1;
        }
        public void clearValue()
        {
            flag = 0;
        }
        public bool isValueSet() { return flag > 0; }
        public bool isAll30() { return usefuel == 30 && usebull == 30 && usesteel == 30 && usebauxite == 30; }

        public int usefuel;
        public int usebull;
        public int usesteel;
        public int usebauxite;
        public int usedevelopment;
	    public int kdockid;
        public int flag;
    }

    public class KanSaveData
    {
        #region Singleton
        private static KanSaveData _instance = null;
        private KanSaveData() 
        {
        }
        public static KanSaveData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KanSaveData();
                }
                return _instance;
            }
        }
        #endregion

        public kcsapi_port portdata { get; set; }
        public kcsapi_start2 start2data { get; set; }
        public List<kcsapi_slotitem> slotitemdata { get; set; }
        public List<kcsapi_kdock> kdockdata { get; set; }
        public List<kcsapi_quest> questdata { get; set; }
        public kcsapi_next nextdata { get; set; }
        public kcsapi_battle battledata { get; set; }
        public kcsapi_battleresult battleresultdata { get; set; }

        public CreateShipSaveData createshipdata { get; set; }

        public List<int> enemyhpdata { get; set; }

        public int shipcountoffset { get; set; }
        public int slotitemcountoffset { get; set; }
        public BattleType lastbattletype { get; set; }
        public int lastdeckid { get; set; }
        public int maxslotitemid { get; set; }
    }
}
