using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WayOfTheSamurai4SaveEditor
{
    public class SaveDataViewModel
    {
        public ObservableCollection<MainCharacter> MainCharacters { get; set; }
        public ObservableCollection<Weapon> Taitou {  get; set; }
        public ObservableCollection<Weapon> BukiBukuro { get; set; }
        public ObservableCollection<Weapon> BukiDansu { get; set; }

        public SaveDataViewModel()
        {
            MainCharacters = [];
            Taitou = [];
            BukiBukuro = [];
            BukiDansu = [];
        }
    }
}
