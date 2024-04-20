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
        public static ObservableCollection<Item> ToItems(RawRareItem[] raw)
        {
            var items = new ObservableCollection<Item>();

            for(int i = 0; i < raw.Length; ++i )
            {
                var rawRareItem = raw[i];
                var id = ToUInt16Enum<ItemId>(rawRareItem.Id);
                var count = BitConverter.ToUInt16(rawRareItem.Count);
                items.Add(new Item() { Id = id, Count = count });
            }

            return items;
        }

        public static void ToRawItems(ObservableCollection<Item> items, ref RawRareItem[] raw)
        {
            for (int i = 0; i < raw.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes((ushort)items[i].Id), raw[i].Id, raw[i].Id.Length);
                Array.Copy(BitConverter.GetBytes(items[i].Count), raw[i].Count, raw[i].Count.Length);
            }
        }
    }
}
