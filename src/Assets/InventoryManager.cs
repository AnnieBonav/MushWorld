using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private CollectedGrabbables _collectedGrabbables;
    [SerializeField] private GameObject _smallInventoryUI;

    [SerializeField] private Grabbable _testBigMush;
    [SerializeField] private Grabbable _testSmallMush;
    [SerializeField] private GameObject _inventoryItemPrefab;

    [SerializeField] private List<InventorySlot> _inventorySlots;


    private void Awake()
    {
        _inventorySlots = new List<InventorySlot>();
        _collectedGrabbables = new CollectedGrabbables();
        
        // Fill the slots with children of inventory
        for(int i = 0; i < _smallInventoryUI.transform.childCount; i++)
        {
            _inventorySlots.Add(_smallInventoryUI.transform.GetChild(i).GetComponent<InventorySlot>());
        }

        Grabbable.CollectedGrabbable += AddItem;

    }

    // To add an InventoryItem, I collected a grabbable
    public void AddItem(Grabbable grabbable)
    {
        // If amount is -1, it did not exist. If it is anything else, it existed and now we only need to add
        int currentAmount = _collectedGrabbables.Add(grabbable);

        if(currentAmount <= 0)
        {
            print("Spawning new item");
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                InventorySlot slot = _inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                {
                    SpawnNewItem(grabbable, slot);
                    return;
                }
            }
        }

        print("Updating amount");
        for(int i = 0; i < _inventorySlots.Count; i++)
        {
            InventorySlot slot = _inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(grabbable == itemInSlot.grabbable)
            {
                itemInSlot.UpdateAmount(currentAmount);
            }
        }
        // If item did exist, then add to the number

        
    }

    private void SpawnNewItem(Grabbable collectedGrabbable, InventorySlot slot)
    {
        GameObject newItem = Instantiate(_inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.Initialize(collectedGrabbable);

        
    }

    public void TestAddBig()
    {
        AddItem(_testBigMush);
    }

    public void TestAddSmall()
    {
        AddItem(_testSmallMush);
    }
}
