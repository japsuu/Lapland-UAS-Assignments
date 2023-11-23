namespace ObjectOrientedProgramming.Assignments._5;

/// <summary>
/// Suunnittelu ja toteuta kivi-paperi-sakset peli.
/// Tarkoituksena on siis toteuttaa peli jossa voittaja on se, joka on ensimmäisenä 3 kertaa voittanut yhden kivi-paperi-sakset kierroksen.
///
/// Voit itse päättää miten pelin tarkemmin toteutat, mutta pelaajasta pitää pystyä pitämään tallessa
/// nimi, kuinka monta kierros voittoa on sekä kierroksen valinta.
///
/// Toteuta ohjelma niin että “tietokoneen” valinta joka kierroksella arvotaan.
/// Toteuta ohjelma noudattamaan olio-ohjelmoinnin periaatteita; luokkia, kapselointia ja periytymistä.
///
/// Vinkkejä:
/// - Yritä tunnistaa tehtävän annosta mahdollisia luokkia. Esimerkiksi ihminen ja Tietokone. Voisiko näille olla yhteinen kantaluokka?
/// - Pääohjelmaa voisi ajaa silmukassa niin kauaa, että voittaja on selvillä
/// - Random luokka voi käyttää arpomaan “tietokoneen” valinta, esim: 1=kivi, 2=paperi ja sakset =3
/// </summary>
public class Assignment3 : ISchoolAssignment
{
    public enum Choice
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    private enum RoundWinner
    {
        Tie,
        Human,
        Computer
    }
    
    public abstract class Player
    {
        public int Wins { get; set; }
        
        
        public abstract Choice GetChoice();
    }


    private class HumanPlayer : Player
    {
        public string Name { get; set; }
        
        
        public HumanPlayer(string name)
        {
            Name = name;
        }
        
        
        public override Choice GetChoice()
        {
            Console.WriteLine("1. Kivi");
            Console.WriteLine("2. Paperi");
            Console.WriteLine("3. Sakset");
            Console.Write("Valintasi: ");
            int choice = -1;
            while (choice < 1 || choice > 3)
            {
                bool wasParsed = int.TryParse(Console.ReadLine(), out choice);
                if (wasParsed)
                    continue;
                
                Console.WriteLine("Invalid input, try again.");
                Console.Write("Valintasi: ");
            }
            return (Choice)choice;
        }
    }


    private class ComputerPlayer : Player
    {
        private readonly Random _random = new();
        
        
        public override Choice GetChoice()
        {
            return (Choice)_random.Next(1, 4);
        }
    }
    
    
    public void Run(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Saisinko nimesi?: ");
        string name = Console.ReadLine() ?? "Ihminen";
        HumanPlayer humanPlayer = new(name);
        ComputerPlayer computerPlayer = new();
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("-- Peli alkaa! --");
        while (humanPlayer.Wins < 3 && computerPlayer.Wins < 3)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Choice humanChoice = humanPlayer.GetChoice();
            Choice computerChoice = computerPlayer.GetChoice();
            Console.WriteLine($"{humanPlayer.Name} valitsi {GetChoiceName(humanChoice)}");
            Console.WriteLine($"Tietokone valitsi {GetChoiceName(computerChoice)}");
            RoundWinner winner = GetWinner(humanChoice, computerChoice);
            switch (winner)
            {
                case RoundWinner.Tie:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Tasapeli!");
                    continue;
                case RoundWinner.Human:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{humanPlayer.Name} voittaa!");
                    humanPlayer.Wins++;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tietokone voittaa!");
                    computerPlayer.Wins++;
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pisteet: {humanPlayer.Name} {humanPlayer.Wins} - {computerPlayer.Wins} Tietokone");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        if (humanPlayer.Wins == 3)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-- {humanPlayer.Name} voitti pelin! --");
            return;
        }
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-- Tietokone voitti pelin! --");
    }
    
    
    private static RoundWinner GetWinner(Choice humanChoice, Choice computerChoice)
    {
        if (humanChoice == computerChoice)
            return RoundWinner.Tie;
        
        if (humanChoice == Choice.Rock && computerChoice == Choice.Scissors)
            return RoundWinner.Human;
        
        if (humanChoice == Choice.Paper && computerChoice == Choice.Rock)
            return RoundWinner.Human;
        
        if (humanChoice == Choice.Scissors && computerChoice == Choice.Paper)
            return RoundWinner.Human;
        
        return RoundWinner.Computer;
    }
    
    
    private static string GetChoiceName(Choice choice)
    {
        return choice switch
        {
            Choice.Rock => "Kivi",
            Choice.Paper => "Paperi",
            Choice.Scissors => "Sakset",
            _ => ""
        };
    }
}