using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _bigInventoryUI;
    [SerializeField] private GameObject _backgroundUI;
    [SerializeField] private GameObject _smallInventoryUI;

    private bool _bigInventoryOpened = false;
    private bool _smallInventoryActive = false;

    private int _selectedSlot = 0;

    [SerializeField] private List<InventorySlot> _inventorySlots; // Duplicated from InventoryManager, good to have to make it work

    private void Awake()
    {
        _bigInventoryUI.SetActive(false);
        _backgroundUI.SetActive(false);
        // Fill the slots with children of inventory
        for (int i = 0; i < _smallInventoryUI.transform.childCount; i++)
        {
            _inventorySlots.Add(_smallInventoryUI.transform.GetChild(i).GetComponent<InventorySlot>());
        }
    }

    private void Start()
    {
        _inventorySlots[_selectedSlot].ActivateSelection();
    }

    // Switches between selected slots in loop
    // TODO: when something else is selected (oustide) this is deselected. Maybe that can be prettier? It does not break tho.
    // TODO: would be nice to modify how the inventory looks like when stuff is being moved around
    // TODO: Add moving inventory items around slots
    public void OnSwitchSelectedItem(InputValue value)
    {
        int inputValue = (int)value.Get<float>();
        if(inputValue == 1 && _selectedSlot + 1 >= _inventorySlots.Count)
        {
            _selectedSlot = 0;
        }
        else if(inputValue == -1 && _selectedSlot -1 < 0)
        {
            _selectedSlot = _inventorySlots.Count - 1;
        }
        else
        {
            _selectedSlot += inputValue;
        }
        _inventorySlots[_selectedSlot].ActivateSelection();
    }

    public void OnActivateInventoryWindow(InputValue value)
    {
        if (_bigInventoryOpened)
        {
            _bigInventoryOpened = false;
        }
        else
        {
            _bigInventoryOpened = true;
        }
        _bigInventoryUI.SetActive(_bigInventoryOpened);
        _backgroundUI.SetActive(_bigInventoryOpened);
    }
}
