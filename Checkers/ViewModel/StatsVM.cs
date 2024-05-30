using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Services;
namespace Checkers.ViewModel
{
    internal class StatsVM
    {
        public int PieseAlbe {  get; set; }
        public int PieseRosii { get; set; }
        public int VictoriiAlb { get; set; }
        public int VictoriiRosu { get; set; }
        public StatsVM() 
        { 
            var ss=new SaveStats();
            var jsonList = ss.getStats();
            setVar(jsonList);
        }
        private void setVar(List<SaveStats.MyData> list)
        {
            foreach (var item in list)
            {
                if(item.Culoare=="White")
                {
                    PieseAlbe = item.Piese;
                    VictoriiAlb = item.Victorii;
                }
                else
                {
                    PieseRosii=item.Piese;
                    VictoriiRosu=item.Victorii;
                }
            }
        }
    }
}
