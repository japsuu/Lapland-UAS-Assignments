namespace ObjectOrientedProgramming.Assignments._2;

/// <summary>
/// Assignment 2.4
/// </summary>
public class Assignment4 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Anna kokonaisaika minuutteina:");
            string? minutes = Console.ReadLine();

            if (int.TryParse(minutes, out int minutesInt))
            {
                int days = minutesInt / 1440;
                int hours = minutesInt % 1440 / 60;
                int minutesLeft = minutesInt % 1440 % 60;

                Console.WriteLine($"Antamasi {minutesInt} minuuttia on: {days} päivää, {hours} tuntia ja {minutesLeft} minuuttia.");
                return;
            }

            Console.WriteLine("Väärä luku!");
        }
    }
}