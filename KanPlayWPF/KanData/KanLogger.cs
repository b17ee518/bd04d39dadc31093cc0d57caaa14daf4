using KanPlayWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    public class KanLogger
    {
        private static KanSaveData pksd = KanSaveData.Instance;
        private static KanDataConnector pkdc = KanDataConnector.Instance;
        
        #region Singleton
        private static KanLogger _instance = null;
        private KanLogger() 
        {
        }
        public static KanLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KanLogger();
                }
                return _instance;
            }
        }
        #endregion

        #region Logger
        private void AddLog(string filename, string log)
        {
            try
            {
                using (var sw = new StreamWriter(
                    new FileStream(filename, FileMode.Append, FileAccess.Write), Encoding.GetEncoding("UTF-16")))
                {
                    string str = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]\t");
                    str += log;
                    sw.WriteLine(str);
                }
            }
            catch
            {

            }
        }

        public void LogError(string log)
        {
            RecordLog("error", log);
        }
        public void LogAPI(string path, string request, string response)
        {
            string str = path + "\t" + request + "\t" + response;
            RecordLog("apilog", str);
        }

        public void RecordLog(string filename, string log)
        { 
            string path = AppDomain.CurrentDomain.BaseDirectory + "/log/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullpath = path + filename + ".table";
            AddLog(fullpath, log);
        }
        #endregion


public string logBattleResult(bool bWrite=true)
{
	int maparea_id = pksd.nextdata.api_maparea_id;
	int mapinfo_no = pksd.nextdata.api_mapinfo_no;

	string mapareastr = "";
	string mapinfostr = "";
	foreach(Api_Mst_Maparea v in pksd.start2data.api_mst_maparea)
	{
		if (v.api_id == maparea_id)
		{
			mapareastr = v.api_name;
		}
	}

	SeikuResultType seiku = (SeikuResultType)pksd.battledata.api_kouku.api_stage1.api_disp_seiku;
	string seikustr = "-";
	switch (seiku)
	{
	case SeikuResultType.KaKuHo:
		seikustr = "制空権確保";
		break;
	case SeikuResultType.YuSei:
		seikustr = "航空優勢";
		break;
	case SeikuResultType.Unknown:
		seikustr = "航空均衡/劣勢";
		break;
	case SeikuResultType.SouSiTu:
		seikustr = "制空権喪失";
		break;
	}

	string sformstr = "-";
	if (pksd.battledata.api_formation.Count() > 0)
	{
		sformstr = getFormationStr(pksd.battledata.api_formation[0]);
	}
	string eformstr = "-";
	if (pksd.battledata.api_formation.Count() > 1)
	{
		eformstr = getFormationStr(pksd.battledata.api_formation[1]);
	}
	string interceptstr = "-";

	if (pksd.battledata.api_formation.Count() > 2)
	{
		switch (pksd.battledata.api_formation[2])
		{
		case 1:
			interceptstr = "同航戦";
			break;
		case 2:
			interceptstr = "反航戦";
			break;
		case 3:
			interceptstr = "Ｔ字戦(有利)";
			break;
		case 4:
			interceptstr = "Ｔ字戦(不利)";
			break;
		}
	}

	string mvpstr = "-";
	string mvp_combinedstr = "-";
	int mvp = pksd.battleresultdata.api_mvp;
	int mvp_combined = pksd.battleresultdata.api_mvp_combined;
	if (mvp > 0 && pksd.lastdeckid >= 0 && pksd.lastdeckid < 4)
	{
		int shipno = pksd.portdata.api_deck_port[pksd.lastdeckid].api_ship[mvp - 1];
		if (shipno > 0)
		{
			kcsapi_ship2 pship = pkdc.findShipFromShipno(shipno);
			if (pship != null)
			{
				kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(pship.api_ship_id);
				if (pmstship != null)
				{
					mvpstr = pmstship.api_name;
				}
			}
		}
	}
	if (mvp_combined > 0)
	{
		int shipno = pksd.portdata.api_deck_port[1].api_ship[mvp_combined - 1];
		if (shipno > 0)
		{
			kcsapi_ship2 pship = pkdc.findShipFromShipno(shipno);
			if (pship != null)
			{
				kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(pship.api_ship_id);
				if (pmstship != null)
				{
					mvp_combinedstr = pmstship.api_name;
				}
			}
		}
	}


	string dropstr = "-";
	if (pksd.battleresultdata.api_get_ship.api_ship_id > 0)
	{
		dropstr = pksd.battleresultdata.api_get_ship.api_ship_name;
	}

	string battletypestr = "-";
	switch (pksd.lastbattletype)
	{
	case BattleType.Day:
		battletypestr = "昼戦";
		break;
	case BattleType.Night:
		battletypestr = "夜戦";
		break;
	case BattleType.DayToNight:
		battletypestr = "昼夜";
		break;
	case BattleType.NightToDay:
		battletypestr = "夜昼";
        break;
    case BattleType.Air:
        battletypestr = "昼空";
        break;
	case BattleType.Combined_Water:
		battletypestr = "連航水";
		break;
	case BattleType.Combined_KouKu:
		battletypestr = "連航";
		break;
	case BattleType.Combined_KouKuNight:
		battletypestr = "連航夜";
		break;
	case BattleType.Combined_Day:
		battletypestr = "連昼";
		break;
	case BattleType.Combined_DayToNight:
		battletypestr = "連昼夜";
		break;
	}

	string writestr = mapareastr + "\t"
		+ pksd.battleresultdata.api_quest_name + "\t"
		+ pksd.battleresultdata.api_enemy_info.api_deck_name + "\t"
		+ battletypestr + "\t"
		+ pksd.battleresultdata.api_win_rank + "\t"
		+ dropstr + "\t"
		+ seikustr + "\t"
		+ sformstr + "\t"
		+ eformstr + "\t"
		+ interceptstr + "\t"
		+ mvpstr + "\t"
		+ mvp_combinedstr + "\t";

	if (bWrite)
	{
		string filename = string.Format("BattleResult_{0}_{1}", maparea_id, mapinfo_no);
		RecordLog(filename, writestr);
	}
	return writestr;
}

