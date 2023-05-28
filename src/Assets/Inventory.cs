using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Grabbable> _grabbedItems;

    private void Awake()
    {
        _grabbedItems = new List<Grabbable>();
        Grabbable.CollectedGrabbable += AddInventory;
    }

    private void AddInventory(Grabbable grabable)
    {
        _grabbedItems.Add(grabable);
        print("Current number of items: " + _grabbedItems.Count);
    }
}
