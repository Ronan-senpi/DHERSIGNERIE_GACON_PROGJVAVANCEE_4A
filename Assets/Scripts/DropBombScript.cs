using Assets.Scripts.others;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropBombScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private GameObject FlashBomb;
    [SerializeField]
    private GameObject MineBomb;
    [SerializeField]
    protected BombType bombType;
    [SerializeField]
    private string mainFireInput = "Fire1.1";
    [SerializeField]
    private string SecondaryFireInput = "Fire1.2";
    private void Update()
    {
        //main bomb
        if (Input.GetButtonDown(mainFireInput))
        {
            Instantiate(bomb, GetSnapPosition(transform.position, bomb.transform.position.y), Quaternion.identity);
        }

        //Secondary bomb
        if (Input.GetButtonDown(SecondaryFireInput))
        {
            GameObject i;
            switch (bombType)
            {
                case BombType.Flash:
                    i = this.FlashBomb;
                    break;
                case BombType.Mine:
                default:
                    i = this.MineBomb;
                    break;
            }
            Instantiate(i, GetSnapPosition(transform.position, i.transform.position.y), Quaternion.identity);
        }
    }
    protected Vector3 GetSnapPosition(Vector3 pos, float y)
    {
        return new Vector3(
                ((int)pos.x + 0.5f),
                y,
                ((int)pos.z + 0.5f));
    }
}
