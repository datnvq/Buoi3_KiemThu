using System.Text;
using Buoi3KiemThu;

var generator = new AutoTestGenerator();
return generator.Run();

internal sealed class AutoTestGenerator
{
    private readonly List<AutoTestCase> _cases = BuildCases();

    public int Run()
    {
        string root = Directory.GetCurrentDirectory();
        string resultsDirectory = Path.Combine(root, "results");
        Directory.CreateDirectory(resultsDirectory);

        var resultLines = new List<string>
        {
            "Auto-generated black-box test run",
            $"Generated at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
            string.Empty
        };

        int passed = 0;
        int failed = 0;

        foreach (AutoTestCase testCase in _cases)
        {
            AutoTestOutcome outcome = testCase.Execute();
            if (outcome.Passed)
            {
                passed++;
            }
            else
            {
                failed++;
            }

            string status = outcome.Passed ? "PASS" : "FAIL";
            string detailedLine = $"[{status}] {testCase.Id} | {testCase.Category} | Input: {testCase.Input} | Expected: {testCase.Expected} | Actual: {outcome.Actual} | Technique: {testCase.Technique}";

            Console.WriteLine(detailedLine);
            resultLines.Add(detailedLine);

        }

        Console.WriteLine();
        resultLines.Add(string.Empty);
        resultLines.Add($"Passed: {passed}");
        resultLines.Add($"Failed: {failed}");

        File.WriteAllLines(Path.Combine(resultsDirectory, "auto-test-results.txt"), resultLines, Encoding.UTF8);

        Console.WriteLine($"Auto-generated cases: {passed + failed}");
        Console.WriteLine($"Passed: {passed}");
        Console.WriteLine($"Failed: {failed}");

        return failed == 0 ? 0 : 1;
    }

    private static List<AutoTestCase> BuildCases()
    {
        return new List<AutoTestCase>
        {
            SuccessCase("RP-A01", "Rectangle perimeter", "length = 3, width = 4", "14", "Equivalence partitioning", () => MathExercises.RectanglePerimeter(3, 4)),
            SuccessCase("RP-A02", "Rectangle perimeter", "length = 0.5, width = 0.5", "2", "Boundary value analysis", () => MathExercises.RectanglePerimeter(0.5, 0.5)),
            FailureCase<ArgumentOutOfRangeException>("RP-A03", "Rectangle perimeter", "length = 0, width = 4", "Exception", "Invalid data", () => MathExercises.RectanglePerimeter(0, 4)),

            SuccessCase("RA-A01", "Rectangle area", "length = 3, width = 4", "12", "Equivalence partitioning", () => MathExercises.RectangleArea(3, 4)),
            SuccessCase("RA-A02", "Rectangle area", "length = 0.5, width = 0.5", "0.25", "Boundary value analysis", () => MathExercises.RectangleArea(0.5, 0.5)),
            FailureCase<ArgumentOutOfRangeException>("RA-A03", "Rectangle area", "length = -1, width = 4", "Exception", "Invalid data", () => MathExercises.RectangleArea(-1, 4)),

            SuccessCase("QE-A01", "Quadratic equation", "a = 1, b = -5, c = 6", "Two real roots: x1 = 2, x2 = 3", "Equivalence partitioning", () => MathExercises.SolveQuadratic(1, -5, 6).ToString()),
            SuccessCase("QE-A02", "Quadratic equation", "a = 1, b = 2, c = 1", "One double root: x = -1", "Boundary on discriminant = 0", () => MathExercises.SolveQuadratic(1, 2, 1).ToString()),
            FailureCase<ArgumentException>("QE-A03", "Quadratic equation", "a = 0, b = 2, c = 1", "Exception", "Invalid coefficient", () => MathExercises.SolveQuadratic(0, 2, 1)),

            SuccessCase("DM-A01", "Days in month", "month = 1, year = 2026", "31", "Equivalence partitioning", () => MathExercises.DaysInMonth(1, 2026)),
            SuccessCase("DM-A02", "Days in month", "month = 2, year = 2024", "29", "Leap-year boundary", () => MathExercises.DaysInMonth(2, 2024)),
            FailureCase<ArgumentOutOfRangeException>("DM-A03", "Days in month", "month = 13, year = 2026", "Exception", "Invalid month", () => MathExercises.DaysInMonth(13, 2026)),

            SuccessCase("PR-A01", "Prime check", "n = 17", "True", "Equivalence partitioning", () => MathExercises.IsPrime(17)),
            SuccessCase("PR-A02", "Prime check", "n = 1", "False", "Boundary value analysis", () => MathExercises.IsPrime(1)),
            FailureCase<ArgumentOutOfRangeException>("PR-A03", "Prime check", "n = -7", "Exception", "Invalid data", () => MathExercises.IsPrime(-7)),

            SuccessCase("AS-A01", "Alternating sum", "n = 5", "3", "Equivalence partitioning", () => MathExercises.AlternatingSum(5)),
            SuccessCase("AS-A02", "Alternating sum", "n = 6", "-3", "Boundary on parity change", () => MathExercises.AlternatingSum(6)),
            FailureCase<ArgumentOutOfRangeException>("AS-A03", "Alternating sum", "n = 0", "Exception", "Invalid boundary", () => MathExercises.AlternatingSum(0)),

            SuccessCase("GCD-A01", "Greatest common divisor", "a = 48, b = 18", "6", "Equivalence partitioning", () => MathExercises.GreatestCommonDivisor(48, 18)),
            SuccessCase("GCD-A02", "Greatest common divisor", "a = 0, b = 18", "18", "Boundary with zero operand", () => MathExercises.GreatestCommonDivisor(0, 18)),
            FailureCase<ArgumentException>("GCD-A03", "Greatest common divisor", "a = 0, b = 0", "Exception", "Invalid special case", () => MathExercises.GreatestCommonDivisor(0, 0)),

            SuccessCase("SF-A01", "Sum of factorials", "n = 4", "33", "Equivalence partitioning", () => MathExercises.SumFactorials(4)),
            SuccessCase("SF-A02", "Sum of factorials", "n = 1", "1", "Boundary value analysis", () => MathExercises.SumFactorials(1)),
            FailureCase<ArgumentOutOfRangeException>("SF-A03", "Sum of factorials", "n = 0", "Exception", "Invalid boundary", () => MathExercises.SumFactorials(0))
        };
    }

    private static AutoTestCase SuccessCase<T>(string id, string category, string input, string expected, string technique, Func<T> action)
    {
        return new AutoTestCase(
            id,
            category,
            input,
            expected,
            technique,
            () =>
            {
                T actual = action();
                string actualText = actual?.ToString() ?? string.Empty;
                return new AutoTestOutcome(Equals(expected, actualText), actualText);
            });
    }

    private static AutoTestCase FailureCase<TException>(string id, string category, string input, string expected, string technique, Action action)
        where TException : Exception
    {
        return new AutoTestCase(
            id,
            category,
            input,
            expected,
            technique,
            () =>
            {
                try
                {
                    action();
                    return new AutoTestOutcome(false, "No exception");
                }
                catch (TException ex)
                {
                    return new AutoTestOutcome(true, ex.GetType().Name);
                }
                catch (Exception ex)
                {
                    return new AutoTestOutcome(false, ex.GetType().Name);
                }
            });
    }

}

internal sealed record AutoTestCase(
    string Id,
    string Category,
    string Input,
    string Expected,
    string Technique,
    Func<AutoTestOutcome> Execute)
{
    public string Name => Category;
}

internal sealed record AutoTestOutcome(bool Passed, string Actual);