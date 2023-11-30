using CommonClassLibrary;

namespace Assignment4_MathApp;

public class MathApp
{
    private readonly Queue<MathQuestion> _questions = new();

    
    public MathApp(MathOperation mathOperation, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _questions.Enqueue(GenerateNewQuestion(mathOperation));
        }
    }
    
    
    public void Run()
    {
        while (_questions.Count > 0)
        {
            MathQuestion question = _questions.Dequeue();
            question.PrintQuestion();
            
            string? answer = Console.ReadLine();
            if (int.TryParse(answer, out int answerInt))
            {
                if (question.IsAnswerCorrect(answerInt))
                {
                    ConsoleLogger.WriteLineSuccess("Correct!");
                }
                else
                {
                    ConsoleLogger.WriteLineError("Incorrect!");
                    question.PrintCorrectAnswer();
                    _questions.Enqueue(question);
                }
            }
            else
            {
                ConsoleLogger.WriteLineWarning("Invalid answer.");
            }
        }
    }


    private static MathQuestion GenerateNewQuestion(MathOperation mathOperation)
    {
        Random random = new();
        int operand1 = random.Next(1, 11);
        int operand2 = random.Next(1, 11);
        return new MathQuestion(mathOperation, operand1, operand2);
    }
}