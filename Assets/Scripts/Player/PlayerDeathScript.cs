using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    int playerId;
    public void dead()
    {
        gameManager.EndRound(playerId);
    }
}
