using System.Globalization;

namespace ObjectOrientedProgramming.Assignments._2;

/// <summary>
/// Assignment 2.3
/// </summary>
public class Assignment3 : ISchoolAssignment
{
    public void Run(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Anna luku 1:");
            string? number1 = Console.ReadLine();
            Console.WriteLine("Anna luku 2:");
            string? number2 = Console.ReadLine();

            if (double.TryParse(number1, NumberStyles.Any, CultureInfo.InvariantCulture, out double num1) && double.TryParse(number2, NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
            {
                string formattedNum1 = Math.Round(num1, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);
                string formattedNum2 = Math.Round(num2, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);
                string division = Math.Round(num1 / num2, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);
                string multiplication = Math.Round(num1 * num2, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);
                string subtraction = Math.Round(num1 - num2, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);
                string addition = Math.Round(num1 + num2, 2, MidpointRounding.AwayFromZero).ToString("F2", CultureInfo.InvariantCulture);

                Console.WriteLine($"Lukujen {formattedNum1} ja {formattedNum2} laskuoperaatiot:");
                Console.WriteLine($"Jakolasku: {formattedNum1} / {formattedNum2} = {division}");
                Console.WriteLine($"Kertolasku: {formattedNum1} * {formattedNum2} = {multiplication}");
                Console.WriteLine($"Vähennyslasku: {formattedNum1} - {formattedNum2} = {subtraction}");
                Console.WriteLine($"Yhteenlasku: {formattedNum1} + {formattedNum2} = {addition}");

                return;
            }

            Console.WriteLine("Väärä luku!");
        }
    }
}