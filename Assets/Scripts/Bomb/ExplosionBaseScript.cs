using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBaseScript : MonoBehaviour
{

    [SerializeField]
    protected float Duration = 1f;
    [SerializeField]
    protected LayerMask hitLayer;
    [SerializeField]
    protected LayerMask BombLayer;
    public bool detectBomb { get; set; }

    private void Awake()
    {
        detectBomb = true;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(EndExplosionAfterDuration());
        MakeItBlewUp();
    }
    protected IEnumerator EndExplosionAfterDuration()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((hitLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            hit(other);
        }
    }

    protected virtual void hit(Collider other)
    {
        Destroy(other.gameObject);
    }
    /// <summary>
    /// Si on une bombe dans une case cela la fait exploser
    /// </summary>
    protected virtual void MakeItBlewUp()
    {
        RaycastHit hit;
        var v = transform.position + (Vector3.up * 50.0f);
        if (detectBomb && Physics.Raycast(v, -Vector3.up, out hit, 100.0f, BombLayer.value, QueryTriggerInteraction.Collide))
        {
            Debug.Log("Make it bl");
            BombeBaseScript bbs = hit.transform.GetComponent<BombeBaseScript>();
            if (bbs != null)
            {
                StartCoroutine(delay(bbs));

            }
        }
    }
    IEnumerator delay(BombeBaseScript bbs)
    {
        yield return new WaitForSeconds(0.25f);
        bbs.Explosion();
    }
}
