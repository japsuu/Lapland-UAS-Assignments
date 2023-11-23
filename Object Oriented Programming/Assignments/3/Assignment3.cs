namespace ObjectOrientedProgramming.Assignments._3;

/// <summary>
/// Tee ohjelma, joka kysyy oppilaiden nimiä 5-10 kpl ja lisää jokaisen nimen listaan.
/// Lopuksi vielä tulostetaan kaikkien oppilaiden nimet allekkain
/// </summary>
public class Assignment3 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        List<string> students = new();

        while (students.Count < 10)
        {
            Console.WriteLine("Anna oppilaan nimi:");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                if (students.Count >= 5)
                    break;
                else
                    continue;
            
            students.Add(input);
        }

        Console.WriteLine("\nOppilaat:");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }
    }
}