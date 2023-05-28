using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestImplementation : MonoBehaviour
{
    public void ClickHoldRelease(InputAction.CallbackContext context)
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
