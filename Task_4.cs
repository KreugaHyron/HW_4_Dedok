using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Dedok
{
    public class DailyTemperature
    {
        public decimal MaxTemperature { get; set; }
        public decimal MinTemperature { get; set; }

        public DailyTemperature(decimal maxTemperature, decimal minTemperature)
        {
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        public decimal TemperatureDifference => MaxTemperature - MinTemperature;
    }
}
