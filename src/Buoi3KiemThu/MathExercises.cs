namespace Buoi3KiemThu;

public enum QuadraticSolutionKind
{
    TwoDistinctRealRoots,
    OneDoubleRoot,
    NoRealRoots
}

public sealed record QuadraticSolution(QuadraticSolutionKind Kind, double? Root1, double? Root2)
{
    public override string ToString()
    {
        return Kind switch
        {
            QuadraticSolutionKind.TwoDistinctRealRoots => $"Two real roots: x1 = {Root1}, x2 = {Root2}",
            QuadraticSolutionKind.OneDoubleRoot => $"One double root: x = {Root1}",
            QuadraticSolutionKind.NoRealRoots => "No real roots",
            _ => Kind.ToString()
        };
    }
}

public static class MathExercises
{
    public static double RectanglePerimeter(double length, double width)
    {
        ValidatePositive(length, nameof(length));
        ValidatePositive(width, nameof(width));
        return 2 * (length + width);
    }

    public static double RectangleArea(double length, double width)
    {
        ValidatePositive(length, nameof(length));
        ValidatePositive(width, nameof(width));
        return length * width;
    }

    public static QuadraticSolution SolveQuadratic(double a, double b, double c)
    {
        if (Math.Abs(a) < 1e-12)
        {
            throw new ArgumentException("Coefficient a must be different from 0 for a quadratic equation.", nameof(a));
        }

        double discriminant = b * b - 4 * a * c;
        if (discriminant > 1e-12)
        {
            double sqrt = Math.Sqrt(discriminant);
            double root1 = (-b - sqrt) / (2 * a);
            double root2 = (-b + sqrt) / (2 * a);
            return new QuadraticSolution(QuadraticSolutionKind.TwoDistinctRealRoots, root1, root2);
        }

        if (Math.Abs(discriminant) <= 1e-12)
        {
            double root = -b / (2 * a);
            return new QuadraticSolution(QuadraticSolutionKind.OneDoubleRoot, root, root);
        }

        return new QuadraticSolution(QuadraticSolutionKind.NoRealRoots, null, null);
    }

    public static int DaysInMonth(int month, int year)
    {
        if (year <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be greater than 0.");
        }

        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be in the range 1..12.");
        }

        return DateTime.DaysInMonth(year, month);
    }

    public static bool IsPrime(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Prime check expects a non-negative integer.");
        }

        if (n < 2)
        {
            return false;
        }

        if (n == 2)
        {
            return true;
        }

        if (n % 2 == 0)
        {
            return false;
        }

        for (int divisor = 3; divisor * divisor <= n; divisor += 2)
        {
            if (n % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static long AlternatingSum(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        long sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i % 2 == 1 ? i : -i;
        }

        return sum;
    }

    public static int GreatestCommonDivisor(int a, int b)
    {
        if (a == 0 && b == 0)
        {
            throw new ArgumentException("At least one value must be non-zero.");
        }

        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }

    public static long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than or equal to 0.");
        }

        checked
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }

    public static long SumFactorials(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        checked
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += Factorial(i);
            }

            return sum;
        }
    }

    private static void ValidatePositive(double value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value must be greater than 0.");
        }
    }
}