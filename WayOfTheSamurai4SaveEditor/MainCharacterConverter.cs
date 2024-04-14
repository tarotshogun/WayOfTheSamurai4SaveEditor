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
        public static ObservableCollection<MainCharacter> ToMainCharacters(RawSaveData raw)
        {
            var name = Encoding.Unicode.GetString(raw.Name);
            var money = BitConverter.ToUInt32(raw.Money);
            var cashbox = BitConverter.ToUInt32(raw.Cashbox);

            return
            [
                new MainCharacter{Name=name, Money=money, Cashbox=cashbox},
            ];
        }

        public static void ToRawMainCharacter(MainCharacter character, ref RawSaveData raw)
        {
            Array.Copy(Encoding.Unicode.GetBytes(character.Name), raw.Name, character.Name.Length);
            Array.Copy(BitConverter.GetBytes(character.Money), raw.Money, sizeof(uint));
            Array.Copy(BitConverter.GetBytes(character.Cashbox), raw.Cashbox, sizeof(uint));
        }
    }
}
