using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Program1 
{
    static double Positive()
    {
        double LowNumber;
        do
        {
            Console.WriteLine("enter a number greater than 0 ");
            LowNumber = Convert.ToDouble(Console.ReadLine());
            if (LowNumber < 0)
            {
                continue;
            }
            else 
            {
                Console.WriteLine($"The Low number is {LowNumber}");
            }
        }
        while (LowNumber < 0);
        return LowNumber;
    }

    static double Higher(double Low)
    {
        double HighNumber;
        do
        {
            Console.WriteLine($"enter a number greater than {Low}");
            HighNumber = Convert.ToDouble(Console.ReadLine());
            if (Low >= HighNumber)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"The High number is {HighNumber}");
            }
        }
        while (HighNumber <= Low);
        return HighNumber;

    }

    static double Difference(double High, double Low)
    {
        return Math.Round(High - Low , 2);
    }

    static void Files(double High, double Low)
    {
        var numbers = new List<string>();

        for (double i = 1; i < Math.Ceiling(High) - Math.Floor(Low) + 1; i++)
        {
            if (i == 1)
            {
                numbers.Add(Low.ToString());
            }
            if (i > High)
            {
                break;
            }
            else
            {
                numbers.Add(i.ToString());
            }
        }
        if (High % 1 != 0)
        {
            numbers.Add(High.ToString());
        }
        numbers.Sort();
        using (StreamWriter sw = File.AppendText("numbers.txt"))
        {
            numbers.Reverse();
            for (int i = 0; i < numbers.Count; i++)
            {
                sw.WriteLine(numbers[i]);
            }
        }
    }

    static void ReadSum()
    {
        string path = @"numbers.txt";
        double sum = 0;
        double number;
        string prime = "";
        int counter = 0;
        var lines = File.ReadLines(path);
        foreach (var line in lines)
        {
            Console.Write($"{line} ");
            number = Convert.ToDouble(line);
            sum += number;
            if (counter == 0)
            {
                counter++;
            }
            else
            {
                for (double i = 2; i <= number; i++)
                {
                    if (number == 2)
                    {
                        prime += Convert.ToString(number) + " ";
                        break;
                    }
                    else if (number == 3)
                    {
                        prime += Convert.ToString(number) + " ";
                        break;
                    }
                    else if (number % 3 == 0)
                    {
                        break;
                    }
                    else if (number % i == 0)
                    {
                        break;
                    }
                    else if (number == -1)
                    {
                        continue;
                    }
                    else
                    {
                        prime += Convert.ToString(number) + " ";
                        break;
                    }
                }
            }
        }
        sum = Math.Round(sum, 2);
        Console.WriteLine($"\nThe Sum of all the numbers is {sum}");
        if (prime == "")
        {
            Console.WriteLine("There are no prime numbers");
        }
        else 
        {
            Console.WriteLine($"These are the prime numbers {prime}");
        }
    }

    static void Main(string[] args)
    {
        double Low = Positive();
        double High = Higher(Low);
        double Calculated = Difference(High, Low);
        Console.WriteLine($"The difference is {Calculated}");
        Files(High, Low);
        ReadSum();
        
    }
}