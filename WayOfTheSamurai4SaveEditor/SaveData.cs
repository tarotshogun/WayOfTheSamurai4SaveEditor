using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    public class SaveData
    {
        public ObservableCollection<MainCharacter> MainCharacters;
        public ObservableCollection<Weapon> Taitou;
        public ObservableCollection<Weapon> BukiBukuro;
        public ObservableCollection<Weapon> BukiDansu;

        private string _path;

        public SaveData()
        {
            MainCharacters = new ObservableCollection<MainCharacter>();
            Taitou = new ObservableCollection<Weapon>();
            BukiBukuro = new ObservableCollection<Weapon>();
            BukiDansu = new ObservableCollection<Weapon>();
        }

        public SaveData Load()
        {
            MainCharacters.Add(new MainCharacter() { Name = "近藤勇" });
            MainCharacters.Add(new MainCharacter() { Name = "土方歳三" });

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
