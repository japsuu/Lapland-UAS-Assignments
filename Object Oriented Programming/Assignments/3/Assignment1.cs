namespace ObjectOrientedProgramming.Assignments._3;

/// <summary>
/// Toteuta ohjelma joka tulostaa luvut 1-25 allekkain
/// a) käytä for silmukkaa
/// b) käytä while silmukkaa
/// c) Laske jokaisen numeron summa ja tulosta se lopuksi. Voit käyttää haluamaasi silmukkaa.
/// d) Laske lukujen keskiarvo ja tulosta se
/// </summary>
public class Assignment1 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        Console.WriteLine("a)");
        for (int i = 1; i <= 25; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nb)");
        int j = 1;
        while (j <= 25)
        {
            Console.WriteLine(j);
            j++;
        }

        Console.WriteLine("\nc)");
        int sum = 0;
        for (int k = 1; k <= 25; k++)
        {
            sum += k;
        }

        Console.WriteLine($"Lukujen summa on {sum}.");

        Console.WriteLine("\nd)");
        double average = sum / 25.0;
        Console.WriteLine($"Lukujen keskiarvo on {average}.");
    }
}