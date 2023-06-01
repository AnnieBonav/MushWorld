using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneHandling : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeControllerPlayground()
    {
        SceneManager.LoadScene("ControllerPlayground");
    }

    public void ChangeToAllWorlds()
    {
        SceneManager.LoadScene("AllWorlds");
    }

    public void OnClick(InputValue value)
    {
        print("I was clicked: " + value.ToString());
    }
}
