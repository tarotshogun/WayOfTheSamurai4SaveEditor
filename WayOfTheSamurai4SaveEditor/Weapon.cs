using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class Weapon(string name = "")
    {
        public IEnumerable<YaibaMaterial> YaibaList { get; private set; } = Enum.GetValues<YaibaMaterial>();
        public IEnumerable<YaibaMaterial> TsubaList { get; private set; } = Enum.GetValues<YaibaMaterial>();
        public IEnumerable<YaibaMaterial> TsukaList { get; private set; } = Enum.GetValues<YaibaMaterial>();

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
        public uint Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public uint Taikyu { get; set; }
        public uint MaxTaikyu { get; set; }
        public uint Shitsu { get; set; }
        public uint MaxShitsu { get; set; }
        public bool IsOriginal { get; set; } = false;
        public YaibaMaterial Yaiba { get; set; }
        public TsubaMaterial Tsuba { get; set; }
        public TsukaMaterial Tsuka { get; set; }
        public uint Zansatsu { get; set; }

        private string _name = name;
        private uint _attack;
    }
}
