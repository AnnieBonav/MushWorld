using UnityEngine;
using UnityEngine.InputSystem;

public class TestCamController : MonoBehaviour
{
    Camera cam;

    Vector3 newPosition;
    [SerializeField] private float movementTime = 5f;

    Vector3 dragStartPosition = Vector3.zero;
    Vector3 dragCurrentPosition = Vector3.zero;

    private void Start()
    {
        newPosition = transform.position;
        cam = Camera.main;
    }

    private void Update()
    {
        ApplyMovements();
    }


    public void DragAndMove(InputAction.CallbackContext context)
    {
        print("Dragged?");
        System.Type vector2Type = Vector2.zero.GetType();

        string buttonControlPath = "/Mouse/leftButton";
        //string deltaControlPath = "/Mouse/delta";

        if (context.started)
        {
            if (context.control.path == buttonControlPath)
            {
                Debug.Log("Button Pressed Down Event - called once when button pressed");

                Ray dragStartRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                Plane dragStartPlane = new Plane(Vector3.up, Vector3.zero);
                float dragStartEntry;

                if (dragStartPlane.Raycast(dragStartRay, out dragStartEntry))
                {
                    dragStartPosition = dragStartRay.GetPoint(dragStartEntry);
                }
            }
        }
        else if (context.performed)
        {
            if (context.control.path == buttonControlPath)
            {
                Debug.Log("Button Hold Down - called continously till the button is pressed");

                Ray dragCurrentRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                Plane dragCurrentPlane = new Plane(Vector3.up, Vector3.zero);
                float dragCurrentEntry;

                if (dragCurrentPlane.Raycast(dragCurrentRay, out dragCurrentEntry))
                {
                    dragCurrentPosition = dragCurrentRay.GetPoint(dragCurrentEntry);
                    newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                }
            }

        }
        else if (context.canceled)
        {
            if (context.control.path == buttonControlPath)
            {
                Debug.Log("Button released");
            }
        }
    }

    private void ApplyMovements()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, movementTime * Time.deltaTime);
    }
}
