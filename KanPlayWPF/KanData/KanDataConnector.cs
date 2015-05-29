using Codeplex.Data;
using KanPlayWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    enum KanAPIDumpState
    {
        Normal,
        Output,
        Ignore,
    }
    #region KanAPIDistributor
    internal class KanAPIDistributor
    {
        public KanAPIDistributor(string api, KanAPIDumpState state, Func<dynamic, bool> f)
        {
            apiStr = api;
            dumpState = state;
            func = f;
        }

        public string apiStr {get; set; }
        public KanAPIDumpState dumpState {get; set; }
        public Func<dynamic, bool> func {get; set; }
    }
    #endregion

    public class KanDataConnector
    {
        private List<KanAPIDistributor> _apiDistributors = new List<KanAPIDistributor>();
        private KanSaveData pksd = KanSaveData.Instance;
        private KanVMUpdater pkvm = KanVMUpdater.Instance;

        private void checkWoundQuit()
        {
	int lastdeckid = pksd.lastdeckid;
	bool bClose = false;
	if (lastdeckid >= 0 && lastdeckid < 4)
	{
		foreach(int shipno in pksd.portdata.api_deck_port[lastdeckid].api_ship)
		{
			if (shipno > 0)
			{
				kcsapi_ship2 pship = findShipFromShipno(shipno);
				if (pship != null)
				{
                    if (WoundModel.getWoundStateFromHP(pship.api_nowhp, pship.api_maxhp) > WoundState.Moderate)
					{
						if (pship.api_locked > 0 || pship.api_lv > 2)
						{
							bClose = true;
							break;
						}
					}
				}
			}
		}
	}
	if (bClose)
	{
        throw new Exception();
	}

        }

        #region Initialize
        private void Initialize()
        {
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_start2",
                KanAPIDumpState.Normal,
                start2_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_port/port",
                KanAPIDumpState.Normal,
                 port_port_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/basic",
                KanAPIDumpState.Normal,
                 get_member_basic_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/ship",
                KanAPIDumpState.Normal,
                 get_member_ship_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/ship2",
                KanAPIDumpState.Normal,
                 get_member_ship2_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/ship3",
                KanAPIDumpState.Normal,
                 get_member_ship3_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/ship_deck",
                KanAPIDumpState.Normal,
                 get_member_ship_deck_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/slot_item",
                KanAPIDumpState.Normal,
                 get_member_slot_item_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/useitem",
                KanAPIDumpState.Normal,
                 get_member_useitem_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/deck",
                KanAPIDumpState.Normal,
                 get_member_deck_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/deck_port",
                KanAPIDumpState.Normal,
                 get_member_deck_port_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/ndock",
                KanAPIDumpState.Normal,
                 get_member_ndock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/kdock",
                KanAPIDumpState.Normal,
                 get_member_kdock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/material",
                KanAPIDumpState.Normal,
                 get_member_material_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_hensei/change",
                KanAPIDumpState.Normal,
                 req_hensei_change_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_hensei/lock",
                KanAPIDumpState.Normal,
                 req_hensei_lock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_hensei/combined",
                KanAPIDumpState.Normal,
                 req_hensei_combined_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/unsetslot",
                KanAPIDumpState.Normal,
                 get_member_unsetslot_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/unsetslot_all",
                KanAPIDumpState.Normal,
                 req_kaisou_unsetslot_all_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/getship",
                KanAPIDumpState.Normal,
                 req_kousyou_getship_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/createitem",
                KanAPIDumpState.Normal,
                 req_kousyou_createitem_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/createship",
                KanAPIDumpState.Normal,
                 req_kousyou_createship_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/createship_speedchange",
                KanAPIDumpState.Normal,
                 req_kousyou_createship_speedchange_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/destroyship",
                KanAPIDumpState.Normal,
                 req_kousyou_destroyship_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/destroyitem2",
                KanAPIDumpState.Normal,
                 req_kousyou_destroyitem2_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_nyukyo/start",
                KanAPIDumpState.Normal,
                 req_nyukyo_start_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_nyukyo/speedchange",
                KanAPIDumpState.Normal,
                 req_nyukyo_speedchange_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_hokyu/charge",
                KanAPIDumpState.Normal,
                 req_hokyu_charge_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/powerup",
                KanAPIDumpState.Normal,
                 req_kaisou_powerup_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/slotset",
                KanAPIDumpState.Normal,
                 req_kaisou_slotset_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/remodeling",
                KanAPIDumpState.Normal,
                 req_kaisou_remodeling_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_mission/start",
                KanAPIDumpState.Normal,
                 req_mission_start_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_mission/result",
                KanAPIDumpState.Normal,
                 req_mission_result_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/mission",
                KanAPIDumpState.Normal,
                 get_member_mission_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/mapinfo",
                KanAPIDumpState.Normal,
                 get_member_mapinfo_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/mapcell",
                KanAPIDumpState.Normal,
                 get_member_mapcell_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_map/start",
                KanAPIDumpState.Normal,
                 req_map_start_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_map/next",
                KanAPIDumpState.Normal,
                 req_map_next_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_sortie/battleresult",
                KanAPIDumpState.Normal,
                 req_sortie_battleresult_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_sortie/battle",
                KanAPIDumpState.Normal,
                 req_sortie_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_battle_midnight/battle",
                KanAPIDumpState.Normal,
                 req_battle_midnight_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_battle_midnight/sp_midnight",
                KanAPIDumpState.Normal,
                 req_battle_midnight_sp_midnight_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_sortie/night_to_day",
                KanAPIDumpState.Normal,
                 req_sortie_night_to_day_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_sortie/airbattle",
                KanAPIDumpState.Normal,
                 req_sortie_airbattle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/airbattle",
                KanAPIDumpState.Normal,
                 req_combined_battle_airbattle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/battle_water",
                KanAPIDumpState.Normal,
                 req_combined_battle_battlewater_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/battleresult",
                KanAPIDumpState.Normal,
                 req_combined_battle_battleresult_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/battle",
                KanAPIDumpState.Normal,
                 req_combined_battle_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/midnight_battle",
                KanAPIDumpState.Normal,
                 req_combined_battle_midnight_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/sp_midnight",
                KanAPIDumpState.Normal,
                 req_combined_battle_sp_midnight_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/practice",
                KanAPIDumpState.Normal,
                 get_member_practice_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/get_practice_enemyinfo",
                KanAPIDumpState.Normal,
                 req_member_get_practice_enemyinfo_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_practice/battle",
                KanAPIDumpState.Normal,
                 req_practice_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_practice/midnight_battle",
                KanAPIDumpState.Normal,
                 req_practice_midnight_battle_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_practice/battle_result",
                KanAPIDumpState.Normal,
                 req_practice_battle_result_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/questlist",
                KanAPIDumpState.Normal,
                 get_member_questlist_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_quest/start",
                KanAPIDumpState.Normal,
                 req_quest_start_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_quest/stop",
                KanAPIDumpState.Normal,
                 req_quest_stop_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_quest/clearitemget",
                KanAPIDumpState.Normal,
                 req_quest_clearitemget_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/sortie_conditions",
                KanAPIDumpState.Normal,
                 get_member_sortie_conditions_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/pkdc.updatedeckname",
                KanAPIDumpState.Normal,
                 req_member_updatedeckname_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/pkdc.updatecomment",
                KanAPIDumpState.Normal,
                 req_member_updatecomment_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/open_new_dock",
                KanAPIDumpState.Normal,
                 req_kousyou_open_new_dock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_nyukyo/open_new_dock",
                KanAPIDumpState.Normal,
                 req_nyukyo_open_new_dock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_auth_member/logincheck",
                KanAPIDumpState.Normal,
                 auth_member_logincheck_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/furniture",
                KanAPIDumpState.Normal,
                 get_member_furniture_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_furniture/buy",
                KanAPIDumpState.Normal,
                 req_furniture_buy_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_furniture/change",
                KanAPIDumpState.Normal,
                 req_furniture_change_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/itemuse",
                KanAPIDumpState.Normal,
                 req_member_itemuse_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/itemuse_cond",
                KanAPIDumpState.Normal,
                 req_member_itemuse_cond_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/record",
                KanAPIDumpState.Normal,
                 get_member_record_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_ranking/getlist",
                KanAPIDumpState.Normal,
                 req_ranking_getlist_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/picture_book",
                KanAPIDumpState.Normal,
                 get_member_picture_book_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/book2",
                KanAPIDumpState.Normal,
                 get_member_book2_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/get_incentive",
                KanAPIDumpState.Normal,
                 req_member_get_incentive_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_get_member/payitem",
                KanAPIDumpState.Normal,
                 get_member_payitem_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/lock",
                KanAPIDumpState.Normal,
                 req_kaisou_lock_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_mission/return_instruction",
                KanAPIDumpState.Normal,
                 req_mission_return_instruction_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_member/payitemuse",
                KanAPIDumpState.Normal,
                 req_member_payitemuse_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kaisou/marriage",
                KanAPIDumpState.Normal,
                 req_kaisou_marriage_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/remodel_slotlist",
                KanAPIDumpState.Normal,
                 req_kousyou_remodel_slotlist_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/remodel_slotlist_detail",
                KanAPIDumpState.Normal,
                 req_kousyou_remodel_slotlist_detail_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_kousyou/remodel_slot",
                KanAPIDumpState.Normal,
                 req_kousyou_remodel_slot_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_furniture/music_list",
                KanAPIDumpState.Normal,
                 req_furniture_music_list_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_furniture/music_play",
                KanAPIDumpState.Normal,
                 req_furniture_music_play_parse));
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_furniture/set_portbgm",
                KanAPIDumpState.Normal,
                 req_furniture_set_portbgm_parse));
        }
        #endregion

        #region Singleton
        private static KanDataConnector _instance = null;
        private KanDataConnector() 
        {
            Initialize();
        }
        public static KanDataConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KanDataConnector();
                }
                return _instance;
            }
        }
        #endregion

        #region DistributorIteration
        private KanAPIDistributor getDistributorFromApi(string apiStr)
        {
            foreach(KanAPIDistributor item in _apiDistributors)
            {
                if (item.apiStr == apiStr)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion
        //
        #region Variables
        private string _pathAndQuery;
        private string _requestBody;
        private string _responseBody;
        private KanReqData _req = new KanReqData();
        #endregion

        private static bool port_port_parse_firstTime = true;

        #region Log
        private void DAPILog()
        {
            // logout
        }
        #endregion

        #region Add/...
        
bool RemoveShip(int shipno)
{
    int removed = pksd.portdata.api_ship.RemoveAll(item => 
        {
            if (item.api_id == shipno)
            {
                foreach (int itemid in item.api_slot)
                {
                    RemoveSlotItem(itemid);
                }
                return true;
            }
            return false;
        });
    return removed > 0;
}

bool RemoveSlotItem(int id)
{
    return pksd.slotitemdata.RemoveAll(item => item.api_id == id) > 0;
}

bool AddShip(kcsapi_ship2 ship)
{
	if (findShipFromShipno(ship.api_id) != null)
	{
		return false;
	}
	pksd.portdata.api_ship.Add(ship);
	return true;
}

bool AddShip(int shipid, List<int> slotitems)
{
	int newid = 0;
    foreach (kcsapi_ship2 it in pksd.portdata.api_ship)
	{
		if (it.api_id > newid)
		{
			newid = it.api_id;
		}
	}
	newid++;
	kcsapi_ship2 ship = new kcsapi_ship2();
	kcsapi_mst_ship mstship = findMstShipFromShipid(shipid);
	if (mstship != null)
	{
		if (ship.ReadFromMstShip(mstship, newid))
		{
			int i = 0;
            foreach (int slotitemid in slotitems)
			{
				ship.api_slot[i] = slotitemid;
				i++;
			}
			return AddShip(ship);
		}
	}
	return false;
}

bool AddSlotItem(kcsapi_slotitem item)
{
	if (findSlotitemFromId(item.api_id) != null)
	{
		return false;
	}
	pksd.slotitemdata.Add(item);
	if (item.api_id > pksd.maxslotitemid)
	{
		pksd.maxslotitemid = item.api_id;
	}
	return true;
}

bool AddSlotItem(int id, int slotitemId)
{
	kcsapi_slotitem slotitem = new kcsapi_slotitem();
	if (id < 0)
	{
		id = pksd.maxslotitemid + 1;
	}
	slotitem.api_id = id;
	slotitem.api_slotitem_id = slotitemId;
	slotitem.api_locked = 0;
	slotitem.api_level = 0;

	return AddSlotItem(slotitem);
}
        #endregion

        #region FindShip/...
        public kcsapi_ship2 findShipFromShipno(int shipno)
        {
            foreach (kcsapi_ship2 it in pksd.portdata.api_ship)
            {
                if (it.api_id == shipno)
                {
                    return it;
                }
            }
            Console.WriteLine("No ship data.");
            return null;
        }

        public kcsapi_mst_ship findMstShipFromShipid(int shipid)
        {
            foreach (kcsapi_mst_ship v in pksd.start2data.api_mst_ship)
            {
                if (v.api_id == shipid)
                {
                    return v;
                }
            }
            Console.WriteLine("No mst ship data.");
            return null;
        }

        public Api_Mst_Mission findMstMissionFromMissionid(int missionid)
        {
            foreach (Api_Mst_Mission v in pksd.start2data.api_mst_mission)
            {
                if (v.api_id == missionid)
                {
                    return v;
                }
            }
            Console.WriteLine("No mst mission data.");
            return null;
        }

        public kcsapi_slotitem findSlotitemFromId(int id)
        {
            foreach (kcsapi_slotitem it in pksd.slotitemdata)
            {
                if (it.api_id == id)
                {
                    return it;
                }
            }
            Console.WriteLine("No slotitem data.");
            return null;
        }

        public kcsapi_mst_slotitem findMstSlotItemFromSlotitemid(int slotitemid)
        {
            foreach (kcsapi_mst_slotitem v in pksd.start2data.api_mst_slotitem)
            {
                if (v.api_id == slotitemid)
                {
                    return v;
                }
            }
            Console.WriteLine("No mst slotitem data.");
            return null;
        }
        #endregion

        #region MainParse
        public bool Parse(string pathAndQuery, string requestBody, string responseBody)
        {
            _pathAndQuery = pathAndQuery;
            _requestBody = requestBody;
            _responseBody = responseBody;

            var json = DynamicJson.Parse(responseBody);
            if (json.api_result != 1)
            {
                DAPILog();
            }

            dynamic jobj;
            try
            {
                jobj = json.api_data;
            }
            catch
            {
                jobj = null;
            }

            _req.ReadFromString(_pathAndQuery, _requestBody);

            KanAPIDistributor distributor = getDistributorFromApi(_pathAndQuery);
            if (distributor == null)
            {
                DAPILog();
                return false;
            }

            if (distributor.dumpState == KanAPIDumpState.Ignore)
            {
                return true;
            }

            if (distributor.dumpState == KanAPIDumpState.Output)
            {
                DAPILog();
            }

            return distributor.func(jobj);
        }
        #endregion
        
        #region Parse
        bool start2_parse(dynamic jobj)
        {
            pksd.start2data = jobj;
            return true;
        }
        
bool port_port_parse(dynamic jobj)
{
	pksd.portdata = jobj;
	pksd.shipcountoffset = 0;
	// material, deck, ndock, ship2, basic
	pkvm.updateOverviewTable();
	pkvm.updateMissionTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();

	pkvm.updateRepairDockTable();
	pkvm.updateExpeditionTable();

	pksd.nextdata.api_no = -1;
	pkvm.updateInfoTitleBattle();
	pkvm.updateInfoTitleCond();

    if (port_port_parse_firstTime)
    {
        pkvm.updateWeaponTable();
        port_port_parse_firstTime = false;
    }

	return true;
}

bool get_member_basic_parse(dynamic jobj)
{
	pksd.portdata.api_basic = jobj;
	pkvm.updateOverviewTable();
	return true;
}

bool get_member_ship_parse(dynamic jobj)
{
	kcsapi_ship api_ship;
	api_ship = jobj;
	if (api_ship.api_id > 0)
	{
		kcsapi_ship2 pship = findShipFromShipno(api_ship.api_id);
		if (pship != null)
		{
			pship.ReadFromShip(api_ship);
			pkvm.updateFleetTable();
			pkvm.updateRepairTable();
			pkvm.updateInfoTitleCond();
		}
	}
	return true;
}

bool get_member_ship2_parse(dynamic jobj)
{
	pksd.portdata.api_ship.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_ship2 api_ship2item;
		api_ship2item.ReadFromJObj(jarray[i].toObject());
		pksd.portdata.api_ship.Add(api_ship2item);
	}
     */
    pksd.portdata.api_ship = jobj;

	pksd.shipcountoffset = 0;

	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();
	pkvm.updateInfoTitleCond();
	return true;
}

bool get_member_ship3_parse(dynamic jobj)
{
	kcsapi_ship3 api_ship3;
	api_ship3 = jobj;

	foreach(kcsapi_ship2 v in api_ship3.api_ship_data)
	{
        for (int i = 0; i < pksd.portdata.api_ship.Count; i++ )
        {
            if (pksd.portdata.api_ship[i].api_id == v.api_id)
            {
                pksd.portdata.api_ship[i] = v;
            }
        }
	}

	pksd.portdata.api_deck_port = api_ship3.api_deck_data;
	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();

	pksd.shipcountoffset = 0;
	pkvm.updateExpeditionTable();
	pkvm.updateInfoTitleCond();
	return true;
}

// same as ship3
bool get_member_ship_deck_parse(dynamic jobj)
{
	kcsapi_ship_deck api_ship_deck;
	api_ship_deck = jobj;

	//        pksd.portdata.api_ship = api_ship_deck.api_ship_data;
	foreach(kcsapi_ship2 v in api_ship_deck.api_ship_data)
	{
        for (int i = 0; i < pksd.portdata.api_ship.Count; i++ )
        {
            if (v.api_id == pksd.portdata.api_ship[i].api_id)
            {
                pksd.portdata.api_ship[i] = v;
            }

        }
	}

	pksd.portdata.api_deck_port = api_ship_deck.api_deck_data;
	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();

	pksd.shipcountoffset = 0;
	pkvm.updateExpeditionTable();
	pkvm.updateInfoTitleCond();
	return true;
}

bool get_member_slot_item_parse(dynamic jobj)
{
	pksd.slotitemdata.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_slotitem api_slotitem;
		api_slotitem.ReadFromJObj(jarray[i].toObject());
		pksd.slotitemdata.Add(api_slotitem);

		if (api_slotitem.api_id > pksd.maxslotitemid)
		{
			pksd.maxslotitemid = api_slotitem.api_id;
		}
	}
     */
    pksd.slotitemdata = jobj;
    foreach (kcsapi_slotitem it in pksd.slotitemdata)
    {
        if (it.api_id > pksd.maxslotitemid)
        {
            pksd.maxslotitemid = it.api_id;
        }
    }

	pksd.slotitemcountoffset = 0;

	pkvm.updateOverviewTable();
	pkvm.updateWeaponTable();
	//TODO: pkdc.update tootip?
	return true;
}

