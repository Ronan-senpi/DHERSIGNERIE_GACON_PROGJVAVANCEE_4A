using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtnHandler : MonoBehaviour
{
    public void play(){
        int map = PlayerPrefs.GetInt("MapNumber",1);
        
        switch(map){
            case 1:
                SceneManager.LoadScene("GameScene");
            break;
            case 2:
                SceneManager.LoadScene("Map1Scene");
            break;
            default:
                SceneManager.LoadScene("GameScene");
            break;
        }

        AudioManager.instance.Play("MenuInteraction");
    }
}
