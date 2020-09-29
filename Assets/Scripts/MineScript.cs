using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : BombeBaseScript
{
    [SerializeField]
    protected LayerMask triggerLayer;
    [SerializeField]
    protected float delayBeforeActivation = 1;
    protected bool canBlowUp = false;
    protected override void Start()
    {
        StartCoroutine(DelayBeforeActivation()); 
    }
    protected IEnumerator DelayBeforeActivation()
    {
        yield return new WaitForSeconds(delayBeforeActivation);
        this.canBlowUp = true;
        Debug.Log("can blow up");
        
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (canBlowUp && (triggerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("blowup !");
            Explosion();
        }
    }

}