bool get_member_useitem_parse(dynamic jobj)
{
	return true;
}

bool get_member_deck_parse(dynamic jobj)
{
	pksd.portdata.api_deck_port.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_deck api_deck;
		api_deck.ReadFromJObj(jarray[i].toObject());
		pksd.portdata.api_deck_port.Add(api_deck);
	}
     */
    pksd.portdata.api_deck_port = jobj;

	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();
	pkvm.updateInfoTitleCond();
	return true;
}

bool get_member_deck_port_parse(dynamic jobj)
{
	return get_member_deck_parse(jobj);
}

bool get_member_ndock_parse(dynamic jobj)
{
	pksd.portdata.api_ndock.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_ndock api_ndock;
		api_ndock.ReadFromJObj(jarray[i].toObject());
		pksd.portdata.api_ndock.Add(api_ndock);
	}
     */
    pksd.portdata.api_ndock = jobj;

	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	pkvm.updateRepairTable();

	pkvm.updateRepairDockTable();
	return true;
}

bool get_member_kdock_parse(dynamic jobj)
{
	pksd.kdockdata.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_kdock api_kdock;
		api_kdock.ReadFromJObj(jarray[i].toObject());
		pksd.kdockdata.Add(api_kdock);
	}
     */
    pksd.kdockdata = jobj;

	pkvm.updateBuildDockTable();

	if (pksd.createshipdata.isValueSet())
	{
		KanLogger.Instance.logBuildResult();
		pksd.createshipdata.clearValue();
	}
	return true;
}

