namespace SearchServiceLSM.Utils
{
    public static class WeightCalculator
    {
        /// <summary>
        /// Calculates Weight of the property based on Searched text
        /// Weight of the "Full match" is 10x more than weighht of the "Partial match"
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyWeight"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetWeight(string property, int propertyWeight, string text)
        {
            if (string.IsNullOrEmpty(property))
                return 0;

            if (property.Contains(text, StringComparison.OrdinalIgnoreCase))
            {
                int multiplier = property.Length == text.Length ? 10 : 1;
                return multiplier * propertyWeight;
            }

            return 0;
        }
    }
}
