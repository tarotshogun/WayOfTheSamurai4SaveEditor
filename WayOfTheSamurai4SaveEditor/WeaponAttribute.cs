using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    enum Mei : uint
    {
        人斬り = 0x016A00,
        狂事 = 0x01016B,
        血河 = 0x02016C,
        黄泉路 = 0x03016D,
        猟奇守 = 0x04016E,

        石頭 = 0x05016F,
        鉄壁 = 0x060170,
        白金造 = 0x070171,
        金剛造 = 0x080172,
        不壊 = 0x090173,

        一輝 = 0x0A0174,
        二条 = 0x0B0175,
        三晃 = 0x0C0176,
        四海 = 0x0D0177,
        悟道 = 0x0E0178,

        剃刀 = 0x0F0179,
        鋭刃 = 0x10017A,
        冷刃 = 0x11017B,
        鬼神 = 0x12017C,
        散華 = 0x13017D,

        なし = 0xFFFFFF,
    }

    public enum Attraction : ushort
    {
        天運 = 0x0000,
        暗刃 = 0x0001,
        明刃 = 0x0002,
        銭呼 = 0x0003,
        活復 = 0x0004,
        疾風 = 0x0005,
        背水 = 0x0006,
        投抜 = 0x0007,
        頑健 = 0x0008,
        重撃 = 0x0009,

        なし = 0xFFFF,
    }
}
