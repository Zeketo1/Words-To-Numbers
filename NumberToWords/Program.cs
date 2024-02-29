namespace NumberToWords;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Number to Words Converter");
        Console.WriteLine("Enter a number (up to 9 digits):");

        string input = Console.ReadLine();

        if (long.TryParse(input, out long number))
        {
            string words = NumberToWords(number);
            Console.WriteLine($"Words representation: {words}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.ReadLine(); 
    }
    static string NumberToWords(long number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            string[] unitsArray = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tensArray = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsArray[number];
            else
            {
                words += tensArray[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsArray[number % 10];
            }
        }

        return words;
    }
}