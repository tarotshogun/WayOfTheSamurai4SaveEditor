using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class Weapon(
        string name = "",
        ushort durability = 0,
        ushort MaxDurability = 0,
        YaibaMaterial yaiba = YaibaMaterial.無,
        TsubaMaterial tsuba = TsubaMaterial.無,
        TsukaMaterial tsuka = TsukaMaterial.無)
    {
        const ushort GameMaxDurability = 2000;

        public IEnumerable<YaibaMaterial> YaibaList { get; private set; } = Enum.GetValues<YaibaMaterial>();
        public IEnumerable<TsubaMaterial> TsubaList { get; private set; } = Enum.GetValues<TsubaMaterial>();
        public IEnumerable<TsukaMaterial> TsukaList { get; private set; } = Enum.GetValues<TsukaMaterial>();
        public IEnumerable<Mei> MeiList { get; private set; } = Enum.GetValues<Mei>();

        // 17文字+終端文字
        public string Name
        {
            get { return _name; }
            set
            {
                if (IsOriginal)
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
        public YaibaMaterial Yaiba
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

        public TsubaMaterial Tsuba
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

        public TsukaMaterial Tsuka
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
        public uint TotalRecoveredDurability {  get; set; } 

        private string _name = name;
        private ushort _attack;
        private ushort _durability = durability;
        private ushort _maxDurability = MaxDurability;
        private YaibaMaterial _yaiba = yaiba;
        private TsubaMaterial _tsuba = tsuba;
        private TsukaMaterial _tsuka = tsuka;
    }
}
