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
        if (Input.GetAxis(fireInput) != 0)
        {
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
        }
    }
}
