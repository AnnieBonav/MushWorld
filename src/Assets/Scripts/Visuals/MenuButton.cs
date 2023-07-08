using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _selectSoundEvent;
    [SerializeField] private string _navigateSoundEffect;
    [SerializeField] private string _sceneToGo;

    public void PlayNavigateSound()
    {
        AkSoundEngine.PostEvent(_navigateSoundEffect, gameObject);
    }

    public void PlaySound()
    {
        AkSoundEngine.PostEvent(_selectSoundEvent, gameObject);
    }

    public void ChangeScene()
    {
        print("Trying to go to: " + _sceneToGo);
        SceneManager.LoadScene(_sceneToGo);
    }
}
