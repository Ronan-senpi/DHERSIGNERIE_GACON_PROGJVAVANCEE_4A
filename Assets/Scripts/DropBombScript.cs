using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBombScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private string fireInput = "Fire1";
    private void Update()
    {
        if (Input.GetButtonDown(fireInput))
        {
            var tmp = new Vector3(
                ((int)transform.position.x + 0.5f),
                transform.position.y,
                ((int)transform.position.z +0.5f));
            Instantiate(bomb, tmp, Quaternion.identity);
        }
    }
}
