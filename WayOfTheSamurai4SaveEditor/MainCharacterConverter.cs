using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public static class MainCharacterConverter
    {
        public static ObservableCollection<MainCharacter> ToMainCharacters(ref readonly RawSaveData raw)
        {
            string name = Encoding.Unicode.GetString(raw.Name).TrimEnd('\0');
            uint money = BitConverter.ToUInt16(raw.Money);

            return
            [
                new MainCharacter{Name=name, Money=money},
            ];
        }
    }
}
