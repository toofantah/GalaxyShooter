using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesDisplay;
    [SerializeField]
    private GameObject _gameOver;
   

    void Start()
    {
       
        _ScoreText.text = "SCORE : " + 0;
    }

   public void UpdateScore(int score)
    {
        _ScoreText.text = "SCORE : " + score;
    }

    public void UpdateSprites(int currentLives)
    {
        _livesDisplay.sprite = _livesSprites[currentLives];
    }

    public void GameOver()
    {
        StartCoroutine(GameOverFlashingRoutine());
    }

    IEnumerator GameOverFlashingRoutine()
    {
        while (true)
        {
            _gameOver.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
