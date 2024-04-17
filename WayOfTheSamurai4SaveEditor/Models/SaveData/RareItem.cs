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
        public IEnumerable<RareItemId> RareItemIdList { get; private set; } = Enum.GetValues<RareItemId>();

        public RareItemId Id
        {
            get { return _id; }
            set
            {
                _id = value;
                if (value == RareItemId.なし)
                {
                    // UIにも反映されるようにしたい
                    Count = 0;
                }
            }
        }

        public ushort Count
        {
            get { return _count; }
            set
            {
                const ushort MaxRareItemCount = 99;
                if (Id != RareItemId.なし)
                {
                    _count = value > MaxRareItemCount ? MaxRareItemCount : value;
                }
                else
                {
                    _count = 0;
                }
            }
        }

        private RareItemId _id = RareItemId.なし;
        private ushort _count = 0;
    }
}