bool get_member_material_parse(dynamic jobj)
{
	pksd.portdata.api_material.Clear();
    /*
	QJsonArray jarray = jdoc.object()["api_data"].toArray();
	for (int i = 0; i<jarray.Count; i++)
	{
		kcsapi_material api_material;
		api_material.ReadFromJObj(jarray[i].toObject());
		pksd.portdata.api_material.Add(api_material);
	}
     */
    pksd.portdata.api_material = jobj;

	pkvm.updateOverviewTable();
	return true;
}

bool req_hensei_change_parse(dynamic jobj)
{
	int team =  Convert.ToInt32(_req.GetItemAsString("api_id"));
	int index =  Convert.ToInt32(_req.GetItemAsString("api_ship_idx"));
	int shipid =  Convert.ToInt32(_req.GetItemAsString("api_ship_id"));

	List<int> lstship = (pksd.portdata.api_deck_port[team - 1].api_ship);

	while (lstship.Count < 6)
	{
		lstship.Add(-1);
	}

	if (index == -1)
	{
		shipid = lstship.First();
		lstship.Clear();
		lstship.Add(shipid);
	}
	else if (shipid == -1)
	{
		lstship.RemoveAt(index);
	}
	else
	{
		int prev = -1;
		int previndex = -1;
		if (lstship.Count >= index + 1)
		{
			prev = lstship[index];
			for (int i = 0; i<lstship.Count; i++)
			{
				if (lstship[i] == shipid)
				{
					previndex = i;
					break;
				}
			}
		}

		lstship[index] = shipid;
		if (previndex >= 0)
		{
			lstship[previndex] = prev;
		}
	}
	pkvm.updateFleetTable();
	return true;
}

