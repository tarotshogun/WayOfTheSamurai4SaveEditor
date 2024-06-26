﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;
using WayOfTheSamurai4SaveEditor.Models.SaveDataConversion;
using WayOfTheSamurai4SaveEditor.Models.SaveDataFileIO;
using WayOfTheSamurai4SaveEditor.Models.RawData;
using WayOfTheSamurai4SaveEditor.Models.SaveData;

namespace WayOfTheSamurai4SaveEditor.Models
{
    class SaveDataFile
    {
        public ObservableCollection<MainCharacter> MainCharacters { get; set; } = [];
        public ObservableCollection<Weapon> CarriedWeapons { get; set; } = [];
        public ObservableCollection<Weapon> BaggedWeapons { get; set; } = [];
        public ObservableCollection<Weapon> CabinetWeapons { get; set; } = [];
        public ObservableCollection<Item> CarriedItems { get; set; } = [];
        public ObservableCollection<Item> CabinetItems { get; set; } = [];
        public ObservableCollection<RareItem> RareItems { get; set; } = [];
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
            CarriedWeapons = WeaponConverter.ToWeapons(_raw.CarriedWeapons);
            BaggedWeapons = WeaponConverter.ToWeapons(_raw.BaggedWeapons);
            CabinetWeapons = WeaponConverter.ToWeapons(_raw.CabinetWeapons);
            CarriedItems = SaveDataConverter.ToItems(_raw.CarriedItems);
            CabinetItems = SaveDataConverter.ToItems(_raw.CabinetItems);
            RareItems = SaveDataConverter.ToRareItems(_raw.RareItems);
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
            WeaponConverter.ToRawWeapons(CarriedWeapons, ref _raw.CarriedWeapons);
            WeaponConverter.ToRawWeapons(BaggedWeapons, ref _raw.BaggedWeapons);
            WeaponConverter.ToRawWeapons(CabinetWeapons, ref _raw.CabinetWeapons);
            RyuhaConverter.ToRawMyRyuhaName(Ryuha, ref _raw.MyRyuhaName);
            SaveDataConverter.ToRawItems(CarriedItems, ref _raw.CarriedItems);
            SaveDataConverter.ToRawItems(CabinetItems, ref _raw.CabinetItems);
            SaveDataConverter.ToRawRareItems(RareItems, ref _raw.RareItems);
            SaveDataAccessor.Save(path, _raw);
            Path = path;
        }
    }
}