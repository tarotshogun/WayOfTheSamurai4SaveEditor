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
            string name = Encoding.Unicode.GetString(raw.Name);
            uint money = BitConverter.ToUInt16(raw.Money);

            return
            [
                new MainCharacter{Name=name, Money=money},
            ];
        }
        public static void ToRawMainCharacter(MainCharacter character, ref RawSaveData raw)
        {
            // TODO: Delete the magic number
            Array.Copy(Encoding.Unicode.GetBytes(character.Name), raw.Name, 64);
            Array.Copy(BitConverter.GetBytes(character.Money), raw.Money, 2);
        }
    }
}
