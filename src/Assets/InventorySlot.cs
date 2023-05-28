using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySlot : MonoBehaviour
{
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