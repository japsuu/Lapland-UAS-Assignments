namespace Assignment4_MathApp;

public enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public static class OperationExtensions
{
    /// <returns>The string representation of a math operation.</returns>
    public static string ToSymbol(this MathOperation mathOperation)
    {
        return mathOperation switch
        {
            MathOperation.Addition => "+",
            MathOperation.Subtraction => "-",
            MathOperation.Multiplication => "*",
            MathOperation.Division => "/",
            _ => throw new ArgumentOutOfRangeException(nameof(mathOperation), mathOperation, null)
        };
    }
}