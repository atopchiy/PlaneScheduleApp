using System.Text.Json;

namespace PlaneScheduleApp.Helpers;

public static class JsonFileParser
{
    public static T? Parse<T>(this string data)
    {
        try
        {
            var parsedData = JsonSerializer.Deserialize<T>(data);
            return parsedData;
        }
        catch (Exception)
        {
            Console.WriteLine("Could not deserialize provided data");
            throw;
        }
    }
}