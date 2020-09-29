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

    protected int secondaryBombMaxUse = 1;
    protected int secondaryBombCurentCurrentUse = 0;
    private void Start()
    {
        BombeBaseScript bbs;
        switch (bombType)
        {
            case BombType.Flash:
                bbs = this.FlashBomb.GetComponent<BombeBaseScript>();
                SetMaxUse(bbs);
                break;
            case BombType.Mine:
            default:
                bbs = this.MineBomb.GetComponent<BombeBaseScript>();
                SetMaxUse(bbs);
                break;
        }

    }

    private void Update()
    {
        //main bomb
        if (Input.GetButtonDown(mainFireInput))
        {
            this.DropMainBomb();
        }

        //Secondary bomb
        if ( this.CanDropSecondaryBomb() && Input.GetButtonDown(SecondaryFireInput))
        {
            this.DropSecondaryBomb();
        }
    }
    protected void SetMaxUse(BombeBaseScript bbs)
    {
        if (bbs != null)
        {
            secondaryBombMaxUse = bbs.GetMaxUserBomb();
        }
    }
    /// <summary>
    /// Snap au centre d'une Unit
    /// </summary>
    /// <param name="pos">Position du player</param>
    /// <param name="y">Z du prefabs</param>
    /// <returns>position centre unit</returns>
    protected Vector3 GetSnapPosition(Vector3 pos, float y)
    {
        return new Vector3(
                ((int)pos.x + 0.5f),
                y,
                ((int)pos.z + 0.5f));
    }

    public void DropMainBomb()
    {
        Instantiate(bomb, GetSnapPosition(transform.position, bomb.transform.position.y), Quaternion.identity);
    }

    public void DropSecondaryBomb()
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
        this.secondaryBombCurentCurrentUse++;
        Instantiate(i, GetSnapPosition(transform.position, i.transform.position.y), Quaternion.identity);

    }

    public bool CanDropSecondaryBomb()
    {
        return (secondaryBombCurentCurrentUse < secondaryBombMaxUse || secondaryBombMaxUse == 0);
    }
}
