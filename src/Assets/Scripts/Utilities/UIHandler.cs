using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private TMP_Text _scoreText;
    private bool _inventoryOpened = false;
    private int _score = 0;

    public void OnInventory(InputValue value)
    {
        if (_inventoryOpened)
        {
            _inventoryOpened = false;
        }
        else
        {
            _inventoryOpened = true;
        }
        _inventoryUI.SetActive(_inventoryOpened);
    }

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        Mushroom.CollectedMushroom += IncreasePoints;
        _inventoryUI.SetActive(false);
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
