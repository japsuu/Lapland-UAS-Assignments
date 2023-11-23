namespace ObjectOrientedProgramming.Assignments._2;

/// <summary>
/// Assignment 2.2
/// </summary>
public class Assignment2 : ISchoolAssignment
{
    private const int MAX_STUDENT_POINTS = 81;


    public void Run(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Anna opiskelijan pistemäärä:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int studentPoints))
            {
                if (studentPoints < 0 || studentPoints > MAX_STUDENT_POINTS)
                {
                    Console.WriteLine("Väärä pistemäärä!");
                    return;
                }

                int studentGrade = GetStudentGrade(studentPoints);
                Console.WriteLine($"Opiskelijan arvosana on {studentGrade}.");
                return;
            }

            Console.WriteLine("Väärä pistemäärä!");
        }
    }


    private static int GetStudentGrade(int studentPoints)
    {
        double pointsPercentage = studentPoints / (double)MAX_STUDENT_POINTS;

        return pointsPercentage switch
        {
            >= 0.9 => 5,
            >= 0.8 => 4,
            >= 0.7 => 3,
            >= 0.6 => 2,
            >= 0.5 => 1,
            _ => 0
        };
    }
}