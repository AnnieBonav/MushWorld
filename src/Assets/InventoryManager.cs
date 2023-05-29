using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventoryItemsList _inventoryItems;
    [SerializeField] private GameObject _smallInventoryUI;

    [SerializeField] private Grabbable _testBigMush;
    [SerializeField] private Grabbable _testSmallMush;
    [SerializeField] private GameObject _inventoryItemPrefab;

    [SerializeField] private List<InventorySlot> _inventorySlots;


    private void Awake()
    {
        _inventorySlots = new List<InventorySlot>();
        _inventoryItems = new InventoryItemsList();

        for(int i = 0; i < _smallInventoryUI.transform.childCount; i++)
        {
            _inventorySlots.Add(_smallInventoryUI.transform.GetChild(i).GetComponent<InventorySlot>());
        }
    }

    public void TestAddSmall()
    {
        print("Add small");
        AddItem(_testSmallMush);
    }

    public void AddItem(Grabbable grabbable)
    {

        /* GameObject newInventoryItem = Instantiate(_inventoryItemPrefab, EventSystem.current.currentSelectedGameObject.transform);
        InventoryItem inventoryItem = newInventoryItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item); // The item will be sent by the mushroom that was grabbed
        _inventoryItems.AddItem(inventoryItem);*/

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

    private void SpawnNewItem(Grabbable grabbable, InventorySlot slot)
    {
        GameObject newItem = Instantiate(_inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.Initialize(grabbable);
    }

    public void TestAddBig()
    {
        print("Add big");
        AddItem(_testBigMush);
    }
}
