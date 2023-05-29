using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemsList
{
    private List<InventoryItem> _items;
    public List<InventoryItem> Items
    {
        get { return _items; }
    }

    public void AddItem(InventoryItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        _items.Remove(item);
    }
}
