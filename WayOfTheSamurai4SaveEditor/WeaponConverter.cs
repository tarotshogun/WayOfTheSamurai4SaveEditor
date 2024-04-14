using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WayOfTheSamurai4SaveEditor
{
    public static class WeaponConverter
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
            // TODO: Delete the magic number
            Array.Copy(Encoding.Unicode.GetBytes(weapon.Name), raw.Name, 64);
        }

        static Weapon ToWeapon(ref readonly RawCabinetWeapon raw)
        {
            string name = Encoding.Unicode.GetString(raw.Name);
            if (name.Equals(""))
            {
                return new Weapon();
            }

            var attack = BitConverter.ToUInt16(raw.Attack);
            var weaponId = BitConverter.ToUInt16(raw.WeaponId);
            var uniqueId = BitConverter.ToUInt64(
                [raw.UniqueWeaponId[0], raw.UniqueWeaponId[1], raw.UniqueWeaponId[2],
                raw.UniqueWeaponId[3], raw.UniqueWeaponId[4], raw.UniqueWeaponId[5], 0x00, 0x00]
            );
            var durability = BitConverter.ToUInt16(raw.Durability);
            var maxDurability = BitConverter.ToUInt16(raw.MaxDurability);
            var quality = BitConverter.ToUInt16(raw.Quality);
            var maxQuality = BitConverter.ToUInt16(raw.MaxQuality);
            var killCount = BitConverter.ToUInt16(raw.KillCount);
            var totalRecoveredDurability = BitConverter.ToUInt32(raw.TotalRecoveredDurability);
            var yaiba = ToEnum<YaibaMaterial>(raw.Yaiba);
            var tsuba = ToEnum<TsubaMaterial>(raw.Tsuba);
            var tsuka = ToTsukaMaterial(raw.Tsuka);
            var mei = ToEnum<Mei>(raw.Mei);

            Debug.Write(string.Format("[0x{0:X2}:{1:X}] ", weaponId, name));
            Debug.Write(string.Format("unique: 0x{0:X2} ", uniqueId));
            Debug.Write(string.Format("materials: 0x{0:X8} 0x{1:X8} 0x{2:X4} ",
                ToUInt32(raw.Yaiba), ToUInt32(raw.Tsuba), BitConverter.ToUInt16(raw.Tsuka)));
            Debug.Write(string.Format("mei: 0x{0:X8} ", ToUInt32(raw.Mei)));
            Debug.WriteLine("");

            return new Weapon(name,durability, maxDurability, yaiba, tsuba, tsuka)
            {
                Attack = attack,
                IsOriginal = (weaponId == 0xFFFF),
                Quality = quality,
                MaxQuality = maxQuality,
                KillCount = killCount,
                Mei = mei,
                TotalRecoveredDurability = totalRecoveredDurability,
            };
        }

        static uint ToUInt32(byte[] raw)
        {
            // ToUInt32は少なくとも4byteのバイト列を必要とするため、リサイズする
            Debug.Assert(raw.Length < 4);
            byte[] extendedRaw = new byte[4];
            Array.Copy(raw, extendedRaw, raw.Length);

            return BitConverter.ToUInt32(extendedRaw);
        }

        static T ToEnum<T>(byte[] raw) where T : Enum
        {
            var value = ToUInt32(raw);
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)(object)value;
            }
            else
            {
                const string defaultValue = "無";
                Debug.Assert(Enum.GetNames(typeof(T)).Contains(defaultValue));
                return (T)Enum.Parse(typeof(T), "無");
            }
        }


        static TsukaMaterial ToTsukaMaterial(byte[] raw)
        {
            var tsuka = BitConverter.ToUInt16(raw);
            if (Enum.IsDefined(typeof(TsukaMaterial), tsuka))
            {
                return (TsukaMaterial)tsuka;
            }
            else
            {
                return TsukaMaterial.無;
            }
        }
    }
}
