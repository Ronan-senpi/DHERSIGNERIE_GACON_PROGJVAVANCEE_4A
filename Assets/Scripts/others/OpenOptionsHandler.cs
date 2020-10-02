using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenOptionsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

    void Start(){
        Panel.SetActive(false);
    }
    public void OpenPanel(){
        if(Panel!=null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
