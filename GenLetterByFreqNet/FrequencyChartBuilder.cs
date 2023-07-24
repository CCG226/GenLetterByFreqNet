using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{ 
    internal static class FrequencyChartBuilder
    { 

        //default character chart 
        public static (char Character, double FrequencyValue, double CumulativeValue)[] Default()
         { 
            (char Character, double FrequencyValue, double CumulativeValue)[] NewChart = new (char Character, double FrequencyValue, double CumulativeValue)[26]
            {
                ( 'A', 8.4966, 0),
                ( 'B', 2.0720, 0 ),
                ( 'C', 4.5388, 0 ),
                ( 'D', 3.3844, 0 ),
                ( 'E', 11.1607, 0 ),
                ( 'F', 1.8121, 0),
                ( 'G', 2.4705, 0),
                ( 'H', 3.0034,0 ),
                ( 'I', 7.5448,0),
                ( 'J', 0.1965 ,0),
                ( 'K', 1.1016,0 ),
                ( 'L', 5.4893,0),
                ( 'M', 3.0129,0 ),
                ( 'N', 6.6544,0 ),
                ( 'O', 7.1635,0 ),
                ( 'P', 3.1671,0 ),
                ( 'Q', 0.1962,0 ),
                ( 'R', 7.5809,0 ),
                ( 'S', 5.7351,0 ),
                ( 'T', 6.9509,0 ),
                ( 'U', 3.6308,0),
                ( 'V', 1.0074,0 ),
                ( 'W', 1.2899,0 ),
                ( 'X', 0.2902,0 ),
                ( 'Y', 1.7779,0),
                ( 'Z', 0.2722,0 ),
            };

            CalculateCumulativeSumForChart(NewChart);
        
            return NewChart;
        }
        //default character chart with overridden frequency values 
        public static (char Character, double FrequencyValue, double CumulativeValue)[] CustomPercent(double[] weights)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            (char Character, double FrequencyValue, double CumulativeValue)[] NewChart = new (char Character, double FrequencyValue, double CumulativeValue)[26];
        
            for(int i = 0; i < weights.Length; i++)
            {
                NewChart[i].Character = alphabet[i];
                NewChart[i].FrequencyValue = weights[i];
                NewChart[i].CumulativeValue = 0;

            }

          CalculateCumulativeSumForChart(NewChart);

            return NewChart;
        }
        //entire chart is to be overridden by user provided dictionary of character values and their corresponding frequency values 
        public static (char Character, double FrequencyValue, double CumulativeValue)[] CustomCharacterSet(Dictionary<char, double> importedSet)
        {
            (char Character, double FrequencyValue, double CumulativeValue)[] NewChart = new (char Character, double FrequencyValue, double CumulativeValue)[importedSet.Count];

            int i = 0;
            foreach(var element in importedSet)
            {
                NewChart[i].Character = element.Key;
                NewChart[i].FrequencyValue = element.Value;
                NewChart[i].CumulativeValue = 0;
                i++;
            }

           CalculateCumulativeSumForChart(NewChart);

            return NewChart;
        }
        //calculates cummulative sum of the charts frequency value and
        //stores result in each elements CumulativeValue property
        //mutltiplied by a 1000 so that we can cleanly just randomly generate a number 
        //between 0-1000 instead of between 1-100 as that would require the
        //need to generate messy random decimal numbers to be accurate
       private static void CalculateCumulativeSumForChart((char Character, double FrequencyValue, double CumulativeValue)[] chart)
        {
            //contains and tracks cummulative sum value
            double currVal = 0;

            for(int i = 0; i < chart.Length; i++)
            {
                if(i == 0)//special case
                {
                    currVal = chart[0].FrequencyValue * 1000;
                    chart[i].CumulativeValue = Math.Round(currVal);
                
                }
                else
                {
                    currVal = (chart[i].FrequencyValue * 1000) + chart[i - 1].CumulativeValue;
                    chart[i].CumulativeValue = Math.Round(chart[i].CumulativeValue + currVal);
                }
            
            }

        }
    }
}
