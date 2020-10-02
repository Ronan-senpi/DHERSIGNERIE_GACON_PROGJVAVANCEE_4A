using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeBaseScript : MonoBehaviour
{
    [SerializeField]
    protected float timer = 1.5f;
    [SerializeField]
    protected GameObject explosionObject;
    [SerializeField]
    protected int range = 1;
    //0 = infini
    [SerializeField]
    protected int nbMaxUse = 0;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(DelayExplosion());
    }

    protected virtual IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(timer);
        this.Explosion();

    }

    public virtual void Explosion()
    {
        GameObject go = Instantiate(explosionObject, gameObject.transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;
        for (int i = 1; i <= range; i++)
        {
            //Pas opti mais pour le moment ... 
            Vector3 nPosition1 = new Vector3(
                gameObject.transform.position.x + i,
                gameObject.transform.position.y,
                gameObject.transform.position.z);
            var tmp1 = Instantiate(explosionObject, nPosition1, Quaternion.identity);
            tmp1.name = "1";

            Vector3 nPosition2 = new Vector3(
                gameObject.transform.position.x - i,
                gameObject.transform.position.y,
                gameObject.transform.position.z);
            var tmp2 = Instantiate(explosionObject, nPosition2, Quaternion.identity);
            tmp2.name = "2";
            Vector3 nPosition3 = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z + i);
            var tmp3 = Instantiate(explosionObject, nPosition3, Quaternion.identity);
            tmp3.name = "3";
            Vector3 nPosition4 = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z - i);
            var tmp4 = Instantiate(explosionObject, nPosition4, Quaternion.identity);
            tmp4.name = "4";

        }

        Destroy(gameObject);
    }
    /// <summary>
    /// Retourne le nombre d'utilisation max de la bombe (0 = infini)
    /// </summary>
    /// <returns></returns>
    public int GetMaxUserBomb()
    {
        return nbMaxUse;
    }
}
