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
/// </summary>
public class Assignment3 : ISchoolAssignment
{
    public class Thermostat
    {
        private int _targetTemperature;
        private int _currentTemperature;
        private bool _isOn;

        public Thermostat(int targetTemperature, int currentTemperature, bool isOn)
        {
            _targetTemperature = targetTemperature;
            _currentTemperature = currentTemperature;
            _isOn = isOn;
        }

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Termostaatti päälle.");
        }

        public void TurnOff()
        {
            _isOn = false;
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
        Thermostat thermostat = new Thermostat(21, 18, false);
        thermostat.TurnOn();
        thermostat.SetCurrentTemperature(18);
        thermostat.SetTargetTemperature(21);

        while (true)
        {
            int currentTemperature = thermostat.GetCurrentTemperature();
            int targetTemperature = thermostat.GetTargetTemperature();

            if (currentTemperature >= targetTemperature)
            {
                thermostat.TurnOff();
                Console.WriteLine($"Lämpötila on saavutettu. Lämpötila on {currentTemperature} astetta.");
                return;
            }
            
            Console.WriteLine($"Lämpötila on {currentTemperature} astetta. Lämpötila nousee yhdellä asteella.");
            thermostat.SetCurrentTemperature(currentTemperature + 1);
            Thread.Sleep(1000);
        }
    }
}