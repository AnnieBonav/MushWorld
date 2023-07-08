using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

// TODO: Add map changing scheme
// TODO: Fill inventory items with already existing items
public class UIHandler : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] private TMP_Text _livesText;
    private int _livesAmount = 0;
    

    [Header("Player Input")]
    [SerializeField] private PlayerInput _playerInput;
    // [SerializeField] private InputAction _grabAndDrag;

    private InputActionMap _UIMap;
    private InputActionMap _playerMap;


    private void Awake()
    {
        Cursor.visible = false;
        
        if(_livesText != null)
        {
            _livesText.text = _livesAmount.ToString(); // TODO: Change so this is not awful
        }
        Absorbable.AbsorbedHeart += UpdateLives;

        /* _grabAndDrag.started += StartsGrabbing;
        _grabAndDrag.performed += StartsGrabbing;
        _grabAndDrag.canceled += StartsGrabbing;*/

        // _playerInput.actions.FindAction("SwitchSelectedItem").canceled += FinishedSwitchedSelectedItem;
        _playerInput.actions.FindAction("Navigate").started += NavigateSound;
    }

    private void NavigateSound(InputAction.CallbackContext callback)
    {
        print("I woudl sound");
    }

    private void FinishedSwitchedSelectedItem(InputAction.CallbackContext context)
    {
        SwitchActionMap();
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

    private void UpdateLives()
    {
        _livesAmount ++;
        _livesText.text = _livesAmount.ToString();
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Navigates between the items on the inventory
    public void OnNavigate(InputValue value)
    {
        // print("Navigate" + EventSystem.current.currentSelectedGameObject.name);
        // print("Navigate was called. Current map: " + _playerInput.currentActionMap.name);
        /*if(_playerInput.currentActionMap.name == "UI")
        {
            print("Bring back from onnavigate");
            SwitchActionMap();
        }*/

        // _inventoryIsActive = false; // TODO: This disabling going through the inventory could be prettier than checking every time the player moves
        // ModifyInventory();
        // GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
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

    // TODO: Change action maps
    private void SwitchActionMap()
    {
        print("SWITCH");
        if (_playerInput.currentActionMap.name == "Player")
        {
            print("Was player");
            _playerInput.SwitchCurrentActionMap("UI");
        }
        else
        {
            print("Was UI");
            _playerInput.SwitchCurrentActionMap("Player");
        }
    }
}
