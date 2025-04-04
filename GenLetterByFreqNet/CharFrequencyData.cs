using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNet
{
    internal struct CharFrequencyData
    {
        public CharFrequencyData(char character, double frequencyValue, double cumulativeValue)
        {
            Character = character;
            FrequencyValue = frequencyValue;
            CumulativeValue = cumulativeValue;
        }

        public char Character { get; init; }
        public double FrequencyValue { get; init; }
        public double CumulativeValue { get; set; }
    }
}
