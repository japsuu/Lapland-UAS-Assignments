namespace ObjectOrientedProgramming.Assignments._2;

/// <summary>
/// Assignment 2.5
/// </summary>
public class Assignment5 : ISchoolAssignment
{
    private const int MONTHS_IN_YEAR = 12;
    public void Run(string[] args)
    {
        int[] salaries = new int[MONTHS_IN_YEAR];
        for (int i = 0; i < MONTHS_IN_YEAR; i++)
        {
            Console.WriteLine($"Anna kuukauden {i + 1} kuukausipalkka:");
            string? monthSalary = Console.ReadLine();
            if (int.TryParse(monthSalary, out int monthSalaryInt))
            {
                salaries[i] = monthSalaryInt;
            }
            else
            {
                Console.WriteLine("Väärä luku!");
                i--;
            }
        }
        
        int sum = salaries.Sum();
        int average = sum / MONTHS_IN_YEAR;
        
        Console.WriteLine($"Käyttäjän vuosipalkka: {sum}.");
        Console.WriteLine($"Käyttäjän keskipalkka: {average}.");
    }
}
