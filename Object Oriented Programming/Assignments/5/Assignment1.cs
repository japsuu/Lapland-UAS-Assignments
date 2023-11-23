namespace ObjectOrientedProgramming.Assignments._5;

/// <summary>
/// Tehtävänäsi on toteuttaa auton logiikka, pohjana voi käyttää 4.2 toteutusta.
/// Suunnittele ja toteuta tarvittavat jäsenmuuttujat jolla kontrolloit auton tilaa,
/// niin että alla olevista metodeista tulee järkevä kokonaisuus.
/// Esim. ennen kiihdytystä tarkistetaan että onko tarpeeksi polttoainetta ja moottori käynnissä.
/// Tässä tehtävässä kannattaa miettiä miten auto oikeasti toimii.
///
/// Julkiset metodit:
/// startCar,
/// accelerate,
/// brake,
/// maxSpeed,
/// stopEngine,
/// lockDoor.
/// Yksityiset metodit:
/// checkFuel,
/// engineStarted,
/// doorsOpen.
/// Pääohjelmassa luo auto olio, kiihdytä autoa toistolausekkeessa niin kauaa että maksimi nopeus on saavutettu jonka jälkeen jarruta,
/// sammuta moottori ja laita ovet lukkoon.
/// Maksiminopeuden voit itse määrittää.
/// Kiinnitä huomiota siihen, että autoon liittyvät tiedot on tallessa auto oliossa.
/// 
/// </summary>
public class Assignment1 : ISchoolAssignment
{
    public class Car
    {
        public const int MAX_SPEED = 90;

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public Engine Engine { get; private set; }

        public int CurrentSpeed { get; private set; }
        public int Fuel { get; private set; }
        public bool IsEngineRunning { get; private set; }
        public bool AreDoorsLocked { get; private set; }
        public bool AreDoorsOpen { get; private set; }


        public Car(string brand, string model, string color, Engine engine)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Engine = engine;
            Fuel = 100;
        }


        public bool TryStartEngine()
        {
            if (!CheckHasFuel())
            {
                Console.WriteLine("Ei voida käynnistää autoa koska polttoainetta ei ole jäljellä.");
                return false;
            }

            Console.WriteLine($"Käynnistetään {Brand} {Model} jossa {Engine.Cylinders} sylinteriä ja {Engine.HorsePower} hevosvoimaa.");
            IsEngineRunning = true;
            return true;
        }


        public void StopEngine()
        {
            Console.WriteLine($"Sammutetaan {Brand} {Model}.");
            IsEngineRunning = false;
        }


        public bool TryAccelerate(int speed)
        {
            if (!CheckIsEngineStarted())
            {
                Console.WriteLine("Ei voida kiihdyttää koska moottori ei ole käynnissä.");
                return false;
            }

            if (!CheckHasFuel())
            {
                Console.WriteLine("Ei voida kiihdyttää koska polttoainetta ei ole jäljellä.");
                return false;
            }

            if (!CheckAreDoorsClosed())
            {
                Console.WriteLine("Ei voida kiihdyttää koska ovet ovat auki.");
                return false;
            }

            CurrentSpeed += speed;
            Fuel -= speed;
            Console.WriteLine($"Kiihdytetään vauhtiin {CurrentSpeed} km/h");

            return true;
        }


        public void Brake(int speed)
        {
            CurrentSpeed -= Math.Max(speed, 0);
            Console.WriteLine($"Jarrutetaan vauhtiin {CurrentSpeed} km/h");
        }


        public void LockDoors()
        {
            if (!CheckAreDoorsClosed())
            {
                Console.WriteLine("Ei voida lukita ovia koska ovet ovat auki.");
                return;
            }

            Console.WriteLine($"Lukitaan {Brand} {Model}.");
            AreDoorsLocked = true;
        }


        public void UnlockDoors()
        {
            Console.WriteLine($"Avataan {Brand} {Model}.");
            AreDoorsLocked = false;
        }


        public void OpenDoors()
        {
            Console.WriteLine($"Avataan ovet.");
            AreDoorsOpen = true;
        }


        public void CloseDoors()
        {
            Console.WriteLine($"Suljetaan ovet.");
            AreDoorsOpen = false;
        }


        private bool CheckIsEngineStarted() => IsEngineRunning;
        private bool CheckAreDoorsClosed() => !AreDoorsOpen;
        private bool CheckHasFuel() => Fuel > 0;
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

        // Avataan ovet
        car.UnlockDoors();

        // Astutaan autoon
        car.OpenDoors();
        car.CloseDoors();

        // Käynnistetään moottori
        if (!car.TryStartEngine())
            return;

        // Kiihdytetään autoa kunnes maksiminopeus on saavutettu
        while (car.CurrentSpeed < Car.MAX_SPEED)

            // Jos kiihdytys ei onnistu (bensa loppui), pysäytetään auto
            if (!car.TryAccelerate(10))
            {
                car.StopEngine();
                Console.WriteLine("Bensa loppui kesken kiihdytyksen!");
                break;
            }

        bool reachedMaxSpeed = car.CurrentSpeed >= Car.MAX_SPEED;

        // Jarrutetaan
        car.Brake(car.CurrentSpeed);

        if (reachedMaxSpeed)
            car.StopEngine();

        // Astutaan ulos ja lukitaan ovet
        car.OpenDoors();
        car.CloseDoors();
        car.LockDoors();
    }
}