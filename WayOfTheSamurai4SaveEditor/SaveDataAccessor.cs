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
    class SaveDataAccessor
    {
        public static RawSaveData Load(string path)
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
                var hglobal = Marshal.AllocHGlobal(structSize);
                try
                {
                    byte[] bytes = reader.ReadBytes(structSize);
                    Marshal.Copy(bytes, 0, hglobal, structSize);
                    raw = Marshal.PtrToStructure<RawSaveData>(hglobal);
                }
                finally
                {
                    Marshal.FreeHGlobal(hglobal);
                }
            }

            return raw;
        }

        public static void Save(string path, RawSaveData raw)
        {
            using var stream = new FileStream(path, FileMode.Create);
            using var writer = new BinaryWriter(stream);
            var structSize = Marshal.SizeOf(typeof(RawSaveData));
            var hglobal = Marshal.AllocHGlobal(structSize);
            try
            {
                Marshal.StructureToPtr(raw, hglobal, false);
                byte[] bytes = new byte[structSize];
                Marshal.Copy(hglobal, bytes, 0, structSize);
                writer.Write(bytes);
            }
            finally
            {
                Marshal.FreeHGlobal(hglobal);
            }
        }
    }
}
