using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFlashScript : ExplosionBaseScript
{
    [SerializeField]
    protected float StunDuration = 1f;
    protected override void hit(Collider other)
    {
        //TODO : PlayerDeplacementScript.Stuned(StunDuration);
        Debug.LogError("PlayerDeplacementScript.Stuned(StunDuration) is not implemented");
       
    }
}
