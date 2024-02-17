using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// REMEMBER Inventory Slot has NO Grabbable, it has an InventoryItem that contains the grabbable
public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _bigInventoryUI;
    [SerializeField] private GameObject _backgroundUI;
    [SerializeField] private GameObject _smallInventoryUI;
    [SerializeField] private List<InventorySlot> _inventorySlots; // Duplicated from InventoryManager, good to have to make it work

    private bool _bigInventoryOpened = false;
    // private bool _smallInventoryActive = false; // TODO: Implement having active/inactive small inventory

    private int _selectedSlot = 0;
    public Grabbable SelectedGrabbable; // TODO: Change so the architecture is better. This is public so the Eyes visualizer can use it to spawn something  Should the inventory manager spawn it?


    private void Awake()
    {
        _bigInventoryUI.SetActive(false);
        _backgroundUI.SetActive(false);
        // Fill the slots with children of inventory
        for (int i = 0; i < _smallInventoryUI.transform.childCount; i++)
        {
            _inventorySlots.Add(_smallInventoryUI.transform.GetChild(i).GetComponent<InventorySlot>());
        }

        InventoryManager.ConsumedAllCollectibles += RemoveCollectible;
    }

    private void RemoveCollectible()
    {
        SelectedGrabbable = null; // TODO: Should like not exist and I should access the Selected grabbable from the inventory manager or just handle everything with observable?
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
        if(inputValue != 0)
        {
            AkSoundEngine.PostEvent("Play_HoverButton", gameObject);
        }

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
        InventoryItem inventoryItem = _inventorySlots[_selectedSlot].GetComponentInChildren<InventoryItem>();
        if(inventoryItem != null)
        {
            SelectedGrabbable = inventoryItem.grabbable; // Gets the grabable sop the eyes visualizer can use it
            // TODO: Make the architecture better
        }
        else
        {
            SelectedGrabbable = null; // If there is nothing on the new selected slot, then the prefab is removed (if not, the old one remains selected)
        }
        // TODO: Because the selected item is when you change selection, if you add an element on a slot you were already in you do not recognize there is an element. CHANGE ARCHITECTURE
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
