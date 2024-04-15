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
    static partial class WeaponConverter
    {
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
            var yaiba = ToUInt32Enum<Yaiba>(To4Bytes(raw.Yaiba));
            var tsuba = ToUInt32Enum<Tsuba>(To4Bytes(raw.Tsuba));
            var tsuka = ToTsuka(raw.Tsuka);
            var mei = ToUInt32Enum<Mei>(To4Bytes(raw.Mei));
            var attractions = ToAttractions(raw.attractions);

            Debug.Write(string.Format("[0x{0:X2}:{1:X}] ", weaponId, name));
            Debug.Write(string.Format("unique: 0x{0:X2} ", uniqueId));
            Debug.Write(string.Format("materials: 0x{0:X8} 0x{1:X8} 0x{2:X4} ",
                BitConverter.ToUInt32(To4Bytes(raw.Yaiba)),
                BitConverter.ToUInt32(To4Bytes(raw.Tsuba)), 
                BitConverter.ToUInt16(raw.Tsuka)));
            Debug.Write(string.Format("mei: 0x{0:X8} ", BitConverter.ToUInt32(To4Bytes(raw.Mei))));
            Debug.WriteLine("");

            return new Weapon(name, durability, maxDurability, yaiba, tsuba, tsuka)
            {
                Attack = attack,
                IsOriginal = (weaponId == 0xFFFF),
                Quality = quality,
                MaxQuality = maxQuality,
                KillCount = killCount,
                Mei = mei,
                TotalRecoveredDurability = totalRecoveredDurability,
                Attractions = attractions,
            };
        }

        static Tsuka ToTsuka(byte[] raw)
        {
            var tsuka = BitConverter.ToUInt16(raw);
            if (Enum.IsDefined(typeof(Tsuka), tsuka))
            {
                return (Tsuka)tsuka;
            }
            else
            {
                return Tsuka.なし;
            }
        }

        static Attraction[] ToAttractions(RawAttraction[] raw)
        {
            const int MaxAttractionCount = 3;  // 一つの刀あたりの最大の魅力の数
            var attractions = new List<Attraction>(MaxAttractionCount);

            foreach (var rawAttraction in raw)
            {
                var attraction = ToAttraction(rawAttraction);
                for(int i = 0; i < attraction.num; ++i)
                {
                    Debug.Assert(attraction.attraction != Attraction.なし);
                    if(attraction.attraction != Attraction.なし && attractions.Count < MaxAttractionCount)
                    {
                        attractions.Add(attraction.attraction);
                    }
                }
            }

            // 配列の未設定部分に魅力「なし」を追加する
            while (attractions.Count < MaxAttractionCount)
            {
                attractions.Add(Attraction.なし);
            }

            return [.. attractions];
        }

        static (Attraction attraction, uint num) ToAttraction(RawAttraction raw)
        {
            var attraction = ToUInt16Enum<Attraction>(raw.Attraction);
            var num = BitConverter.ToUInt16(raw.Num);
            return (attraction, num);
        }

        static byte[] To4Bytes(byte[] raw)
        {
            const uint ByteSize = 4;
            Debug.Assert(raw.Length < ByteSize);
            var extended = new byte[ByteSize];
            Array.Copy(raw, extended, raw.Length);
            return extended;
        }

        static T ToUInt32Enum<T>(byte[] raw) where T : Enum
        {
            var value = BitConverter.ToUInt32(raw);
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)(object)value;
            }
            else
            {
                const string defaultValue = "なし";
                Debug.Assert(Enum.GetNames(typeof(T)).Contains(defaultValue));
                return (T)Enum.Parse(typeof(T), "なし");
            }
        }

        static T ToUInt16Enum<T>(byte[] raw) where T : Enum
        {
            var value = BitConverter.ToUInt16(raw);
            if (Enum.IsDefined(typeof(Attraction), value))
            {
                return (T)(object)value;
            }
            else
            {
                const string defaultValue = "なし";
                Debug.Assert(Enum.GetNames(typeof(T)).Contains(defaultValue));
                return (T)Enum.Parse(typeof(T), "なし");
            }
        }
    }
}
