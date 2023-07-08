using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string _levelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(_levelName);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}
