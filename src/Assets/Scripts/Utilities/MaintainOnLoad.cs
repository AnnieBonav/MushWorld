using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaintainOnLoad : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.activeSceneChanged += RemoveExisting;
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        print("I was enabled. Scene: " + SceneManager.GetActiveScene().name);
    }
    private void RemoveExisting(Scene currentScene, Scene nextScene)
    {
        if (nextScene.name != "MainScene")
        {
            return; // Returns of it is not the main scene so it doesnt remove the only one existing
        }
        GameObject[] dontDestroyObject = GameObject.FindGameObjectsWithTag("DoNotDestroy");
        if(dontDestroyObject.Count() > 1)
        {
            DestroyImmediate(dontDestroyObject[1]);
        }
    }
}
