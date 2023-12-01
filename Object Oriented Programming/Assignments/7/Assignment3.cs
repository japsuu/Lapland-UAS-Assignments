using System.Xml;

namespace ObjectOrientedProgramming.Assignments._7;

public class Assignment3 : ISchoolAssignment
{
    private const string API_URI = "https://alerts.fmi.fi/cap/feed/rss_fi-FI.rss";
    
    
    public void Run(string[] args)
    {
        Console.WriteLine("Haetaan dataa...\n");

        List<string> alerts = GetAlerts();
        
        foreach (string alert in alerts)
        {
            Console.WriteLine(alert);
        }
    }


    private static List<string> GetAlerts()
    {
        List<string> result = new();
        XmlDocument alerts = new();

        try
        {
            alerts.Load(API_URI);
        }
        catch (System.Net.WebException)
        {
            Console.WriteLine("Virhe: Ei yhteyttä palvelimeen");
            return result;
        }

        XmlNodeList results = alerts.GetElementsByTagName("item");
        XmlNodeList description = alerts.GetElementsByTagName("description");
        
        result.Add(description[0]?.InnerText + ":");
        
        for (int i = 0; i < results.Count; i++)
        {
            XmlNodeList? contents = results[i]?.ChildNodes;

            if (contents == null)
                continue;
            
            for (int j = 0; j < contents.Count; j++)
            {
                // Poimitaan vain title -elementit
                if (!contents[j]!.Name.Contains("title"))
                    continue;
                
                result.Add($"\n{contents[j]!.InnerText}");
                
                // Poimitaan varoituksen lisätiedot
                string info = contents[j + 2]!.InnerText[(contents[j + 2]!.InnerText.IndexOf(' ') + 1)..];
                result.Add($"Lisätietoa: {info}\n");
            }
        }

        return result;
    }
}