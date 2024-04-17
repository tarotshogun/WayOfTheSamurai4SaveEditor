using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayOfTheSamurai4SaveEditor.Models.RawData;
using WayOfTheSamurai4SaveEditor.Models.SaveData;

namespace WayOfTheSamurai4SaveEditor.Models.SaveDataConversion
{
    partial class WeaponConverter
    {
        public static ObservableCollection<Weapon> ToWeapons(RawCabinetWeapon[] raw)
        {
            var weapons = new ObservableCollection<Weapon>();
            foreach (var weapon in raw)
            {
                weapons.Add(ToWeapon(in weapon));
            }
            return weapons;
        }

        public static void ToRawCabinetWeapons(ObservableCollection<Weapon> weapons, ref RawCabinetWeapon[] raw)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                ToRawCabinetWeapon(weapons[i], ref raw[i]);
            }
        }

        static void ToRawCabinetWeapon(Weapon weapon, ref RawCabinetWeapon raw)
        {
            Array.Copy(Encoding.Unicode.GetBytes(weapon.Name), raw.Name, weapon.Name.Length);
            Array.Copy(BitConverter.GetBytes(weapon.Attack), raw.Attack, raw.Attack.Length);
            Array.Copy(BitConverter.GetBytes(weapon.Durability), raw.Durability, raw.Durability.Length);
            Array.Copy(BitConverter.GetBytes(weapon.MaxDurability), raw.MaxDurability, raw.MaxDurability.Length);
            Array.Copy(BitConverter.GetBytes(weapon.Quality), raw.Quality, raw.Quality.Length);
            Array.Copy(BitConverter.GetBytes(weapon.MaxQuality), raw.MaxQuality, raw.MaxQuality.Length);
            Array.Copy(BitConverter.GetBytes(weapon.KillCount), raw.KillCount, raw.KillCount.Length);
            Array.Copy(BitConverter.GetBytes(weapon.TsumagiriCount), raw.TsumagiriCount, raw.TsumagiriCount.Length);
            Array.Copy(BitConverter.GetBytes(weapon.TotalRecoveredDurability), raw.TotalRecoveredDurability, raw.TotalRecoveredDurability.Length);
            // Delete magic number and define constant value
            Array.Copy(BitConverter.GetBytes((uint)weapon.Yaiba), raw.Yaiba, 3);
            Array.Copy(BitConverter.GetBytes((uint)weapon.Tsuba), raw.Tsuba, 3);
            Array.Copy(BitConverter.GetBytes((ushort)weapon.Tsuka), raw.Tsuka, raw.Tsuka.Length);
            Array.Copy(BitConverter.GetBytes((uint)weapon.Mei), raw.Mei, raw.Mei.Length);
            ToRawAttractions(weapon.Attractions, ref raw.Attractions);
        }

        static void ToRawAttractions(Attraction[] attractions, ref RawAttraction[] raw)
        {
            // rawを魅力なし個数0で初期化する
            for (int i = 0; i < raw.Length; i++)
            {
                ToRawAttraction(Attraction.なし, 0, ref raw[i]);
            }

            // 魅力と個数の辞書を作成する
            // なしは入力しないので無視する
            var attractionCount = new OrderedDictionary();
            foreach (var attraction in attractions)
            {
                if (attraction == Attraction.なし)
                {
                    continue;
                }
                else if (!attractionCount.Contains(attraction))
                {
                    attractionCount.Add(attraction, (ushort)1);
                }
                else
                {
                    var count = attractionCount[attraction];
                    Debug.Assert(count is not null);
                    attractionCount[attraction] = (ushort)((ushort)count + 1);
                }
            }

            // View上で魅力を「なし・重撃・なし」という形で設定しても
            // セーブデータでは「重撃・なし・なし」と設定される
            // 特に問題ないと判断して対処は見送り
            for (int i = 0; i < attractionCount.Count; i++)
            {
                var attraction_and_count = attractionCount.Cast<DictionaryEntry>().ElementAt(i);
                var attraction = (Attraction)attraction_and_count.Key;
                var count = attraction_and_count.Value;
                Debug.Assert(count is not null);
                ToRawAttraction(attraction, (ushort)count, ref raw[i]);
            }
        }

        static void ToRawAttraction(Attraction attraction, ushort num, ref RawAttraction raw)
        {
            Array.Copy(BitConverter.GetBytes((ushort)attraction), raw.Attraction, raw.Attraction.Length);
            Array.Copy(BitConverter.GetBytes(num), raw.Num, raw.Num.Length);
        }
    }
}
