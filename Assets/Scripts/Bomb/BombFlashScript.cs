using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFlashScript : BombeBaseScript
{
    protected override void OnDestroy()
    {
        StopAllCoroutines();
        AudioManager.instance.Play("Flash");
    }
}
