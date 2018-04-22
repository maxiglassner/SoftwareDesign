using System;

namespace Aufgabe3
{
   class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value = int.Parse(args[0]);
                int toBase = int.Parse(args[1]);
                int fromBase = int.Parse(args[2]);
                int result = ConvertNumberToBaseFromBase(value, toBase, fromBase);
                Console.WriteLine($"The number {value} in the {fromBase}th-System is in {toBase}th-System number: {result}.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not enough arguments provided.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Arguments need to be of type int.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int ConvertDecimalToHexal(int dec)
        {
            return ConvertToBaseFromDecimal(dec, 6);
        }

        static int ConvertHexalToDecimal(int hexal)
        {
            return ConvertToDecimalFromBase(hexal, 6);
        }

        static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            return ConvertToBaseFromDecimal(toBase, ConvertToDecimalFromBase(fromBase, number));
        }

        // Implementation of the euclidean algorithm.
        static int ConvertToBaseFromDecimal(int toBase, int value)
        {
            if (toBase < 2 || toBase > 10) throw new ArgumentOutOfRangeException("toBase", toBase, "Function can only convert to bases between 2 and 10.");
            int result = 0;
            int numIndex = 1;
            do
            {
                int remainder = value % toBase;
                value = value / toBase;
                result += remainder * numIndex;
                numIndex *= 10;
            }
            while(value != 0);
            return result;
        }

        static int ConvertToDecimalFromBase(int fromBase, int value)
        {
            if (fromBase < 2 || fromBase > 10) throw new ArgumentOutOfRangeException("fromBase", fromBase, "Can Only convert from bases between 2 and 10");
            int result = 0;
            int numIndex = 1;
            while (value != 0)
            {
                int number = value % 10;
                if (number >= fromBase) throw new ArgumentException("Value contains numbers that not available in the given base.", "value");
                value = value / 10;
                result += number * numIndex;
                numIndex *= fromBase;
            }
            return result;
        }
    }
}
