using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] int playerScore = 0;
    [SerializeField] int IncrementScore = 1000;
    void Start()
    {
        tmp.text = ("Score: " + "ZERO");
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = ("Score: " + playerScore.ToString());   
    }
    public void NewScore()
    {
        playerScore += IncrementScore;
    }
}
