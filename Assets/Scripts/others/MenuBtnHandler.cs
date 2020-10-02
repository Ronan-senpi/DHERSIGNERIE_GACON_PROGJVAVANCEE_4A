using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnHandler : MonoBehaviour
{
    public void menu(){

        AudioManager.instance.Play("MenuInteraction");
        SceneManager.LoadScene("MenuScene");
    }
}
