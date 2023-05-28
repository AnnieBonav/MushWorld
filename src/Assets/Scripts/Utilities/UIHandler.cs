using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class UIHandler : MonoBehaviour
{
    public static event Action<GameObject> GrabbedInventorySlot;

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private InputAction _grabAndDrag;
    private bool _inventoryOpened = false;
    private int _score = 0;


    public void OnActivateInventory(InputValue value)
    {
        print("Activating inventory");
    }

    public void OnSwitchSelectedItem(InputValue value)
    {
        print("Switch item selection");
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
        _inventoryUI.SetActive(_inventoryOpened);
    }

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        Mushroom.CollectedMushroom += IncreasePoints;
        _inventoryUI.SetActive(false);

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

    public void OnNavigate(InputValue value)
    {
        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
        print(selectedGameObject.name);
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
