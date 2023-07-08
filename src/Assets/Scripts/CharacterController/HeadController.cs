using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadController : MonoBehaviour
{
    [SerializeField] private float _anglePerSecond = 2f;
    [SerializeField] private float _minX = 320;
    [SerializeField] private float _maxX = 40;

    private float _verticalMovement;

    private void FixedUpdate()
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        if (_verticalMovement < 0 && eulerAngles.x > 300 && (eulerAngles.x - _verticalMovement) <= _minX) return;
        if(_verticalMovement > 0 && eulerAngles.x < 100 && (eulerAngles.x + _verticalMovement) >= _maxX) return;
        transform.Rotate(new Vector3(_verticalMovement, 0, 0));
    }

    public void OnLookVertical(InputValue value)
    {
        float verticalInput = value.Get<float>();
        if(verticalInput > 0) _verticalMovement = _anglePerSecond * -1;
        else if (verticalInput < 0) _verticalMovement = _anglePerSecond;
        else _verticalMovement = 0;
    }
}
