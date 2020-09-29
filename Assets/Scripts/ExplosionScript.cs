using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : ExplosionBaseScript
{
    [SerializeField]
    protected LayerMask BombLayer;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if ((BombLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            BombeBaseScript bbs = other.GetComponent<BombeBaseScript>();
            if (bbs != null)
            {
                bbs.Explosion();
                Destroy(other.gameObject);

            }
        }
    }
}
