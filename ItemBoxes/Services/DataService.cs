using System.Text.Json;
using ItemBoxes.Data;

namespace ItemBoxes.Services;

public class DataService
{
    private const string FilePath = "data.json";

    public List<Box> GetBoxes()
    {
        if (File.Exists(FilePath))
        {
            try
            {
                var json = File.ReadAllText(FilePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<Box>>(json) ?? new List<Box>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
        }

        return new List<Box>();
    }

    public void SaveBoxes(List<Box> boxes)
    {
        var json = JsonSerializer.Serialize(boxes);
        File.WriteAllText(FilePath, json);
    }
    
}