bool req_hensei_lock_parse(dynamic jobj)
{
    int shipid = Convert.ToInt32(_req.GetItemAsString("api_ship_id"));
	kcsapi_hensei_lock api_hensei_lock;
	api_hensei_lock = jobj;
	kcsapi_ship2 pship = findShipFromShipno(shipid);
	if (pship != null)
	{
		pship.api_locked = api_hensei_lock.api_locked;
	}
	return true;
}

bool req_hensei_combined_parse(dynamic jobj)
{
	return true;
}

bool get_member_unsetslot_parse(dynamic jobj)
{
	// slotitem that does not on
//	kcsapi_slot_data api_unsetslot_data;
//	api_unsetslot_data = jobj;
	return true;
}

bool req_kaisou_unsetslot_all_parse(dynamic jobj)
{
    int shipno = Convert.ToInt32(_req.GetItemAsString("api_id"));
	kcsapi_ship2 ship = findShipFromShipno(shipno);
	if (ship != null)
	{
		for (int i = 0; i < ship.api_slot.Count; i++)
		{
			ship.api_slot[i] = -1;
		}
	}

	pkvm.updateWeaponTable();
	return false;
}

bool req_kousyou_getship_parse(dynamic jobj)
{
    int kdock_id = Convert.ToInt32(_req.GetItemAsString("api_kdock_id"));
	pksd.kdockdata[kdock_id - 1].api_created_ship_id = 0;

	kcsapi_kdock_getship api_kdock_getship;
	api_kdock_getship = jobj;
	foreach(kcsapi_slotitem v in api_kdock_getship.api_slotitem)
	{
		if (v.api_slotitem_id >= 0)
		{
			AddSlotItem(v);
		}
	}

	AddShip(api_kdock_getship.api_ship);

	pkvm.updateOverviewTable();
	pkvm.updateBuildDockTable();
	pkvm.updateWeaponTable();
	return true;
}

