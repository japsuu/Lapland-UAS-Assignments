namespace ObjectOrientedProgramming.Assignments._3;

/// <summary>
/// Luo seuraavasta taulukosta dictionary, jossa henkilön nimi on key ja syntymävuosi on value:
/// Nimi syntymävuosi
/// Rutherford B. Hayes 1822
/// James A. Garfield 1831
/// Chester A. Arthur 1829
/// Grover Cleveland 1837
/// Benjamin Harrison 1833
/// William McKinley 1843
/// Theodore Roosevelt 1858.
///
/// Selvitä dictionaryä läpi käymällä:
/// a) kuinka monta henkilöä on syntynyt 1830-luvulla
/// b) Tulosta 1820-luvulla syntyneet henkilöt
/// c) Mikä on henkilöiden keskimääräinen syntymävuosi
/// </summary>
public class Assignment6 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        Dictionary<string, int> presidents = new()
        {
            { "Rutherford B. Hayes", 1822 },
            { "James A. Garfield", 1831 },
            { "Chester A. Arthur", 1829 },
            { "Grover Cleveland", 1837 },
            { "Benjamin Harrison", 1833 },
            { "William McKinley", 1843 },
            { "Theodore Roosevelt", 1858 }
        };

        int presidentsBornIn1830s = presidents.Count(president => president.Value >= 1830 && president.Value <= 1839);
        Console.WriteLine($"Syntynyt 1830-luvulla: {presidentsBornIn1830s} kpl.");

        var presidentsBornIn1820s = presidents.Where(president => president.Value >= 1820 && president.Value <= 1829);
        Console.WriteLine("Syntynyt 1820-luvulla:");
        foreach (var president in presidentsBornIn1820s)
        {
            Console.WriteLine($"{president.Key} {president.Value}");
        }

        double averageBirthYear = presidents.Average(president => president.Value);
        Console.WriteLine($"Keskimääräinen syntymävuosi: {(int)averageBirthYear}.");
    }
}