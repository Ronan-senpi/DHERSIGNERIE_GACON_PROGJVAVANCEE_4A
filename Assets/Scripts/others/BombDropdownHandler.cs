using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombDropdownHandler : MonoBehaviour
{


    private void Start() {
        HandleInputDataP1(GetComponent<Dropdown>().value);
        HandleInputDataP2(GetComponent<Dropdown>().value);
    }
    public void HandleInputDataP1(int val)
    {
        switch(val){
            case 0:
                PlayerPrefs.SetString("BombP1","Flash");
            break;
            case 1:
                PlayerPrefs.SetString("BombP1","Mine");
            break;
            default:
            break;
        }
        PlayerPrefs.Save();
    }

    public void HandleInputDataP2(int val)
    {
        switch(val){
            case 0:
                PlayerPrefs.SetString("BombP2","Flash");
            break;
            case 1:
                PlayerPrefs.SetString("BombP2","Mine");
            break;
            default:
            break;
        }
        PlayerPrefs.Save();
    }
}
