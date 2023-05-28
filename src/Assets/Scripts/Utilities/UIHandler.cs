using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static event Action<GameObject> GrabbedInventorySlot;

    [SerializeField] private GameObject _mainInventoryUI;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private InputAction _grabAndDrag;
    [SerializeField] private bool _inventoryIsActive = false;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private GameObject _initialSelectedItem;
    private GameObject _lastSelectedItem;

    private bool _inventoryOpened = false;
    private int _score = 0;


    public void OnActivateInventory(InputValue value)
    {
        print("Activating inventory");
    }

    public void OnGrab(InputValue value)
    {
        // Check if the selected game object has the Inventory Slot class, if yes, then emit an event so slot classes check if they were selected
        InventorySlot temp = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>();
        if ( temp != null)
        {
            GrabbedInventorySlot?.Invoke(temp.gameObject);
        }
    }

    public void OnActivateInventoryWindow(InputValue value)
    {
        if (_inventoryOpened)
        {
            _inventoryOpened = false;
        }
        else
        {
            _inventoryOpened = true;
        }
        _mainInventoryUI.SetActive(_inventoryOpened);
    }

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        Mushroom.CollectedMushroom += IncreasePoints;
        _mainInventoryUI.SetActive(false);

        _grabAndDrag.started += StartsGrabbing;
        _grabAndDrag.performed += StartsGrabbing;
        _grabAndDrag.canceled += StartsGrabbing;
    }

    private void StartsGrabbing(InputAction.CallbackContext context)
    {
        print("Click hold release");
        System.Type vector2Type = Vector2.zero.GetType();

        string buttonControlPath = "/Mouse/leftButton";
        //string deltaControlPath = "/Mouse/delta";

        Debug.Log(context.control.path);
        //Debug.Log(context.valueType);

        if (context.started)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button Pressed Down Event - called once when button pressed");
            }
        }
        else if (context.performed)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button Hold Down - called continously till the button is pressed");
            }
        }
        else if (context.canceled)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button released");
            }
        }
    }

    private void IncreasePoints(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score;
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ModifyInventory()
    {
        if (_inventoryIsActive)
        {
            _inventoryUI.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
        {
            _inventoryUI.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }

    public void OnSwitchSelectedItem()
    {
        if (!_inventoryIsActive)
        {
            _inventoryIsActive = true;
            ModifyInventory();

        }
        if(_lastSelectedItem == null)
        {
            _lastSelectedItem = _initialSelectedItem;
            _lastSelectedItem.GetComponent<InventorySlot>().ActivateSelection();
        }
        print("Switched selected item");
    }

    // Navigates between the items on the inventory
    public void OnNavigate(InputValue value)
    {
        _inventoryIsActive = false; // TODO: This disabling going through the inventory could be prettier than checking every time the player moves
        ModifyInventory();
        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
        // If the selected item was an InventorySlot, I save it. If not, I can always go back to the selected one
        /* if (selectedGameObject.CompareTag("InventorySlot"))
        {
            _lastSelectedItem = selectedGameObject;
            print(selectedGameObject.name);
        }*/
    }

    public void OnClickHoldRelease(InputAction.CallbackContext context)
    {
        print("Click hold release");
        System.Type vector2Type = Vector2.zero.GetType();

        string buttonControlPath = "/Mouse/leftButton";
        //string deltaControlPath = "/Mouse/delta";

        Debug.Log(context.control.path);
        //Debug.Log(context.valueType);

        if (context.started)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button Pressed Down Event - called once when button pressed");
            }
        }
        else if (context.performed)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button Hold Down - called continously till the button is pressed");
            }
        }
        else if (context.canceled)
        {
            if (context.control.path == buttonControlPath)
            //if (context.valueType != vector2Type)
            {
                Debug.Log("Button released");
            }
        }
    }
}
