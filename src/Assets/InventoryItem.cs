using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _image;
    private Item _item;

    [HideInInspector] public Transform ParentAfterDrag;

    public void InitializeItem(Item item)
    {
        _item = item;
        _image.sprite = _item.image;
    }

    public void InstantiateMushroom()
    {
        print("I am a child instantiating a mushroom");
        GameObject temp = _item.itemPrefab;
        Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
    }

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        print("Began drag");
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("ended drag");
        transform.SetParent(ParentAfterDrag);
        _image.raycastTarget = true;
    }*/
}


/*
// working

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] private Image _image;
    [SerializeField] private Item _item;

    [HideInInspector] public Transform ParentAfterDrag;

    /*
    private void Start()
    {
        InitializeItem(_item);
    }

    public void InitializeItem(Item newItem)
    {
        _image.sprite = newItem.image;
    }

public void OnBeginDrag(PointerEventData eventData)
{
    print("Began drag");
    ParentAfterDrag = transform.parent;
    transform.SetParent(transform.root);
    transform.SetAsLastSibling();
    _image.raycastTarget = false;
}

public void OnDrag(PointerEventData eventData)
{
    transform.position = Input.mousePosition;
}

public void OnEndDrag(PointerEventData eventData)
{
    print("ended drag");
    transform.SetParent(ParentAfterDrag);
    _image.raycastTarget = true;
}
}

*/