using CommonClassLibrary;

namespace Assignment4_MathApp;

/// <summary>
/// Rakenna yksinkertainen komentorivisovellus (matikkasovellus), jossa käyttäjä voi valita haluaako laskea kerto-, jako-, yhteen- tai vähennyslaskuja.
/// Ohjelma tarjoaa käyttäjälle laskutoimituksia valinnan perusteella.
/// Ohjelma ilmoittaa käyttäjälle onko vastaus oikein vai väärin.
/// </summary>
internal static class Program
{
    public static void Main(string[] args)
    {
        ConsoleLogger.WriteLineInfo("Assignment 4 - MathApp");

        MathOperation operation = GetOperationType();
        int questionCount = GetQuestionCount();

        MathApp mathApp = new MathApp(operation, questionCount);
        mathApp.Run();
            
        ConsoleLogger.WriteLineQuestion("Press any key to exit...");
        Console.ReadKey(true);
    }


    private static MathOperation GetOperationType()
    {
        while (true)
        {
            ConsoleLogger.WriteLineInfo("Select operation type:");
            ConsoleLogger.WriteLineInfo("1. Addition");
            ConsoleLogger.WriteLineInfo("2. Subtraction");
            ConsoleLogger.WriteLineInfo("3. Multiplication");
            ConsoleLogger.WriteLineInfo("4. Division");
            ConsoleLogger.WriteQuestion("Operation: ");
            string? operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    return MathOperation.Addition;
                case "2":
                    return MathOperation.Subtraction;
                case "3":
                    return MathOperation.Multiplication;
                case "4":
                    return MathOperation.Division;
                default:
                    ConsoleLogger.WriteLineWarning("Invalid operation type.");
                    continue;
            }
        }
    }


    private static int GetQuestionCount()
    {
        while (true)
        {
            ConsoleLogger.WriteQuestion("How many questions do you want to answer? ");
            string? questionCount = Console.ReadLine();
            if (int.TryParse(questionCount, out int questionCountInt))
                return questionCountInt;
            ConsoleLogger.WriteLineWarning("Invalid question count.");
        }
    }
}