using GenLetterByFreqNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal class FrequencyChartBuilder
    {
        public FrequencyChartBuilder(bool accMode)
        {
            highAccuracyMode = accMode;
        }
        private bool highAccuracyMode { get; set; }
        //default character chart 
        public CharFrequencyData[] Default()
        {
            CharFrequencyData[] newChart = new CharFrequencyData[]
            {    
                new('A', 8.4966, 0),
                new('B', 2.0720, 0),
                new('C', 4.5388, 0),
                new('D', 3.3844, 0),
                new('E', 11.1607, 0),
                new('F', 1.8121, 0),
                new('G', 2.4705, 0),
                new('H', 3.0034, 0),
                new('I', 7.5448, 0),
                new('J', 0.1965, 0),
                new('K', 1.1016, 0),
                new('L', 5.4893, 0),
                new('M', 3.0129, 0),
                new('N', 6.6544, 0),
                new('O', 7.1635, 0),
                new('P', 3.1671, 0),
                new('Q', 0.1962, 0),
                new('R', 7.5809, 0),
                new('S', 5.7351, 0),
                new('T', 6.9509, 0),
                new('U', 3.6308, 0),
                new('V', 1.0074, 0),
                new('W', 1.2899, 0),
                new('X', 0.2902, 0),
                new('Y', 1.7779, 0),
                new('Z', 0.2722, 0)
            };

            CalculateCumulativeSumForChart(newChart);

            return newChart;
        }

        //chart is based on user provided dictionary of character values and their corresponding frequency values 
        public CharFrequencyData[] CustomCharacterSet(Dictionary<char, double> importedSet)
        {
            List<CharFrequencyData> newChart = new List<CharFrequencyData>(importedSet.Count);

            foreach (var set in importedSet)
            {
                if (set.Value > 0)
                {
                    newChart.Add(new CharFrequencyData(set.Key, set.Value, 0));
                }

            }

            CharFrequencyData[] newChartArray = newChart.ToArray();

            CalculateCumulativeSumForChart(newChartArray);

            return newChartArray;
        }
        //calculates cummulative sum of the charts frequency value.
        //Result is stored in each elements CumulativeValue property.
        //CumulativeValue is mutltiplied by the multiplier so that we can just randomly generate a integer. 
        private void CalculateCumulativeSumForChart(CharFrequencyData[] chart)
        {
            //contains and tracks cummulative sum value
            double currCumulativeVal = 0;

            double multiplier = (highAccuracyMode) ? 1000 : 100;

            for (int i = 0; i < chart.Length; i++)
            {

                if (i == 0)
                {
                    currCumulativeVal = chart[0].FrequencyValue * multiplier;
                }
                else
                {
                    currCumulativeVal = (chart[i].FrequencyValue * multiplier) + chart[i - 1].CumulativeValue;
                }

                chart[i].CumulativeValue = Math.Round(currCumulativeVal);
            }

        }
    }
}
