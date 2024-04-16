using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayOfTheSamurai4SaveEditor.Models.RawData;
using WayOfTheSamurai4SaveEditor.Models.SaveData;

namespace WayOfTheSamurai4SaveEditor.Models.SaveDataConverter
{
    static class MainCharacterConverter
    {
        public static ObservableCollection<MainCharacter> ToMainCharacters(RawSaveData raw)
        {
            var name = Encoding.Unicode.GetString(raw.Name);
            var money = BitConverter.ToUInt32(raw.Money);
            var cashbox = BitConverter.ToUInt32(raw.Cashbox);
            var samuraiPoint = BitConverter.ToUInt32(raw.SamuraiPoint);
            var hp = BitConverter.ToSingle(raw.Hp);
            var katsuryoku = BitConverter.ToSingle(raw.Katsuryoku);

            return
            [
                new MainCharacter{
                    Name=name,
                    Money=money,
                    Cashbox=cashbox,
                    SamuraiPoint = samuraiPoint,
                    Hp = hp,
                    Katsuryoku = katsuryoku
                },
            ];
        }

        public static void ToRawMainCharacter(MainCharacter character, ref RawSaveData raw)
        {
            Array.Copy(Encoding.Unicode.GetBytes(character.Name), raw.Name, character.Name.Length);
            Array.Copy(BitConverter.GetBytes(character.Money), raw.Money, raw.Money.Length);
            Array.Copy(BitConverter.GetBytes(character.Cashbox), raw.Cashbox, raw.Cashbox.Length);
            Array.Copy(BitConverter.GetBytes(character.SamuraiPoint), raw.SamuraiPoint, raw.SamuraiPoint.Length);
            Array.Copy(BitConverter.GetBytes(character.Hp), raw.Hp, raw.Hp.Length);
            Array.Copy(BitConverter.GetBytes(character.Katsuryoku), raw.Katsuryoku, raw.Katsuryoku.Length);
        }
    }
}
