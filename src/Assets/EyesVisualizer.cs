using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EyesVisualizer : MonoBehaviour
{
    [SerializeField] private InventoryUIHandler _inventoryUIHandler;

    private LineRenderer _trail;
    private Vector3 _cameraOrigin = new Vector3(0.5f, 0.5f, 0f);
    [SerializeField] private float _rayLength = 50f;
    [SerializeField] private Transform _origin;

    private void Awake()
    {
        _trail = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(_cameraOrigin);
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(ray, out hit, _rayLength);

        _trail.SetPosition(0, _origin.position);
        _trail.SetPosition(1, hit.point);
    }

    public void OnGrab(InputValue value)
    {
        Ray ray = Camera.main.ViewportPointToRay(_cameraOrigin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            if (!hit.collider.gameObject.CompareTag("Grabbable")) return; // Returns if it is not grabbale
            Grabbable tempGrabbable = hit.collider.gameObject.GetComponent<Grabbable>();
            if (tempGrabbable != null)
            {
                tempGrabbable.Grab();
            }
            print("Hit something?: " + hit.collider.transform.name);
        }
    }
    public void OnPlace(InputValue value)
    {
        Ray ray = Camera.main.ViewportPointToRay(_cameraOrigin);
        RaycastHit hit;
        bool hitFloor = Physics.Raycast(ray, out hit, _rayLength);

        Grabbable instancedGrabbable = _inventoryUIHandler.SelectedGrabbable;
        print("I am trying to place");
        if(instancedGrabbable != null) // If there was actually a grabbable
        {
            print("Wants to instance a grabbable");
            Instantiate(instancedGrabbable, hit.point, Quaternion.identity);
        }
    }

}
