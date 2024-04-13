using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public static class SaveDataConverter
    {
        public static SaveDataViewModel ToSaveData(RawSaveData raw)
        {
            return new SaveDataViewModel
            {
                MainCharacters = MainCharacterConverter.ToMainCharacters(ref raw),
                BukiDansu = WeaponConverter.ToWeapons(ref raw.BukiDansu),
            };
        }

        public static RawSaveData ToRawSaveData(SaveDataViewModel save, RawSaveData original)
        {
            return original;
        }
    }
}
