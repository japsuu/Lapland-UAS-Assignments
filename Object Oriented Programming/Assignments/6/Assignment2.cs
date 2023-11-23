namespace ObjectOrientedProgramming.Assignments._6;

/// <summary>
/// Tehtävänäsi on toteuttaa lottoarvontakone.
/// Koneen tulee osata arpoa sekä lotto, viking lotto ja eurojackpot rivit.
/// Käyttäjältä kysytään mitä (lotto/viking/eurojackpot) ja kuinka monta riviä arvotaan.
///
/// Lotossa valitaan seitsemän numeroa väliltä 1-40.
/// Viking Lotossa valitaan kuusi numeroa väliltä 1-48 sekä yksi lisänumero, eli vikingnumero, väliltä 1-5.
/// EuroJackpotissa valitaan viisi päänumeroa väliltä 1-50 ja kaksi tähtinumeroa väliltä 1-12
/// 
/// Toteuta ohjelma noudattamaan olio-ohjelmoinnin periaatteita;
/// luokkia, kapselointia, periytymistä ja metodien ylikirjoittamista/peittämistä.
/// </summary>
public class Assignment2 : ISchoolAssignment
{
    private abstract class Lottery
    {
        protected readonly Random Random = new();

        public abstract void GenerateNumbers(int lines);
    }

    private class Lotto : Lottery
    {
        public override void GenerateNumbers(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                List<int> numbers = new();
                while (numbers.Count < 7)
                {
                    int number = Random.Next(1, 41);
                    if (!numbers.Contains(number))
                    {
                        numbers.Add(number);
                    }
                }
                numbers.Sort();
                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }


    private class VikingLotto : Lottery
    {
        public override void GenerateNumbers(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                List<int> numbers = new();
                while (numbers.Count < 6)
                {
                    int number = Random.Next(1, 49);
                    if (!numbers.Contains(number))
                    {
                        numbers.Add(number);
                    }
                }
                numbers.Sort();
                int vikingNumber = Random.Next(1, 6);
                Console.WriteLine(string.Join(", ", numbers) + $", Viking numero: {vikingNumber}");
            }
        }
    }

    private class EuroJackpot : Lottery
    {
        public override void GenerateNumbers(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                List<int> numbers = new();
                while (numbers.Count < 5)
                {
                    int number = Random.Next(1, 51);
                    if (!numbers.Contains(number))
                    {
                        numbers.Add(number);
                    }
                }
                numbers.Sort();
                List<int> starNumbers = new();
                while (starNumbers.Count < 2)
                {
                    int number = Random.Next(1, 13);
                    if (!starNumbers.Contains(number))
                    {
                        starNumbers.Add(number);
                    }
                }
                starNumbers.Sort();
                Console.WriteLine(string.Join(", ", numbers) + $", Tähtinumerot: {string.Join(", ", starNumbers)}");
            }
        }
    }
    
    
    public void Run(string[] args)
    {
        Console.WriteLine("Valitse loton tyyppi (1: Lotto, 2: Viking Lotto, 3: EuroJackpot):");
        string? lotteryType = Console.ReadLine();
        Console.WriteLine("Kuinka monta riviä arvotaan?:");
        int lines = int.Parse(Console.ReadLine() ?? "5");

        Lottery lottery;
        switch (lotteryType)
        {
            case "1":
                lottery = new Lotto();
                break;
            case "2":
                lottery = new VikingLotto();
                break;
            case "3":
                lottery = new EuroJackpot();
                break;
            default:
                Console.WriteLine("Epäkelpo numero!");
                return;
        }

        lottery.GenerateNumbers(lines);
    }
}