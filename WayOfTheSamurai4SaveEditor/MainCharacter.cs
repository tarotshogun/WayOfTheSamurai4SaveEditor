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

        // 最大31文字
        public string Name { get; set; }
        public int Day { get; }
        public int Time { get; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Katsuryoku { get; set; }
        public int MaxKatsuryoku { get; set; }
        // 最大99999
        public uint Money { get; set; }
    }
}
