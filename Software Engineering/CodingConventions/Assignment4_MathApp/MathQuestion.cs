namespace Assignment4_MathApp;

public class MathQuestion
{
    private readonly MathOperation _operation;
    private readonly int _operand1;
    private readonly int _operand2;
    private readonly int _correctAnswer;


    public MathQuestion(MathOperation operation, int operand1, int operand2)
    {
        _operation = operation;
        _operand1 = operand1;
        _operand2 = operand2;
        _correctAnswer = CalculateCorrectAnswer(operation, operand1, operand2);
    }
    

    public bool IsAnswerCorrect(int answer) => answer == _correctAnswer;
    
    public void PrintCorrectAnswer() => Console.WriteLine($"{_operand1} {_operation.ToSymbol()} {_operand2} = {_correctAnswer}");
    
    public void PrintQuestion()
    {
        Console.WriteLine("\nWhat is...");
        Console.Write($"{_operand1} {_operation.ToSymbol()} {_operand2} = ");
    }


    private static int CalculateCorrectAnswer(MathOperation operation, int operand1, int operand2)
    {
        return operation switch
        {
            MathOperation.Addition => operand1 + operand2,
            MathOperation.Subtraction => operand1 - operand2,
            MathOperation.Multiplication => operand1 * operand2,
            MathOperation.Division => operand1 / operand2,
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }
}