using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBombScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private GameObject FlashBomb;
    [SerializeField]
    private GameObject Mine;
    [SerializeField]
    private string mainFireInput = "Fire1.1";
    [SerializeField]
    private string SecondaryFireInput = "Fire1.2";
    private void Update()
    {
        //main bomb
        if (Input.GetButtonDown(mainFireInput))
        {
            var tmp = new Vector3(
                ((int)transform.position.x + 0.5f),
                transform.position.y,
                ((int)transform.position.z +0.5f));
            Instantiate(bomb, tmp, Quaternion.identity);
        }

        //Secondary bomb
        if (Input.GetButtonDown(SecondaryFireInput))
        {
            var tmp = new Vector3(
                ((int)transform.position.x + 0.5f),
                transform.position.y,
                ((int)transform.position.z + 0.5f));
            Instantiate(bomb, tmp, Quaternion.identity);
        }

    }
}
