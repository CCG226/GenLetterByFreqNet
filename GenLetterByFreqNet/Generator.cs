namespace GenLetterByFreqNET
{
    public class Generator
    {
        private (char Character, double FrequencyValue, double CumulativeValue)[] CharFrequencyChart;

        public Generator()
        {
            CharFrequencyChart = FrequencyChartBuilder.Default();
        }

        public Generator(double[] overrideLetterWeights)
        {
            ArgValidator.isOverrideWeightsSizeEqualToAlphabetSize(overrideLetterWeights);

            ArgValidator.isWeightsEqualTo100(overrideLetterWeights);

            CharFrequencyChart = FrequencyChartBuilder.CustomPercent(overrideLetterWeights);

        }

        public Generator(Dictionary<char, double> overrideCharacterSet)
        {
            ArgValidator.isWeightsEqualTo100(overrideCharacterSet);
          
            CharFrequencyChart = FrequencyChartBuilder.CustomCharacterSet(overrideCharacterSet);
        }

        public char GetRandomCharacter()
        {
            return ' ';
        }

        public string GetRandomCharacters(int amount)
        {

            ArgValidator.isAmountLessThanOrEqualToZero(amount);

            return "";

        }

    }
}