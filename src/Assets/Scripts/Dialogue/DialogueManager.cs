using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private UIFacade _uiFacade;
    private Queue<string> _sentences;

    private void Awake()
    {
        _sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        _uiFacade.SpeakerName.text = dialogue.SpeakerName;
        for(int i = 0; i < dialogue.Sentences.Length; i++)
        {
            _sentences.Enqueue(dialogue.Sentences[i]);
        }
        NextSentence();
    }

    public void OnGrab(InputValue value)
    {
        if (_sentences.Count > 0)
        {
            NextSentence();
        }
        else
        {
            EndDialogue();
        }
    }

    public void NextSentence()
    {
        string sentence = _sentences.Dequeue();
        StartCoroutine(DisplayText(sentence));
    }

    private IEnumerator DisplayText(string sentence)
    {
        _uiFacade.DialogueSentence.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _uiFacade.DialogueSentence.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }

    

    public void EndDialogue()
    {
        print("Ended dialogue");
    }
}
