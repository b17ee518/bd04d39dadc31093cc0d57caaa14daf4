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
        private List<int> _api_frai_flag = new List<int>(); public List<int> api_frai_flag { get { return _api_frai_flag; } set { _api_frai_flag = value; } }
        private List<int> _api_erai_flag = new List<int>(); public List<int> api_erai_flag { get { return _api_erai_flag; } set { _api_erai_flag = value; } }
        private List<int> _api_fbak_flag = new List<int>(); public List<int> api_fbak_flag { get { return _api_fbak_flag; } set { _api_fbak_flag = value; } }
        private List<int> _api_ebak_flag = new List<int>(); public List<int> api_ebak_flag { get { return _api_ebak_flag; } set { _api_ebak_flag = value; } }
        private List<int> _api_fcl_flag = new List<int>(); public List<int> api_fcl_flag { get { return _api_fcl_flag; } set { _api_fcl_flag = value; } }
        private List<int> _api_ecl_flag = new List<int>(); public List<int> api_ecl_flag { get { return _api_ecl_flag; } set { _api_ecl_flag = value; } }
        private List<Double> _api_fdam = new List<Double>(); public List<Double> api_fdam { get { return _api_fdam; } set { _api_fdam = value; } }
        private List<Double> _api_edam = new List<Double>(); public List<Double> api_edam { get { return _api_edam; } set { _api_edam = value; } }
    }

    public class kcsapi_battle_kouku : KAPIBaseData
    {

	    public kcsapi_battle_kouku(){}

        private List<List<int>> _api_plane_from = new List<List<int>>() { new List<int>()}; public List<List<int>> api_plane_from { get { return _api_plane_from; } set { _api_plane_from = value; } } //? f, e list
        private kcsapi_battle_kouku_stage1 _api_stage1 = new kcsapi_battle_kouku_stage1(); public kcsapi_battle_kouku_stage1 api_stage1 { get { return _api_stage1; } set { _api_stage1 = value; } }
        private kcsapi_battle_kouku_stage2 _api_stage2 = new kcsapi_battle_kouku_stage2(); public kcsapi_battle_kouku_stage2 api_stage2 { get { return _api_stage2; } set { _api_stage2 = value; } }
        private kcsapi_battle_kouku_stage3 _api_stage3 = new kcsapi_battle_kouku_stage3(); public kcsapi_battle_kouku_stage3 api_stage3 { get { return _api_stage3; } set { _api_stage3 = value; } }
	    // combined
        private kcsapi_battle_kouku_stage3 _api_stage3_combined = new kcsapi_battle_kouku_stage3(); public kcsapi_battle_kouku_stage3 api_stage3_combined { get { return _api_stage3_combined; } set { _api_stage3_combined = value; } }
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

        private List<int> _api_erai_flag = new List<int>(); public List<int> api_erai_flag { get { return _api_erai_flag; } set { _api_erai_flag = value; } }
        private List<int> _api_ebak_flag = new List<int>(); public List<int> api_ebak_flag { get { return _api_ebak_flag; } set { _api_ebak_flag = value; } }
        private List<int> _api_ecl_flag = new List<int>(); public List<int> api_ecl_flag { get { return _api_ecl_flag; } set { _api_ecl_flag = value; } }
        private List<Double> _api_edam = new List<Double>(); public List<Double> api_edam { get { return _api_edam; } set { _api_edam = value; } }
    }

    public class kcsapi_battle_support_airatack : KAPIBaseData
    {

	    public kcsapi_battle_support_airatack(){}
	    
	    public int api_deck_id {get; set;}
        private List<int> _api_ship_id = new List<int>(); public List<int> api_ship_id { get { return _api_ship_id; } set { _api_ship_id = value; } }
        private List<int> _api_undressing_flag = new List<int>(); public List<int> api_undressing_flag { get { return _api_undressing_flag; } set { _api_undressing_flag = value; } } //??
        private List<int> _api_stage_flag = new List<int>(); public List<int> api_stage_flag { get { return _api_stage_flag; } set { _api_stage_flag = value; } }
        private List<List<int>> _api_plane_from = new List<List<int>>(){new List<int>()}; public List<List<int>> api_plane_from { get { return _api_plane_from; } set { _api_plane_from = value; } }
        private kcsapi_battle_support_airatack_stage1 _api_stage1 = new kcsapi_battle_support_airatack_stage1(); public kcsapi_battle_support_airatack_stage1 api_stage1 { get { return _api_stage1; } set { _api_stage1 = value; } }
        private kcsapi_battle_support_airatack_stage2 _api_stage2 = new kcsapi_battle_support_airatack_stage2(); public kcsapi_battle_support_airatack_stage2 api_stage2 { get { return _api_stage2; } set { _api_stage2 = value; } }
        private kcsapi_battle_support_airatack_stage3 _api_stage3 = new kcsapi_battle_support_airatack_stage3(); public kcsapi_battle_support_airatack_stage3 api_stage3 { get { return _api_stage3; } set { _api_stage3 = value; } }
    }

    public class kcsapi_battle_support_hourai : KAPIBaseData
    {

	    public kcsapi_battle_support_hourai(){}
	    
	    public int api_deck_id {get; set;}
        private List<int> _api_ship_id = new List<int>(); public List<int> api_ship_id { get { return _api_ship_id; } set { _api_ship_id = value; } }
        private List<int> _api_undressing_flag = new List<int>(); public List<int> api_undressing_flag { get { return _api_undressing_flag; } set { _api_undressing_flag = value; } }
        private List<int> _api_cl_list = new List<int>(); public List<int> api_cl_list { get { return _api_cl_list; } set { _api_cl_list = value; } }
        private List<Double> _api_damage = new List<Double>(); public List<Double> api_damage { get { return _api_damage; } set { _api_damage = value; } }
    }

    public class kcsapi_battle_support_info : KAPIBaseData
    {

	    public kcsapi_battle_support_info(){}
	    
	    //TODO: support info
        private kcsapi_battle_support_airatack _api_support_airatack = new kcsapi_battle_support_airatack(); public kcsapi_battle_support_airatack api_support_airatack { get { return _api_support_airatack; } set { _api_support_airatack = value; } }
        private kcsapi_battle_support_hourai _api_support_hourai = new kcsapi_battle_support_hourai(); public kcsapi_battle_support_hourai api_support_hourai { get { return _api_support_hourai; } set { _api_support_hourai = value; } }
    }

    public class kcsapi_battle_opening_atack : KAPIBaseData
    {

	    public kcsapi_battle_opening_atack(){}
	    
	    // from #1
        private List<int> _api_frai = new List<int>(); public List<int> api_frai { get { return _api_frai; } set { _api_frai = value; } }
        private List<int> _api_erai = new List<int>(); public List<int> api_erai { get { return _api_erai; } set { _api_erai = value; } }
        private List<Double> _api_fdam = new List<Double>(); public List<Double> api_fdam { get { return _api_fdam; } set { _api_fdam = value; } }
        private List<Double> _api_edam = new List<Double>(); public List<Double> api_edam { get { return _api_edam; } set { _api_edam = value; } }
        private List<Double> _api_fydam = new List<Double>(); public List<Double> api_fydam { get { return _api_fydam; } set { _api_fydam = value; } }
        private List<Double> _api_eydam = new List<Double>(); public List<Double> api_eydam { get { return _api_eydam; } set { _api_eydam = value; } }
        private List<int> _api_fcl = new List<int>(); public List<int> api_fcl { get { return _api_fcl; } set { _api_fcl = value; } }
        private List<int> _api_ecl = new List<int>(); public List<int> api_ecl { get { return _api_ecl; } set { _api_ecl = value; } }
    }

    public class kcsapi_battle_hougeki : KAPIBaseData
    {
	    public kcsapi_battle_hougeki(){}

        private List<int> _api_at_list = new List<int>(); public List<int> api_at_list { get { return _api_at_list; } set { _api_at_list = value; } }
        private List<int> _api_at_type = new List<int>(); public List<int> api_at_type { get { return _api_at_type; } set { _api_at_type = value; } }
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
        private List<List<int>> _api_df_list = new List<List<int>>() { new List<int>()}; public List<List<int>> api_df_list { get { return _api_df_list; } set { _api_df_list = value; } }
        private List<List<int>> _api_si_list = new List<List<int>>() { new List<int>()}; public List<List<int>> api_si_list { get { return _api_si_list; } set { _api_si_list = value; } }
        private List<List<int>> _api_cl_list = new List<List<int>>() { new List<int>() }; public List<List<int>> api_cl_list { get { return _api_cl_list; } set { _api_cl_list = value; } }

	    // midnight
        private List<int> _api_sp_list = new List<int>(); public List<int> api_sp_list { get { return _api_sp_list; } set { _api_sp_list = value; } }
	    /*
	    public 0　通常
	    public 1　連続
	    public 2　主砲雷撃
	    public 3　雷撃雷撃
	    public 4　主砲主砲副砲
	    public 5　主砲主砲主砲
	    public */
        private List<List<Double>> _api_damage = new List<List<Double>>() { new List<Double>()}; public List<List<Double>> api_damage { get { return _api_damage; } set { _api_damage = value; } }
    }

    public class kcsapi_battle_raigeki : KAPIBaseData
    {

	    public kcsapi_battle_raigeki(){}

        // from #1
        private List<int> _api_frai = new List<int>(); public List<int> api_frai { get { return _api_frai; } set { _api_frai = value; } }
        private List<int> _api_erai = new List<int>(); public List<int> api_erai { get { return _api_erai; } set { _api_erai = value; } }
        private List<Double> _api_fdam = new List<Double>(); public List<Double> api_fdam { get { return _api_fdam; } set { _api_fdam = value; } }
        private List<Double> _api_edam = new List<Double>(); public List<Double> api_edam { get { return _api_edam; } set { _api_edam = value; } }
        private List<Double> _api_fydam = new List<Double>(); public List<Double> api_fydam { get { return _api_fydam; } set { _api_fydam = value; } }
        private List<Double> _api_eydam = new List<Double>(); public List<Double> api_eydam { get { return _api_eydam; } set { _api_eydam = value; } }
        private List<int> _api_fcl = new List<int>(); public List<int> api_fcl { get { return _api_fcl; } set { _api_fcl = value; } }
        private List<int> _api_ecl = new List<int>(); public List<int> api_ecl { get { return _api_ecl; } set { _api_ecl = value; } }
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

        private List<int> _api_ship_ke = new List<int>(); public List<int> api_ship_ke { get { return _api_ship_ke; } set { _api_ship_ke = value; } } //enemy ship list from #1
        private List<int> _api_ship_lv = new List<int>(); public List<int> api_ship_lv { get { return _api_ship_lv; } set { _api_ship_lv = value; } } //enemy ship lv from #1
        private List<int> _api_nowhps = new List<int>(); public List<int> api_nowhps { get { return _api_nowhps; } set { _api_nowhps = value; } } // both hps from #1 (13)
        private List<int> _api_maxhps = new List<int>(); public List<int> api_maxhps { get { return _api_maxhps; } set { _api_maxhps = value; } }

	    // combined
        private List<int> _api_nowhps_combined = new List<int>(); public List<int> api_nowhps_combined { get { return _api_nowhps_combined; } set { _api_nowhps_combined = value; } }
        private List<int> _api_maxhps_combined = new List<int>(); public List<int> api_maxhps_combined { get { return _api_maxhps_combined; } set { _api_maxhps_combined = value; } }

        public int api_midnight_flag { get; set; }
        private List<List<int>> _api_eSlot = new List<List<int>>() { new List<int>() }; public List<List<int>> api_eSlot { get { return _api_eSlot; } set { _api_eSlot = value; } } // from #0
        private List<List<int>> _api_eKyoka = new List<List<int>>() { new List<int>() }; public List<List<int>> api_eKyoka { get { return _api_eKyoka; } set { _api_eKyoka = value; } } // from #0
        private List<List<int>> _api_fParam = new List<List<int>>() { new List<int>() }; public List<List<int>> api_fParam { get { return _api_fParam; } set { _api_fParam = value; } } // from #0
        // combined
        private List<List<int>> _api_fParam_combined = new List<List<int>>() { new List<int>() }; public List<List<int>> api_fParam_combined { get { return _api_fParam_combined; } set { _api_fParam_combined = value; } } // from #0
        private List<List<int>> _api_eParam = new List<List<int>>() { new List<int>() }; public List<List<int>> api_eParam { get { return _api_eParam; } set { _api_eParam = value; } } // from #0
        private List<int> _api_search = new List<int>(); public List<int> api_search { get { return _api_search; } set { _api_search = value; } } //?
        private List<int> _api_formation = new List<int>(); public List<int> api_formation { get { return _api_formation; } set { _api_formation = value; } } // f, e, i { null, "単縦陣", "複縦陣", "輪形陣", "梯形陣", "単横陣" } { null, "同航戦", "反航戦", "Ｔ字戦(有利)", "Ｔ字戦(不利)" }
        private List<int> _api_stage_flag = new List<int>(); public List<int> api_stage_flag { get { return _api_stage_flag; } set { _api_stage_flag = value; } } // kouku stage1~3

	    // midnight
        private List<int> _api_touch_plane = new List<int>(); public List<int> api_touch_plane { get { return _api_touch_plane; } set { _api_touch_plane = value; } }
        private List<int> _api_flare_pos = new List<int>(); public List<int> api_flare_pos { get { return _api_flare_pos; } set { _api_flare_pos = value; } }

        private kcsapi_battle_kouku _api_kouku = new kcsapi_battle_kouku(); public kcsapi_battle_kouku api_kouku { get { return _api_kouku; } set { _api_kouku = value; } }
	    // combine
        private kcsapi_battle_kouku _api_kouku2 = new kcsapi_battle_kouku(); public kcsapi_battle_kouku api_kouku2 { get { return _api_kouku2; } set { _api_kouku2 = value; } }

	    public int api_support_flag {get; set;} //空爆1　砲撃2　雷撃3
        private kcsapi_battle_support_info _api_support_info = new kcsapi_battle_support_info(); public kcsapi_battle_support_info api_support_info { get { return _api_support_info; } set { _api_support_info = value; } }
	    public int api_opening_flag {get; set;}
        private kcsapi_battle_opening_atack _api_opening_atack = new kcsapi_battle_opening_atack(); public kcsapi_battle_opening_atack api_opening_atack { get { return _api_opening_atack; } set { _api_opening_atack = value; } }
        private List<int> _api_hourai_flag = new List<int>(); public List<int> api_hourai_flag { get { return _api_hourai_flag; } set { _api_hourai_flag = value; } } // hougeki1, hougeki2, hougeki3, raigeki
        private kcsapi_battle_hougeki _api_hougeki1 = new kcsapi_battle_hougeki(); public kcsapi_battle_hougeki api_hougeki1 { get { return _api_hougeki1; } set { _api_hougeki1 = value; } }
        private kcsapi_battle_hougeki _api_hougeki2 = new kcsapi_battle_hougeki(); public kcsapi_battle_hougeki api_hougeki2 { get { return _api_hougeki2; } set { _api_hougeki2 = value; } }
        private kcsapi_battle_hougeki _api_hougeki3 = new kcsapi_battle_hougeki(); public kcsapi_battle_hougeki api_hougeki3 { get { return _api_hougeki3; } set { _api_hougeki3 = value; } }
        private kcsapi_battle_raigeki _api_raigeki = new kcsapi_battle_raigeki(); public kcsapi_battle_raigeki api_raigeki { get { return _api_raigeki; } set { _api_raigeki = value; } }

	    // midnight
        private kcsapi_battle_hougeki _api_hougeki = new kcsapi_battle_hougeki(); public kcsapi_battle_hougeki api_hougeki { get { return _api_hougeki; } set { _api_hougeki = value; } } //midnight
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

        private List<int> _api_ship_id = new List<int>(); public List<int> api_ship_id { get { return _api_ship_id; } set { _api_ship_id = value; } }
	    public string api_win_rank {get; set;}
	    public int api_get_exp {get; set;}
	    public int api_mvp {get; set;}
	    // combined
	    public int api_mvp_combined {get; set;}

	    public int api_member_lv {get; set;}
	    public int api_member_exp {get; set;}
	    public int api_get_base_exp {get; set;}
        private List<int> _api_get_ship_exp = new List<int>(); public List<int> api_get_ship_exp { get { return _api_get_ship_exp; } set { _api_get_ship_exp = value; } }
        private List<List<int>> _api_get_exp_lvup = new List<List<int>>() { new List<int>()}; public List<List<int>> api_get_exp_lvup { get { return _api_get_exp_lvup; } set { _api_get_exp_lvup = value; } }
        // combined
        private List<int> _api_get_ship_exp_combined = new List<int>(); public List<int> api_get_ship_exp_combined { get { return _api_get_ship_exp_combined; } set { _api_get_ship_exp_combined = value; } }
        private List<List<int>> _api_get_exp_lvup_combined = new List<List<int>>() { new List<int>() }; public List<List<int>> api_get_exp_lvup_combined { get { return _api_get_exp_lvup_combined; } set { _api_get_exp_lvup_combined = value; } }

	    public int api_dests {get; set;}
	    public int api_destsf {get; set;}
        private List<int> _api_lost_flag = new List<int>(); public List<int> api_lost_flag { get { return _api_lost_flag; } set { _api_lost_flag = value; } }
	    public string api_quest_name {get; set;}
	    public int api_quest_level {get; set;}
        private kcsapi_battleresult_enemyinfo _api_enemy_info = new kcsapi_battleresult_enemyinfo(); public kcsapi_battleresult_enemyinfo api_enemy_info { get { return _api_enemy_info; } set { _api_enemy_info = value; } }
	    public int api_first_clear {get; set;}
        private List<int> _api_get_flag = new List<int>(); public List<int> api_get_flag { get { return _api_get_flag; } set { _api_get_flag = value; } }
        private kcsapi_battleresult_getship _api_get_ship = new kcsapi_battleresult_getship(); public kcsapi_battleresult_getship api_get_ship { get { return _api_get_ship; } set { _api_get_ship = value; } }
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

        private List<kcsapi_practice_enemyinfo_deck_ships> _api_ships = new List<kcsapi_practice_enemyinfo_deck_ships>(); public List<kcsapi_practice_enemyinfo_deck_ships> api_ships { get { return _api_ships; } set { _api_ships = value; } }
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
        private List<int> _api_experience = new List<int>(); public List<int> api_experience { get { return _api_experience; } set { _api_experience = value; } }
	    public int api_friend {get; set;}
        private List<int> _api_ship = new List<int>(); public List<int> api_ship { get { return _api_ship; } set { _api_ship = value; } }
        private List<int> _api_slotitem = new List<int>(); public List<int> api_slotitem { get { return _api_slotitem; } set { _api_slotitem = value; } }
	    public int api_furniture {get; set;}
	    public string api_deckname {get; set;}
	    public string api_deckname_id {get; set;}
        private kcsapi_practice_enemyinfo_deck _api_deck = new kcsapi_practice_enemyinfo_deck(); public kcsapi_practice_enemyinfo_deck api_deck { get { return _api_deck; } set { _api_deck = value; } }
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
        private List<int> _api_onslot = new List<int>(); public List<int> api_onslot { get { return _api_onslot; } set { _api_onslot = value; } }
    }

    /**
     * @brief The kcsapi_charge class
     */
    public class kcsapi_charge : KAPIBaseData
    {
	    public kcsapi_charge(){}

        private List<kcsapi_charge_ship> _api_ship = new List<kcsapi_charge_ship>(); public List<kcsapi_charge_ship> api_ship { get { return _api_ship; } set { _api_ship = value; } }
        private List<int> _api_material = new List<int>(); public List<int> api_material { get { return _api_material; } set { _api_material = value; } }
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
        private kcsapi_slotitem _api_slot_item = new kcsapi_slotitem(); public kcsapi_slotitem api_slot_item { get { return _api_slot_item; } set { _api_slot_item = value; } }
        private List<int> _api_material = new List<int>(); public List<int> api_material { get { return _api_material; } set { _api_material = value; } }
	    public int api_type3 {get; set;}
        private List<int> _api_unsetslot = new List<int>(); public List<int> api_unsetslot { get { return _api_unsetslot; } set { _api_unsetslot = value; } }
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
        private List<Int64> _api_mission = new List<Int64>(); public List<Int64> api_mission { get { return _api_mission; } set { _api_mission = value; } }
	    public string api_flagship {get; set;}
        private List<int> _api_ship = new List<int>(); public List<int> api_ship { get { return _api_ship; } set { _api_ship = value; } }
    }

    /**
     * @brief The kcsapi_destroyitem2 class
     */
    public class kcsapi_destroyitem2 : KAPIBaseData
    {
	    public kcsapi_destroyitem2(){}

        private List<int> _api_get_material = new List<int>(); public List<int> api_get_material { get { return _api_get_material; } set { _api_get_material = value; } }
    }

    /**
     * @brief The kcsapi_destroyship class
     */
    public class kcsapi_destroyship : KAPIBaseData
    {
	    public kcsapi_destroyship(){}

        private List<int> _api_material = new List<int>(); public List<int> api_material { get { return _api_material; } set { _api_material = value; } }
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
        private Int64 _api_complete_time = new Int64(); public Int64 api_complete_time { get { return _api_complete_time; } set { _api_complete_time = value; } }
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
        private List<int> _api_taik = new List<int>(); public List<int> api_taik { get { return _api_taik; } set { _api_taik = value; } }
        private List<int> _api_souk = new List<int>(); public List<int> api_souk { get { return _api_souk; } set { _api_souk = value; } }
        private List<int> _api_houg = new List<int>(); public List<int> api_houg { get { return _api_houg; } set { _api_houg = value; } }
        private List<int> _api_raig = new List<int>(); public List<int> api_raig { get { return _api_raig; } set { _api_raig = value; } }
        private List<int> _api_baku = new List<int>(); public List<int> api_baku { get { return _api_baku; } set { _api_baku = value; } }
        private List<int> _api_tyku = new List<int>(); public List<int> api_tyku { get { return _api_tyku; } set { _api_tyku = value; } }
        private List<int> _api_houm = new List<int>(); public List<int> api_houm { get { return _api_houm; } set { _api_houm = value; } }
        private List<int> _api_raim = new List<int>(); public List<int> api_raim { get { return _api_raim; } set { _api_raim = value; } }
        private List<int> _api_saku = new List<int>(); public List<int> api_saku { get { return _api_saku; } set { _api_saku = value; } }
        private List<int> _api_luck = new List<int>(); public List<int> api_luck { get { return _api_luck; } set { _api_luck = value; } }
	    public int api_soku {get; set;}
	    public int api_leng {get; set;}
        private List<int> _api_slot = new List<int>(); public List<int> api_slot { get { return _api_slot; } set { _api_slot = value; } }
        private List<int> _api_onslot = new List<int>(); public List<int> api_onslot { get { return _api_onslot; } set { _api_onslot = value; } }
        private List<int> _api_broken = new List<int>(); public List<int> api_broken { get { return _api_broken; } set { _api_broken = value; } }
        private List<int> _api_powup = new List<int>(); public List<int> api_powup { get { return _api_powup; } set { _api_powup = value; } }
        private List<int> _api_kyouka = new List<int>(); public List<int> api_kyouka { get { return _api_kyouka; } set { _api_kyouka = value; } }
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
        private List<int> _api_ndock_item = new List<int>(); public List<int> api_ndock_item { get { return _api_ndock_item; } set { _api_ndock_item = value; } }
	    public int api_star {get; set;}
	    public int api_srate {get; set;}
	    public int api_cond {get; set;}
        private List<int> _api_karyoku = new List<int>(); public List<int> api_karyoku { get { return _api_karyoku; } set { _api_karyoku = value; } }
        private List<int> _api_raisou = new List<int>(); public List<int> api_raisou { get { return _api_raisou; } set { _api_raisou = value; } }
        private List<int> _api_taiku = new List<int>(); public List<int> api_taiku { get { return _api_taiku; } set { _api_taiku = value; } }
        private List<int> _api_soukou = new List<int>(); public List<int> api_soukou { get { return _api_soukou; } set { _api_soukou = value; } }
        private List<int> _api_kaihi = new List<int>(); public List<int> api_kaihi { get { return _api_kaihi; } set { _api_kaihi = value; } }
        private List<int> _api_taisen = new List<int>(); public List<int> api_taisen { get { return _api_taisen; } set { _api_taisen = value; } }
        private List<int> _api_sakuteki = new List<int>(); public List<int> api_sakuteki { get { return _api_sakuteki; } set { _api_sakuteki = value; } }
        private List<int> _api_lucky = new List<int>(); public List<int> api_lucky { get { return _api_lucky; } set { _api_lucky = value; } }
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
        public string api_aftershipid { get; set; }
        private List<int> _api_taik = new List<int>(); public List<int> api_taik { get { return _api_taik; } set { _api_taik = value; } }
        private List<int> _api_souk = new List<int>(); public List<int> api_souk { get { return _api_souk; } set { _api_souk = value; } }
        private List<int> _api_tous = new List<int>(); public List<int> api_tous { get { return _api_tous; } set { _api_tous = value; } }   // diff
        private List<int> _api_houg = new List<int>(); public List<int> api_houg { get { return _api_houg; } set { _api_houg = value; } }
        private List<int> _api_raig = new List<int>(); public List<int> api_raig { get { return _api_raig; } set { _api_raig = value; } }
        private List<int> _api_baku = new List<int>(); public List<int> api_baku { get { return _api_baku; } set { _api_baku = value; } }
        private List<int> _api_tyku = new List<int>(); public List<int> api_tyku { get { return _api_tyku; } set { _api_tyku = value; } }
        private List<int> _api_atap = new List<int>(); public List<int> api_atap { get { return _api_atap; } set { _api_atap = value; } }   // diff
        private List<int> _api_tais = new List<int>(); public List<int> api_tais { get { return _api_tais; } set { _api_tais = value; } }   // diff
        private List<int> _api_houm = new List<int>(); public List<int> api_houm { get { return _api_houm; } set { _api_houm = value; } }
        private List<int> _api_raim = new List<int>(); public List<int> api_raim { get { return _api_raim; } set { _api_raim = value; } }
        private List<int> _api_kaih = new List<int>(); public List<int> api_kaih { get { return _api_kaih; } set { _api_kaih = value; } }   // diff
        private List<int> _api_houk = new List<int>(); public List<int> api_houk { get { return _api_houk; } set { _api_houk = value; } } // diff
        private List<int> _api_raik = new List<int>(); public List<int> api_raik { get { return _api_raik; } set { _api_raik = value; } } // diff
        private List<int> _api_bakk = new List<int>(); public List<int> api_bakk { get { return _api_bakk; } set { _api_bakk = value; } } // diff
        private List<int> _api_saku = new List<int>(); public List<int> api_saku { get { return _api_saku; } set { _api_saku = value; } }
        private List<int> _api_sakb = new List<int>(); public List<int> api_sakb { get { return _api_sakb; } set { _api_sakb = value; } } // diff
        private List<int> _api_luck = new List<int>(); public List<int> api_luck { get { return _api_luck; } set { _api_luck = value; } }
	    public int api_sokuh {get; set;}
	    public int api_soku {get; set;}
        public int api_leng { get; set; }
        private List<int> _api_grow = new List<int>(); public List<int> api_grow { get { return _api_grow; } set { _api_grow = value; } }
        public int api_slot_num {get; set;}
        private List<int> _api_maxeq = new List<int>(); public List<int> api_maxeq { get { return _api_maxeq; } set { _api_maxeq = value; } }
        private List<int> _api_defeq = new List<int>(); public List<int> api_defeq { get { return _api_defeq; } set { _api_defeq = value; } }
        public int api_buildtime {get; set;}
        private List<int> _api_broken = new List<int>(); public List<int> api_broken { get { return _api_broken; } set { _api_broken = value; } }
        private List<int> _api_powup = new List<int>(); public List<int> api_powup { get { return _api_powup; } set { _api_powup = value; } }
        private List<int> _api_gumax = new List<int>(); public List<int> api_gumax { get { return _api_gumax; } set { _api_gumax = value; } }
	    public int api_backs {get; set;}
	    public string api_getmes {get; set;}
	    public string api_homemes {get; set;}  //o
	    public string api_gomes {get; set;}    //o
	    public string api_gomes2 {get; set;}   //o
	    public string api_sinfo {get; set;}
	    public int api_afterfuel {get; set;}
        public int api_afterbull { get; set; }
        private List<string> _api_touchs = new List<string>(); public List<string> api_touchs { get { return _api_touchs; } set { _api_touchs = value; } }
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
        private List<int> _api_exp = new List<int>(); public List<int> api_exp { get { return _api_exp; } set { _api_exp = value; } }
	    public int api_nowhp {get; set;}
	    public int api_maxhp {get; set;}
	    public int api_leng {get; set;}	// short .. super long
        private List<int> _api_slot = new List<int>(); public List<int> api_slot { get { return _api_slot; } set { _api_slot = value; } }
        private List<int> _api_onslot = new List<int>(); public List<int> api_onslot { get { return _api_onslot; } set { _api_onslot = value; } }
        private List<int> _api_kyouka = new List<int>(); public List<int> api_kyouka { get { return _api_kyouka; } set { _api_kyouka = value; } }
	    public int api_backs {get; set;}
	    public int api_fuel {get; set;}
	    public int api_bull {get; set;}
	    public int api_slotnum {get; set;}
        private Int64 _api_ndock_time = new Int64(); public Int64 api_ndock_time { get { return _api_ndock_time; } set { _api_ndock_time = value; } }
        private List<int> _api_ndock_item = new List<int>(); public List<int> api_ndock_item { get { return _api_ndock_item; } set { _api_ndock_item = value; } } // fuel bull.ndock
	    public int api_srate {get; set;}	// normal .. ss
        public int api_cond {get; set;}
        private List<int> _api_karyoku = new List<int>(); public List<int> api_karyoku { get { return _api_karyoku; } set { _api_karyoku = value; } }
        private List<int> _api_raisou = new List<int>(); public List<int> api_raisou { get { return _api_raisou; } set { _api_raisou = value; } }
        private List<int> _api_taiku = new List<int>(); public List<int> api_taiku { get { return _api_taiku; } set { _api_taiku = value; } }
        private List<int> _api_soukou = new List<int>(); public List<int> api_soukou { get { return _api_soukou; } set { _api_soukou = value; } }
        private List<int> _api_kaihi = new List<int>(); public List<int> api_kaihi { get { return _api_kaihi; } set { _api_kaihi = value; } }
        private List<int> _api_taisen = new List<int>(); public List<int> api_taisen { get { return _api_taisen; } set { _api_taisen = value; } }
        private List<int> _api_sakuteki = new List<int>(); public List<int> api_sakuteki { get { return _api_sakuteki; } set { _api_sakuteki = value; } }
        private List<int> _api_lucky = new List<int>(); public List<int> api_lucky { get { return _api_lucky; } set { _api_lucky = value; } }
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
        private List<kcsapi_kdock> _api_kdock = new List<kcsapi_kdock>(); public List<kcsapi_kdock> api_kdock { get { return _api_kdock; } set { _api_kdock = value; } }
        private kcsapi_ship2 _api_ship = new kcsapi_ship2(); public kcsapi_ship2 api_ship { get { return _api_ship; } set { _api_ship = value; } }
        private List<kcsapi_slotitem> _api_slotitem = new List<kcsapi_slotitem>(); public List<kcsapi_slotitem> api_slotitem { get { return _api_slotitem; } set { _api_slotitem = value; } }
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
        private List<int> _api_type = new List<int>(); public List<int> api_type { get { return _api_type; } set { _api_type = value; } }
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
        private List<int> _api_broken = new List<int>(); public List<int> api_broken { get { return _api_broken; } set { _api_broken = value; } }
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
        private List<string> _api_description = new List<string>(); public List<string> api_description { get { return _api_description; } set { _api_description = value; } }
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
        private Int64 _api_complete_time = new Int64(); public Int64 api_complete_time { get { return _api_complete_time; } set { _api_complete_time = value; } }
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
        private kcsapi_ship2 _api_ship = new kcsapi_ship2(); public kcsapi_ship2 api_ship { get { return _api_ship; } set { _api_ship = value; } }
        private List<kcsapi_deck> _api_deck = new List<kcsapi_deck>(); public List<kcsapi_deck> api_deck { get { return _api_deck; } set { _api_deck = value; } }
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
        private kcsapi_clearitemget_bounus_item _api_item = new kcsapi_clearitemget_bounus_item(); public kcsapi_clearitemget_bounus_item api_item { get { return _api_item; } set { _api_item = value; } }
    }
    /************************************************************************/
    /*                                                                      */
    /************************************************************************/
    public class kcsapi_clearitemget : KAPIBaseData
    {
	    public kcsapi_clearitemget(){}

        private List<int> _api_material = new List<int>(); public List<int> api_material { get { return _api_material; } set { _api_material = value; } }
	    public int api_bounus_count {get; set;}
        private List<kcsapi_clearitemget_bounus> _api_bounus = new List<kcsapi_clearitemget_bounus>(); public List<kcsapi_clearitemget_bounus> api_bounus { get { return _api_bounus; } set { _api_bounus = value; } }
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
        private List<int> _api_get_material = new List<int>(); public List<int> api_get_material { get { return _api_get_material; } set { _api_get_material = value; } }
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
        private List<kcsapi_quest> _api_list = new List<kcsapi_quest>(); public List<kcsapi_quest> api_list { get { return _api_list; } set { _api_list = value; } }
	    public int api_exec_count {get; set;}
    }


    /**
     * @brief The kcsapi_ship3 class
     */
    public class kcsapi_ship3: KAPIBaseData
    {
	    public kcsapi_ship3(){}

        private List<kcsapi_ship2> _api_ship_data = new List<kcsapi_ship2>(); public List<kcsapi_ship2> api_ship_data { get { return _api_ship_data; } set { _api_ship_data = value; } }
        private List<kcsapi_deck> _api_deck_data = new List<kcsapi_deck>(); public List<kcsapi_deck> api_deck_data { get { return _api_deck_data; } set { _api_deck_data = value; } }

	    //
	    //public kcsapi_slot_data api_slot_data = new
    }

    /**
    * @brief The kcsapi_ship_deck class
    */
    public class kcsapi_ship_deck : KAPIBaseData
    {
	    public kcsapi_ship_deck(){}

        private List<kcsapi_ship2> _api_ship_data = new List<kcsapi_ship2>(); public List<kcsapi_ship2> api_ship_data { get { return _api_ship_data; } set { _api_ship_data = value; } }
        private List<kcsapi_deck> _api_deck_data = new List<kcsapi_deck>(); public List<kcsapi_deck> api_deck_data { get { return _api_deck_data; } set { _api_deck_data = value; } }
    }

    public class kcsapi_slot_data: KAPIBaseData
    {
	    public kcsapi_slot_data(){}

        private List<int> _api_slottype1 = new List<int>(); public List<int> api_slottype1 { get { return _api_slottype1; } set { _api_slottype1 = value; } }
        private List<int> _api_slottype2 = new List<int>(); public List<int> api_slottype2 { get { return _api_slottype2; } set { _api_slottype2 = value; } }
        private List<int> _api_slottype3 = new List<int>(); public List<int> api_slottype3 { get { return _api_slottype3; } set { _api_slottype3 = value; } }
        private List<int> _api_slottype4 = new List<int>(); public List<int> api_slottype4 { get { return _api_slottype4; } set { _api_slottype4 = value; } }
        private List<int> _api_slottype5 = new List<int>(); public List<int> api_slottype5 { get { return _api_slottype5; } set { _api_slottype5 = value; } }
        private List<int> _api_slottype6 = new List<int>(); public List<int> api_slottype6 { get { return _api_slottype6; } set { _api_slottype6 = value; } }
        private List<int> _api_slottype7 = new List<int>(); public List<int> api_slottype7 { get { return _api_slottype7; } set { _api_slottype7 = value; } }
        private List<int> _api_slottype8 = new List<int>(); public List<int> api_slottype8 { get { return _api_slottype8; } set { _api_slottype8 = value; } }
        private List<int> _api_slottype9 = new List<int>(); public List<int> api_slottype9 { get { return _api_slottype9; } set { _api_slottype9 = value; } }
        private List<int> _api_slottype10 = new List<int>(); public List<int> api_slottype10 { get { return _api_slottype10; } set { _api_slottype10 = value; } }
        private List<int> _api_slottype11 = new List<int>(); public List<int> api_slottype11 { get { return _api_slottype11; } set { _api_slottype11 = value; } }
        private List<int> _api_slottype12 = new List<int>(); public List<int> api_slottype12 { get { return _api_slottype12; } set { _api_slottype12 = value; } }
        private List<int> _api_slottype13 = new List<int>(); public List<int> api_slottype13 { get { return _api_slottype13; } set { _api_slottype13 = value; } }
        private List<int> _api_slottype14 = new List<int>(); public List<int> api_slottype14 { get { return _api_slottype14; } set { _api_slottype14 = value; } }
        private List<int> _api_slottype15 = new List<int>(); public List<int> api_slottype15 { get { return _api_slottype15; } set { _api_slottype15 = value; } }
        private List<int> _api_slottype16 = new List<int>(); public List<int> api_slottype16 { get { return _api_slottype16; } set { _api_slottype16 = value; } }
        private List<int> _api_slottype17 = new List<int>(); public List<int> api_slottype17 { get { return _api_slottype17; } set { _api_slottype17 = value; } }
        private List<int> _api_slottype18 = new List<int>(); public List<int> api_slottype18 { get { return _api_slottype18; } set { _api_slottype18 = value; } }
        private List<int> _api_slottype19 = new List<int>(); public List<int> api_slottype19 { get { return _api_slottype19; } set { _api_slottype19 = value; } }
        private List<int> _api_slottype20 = new List<int>(); public List<int> api_slottype20 { get { return _api_slottype20; } set { _api_slottype20 = value; } }
        private List<int> _api_slottype21 = new List<int>(); public List<int> api_slottype21 { get { return _api_slottype21; } set { _api_slottype21 = value; } }
        private List<int> _api_slottype22 = new List<int>(); public List<int> api_slottype22 { get { return _api_slottype22; } set { _api_slottype22 = value; } }
        private List<int> _api_slottype23 = new List<int>(); public List<int> api_slottype23 { get { return _api_slottype23; } set { _api_slottype23 = value; } }
        private List<int> _api_slottype24 = new List<int>(); public List<int> api_slottype24 { get { return _api_slottype24; } set { _api_slottype24 = value; } }
        private List<int> _api_slottype25 = new List<int>(); public List<int> api_slottype25 { get { return _api_slottype25; } set { _api_slottype25 = value; } }
        private List<int> _api_slottype26 = new List<int>(); public List<int> api_slottype26 { get { return _api_slottype26; } set { _api_slottype26 = value; } }
        private List<int> _api_slottype27 = new List<int>(); public List<int> api_slottype27 { get { return _api_slottype27; } set { _api_slottype27 = value; } }
        private List<int> _api_slottype28 = new List<int>(); public List<int> api_slottype28 { get { return _api_slottype28; } set { _api_slottype28 = value; } }
        private List<int> _api_slottype29 = new List<int>(); public List<int> api_slottype29 { get { return _api_slottype29; } set { _api_slottype29 = value; } }
        private List<int> _api_slottype30 = new List<int>(); public List<int> api_slottype30 { get { return _api_slottype30; } set { _api_slottype30 = value; } }
        private List<int> _api_slottype31 = new List<int>(); public List<int> api_slottype31 { get { return _api_slottype31; } set { _api_slottype31 = value; } }
        private List<int> _api_slottype32 = new List<int>(); public List<int> api_slottype32 { get { return _api_slottype32; } set { _api_slottype32 = value; } }
        private List<int> _api_slottype33 = new List<int>(); public List<int> api_slottype33 { get { return _api_slottype33; } set { _api_slottype33 = value; } }
        private List<int> _api_slottype34 = new List<int>(); public List<int> api_slottype34 { get { return _api_slottype34; } set { _api_slottype34 = value; } }
        private List<int> _api_slottype35 = new List<int>(); public List<int> api_slottype35 { get { return _api_slottype35; } set { _api_slottype35 = value; } }
        private List<int> _api_slottype36 = new List<int>(); public List<int> api_slottype36 { get { return _api_slottype36; } set { _api_slottype36 = value; } }
        private List<int> _api_slottype37 = new List<int>(); public List<int> api_slottype37 { get { return _api_slottype37; } set { _api_slottype37 = value; } }
        private List<int> _api_slottype38 = new List<int>(); public List<int> api_slottype38 { get { return _api_slottype38; } set { _api_slottype38 = value; } }
        private List<int> _api_slottype39 = new List<int>(); public List<int> api_slottype39 { get { return _api_slottype39; } set { _api_slottype39 = value; } }
        private List<int> _api_slottype40 = new List<int>(); public List<int> api_slottype40 { get { return _api_slottype40; } set { _api_slottype40 = value; } }
        private List<int> _api_slottype41 = new List<int>(); public List<int> api_slottype41 { get { return _api_slottype41; } set { _api_slottype41 = value; } }
        private List<int> _api_slottype42 = new List<int>(); public List<int> api_slottype42 { get { return _api_slottype42; } set { _api_slottype42 = value; } }
        private List<int> _api_slottype43 = new List<int>(); public List<int> api_slottype43 { get { return _api_slottype43; } set { _api_slottype43 = value; } }
        private List<int> _api_slottype44 = new List<int>(); public List<int> api_slottype44 { get { return _api_slottype44; } set { _api_slottype44 = value; } }
        private List<int> _api_slottype45 = new List<int>(); public List<int> api_slottype45 { get { return _api_slottype45; } set { _api_slottype45 = value; } }
        private List<int> _api_slottype46 = new List<int>(); public List<int> api_slottype46 { get { return _api_slottype46; } set { _api_slottype46 = value; } }
        private List<int> _api_slottype47 = new List<int>(); public List<int> api_slottype47 { get { return _api_slottype47; } set { _api_slottype47 = value; } }
        private List<int> _api_slottype48 = new List<int>(); public List<int> api_slottype48 { get { return _api_slottype48; } set { _api_slottype48 = value; } }
    }

    public class Api_Mst_Item_Shop: KAPIBaseData
    {
	    public Api_Mst_Item_Shop(){}

        private List<int> _api_cabinet_1 = new List<int>(); public List<int> api_cabinet_1 { get { return _api_cabinet_1; } set { _api_cabinet_1 = value; } }
        private List<int> _api_cabinet_2 = new List<int>(); public List<int> api_cabinet_2 { get { return _api_cabinet_2; } set { _api_cabinet_2 = value; } }
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

        private Api_Boko_Max_Ships _api_boko_max_ships = new Api_Boko_Max_Ships(); public Api_Boko_Max_Ships api_boko_max_ships { get { return _api_boko_max_ships; } set { _api_boko_max_ships = value; } }
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
        private List<int> _api_taik = new List<int>(); public List<int> api_taik { get { return _api_taik; } set { _api_taik = value; } }
        private List<int> _api_souk = new List<int>(); public List<int> api_souk { get { return _api_souk; } set { _api_souk = value; } }
        private List<int> _api_tous = new List<int>(); public List<int> api_tous { get { return _api_tous; } set { _api_tous = value; } }   // diff
        private List<int> _api_houg = new List<int>(); public List<int> api_houg { get { return _api_houg; } set { _api_houg = value; } }
        private List<int> _api_raig = new List<int>(); public List<int> api_raig { get { return _api_raig; } set { _api_raig = value; } }
        private List<int> _api_baku = new List<int>(); public List<int> api_baku { get { return _api_baku; } set { _api_baku = value; } }
        private List<int> _api_tyku = new List<int>(); public List<int> api_tyku { get { return _api_tyku; } set { _api_tyku = value; } }
        private List<int> _api_atap = new List<int>(); public List<int> api_atap { get { return _api_atap; } set { _api_atap = value; } }   // diff
        private List<int> _api_tais = new List<int>(); public List<int> api_tais { get { return _api_tais; } set { _api_tais = value; } }   // diff
        private List<int> _api_houm = new List<int>(); public List<int> api_houm { get { return _api_houm; } set { _api_houm = value; } }
        private List<int> _api_raim = new List<int>(); public List<int> api_raim { get { return _api_raim; } set { _api_raim = value; } }
        private List<int> _api_kaih = new List<int>(); public List<int> api_kaih { get { return _api_kaih; } set { _api_kaih = value; } }   // diff
        private List<int> _api_houk = new List<int>(); public List<int> api_houk { get { return _api_houk; } set { _api_houk = value; } } // diff
        private List<int> _api_raik = new List<int>(); public List<int> api_raik { get { return _api_raik; } set { _api_raik = value; } } // diff
        private List<int> _api_bakk = new List<int>(); public List<int> api_bakk { get { return _api_bakk; } set { _api_bakk = value; } } // diff
        private List<int> _api_saku = new List<int>(); public List<int> api_saku { get { return _api_saku; } set { _api_saku = value; } }
        private List<int> _api_sakb = new List<int>(); public List<int> api_sakb { get { return _api_sakb; } set { _api_sakb = value; } } // diff
        private List<int> _api_luck = new List<int>(); public List<int> api_luck { get { return _api_luck; } set { _api_luck = value; } }
	    public int api_sokuh {get; set;}
	    public int api_soku {get; set;}
	    public int api_leng {get; set;}
        private List<int> _api_grow = new List<int>(); public List<int> api_grow { get { return _api_grow; } set { _api_grow = value; } }
        public int api_slot_num { get; set; }
        private List<int> _api_maxeq = new List<int>(); public List<int> api_maxeq { get { return _api_maxeq; } set { _api_maxeq = value; } }
        private List<int> _api_defeq = new List<int>(); public List<int> api_defeq { get { return _api_defeq; } set { _api_defeq = value; } }
        public int api_buildtime { get; set; }
        private List<int> _api_broken = new List<int>(); public List<int> api_broken { get { return _api_broken; } set { _api_broken = value; } }
        private List<int> _api_powup = new List<int>(); public List<int> api_powup { get { return _api_powup; } set { _api_powup = value; } }
        private List<int> _api_gumax = new List<int>(); public List<int> api_gumax { get { return _api_gumax; } set { _api_gumax = value; } }
	    public int api_backs {get; set;}
	    public string api_getmes {get; set;}
	    public string api_homemes {get; set;} //o
	    public string api_gomes {get; set;} //o
	    public string api_gomes2 {get; set;} //o
	    public string api_sinfo {get; set;}
	    public int api_afterfuel {get; set;}
	    public int api_afterbull {get; set;}
        private List<string> _api_touchs = new List<string>(); public List<string> api_touchs { get { return _api_touchs; } set { _api_touchs = value; } } //o[ ]
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
        private List<int> _api_boko_n = new List<int>(); public List<int> api_boko_n { get { return _api_boko_n; } set { _api_boko_n = value; } }
        private List<int> _api_boko_d = new List<int>(); public List<int> api_boko_d { get { return _api_boko_d; } set { _api_boko_d = value; } }
        private List<int> _api_kaisyu_n = new List<int>(); public List<int> api_kaisyu_n { get { return _api_kaisyu_n; } set { _api_kaisyu_n = value; } }
        private List<int> _api_kaisyu_d = new List<int>(); public List<int> api_kaisyu_d { get { return _api_kaisyu_d; } set { _api_kaisyu_d = value; } }
        private List<int> _api_kaizo_n = new List<int>(); public List<int> api_kaizo_n { get { return _api_kaizo_n; } set { _api_kaizo_n = value; } }
        private List<int> _api_kaizo_d = new List<int>(); public List<int> api_kaizo_d { get { return _api_kaizo_d; } set { _api_kaizo_d = value; } }
        private List<int> _api_map_n = new List<int>(); public List<int> api_map_n { get { return _api_map_n; } set { _api_map_n = value; } }
        private List<int> _api_map_d = new List<int>(); public List<int> api_map_d { get { return _api_map_d; } set { _api_map_d = value; } }
        private List<int> _api_ensyuf_n = new List<int>(); public List<int> api_ensyuf_n { get { return _api_ensyuf_n; } set { _api_ensyuf_n = value; } }
        private List<int> _api_ensyuf_d = new List<int>(); public List<int> api_ensyuf_d { get { return _api_ensyuf_d; } set { _api_ensyuf_d = value; } }
        private List<int> _api_ensyue_n = new List<int>(); public List<int> api_ensyue_n { get { return _api_ensyue_n; } set { _api_ensyue_n = value; } }
        private List<int> _api_battle_n = new List<int>(); public List<int> api_battle_n { get { return _api_battle_n; } set { _api_battle_n = value; } }
        private List<int> _api_battle_d = new List<int>(); public List<int> api_battle_d { get { return _api_battle_d; } set { _api_battle_d = value; } }
        private List<int> _api_weda = new List<int>(); public List<int> api_weda { get { return _api_weda; } set { _api_weda = value; } }
        private List<int> _api_wedb = new List<int>(); public List<int> api_wedb { get { return _api_wedb; } set { _api_wedb = value; } }
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
        private Api_Equip_Type _api_equip_type = new Api_Equip_Type(); public Api_Equip_Type api_equip_type { get { return _api_equip_type; } set { _api_equip_type = value; } }
    }

    public class Api_Mst_Slotitem: KAPIBaseData
    {
	    public Api_Mst_Slotitem(){}

	    public int api_id {get; set;}
	    public int api_sortno {get; set;}
        public string api_name { get; set; }
        private List<int> _api_type = new List<int>(); public List<int> api_type { get { return _api_type; } set { _api_type = value; } }
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
        private List<int> _api_broken = new List<int>(); public List<int> api_broken { get { return _api_broken; } set { _api_broken = value; } }
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
        private List<string> _api_description = new List<string>(); public List<string> api_description { get { return _api_description; } set { _api_description = value; } }
	    public int api_price {get; set;}
    }

    public class Api_Mst_Payitem: KAPIBaseData
    {
	    public Api_Mst_Payitem(){}

	    public int api_id {get; set;}
	    public int api_type {get; set;}
	    public string api_name {get; set;}
	    public string api_description {get; set;}
        private List<int> _api_item = new List<int>(); public List<int> api_item { get { return _api_item; } set { _api_item = value; } }
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
        private List<int> _api_item = new List<int>(); public List<int> api_item { get { return _api_item; } set { _api_item = value; } }
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
        private List<int> _api_map_bgm = new List<int>(); public List<int> api_map_bgm { get { return _api_map_bgm; } set { _api_map_bgm = value; } }
        private List<int> _api_boss_bgm = new List<int>(); public List<int> api_boss_bgm { get { return _api_boss_bgm; } set { _api_boss_bgm = value; } }
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
        private List<int> _api_win_item1 = new List<int>(); public List<int> api_win_item1 { get { return _api_win_item1; } set { _api_win_item1 = value; } }
        private List<int> _api_win_item2 = new List<int>(); public List<int> api_win_item2 { get { return _api_win_item2; } set { _api_win_item2 = value; } }
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

        private List<kcsapi_mst_ship> _api_mst_ship = new List<kcsapi_mst_ship>(); public List<kcsapi_mst_ship> api_mst_ship { get { return _api_mst_ship; } set { _api_mst_ship = value; } }
        private List<kcsapi_mst_slotitem> _api_mst_slotitem = new List<kcsapi_mst_slotitem>(); public List<kcsapi_mst_slotitem> api_mst_slotitem { get { return _api_mst_slotitem; } set { _api_mst_slotitem = value; } }
        private List<kcsapi_mst_useitem> _api_mst_useitem = new List<kcsapi_mst_useitem>(); public List<kcsapi_mst_useitem> api_mst_useitem { get { return _api_mst_useitem; } set { _api_mst_useitem = value; } }
        private List<kcsapi_mst_stype> _api_mst_stype = new List<kcsapi_mst_stype>(); public List<kcsapi_mst_stype> api_mst_stype { get { return _api_mst_stype; } set { _api_mst_stype = value; } }
        private List<kcsapi_mst_slotitem_equiptype> _api_mst_slotitem_equiptype = new List<kcsapi_mst_slotitem_equiptype>(); public List<kcsapi_mst_slotitem_equiptype> api_mst_slotitem_equiptype { get { return _api_mst_slotitem_equiptype; } set { _api_mst_slotitem_equiptype = value; } }

	    // Keep

        private List<Api_Mst_Shipgraph> _api_mst_shipgraph = new List<Api_Mst_Shipgraph>(); public List<Api_Mst_Shipgraph> api_mst_shipgraph { get { return _api_mst_shipgraph; } set { _api_mst_shipgraph = value; } }
        private List<Api_Mst_Slotitemgraph> _api_mst_slotitemgraph = new List<Api_Mst_Slotitemgraph>(); public List<Api_Mst_Slotitemgraph> api_mst_slotitemgraph { get { return _api_mst_slotitemgraph; } set { _api_mst_slotitemgraph = value; } }
        private List<Api_Mst_Furniture> _api_mst_furniture = new List<Api_Mst_Furniture>(); public List<Api_Mst_Furniture> api_mst_furniture { get { return _api_mst_furniture; } set { _api_mst_furniture = value; } }
        private List<Api_Mst_Furnituregraph> _api_mst_furnituregraph = new List<Api_Mst_Furnituregraph>(); public List<Api_Mst_Furnituregraph> api_mst_furnituregraph { get { return _api_mst_furnituregraph; } set { _api_mst_furnituregraph = value; } }
        private List<Api_Mst_Payitem> _api_mst_payitem = new List<Api_Mst_Payitem>(); public List<Api_Mst_Payitem> api_mst_payitem { get { return _api_mst_payitem; } set { _api_mst_payitem = value; } }
        private Api_Mst_Item_Shop _api_mst_item_shop = new Api_Mst_Item_Shop(); public Api_Mst_Item_Shop api_mst_item_shop { get { return _api_mst_item_shop; } set { _api_mst_item_shop = value; } }
        private List<Api_Mst_Maparea> _api_mst_maparea = new List<Api_Mst_Maparea>(); public List<Api_Mst_Maparea> api_mst_maparea { get { return _api_mst_maparea; } set { _api_mst_maparea = value; } }
        private List<Api_Mst_Mapinfo> _api_mst_mapinfo = new List<Api_Mst_Mapinfo>(); public List<Api_Mst_Mapinfo> api_mst_mapinfo { get { return _api_mst_mapinfo; } set { _api_mst_mapinfo = value; } }
        private List<Api_Mst_Mapbgm> _api_mst_mapbgm = new List<Api_Mst_Mapbgm>(); public List<Api_Mst_Mapbgm> api_mst_mapbgm { get { return _api_mst_mapbgm; } set { _api_mst_mapbgm = value; } }
        private List<Api_Mst_Mapcell> _api_mst_mapcell = new List<Api_Mst_Mapcell>(); public List<Api_Mst_Mapcell> api_mst_mapcell { get { return _api_mst_mapcell; } set { _api_mst_mapcell = value; } }
        private List<Api_Mst_Mission> _api_mst_mission = new List<Api_Mst_Mission>(); public List<Api_Mst_Mission> api_mst_mission { get { return _api_mst_mission; } set { _api_mst_mission = value; } }
        private List<Api_Mst_Const> _api_mst_const = new List<Api_Mst_Const>(); public List<Api_Mst_Const> api_mst_const { get { return _api_mst_const; } set { _api_mst_const = value; } }
        private List<Api_Mst_Shipupgrade> _api_mst_shipupgrade = new List<Api_Mst_Shipupgrade>(); public List<Api_Mst_Shipupgrade> api_mst_shipupgrade { get { return _api_mst_shipupgrade; } set { _api_mst_shipupgrade = value; } }
    }

    /**
     * @brief The kcsapi_port class
     */
    public class kcsapi_port: KAPIBaseData
    {
	    public kcsapi_port(){}

        private List<kcsapi_material> _api_material = new List<kcsapi_material>() {         
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
        }; public List<kcsapi_material> api_material { get { return _api_material; } set { _api_material = value; } }
        private List<kcsapi_deck> _api_deck_port = new List<kcsapi_deck>(); public List<kcsapi_deck> api_deck_port { get { return _api_deck_port; } set { _api_deck_port = value; } }
        private List<kcsapi_ndock> _api_ndock = new List<kcsapi_ndock>(); public List<kcsapi_ndock> api_ndock { get { return _api_ndock; } set { _api_ndock = value; } }
        private List<kcsapi_ship2> _api_ship = new List<kcsapi_ship2>(); public List<kcsapi_ship2> api_ship { get { return _api_ship; } set { _api_ship = value; } }
        private kcsapi_basic _api_basic = new kcsapi_basic(); public kcsapi_basic api_basic { get { return _api_basic; } set { _api_basic = value; } }
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
        private List<string> _api_description = new List<string>(); public List<string> api_description { get { return _api_description; } set { _api_description = value; } }
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
        private kcsapi_next_enemy _api_enemy = new kcsapi_next_enemy(); public kcsapi_next_enemy api_enemy { get { return _api_enemy; } set { _api_enemy = value; } }
    }

    /**
    * @brief The kcsapi_mission_start class
    */
    public class kcsapi_mission_start : KAPIBaseData
    {
	    public kcsapi_mission_start(){}

        private Int64 _api_complatetime = new Int64(); public Int64 api_complatetime { get { return _api_complatetime; } set { _api_complatetime = value; } }
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
        private List<int> _api_remodel_id = new List<int>(); public List<int> api_remodel_id { get { return _api_remodel_id; } set { _api_remodel_id = value; } }
        private List<int> _api_after_material = new List<int>(); public List<int> api_after_material { get { return _api_after_material; } set { _api_after_material = value; } }
	    public int api_voice_id {get; set;}
        private kcsapi_slotitem _api_after_slot = new kcsapi_slotitem(); public kcsapi_slotitem api_after_slot { get { return _api_after_slot; } set { _api_after_slot = value; } }
    }

}