using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayOfTheSamurai4SaveEditor.Models.RawData;
using WayOfTheSamurai4SaveEditor.Models.SaveData;

namespace WayOfTheSamurai4SaveEditor.Models.SaveDataConversion
{
    static partial class SaveDataConverter
    {
        // バイナリから推察するに最大10個までの貴重品が格納できるが、
        // 実際には製錬用の鉄4種しか格納されないので最低限の容量をコピーする
        const int RareItemTypeCount = 4;

        public static ObservableCollection<RareItem> ToRareItems(RawRareItem[] raw)
        {
            var rareItems = new ObservableCollection<RareItem>();

            for(int i = 0; i < RareItemTypeCount; ++i )
            {
                var rawRareItem = raw[i];
                var id = ToUInt16Enum<RareItemId>(rawRareItem.Id);
                var count = BitConverter.ToUInt16(rawRareItem.Count);
                rareItems.Add(new RareItem() { Id = id, Count = count });
            }

            return rareItems;
        }

        public static void ToRawRareItems(ObservableCollection<RareItem> rareItems, ref RawRareItem[] raw)
        {
            for (int i = 0; i < RareItemTypeCount; i++)
            {
                Array.Copy(BitConverter.GetBytes((ushort)rareItems[i].Id), raw[i].Id, raw[i].Id.Length);
                Array.Copy(BitConverter.GetBytes(rareItems[i].Count), raw[i].Count, raw[i].Count.Length);
            }
        }

        // 別の個所に同一関数があるので統一する
        static T ToUInt16Enum<T>(byte[] raw) where T : Enum
        {
            var value = BitConverter.ToUInt16(raw);
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

    }
}
