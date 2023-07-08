using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogue
{
    [SerializeField] private string _speakerName;
    [SerializeField][TextArea(3, 10)] private string[] _sentences;

    public string[] Sentences
    {
        get { return _sentences; }
        set { _sentences = value; }
    }

    public string SpeakerName
    {
        get { return _speakerName; }
        set { _speakerName = value; }
    }
}
