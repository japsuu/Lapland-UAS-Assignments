namespace CommonClassLibrary;

public static class ConsoleLogger
{
    public static void WriteLineInfo(string message)
    {
        WriteLineColor(message, ConsoleColor.White);
    }
    
    
    public static void WriteInfo(string message)
    {
        WriteColor(message, ConsoleColor.White);
    }
    
    
    public static void WriteLineError(string message)
    {
        WriteLineColor(message, ConsoleColor.Red);
    }
    
    
    public static void WriteError(string message)
    {
        WriteColor(message, ConsoleColor.Red);
    }
    
    
    public static void WriteLineWarning(string message)
    {
        WriteLineColor(message, ConsoleColor.Yellow);
    }
    
    
    public static void WriteWarning(string message)
    {
        WriteColor(message, ConsoleColor.Yellow);
    }
    
    
    public static void WriteLineQuestion(string message)
    {
        WriteLineColor(message, ConsoleColor.Cyan);
    }
    
    
    public static void WriteQuestion(string message)
    {
        WriteColor(message, ConsoleColor.Cyan);
    }
    
    
    public static void WriteLineSuccess(string message)
    {
        WriteLineColor(message, ConsoleColor.Green);
    }
    
    
    public static void WriteSuccess(string message)
    {
        WriteColor(message, ConsoleColor.Green);
    }
    
    
    public static void WriteLineColor(string message, ConsoleColor color)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
    
    
    public static void WriteColor(string message, ConsoleColor color)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ForegroundColor = originalColor;
    }
}