using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private RectTransform _cursorTransform;
    [SerializeField] private float _cursorSpeed = 1000f;
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _padding = 50f;

    private bool previousMouseState;
    private Mouse _virtualMouse;
    private Camera _mainCamera;
    private Mouse _currentMouse;

    private string _previousControlScheme = "";
    private const string _gamepadScheme = "Gamepad";
    private const string _mouseScheme = "Keyboard&Mouse";

    private void OnEnable()
    {
        _mainCamera = Camera.main;
        _currentMouse = Mouse.current;

        if (_virtualMouse == null) _virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        else if (!_virtualMouse.added) InputSystem.AddDevice(_virtualMouse);

        InputUser.PerformPairingWithDevice(_virtualMouse, _playerInput.user);

        if(_cursorTransform != null)
        {
            Vector2 position = _cursorTransform.anchoredPosition;
            InputState.Change(_virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        _playerInput.onControlsChanged += OnControlsChanged;
    }

    private void OnDisable()
    {
        if(_virtualMouse != null && _virtualMouse.added) InputSystem.RemoveDevice(_virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
        _playerInput.onControlsChanged -= OnControlsChanged;
    }

    private void UpdateMotion()
    {
        if(_virtualMouse == null || Gamepad.current == null) return;

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        deltaValue *= _cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = _virtualMouse.position.ReadValue();
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, _padding, Screen.width - _padding);
        newPosition.y = Mathf.Clamp(newPosition.y, _padding, Screen.height - _padding);

        InputState.Change(_virtualMouse.position, newPosition);
        InputState.Change(_virtualMouse.delta, deltaValue);

        bool aButtonIsPressed = Gamepad.current.aButton.isPressed;
        if(previousMouseState != aButtonIsPressed)
        {
            _virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(_virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }

        AnchorCursor(newPosition);
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, position, _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _mainCamera, out anchoredPosition);
        _cursorTransform.anchoredPosition = anchoredPosition;
    }

    private void OnControlsChanged(PlayerInput input)
    {
        if (_playerInput.currentControlScheme == _mouseScheme && _previousControlScheme != _mouseScheme)
        {
            print("Changed here");
            _cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            _currentMouse.WarpCursorPosition(_virtualMouse.position.ReadValue());
            _previousControlScheme = _mouseScheme;
        }
        else if (_playerInput.currentControlScheme == _gamepadScheme && _previousControlScheme != _gamepadScheme)
        {
            print("Changed there");
            _cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(_virtualMouse.position, _currentMouse.position.ReadValue());
            AnchorCursor(_currentMouse.position.ReadValue());
            _previousControlScheme = _gamepadScheme;
        }
    }
}
