using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DistortionController : MonoBehaviour
{
    public static event Action ActivateDistort;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _distortedCameraObject;
    private Camera _distortedCamera;
    [SerializeField] private Shader _distortionShader;

    private void Awake()
    {
        _distortedCamera = _distortedCameraObject.GetComponent<Camera>();
        _distortedCamera.RenderWithShader(_distortionShader, "RenderType"); // replacementTag is to replace some tags with this renderer
    }

    public void OnTriggerDistortion(InputValue value)
    {
        ActivateDistort?.Invoke();

    }

    private void FixedUpdate()
    {
        
    }
}
