using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor.Models.SaveData
{
    enum RareItemId : ushort
    {
        くず鉄 = 0x0029,
        卸し鉄 = 0x002A,
        堂島鋼 = 0x002B,
        緋緋色金 = 0x002C,
        なし = 0xFFFF,
    }

    class RareItem
    {
        RareItemId id = RareItemId.なし;
        uint count = 0;
    }
}