bool req_kousyou_createitem_parse(dynamic jobj)
{
	kcsapi_createitem api_createitem;
	api_createitem = jobj;
	if (api_createitem.api_create_flag == 1)
	{
		AddSlotItem(api_createitem.api_slot_item);
	}
	for (int i = 0; i<api_createitem.api_material.Count; i++)
	{
		pksd.portdata.api_material[i].api_value = api_createitem.api_material[i];
	}

	pkvm.updateOverviewTable();
	pkvm.updateWeaponTable();

	int usefuel =Convert.ToInt32(_req.GetItemAsString("api_item1"));
	int usebull = Convert.ToInt32(_req.GetItemAsString("api_item2"));
	int usesteel = Convert.ToInt32(_req.GetItemAsString("api_item3"));
	int usebauxite = Convert.ToInt32(_req.GetItemAsString("api_item4"));
	//TODO: adjust item?
	KanLogger.Instance.logCreateItemResult(api_createitem.api_slot_item.api_slotitem_id, usefuel, usebull, usesteel, usebauxite);

	return true;
}

bool req_kousyou_createship_parse(dynamic jobj)
{
    int usefuel = Convert.ToInt32(_req.GetItemAsString("api_item1"));
    int usebull = Convert.ToInt32(_req.GetItemAsString("api_item2"));
    int usesteel = Convert.ToInt32(_req.GetItemAsString("api_item3"));
    int usebauxite = Convert.ToInt32(_req.GetItemAsString("api_item4"));
    int usedev = Convert.ToInt32(_req.GetItemAsString("api_item5"));
    int bLarge = Convert.ToInt32(_req.GetItemAsString("api_large_flag"));
    int kdockid = Convert.ToInt32(_req.GetItemAsString("api_kdock_id"));
    int highspeed = Convert.ToInt32(_req.GetItemAsString("api_highspeed"));
	if (bLarge > 0)
	{
		DAPILog();
	}

	pksd.portdata.api_material[(int)MaterialDataIndex.Fuel].api_value -= usefuel;
    pksd.portdata.api_material[(int)MaterialDataIndex.Bullet].api_value -= usebull;
    pksd.portdata.api_material[(int)MaterialDataIndex.Steel].api_value -= usesteel;
    pksd.portdata.api_material[(int)MaterialDataIndex.Bauxite].api_value -= usebauxite;
    pksd.portdata.api_material[(int)MaterialDataIndex.Development].api_value -= usedev;
	if (highspeed > 0)
	{
        pksd.portdata.api_material[(int)MaterialDataIndex.InstantBuild].api_value -= 1;
		pkvm.updateOverviewTable();
	}

	pksd.createshipdata.setValue(usefuel, usebull, usesteel, usebauxite, usedev, kdockid);

	return true;
}

bool req_kousyou_createship_speedchange_parse(dynamic jobj)
{
	int dockid = Convert.ToInt32(_req.GetItemAsString("api_kdock_id")) - 1;
	if (dockid >= 0)
	{
		pksd.kdockdata[dockid].api_complete_time = 0;
		pkvm.updateBuildDockTable();
        pksd.portdata.api_material[(int)MaterialDataIndex.InstantBuild].api_value -= 1;
		pkvm.updateOverviewTable();
	}
	return true;
}

