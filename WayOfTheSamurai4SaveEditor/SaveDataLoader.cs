using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WayOfTheSamurai4SaveEditor
{
    static class SaveDataLoader
    {
        public static SaveData Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            var raw = new RawSaveData();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                using var reader = new BinaryReader(stream);
                var structSize = Marshal.SizeOf(typeof(RawSaveData));
                // 領域をアロケートする
                var hglobal = Marshal.AllocHGlobal(structSize);
                // ファイルからデータを読み込む
                byte[] bytes = reader.ReadBytes(structSize);
                // 読み込んだデータをアロケーションした領域にコピーする
                Marshal.Copy(bytes, 0, hglobal, structSize);
                // 構造体にマーシャリングする
                raw = Marshal.PtrToStructure<RawSaveData>(hglobal);
                // アンマネージメモリ解放
                Marshal.FreeHGlobal(hglobal);
            }

            var data = new SaveData
            {
                MainCharacters = MainCharacterConverter.ToMainCharacters(ref raw),
                BukiDansu = WeaponConverter.ToWeapons(ref raw.BukiDansu),
            };
            return data;
        }
    }
}
