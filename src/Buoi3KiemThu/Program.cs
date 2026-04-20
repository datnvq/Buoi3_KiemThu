using System.Globalization;
using Buoi3KiemThu;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("Black Box Practice Menu");
    Console.WriteLine("1. Rectangle perimeter");
    Console.WriteLine("2. Rectangle area");
    Console.WriteLine("3. Solve quadratic equation");
    Console.WriteLine("4. Days in month");
    Console.WriteLine("5. Prime check");
    Console.WriteLine("6. Alternating sum 1 - 2 + 3 - ... + n");
    Console.WriteLine("7. Greatest common divisor");
    Console.WriteLine("8. Sum of factorials 1! + 2! + ... + n!");
    Console.WriteLine("0. Exit");
    Console.Write("Select: ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.WriteLine($"Perimeter = {MathExercises.RectanglePerimeter(ReadDouble("Length"), ReadDouble("Width"))}");
                break;
            case "2":
                Console.WriteLine($"Area = {MathExercises.RectangleArea(ReadDouble("Length"), ReadDouble("Width"))}");
                break;
            case "3":
            {
                double a = ReadDouble("a");
                double b = ReadDouble("b");
                double c = ReadDouble("c");
                Console.WriteLine(MathExercises.SolveQuadratic(a, b, c));
                break;
            }
            case "4":
                Console.WriteLine($"Days = {MathExercises.DaysInMonth(ReadInt("Month"), ReadInt("Year"))}");
                break;
            case "5":
                Console.WriteLine($"Prime = {MathExercises.IsPrime(ReadInt("n"))}");
                break;
            case "6":
                Console.WriteLine($"Sum = {MathExercises.AlternatingSum(ReadInt("n"))}");
                break;
            case "7":
                Console.WriteLine($"GCD = {MathExercises.GreatestCommonDivisor(ReadInt("a"), ReadInt("b"))}");
                break;
            case "8":
                Console.WriteLine($"Sum of factorials = {MathExercises.SumFactorials(ReadInt("n"))}");
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
}

static double ReadDouble(string label)
{
    while (true)
    {
        Console.Write($"Enter {label}: ");
        string? input = Console.ReadLine();
        if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value) ||
            double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
        {
            return value;
        }

        Console.WriteLine("Invalid number, please try again.");
    }
}

static int ReadInt(string label)
{
    while (true)
    {
        Console.Write($"Enter {label}: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int value))
        {
            return value;
        }

        Console.WriteLine("Invalid integer, please try again.");
    }
}