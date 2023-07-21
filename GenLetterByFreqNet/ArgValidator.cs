using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal static class ArgValidator
    {
        public static void isOverrideWeightsSizeEqualToAlphabetSize(double[] weights)
        {
            if (weights.Length != 26)
            {
                throw new InvalidOverrideWeightArraySize("Size Of Override Array Of Frequency Weights Must Equal 26." +
                    " Parameter to override weights array size is " + weights.Length);

            }

        }
        public static void isAmountLessThanOrEqualToZero(int amount)
        {

            if (amount <= 0)
            {
                throw new InvalidCharacterAmountException("Cannot generate 0 or less characters." +
                    " Parameter amount value is " + amount);
            }


        }
        public static void isWeightsEqualTo100(double[] weights)
        {
            double total = 0;

            foreach (double weight in weights)
            {
                total += weight;
            }

            if (total != 100)
            {
                throw new InvalidWeightTotalException("list of decimal values must add up to 100 to represent 100%." +
                    " Total weight perecent of parameter array is " + total);
            }

        }
        public static void isWeightsEqualTo100(Dictionary<char, double> CharFrequencyChartArg)
        {
            double total = 0;

            foreach (double weight in CharFrequencyChartArg.Values)
            {
                total += weight;
            }


            if (total != 100)
            {
                throw new InvalidWeightTotalException("list of decimal values must add up to 100 to represent 100%." +
   " Total weight perecent of parameter Dictionary is " + total);
            }

        }
    }
}
