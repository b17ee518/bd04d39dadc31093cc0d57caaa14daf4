using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    public enum BattleType
    {
        Day,
        Night,
        DayToNight,
        NightToDay,

        Air,

        CombinedBegin,

        Combined_KouKu,
        Combined_Water,
        Combined_KouKuNight,
        Combined_Day,
        Combined_Nignt,
        Combined_DayToNight,
    }

    public class KanBattle
    {
        public static List<int> updateBattle(kcsapi_battle api_battle, BattleType type)
        {
            KanSaveData pksd = KanSaveData.Instance;
            KanDataConnector pkdc = KanDataConnector.Instance;

	        int dockid = 0;
	        int dockid_combined = -1;
	        bool bCombined = false;
	        if (type < BattleType.CombinedBegin)
	        {
		        dockid = api_battle.api_dock_id - 1;
		        // midnight
		        if (type == BattleType.Night || type == BattleType.DayToNight || dockid < 0)
		        {
			        dockid = api_battle.api_deck_id - 1;
		        }		
	        }
	        else
	        {
		        bCombined = true;
		        dockid_combined = 1;
	        }

	        List<int> enemyhps = new List<int>();

	        if (dockid >= 0)
	        {
		        pksd.lastbattletype = type;
		        pksd.lastdeckid = dockid;

		        List<kcsapi_ship2> pships = new List<kcsapi_ship2>();
		        foreach(int shipid in pksd.portdata.api_deck_port[dockid].api_ship)
		        {
			        if (shipid > 0)
			        {
				        kcsapi_ship2 pship = pkdc.findShipFromShipno(shipid);
				        if (pship != null)
				        {
					        pships.Add(pkdc.findShipFromShipno(shipid));
				        }
			        }
		        }
		        List<kcsapi_ship2>pships_combined = new List<kcsapi_ship2>();
		        if (dockid_combined >= 0)
		        {
			        foreach(int shipid in pksd.portdata.api_deck_port[dockid_combined].api_ship)
			        {
				        if (shipid > 0)
				        {
					        kcsapi_ship2 pship = pkdc.findShipFromShipno(shipid);
					        if (pship != null)
					        {
						        pships_combined.Add(pkdc.findShipFromShipno(shipid));
					        }
				        }
			        }
		        }

		        List<Double> totalfdamage = new List<double>();
		        for (int i = 0; i < 7; i++)
		        {
			        totalfdamage.Add(0);
		        }
		        List<Double> totalfdamage_combined = new List<double>();
		        for (int i = 0; i < 7; i++)
		        {
                    totalfdamage_combined.Add(0);
		        }
		        List<Double> totaledamage = new List<double>();
		        for (int i = 0; i < 7; i++)
		        {
                    totaledamage.Add(0);
		        }

		        List<int> api_nowhps = api_battle.api_nowhps;
		        List<int> api_nowhps_combined = api_battle.api_nowhps_combined;
		        //TODO: formation
		        int stageflagcount = api_battle.api_stage_flag.Count;
		        if (stageflagcount >= 3)
		        {
			        //　航空ダメージ
			        if (api_battle.api_stage_flag[2] > 0)
			        {
				        for (int i = 1; i < api_battle.api_kouku.api_stage3.api_fdam.Count; i++)
				        {
					        totalfdamage[i] += api_battle.api_kouku.api_stage3.api_fdam[i];
				        }
				        for (int i = 1; i < api_battle.api_kouku.api_stage3.api_edam.Count; i++)
				        {
					        totaledamage[i] += api_battle.api_kouku.api_stage3.api_edam[i];
				        }
				        if (bCombined)
				        {
					        for (int i = 1; i < api_battle.api_kouku.api_stage3_combined.api_fdam.Count; i++)
					        {
						        totalfdamage_combined[i] += api_battle.api_kouku.api_stage3_combined.api_fdam[i];
					        }

					        // kouku2
					        for (int i = 1; i < api_battle.api_kouku2.api_stage3.api_fdam.Count; i++)
					        {
						        totalfdamage[i] += api_battle.api_kouku2.api_stage3.api_fdam[i];
					        }
					        for (int i = 1; i < api_battle.api_kouku2.api_stage3.api_edam.Count; i++)
					        {
						        totaledamage[i] += api_battle.api_kouku2.api_stage3.api_edam[i];
					        }
					        for (int i = 1; i < api_battle.api_kouku2.api_stage3_combined.api_fdam.Count; i++)
					        {
						        totalfdamage_combined[i] += api_battle.api_kouku2.api_stage3_combined.api_fdam[i];
					        }
				        }
			        }
		        }

		        if (type != BattleType.Night && type != BattleType.DayToNight && type != BattleType.Combined_KouKuNight && type != BattleType.Combined_DayToNight && type != BattleType.Combined_Nignt)
		        {
			        // support
			        if (api_battle.api_support_flag > 0)
			        {
				        switch (api_battle.api_support_flag)
				        {
				        case 1:	// kubaku
				        {
					        int supportstageflagcount = api_battle.api_support_info.api_support_airatack.api_stage_flag.Count;
					        if (supportstageflagcount >= 3)
					        {
						        if (api_battle.api_support_info.api_support_airatack.api_stage_flag[2] > 0)
						        {
							        for (int i = 1; i < api_battle.api_support_info.api_support_airatack.api_stage3.api_edam.Count; i++)
							        {
								        totaledamage[i] += api_battle.api_support_info.api_support_airatack.api_stage3.api_edam[i];
							        }
						        }
					        }

				        }
					        break;
				        case 2: // hougeki
				        case 3: // raigeki
				        {
					        for (int i = 1; i < api_battle.api_support_info.api_support_hourai.api_damage.Count; i++)
					        {
						        totaledamage[i] += api_battle.api_support_info.api_support_hourai.api_damage[i];
					        }
				        }
					        break;
				        default:
					        break;
				        }
			        }

			        // opening
			        // TODO: combined?
			        if (api_battle.api_opening_flag > 0)
			        {
				        for (int i = 0; i < api_battle.api_opening_atack.api_fdam.Count; i++)
				        {
					        if (bCombined/*api_battle.api_formation[0] == 11*/)
					        {
						        totalfdamage_combined[i] += api_battle.api_opening_atack.api_fdam[i];
					        }
					        else
					        {
						        totalfdamage[i] += api_battle.api_opening_atack.api_fdam[i];
					        }
				        }
				        for (int i = 0; i < api_battle.api_opening_atack.api_edam.Count; i++)
				        {
					        totaledamage[i] += api_battle.api_opening_atack.api_edam[i];
				        }
			        }

			        // hourai
			        int houraiflagcount = api_battle.api_hourai_flag.Count;
			        if (houraiflagcount >= 4)
			        {
				        int hougeki1flag = api_battle.api_hourai_flag[0];
				        int hougeki2flag = api_battle.api_hourai_flag[1];
				        int hougeki3flag = api_battle.api_hourai_flag[2];
				        int raigekiflag = api_battle.api_hourai_flag[3];
				        if (bCombined && type == BattleType.Combined_KouKu || type == BattleType.Combined_Day)
				        {
					        raigekiflag = api_battle.api_hourai_flag[1];
					        hougeki2flag = api_battle.api_hourai_flag[2];
					        hougeki3flag = api_battle.api_hourai_flag[3];
				        }
				        if (hougeki1flag > 0)
				        {
					        bool bCombineDamage = false;
                            if (type == BattleType.Combined_KouKu || type == BattleType.Combined_Day)
					        {
						        bCombineDamage = bCombined;
					        }
					        processHouraiDamages((api_battle.api_hougeki1), totalfdamage, totaledamage, totalfdamage_combined, bCombineDamage);
				        }
				        if (hougeki2flag > 0)
				        {
					        bool bCombineDamage = false;
					        processHouraiDamages((api_battle.api_hougeki2), totalfdamage, totaledamage, totalfdamage_combined, bCombineDamage);
				        }
				        if (hougeki3flag > 0)
				        {
					        bool bCombineDamage = bCombined;
					        if (type == BattleType.Combined_KouKu || type == BattleType.Combined_Day)
					        {
						        bCombineDamage = false;
					        }
					        processHouraiDamages((api_battle.api_hougeki3), totalfdamage, totaledamage, totalfdamage_combined, bCombineDamage);
				        }
				        // raigeki
				        if (raigekiflag > 0)
				        {
					        for (int i = 0; i < api_battle.api_raigeki.api_fdam.Count; i++)
					        {
						        if (bCombined)
						        {
							        totalfdamage_combined[i] += api_battle.api_raigeki.api_fdam[i];
						        }
						        else
						        {
							        totalfdamage[i] += api_battle.api_raigeki.api_fdam[i];
						        }
					        }
					        for (int i = 0; i < api_battle.api_raigeki.api_edam.Count; i++)
					        {
						        totaledamage[i] += api_battle.api_raigeki.api_edam[i];
					        }
				        }
			        }
		        }

		        else
		        {
			        // midnight
			        processHouraiDamages((api_battle.api_hougeki), totalfdamage, totaledamage, totalfdamage_combined, bCombined);
		        }

		        for (int i = 0; i < pships.Count; i++)
		        {
			        if (pships[i] != null)
			        {
				        pships[i].api_nowhp -= (int)totalfdamage[i + 1];
			        }
		        }
		        for (int i = 0; i < pships_combined.Count; i++)
		        {
			        if (pships_combined[i] != null)
			        {
				        pships_combined[i].api_nowhp -= (int)totalfdamage_combined[i + 1];
			        }
		        }
		        KanVMUpdater.Instance.updateFleetTable();

		        enemyhps.Add(0);
		        for (int i = 1; i < api_battle.api_ship_ke.Count; i++)
		        {
			        int nowhp = api_battle.api_nowhps[i + 6] - (int)totaledamage[i];
			        enemyhps.Add(nowhp);
		        }

                KanVMUpdater.Instance.updateInfoTitleBattle(true, enemyhps);

	        }
	        return enemyhps;
	
        }

        private static void processHouraiDamages(kcsapi_battle_hougeki api_hougeki, List<Double> totalfdamage, List<Double> totaledamage, List<Double> totalfdamage_combined, bool bOnlyCombined)
        {
	        // must skip 0!!!
	        List<Double> fdamage = totalfdamage;
	        if (bOnlyCombined)
	        {
		        fdamage = totalfdamage_combined;
	        }
	        for (int j = 1; j < api_hougeki.api_at_list.Count; j++)
	        {
		        bool bfattack = true;
		        bool bfdefend = true;

		        int attackpos = api_hougeki.api_at_list[j];
		        if (attackpos > 6)
		        {
			        bfattack = false;
			        attackpos -= 6;
		        }

		        if (attackpos > 0)
		        {
			        for (int k = 0; k < api_hougeki.api_df_list[j].Count; k++)
			        {
				        int defendpos = api_hougeki.api_df_list[j][k];
				        if (defendpos > 6)
				        {
					        bfdefend = false;
					        defendpos -= 6;
				        }

				        if (defendpos > 0)
				        {
					        if (bfdefend)
					        {
						        fdamage[defendpos] += api_hougeki.api_damage[j][k];
					        }
					        else
					        {
						        totaledamage[defendpos] += api_hougeki.api_damage[j][k];
					        }
				        }
			        }
		        }

	        }
        }

    }
}
