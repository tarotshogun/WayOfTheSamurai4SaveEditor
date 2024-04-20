using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WayOfTheSamurai4SaveEditor.Models.SaveData
{
    [TypeConverter(typeof(EnumDisplayTypeConverter))]
    public enum RareItemId : ushort
    {
        [Description("くず鉄")]
        Kuzutetsu = 0x0029,
        [Description("卸し鉄")]
        Oroshigane = 0x002A,
        [Description("堂島鋼")]
        Doujimahagane = 0x002B,
        [Description("緋緋色金")]
        Hihiirokane = 0x002C,
        [Description("")]
        None = 0xFFFF,
    }

    class RareItem
    {
        public IEnumerable<RareItemId> ItemIdList { get; private set; } = Enum.GetValues<RareItemId>();

        public RareItemId Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged();
                if (value == RareItemId.None)
                {
                    // なぜかUIにはCountの変更が反映されない
                    Count = 0;
                }
            }
        }

        public ushort Count
        {
            get { return _count; }
            set
            {
                const ushort MaxRareItemCount = 99;
                if (Id != RareItemId.None)
                {
                    _count = value > MaxRareItemCount ? MaxRareItemCount : value;
                }
                else
                {
                    _count = 0;
                }
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private RareItemId _id = RareItemId.None;
        private ushort _count = 0;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
