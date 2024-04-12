using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    static class SaveDataLoader
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RawSaveData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Padding0000;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Money;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Padding000A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0010;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0020;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0030;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0040;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0050;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0060;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0070;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0080;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding0090;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding00A0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding00B0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Padding00C0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] Padding00D0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]  // UTF-16で31文字分の文字列+終端文字
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Padding011C;

        }

        public static SaveData Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            var raw = new RawSaveData();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream))
                {
                    var structSize = Marshal.SizeOf(typeof(RawSaveData));
                    // 領域をアロケートする
                    var hglobal = Marshal.AllocHGlobal(structSize);
                    // ファイルからデータを読み込む
                    byte[] bytes = reader.ReadBytes(structSize);
                    // 読み込んだデータをアロケーションした領域にコピーする
                    Marshal.Copy(bytes, 0, hglobal, structSize);
                    // 構造体にマーシャリングする
                    raw = (RawSaveData)Marshal.PtrToStructure<RawSaveData>(hglobal);
                    // アンマネージメモリ解放
                    Marshal.FreeHGlobal(hglobal);
                }
            }

            var data = new SaveData();

            string name = Encoding.Unicode.GetString(raw.Name).TrimEnd('\0');
            uint money = BitConverter.ToUInt16(raw.Money);
            data.MainCharacters.Clear();
            data.MainCharacters.Add(new MainCharacter() { Name = name, Money = money });

            for (int i = 0; i < 3; i++)
            {
                data.Taitou.Add(new Weapon("なまくら刀"));
            }

            for (int i = 0; i < 10; i++)
            {
                data.BukiBukuro.Add(new Weapon("なまくら刀"));
            }

            for (int i = 0; i < 100; i++)
            {
                data.BukiDansu.Add(new Weapon("なまくら刀"));
            }
            return data;
        }
    }
}
