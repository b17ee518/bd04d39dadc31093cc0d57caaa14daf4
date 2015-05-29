using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    public abstract class KAPIBaseData
    {
        public KAPIBaseData() { }
    }
    
    public class kcsapi_basic : KAPIBaseData
    {
    	public kcsapi_basic() { }
        
        public string api_member_id {get; set;}
        public string api_nickname {get; set;}
        public string api_nickname_id {get; set;}
        public int api_active_flag {get; set;}
        private Int64 _api_starttime = new Int64(); public Int64 api_starttime { get { return _api_starttime; } set { _api_starttime = value; } }
        public int api_level {get; set;}
        public int api_rank {get; set;}
        public int api_experience {get; set;}
    	public string api_fleetname {get; set;}  //object
    	public string api_comment {get; set;}
    	public string api_comment_id {get; set;}
    	public int api_max_chara {get; set;}
    	public int api_max_slotitem {get; set;}
    	public int api_max_kagu {get; set;}
    	public int api_playtime {get; set;}
        public int api_tutorial { get; set; }
        private List<int> _api_furniture = new List<int>(); public List<int> api_furniture { get { return _api_furniture; } set { _api_furniture = value; } }
    	public int api_count_deck {get; set;}
    	public int api_count_kdock {get; set;}
    	public int api_count_ndock {get; set;}
    	public int api_fcoin {get; set;}
    	public int api_st_win {get; set;}
    	public int api_st_lose {get; set;}
    	public int api_ms_count {get; set;}
    	public int api_ms_success {get; set;}
    	public int api_pt_win {get; set;}
    	public int api_pt_lose {get; set;}
    	public int api_pt_challenged {get; set;}
    	public int api_pt_challenged_win {get; set;}
    	public int api_firstflag {get; set;}
	    public int api_tutorial_progress {get; set;}
        private List<int> _api_pvp = new List<int>(); public List<int> api_pvp { get { return _api_pvp; } set { _api_pvp = value; } }
	    // "api_large_dock":1
    }
    
    public class kcsapi_battle_kouku_stage1 : KAPIBaseData
    {
	    public kcsapi_battle_kouku_stage1(){}
	     
	    public int api_f_count {get; set;}
	    public int api_f_lostcount {get; set;}
	    public int api_e_count {get; set;}
	    public int api_e_lostcount {get; set;}
	    public int api_disp_seiku {get; set;}
        private List<int> _api_touch_plane = new List<int>(); public List<int> api_touch_plane { get { return _api_touch_plane; } set { _api_touch_plane = value; } }
    }

    public class kcsapi_battle_kouku_stage2 : KAPIBaseData
    {

	    public kcsapi_battle_kouku_stage2(){}
	    
	    public int api_f_count {get; set;}
	    public int api_f_lostcount {get; set;}
	    public int api_e_count {get; set;}
	    public int api_e_lostcount {get; set;}
    }

    public class kcsapi_battle_kouku_stage3 : KAPIBaseData
    {
        public kcsapi_battle_kouku_stage3(){}

	    // from #1
        public List<int> api_frai_flag = new List<int>();
        public List<int> api_erai_flag = new List<int>();
        public List<int> api_fbak_flag = new List<int>();
        public List<int> api_ebak_flag = new List<int>();
        public List<int> api_fcl_flag = new List<int>();
        public List<int> api_ecl_flag = new List<int>();
        public List<Double> api_fdam = new List<Double>();
        public List<Double> api_edam = new List<Double>();
    }

    public class kcsapi_battle_kouku : KAPIBaseData
    {

	    public kcsapi_battle_kouku(){}

        public List<List<int>> api_plane_from = new List<List<int>>(); //? f, e list
        public kcsapi_battle_kouku_stage1 api_stage1 = new kcsapi_battle_kouku_stage1();
        public kcsapi_battle_kouku_stage2 api_stage2 = new kcsapi_battle_kouku_stage2();
        public kcsapi_battle_kouku_stage3 api_stage3 = new kcsapi_battle_kouku_stage3();
	    // combined
	    public kcsapi_battle_kouku_stage3 api_stage3_combined = new kcsapi_battle_kouku_stage3();
    }

    public class kcsapi_battle_support_airatack_stage1 : KAPIBaseData
    {

	    public kcsapi_battle_support_airatack_stage1(){}
	    
	    public int api_f_count {get; set;}
	    public int api_f_lostcount {get; set;}
	    public int api_e_count {get; set;}
	    public int api_e_lostcount {get; set;}
    }
    public class kcsapi_battle_support_airatack_stage2 : KAPIBaseData
    {

	    public kcsapi_battle_support_airatack_stage2(){}
	    
	    public int api_f_count {get; set;}
	    public int api_f_lostcount {get; set;}
    }
    public class kcsapi_battle_support_airatack_stage3 : KAPIBaseData
    {

	    public kcsapi_battle_support_airatack_stage3(){}

        public List<int> api_erai_flag = new List<int>();
        public List<int> api_ebak_flag = new List<int>();
        public List<int> api_ecl_flag = new List<int>();
        public List<Double> api_edam = new List<Double>();
    }

    public class kcsapi_battle_support_airatack : KAPIBaseData
    {

	    public kcsapi_battle_support_airatack(){}
	    
	    public int api_deck_id {get; set;}
        public List<int> api_ship_id = new List<int>();
        public List<int> api_undressing_flag = new List<int>(); //??
        public List<int> api_stage_flag = new List<int>();
        public List<List<int>> api_plane_from = new List<List<int>>();
        public kcsapi_battle_support_airatack_stage1 api_stage1 = new kcsapi_battle_support_airatack_stage1();
        public kcsapi_battle_support_airatack_stage2 api_stage2 = new kcsapi_battle_support_airatack_stage2();
        public kcsapi_battle_support_airatack_stage3 api_stage3 = new kcsapi_battle_support_airatack_stage3();
    }

    public class kcsapi_battle_support_hourai : KAPIBaseData
    {

	    public kcsapi_battle_support_hourai(){}
	    
	    public int api_deck_id {get; set;}
        public List<int> api_ship_id = new List<int>();
        public List<int> api_undressing_flag = new List<int>();
        public List<int> api_cl_list = new List<int>();
        public List<Double> api_damage = new List<Double>();
    }

    public class kcsapi_battle_support_info : KAPIBaseData
    {

	    public kcsapi_battle_support_info(){}
	    
	    //TODO: support info
        public kcsapi_battle_support_airatack api_support_airatack = new kcsapi_battle_support_airatack();
        public kcsapi_battle_support_hourai api_support_hourai = new kcsapi_battle_support_hourai();
    }

    public class kcsapi_battle_opening_atack : KAPIBaseData
    {

	    public kcsapi_battle_opening_atack(){}
	    
	    // from #1
        public List<int> api_frai = new List<int>();
        public List<int> api_erai = new List<int>();
        public List<Double> api_fdam = new List<Double>();
        public List<Double> api_edam = new List<Double>();
        public List<Double> api_fydam = new List<Double>();
        public List<Double> api_eydam = new List<Double>();
        public List<int> api_fcl = new List<int>();
        public List<int> api_ecl = new List<int>();
    }

    public class kcsapi_battle_hougeki : KAPIBaseData
    {
	    public kcsapi_battle_hougeki(){}

        public List<int> api_at_list = new List<int>();
        public List<int> api_at_type = new List<int>();
	    /*
	    public 0 砲撃
	    public 1 レーザー
	    public 2　連続砲撃
	    public 3　偵察主砲副砲
	    public 4　偵察電探主砲
	    public 5　偵察主砲徹甲
	    public 6　偵察主砲主砲
	    public 7　航空
	    public 8　爆雷
	    public */
	    // must skip #0
        public List<List<int>> api_df_list = new List<List<int>>();
        public List<List<int>> api_si_list = new List<List<int>>();
        public List<List<int>> api_cl_list = new List<List<int>>();

	    // midnight
        public List<int> api_sp_list = new List<int>();
	    /*
	    public 0　通常
	    public 1　連続
	    public 2　主砲雷撃
	    public 3　雷撃雷撃
	    public 4　主砲主砲副砲
	    public 5　主砲主砲主砲
	    public */

        public List<List<Double>> api_damage = new List<List<double>>();
    }

    public class kcsapi_battle_raigeki : KAPIBaseData
    {

	    public kcsapi_battle_raigeki(){}
	    
	    // from #1
        public List<int> api_frai = new List<int>();
        public List<int> api_erai = new List<int>();
	    public List<Double> api_fdam = new List<double>();
	    public List<Double> api_edam = new List<double>();
	    public List<Double> api_fydam = new List<double>();
        public List<Double> api_eydam = new List<double>();
        public List<int> api_fcl = new List<int>();
        public List<int> api_ecl = new List<int>();
    }
    /************************************************************************/
    /* battle and midnight_battle                                           */
    /************************************************************************/
    public class kcsapi_battle : KAPIBaseData
    {

	    public kcsapi_battle(){}
	    
	    public int api_dock_id {get; set;}
	    //midnight
	    //TODO: check practice
	    public int api_deck_id {get; set;}
	    public string api_deck_id_s {get; set;}

        public List<int> api_ship_ke = new List<int>(); //enemy ship list from #1
        public List<int> api_ship_lv = new List<int>(); //enemy ship lv from #1
        public List<int> api_nowhps = new List<int>(); // both hps from #1 (13)
        public List<int> api_maxhps = new List<int>();

	    // combined
        public List<int> api_nowhps_combined = new List<int>();
        public List<int> api_maxhps_combined = new List<int>();
	    
	    public int api_midnight_flag {get; set;}
        public List<List<int>> api_eSlot = new List<List<int>>(); // from #0
        public List<List<int>> api_eKyouka = new List<List<int>>(); // from #0
        public List<List<int>> api_fParam = new List<List<int>>(); // from #0
	    // combined
        public List<List<int>> api_fParam_combined = new List<List<int>>(); // from #0
        public List<List<int>> api_eParam = new List<List<int>>(); // from #0
        public List<int> api_search = new List<int>(); //?
        public List<int> api_formation = new List<int>(); // f, e, i { null, "単縦陣", "複縦陣", "輪形陣", "梯形陣", "単横陣" } { null, "同航戦", "反航戦", "Ｔ字戦(有利)", "Ｔ字戦(不利)" }
        public List<int> api_stage_flag = new List<int>(); // kouku stage1~3

	    // midnight
        public List<int> api_touch_plane = new List<int>();
        public List<int> api_flare_pos = new List<int>();

	    public kcsapi_battle_kouku api_kouku = new kcsapi_battle_kouku();
	    // combine
        public kcsapi_battle_kouku api_kouku2 = new kcsapi_battle_kouku();

	    public int api_support_flag {get; set;} //空爆1　砲撃2　雷撃3
	    public kcsapi_battle_support_info api_support_info = new kcsapi_battle_support_info();
	    public int api_opening_flag {get; set;}
	    public kcsapi_battle_opening_atack api_opening_atack = new kcsapi_battle_opening_atack();
        public List<int> api_hourai_flag = new List<int>(); // hougeki1, hougeki2, hougeki3, raigeki
	    public kcsapi_battle_hougeki api_hougeki1 = new kcsapi_battle_hougeki();
	    public kcsapi_battle_hougeki api_hougeki2 = new kcsapi_battle_hougeki();
	    public kcsapi_battle_hougeki api_hougeki3 = new kcsapi_battle_hougeki();
	    public kcsapi_battle_raigeki api_raigeki = new kcsapi_battle_raigeki();

	    // midnight
        public kcsapi_battle_hougeki api_hougeki = new kcsapi_battle_hougeki(); //midnight
    }


    public class kcsapi_battleresult_enemyinfo : KAPIBaseData
    {
	    public kcsapi_battleresult_enemyinfo(){}

	    public string api_level {get; set;}
	    public string api_rank {get; set;}
	    public string api_deck_name {get; set;}
    }

    public class kcsapi_battleresult_getship : KAPIBaseData
    {
	    public kcsapi_battleresult_getship(){}	

	    public int api_ship_id {get; set;}
	    public string api_ship_type {get; set;}
	    public string api_ship_name {get; set;}
	    public string api_ship_getmes {get; set;}
    }

    /**
     * @brief The kcsapi_battleresult class
     */
    public class kcsapi_battleresult : KAPIBaseData
    {
	    public kcsapi_battleresult(){}

        public List<int> api_ship_id = new List<int>();
	    public string api_win_rank {get; set;}
	    public int api_get_exp {get; set;}
	    public int api_mvp {get; set;}
	    // combined
	    public int api_mvp_combined {get; set;}

	    public int api_member_lv {get; set;}
	    public int api_member_exp {get; set;}
	    public int api_get_base_exp {get; set;}
        public List<int> api_get_ship_exp = new List<int>();
        public List<List<int>> api_get_exp_lvup = new List<List<int>>();
	    // combined
        public List<int> api_get_ship_exp_combined = new List<int>();
        public List<List<int>> api_get_exp_lvup_combined = new List<List<int>>();

	    public int api_dests {get; set;}
	    public int api_destsf {get; set;}
        public List<int> api_lost_flag = new List<int>();
	    public string api_quest_name {get; set;}
	    public int api_quest_level {get; set;}
        public kcsapi_battleresult_enemyinfo api_enemy_info = new kcsapi_battleresult_enemyinfo();
	    public int api_first_clear {get; set;}
        public List<int> api_get_flag = new List<int>();
        public kcsapi_battleresult_getship api_get_ship = new kcsapi_battleresult_getship();
	    public int api_get_eventflag {get; set;}
	    public int api_get_exmap_rate {get; set;}
	    public int api_get_exmap_useitem_id {get; set;}
    }

    public class kcsapi_practice_enemyinfo_deck_ships : KAPIBaseData
    {
	    public kcsapi_practice_enemyinfo_deck_ships(){}

	    public int api_id {get; set;}
	    public int api_shipid {get; set;}
	    public int api_level {get; set;}
	    public int api_star {get; set;}
    }

    public class kcsapi_practice_enemyinfo_deck : KAPIBaseData
    {
	    public kcsapi_practice_enemyinfo_deck(){}
	     
	    public List<kcsapi_practice_enemyinfo_deck_ships> api_ships = new List<kcsapi_practice_enemyinfo_deck_ships>();
    }

    /************************************************************************/
    /*                                                                      */
    /************************************************************************/
    public class kcsapi_practice_enemyinfo : KAPIBaseData
    {
	    public kcsapi_practice_enemyinfo(){}	

	    public int api_member_id {get; set;}
	    public string api_nickname {get; set;}
	    public string api_nickname_id {get; set;}
	    public string api_cmt {get; set;}
	    public string api_cmt_id {get; set;}
	    public int api_level {get; set;}
	    public int api_rank {get; set;}
        public List<int> api_experience = new List<int>();
	    public int api_friend {get; set;}
        public List<int> api_ship = new List<int>();
        public List<int> api_slotitem = new List<int>();
	    public int api_furniture {get; set;}
	    public string api_deckname {get; set;}
	    public string api_deckname_id {get; set;}
        public kcsapi_practice_enemyinfo_deck api_deck = new kcsapi_practice_enemyinfo_deck();
    }


    /**
     * @brief The kcsapi_slotitem class
     */
    public class kcsapi_slotitem : KAPIBaseData
    {
	    public kcsapi_slotitem(){}

	    public bool ReadFromSlotItem(kcsapi_slotitem slotitem)
        {
	        if (slotitem.api_id == this.api_id)
	        {
	    	    this.api_slotitem_id = slotitem.api_slotitem_id;
	    	    this.api_locked = slotitem.api_locked;
	    	    this.api_level = slotitem.api_level;
	    	    return true;
	        }
            return false;
        }

	    public int api_id {get; set;}
	    public int api_slotitem_id {get; set;}
        public int api_locked {get; set;}
	    public int api_level {get; set;}
    }


    public class kcsapi_charge_ship : KAPIBaseData
    {
	    public kcsapi_charge_ship(){}

	    public int api_id {get; set;}
	    public int api_fuel {get; set;}
	    public int api_bull {get; set;}
        public List<int> api_onslot = new List<int>();
    }

    /**
     * @brief The kcsapi_charge class
     */
    public class kcsapi_charge : KAPIBaseData
    {
	    public kcsapi_charge(){}

        public List<kcsapi_charge_ship> api_ship = new List<kcsapi_charge_ship>();
        public List<int> api_material = new List<int>();
	    public int api_use_bou {get; set;}
    }

    /**
     * @brief The kcsapi_createitem class
     */
    public class kcsapi_createitem : KAPIBaseData
    {
	    public kcsapi_createitem(){}

	    public int api_id {get; set;}
	    public int api_slotitem_id {get; set;}
	    public int api_create_flag {get; set;}
	    public int api_shizai_flag {get; set;}
        public kcsapi_slotitem api_slot_item = new kcsapi_slotitem();
        public List<int> api_material = new List<int>();
	    public int api_type3 {get; set;}
        public List<int> api_unsetslot = new List<int>();
    }


    /**
     * @brief The kcsapi_deck class
     */
    public class kcsapi_deck : KAPIBaseData
    {
	    public kcsapi_deck(){}

	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public string api_name {get; set;}
	    public string api_name_id {get; set;}
        public List<Int64> api_mission = new List<Int64>();
	    public string api_flagship {get; set;}
        public List<int> api_ship = new List<int>();
    }

    /**
     * @brief The kcsapi_destroyitem2 class
     */
    public class kcsapi_destroyitem2 : KAPIBaseData
    {
	    public kcsapi_destroyitem2(){}

        public List<int> api_get_material = new List<int>();
    }

    /**
     * @brief The kcsapi_destroyship class
     */
    public class kcsapi_destroyship : KAPIBaseData
    {
	    public kcsapi_destroyship(){}

        public List<int> api_material = new List<int>();
    }

    /**
     * @brief The kcsapi_kdock class
     */
    public class kcsapi_kdock : KAPIBaseData
    {
	    public kcsapi_kdock(){}
	     
	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public int api_state {get; set;}
	    public int api_created_ship_id {get; set;}
	    public Int64 api_complete_time = new Int64();
	    public string api_complete_time_str {get; set;}
	    public int api_item1 {get; set;}
	    public int api_item2 {get; set;}
	    public int api_item3 {get; set;}
	    public int api_item4 {get; set;}
	    public int api_item5 {get; set;}
    }

    /**
     * @brief The kcsapi_ship class
     */
    public class kcsapi_ship: KAPIBaseData
    {
	    public kcsapi_ship(){}

	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_name {get; set;}
	    public string api_yomi {get; set;}
	    public int api_stype {get; set;}
	    public int api_ship_id {get; set;}
	    public int api_lv {get; set;}
	    public int api_exp {get; set;}
	    public int api_afterlv {get; set;}
	    public int api_aftershipid {get; set;}
	    public int api_nowhp {get; set;}
	    public int api_maxhp {get; set;}
        public List<int> api_taik = new List<int>();
        public List<int> api_souk = new List<int>();
        public List<int> api_houg = new List<int>();
        public List<int> api_raig = new List<int>();
        public List<int> api_baku = new List<int>();
        public List<int> api_tyku = new List<int>();
        public List<int> api_houm = new List<int>();
        public List<int> api_raim = new List<int>();
        public List<int> api_saku = new List<int>();
        public List<int> api_luck = new List<int>();
	    public int api_soku {get; set;}
	    public int api_leng {get; set;}
        public List<int> api_slot = new List<int>();
        public List<int> api_onslot = new List<int>();
        public List<int> api_broken = new List<int>();
        public List<int> api_powup = new List<int>();
        public List<int> api_kyouka = new List<int>();
	    public int api_backs {get; set;}
	    public int api_fuel {get; set;}
	    public int api_fuel_max {get; set;}
	    public int api_bull {get; set;}
	    public int api_bull_max {get; set;}
	    public string api_gomes {get; set;}    //o
	    public string api_gomes2 {get; set;}   //o
	    public int api_slotnum {get; set;}
	    public int api_ndock_time {get; set;}
	    public string api_ndock_time_str {get; set;}
        public List<int> api_ndock_item = new List<int>();
	    public int api_star {get; set;}
	    public int api_srate {get; set;}
	    public int api_cond {get; set;}
        public List<int> api_karyoku = new List<int>();
        public List<int> api_raisou = new List<int>();
        public List<int> api_taiku = new List<int>();
        public List<int> api_soukou = new List<int>();
        public List<int> api_kaihi = new List<int>();
        public List<int> api_taisen = new List<int>();
        public List<int> api_sakuteki = new List<int>();
        public List<int> api_lucky = new List<int>();
	    public int api_use_fuel {get; set;}
	    public int api_use_bull {get; set;}
	    public int api_voicef {get; set;}
    }

    /**
    * @brief The kcsapi_mst_ship class
    */
    public class kcsapi_mst_ship : KAPIBaseData
    {
	    public kcsapi_mst_ship(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_name {get; set;}
	    public string api_yomi {get; set;}
	    public int api_stype {get; set;}
	    public int api_ctype {get; set;}
	    public int api_cnum {get; set;}
	    public string api_enqflg {get; set;}
	    public int api_afterlv {get; set;}
	    public string api_aftershipid {get; set;}
	    public List<int> api_taik = new List<int>();
	    public List<int> api_souk = new List<int>();
	    public List<int> api_tous = new List<int>();
	    public List<int> api_houg = new List<int>();
	    public List<int> api_raig = new List<int>();
	    public List<int> api_baku = new List<int>();
	    public List<int> api_tyku = new List<int>();
	    public List<int> api_atap = new List<int>();
	    public List<int> api_tais = new List<int>();
	    public List<int> api_houm = new List<int>();
	    public List<int> api_raim = new List<int>();
	    public List<int> api_kaih = new List<int>();
	    public List<int> api_houk = new List<int>();
	    public List<int> api_raik = new List<int>();
	    public List<int> api_bakk = new List<int>();
	    public List<int> api_saku = new List<int>();
	    public List<int> api_sakb = new List<int>();
	    public List<int> api_luck = new List<int>();
	    public int api_sokuh {get; set;}
	    public int api_soku {get; set;}
        public int api_leng { get; set; }
        public List<int> api_grow = new List<int>();
        public int api_slot_num {get; set;}
        public List<int> api_maxeq = new List<int>();
        public List<int> api_defeq = new List<int>();
        public int api_buildtime {get; set;}
        public List<int> api_broken = new List<int>();
        public List<int> api_powup = new List<int>();
        public List<int> api_gumax = new List<int>();
	    public int api_backs {get; set;}
	    public string api_getmes {get; set;}
	    public string api_homemes {get; set;}  //o
	    public string api_gomes {get; set;}    //o
	    public string api_gomes2 {get; set;}   //o
	    public string api_sinfo {get; set;}
	    public int api_afterfuel {get; set;}
	    public int api_afterbull {get; set;}
	    public List<string> api_touchs = new List<string>(); //o
	    public string api_missions {get; set;} //o
	    public string api_systems {get; set;}  //o
	    public int api_fuel_max {get; set;}
	    public int api_bull_max {get; set;}
	    public int api_voicef {get; set;}
    }

    /**
     * @brief The kcsapi_ship2 class
     */
    public class kcsapi_ship2 : KAPIBaseData
    {
	    public kcsapi_ship2(){}
        
	    public bool ReadFromShip(kcsapi_ship ship)
        {
	        if (ship.api_id == api_id)
	        {
	    	    api_id = ship.api_id;
	    	    api_sortno = ship.api_sortno;
	    	    api_ship_id = ship.api_ship_id;
	    	    api_lv = ship.api_ship_id;
        //        api_exp = ship.api_exp;
	    	    api_nowhp = ship.api_nowhp;
	    	    api_maxhp = ship.api_maxhp;
	    	    api_leng = ship.api_leng;
	    	    api_slot = ship.api_slot;
	    	    api_onslot = ship.api_onslot;
	    	    api_kyouka = ship.api_kyouka;
	    	    api_backs = ship.api_backs;
	    	    api_fuel = ship.api_fuel;
	    	    api_bull = ship.api_bull;
	    	    api_slotnum = ship.api_slotnum;
	    	    api_ndock_time = ship.api_ndock_time;
	    	    api_ndock_item = ship.api_ndock_item;
	    	    api_srate = ship.api_srate;
	    	    api_cond = ship.api_cond;
	    	    api_karyoku = ship.api_karyoku;
	    	    api_raisou = ship.api_raisou;
	    	    api_taiku = ship.api_taiku;
	    	    api_soukou = ship.api_soukou;
	    	    api_kaihi = ship.api_kaihi;
	    	    api_taisen = ship.api_taisen;
	    	    api_sakuteki = ship.api_sakuteki;
	    	    api_lucky = ship.api_lucky;
	    	    return true;
	        }
	        return false;
        }
	    public bool ReadFromMstShip(kcsapi_mst_ship mstship, int id)
        {
	        api_id = id;
	        api_sortno = mstship.api_sortno;
	        api_ship_id = mstship.api_id;
	        api_lv = 1;

            api_exp.Clear();
	        api_exp.Add(0); // total exp
	        api_exp.Add(100); // next level exp
	        api_exp.Add(0); // ?

	        api_nowhp = mstship.api_taik.First();
	        api_maxhp = api_nowhp;
	        api_leng = mstship.api_leng;

	        //add slotitem later
	        api_slot.Clear();
	        api_slot.Add(-1);
	        api_slot.Add(-1);
	        api_slot.Add(-1);
	        api_slot.Add(-1);
	        api_slot.Add(-1);

            api_onslot.Clear();
	        api_onslot.Add(0);
	        api_onslot.Add(0);
	        api_onslot.Add(0);
	        api_onslot.Add(0);
	        api_onslot.Add(0);

            api_kyouka.Clear();
	        api_kyouka.Add(0);
	        api_kyouka.Add(0);
	        api_kyouka.Add(0);
	        api_kyouka.Add(0);
	        api_kyouka.Add(0);

	        api_backs = mstship.api_backs;
	        api_fuel = mstship.api_fuel_max;
	        api_bull = mstship.api_bull_max;
	        api_slotnum = mstship.api_slot_num;
	        api_ndock_time = 0;

            api_ndock_item.Clear();
	        api_ndock_item.Add(0);
	        api_ndock_item.Add(0);

	        api_srate = api_backs; //?
	        api_cond = 40;

	        // no data
            api_karyoku.Clear();
	        api_karyoku.Add(0);
	        api_karyoku.Add(0);
            api_raisou.Clear();
	        api_raisou.Add(0);
	        api_raisou.Add(0);
            api_taiku.Clear();
	        api_taiku.Add(0);
	        api_taiku.Add(0);
            api_soukou.Clear();
	        api_soukou.Add(0);
	        api_soukou.Add(0);
            api_kaihi.Clear();
	        api_kaihi.Add(0);
	        api_kaihi.Add(0);
            api_taisen.Clear();
	        api_taisen.Add(0);
	        api_taisen.Add(0);
            api_sakuteki.Clear();
	        api_sakuteki.Add(0);
	        api_sakuteki.Add(0);
            api_lucky.Clear();
	        api_lucky.Add(0);
	        api_lucky.Add(0);

	        api_locked = 0;
	        api_locked_equip = 0;
	        api_sally_area = 0;

	        return false;
        }

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public int api_ship_id {get; set;}
	    public int api_lv {get; set;}
	    public List<int> api_exp = new List<int>();
	    public int api_nowhp {get; set;}
	    public int api_maxhp {get; set;}
	    public int api_leng {get; set;}	// short .. super long
	    public List<int> api_slot = new List<int>();
	    public List<int> api_onslot = new List<int>();
	    public List<int> api_kyouka = new List<int>();
	    public int api_backs {get; set;}
	    public int api_fuel {get; set;}
	    public int api_bull {get; set;}
	    public int api_slotnum {get; set;}
        public Int64 api_ndock_time = new Int64();
	    public List<int> api_ndock_item = new List<int>(); // fuel bull.ndock
	    public int api_srate {get; set;}	// normal .. ss
        public int api_cond {get; set;}
        public List<int> api_karyoku = new List<int>();
        public List<int> api_raisou = new List<int>();
        public List<int> api_taiku = new List<int>();
        public List<int> api_soukou = new List<int>();
        public List<int> api_kaihi = new List<int>();
        public List<int> api_taisen = new List<int>();
        public List<int> api_sakuteki = new List<int>();
        public List<int> api_lucky = new List<int>();
	    public int api_locked {get; set;}
	    public int api_locked_equip {get; set;}
	    public int api_sally_area {get; set;}
    }

    /**
     * @brief The kcsapi_kdock_getship class
     */
    public class kcsapi_kdock_getship : KAPIBaseData
    {
	    public kcsapi_kdock_getship(){}

	    public int api_id {get; set;}
	    public int api_ship_id {get; set;}
	    public List<kcsapi_kdock> api_kdock = new List<kcsapi_kdock>();
	    public kcsapi_ship2 api_ship = new kcsapi_ship2();
        public List<kcsapi_slotitem> api_slotitem = new List<kcsapi_slotitem>();
    }

    /**
     * @brief The kcsapi_material class
     */
    public class kcsapi_material: KAPIBaseData
    {
	    public kcsapi_material(){}

	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public int api_value {get; set;}
    }


    /**
     * @brief The kcsapi_mst_slotitem class
     */
    public class kcsapi_mst_slotitem: KAPIBaseData
    {
	    public kcsapi_mst_slotitem(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
        public string api_name { get; set; }
        public List<int> api_type = new List<int>();
	    public int api_taik {get; set;}
	    public int api_souk {get; set;}
	    public int api_houg {get; set;}
	    public int api_raig {get; set;}
	    public int api_soku {get; set;}
	    public int api_baku {get; set;}
	    public int api_tyku {get; set;}
	    public int api_tais {get; set;}
	    public int api_atap {get; set;}
	    public int api_houm {get; set;}
	    public int api_raim {get; set;}
	    public int api_houk {get; set;}
	    public int api_raik {get; set;}
	    public int api_bakk {get; set;}
	    public int api_saku {get; set;}
	    public int api_sakb {get; set;}
	    public int api_luck {get; set;}
	    public int api_leng {get; set;}
        public int api_rare {get; set;}
        public List<int> api_broken = new List<int>();
	    public string api_info {get; set;}
	    public string api_usebull {get; set;}
    }

    /**
     * @brief The kcsapi_mst_slotitem_equiptype class
     */
    public class kcsapi_mst_slotitem_equiptype: KAPIBaseData
    {
	    public kcsapi_mst_slotitem_equiptype(){}

	    public int api_id {get; set;}
	    public string api_name {get; set;}
	    public int api_show_flg {get; set;}
    }

    /**
     * @brief The kcsapi_mst_stype class
     */
    public class kcsapi_mst_stype: KAPIBaseData
    {
	    public kcsapi_mst_stype(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_name {get; set;}
	    public int api_scnt {get; set;}
	    public int api_kcnt {get; set;}
	    //"api_equip_type":{"1":0,"2":0,"3":0,"4":0,"5":0,"6":0,"7":0,"8":0,"9":0,"10":0,"11":0,"12":0,"13":0,"14":0,"15":0,"16":0,"17":0,"18":0,"19":0,"20":0,"21":0,"22":0,"23":0,"24":0,"25":0,"26":0,"27":0,"28":0,"29":0,"30":0,"31":0,"32":0,"33":0,"34":0,"35":0
    }

    /**
     * @brief The kcsapi_mst_useitem class
     */
    public class kcsapi_mst_useitem: KAPIBaseData
    {
	    public kcsapi_mst_useitem(){}

	    public int api_id {get; set;}
	    public int api_usetype {get; set;}
	    public int api_category {get; set;}
	    public string api_name {get; set;}
        public List<string> api_description = new List<string>();
	    public int api_price {get; set;}
    }

    /**
     * @brief The kcsapi_ndock class
     */
    public class kcsapi_ndock: KAPIBaseData
    {
	    public kcsapi_ndock(){}
	    
	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public int api_state {get; set;}
	    public int api_ship_id {get; set;}
        public Int64 api_complete_time = new Int64();
	    public string api_complete_time_str {get; set;}
	    public int api_item1 {get; set;}
	    public int api_item2 {get; set;}
	    public int api_item3 {get; set;}
	    public int api_item4 {get; set;}
    }


    /**
     * @brief The kcsapi_powerup class
     */
    public class kcsapi_powerup: KAPIBaseData
    {
	    public kcsapi_powerup(){}
	    
	    public int api_powerup_flag {get; set;}
	    public kcsapi_ship2 api_ship = new kcsapi_ship2();
        public List<kcsapi_deck> api_deck = new List<kcsapi_deck>();
    }

    public class kcsapi_clearitemget_bounus_item : KAPIBaseData
    {
	    public kcsapi_clearitemget_bounus_item(){}

	    public int api_id {get; set;}
	    public string api_name {get; set;}
    }

    public class kcsapi_clearitemget_bounus : KAPIBaseData
    {
	    public kcsapi_clearitemget_bounus(){}

	    public int api_type {get; set;}
	    public int api_count {get; set;}
	    //TODO: check ship
        public kcsapi_clearitemget_bounus_item api_item = new kcsapi_clearitemget_bounus_item();
    }
    /************************************************************************/
    /*                                                                      */
    /************************************************************************/
    public class kcsapi_clearitemget : KAPIBaseData
    {
	    public kcsapi_clearitemget(){}

        public List<int> api_material = new List<int>();
	    public int api_bounus_count {get; set;}
        public List<kcsapi_clearitemget_bounus> api_bounus = new List<kcsapi_clearitemget_bounus>();
    }


    /**
     * @brief The kcsapi_quest class
     */
    public class kcsapi_quest: KAPIBaseData
    {
	    public kcsapi_quest(){}

	    public int api_no {get; set;}
	    public int api_category {get; set;}
	    public int api_type {get; set;}
	    public int api_state {get; set;}
	    public string api_title {get; set;}
        public string api_detail { get; set; }
        public List<int> api_get_material = new List<int>();
	    public int api_bonus_flag {get; set;}
	    public int api_progress_flag {get; set;}
    }

    /**
     * @brief The kcsapi_questlist class
     */
    public class kcsapi_questlist: KAPIBaseData
    {
	    public kcsapi_questlist(){}
    
	    public int api_count {get; set;}
	    public int api_page_count {get; set;}
	    public int api_disp_page {get; set;}
        public List<kcsapi_quest> api_list = new List<kcsapi_quest>();
	    public int api_exec_count {get; set;}
    }


    /**
     * @brief The kcsapi_ship3 class
     */
    public class kcsapi_ship3: KAPIBaseData
    {
	    public kcsapi_ship3(){}

	    public List<kcsapi_ship2> api_ship_data = new List<kcsapi_ship2>();
        public List<kcsapi_deck> api_deck_data = new List<kcsapi_deck>();

	    //
	    //public kcsapi_slot_data api_slot_data = new
    }

    /**
    * @brief The kcsapi_ship_deck class
    */
    public class kcsapi_ship_deck : KAPIBaseData
    {
	    public kcsapi_ship_deck(){}

	    public List<kcsapi_ship2> api_ship_data = new List<kcsapi_ship2>();
        public List<kcsapi_deck> api_deck_data = new List<kcsapi_deck>();
    }

    public class kcsapi_slot_data: KAPIBaseData
    {
	    public kcsapi_slot_data(){}

        public List<int> api_slottype1 = new List<int>();
        public List<int> api_slottype2 = new List<int>();
        public List<int> api_slottype3 = new List<int>();
        public List<int> api_slottype4 = new List<int>();
        public List<int> api_slottype5 = new List<int>();
        public List<int> api_slottype6 = new List<int>();
        public List<int> api_slottype7 = new List<int>();
        public List<int> api_slottype8 = new List<int>();
        public List<int> api_slottype9 = new List<int>();
        public List<int> api_slottype10 = new List<int>();
        public List<int> api_slottype11 = new List<int>();
        public List<int> api_slottype12 = new List<int>();
        public List<int> api_slottype13 = new List<int>();
        public List<int> api_slottype14 = new List<int>();
        public List<int> api_slottype15 = new List<int>();
        public List<int> api_slottype16 = new List<int>();
        public List<int> api_slottype17 = new List<int>();
        public List<int> api_slottype18 = new List<int>();
        public List<int> api_slottype19 = new List<int>();
        public List<int> api_slottype20 = new List<int>();
        public List<int> api_slottype21 = new List<int>();
        public List<int> api_slottype22 = new List<int>();
        public List<int> api_slottype23 = new List<int>();
        public List<int> api_slottype24 = new List<int>();
        public List<int> api_slottype25 = new List<int>();
        public List<int> api_slottype26 = new List<int>();
        public List<int> api_slottype27 = new List<int>();
        public List<int> api_slottype28 = new List<int>();
        public List<int> api_slottype29 = new List<int>();
        public List<int> api_slottype30 = new List<int>();
        public List<int> api_slottype31 = new List<int>();
        public List<int> api_slottype32 = new List<int>();
        public List<int> api_slottype33 = new List<int>();
        public List<int> api_slottype34 = new List<int>();
        public List<int> api_slottype35 = new List<int>();
        public List<int> api_slottype36 = new List<int>();
    }

    public class Api_Mst_Item_Shop: KAPIBaseData
    {
	    public Api_Mst_Item_Shop(){}

        public List<int> api_cabinet_1 = new List<int>();
        public List<int> api_cabinet_2 = new List<int>();
    }

    public class Api_Boko_Max_Ships: KAPIBaseData
    {
	    public Api_Boko_Max_Ships(){}

	    public string api_string_value {get; set;}
	    public int api_int_value {get; set;}
    }

    public class Api_Mst_Const: KAPIBaseData
    {
	    public Api_Mst_Const(){}

        public Api_Boko_Max_Ships api_boko_max_ships = new Api_Boko_Max_Ships();
    }


    public class Api_Mst_Ship: KAPIBaseData
    {
	    public Api_Mst_Ship(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_name {get; set;}
	    public string api_yomi {get; set;}
	    public int api_stype {get; set;}
	    public int api_ctype {get; set;}
	    public int api_cnum {get; set;}
	    public string api_enqflg {get; set;}
	    public int api_afterlv {get; set;}
        public string api_aftershipid { get; set; }
        public List<int> api_taik = new List<int>();
        public List<int> api_souk = new List<int>();
        public List<int> api_tous = new List<int>();
        public List<int> api_houg = new List<int>();
        public List<int> api_raig = new List<int>();
        public List<int> api_baku = new List<int>();
        public List<int> api_tyku = new List<int>();
        public List<int> api_atap = new List<int>();
        public List<int> api_tais = new List<int>();
        public List<int> api_houm = new List<int>();
        public List<int> api_raim = new List<int>();
        public List<int> api_kaih = new List<int>();
        public List<int> api_houk = new List<int>();
        public List<int> api_raik = new List<int>();
        public List<int> api_bakk = new List<int>();
        public List<int> api_saku = new List<int>();
        public List<int> api_sakb = new List<int>();
        public List<int> api_luck = new List<int>();
	    public int api_sokuh {get; set;}
	    public int api_soku {get; set;}
	    public int api_leng {get; set;}
	    public List<int> api_grow = new List<int>();
        public int api_slot_num { get; set; }
        public List<int> api_maxeq = new List<int>();
        public List<int> api_defeq = new List<int>();
        public int api_buildtime { get; set; }
        public List<int> api_broken = new List<int>();
        public List<int> api_powup = new List<int>();
        public List<int> api_gumax = new List<int>();
	    public int api_backs {get; set;}
	    public string api_getmes {get; set;}
	    public string api_homemes {get; set;} //o
	    public string api_gomes {get; set;} //o
	    public string api_gomes2 {get; set;} //o
	    public string api_sinfo {get; set;}
	    public int api_afterfuel {get; set;}
	    public int api_afterbull {get; set;}
        public List<string> api_touchs = new List<string>(); //o[ ]
	    public string api_missions {get; set;} //o
	    public string api_systems {get; set;} //o
	    public int api_fuel_max {get; set;}
	    public int api_bull_max {get; set;}
	    public int api_voicef {get; set;}
    }

    public class Api_Mst_Shipgraph: KAPIBaseData
    {
	    public Api_Mst_Shipgraph(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_filename {get; set;}
        public string api_version {get; set;}
        public List<int> api_boko_n = new List<int>();
        public List<int> api_boko_d = new List<int>();
        public List<int> api_kaisyu_n = new List<int>();
        public List<int> api_kaisyu_d = new List<int>();
        public List<int> api_kaizo_n = new List<int>();
        public List<int> api_kaizo_d = new List<int>();
        public List<int> api_map_n = new List<int>();
        public List<int> api_map_d = new List<int>();
        public List<int> api_ensyuf_n = new List<int>();
        public List<int> api_ensyuf_d = new List<int>();
        public List<int> api_ensyue_n = new List<int>();
        public List<int> api_battle_n = new List<int>();
        public List<int> api_battle_d = new List<int>();
        public List<int> api_weda = new List<int>();
        public List<int> api_wedb = new List<int>();
    }

    public class Api_Equip_Type: KAPIBaseData
    {
	    public Api_Equip_Type(){}

	    public int _1 {get; set;}
	    public int _2 {get; set;}
	    public int _3 {get; set;}
	    public int _4 {get; set;}
	    public int _5 {get; set;}
	    public int _6 {get; set;}
	    public int _7 {get; set;}
	    public int _8 {get; set;}
	    public int _9 {get; set;}
	    public int _10 {get; set;}
	    public int _11 {get; set;}
	    public int _12 {get; set;}
	    public int _13 {get; set;}
	    public int _14 {get; set;}
	    public int _15 {get; set;}
	    public int _16 {get; set;}
	    public int _17 {get; set;}
	    public int _18 {get; set;}
	    public int _19 {get; set;}
	    public int _20 {get; set;}
	    public int _21 {get; set;}
	    public int _22 {get; set;}
	    public int _23 {get; set;}
	    public int _24 {get; set;}
	    public int _25 {get; set;}
	    public int _26 {get; set;}
	    public int _27 {get; set;}
	    public int _28 {get; set;}
	    public int _29 {get; set;}
	    public int _30 {get; set;}
	    public int _31 {get; set;}
    }

    public class Api_Mst_Stype: KAPIBaseData
    {
	    public Api_Mst_Stype(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_name {get; set;}
	    public int api_scnt {get; set;}
	    public int api_kcnt {get; set;}
        public Api_Equip_Type api_equip_type = new Api_Equip_Type();
    }

    public class Api_Mst_Slotitem: KAPIBaseData
    {
	    public Api_Mst_Slotitem(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
        public string api_name { get; set; }
        public List<int> api_type = new List<int>();
	    public int api_taik {get; set;}
	    public int api_souk {get; set;}
	    public int api_houg {get; set;}
	    public int api_raig {get; set;}
	    public int api_soku {get; set;}
	    public int api_baku {get; set;}
	    public int api_tyku {get; set;}
	    public int api_tais {get; set;}
	    public int api_atap {get; set;}
	    public int api_houm {get; set;}
	    public int api_raim {get; set;}
	    public int api_houk {get; set;}
	    public int api_raik {get; set;}
	    public int api_bakk {get; set;}
	    public int api_saku {get; set;}
	    public int api_sakb {get; set;}
	    public int api_luck {get; set;}
	    public int api_leng {get; set;}
	    public int api_rare {get; set;}
	    public List<int> api_broken = new List<int>();
	    public string api_info {get; set;}
	    public string api_usebull {get; set;}
    }

    public class Api_Mst_Slotitemgraph: KAPIBaseData
    {
	    public Api_Mst_Slotitemgraph(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
	    public string api_filename {get; set;}
	    public string api_version {get; set;}
    }

    public class Api_Mst_Furniture: KAPIBaseData
    {
	    public Api_Mst_Furniture(){}

	    public int api_id {get; set;}
	    public int api_type {get; set;}
	    public int api_no {get; set;}
	    public string api_title {get; set;}
	    public string api_description {get; set;}
	    public int api_rarity {get; set;}
	    public int api_price {get; set;}
	    public int api_saleflg {get; set;}
    }

    public class Api_Mst_Furnituregraph: KAPIBaseData
    {
	    public Api_Mst_Furnituregraph(){}

	    public int api_id {get; set;}
	    public int api_type {get; set;}
	    public int api_no {get; set;}
	    public string api_filename {get; set;}
	    public string api_version {get; set;}
    }

    public class Api_Mst_Useitem: KAPIBaseData
    {
	    public Api_Mst_Useitem(){}

	    public int api_id {get; set;}
	    public int api_usetype {get; set;}
	    public int api_category {get; set;}
	    public string api_name {get; set;}
        public List<string> api_description = new List<string>();
	    public int api_price {get; set;}
    }

    public class Api_Mst_Payitem: KAPIBaseData
    {
	    public Api_Mst_Payitem(){}

	    public int api_id {get; set;}
	    public int api_type {get; set;}
	    public string api_name {get; set;}
	    public string api_description {get; set;}
	    public List<int> api_item = new List<int>();
	    public int api_price {get; set;}
    }

    public class Api_Mst_Maparea: KAPIBaseData
    {
	    public Api_Mst_Maparea(){}

	    public int api_id {get; set;}
	    public string api_name {get; set;}
	    public int api_type {get; set;}
    }

    //"api_mst_item_shop":{"api_cabinet_1":[1,2,3,4,15,5,7,6,11,14,10,13],"api_cabinet_2":[16,17,20,19,8,9,18,-1,-1,-1]},"api_mst_maparea":[{"api_id":1,"api_name":"\u93ae\u5b88\u5e9c\u6d77\u57df","api_type":0},{"api_id":2,"api_name":"\u5357\u897f\u8af8\u5cf6\u6d77\u57df","api_type":0},{"api_id":3,"api_name":"\u5317\u65b9\u6d77\u57df","api_type":0},{"api_id":4,"api_name":"\u897f\u65b9\u6d77\u57df","api_type":0},{"api_id":5,"api_name":"\u5357\u65b9\u6d77\u57df","api_type":0},{"api_id":27,"api_name":"AL \/ MI\u4f5c\u6226","api_type":1}],

    public class Api_Mst_Mapinfo: KAPIBaseData
    {
	    public Api_Mst_Mapinfo(){}

	    public int api_id {get; set;}
	    public int api_maparea_id {get; set;}
	    public int api_no {get; set;}
	    public string api_name {get; set;}
	    public int api_level {get; set;}
	    public string api_opetext {get; set;}
        public string api_infotext { get; set; }
        public List<int> api_item = new List<int>();
	    public int api_max_maphp {get; set;}
	    public int api_required_defeat_count {get; set;}
	    // "api_sally_flag":[1,0]
    }

    public class Api_Mst_Mapbgm: KAPIBaseData
    {
	    public Api_Mst_Mapbgm(){}

	    public int api_id {get; set;}
	    public int api_maparea_id {get; set;}
        public int api_no { get; set; }
        public List<int> api_map_bgm = new List<int>();
        public List<int> api_boss_bgm = new List<int>();
    }

    public class Api_Mst_Mapcell: KAPIBaseData
    {
	    public Api_Mst_Mapcell(){}

	    public int api_map_no {get; set;}
	    public int api_maparea_id {get; set;}
	    public int api_mapinfo_no {get; set;}
	    public int api_id {get; set;}
	    public int api_no {get; set;}
	    public int api_color_no {get; set;}
    }

    public class Api_Mst_Mission: KAPIBaseData
    {
	    public Api_Mst_Mission(){}

	    public int api_id {get; set;}
	    public int api_maparea_id {get; set;}
	    public string api_name {get; set;}
	    public string api_details {get; set;}
	    public int api_time {get; set;}
	    public int api_difficulty {get; set;}
	    public float api_use_fuel {get; set;}
        public float api_use_bull {get; set;}
        public List<int> api_win_item1 = new List<int>();
        public List<int> api_win_item2 = new List<int>();
	    // "api_return_flag":1
    }

    public class Api_Mst_Shipupgrade: KAPIBaseData
    {
	    public Api_Mst_Shipupgrade(){}

	    public int api_id {get; set;}
	    public int api_original_ship_id {get; set;}
	    public int api_upgrade_type {get; set;}
	    public int api_upgrade_level {get; set;}
	    public int api_drawing_count {get; set;}
	    public int api_sortno {get; set;}
    }
    /**
     * @brief The kcsapi_start2 class
     */
    public class kcsapi_start2: KAPIBaseData
    {
	    public kcsapi_start2(){}

	    public List<kcsapi_mst_ship> api_mst_ship = new List<kcsapi_mst_ship>();
        public List<kcsapi_mst_slotitem> api_mst_slotitem = new List<kcsapi_mst_slotitem>();
        public List<kcsapi_mst_useitem> api_mst_useitem = new List<kcsapi_mst_useitem>();
        public List<kcsapi_mst_stype> api_mst_stype = new List<kcsapi_mst_stype>();
	    public List<kcsapi_mst_slotitem_equiptype> api_mst_slotitem_equiptype = new List<kcsapi_mst_slotitem_equiptype>();

	    // Keep

	    public List<Api_Mst_Shipgraph> api_mst_shipgraph = new List<Api_Mst_Shipgraph>();
	    public List<Api_Mst_Slotitemgraph> api_mst_slotitemgraph = new List<Api_Mst_Slotitemgraph>();
	    public List<Api_Mst_Furniture> api_mst_furniture = new List<Api_Mst_Furniture>();
	    public List<Api_Mst_Furnituregraph> api_mst_furnituregraph = new List<Api_Mst_Furnituregraph>();
	    public List<Api_Mst_Payitem> api_mst_payitem = new List<Api_Mst_Payitem>();
	    public Api_Mst_Item_Shop api_mst_item_shop = new Api_Mst_Item_Shop();
	    public List<Api_Mst_Maparea> api_mst_maparea = new List<Api_Mst_Maparea>();
	    public List<Api_Mst_Mapinfo> api_mst_mapinfo = new List<Api_Mst_Mapinfo>();
	    public List<Api_Mst_Mapbgm> api_mst_mapbgm = new List<Api_Mst_Mapbgm>();
	    public List<Api_Mst_Mapcell> api_mst_mapcell = new List<Api_Mst_Mapcell>();
	    public List<Api_Mst_Mission> api_mst_mission = new List<Api_Mst_Mission>();
	    public List<Api_Mst_Const> api_mst_const = new List<Api_Mst_Const>();
        public List<Api_Mst_Shipupgrade> api_mst_shipupgrade = new List<Api_Mst_Shipupgrade>();
    }

    /**
     * @brief The kcsapi_port class
     */
    public class kcsapi_port: KAPIBaseData
    {
	    public kcsapi_port(){}

        public List<kcsapi_material> api_material = new List<kcsapi_material>() 
        { 
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
            new kcsapi_material(),
        };
	    public List<kcsapi_deck> api_deck_port = new List<kcsapi_deck>();
	    public List<kcsapi_ndock> api_ndock = new List<kcsapi_ndock>();
	    public List<kcsapi_ship2> api_ship = new List<kcsapi_ship2>();
        public kcsapi_basic api_basic = new kcsapi_basic();
	    //public Api_Log[ ] api_log = new
    }

    /**
     * @brief The kcsapi_useitem class
     */
    public class kcsapi_useitem: KAPIBaseData
    {
	    public kcsapi_useitem(){}

	    public int api_member_id {get; set;}
	    public int api_id {get; set;}
	    public int api_value {get; set;}
	    public int api_usetype {get; set;}
	    public int api_category {get; set;}
	    public string api_name {get; set;}
	    public List<string> api_description = new List<string>();
	    public int api_price {get; set;}
	    public int api_count {get; set;}
    }

    public class kcsapi_next_enemy : KAPIBaseData
    {
	    public kcsapi_next_enemy(){}

	    public int api_enemy_id {get; set;}
	    public int api_result {get; set;}
	    public string api_result_str {get; set;}
    }

    /**
     * @brief The kcsapi_next class
     */
    public class kcsapi_next: KAPIBaseData
    {
	    public kcsapi_next(){}

	    public int api_rashin_flg {get; set;}
	    public int api_rashin_id {get; set;}
	    public int api_maparea_id {get; set;}
	    public int api_mapinfo_no {get; set;}
	    public int api_no {get; set;}
	    public int api_color_no {get; set;}
	    public int api_event_id {get; set;}
	    public int api_event_kind {get; set;}
	    public int api_next {get; set;}
	    public int api_bosscell_no {get; set;}
	    public int api_bosscomp {get; set;}
    //    int api_comment_kind {get; set;}
    //    int api_production_kind {get; set;}
	    public kcsapi_next_enemy api_enemy = new kcsapi_next_enemy();
    }

    /**
    * @brief The kcsapi_mission_start class
    */
    public class kcsapi_mission_start : KAPIBaseData
    {
	    public kcsapi_mission_start(){}

	    public Int64 api_complatetime = new Int64();
	    public string api_complatetime_str {get; set;}

    }

    /**
    * @brief The kcsapi_hensei_lock class
    */
    public class kcsapi_hensei_lock : KAPIBaseData
    {
	    public kcsapi_hensei_lock(){}

	    public int api_locked {get; set;}
    }

    /**
    * @brief The kcsapi_kaisou_lock class
    */
    public class kcsapi_kaisou_lock : KAPIBaseData
    {
	    public kcsapi_kaisou_lock(){}

	    public int api_locked {get; set;}
    }
    /**
    * @brief The kcsapi_remodel_slot class
    */
    public class kcsapi_remodel_slot : KAPIBaseData
    {
	    public kcsapi_remodel_slot(){}

        public int api_remodel_flag { get; set; }
        public List<int> api_remodel_id = new List<int>();
        public List<int> api_after_material = new List<int>();
	    public int api_voice_id {get; set;}
	    public kcsapi_slotitem api_after_slot = new kcsapi_slotitem();
    }

}