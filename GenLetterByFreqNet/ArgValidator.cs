using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal class ArgValidator
    {
        const int ZERO = 0;
        const int MAX_DICT_SIZE = 10_000;

        //integer argument must be greater than zero
        public static void isAmountLessThanOrEqualToZero(int amount)
        {

            if (amount <= ZERO)
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
                if(weight < ZERO)
                {
                    throw new InvalidWeightException("Weight values cannot be less than or equal to zero!");
                }
            }

        }

        public static void isCustomSetSizeValid(Dictionary<char, double> CharFrequencyChartArg)
        {

            if(CharFrequencyChartArg.Count == ZERO)
            {
                throw new InvalidWeightException("Custom character set cannot be empty!");
            }
            if (CharFrequencyChartArg.Count > MAX_DICT_SIZE)
            {
                throw new InvalidWeightException("Custom character set is to big!");
            }
        }
    }
}
