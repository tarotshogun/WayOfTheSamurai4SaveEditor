using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class Weapon
    {
        private string _name;
        private int _attack;
        private bool _isDefault;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!_isDefault)
                {
                    _name = value;
                }
            }
        }
        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public int Taikyu { get; set; }
        public int MaxTaikyu { get; set; }
        public bool IsDefault
        {
            get { return _isDefault; }
        }
        public int Yaiba { get; }
        public int Tsuba { get; }
        public int Tsuka { get; }
        public int Zansatsu { get; set; }

        public Weapon(string name = "")
        {
            _name = name;
            _isDefault = true;
        }
    }
}
