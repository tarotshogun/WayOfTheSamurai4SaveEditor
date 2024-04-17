using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayOfTheSamurai4SaveEditor.Models.RawData;
using WayOfTheSamurai4SaveEditor.Models.SaveData;

namespace WayOfTheSamurai4SaveEditor.Models.SaveDataConversion
{
    static class RyuhaConverter
    {
        public static ObservableCollection<Ryuha> ToRyuha(RawMyRyuhaName[] raw)
        {
            var ryuhas = new ObservableCollection<Ryuha>();

            foreach (var rawRyuha in raw)
            {
                var name = Encoding.Unicode.GetString(rawRyuha.Name);
                ryuhas.Add(new Ryuha(name) { });
            }


            return ryuhas;
        }

        public static void ToRawMyRyuhaName(ObservableCollection<Ryuha> ryuhas, ref RawMyRyuhaName[] raw)
        {
            for (int i = 0; i < ryuhas.Count; i++)
            {
                Array.Copy(Encoding.Unicode.GetBytes(ryuhas[i].Name), raw[i].Name, ryuhas[i].Name.Length);
            }
        }
    }
}
