using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    // 表示用の変換処理を作るのがめんどくさいので変数名を全部日本語にする
    public enum YaibaMaterial : uint
    {
        なまくら刀 = 0x18013b,
        無 = 0xFFFFFF,
    }

    public enum TsubaMaterial : uint
    {
        なまくら刀 = 0x013d00,
        無 = 0xFFFFFF,
    }

    public enum TsukaMaterial : ushort
    {
        なまくら刀 = 0x013c,
        無 = 0xFFFF,
    }
}
