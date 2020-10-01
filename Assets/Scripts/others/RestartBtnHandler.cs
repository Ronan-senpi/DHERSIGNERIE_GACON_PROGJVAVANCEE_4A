using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtnHandler : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    public void restart(){
        gameManager.RestartGame();
    }
}
