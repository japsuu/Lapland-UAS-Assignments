
using ObjectOrientedProgramming.Assignments._7;

namespace ObjectOrientedProgramming
{
    internal static class Program
    {
        private static readonly ISchoolAssignment Assignment = new Assignment3();
        
        private static void Main(string[] args)
        {
            Assignment.Run(args);
            Console.ReadKey(true);
        }
    }
}
