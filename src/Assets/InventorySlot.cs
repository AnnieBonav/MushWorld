using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        // Listens to UI event that says that something was selected to see if it was selected
        _button = GetComponent<Button>();
        UIHandler.GrabbedInventorySlot += CheckIfGrabbed;
    }

    private void CheckIfGrabbed(GameObject itemGrabbed)
    {
        if(gameObject == itemGrabbed)
        {
            print("I was grabbed: " + itemGrabbed.transform.name);
            InventoryItem temp = GetComponentInChildren<InventoryItem>();
            if(temp != null)
            {
                print("Ask child to instantiate mushroom");
                temp.InstantiateMushroom();
            }
        }
    }

    public void ActivateSelection()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void DeactivateSelection()
    {
        // _button.OnDeselect();
    }

    /*public override void OnDrop(PointerEventData eventData)
    {
        _eventData = eventData;
        print("OnDrop called");
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.ParentAfterDrag = transform;
        }
    }

    public void PlaceItem()
    {
        print("OnDrop called");
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = _eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.ParentAfterDrag = transform;
        }
    }*/
}

/*  //Working with old imput system
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        print("OnDrop called");
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.ParentAfterDrag = transform;
        }
    }
}
*/