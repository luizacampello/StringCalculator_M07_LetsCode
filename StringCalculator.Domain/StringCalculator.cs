namespace StringCalculator.Domain
{
    public class StringCalculator
    {
        public int Add(string entryNumbers)
        {
            if (string.IsNullOrWhiteSpace(entryNumbers))
            {
                return 0;
            }

            string[] entryNumbersList = entryNumbers.Split(',');

            int listLength = entryNumbersList.Length;
            bool emptyItem = entryNumbersList.Any(x => x == "");
            bool nonNumber = entryNumbersList.Any(x => !int.TryParse(x, out _));

            if (listLength > 2 || emptyItem || nonNumber)
            {
                throw new ArgumentException(nameof(entryNumbers));
            }

            int numbersSum = entryNumbersList.Sum(Convert.ToInt32);

            return numbersSum;

        }
    }
}