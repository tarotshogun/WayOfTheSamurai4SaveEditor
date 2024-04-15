using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
解析メモ

B3C uint8 侍点

35A8 float 体力 9999が最大（461C3C00）
35A4 float 活力 9999が最大（461C3C00）

5B90 ~ 貴重品
0029XXXX 0029がくず鉄でXXXXが個数
002AXXXX 0029が卸し金でXXXXが個数
002BXXXX 0029が堂島鋼でXXXXが個数
002CXXXX 0029が緋緋色金でXXXXが個数
*/

namespace WayOfTheSamurai4SaveEditor
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawSaveData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Padding0000_0007;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Money;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Cashbox;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 192)] // 16 * 12 lines
        public byte[] Padding0010_00CF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] Padding00D0_00DB;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Padding011C_011F;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2576)]
        public byte[] Padding0120_0B2F;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] Padding0B30_0B3B;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SamuraiPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10848)] 
        public byte[] Padding0B40_359F;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Padding35A0_35A4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Katsuryoku;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Hp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Padding35AC_35AF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30512)]
        public byte[] Padding35B0_ACDF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] PaddingACE0_ACED;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)] // 武器箪笥四まで解放したときの値
        public RawCabinetWeapon[] CabinetWeapons;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] // 武器1つで10行進むので200*16bytes*10lines
        public byte[] Padding129AE_B9AF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 221632)]
        public byte[] PaddingB9B0_;
    }

    // メンバ変数の名前は武器箪笥最初の武器のアドレスを参照
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawCabinetWeapon
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] PaddingACEE_ACF3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] WeaponId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Yaiba;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Tsuba;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Tsuka;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] UniqueWeaponId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Attack;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MaxDurability;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Quality;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MaxQuality;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] PaddingAD0C_AD11; // 魅力のヘッダ？違いそう
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public RawAttraction[] Attractions;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]  // 実際は17文字までしか入力できないようです
        public byte[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public byte[] PaddingAD5E_AD73;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] PaddingAD74_AD77; // つま斬り数1?
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] PaddingAD78_AD7B; // つま斬り数2?
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TotalRecoveredDurability;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Durability;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PaddingAD82_AD83;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Mei;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] PaddingAD87_AD89;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] KillCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PaddingAD8C_AD8D;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawAttraction
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Attraction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Num;
    }
}
