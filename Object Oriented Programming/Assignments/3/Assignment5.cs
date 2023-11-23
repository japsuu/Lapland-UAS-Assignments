namespace ObjectOrientedProgramming.Assignments._3;

/// <summary>
/// "Theodore,Roosevelt","William,Taft","Woodrow,Wilson","Warren,Harding","Calvin,Coolidge","Herbert,Hoover","Franklin,Roosevelt",
/// "Harry,Truman","Dwight,Eisenhower","John,Kennedy","Lyndon,Johnson","Richard,Nixon"
/// Järjestä ja tulosta ylläoleva lista etunimen perusteella.
/// </summary>
public class Assignment5 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        string[] presidents = {
            "Theodore,Roosevelt",
            "William,Taft",
            "Woodrow,Wilson",
            "Warren,Harding",
            "Calvin,Coolidge",
            "Herbert,Hoover",
            "Franklin,Roosevelt",
            "Harry,Truman",
            "Dwight,Eisenhower",
            "John,Kennedy",
            "Lyndon,Johnson",
            "Richard,Nixon"
        };

        Array.Sort(presidents, (president1, president2) =>
            string.Compare(president1, president2, StringComparison.Ordinal));

        Console.WriteLine("Presidentit järjestettynä etunimen perusteella:");
        foreach (string president in presidents)
        {
            Console.WriteLine(president);
        }
    }
}