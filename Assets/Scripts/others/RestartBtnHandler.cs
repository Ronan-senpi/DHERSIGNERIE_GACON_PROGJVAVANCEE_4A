using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtnHandler : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    public void restart()
    {

        AudioManager.instance.Play("MenuInteraction");
        gameManager.RestartGame();
    }
    public void Resume()
    {

        AudioManager.instance.Play("MenuInteraction");
        gameManager.ResumeGame();
    }
}
