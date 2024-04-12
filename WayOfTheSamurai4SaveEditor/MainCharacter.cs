using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class MainCharacter
    {
        public MainCharacter() { Name = ""; }

        public string Name { get; set; }
        public int Day { get; set; }
        public int Time { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Katsuryoku { get; set; }
        public int MaxKatsuryoku { get; set; }
        public int Money { get; set; }
    }
}
