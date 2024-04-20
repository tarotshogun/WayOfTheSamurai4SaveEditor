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
        [Description("ひよこういろう")]
        Uiro = 0x0005,
        [Description("砥石")]
        Toishi = 0x0010,
        [Description("梅酒")]
        Umeshu = 0x0025,
        [Description("コイン")]
        Coin = 0x0074,
        [Description("ゴカイ")]
        Gokai = 0x00C5,
        [Description("オキアミ")]
        Okiami = 0x00C6,
        [Description("シロギス")]
        Shirogisu = 0x0050,
        [Description("アカヒトデ")]
        Akahitode = 0x005E,
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
