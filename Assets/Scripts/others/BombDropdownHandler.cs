using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.others;

public class BombDropdownHandler : MonoBehaviour
{


    private void Start()
    {
        HandleInputDataP1(GetComponent<Dropdown>().value);
        HandleInputDataP2(GetComponent<Dropdown>().value);
    }
    public void HandleInputDataP1(int val)
    {
        switch (val)
        {
            case 0:
                PlayerPrefs.SetString("BombP1", BombType.Flash.ToString());
                break;
            case 1:
            default:
                PlayerPrefs.SetString("BombP1", BombType.Mine.ToString());
                break;
        }
        PlayerPrefs.Save();

    }

    public void HandleInputDataP2(int val)
    {
        switch (val)
        {
            case 0:
                PlayerPrefs.SetString("BombP2", BombType.Flash.ToString());
                break;
            case 1:
            default:
                PlayerPrefs.SetString("BombP2", BombType.Mine.ToString());
                break;
        }
        PlayerPrefs.Save();

    }
}
