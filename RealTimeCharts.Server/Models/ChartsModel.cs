using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts.Server.Models
{
    public class ChartsModel
    {
        public List<int> Data { get; set; }
        public string? Label { get; set; }
        public string? BackgroundColor { get; set; }

        public ChartsModel()
        {
            Data = new List<int>();
        }
    }
}
