using ItemBoxes.Data;

namespace ItemBoxes.Services;

public class ItemService : IItemService
{
    private readonly DataService _dataService;

    public ItemService(DataService dataService)
    {
        _dataService = dataService;
    }
    

    public List<Item> GetItems(string boxId)
    {
        var boxes = _dataService.GetBoxes();
        return boxes.SelectMany(b => b.Items).Where(i => i.BoxId == boxId).ToList();
    }

    public void AddItem(Item item)
    {
        var boxes = _dataService.GetBoxes();
        var box = boxes.FirstOrDefault(b => b.Id == item.BoxId);

        if (box != null)
        {
            box.Items.Add(item);
            _dataService.SaveBoxes(boxes);
        }
    }
}