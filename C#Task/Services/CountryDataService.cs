using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class CountryData
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public double[] Latlng { get; set; }
    public double Area { get; set; }
    public long Population { get; set; }
}

public class CountryInfo
{
    public string Name { get; set; }
    public CountryData CountryData { get; set; }
}

public class CountryDataService
{
    private readonly HttpClient _client;

    public CountryDataService()
    {
        _client = new HttpClient();
    }

    public async Task GenerateCountryDataFiles()
    {
        try
        {
            Console.WriteLine("Starting to fetch data from the API...");
            string apiUrl = "https://restcountries.com/v3.1/all";
            var response = await _client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error fetching data: {response.StatusCode}");
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Received empty response from API.");
                return;
            }

           
            var countries = JsonConvert.DeserializeObject<CountryInfo[]>(responseBody);
            if (countries == null || countries.Length == 0)
            {
                Console.WriteLine("No country data available.");
                return;
            }
            Console.WriteLine("Data deserialized successfully...");

            foreach (var country in countries)
            {
                string fileName = $"{country.Name}.txt";
                string content = $"Region: {country.CountryData.Region}\n" +
                                 $"Subregion: {country.CountryData.Subregion}\n" +
                                 $"Latlng: {string.Join(", ", country.CountryData.Latlng)}\n" +
                                 $"Area: {country.CountryData.Area} km²\n" +
                                 $"Population: {country.CountryData.Population}\n";

                try
                {
                    await File.WriteAllTextAsync(fileName, content);
                    Console.WriteLine($"File created for {country.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing file for {country.Name}: {ex.Message}");
                }
            }

            Console.WriteLine("Country data files generation completed.");
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}