bool req_kousyou_destroyship_parse(dynamic jobj)
{
	int shipno = Convert.ToInt32(_req.GetItemAsString("api_ship_id"));
	if (shipno > 0)
	{
		/*
		bool bDone = false;

		List<kcsapi_deck>::iterator it;
		for (it = pksd.portdata.api_deck_port.begin(); it != pksd.portdata.api_deck_port.end(); ++it)
		{
			for (int i = 0; i<it.api_ship.Count; i++)
			{
				if (it.api_ship[i] == shipno)
				{
					it.api_ship.removeAt(i);
					bDone = true;
					break;
				}
			}
			if (bDone)
			{
				break;
			}
		}

		// slotitem
		const kcsapi_ship2 * pship = findShipFromShipno(shipno);
		if (pship)
		{
			foreach(int slotitemid, pship.api_slot)
			{
				if (slotitemid >= 0)
				{
					pksd.slotitemcountoffset--;
				}
			}
		}
		*/
		// material
		kcsapi_destroyship api_destroyship;
		api_destroyship = jobj;
		List<int> api_material = api_destroyship.api_material;
		for (int i = 0; i<api_material.Count; i++)
		{
			pksd.portdata.api_material[i].api_value = api_material[i];
		}

		RemoveShip(shipno);
		pkvm.updateOverviewTable();
		pkvm.updateFleetTable();

		pkvm.updateRepairTable();
		pkvm.updateWeaponTable();
	}
	return true;
}

bool req_kousyou_destroyitem2_parse(dynamic jobj)
{
	string idsstr = _req.GetItemAsString("api_slotitem_ids");
    List<string> idslst = new List<string>(idsstr.Split(new string[]{"%2C"}, StringSplitOptions.None));

    foreach (string v in idslst)
	{
		int itemid = Convert.ToInt32(v);
		RemoveSlotItem(itemid);
	}

	kcsapi_destroyitem2 api_destroyitem2;
	api_destroyitem2 = jobj;
	List<int> api_get_material = api_destroyitem2.api_get_material;
	for (int i = 0; i<api_get_material.Count; i++)
	{
		pksd.portdata.api_material[i].api_value += api_get_material[i];
	}
	pkvm.updateOverviewTable();
	pkvm.updateWeaponTable();
	return true;
}

bool req_nyukyo_start_parse(dynamic jobj)
{
	int highspeed =  Convert.ToInt32(_req.GetItemAsString("api_highspeed"));
	int shipno =  Convert.ToInt32(_req.GetItemAsString("api_ship_id"));
	if (highspeed > 0 && shipno > 0)
	{
		kcsapi_ship2 pship = findShipFromShipno(shipno);
		if (pship != null)
		{
			pship.api_nowhp = pship.api_maxhp;
			pship.api_ndock_time = 0;
			pkvm.updateFleetTable();
			pkvm.updateRepairTable();
		}
		pksd.portdata.api_material[(int)MaterialDataIndex.InstantRepair].api_value -= 1;
		pkvm.updateOverviewTable();
	}
	return true;
}

bool req_nyukyo_speedchange_parse(dynamic jobj)
{
	int dockid =  Convert.ToInt32(_req.GetItemAsString("api_ndock_id")) - 1;
	if (dockid >= 0)
	{
		int shipno = pksd.portdata.api_ndock[dockid].api_ship_id;
		if (shipno > 0)
		{
			pksd.portdata.api_ndock[dockid].api_ship_id = 0;
			kcsapi_ship2 pship = findShipFromShipno(shipno);
			if (pship != null)
			{
				pship.api_nowhp = pship.api_maxhp;
				pship.api_ndock_time = 0;
				pkvm.updateRepairTable();
			}
			pkvm.updateRepairDockTable();
			pksd.portdata.api_material[(int)MaterialDataIndex.InstantRepair].api_value -= 1;
			pkvm.updateOverviewTable();
		}
	}
	return true;
}

bool req_hokyu_charge_parse(dynamic jobj)
{
	kcsapi_charge api_charge;
	api_charge = jobj;

	foreach(kcsapi_charge_ship v in api_charge.api_ship)
	{
		foreach (kcsapi_ship2 it in pksd.portdata.api_ship)
		{
			if (it.api_id == v.api_id)
			{
				it.api_fuel = v.api_fuel;
				it.api_bull = v.api_bull;
				break;
			}
		}
	}

	for (int i = 0; i<api_charge.api_material.Count; i++)
	{
		pksd.portdata.api_material[i].api_value = api_charge.api_material[i];
	}

	pkvm.updateFleetTable();
	return true;
}

bool req_kaisou_powerup_parse(dynamic jobj)
{
	List<string> shipsids = new List<string>(_req.GetItemAsString("api_id_items").Split(new string[]{"%2C"}, StringSplitOptions.None));
	foreach(string v in shipsids)
	{
		int shipno =  Convert.ToInt32(v);
		RemoveShip(shipno);
	}

	kcsapi_powerup api_powerup;
	api_powerup = jobj;
	pksd.portdata.api_deck_port = api_powerup.api_deck;

	pkvm.updateOverviewTable();
	pkvm.updateFleetTable();
	return true;
}

bool req_kaisou_slotset_parse(dynamic jobj)
{
	int shipno =  Convert.ToInt32(_req.GetItemAsString("api_id"));
    int slotindex = Convert.ToInt32(_req.GetItemAsString("api_slot_idx"));
	int itemid =  Convert.ToInt32(_req.GetItemAsString("api_item_id"));

	kcsapi_ship2 ship = findShipFromShipno(shipno);
	if (ship != null)
	{
		ship.api_slot[slotindex] = itemid;
		pkvm.updateWeaponTable();
		return true;
	}

	return false;
}

bool req_kaisou_remodeling_parse(dynamic jobj)
{
	//TODO
	return true;
}

