using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal static class ArgValidator
    {
        //ensures array of doubles to override each alpabet characters freqeuncy value
        //is size of 26 so that every character is overridden 
        public static void isOverrideWeightsSizeEqualToAlphabetSize(double[] weights)
        {
            if (weights.Length != 26)
            {
                throw new InvalidOverrideWeightArraySize("Size of override Array of Frequency percentages must equal 26." +
                    " Parameter to override weights array size is " + weights.Length);

            }

        }
        //integer argument must be greater than zero
        public static void isAmountLessThanOrEqualToZero(int amount)
        {

            if (amount <= 0)
            {
                throw new InvalidCharacterAmountException("Cannot generate 0 or less characters." +
                    " Parameter amount value is " + amount);
            }


        }
        //total of all double values summed together
        //must be equal to 100 when rounded
        public static void isWeightsEqualTo100(double[] weights)
        {
            double total = 0;

            foreach (double weight in weights)
            {
                total += weight;
            }

            if (Math.Round(total, 0) != 100)
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


            if (Math.Round(total, 0) != 100)
            {
                throw new InvalidWeightTotalException("list of decimal values must add up to 100 to represent 100%." +
   " Total weight perecent of argument dictionary is " + total);
            }

        }
    }
}
