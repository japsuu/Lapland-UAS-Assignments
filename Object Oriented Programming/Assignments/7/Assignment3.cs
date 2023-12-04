using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ObjectOrientedProgramming.Assignments._7;

/// <summary>
/// Tehtävänäsi on toteuttaa ohjelman joka hyödyntää REST/JSON api tiedon hakemiseen.
///
/// Pisteytys
/// - Rajapinnan valinta ja hyödyntäminen 1pst
/// - Vikatilanteisiin varautuminen 1pst
/// - JSON ⇔ Olio mappauksen tekeminen 1pst
/// - Yleinen sovelluksen logiikka 1pst
/// - Olio-ohjelmoinnin periaatteita( luokkia, kapselointia, periytymistä ja metodien ylikirjoittamista/peittämistä ) 2pst
/// </summary>
public class Assignment3 : ISchoolAssignment
{
    /// <summary>
    /// Haetaan tiejakson "Hämeenlinnanväylä, Mannerheimintie 3.101" (id 00003_101_00000_1_0) ajantasaiset kelitiedot.
    /// Lisätietoa:
    /// - https://www.digitraffic.fi/tieliikenne/#tiejaksojen-keliennusteet
    /// - https://tie.digitraffic.fi/api/weather/v1/forecast-sections
    /// </summary>
    private const string API_URI = "https://tie.digitraffic.fi/api/weather/v1/forecast-sections/00003_101_00000_1_0/forecasts";
    
    
    public void Run(string[] args)
    {
        Console.WriteLine("Haetaan dataa...\n");

        RoadWeatherApiResponse? response = GetApiResponse();

        if (response?.Forecasts == null)
            return;
        
        Console.WriteLine("Hämeenlinnanväylä, Mannerheimintie 3 tiejakson kelitiedot:");
        foreach (Forecast forecast in response.Forecasts)
            Console.WriteLine(forecast);
    }


    private static RoadWeatherApiResponse? GetApiResponse()
    {
        HttpClientHandler handler = new();
        handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        HttpClient client = new(handler);

        try
        {
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("OOP-Assignments", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = client.GetAsync(API_URI).Result;

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            RoadWeatherApiResponse? response = JsonSerializer.Deserialize<RoadWeatherApiResponse>(json);
            
            if (response != null)
                return response;
            
            Console.WriteLine("Deserialisointi epäonnistui. Onko API:n data muuttunut?");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Virhe ladatessa dataa: {e.Message}");
            return null;
        }
    }
}


public class RoadWeatherApiResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("forecasts")]
    public List<Forecast>? Forecasts { get; set; }
    
    [JsonPropertyName("dataUpdatedTime")]
    public DateTime DataUpdatedTime { get; set; }
    
    
    public override string ToString()
    {
        StringBuilder builder = new();
        
        int fCount = Forecasts?.Count ?? 0;
        builder.AppendLine($"Id: {Id}");
        builder.AppendLine($"Tiedot: {fCount}");
        builder.AppendLine($"Päivitetty: {DataUpdatedTime}");
        
        return builder.ToString();
    }
}


public class Forecast
{
    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }
    
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("forecastName")]
    public string? ForecastName { get; set; }
    
    [JsonPropertyName("daylight")]
    public bool? Daylight { get; set; }
    
    [JsonPropertyName("roadTemperature")]
    public double? RoadTemperature { get; set; }
    
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }
    
    [JsonPropertyName("windSpeed")]
    public double? WindSpeed { get; set; }
    
    [JsonPropertyName("windDirection")]
    public double? WindDirection { get; set; }
    
    [JsonPropertyName("overallRoadCondition")]
    public string? OverallRoadCondition { get; set; }
    
    [JsonPropertyName("weatherSymbol")]
    public string? WeatherSymbol { get; set; }
    
    [JsonPropertyName("reliability")]
    public string? Reliability { get; set; }
    
    [JsonPropertyName("forecastConditionReason")]
    public ForecastConditionReason? ForecastConditionReason { get; set; }
    
    [JsonPropertyName("dataUpdatedTime")]
    public DateTime? DataUpdatedTime { get; set; }
    
    
    public override string ToString()
    {
        StringBuilder builder = new();

        bool isObservation = Type == "OBSERVATION";
        string title = "--- Keliennuste";
        string name = $"Ennuste {ForecastName} päähän";
        if (isObservation)
        {
            title = "--- Kelihavainto ---";
            name = $"Havainto {ForecastName} sitten";
        }
        
        builder.AppendLine($"{title} {Time} ---");
        builder.AppendLine(name);
        builder.AppendLine($"Aurinko laskenut: {!Daylight}");
        builder.AppendLine($"Tien lämpötila: {RoadTemperature}");
        builder.AppendLine($"Ilman lämpötila: {Temperature}");
        builder.AppendLine($"Tuulen nopeus: {WindSpeed} (suuntaan {WindDirection})");
        builder.AppendLine($"Tien yleinen kunto: {OverallRoadCondition}");
        if (!isObservation)
        {
            builder.AppendLine($"Syy (sateen tila): {ForecastConditionReason?.PrecipitationCondition}");
            builder.AppendLine($"Syy (tien kunto): {ForecastConditionReason?.RoadCondition}");
        }
        builder.AppendLine($"Päivitetty: {DataUpdatedTime}");
        
        return builder.ToString();
    }
}


public class ForecastConditionReason
{
    [JsonPropertyName("precipitationCondition")]
    public string? PrecipitationCondition { get; set; }
    
    [JsonPropertyName("roadCondition")]
    public string? RoadCondition { get; set; }
}