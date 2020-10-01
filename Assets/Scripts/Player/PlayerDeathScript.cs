using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    int playerId;

    public GameObject spawn;

    private void Start() {
        if(playerId==1){
            spawn = GameObject.Find("Spawn1");
        }
        else{
            spawn = GameObject.Find("Spawn2");
        }
    }


    public void dead()
    {
        gameObject.transform.position = spawn.transform.position;
        gameObject.GetComponent<PlayerDeplacementScript>().Reborn();
        gameManager.EndRound(playerId);
    }
}
