using ItemBoxes.Data;

namespace ItemBoxes.Services;

public class BoxService : IBoxService
{
    private readonly DataService _dataService;

    public BoxService(DataService dataService)
    {
        _dataService = dataService;
    }
    
    public List<Box> GetBoxes()
    {
        return _dataService.GetBoxes();
    }

    public void AddBox(Box box)
    {
        var boxes = GetBoxes();
        box.Id = Guid.NewGuid().ToString();
        boxes.Add(box);
        _dataService.SaveBoxes(boxes);
    }

    public void DeleteItem(string boxId, string itemName)
    {
        var boxes = GetBoxes();
        var box = boxes.FirstOrDefault(b => b.Id == boxId);
        
        if (box != null)
        {
            var item = box.Items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                box.Items.Remove(item);
                SaveBoxes(boxes);
            }
        }
    }

    public void DeleteBox(string boxId)
    {
        var boxes = GetBoxes();
        var box = boxes.FirstOrDefault(b => b.Id == boxId);

        if (box != null)
        {
            boxes.Remove(box);
            SaveBoxes(boxes);
        }
    }

    public void SaveBoxes(List<Box> boxes)
    {
        _dataService.SaveBoxes(boxes);
    }
}