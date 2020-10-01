using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnHandler : MonoBehaviour
{
    public void menu(){
        SceneManager.LoadScene("MenuScene");
    }
}
