using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor.Models.SaveData
{
    [TypeConverter(typeof(EnumDisplayTypeConverter))]
    enum WeaponId: ushort
    {
        Id_0x0001 = 0x0001,
        [Description("中道刀")]
        Id_0x0002,
        [Description("数奇者")]
        Id_0x0003,
        [Description("徳母里")]
        Id_0x0004,
        [Description("与根助")]
        Id_0x0005,
        [Description("絶天")]
        Id_0x0006,
        [Description("一発丸")]
        Id_0x0007,
        Id_0x0008,
        [Description("ジャクリーン")]
        Id_0x0009,
        Id_0x000A,
        Id_0x000B,
        Id_0x000C,
        Id_0x000D,
        Id_0x000E,
        Id_0x000F,
        Id_0x0010,
        [Description("竹刀")]
        Id_0x0011,
        Id_0x0012,
        [Description("竹富士")]
        Id_0x0013,
        [Description("精霊舞")]
        Id_0x0014,
        [Description("十手")]
        Id_0x0015,
        [Description("炎天過")]
        Id_0x0016,
        [Description("氷天過")]
        Id_0x0017,
        [Description("ジョセフィーヌ")]
        Id_0x0018,
        [Description("一文字")]
        Id_0x0019,
        [Description("阿摩羅")]
        Id_0x001A,
        [Description("センチュリオン")]
        Id_0x001B,
        [Description("闇緊")]
        Yamikin,
        Id_0x001D,
        [Description("浅餓王")]
        Id_0x001E,
        [Description("天井割")]
        Id_0x001F,
        Id_0x0020,
        [Description("阿修羅")]
        Id_0x0021,
        [Description("寂蓮")]
        Id_0x0022,
        Id_0x0023,
        Id_0x0024,
        Id_0x0025,
        [Description("黒蜻蛉")]
        Id_0x0026,
        [Description("真心")]
        Id_0x0027,
        [Description("黒獅子")]
        Id_0x0028,
        [Description("羅刹")]
        Id_0x0029,
        [Description("風花")]
        Id_0x002A,
        [Description("藤奈美")]
        Id_0x002B,
        [Description("クルセイダー")]
        Crusader,
        Id_0x002D,
        Id_0x002E,
        [Description("正道刀")]
        Id_0x002F,
        [Description("天道刀")]
        Id_0x0030 = 0x0030,
        [Description("源平")]
        Id_0x0031,
        [Description("汎来巣")]
        Id_0x0032,
        [Description("五郎縞")]
        Id_0x0033,
        Id_0x0034,
        Id_0x0035,
        [Description("律義")]
        Id_0x0036,
        Id_0x0037,
        Id_0x0038,
        Id_0x0039,
        [Description("余熱")]
        Id_0x003A,
        [Description("チーフテン")]
        Id_0x0044 = 0x0044,
        Id_0x0045,
        [Description("物干竿")]
        Id_0x0046,
        [Description("日本橋")]
        Id_0x0047,
        [Description("手長")]
        Id_0x0048,
        [Description("幽餓王")]
        Id_0x0049,
        [Description("貪鬼丸")]
        Id_0x004A,
        [Description("馬通二")]
        Id_0x004B,
        Id_0x004C,
        [Description("猿丸")]
        Id_0x004D,
        [Description("蝉丸")]
        Id_0x004E,
        [Description("小式部")]
        Id_0x004F,
        Id_0x0050 = 0x0050,
        Id_0x0051,
        [Description("柾重")]
        Id_0x0052,
        [Description("蛇蜻蛉")]
        Id_0x0053, 
        [Description("曼珠沙華")]
        Id_0x0054,
        [Description("百代草")]
        Id_0x0055,
        [Description("不語仙")]
        Id_0x0056,
        [Description("金盞花")]
        Id_0x0057,
        Id_0x0058,
        [Description("富士ヶ根")]
        Id_0x0059,
        [Description("大文字")]
        Id_0x005A,
        [Description("麒麟児")]
        Id_0x005B,
        Id_0x005C,
        [Description("霜柱")]
        Id_0x005D,
        [Description("高楊枝")]
        Id_0x005F,
        [Description("無天下")]
        Id_0x0060,
        [Description("乃理州")]
        Id_0x0061,
        [Description("青伯")]
        Id_0x0062,
        Id_0x0063,
        [Description("霧単穂")]
        Id_0x0064,
        Id_0x0065,
        Id_0x0066,
        Id_0x0067,
        [Description("なまくら刀")]
        Id_0x0068,
        [Description("珍比羅")]
        Id_0x0069,
        Id_0x006A,
        Id_0x006B,
        [Description("出刃包丁")]
        Id_0x006C,
        Id_0x006D,
        [Description("陸奥守吉行")]
        Id_0x006E,
        [Description("M2リボルバー")]
        Id_0x006F,
        [Description("カツオ")]
        Id_0x0070,
        [Description("虎徹")]
        Id_0x0071,
        [Description("自作")]
        Original = 0xFFFF,
    }

    enum UniqueWeaponList : ulong
    {
        なし = 0x00FFFFFFF,
        // 二つ同じなのは堂島由来だから？不明
        闇緊 = 0x2B0002009E,
        竹富士 = 0x2B0002009E,
        絶天 = 0x3700040134,
    }
}
