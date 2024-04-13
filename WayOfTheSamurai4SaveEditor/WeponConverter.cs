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
        static uint ToUInt32(byte[] raw)
        {
            Debug.Assert(raw.Length < 4);

            // ToUInt32は少なくとも4byteのバイト列を必要とするため、値をコピーする
            byte[] extendedRaw = new byte[4];
            Array.Copy(raw, extendedRaw, raw.Length);

            return BitConverter.ToUInt32(extendedRaw);
        }

        static YaibaMaterial ToYaibaMaterial(byte[] raw)
        {
            var yaiba = ToUInt32(raw);
            if (Enum.IsDefined(typeof(YaibaMaterial), yaiba))
            {
                return (YaibaMaterial)yaiba;
            }
            else
            {
                return YaibaMaterial.無;
            }
        }
        static TsubaMaterial ToTsubaMaterial(byte[] raw)
        {
            var tsuba = ToUInt32(raw);
            if (Enum.IsDefined(typeof(TsubaMaterial), tsuba))
            {
                return (TsubaMaterial)tsuba;
            }
            else
            {
                return TsubaMaterial.無;
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

        static Weapon ToWepon(ref readonly RawBukiDansuWeapons raw)
        {
            string name = Encoding.Unicode.GetString(raw.Name).TrimEnd('\0');
            if (name.Equals(""))
            {
                return new Weapon();
            }

            var attack = BitConverter.ToUInt16(raw.Attack);
            var weponId = BitConverter.ToUInt16(raw.WeaponId);
            var uniqueId = BitConverter.ToUInt64(
                [raw.UniqueWeponId[0], raw.UniqueWeponId[1], raw.UniqueWeponId[2], 
                raw.UniqueWeponId[3], raw.UniqueWeponId[4], raw.UniqueWeponId[5], 0x00, 0x00]
            );
            var taikyu = BitConverter.ToUInt16(raw.Taikyu);
            var maxTaikyu = BitConverter.ToUInt16(raw.MaxTaikyu);
            var shitsu = BitConverter.ToUInt16(raw.Shitsu);
            var maxShitsu = BitConverter.ToUInt16(raw.MaxShitsu);
            var zansatsu = BitConverter.ToUInt16(raw.NumZansatsu);
            var yaiba = ToYaibaMaterial(raw.Yaiba);
            var tsuba = ToTsubaMaterial(raw.Tsuba);
            var tsuka = ToTsukaMaterial(raw.Tsuka);

            Debug.WriteLine(
                string.Format("[0x{0:X2}:{1:X}] unique:{2:X6} material: 0x{3:X2} 0x{4:X3} 0x{5:X4}",
                weponId, name, uniqueId, ToUInt32(raw.Yaiba), ToUInt32(raw.Tsuba), BitConverter.ToUInt16(raw.Tsuka)));

            return new Weapon(name)
            {
                Attack = attack,
                IsOriginal = (weponId == 0xFFFF),
                Taikyu = taikyu,
                MaxTaikyu = maxTaikyu,
                Shitsu = shitsu,
                MaxShitsu = maxShitsu,
                Zansatsu = zansatsu,
                Yaiba = yaiba,
                Tsuba = tsuba,
                Tsuka = tsuka,
            };
        }

        public static ObservableCollection<Weapon> ToWeapons(ref readonly RawBukiDansuWeapons[] raw)
        {
            var weapons = new ObservableCollection<Weapon>();
            foreach (var weapon in raw)
            {
                weapons.Add(ToWepon(in weapon));
            }
            return weapons;
        }
    }
}
