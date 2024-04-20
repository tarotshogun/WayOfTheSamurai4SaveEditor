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
        [Description("干物")]
        Himono = 0x0004,
        [Description("ひよこういろう")]
        Uiro = 0x0005,
        [Description("きのこ")]
        Mushroom = 0x0006,
        [Description("毒きのこ")]
        PoisonousMushroom = 0x0007,
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
        [Description("大根")]
        JapaneseRadish = 0x001A,
        Id_0x001B = 0x001B,
        Id_0x001C = 0x001C,
        [Description("人参")]
        Ginseng = 0x001D,
        [Description("鬼辛子")]
        Onikarashi = 0x001E,
        [Description("たまご")]
        Egg = 0x001F,
        Id_0x0020 = 0x0020,
        Id_0x0021 = 0x0021,
        [Description("白紙目録")]
        HakushiMokuroku = 0x0022,
        [Description("梅干し(大)")]
        UmeboshiDai = 0x0023,
        [Description("梅干し")]
        Umeboshi = 0x0024,
        [Description("梅酒")]
        Umeshu = 0x0025,
        [Description("チョコレート")]
        Chocolate= 0x0026,
        [Description("空き瓶")]
        EmptyBottle = 0x0027,
        [Description("ワイン")]
        Wine= 0x0028,
        [Description("ソーダ水")]
        Soda = 0x0040,
        [Description("シロギス")]
        Shirogisu = 0x0050,
        Id_0x0051 = 0x0051,
        Id_0x0052 = 0x0052,
        [Description("マサバ")]
        Id_0x0053 = 0x0053,
        Id_0x0054 = 0x0054,
        Id_0x0055 = 0x0055,
        Id_0x0056 = 0x0056,
        Id_0x0057 = 0x0057,
        Id_0x0058 = 0x0058,
        Id_0x0059 = 0x0059,
        [Description("ヤマメ")]
        Yamame = 0x005A,
        Id_0x005B = 0x005B,
        [Description("タコ")]
        Id_0x005C = 0x005C,
        [Description("ニホンザリガニ")]
        NihonZarigani = 0x005D,
        [Description("アカヒトデ")]
        RedStarfish = 0x005E,
        [Description("伝説の魚")]
        LegendaryFish = 0x005F,
        [Description("錆びた空き缶")]
        Id_0x0063 = 0x0063,
        [Description("長靴")]
        Boots = 0x0064,
        [Description("藁人形")]
        StrawDoll = 0x0065,
        Id_0x0066 = 0x0066,
        [Description("おにぎり(梅)")]
        RiceBallUme = 0x0067,
        [Description("おにぎり(鮭)")]
        RiceBallSalmon = 0x0068,
        [Description("おにぎり(高菜)")]
        RiceBallTakana = 0x0069,
        Id_0x006A = 0x006A,
        Id_0x006B = 0x006B,
        Id_0x006C = 0x006C,
        [Description("極上ワイン")]
        SuperlativeWine = 0x006D,
        [Description("ビンテージワイン")]
        VintageWine = 0x006E,
        Id_0x006F = 0x006F,
        [Description("コイン")]
        Coin = 0x0074,
        Id_0x00C0 = 0x00C0,
        Id_0x00C1 = 0x00C1,
        Id_0x00C2 = 0x00C2,
        Id_0x00C3 = 0x00C3,
        [Description("ミミズ")]
        Mimizu = 0x00C4,
        [Description("ゴカイ")]
        Gokai = 0x00C5,
        [Description("オキアミ")]
        Okiami = 0x00C6,
        [Description("エビ")]
        Shrimp = 0x00C7,
        [Description("小魚")]
        SmallFish = 0x00C8,
        [Description("疑似餌")]
        lure = 0x00C9,
        [Description("ねりエサ")]
        Neriesa = 0x00CA,
        [Description("もち")]
        RiceCake = 0x00CB,
        [Description("力ミミズ")]
        ChikaraMimizu = 0x00CC,
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
