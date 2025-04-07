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
        const double SMALL_WEIGHT = 0.00001;
        const int MAX_DICT_SIZE = 10_000;

        //integer argument must be greater than zero
        public static void IsAmountLessThanOrEqualToZero(int amount)
        {

            if (amount <= ZERO)
            {
                throw new InvalidCharacterAmountException("Cannot generate 0 or less characters." +
                    " Parameter amount value is " + amount);
            }


        }
        //weight arguments must be greater than zero
        public static void IsWeightCustomValuesValid(Dictionary<char, double> CharFrequencyChartArg)
        {

            foreach (double weight in CharFrequencyChartArg.Values)
            {
                if(weight < SMALL_WEIGHT)
                {
                    throw new InvalidWeightException($"Weight values cannot be less than {SMALL_WEIGHT}!");
                }
            }

        }

        public static void IsCustomSetSizeValid(Dictionary<char, double> CharFrequencyChartArg)
        {

            if(CharFrequencyChartArg.Count == ZERO)
            {
                throw new InvalidDictException("Custom character set cannot be empty!");
            }
            if (CharFrequencyChartArg.Count > MAX_DICT_SIZE)
            {
                throw new InvalidDictException("Custom character set is too big!");
            }
        }
    }
}
