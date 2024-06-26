﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor.Models.SaveData
{
    class Ryuha(string name)
    {
        public string Name
        {
            get { return _name; }
            set
            {
                const int MaxNameLength = 9;
                if (value.Length > MaxNameLength)
                {
                    _name = value[..MaxNameLength];
                }
            }
        }

        string _name = name;
    }
}
