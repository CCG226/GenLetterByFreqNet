using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal class ArgValidator
    {
        //integer argument must be greater than zero
        public static void isAmountLessThanOrEqualToZero(int amount)
        {

            if (amount <= 0)
            {
                throw new InvalidCharacterAmountException("Cannot generate 0 or less characters." +
                    " Parameter amount value is " + amount);
            }


        }
        //weight arguments must be greater than zero
        public static void isWeightCustomValuesValid(Dictionary<char, double> CharFrequencyChartArg)
        {

            foreach (double weight in CharFrequencyChartArg.Values)
            {
              if(weight <= 0)
                {
                    throw new InvalidWeightException("Weight values cannot be zero or negative!");
                }
            }

        }
    }
}
