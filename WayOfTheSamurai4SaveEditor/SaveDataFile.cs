using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WayOfTheSamurai4SaveEditor
{
    public class SaveDataFile
    {
        public ObservableCollection<MainCharacter> MainCharacters { get; set; } = [];
        public ObservableCollection<Weapon> Taitou { get; set; } = [];
        public ObservableCollection<Weapon> BukiBukuro { get; set; } = [];
        public ObservableCollection<Weapon> BukiDansu { get; set; } = [];
        public string Path { get; private set; } = "";
        
        private RawSaveData _raw = new();

        public SaveDataFile(string path)
        {
            Read(path);
            Path = path;
        }

        void Read(string path)
        {
            _raw = SaveDataAccessor.Load(path);
            MainCharacters = MainCharacterConverter.ToMainCharacters(_raw);
            BukiDansu = WeaponConverter.ToWeapons(_raw.BukiDansu);
        }

        public void Write()
        {
            Write(Path);
        }

        public void Write(string path)
        {
            MainCharacterConverter.ToRawMainCharacter(MainCharacters[0], ref _raw);
            WeaponConverter.ToRawBukiDansuWeapons(BukiDansu, ref _raw.BukiDansu);
            SaveDataAccessor.Save(path, _raw);
        }
    }
}