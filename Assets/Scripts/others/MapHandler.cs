using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapHandler : MonoBehaviour
{
    private int total_map = 2;
    private int map;

    // Start is called before the first frame update
    void Start()
    {
        map = 1;
        PlayerPrefs.SetInt("MapNumber",map);
        PlayerPrefs.Save();
        UpdateImage();
    }


    public void Before(){
        map--;
        if (map < 1){
            map=total_map;
        }
        PlayerPrefs.SetInt("MapNumber",map);
        PlayerPrefs.Save();
        UpdateImage();
    }

    public void After(){
        map++;
        if (map > total_map){
            map=1;
        }
        PlayerPrefs.SetInt("MapNumber",map);
        PlayerPrefs.Save();
        UpdateImage();
    }

    public void UpdateImage(){
        Sprite map_sprite;
        switch(map){
            case 1:
                map_sprite = Resources.Load<Sprite>("map1");
            break;
            case 2:
                map_sprite = Resources.Load<Sprite>("map2");
            break;
            default:
                map_sprite = Resources.Load<Sprite>("map1");
            break;
        }
        
        gameObject.GetComponent<Image>().sprite = map_sprite;
    }

}
