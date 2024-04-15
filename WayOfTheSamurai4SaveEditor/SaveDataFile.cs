using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;

namespace WayOfTheSamurai4SaveEditor
{
    class SaveDataFile
    {
        public ObservableCollection<MainCharacter> MainCharacters { get; set; } = [];
        public ObservableCollection<Weapon> CarriedWeapons { get; set; } = [];
        public ObservableCollection<Weapon> BaggedWeapons { get; set; } = [];
        public ObservableCollection<Weapon> CabinetWeapons { get; set; } = [];
        public ObservableCollection<Ryuha> Ryuha { get; set; } = [];
        public string Path { get; private set; } = "";
        
        private RawSaveData _raw = new();

        public SaveDataFile(string path)
        {
            Read(path);
        }

        void Read(string path)
        {
            _raw = SaveDataAccessor.Load(path);
            MainCharacters = MainCharacterConverter.ToMainCharacters(_raw);
            CabinetWeapons = WeaponConverter.ToWeapons(_raw.CabinetWeapons);
            Ryuha = RyuhaConverter.ToRyuha(_raw.MyRyuhaName);
            Path = path;
        }

        public void Write()
        {
            Write(Path);
        }

        public void Write(string path)
        {
            MainCharacterConverter.ToRawMainCharacter(MainCharacters[0], ref _raw);
            WeaponConverter.ToRawCabinetWeapons(CabinetWeapons, ref _raw.CabinetWeapons);
            RyuhaConverter.ToRawMyRyuhaName(Ryuha, ref _raw.MyRyuhaName);
            SaveDataAccessor.Save(path, _raw);
            Path = path;
        }
    }
}