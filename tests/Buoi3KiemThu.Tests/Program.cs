using Buoi3KiemThu;

static class Program
{
    private static int _passed;
    private static int _failed;

    public static int Main()
    {
        Run("Rectangle perimeter - valid", () => ExpectEqual(14, MathExercises.RectanglePerimeter(3, 4)));
        Run("Rectangle perimeter - boundary", () => ExpectEqual(2, MathExercises.RectanglePerimeter(0.5, 0.5)));
        Run("Rectangle perimeter - invalid", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.RectanglePerimeter(0, 4)));

        Run("Rectangle area - valid", () => ExpectEqual(12, MathExercises.RectangleArea(3, 4)));
        Run("Rectangle area - boundary", () => ExpectEqual(0.25, MathExercises.RectangleArea(0.5, 0.5)));
        Run("Rectangle area - invalid", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.RectangleArea(-1, 4)));

        Run("Quadratic - two roots", () =>
        {
            QuadraticSolution solution = MathExercises.SolveQuadratic(1, -5, 6);
            ExpectEqual(QuadraticSolutionKind.TwoDistinctRealRoots, solution.Kind);
            ExpectNear(2, solution.Root1);
            ExpectNear(3, solution.Root2);
        });

        Run("Quadratic - double root", () =>
        {
            QuadraticSolution solution = MathExercises.SolveQuadratic(1, 2, 1);
            ExpectEqual(QuadraticSolutionKind.OneDoubleRoot, solution.Kind);
            ExpectNear(-1, solution.Root1);
        });

        Run("Quadratic - invalid a=0", () => ExpectThrows<ArgumentException>(() => MathExercises.SolveQuadratic(0, 2, 1)));

        Run("Days in month - valid 31 days", () => ExpectEqual(31, MathExercises.DaysInMonth(1, 2026)));
        Run("Days in month - leap February", () => ExpectEqual(29, MathExercises.DaysInMonth(2, 2024)));
        Run("Days in month - invalid month", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.DaysInMonth(13, 2026)));

        Run("Prime - valid prime", () => ExpectTrue(MathExercises.IsPrime(17)));
        Run("Prime - non-prime boundary", () => ExpectFalse(MathExercises.IsPrime(1)));
        Run("Prime - invalid negative", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.IsPrime(-7)));

        Run("Alternating sum - valid odd n", () => ExpectEqual(3L, MathExercises.AlternatingSum(5)));
        Run("Alternating sum - valid even n", () => ExpectEqual(-3L, MathExercises.AlternatingSum(6)));
        Run("Alternating sum - invalid n=0", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.AlternatingSum(0)));

        Run("GCD - valid", () => ExpectEqual(6, MathExercises.GreatestCommonDivisor(48, 18)));
        Run("GCD - boundary zero operand", () => ExpectEqual(18, MathExercises.GreatestCommonDivisor(0, 18)));
        Run("GCD - invalid both zero", () => ExpectThrows<ArgumentException>(() => MathExercises.GreatestCommonDivisor(0, 0)));

        Run("Factorial sum - valid", () => ExpectEqual(33L, MathExercises.SumFactorials(4)));
        Run("Factorial sum - boundary n=1", () => ExpectEqual(1L, MathExercises.SumFactorials(1)));
        Run("Factorial sum - invalid n=0", () => ExpectThrows<ArgumentOutOfRangeException>(() => MathExercises.SumFactorials(0)));

        Console.WriteLine();
        Console.WriteLine($"Passed: {_passed}");
        Console.WriteLine($"Failed: {_failed}");
        return _failed == 0 ? 0 : 1;
    }

    private static void Run(string name, Action test)
    {
        try
        {
            test();
            _passed++;
            Console.WriteLine($"[PASS] {name}");
        }
        catch (Exception ex)
        {
            _failed++;
            Console.WriteLine($"[FAIL] {name} -> {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectEqual<T>(T expected, T actual) where T : notnull
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new InvalidOperationException($"Expected {expected}, got {actual}");
        }
    }

    private static void ExpectNear(double expected, double? actual, double tolerance = 1e-9)
    {
        if (actual is null || Math.Abs(expected - actual.Value) > tolerance)
        {
            throw new InvalidOperationException($"Expected around {expected}, got {actual}");
        }
    }

    private static void ExpectTrue(bool condition)
    {
        if (!condition)
        {
            throw new InvalidOperationException("Expected true");
        }
    }

    private static void ExpectFalse(bool condition)
    {
        if (condition)
        {
            throw new InvalidOperationException("Expected false");
        }
    }

    private static void ExpectThrows<TException>(Action action) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException)
        {
            return;
        }

        throw new InvalidOperationException($"Expected exception {typeof(TException).Name}");
    }
}