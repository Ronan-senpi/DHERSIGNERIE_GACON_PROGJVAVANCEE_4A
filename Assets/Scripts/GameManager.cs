using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private readonly string P1_SCORE_TXT = "Player1 : ";
    private readonly string P2_SCORE_TXT = "Player2 : ";
    private readonly string REMAINING_TXT = " HP";
    private bool isFinished = false;

    [SerializeField] 
    private GameObject PlayerPrefab;
    [SerializeField]
    private int maxScore = 3;
    [SerializeField]
    private TextMeshProUGUI p1ScoreTxt;
    private int p1Score = 1;
    [SerializeField]
    private TextMeshProUGUI p2ScoreTxt;
    private int p2Score = 1;

    [SerializeField]
    private TextMeshProUGUI winnerTxt;

    [SerializeField] private Button RestartBtn;
    [SerializeField] private Image RestartImg;
    [SerializeField] private Text RestartBtnText;
    [SerializeField] private Button MenuBtn;
    [SerializeField] private Image MenuImg;
    [SerializeField] private Text MenuBtnText;

    // Start is called before the first frame update
    void Start()
    {
        p1Score = maxScore;
        p2Score = maxScore;

        StartGame();
        
        Debug.Log("P1 : " + PlayerPrefs.GetString("BombP1", "No"));
        
        Debug.Log("P2 : " + PlayerPrefs.GetString("BombP2", "No"));
    }

    public void EndRound(int playerId)
    {
        if (playerId == 1)
        {
            p1Score--;
            p1ScoreTxt.text = P1_SCORE_TXT + p1Score.ToString() + REMAINING_TXT;
        }
        else
        {
            p2Score--;
            p2ScoreTxt.text = P2_SCORE_TXT + p2Score.ToString() + REMAINING_TXT;
        }

        if (p1Score <= 0 || p2Score <= 0){
            winnerTxt.enabled = true;
            if(p1Score <= 0)
                winnerTxt.text = "Player 2 wins!";
            else
                winnerTxt.text = "Player 1 wins!";
            RestartBtn.enabled = true;
            RestartImg.enabled = true;
            RestartBtnText.enabled = true;
            MenuBtn.enabled = true;
            MenuImg.enabled = true;
            MenuBtnText.enabled = true;
            isFinished=true;
        }

    }
    public void StartGame()
    {
        p1ScoreTxt.text = P1_SCORE_TXT + p1Score.ToString() + REMAINING_TXT;
        p2ScoreTxt.text = P2_SCORE_TXT + p2Score.ToString() + REMAINING_TXT;
        winnerTxt.enabled = false;
        RestartBtn.enabled = false;
        RestartImg.enabled = false;
        RestartBtnText.enabled = false;
        MenuBtn.enabled = false;
        MenuImg.enabled = false;
        MenuBtnText.enabled = false;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public bool IsFinished(){
        return isFinished;
    }
}
