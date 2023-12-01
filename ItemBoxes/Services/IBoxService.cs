using ItemBoxes.Data;

namespace ItemBoxes.Services;

public interface IBoxService
{
    List<Box> GetBoxes();
    void AddBox(Box box);
    void DeleteBox(string boxId);
    void DeleteItem(string boxId, string itemName);
    void SaveBoxes(List<Box> boxes);
}