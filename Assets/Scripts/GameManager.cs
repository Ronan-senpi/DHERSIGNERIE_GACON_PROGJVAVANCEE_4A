using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(){
        //Instantiate<GameObject>(PlayerPrefab, Vector3.zero, Quaternion.identity);
        //Instantiate<GameObject>(PlayerPrefab, Vector3.one, Quaternion.identity);
    }

    public void RestartGame(){
        //Instantiate<GameObject>(PlayerPrefab, Vector3.zero, Quaternion.identity);
        Application.LoadLevel(Application.loadedLevel);
    }
}