bool req_mission_start_parse(dynamic jobj)
{
	// expedition
	kcsapi_mission_start api_mission_start;
	api_mission_start = jobj;

	int missionid =  Convert.ToInt32(_req.GetItemAsString("api_mission_id"));
	int deckid =  Convert.ToInt32(_req.GetItemAsString("api_deck_id"));
	if (deckid > 0)
	{
		pksd.portdata.api_deck_port[deckid - 1].api_mission[0] = 1;
		pksd.portdata.api_deck_port[deckid - 1].api_mission[1] = missionid;
		pksd.portdata.api_deck_port[deckid - 1].api_mission[2] = api_mission_start.api_complatetime;
	}
	pkvm.updateExpeditionTable();
	pkvm.updateInfoTitleCond();
	return true;
}

bool req_mission_result_parse(dynamic jobj)
{
	return true;
}

bool get_member_mission_parse(dynamic jobj)
{
	return true;
}

bool get_member_mapinfo_parse(dynamic jobj)
{
	return true;
}

bool get_member_mapcell_parse(dynamic jobj)
{
	return true;
}

bool req_map_start_parse(dynamic jobj)
{
	pksd.lastdeckid = Convert.ToInt32(_req.GetItemAsString("api_deck_id")) - 1;
	pksd.nextdata = jobj;

	pkvm.updateInfoTitleBattle();
	checkWoundQuit();
	return true;
}

bool req_map_next_parse(dynamic jobj)
{
	pksd.nextdata = jobj;

	pkvm.updateInfoTitleBattle();
	checkWoundQuit();
	return true;
}

bool req_sortie_battleresult_parse(dynamic jobj)
{
	pksd.battleresultdata = jobj;
	int shipid = pksd.battleresultdata.api_get_ship.api_ship_id;
	if (shipid > 0)
	{
		pksd.shipcountoffset++;
		kcsapi_mst_ship pmstship = findMstShipFromShipid(shipid);
		if (pmstship != null)
		{
			foreach(int slotitemid in pmstship.api_defeq)
			{
				if (slotitemid > 0)
				{
					pksd.slotitemcountoffset++;
				}
			}
		}
	}

	KanLogger.Instance.logBattleResult();
    KanLogger.Instance.logBattleDetail(false);
	return true;
}

bool req_sortie_battle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

	pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Day);
	return true;
}

bool req_battle_midnight_battle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.DayToNight);
	return true;
}

bool req_battle_midnight_sp_midnight_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Night);
	return true;
}

bool req_sortie_night_to_day_parse(dynamic jobj)
{
	//TODO night to day:
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.NightToDay);
	return true;
}

bool req_sortie_airbattle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Air);
	return true;
}

bool req_combined_battle_airbattle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Combined_KouKu);
	return true;
}

bool req_combined_battle_battlewater_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Combined_Water);
	return true;
}

bool req_combined_battle_battleresult_parse(dynamic jobj)
{
	pksd.battleresultdata = jobj;
	int shipid = pksd.battleresultdata.api_get_ship.api_ship_id;
	if (shipid > 0)
	{
		pksd.shipcountoffset++;
		kcsapi_mst_ship pmstship = findMstShipFromShipid(shipid);
		if (pmstship != null)
		{
			foreach(int slotitemid in pmstship.api_defeq)
			{
				if (slotitemid > 0)
				{
					pksd.slotitemcountoffset++;
				}
			}
		}
	}

    KanLogger.Instance.logBattleResult();
    KanLogger.Instance.logBattleDetail(true);
	return true;
}

bool req_combined_battle_battle_parse(dynamic jobj)
{
    pksd.battledata = jobj;
    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Combined_Day);
    return true;
}

bool req_combined_battle_midnight_battle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Combined_DayToNight);
	return true;
}

bool req_combined_battle_sp_midnight_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    pksd.enemyhpdata = KanBattle.updateBattle(pksd.battledata, BattleType.Combined_Nignt);
	return true;

}

bool get_member_practice_parse(dynamic jobj)
{
	return true;
}

bool req_member_get_practice_enemyinfo_parse(dynamic jobj)
{
	return true;
}

bool req_practice_battle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    KanBattle.updateBattle(pksd.battledata, BattleType.Day);
	return true;
}

bool req_practice_midnight_battle_parse(dynamic jobj)
{
	pksd.battledata = jobj;

    KanBattle.updateBattle(pksd.battledata, BattleType.Night);
	return true;
}

bool req_practice_battle_result_parse(dynamic jobj)
{
	return true;
}

bool get_member_questlist_parse(dynamic jobj)
{
	// TODO: remove quest
	kcsapi_questlist api_questlist;
	api_questlist = jobj;

	int questcount = api_questlist.api_count - 5 * (api_questlist.api_disp_page - 1);
	if (questcount > api_questlist.api_list.Count)
	{
		questcount = api_questlist.api_list.Count;
	}

	if (questcount == 0)
	{
        if (pksd.questdata.Count > 0)
        { 
            pksd.questdata.RemoveAt(pksd.questdata.Count - 1);
		    // when last page nothing??
        }
	}
	else
	{
		int beginindex = api_questlist.api_list[0].api_no;
		int endindex = api_questlist.api_list[questcount - 1].api_no;
		/*
		if (api_questlist.api_disp_page == 1)
		{
		beginindex = -1;
		}
		else if (api_questlist.api_disp_page == api_questlist.api_page_count)
		{
		endindex = 10000000;
		}
		*/

		//delete all in questdata

        pksd.questdata.RemoveAll(
            item =>
            item.api_no >= beginindex && item.api_no <= endindex);
        /*
		foreach (kcsapi_quest it in pksd.questdata)
		{
			if (it.api_no >= beginindex && it.api_no <= endindex)
			{
				it = pksd.questdata.erase(it);
			}
			else
			{
				++it;
			}
		}
         */ 

		// add to
		for (int i = 0; i<questcount; i++)
		{
			if (api_questlist.api_list[i].api_state > 1)
			{
				pksd.questdata.Add(api_questlist.api_list[i]);
			}
		}

        pksd.questdata.Sort((a, b) => a.api_no - b.api_no);
	}


	pkvm.updateMissionTable();
	return true;
}

