using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _amountText;
    private Grabbable _grabbable;

    public Grabbable grabbable
    {
        get { return _grabbable; }
    }

    [HideInInspector] public Transform ParentAfterDrag;

    public void Initialize(Grabbable grabbable)
    {
        _grabbable = grabbable;
        _image.sprite = _grabbable.UISprite;
        UpdateAmount(1);
    }

    public void InstantiateMushroom()
    {
        print("I am a child instantiating a mushroom");
        Instantiate(_grabbable, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void UpdateAmount(int newAmount)
    {
        print("New amount: " + newAmount);
        _amountText.text = newAmount.ToString();
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