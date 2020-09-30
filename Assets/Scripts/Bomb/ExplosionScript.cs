using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : ExplosionBaseScript
{
    [SerializeField]
    protected LayerMask BombLayer;
    [SerializeField]
    protected LayerMask PlayerLayer;

    protected override void OnTriggerEnter(Collider other)
    {
        if ((BombLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            BombeBaseScript bbs = other.GetComponent<BombeBaseScript>();
            if (bbs != null)
            {
                bbs.Explosion();
                Destroy(other.gameObject);
            }
        }
        if ((PlayerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            //other.GetComponent<SCRIPT DE FIN DE VIE DU PLAYER>();
            //Application.LoadLevel(Application.loadedLevel);
            var pds = other.GetComponent<PlayerDeathScript>();
            if (pds != null)
            {
                pds.dead();
            }
        }
        base.OnTriggerEnter(other);

    }
}
