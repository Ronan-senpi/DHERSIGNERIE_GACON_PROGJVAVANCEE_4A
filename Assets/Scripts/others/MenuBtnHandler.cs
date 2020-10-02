using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnHandler : MonoBehaviour
{
    public void menu(){
        if(Time.timeScale==0)
            Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
