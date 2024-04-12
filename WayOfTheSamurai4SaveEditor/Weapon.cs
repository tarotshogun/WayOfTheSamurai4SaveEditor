using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Attack{ get; set; }
        public int Taikyu{ get; set; }
        public int MaxTaikyu{ get; set; }
        public bool IsDefault { get; }
        public int Yaiba{ get; }
        public int Tsuba { get; }
        public int Tsuka { get; }
        public int Zansatsu { get; set; }

        public Weapon()
        {
            Name = "";
        }
    }
}
