using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeBaseScript : MonoBehaviour
{
    [SerializeField]
    protected float timer = 1.5f;
    [SerializeField]
    protected GameObject FireObject;
    [SerializeField]
    protected int range = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion());
    }

    protected IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timer);

        Instantiate(FireObject, gameObject.transform.position, Quaternion.identity);
        for (int i = 1; i <= range; i++)
        {
            //Pas opti mais pour le moment ... 
            Vector3 nPosition1 = new Vector3(
                gameObject.transform.position.x + i,
                gameObject.transform.position.y,
                gameObject.transform.position.z);
            var tmp1 = Instantiate(FireObject, nPosition1, Quaternion.identity);
            tmp1.name = "1";

            Vector3 nPosition2 = new Vector3(
                gameObject.transform.position.x - i,
                gameObject.transform.position.y,
                gameObject.transform.position.z);
            var tmp2 = Instantiate(FireObject, nPosition2, Quaternion.identity);
            tmp2.name = "2";
            Vector3 nPosition3 = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z + i);
            var tmp3 = Instantiate(FireObject, nPosition3, Quaternion.identity);
            tmp3.name = "3";
            Vector3 nPosition4 = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z - i);
            var tmp4 = Instantiate(FireObject, nPosition4, Quaternion.identity);
            tmp4.name = "4";

        }
    }
}