string getFormationStr(int formation)
{
	switch (formation)
	{
	case 1:
		return "単縦陣";
		break;
	case 2:
		return "複縦陣";
		break;
	case 3:
		return "輪形陣";
		break;
	case 4:
		return "梯形陣";
		break;
	case 5:
		return "単横陣";
		break;

	case 11:
		return "第一警戒航行序列";
		break;
	case 12:
		return "第二警戒航行序列";
		break;
	case 13:
		return "第三警戒航行序列";
		break;
	case 14:
		return "第四警戒航行序列";
		break;
	}
	return "";
}


public void logBattleDetail(bool bCombined)
{
	string infoline = logBattleResult(false);

	List<kcsapi_ship2> sships = new List<kcsapi_ship2>();
	List<kcsapi_mst_ship> eships = new List<kcsapi_mst_ship>();
	if (pksd.lastdeckid >= 0 && pksd.lastdeckid < 4)
	{
		foreach(int shipno in pksd.portdata.api_deck_port[pksd.lastdeckid].api_ship)
		{
			if (shipno > 0)
			{
				kcsapi_ship2 pship = pkdc.findShipFromShipno(shipno);
				if (pship != null)
				{
					sships.Add(pship);
				}
			}
		}
		if (bCombined)
		{
			foreach(int shipno in pksd.portdata.api_deck_port[1].api_ship)
			{
				if (shipno > 0)
				{
					kcsapi_ship2 pship = pkdc.findShipFromShipno(shipno);
					if (pship != null)
					{
						sships.Add(pship);
					}
				}
			}
		}
	}
	foreach(int shipid in pksd.battledata.api_ship_ke)
	{
		if (shipid > 0)
		{
			kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(shipid);
			if (pmstship != null)
			{
				eships.Add(pmstship);
			}
		}
	}

	string shipnameline = "\t艦名:\t";
	string lvline = "\tLv:\t";
	List<string> equiplines = new List<string>();
	string beforehpline = "\t前HP:\t";
	string afterhpline = "\t後HP:\t";
	string nenryoline = "\t燃料:\t";
	string danyakuline = "\t弾薬:\t";
	string condline = "\tコンデ:\t";
	string enemynameline = "\t敵艦:\t";
	string ehpline = "\t敵残HP:\t";

	for (int i = 0; i < 5; i++)
	{
		equiplines.Add(string.Format("\t装備{0}\t", i + 1));
	}

	int shipcount = 0;
	foreach(kcsapi_ship2 pship in sships)
	{
		shipcount++;
		kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(pship.api_ship_id);
		if (pmstship != null)
		{
			shipnameline += pmstship.api_name + "\t";
		}
		lvline += pship.api_lv.ToString() + "\t";

		for (int i = 0; i < pship.api_slot.Count(); i++)
		{
			string strslotitemname = "-";

			if (pship.api_slot[i] > 0)
			{
				kcsapi_slotitem pslotitem = pkdc.findSlotitemFromId(pship.api_slot[i]);
				if (pslotitem != null)
				{
					kcsapi_mst_slotitem pmstslotitem = pkdc.findMstSlotItemFromSlotitemid(pslotitem.api_slotitem_id);
					if (pmstslotitem != null)
					{
						strslotitemname = pmstslotitem.api_name;
					}
				}
			}
			/*
			const kcsapi_mst_slotitem * pmstslotitem = findMstSlotItemFromSlotitemid(pship.api_slot[i]);
			foreach(const kcsapi_mst_slotitem &mstslotitem, pksd.start2data.api_mst_slotitem)
			{
				if (mstslotitem.api_id == pship.api_slot[i])
				{
					strslotitemname = mstslotitem.api_name;
					break;
				}
			}
			*/
			equiplines[i] += strslotitemname + "\t";
		}

		beforehpline += pksd.battledata.api_nowhps[shipcount].ToString() + "\t";
		afterhpline += pship.api_nowhp.ToString() + "\t";
		if (pmstship != null)
		{
			nenryoline += string.Format("{0:P0}", (Double)pship.api_fuel / (Double)pmstship.api_fuel_max) + "\t";
			danyakuline += string.Format("{0:P0}", (Double)pship.api_bull / (Double)pmstship.api_bull_max) + "\t";
		}
		condline += pship.api_cond.ToString() + "\t";
	}

	int j = 0;
	foreach (kcsapi_mst_ship pmstship in eships)
	{
		j++;
		enemynameline += pmstship.api_name + "\t";
		int ehp = pksd.enemyhpdata[j];
		if (ehp < 0)
		{
			ehp = 0;
		}
		ehpline += ehp.ToString() + "\t";
	}

	string writestr = infoline + "\n"
		+ shipnameline + "\n"
		+ lvline + "\n";
	foreach (string str in equiplines)
	{
		writestr += str + "\n";
	}
	writestr += beforehpline + "\n"
		+ afterhpline + "\n"
		+ nenryoline + "\n"
		+ danyakuline + "\n"
		+ condline + "\n"
		+ enemynameline + "\n"
		+ ehpline + "\n";

	int maparea_id = pksd.nextdata.api_maparea_id;
	int mapinfo_no = pksd.nextdata.api_mapinfo_no;
	string filename = string.Format("BattleDetail_{0}_{1}", maparea_id, mapinfo_no);
	RecordLog(filename, writestr);
}

