namespace ObjectOrientedProgramming.Assignments._3;

/// <summary>
/// Tee ohjelma, joka yhdistää kahden taulun arvot ja tulostaa ne suuruusjärjestyksessä.
/// Taulukko 1: 1,3,5,7,9,11
/// Taulukko 2: 2,6,8,10,12
/// </summary>
public class Assignment4 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        int[] array1 = { 1, 3, 5, 7, 9, 11 };
        int[] array2 = { 2, 6, 8, 10, 12 };

        int[] combinedArray = new int[array1.Length + array2.Length];
        array1.CopyTo(combinedArray, 0);
        array2.CopyTo(combinedArray, array1.Length);

        Array.Sort(combinedArray);

        Console.WriteLine("Yhdistetty taulukko järjestettynä:");
        foreach (int number in combinedArray)
        {
            Console.WriteLine(number);
        }
    }
}