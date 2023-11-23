namespace ObjectOrientedProgramming.Assignments._4;

/// <summary>
/// Suunnittele ja luo seuraavanlainen Car-luokka:
/// Jäsenmuuttujat ( ja mahdollisuus asettaa arvoja ):
/// - brand
/// - model
/// - color
/// - engine
/// - currentSpeed
/// Metodit
/// - start, käynnistää auton
/// - accelerate, kiihdyttää autoa
/// - brake, jarruttaa autoa.
/// - lisäksi halutessasi voit tehdä ToString metodin joka tulostaa luokan jäsenmuuttujien arvot helpottamaan debuggausta.
///     ( tämän puuttumisesta ei vähennetä pisteitä )
/// Tee pääohjelma jossa luot Car olion sekä käytät olion toimintoja hyväksesi, niin että käynnistät auton ja kiihdytät nopeutta.
/// Voit halutessasi lisätä ominaisuuksia ja/tai toimintoja luokkaan.
/// </summary>
public class Assignment2 : ISchoolAssignment
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Engine Engine { get; set; }
        public int CurrentSpeed { get; private set; }

        public Car(string brand, string model, string color, Engine engine)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Engine = engine;
        }

        public void Start()
        {
            Console.WriteLine($"Käynnistetään {Brand} {Model} jossa {Engine.Cylinders} sylinteriä ja {Engine.HorsePower} hevosvoimaa.");
        }

        public void Accelerate(int speed)
        {
            CurrentSpeed += speed;
            Console.WriteLine($"Kiihdytetään vauhtiin {CurrentSpeed} km/h");
        }

        public void Brake(int speed)
        {
            CurrentSpeed -= speed;
            Console.WriteLine($"Jarrutetaan vauhtiin {CurrentSpeed} km/h");
        }
    }

    public class Engine
    {
        public readonly int Cylinders;
        public readonly int HorsePower;

        public Engine(int cylinders, int horsePower)
        {
            Cylinders = cylinders;
            HorsePower = horsePower;
        }
    }

    public void Run(string[] args)
    {
        Car car = new("Toyota", "Corolla", "Black", new Engine(4, 150));
        car.Start();
        car.Accelerate(50);
        car.Brake(20);
        Console.WriteLine($"Auto kulkee nyt vauhtia {car.CurrentSpeed} km/h.");
    }
}