public void logBuildResult()
{
	if (pksd.createshipdata.isAll30())
	{
		return;
	}

	
	int kdockid = pksd.createshipdata.kdockid - 1;
	if (kdockid >= 0 && pksd.kdockdata.Count() > kdockid)
	{
		string writestr = "";

		int shipid = pksd.kdockdata[kdockid].api_created_ship_id;
		 kcsapi_mst_ship pmstship = pkdc.findMstShipFromShipid(shipid);

		writestr += pmstship.api_name + "\t";

		writestr += getLogDevLeadStr();// + "\t";

		string filename = string.Format("BuildLog_{0}_{1}_{2}_{3}_{4}"
			, pksd.createshipdata.usefuel
			, pksd.createshipdata.usebull
			, pksd.createshipdata.usesteel
			, pksd.createshipdata.usebauxite
			, pksd.createshipdata.usedevelopment);

		RecordLog(filename, writestr);
	}
	
}

public void logCreateItemResult(int slotitemid, int fuel, int bull, int steel, int bauxite)
{
	string writestr = "";
	string slotitemnamestr = "";
	if (slotitemid > 0)
	{
		kcsapi_mst_slotitem pmstslotitem = pkdc.findMstSlotItemFromSlotitemid(slotitemid);
		if (pmstslotitem != null)
		{
			slotitemnamestr = pmstslotitem.api_name;
		}
	}
	else
	{
		slotitemnamestr = "ペンギン";
	}
	writestr += slotitemnamestr + "\t";
	writestr += getLogDevLeadStr();

	string filename = string.Format("CreateItemLog_{0}_{1}_{2}_{3}"
		, fuel
		, bull
		, steel
		, bauxite);

	RecordLog(filename, writestr);
}

string getLogDevLeadStr()
{
	string writestr = "";

	string leadnamestr = "";
	string leadlvstr = "";
	int shipno = pksd.portdata.api_deck_port[0].api_ship[0];
	if (shipno > 0)
	{
		kcsapi_ship2 pleadship = pkdc.findShipFromShipno(shipno);
		if (pleadship != null)
		{
			kcsapi_mst_ship pleadmstship = pkdc.findMstShipFromShipid(pleadship.api_ship_id);
			if (pleadmstship != null)
			{
				leadnamestr += pleadmstship.api_name;
			}
			leadlvstr = string.Format("{0}", pleadship.api_lv);
		}
	}

	writestr += leadnamestr + "\t" + leadlvstr + "\t";
	writestr += string.Format("{0}", pksd.portdata.api_basic.api_level);
	return writestr;
}

    }
}
