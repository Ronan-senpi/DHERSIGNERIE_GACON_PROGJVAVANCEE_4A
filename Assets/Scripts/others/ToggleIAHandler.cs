using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleIAHandler : MonoBehaviour
{

    private bool state;
    Toggle m_Toggle;
    
    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        CheckToggle();
    }

    public void CheckToggle(){
        state = m_Toggle.isOn;
        Debug.Log(state.ToString());
        if(state)
            PlayerPrefs.SetInt("IA", 1);
        else
            PlayerPrefs.SetInt("IA", 0);
        PlayerPrefs.Save();
    }
}
