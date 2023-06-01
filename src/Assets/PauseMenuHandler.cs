using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _backgroundUI;
    [SerializeField] private Button _mainButton;

    private bool _isPaused = false;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
        _backgroundUI.SetActive(false);
    }
    public void OnPause(InputValue value)
    {
        if (_isPaused)
        {
            _isPaused = false;
        }
        else
        {
            _isPaused = true;
            EventSystem.current.SetSelectedGameObject(_mainButton.gameObject);
        }

        _pauseMenu.SetActive(_isPaused);
        _backgroundUI.SetActive(_isPaused);
    }

    public void OnNavigatePause(InputValue value)
    {
        Vector2 navigatePause = value.Get<Vector2>();

        Button buttonSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Slider sliderSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();

        if (navigatePause.y == -1)
        {
            if(buttonSelected != null)
            {
                GameObject downFromThis = buttonSelected.FindSelectableOnDown().gameObject;
                EventSystem.current.SetSelectedGameObject(downFromThis);
            }
            else // TODO: Make this better oh god
            {
                GameObject downFromThis = sliderSelected.FindSelectableOnDown().gameObject;
                EventSystem.current.SetSelectedGameObject(downFromThis);
            }
            return;
        }

        if(navigatePause.y == 1)
        {
            if(buttonSelected != null)
            {
                GameObject upFromThis = buttonSelected.FindSelectableOnUp().gameObject;
                EventSystem.current.SetSelectedGameObject(upFromThis);
            }
            else
            {
                GameObject upFromThis = sliderSelected.FindSelectableOnUp().gameObject;
                EventSystem.current.SetSelectedGameObject(upFromThis);
            }
            return;
        }

        if(navigatePause.x == -1 && sliderSelected != null) // Slider is selected
        {
            sliderSelected.value = sliderSelected.value - 0.1f;
            return;
        }

        if(navigatePause.x == 1 && sliderSelected != null)
        {
            sliderSelected.value = sliderSelected.value + 0.2f;
            return;
        }
        print("Navigated: " + navigatePause);
    }
}
