using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBaseScript : MonoBehaviour
{

    [SerializeField]
    protected float Duration = 1f;
    [SerializeField]
    protected LayerMask hitLayer;
    protected virtual void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((hitLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            //hit(other);
        }
    }
    // Start is called before the first frame update
    protected void Start()
    {
        StartCoroutine(EndExplosionAfterDuration());
    }
    protected IEnumerator EndExplosionAfterDuration()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void hit(Collider other)
    {
        Debug.Log("You blow something you can blow !! :o ");
        Destroy(other.gameObject);
    }
}
