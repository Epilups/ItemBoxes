namespace ItemBoxes.Data;

public class Box
{
    public string  Id { get; set; }
    
    public string Name { get; set; }

    public string ImageLink { get; set; }

    public List<Item> Items { get; set; } = new();

}