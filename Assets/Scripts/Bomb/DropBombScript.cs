﻿using Assets.Scripts.others;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    [SerializeField]
    private int maxBomb = 1;

    List<GameObject> bombs = new List<GameObject>();
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
        if (Input.GetButtonDown(mainFireInput) && CanDropMainBomb())
        {
            this.DropMainBomb();
        }

        //Secondary bomb
        if (Input.GetButtonDown(SecondaryFireInput) && this.CanDropSecondaryBomb())
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
        bombs.Add(Instantiate(bomb, GetSnapPosition(transform.position, bomb.transform.position.y), Quaternion.identity));
    }

    public void DropSecondaryBomb()
    {
        GameObject i;
        bool isMine;
        switch (bombType)
        {
            case BombType.Flash:
                i = this.FlashBomb;
                isMine = false;
                break;
            case BombType.Mine:
            default:
                i = this.MineBomb;
                isMine = true;
                break;
        }
        this.secondaryBombCurentCurrentUse++;
        
        var instance = Instantiate(i, GetSnapPosition(transform.position, i.transform.position.y), Quaternion.identity);
        if (isMine)
            bombs.Add(instance);

    }

    public bool CanDropMainBomb()
    {
        this.bombs.RemoveAll(x => x == null);
        return bombs.Count < maxBomb;
    }
    public bool CanDropSecondaryBomb()
    {
        this.bombs.RemoveAll(x => x == null);
        return (secondaryBombCurentCurrentUse < secondaryBombMaxUse || secondaryBombMaxUse == 0) && bombs.Count < maxBomb;
    }
}
