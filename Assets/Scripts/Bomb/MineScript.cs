using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : BombeBaseScript
{
    [SerializeField]
    protected LayerMask triggerLayer;
    [SerializeField]
    protected float delayBeforeActivation = 1;
    protected bool canBlewUp = false;
    protected override void Start()
    {
        StartCoroutine(DelayBeforeActivation()); 
    }
    protected IEnumerator DelayBeforeActivation()
    {
        yield return new WaitForSeconds(delayBeforeActivation);
        this.canBlewUp = true;
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (canBlewUp && (triggerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Explosion();
        }
    }

}
