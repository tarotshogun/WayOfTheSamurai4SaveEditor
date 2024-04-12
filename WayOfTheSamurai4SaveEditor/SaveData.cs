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

        public SaveData() {
            MainCharacters = new ObservableCollection<MainCharacter>();
            Taitou = new ObservableCollection<Weapon>();
            BukiBukuro = new ObservableCollection<Weapon>();
            BukiDansu = new ObservableCollection<Weapon>();
        }

        public SaveData Load()
        {
            MainCharacters.Add(new MainCharacter() { Name = "近藤勇" });
            MainCharacters.Add(new MainCharacter() { Name = "土方歳三" });

            Taitou.Add(new Weapon() { });
            return this;
        }
    }
}
