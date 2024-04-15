using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    class Weapon(
        string name = "",
        ushort durability = 0,
        ushort MaxDurability = 0,
        Yaiba yaiba = Yaiba.なし,
        Tsuba tsuba = Tsuba.なし,
        Tsuka tsuka = Tsuka.なし)
    {
        const ushort GameMaxDurability = 2000;

        public IEnumerable<Yaiba> YaibaList { get; private set; } = Enum.GetValues<Yaiba>();
        public IEnumerable<Tsuba> TsubaList { get; private set; } = Enum.GetValues<Tsuba>();
        public IEnumerable<Tsuka> TsukaList { get; private set; } = Enum.GetValues<Tsuka>();
        public IEnumerable<Mei> MeiList { get; private set; } = Enum.GetValues<Mei>();
        public IEnumerable<Attraction> AttractionList { get; private set; } = Enum.GetValues<Attraction>();

        // 17文字+終端文字
        public string Name
        {
            get { return _name; }
            set
            {
                const int MaxNameLength = 31;
                if (IsOriginal && value.Length <= MaxNameLength)
                {
                    _name = value;
                }
            }
        }
        public ushort Attack
        {
            get { return _attack; }
            set
            {
                const ushort GameMaxAttack = 2000;
                if (value > GameMaxAttack)
                {
                    _attack = GameMaxAttack;
                }
                else
                {
                    _attack = value;
                }
            }
        }

        public ushort Durability
        {
            get { return _durability; }
            set
            {
                if (value > MaxDurability)
                {
                    _durability = MaxDurability;
                }
                else
                {
                    _durability = value;
                }
            }
        }

        public ushort MaxDurability
        {
            get { return _maxDurability; }
            set
            {
                if (value > GameMaxDurability)
                {
                    _maxDurability = GameMaxDurability;
                }
                else
                {
                    _maxDurability = value;
                }
            }
        }

        public uint Quality { get; set; }
        public uint MaxQuality { get; set; }
        public bool IsOriginal { get; set; } = false;
        public Yaiba Yaiba
        {
            get { return _yaiba; }
            set
            {
                if (IsOriginal)
                {
                    _yaiba = value;
                }
            }
        }

        public Tsuba Tsuba
        {
            get { return _tsuba; }
            set
            {
                if (IsOriginal)
                {
                    _tsuba = value;
                }
            }
        }

        public Tsuka Tsuka
        {
            get { return _tsuka; }
            set
            {
                if (IsOriginal)
                {
                    _tsuka = value;
                }
            }
        }

        public Mei Mei { get; set; }
        public uint KillCount { get; set; }
        public uint TsumagiriCount { get; set; }
        public uint TotalRecoveredDurability {  get; set; }

        public Attraction[] Attractions
        {
            get { return _attractions; }
            set
            {
                Debug.Assert(value.Length == 3);
                _attractions = value;
            }
        }

        string _name = name;
        ushort _attack;
        ushort _durability = durability;
        ushort _maxDurability = MaxDurability;
        Yaiba _yaiba = yaiba;
        Tsuba _tsuba = tsuba;
        Tsuka _tsuka = tsuka;
        Attraction[] _attractions = [Attraction.なし, Attraction.なし, Attraction.なし,];
    }
}
