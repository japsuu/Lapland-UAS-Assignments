namespace ObjectOrientedProgramming.Assignments._2;

/// <summary>
/// Assignment 2.1
/// </summary>
public class Assignment1 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        while (true)
        {
            Dictionary<int, string> stringRepresentations = new()
            {
                { 1, "yksi" },
                { 2, "kaksi" },
                { 3, "kolme" },
                { 4, "neljä" },
                { 5, "viisi" },
                { 6, "kuusi" },
                { 7, "seitsemän" },
                { 8, "kahdeksan" },
                { 9, "yhdeksän" },
                { 10, "kymmenen" }
            };

            Console.WriteLine("Anna numero 1-10:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                if (stringRepresentations.TryGetValue(number, out string? stringRepresentation))
                {
                    Console.WriteLine($"Annoit numeron {stringRepresentation}.");
                    return;
                }
            }

            Console.WriteLine("Väärä numero!");
        }
    }
}
