using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string _levelName;
    public void LoadLevel()
    {
        print("Trying to load level " + _levelName);
        SceneManager.LoadSceneAsync(_levelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadLevel();
    }
}