bool req_quest_start_parse(dynamic jobj)
{
	return true;
}

bool req_quest_stop_parse(dynamic jobj)
{
    int questid = Convert.ToInt32(_req.GetItemAsString("api_quest_id"));

    pksd.questdata.RemoveAll(item => item.api_no == questid);
    /*
	foreach (kcsapi_quest it in pksd.questdata)
	{
		if (it.api_no == questid)
		{
			pksd.questdata.erase(it);
			break;
		}
	}
     */

	pkvm.updateMissionTable();
	return true;
}

bool req_quest_clearitemget_parse(dynamic jobj)
{
	kcsapi_clearitemget api_clearitemget;
	api_clearitemget = jobj;
	for (int i = 0; i < api_clearitemget.api_material.Count; i++)
	{
		pksd.portdata.api_material[i].api_value += api_clearitemget.api_material[i];
	}
	if (api_clearitemget.api_bounus_count > 0)
	{
		for (int i = 0; i < api_clearitemget.api_bounus_count; i++)
		{
			kcsapi_clearitemget_bounus bonus = api_clearitemget.api_bounus[i];
			if (bonus.api_type == 1)
			{
				int index = bonus.api_item.api_id;
				if (index < 7)
				{
					pksd.portdata.api_material[index].api_value += bonus.api_count;
				}
			}
			else if (bonus.api_type == 3)
			{
				// furniture box
			}
			else if (bonus.api_type == 12)
			{
				// item
				AddSlotItem(-1, bonus.api_item.api_id);
			}
			else
			{
				DAPILog();
			}
			// ship?
		}
	}

    int questid = Convert.ToInt32(_req.GetItemAsString("api_quest_id"));

    pksd.questdata.RemoveAll(item => item.api_no == questid);

	pkvm.updateMissionTable();
	return true;
}

bool get_member_sortie_conditions_parse(dynamic jobj)
{
	return true;
}

bool req_member_updatedeckname_parse(dynamic jobj)
{
	return true;
}

bool req_member_updatecomment_parse(dynamic jobj)
{
	return true;
}

bool req_kousyou_open_new_dock_parse(dynamic jobj)
{
	return true;
}

bool req_nyukyo_open_new_dock_parse(dynamic jobj)
{
	return true;
}

bool auth_member_logincheck_parse(dynamic jobj)
{
	return true;
}

bool get_member_furniture_parse(dynamic jobj)
{
	return true;
}

bool req_furniture_buy_parse(dynamic jobj)
{
	return true;
}

bool req_furniture_change_parse(dynamic jobj)
{
	return true;
}

bool req_member_itemuse_parse(dynamic jobj)
{
	return true;
}

bool req_member_itemuse_cond_parse(dynamic jobj)
{
	return true;
}

bool get_member_record_parse(dynamic jobj)
{
	return true;
}

bool req_ranking_getlist_parse(dynamic jobj)
{
	return true;
}

bool get_member_picture_book_parse(dynamic jobj)
{
	return true;
}

bool get_member_book2_parse(dynamic jobj)
{
	return true;
}

bool req_member_get_incentive_parse(dynamic jobj)
{
	return true;
}

bool get_member_payitem_parse(dynamic jobj)
{
	return true;
}

bool req_kaisou_lock_parse(dynamic jobj)
{
    int slotitemid = Convert.ToInt32(_req.GetItemAsString("api_slotitem_id"));

	kcsapi_kaisou_lock api_kaisou_lock;
	api_kaisou_lock = jobj;
	kcsapi_slotitem slotitem = findSlotitemFromId(slotitemid);
	if (slotitem != null)
	{
		slotitem.api_locked = api_kaisou_lock.api_locked;
		pkvm.updateWeaponTable();
	}
	return true;
}

bool req_mission_return_instruction_parse(dynamic jobj)
{
	return true;
}

bool req_member_payitemuse_parse(dynamic jobj)
{
	return true;
}

bool req_kaisou_marriage_parse(dynamic jobj)
{
	return true;
}

bool req_kousyou_remodel_slotlist_parse(dynamic jobj)
{
	return true;
}

bool req_kousyou_remodel_slotlist_detail_parse(dynamic jobj)
{
	return true;
}

bool req_kousyou_remodel_slot_parse(dynamic jobj)
{
    int oslotitemid = Convert.ToInt32(_req.GetItemAsString("api_slot_id"));

	kcsapi_remodel_slot api_remodel_slot;
	api_remodel_slot = jobj;
	if (oslotitemid == api_remodel_slot.api_after_slot.api_id)
	{
		kcsapi_slotitem slotitem = findSlotitemFromId(oslotitemid);
        if (slotitem != null)
        {
            slotitem.ReadFromSlotItem(api_remodel_slot.api_after_slot);
        }
	}
	else
	{
		RemoveSlotItem(oslotitemid);
		AddSlotItem(api_remodel_slot.api_after_slot);
	}
	pkvm.updateWeaponTable();

	return true;
}

bool req_furniture_music_list_parse(dynamic jobj)
{
	return true;
}

bool req_furniture_music_play_parse(dynamic jobj)
{
	return true;
}

bool req_furniture_set_portbgm_parse(dynamic jobj)
{
	return true;
}

        #endregion
    }
}
