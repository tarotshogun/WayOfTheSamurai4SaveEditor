using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor.Models.SaveData
{
    [TypeConverter(typeof(EnumDisplayTypeConverter))]
    enum ItemId: ushort
    {
        Id_0x0000 = 0x0000,
        Id_0x0001 = 0x0001,
        [Description("おにぎり")]
        RiceBall = 0x0002,
        [Description("腐ったおにぎり")]
        RottenRiceBall = 0x0003,
        Id_0x0004 = 0x0004,
        [Description("ひよこういろう")]
        Uiro = 0x0005,
        Id_0x0006 = 0x0006,
        [Description("毒きのこ")]
        DokuKinoko = 0x0007,
        [Description("阿修羅きのこ")]
        AshuraKinoko = 0x0008,
        [Description("秘薬")]
        Hiyaku = 0x0009,
        [Description("技ノ書")]
        WazaNoSho = 0x000A,
        [Description("奥義ノ書")]
        OgiNoSho = 0x000B,
        [Description("秘奥義ノ書")]
        HiogiNoSho = 0x000C,
        Id_0x000D = 0x000D,
        Id_0x000E = 0x000E,
        Id_0x000F = 0x000F,
        [Description("砥石")]
        Toishi = 0x0010,
        [Description("打ち粉")]
        Uchiko = 0x0011,
        [Description("酒")]
        Sake = 0x0012,
        [Description("刀油")]
        KatanaAbura = 0x0013,
        Id_0x0014 = 0x0014,
        Id_0x0015 = 0x0015,
        Id_0x0016 = 0x0016,
        Id_0x0017 = 0x0017,
        Id_0x0018 = 0x0018,
        Id_0x0019 = 0x0019,
        Id_0x001A = 0x001A,
        Id_0x001B = 0x001B,
        Id_0x001C = 0x001C,
        [Description("人参")]
        Ginseng = 0x001D,
        [Description("鬼辛子")]
        Onikarashi = 0x001E,
        Id_0x001F = 0x001F,
        Id_0x0020 = 0x0020,
        Id_0x0021 = 0x0021,
        [Description("白紙目録")]
        HakushiMokuroku = 0x0022,
        [Description("梅干し(大)")]
        Umeboshi = 0x0023,
        Id_0x0024 = 0x0024,
        [Description("梅酒")]
        Umeshu = 0x0025,
        [Description("チョコレート")]
        Chocolate= 0x0026,
        [Description("ソーダ水")]
        Soda = 0x0040,
        [Description("藁人形")]
        StrawDool = 0x0065,
        Id_0x0066 = 0x0066,
        Id_0x0067 = 0x0067,
        Id_0x0068 = 0x0068,
        Id_0x0069 = 0x0069,
        Id_0x006A = 0x006A,
        Id_0x006B = 0x006B,
        [Description("ワイン?")]
        Wine = 0x006C,
        [Description("極上ワイン")]
        SuperlativeWine = 0x006D,
        [Description("ビンテージワイン")]
        VintageWine = 0x006E,
        [Description("コイン")]
        Coin = 0x0074,
        [Description("ゴカイ")]
        Gokai = 0x00C5,
        [Description("オキアミ")]
        Okiami = 0x00C6,
        [Description("シロギス")]
        Shirogisu = 0x0050,
        Id_0x0051 = 0x0051,
        Id_0x0052 = 0x0052,
        Id_0x0053 = 0x0053,
        Id_0x0054 = 0x0054,
        Id_0x0055 = 0x0055,
        Id_0x0056 = 0x0056,
        Id_0x0057 = 0x0057,
        Id_0x0058 = 0x0058,
        Id_0x0059 = 0x0059,
        Id_0x005A = 0x005A,
        Id_0x005B = 0x005B,
        Id_0x005C = 0x005C,
        Id_0x005D = 0x005D,
        [Description("アカヒトデ")]
        Akahitode = 0x005E,
        [Description("伝説の魚")]
        LegendaryFish = 0x005F,
        [Description("")]
        None = 0xFFFF,
    }

    internal class Item
    {
        public IEnumerable<ItemId> ItemIdList { get; private set; } = Enum.GetValues<ItemId>();

        public ItemId Id { get; set; }
        public ushort Count { get; set; }
    }
}
