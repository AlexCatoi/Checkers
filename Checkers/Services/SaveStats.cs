using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Checkers.Services
{
    public class SaveStats
    {
        public class MyData
        {
            public string Culoare { get; set; }
            public int Piese { get; set; }

            public int Victorii { get; set; }
        }
        public SaveStats(string color,int nrPieseRamase)
        {
            List<MyData> lista = createList();
            updateList(lista,color,nrPieseRamase);
            saveToJsonFile(lista);
        }
        public SaveStats() {}


        public List<MyData> getStats()
        {
            var list=createList();
            return list;
        }
        private static List<MyData> createList()
        {
            var file = File.ReadAllText("../../DataFiles/Stats.json");
            var list = JsonConvert.DeserializeObject<List<MyData>>(file) ?? new List<MyData>();
            return list;
        }
        private static void saveToJsonFile(List<MyData> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText("../../DataFiles/Stats.json", json);
        }
        private static void updateList(List<MyData> lista,string color,int piese)
        {
            foreach (MyData data in lista)
            {
                if (data.Culoare==color)
                {
                    data.Victorii += 1;
                    if(data.Piese <piese)
                        data.Piese = piese;
                    break;
                }
            }
        }

    }

}
