using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField]
    protected LayerMask DestroableLayer;
    [SerializeField]
    protected float Duration = 1f;
    protected virtual void Start()
    {
        StartCoroutine(EndExplosionAfterDuration());   
    }
    protected IEnumerator EndExplosionAfterDuration()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((DestroableLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("You blow something you can blow !! :o ");
            Destroy(other.gameObject);
        }
    }
}
