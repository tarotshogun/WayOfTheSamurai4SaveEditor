using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WayOfTheSamurai4SaveEditor
{
    // メンバ変数の名前は武器箪笥最初の武器のアドレスを参照
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawBukiDansuWeapon
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
        public byte[] UniqueWeponId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Attack;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MaxDurability;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Quality;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MaxQuality;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] PaddingAD0C_AD11; // 魅力のヘッダ？
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Miryoku1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] NumMiryoku1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Miryoku2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] NumMiryoku2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Miryoku3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] NumMiryoku3;
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]  // UTF-16で31文字分の文字列+終端文字
        public byte[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Padding011C;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 43968)]
        public byte[] Padding0120_ACDF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] PaddingACE0_ACDF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)] // 武器箪笥四まで解放したときの値
        public RawBukiDansuWeapon[] BukiDansu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 221634)]
        public byte[] Padding;
    }
}
