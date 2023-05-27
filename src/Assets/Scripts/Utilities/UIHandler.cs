using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    private TMP_Text _scoreText;
    private int _score = 0;

    private void Awake()
    {
        _scoreText = gameObject.GetComponentInChildren<TMP_Text>();
        _scoreText.text = "Score: " + _score;
        Mushroom.CollectedMushroom += IncreasePoints;
    }

    private void IncreasePoints(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score;
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
