using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;
   

    void Start()
    {
        _ScoreText.text = "SCORE : " + 0;
    }

   public void UpdateScore(int score)
    {
        _ScoreText.text = "SCORE : " + score;
    }
}
