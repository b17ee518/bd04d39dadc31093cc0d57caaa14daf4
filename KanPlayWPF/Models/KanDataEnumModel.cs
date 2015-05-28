using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace KanPlayWPF.Models
{
    public enum MaterialDataIndex
    {
        Fuel = 0,
        Bullet,
        Steel,
        Bauxite,
        InstantBuild,
        InstantRepair,
        Development,
        PowerUp,        // untested
    }

    public enum SlotItemType
    {
        SYUHOU_S = 1,
        SYUHOU_M = 2,
        SYUHOU_L = 3,
        FUKUHOU = 4,
        GYORAI = 5,
        KANSEN = 6,
        KANBAKU = 7,
        KANKOU = 8,
        TEISATSU = 9,
        SUITEI = 10,
        SUIBAKU = 11,
        DENTAN_S = 12,
        DENTAN_L = 13,
        SONAR = 14,
        BAKURAI = 15,
        SOUKA = 16,
        KIKAN = 17,
        TAIKUTAN = 18,
        TAIKANTAN = 19,
        VT = 20,
        TAIKUKIJU = 21,
        TOKUSEN = 22,
        OUKYU = 23,
        JOURIKUTEI = 24,
        OTOJAIRO = 25,
        TAISENKI = 26,
        SOUKA_M = 27,
        SOUKA_L = 28,
        TANSYOUTOU = 29,
        YUSOU = 30,
        KANSYU = 31,
        SENSUIKANGYORAI = 32,
        SYOUMEITAN = 33,
	    SIREIBU = 34,
	    KOUKU_YOUIN = 35,
	    KOUSYA = 36,
	    TAICHI = 37,
	    SYUHOU_L_II = 38,
	    SUIJOU_YOUIN = 39,
	    SONAR_L = 40,
	    HIKOUTEI_L = 41,
    }

    public enum ShipType
    {
        KAIBOU = 1,
        KUCHIKU = 2,
        KEIJUN = 3,
        RAIJUN = 4,
        JUJUN = 5,
        KOUJUN = 6,
        KEIKUBO = 7,
        KOUSOKUSENKAN = 8,
        TEISOKUSENKAN = 9,
        KOUSEN = 10,
        KUBO = 11,
        DOSENKAN = 12,
        SENSUI = 13,
        SENBO = 14,
        HOKYU = 15,
        SUIBO = 16,
        YOURIKU = 17,
        SOUKAKUBO = 18,
        KOUSAKU = 19,
        SENSUIBOKAN = 20,
        RENJUN = 21,
    }

    public enum SeikuResultType
    {
        KaKuHo = 1,
        YuSei = 2,
        Unknown = 3,
        SouSiTu = 4,
    }
    
    public class KanDataEnumModel : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
    }
}
