using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;

    public Dialogue dialogue
    {
        get { return _dialogue; }
    }

    public void OnTest(InputValue value)
    {
        print("Is testing");
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(_dialogue);
    }
}
