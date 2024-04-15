using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
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
            Array.Copy(BitConverter.GetBytes(weapon.TotalRecoveredDurability), raw.TotalRecoveredDurability, raw.TotalRecoveredDurability.Length);
            // Delete magic number and define constant value
            Array.Copy(BitConverter.GetBytes((uint)weapon.Yaiba), raw.Yaiba, 3);
            Array.Copy(BitConverter.GetBytes((uint)weapon.Tsuba), raw.Tsuba, 3);
            Array.Copy(BitConverter.GetBytes((ushort)weapon.Tsuka), raw.Tsuka, raw.Tsuka.Length);
            Array.Copy(BitConverter.GetBytes((uint)weapon.Mei), raw.Mei, raw.Mei.Length);
        }

    }
}
