using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WayOfTheSamurai4SaveEditor
{
    public class SaveData
    {
        public ObservableCollection<MainCharacter> MainCharacters { get; set; }
        public ObservableCollection<Weapon> Taitou {  get; set; }
        public ObservableCollection<Weapon> BukiBukuro { get; set; }
        public ObservableCollection<Weapon> BukiDansu { get; set; }

        public SaveData()
        {
            MainCharacters = [];
            Taitou = [];
            BukiBukuro = [];
            BukiDansu = [];
        }

        public SaveData Load(string path)
        {
            var data = SaveDataLoader.Load(path);
            MainCharacters = data.MainCharacters;

            MainCharacters.Add(new MainCharacter() { Name = "名無し侍" });

            for (int i = 0; i < 3; i++)
            {
                Taitou.Add(new Weapon("なまくら刀"));
            }

            for (int i = 0; i < 10; i++)
            {
                BukiBukuro.Add(new Weapon("なまくら刀"));
            }

            for (int i = 0; i < 100; i++)
            {
                BukiDansu.Add(new Weapon("なまくら刀"));
            }
            return this;
        }
    }
}
