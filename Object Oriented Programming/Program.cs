
using ObjectOrientedProgramming.Assignments._6;

namespace ObjectOrientedProgramming
{
    internal static class Program
    {
        private static readonly ISchoolAssignment Assignment = new Assignment2();
        
        private static void Main(string[] args)
        {
            Assignment.Run(args);
            Console.ReadKey(true);
        }
    }
}
