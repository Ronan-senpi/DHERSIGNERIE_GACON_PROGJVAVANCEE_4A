﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtnHandler : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart(){
        gameManager.RestartGame();
    }
}
