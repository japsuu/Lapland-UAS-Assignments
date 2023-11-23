namespace ObjectOrientedProgramming.Assignments._4;

/// <summary>
/// Tehtävänäsi on toteuttaa laskin, joka osaa laskea peruslaskutoiminnot, eli + - / ja * laskut.
/// Luo uusi Calculator luokka jonne toteutat addition, subtraction, divide ja multiply -metodit.
/// Jokainen metodi ottaa vastaan 2 numeerista arvoa ja suorittaa laskutoimituksen niiden perusteella.
/// Laskutoimituksen jälkeen arvo palautetaan pääohjelmaan jossa se tulostetaan.
/// Tee pääohjelmaan logiikka, jossa kysyt käyttäjältä 2 numeroa ja halutun lasku-operaation,
/// sen jälkeen käytä Calculator luokkaa laskemaan ja tulosta tulos käyttäjälle.
/// </summary>
public class Assignment1 : ISchoolAssignment
{
    public static class Calculator
    {
        public static int Add(int number1, int number2) => number1 + number2;
        
        public static int Subtract(int number1, int number2) => number1 - number2;
        
        public static int Multiply(int number1, int number2) => number1 * number2;
        
        public static int Divide(int number1, int number2) => number1 / number2;
    }


    public void Run(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Anna luku 1:");
            string? input1 = Console.ReadLine();
            Console.WriteLine("Anna luku 2:");
            string? input2 = Console.ReadLine();
            Console.WriteLine("Anna laskutoimitus (+, -, *, /):");
            string? operation = Console.ReadLine();

            if (int.TryParse(input1, out int number1) && int.TryParse(input2, out int number2))
            {
                int result = operation switch
                {
                    "+" => Calculator.Add(number1, number2),
                    "-" => Calculator.Subtract(number1, number2),
                    "*" => Calculator.Multiply(number1, number2),
                    "/" => Calculator.Divide(number1, number2),
                    _ => 0
                };

                Console.WriteLine($"Tulos on {result}.");
                return;
            }

            Console.WriteLine("Väärä luku!");
        }
    }
}