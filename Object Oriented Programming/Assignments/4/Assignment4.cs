namespace ObjectOrientedProgramming.Assignments._4;

/// <summary>
/// Suunnittele ja toteuta lattialämmitystermostaatin toiminta.
/// Termostaatti pitää pystyä laittamaan päälle, tavoitelämpötilaa säätämään ja tarkistamaan mikä on tämän hetken lämpötila.
/// Toteuta pääohjelmassa logiikka Termostaatti-luokan alustamiselle sekä termostaatin säätämiselle.
/// Säätäminen tapahtuu Termostaatti luokan metodeita hyödyntäen.
/// Tässä tehtävässä voit pääohjelmassa tehdä säätämiseen tarvittavan logiikan.
/// 
/// Esimerkiksi.
/// - Tavoitelämpötila on 21 astetta
/// - Nykyinen lämpötila on 18 astetta
/// - Lämpötilaa pitää nostaa 3 astetta.
///
/// Muokkaa Tehtävä 3 niin että kysyt käyttäjältä nykyisen lämpötilan ja käyttäjän antaman arvon mukaan säädät tavoitelämpötilaa,
/// joko ylös- tai alaspäin.
/// Pääohjelmassa tulee käyttää silmukkaa lämpötilan säätämiseen.
/// </summary>
public class Assignment4 : ISchoolAssignment
{
    public class Thermostat
    {
        public bool IsOn { get; private set; }
        
        private int _targetTemperature;
        private int _currentTemperature;

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Termostaatti päälle.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Termostaatti pois päältä.");
        }

        public void SetTargetTemperature(int targetTemperature)
        {
            _targetTemperature = targetTemperature;
            Console.WriteLine($"Tavoitelämpötila asetettu {_targetTemperature} astetta.");
        }

        public void SetCurrentTemperature(int currentTemperature)
        {
            _currentTemperature = currentTemperature;
            Console.WriteLine($"Nykyinen lämpötila asetettu {_currentTemperature} astetta.");
        }

        public int GetCurrentTemperature()
        {
            return _currentTemperature;
        }

        public int GetTargetTemperature()
        {
            return _targetTemperature;
        }
    }
    
    public void Run(string[] args)
    {
        Thermostat thermostat = new Thermostat();

        Console.WriteLine("Anna nykyinen lämpötila:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int currentTemperature))
            thermostat.SetCurrentTemperature(currentTemperature);
        else
            Console.WriteLine("Väärä lämpötila!");
        
        Console.WriteLine("Anna tavoitelämpötila:");
        input = Console.ReadLine();
        if (int.TryParse(input, out int targetTemperature))
            thermostat.SetTargetTemperature(targetTemperature);
        else
            Console.WriteLine("Väärä lämpötila!");
        
        thermostat.TurnOn();
        
        while (true)
        {
            currentTemperature = thermostat.GetCurrentTemperature();
            targetTemperature = thermostat.GetTargetTemperature();
            
            if (currentTemperature == targetTemperature)
            {
                Console.WriteLine("Tavoitelämpötila on saavutettu.");
                thermostat.TurnOff();
                return;
            }
            
            if (currentTemperature < targetTemperature)
            {
                Console.WriteLine("Lämpötila nousee...");
                thermostat.SetCurrentTemperature(currentTemperature + 1);
            }
            else
            {
                Console.WriteLine("Lämpötila laskee...");
                thermostat.SetCurrentTemperature(currentTemperature - 1);
            }
            
            Thread.Sleep(1000);
        }
    }
}