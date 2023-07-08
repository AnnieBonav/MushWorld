using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// TODO: Just...clean up
public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private UIFacade _uiFacade;

    private bool _isPaused = false;

    [SerializeField] private bool _debugVolumeChange = false;

    private void Awake()
    {
        _uiFacade.PauseUI.SetActive(false);
        _uiFacade.Background.SetActive(false);
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
            EventSystem.current.SetSelectedGameObject(_uiFacade.GoMainMenuInPauseButton);
        }

        _uiFacade.PauseUI.SetActive(_isPaused);
        _uiFacade.Background.SetActive(_isPaused);
    }

    public void OnNavigatePause(InputValue value) // THis is not that clean but it helps mantain a separation of the UI interactions, because working with maps is Awful
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
    }
}
