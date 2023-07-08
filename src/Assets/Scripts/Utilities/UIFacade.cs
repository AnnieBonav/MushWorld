using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFacade : MonoBehaviour
{
    public GameObject Background;
    public Image Crosshair;

    [Header("Game Stats")]
    public GameObject HeartsUI;
    public TMP_Text Heartstext;

    [Header("Inventory")]
    public GameObject BigInventoryUI;
    public GameObject SmallInventoryUI;

    [Header("Dialogue")]
    public GameObject DialogueUI;
    public TMP_Text SpeakerName;
    public TMP_Text DialogueSentence;

    [Header("PAUSE UI")]
    public GameObject PauseUI;
    public GameObject GoMainMenuInPauseButton;

    [Header("Sliders in Pause Menu")]
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Slider UISlider;
}
