using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class MainCharacter
    {
        public string Name
        {
            get { return _name; }
            set {
                const int MaxNameLength = 31;
                if (value.Length > MaxNameLength)
                {
                    _name = value[..MaxNameLength];
                } 
                else
                {
                    _name = value;
                }
            }
        }

        public uint Money
        {
            get { return _money; }
            set
            {
                const uint MaxMoney = 99999;
                if (value > MaxMoney)
                {
                    _money = MaxMoney;
                }
                else
                {
                    _money = value;
                }
            }
        }

        public uint Cashbox
        {
            get { return _cashbox; }
            set
            {
                const uint MaxCashbox = 999999;
                if (value > MaxCashbox)
                {
                    _cashbox = MaxCashbox;
                }
                else
                {
                    _cashbox = value;
                }
            }
        }

        public float MaxHp { get; set; }
        public float Hp { get; set; }
        public float Katsuryoku { get; set; }
        public float MaxKatsuryoku { get; set; }

        string _name = "";
        uint _money = 0;
        uint _cashbox= 0;
    }
}
