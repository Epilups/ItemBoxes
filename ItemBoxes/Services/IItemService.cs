using ItemBoxes.Data;

namespace ItemBoxes.Services;

public interface IItemService
{
    List<Item> GetItems(string boxId);
    void AddItem(Item item);

}