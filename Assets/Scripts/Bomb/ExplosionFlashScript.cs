using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFlashScript : ExplosionBaseScript
{
    [SerializeField]
    protected float StunDuration = 1f;
    protected override void hit(Collider other)
    {
        PlayerDeplacementScript pylr = other.GetComponent<PlayerDeplacementScript>();
        if(pylr!=null){
            pylr.Stuned(StunDuration);
        }
    }
    protected override void MakeItBlewUp()
    {
        //You can't make bl
    }
}
