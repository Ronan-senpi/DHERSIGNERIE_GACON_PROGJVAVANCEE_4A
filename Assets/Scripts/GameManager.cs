using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private readonly string P1_SCORE_TXT = "Player1 : ";
    private readonly string P2_SCORE_TXT = "Player2 : ";
    private readonly string WINNER = " win !";
    [SerializeField] 
    private GameObject PlayerPrefab;
    [SerializeField]
    private int maxScore = 3;
    [SerializeField]
    private TextMeshProUGUI p1ScoreTxt;
    private int p1Score = 0;
    [SerializeField]
    private TextMeshProUGUI p2ScoreTxt;
    private int p2Score = 0;

    [SerializeField]
    private TextMeshProUGUI winnerTxt;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void EndRound(int playerId)
    {
        if (playerId == 1)
        {
            p2Score++;
            p2ScoreTxt.text = P2_SCORE_TXT + p2Score.ToString();
        }
        else
        {
            p1Score++;
            p1ScoreTxt.text = P1_SCORE_TXT + p1Score.ToString();
            if (true)
            {

            }
        }

    }
    public void StartGame()
    {
        p1ScoreTxt.text = P1_SCORE_TXT + p1Score.ToString();
        p2ScoreTxt.text = P2_SCORE_TXT + p2Score.ToString();
        winnerTxt.enabled = false;
        //Instantiate<GameObject>(PlayerPrefab, Vector3.zero, Quaternion.identity);
        //Instantiate<GameObject>(PlayerPrefab, Vector3.one, Quaternion.identity);
    }

    public void RestartGame()
    {
        //Instantiate<GameObject>(PlayerPrefab, Vector3.zero, Quaternion.identity);
        //Application.LoadLevel(Application.loadedLevel);
    }
}
