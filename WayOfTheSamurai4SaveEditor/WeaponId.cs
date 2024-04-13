using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    // 表示用の変換処理を作るのがめんどくさいので変数名を全部日本語にする
    public enum WeaponIdList
    {
        なまくら刀 = 0x0068,
        カツオ = 0x0070,
        クルセイダー = 0x002C,
        自作 = 0xFFFF,
    }

    public enum UniqueWeaponList
    {
        無 = 0xFFFF,
    }
}
