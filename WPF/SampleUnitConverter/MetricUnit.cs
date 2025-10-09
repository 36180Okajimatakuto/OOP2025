using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    class MetricUnit :DistanceUnit {
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{ Name = "mm",Coefficent = 1,},
            new MetricUnit{ Name = "cm",Coefficent = 10,},
            new MetricUnit{ Name = "m",Coefficent = 10 * 100,},
            new MetricUnit{ Name = "Km",Coefficent = 10 * 100 * 1000,},
        };

        public static ICollection<MetricUnit> Units { get => units; }

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">変換元の単位</param>
        /// <param name="value">変換する値</param>
        /// <returns>変換した値</returns>
        public double FormImperialUnit(ImperialUnit unit,double value) {
            return (value * unit.Coefficent) * 25.4 / this.Coefficent; 
        }
    }
}
