namespace ObjectOrientedProgramming.Assignments.Test;

/// <summary>
/// Tehtävänäsi on toteuttaa yksinkertainen pelihahmojen tietojen tallentamiseen liittyvä logiikka. 
/// 
/// Pelissä tulee olemaan kolme erilaista hahmoa: Warrior, Worker ja Merchant.
/// Jokaiselle hahmolle yhteisiä tietoja ovat Name ja Age, näitä varten toteuta kantaluokka ja mahdollisuus asettaa arvot. Lisäksi:
///     Warrior oliolle pitää pystyä antamaan double tyyppinen power tieto
///     Worker oliolle pitää pystyä antamaan string tyyppinen workEthic tieto
///     Merchant oliolle pitää pystyä antamaan double tyyppinen profit tieto.
/// 
/// Toteuta jokaiselle hahmolle action metodi niin, että
///     Warrior luokan action metodi tulostaa: attack
///     Worker luokan action metodi tulostaa: working
///     Merchant luokan action metodi tulostaa: trading
/// Pääohjelmassa:
///     luo jokaisesta hahmosta yksi olio
///     syötä oliolle tietoja, tiedot voivat olla kuvitteellisia ( tietojen sisältö ei vaikuta pisteytykseen )
///     lisää hahmot listaan
///     käy lista läpi ja tulosta listan jokainen hahmo
///     kutsu action metodia jokaiselle hahmolle listan läpikäynnin yhteydessä
/// </summary>


public abstract class Character
{
    public readonly string Name;
    public readonly int Age;


    protected Character(string name, int age)
    {
        Name = name;
        Age = age;
    }


    public abstract void Action();
    
    
    public override string ToString() => $"I am {Name} ({Age} years old)";
}


public class Warrior : Character
{
    public readonly double Power;


    public Warrior(string name, int age, double power) : base(name, age) => Power = power;


    public override void Action() => Console.WriteLine("attack");
    
    
    public override string ToString() => $"{base.ToString()}, my power is {Power}";
}


public class Worker : Character
{
    public readonly string WorkEthic;
    
    
    public Worker(string name, int age, string workEthic) : base(name, age) => WorkEthic = workEthic;


    public override void Action() => Console.WriteLine("working");
    
    
    public override string ToString() => $"{base.ToString()}, my work ethic is {WorkEthic}";
}


public class Merchant : Character
{
    public readonly double Profit;
    
    
    public Merchant(string name, int age, double profit) : base(name, age) => Profit = profit;


    public override void Action() => Console.WriteLine("trading");
    
    
    public override string ToString() => $"{base.ToString()}, my profit is {Profit} euros";
}


public class GameCharacterLogic : ISchoolAssignment
{
    public void Run(string[] args)
    {
        List<Character> characters = new()
        {
            new Warrior("Warrior", 19, 75),
            new Worker("Worker", 24, "Hard"),
            new Merchant("Merchant", 63, 1005)
        };

        foreach (Character character in characters)
        {
            Console.WriteLine(character);
            character.Action();
            Console.WriteLine();
        }
    }
}