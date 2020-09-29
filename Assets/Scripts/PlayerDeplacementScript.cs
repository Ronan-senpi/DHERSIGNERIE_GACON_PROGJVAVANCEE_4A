using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeplacementScript : MonoBehaviour
{

    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private string AxisHorizontal;
    [SerializeField] private string AxisVertical;
    [SerializeField] private GameManager gameManager;

    private bool stunned = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Vector3.zero;


        if (Input.GetAxis(AxisHorizontal) > 0  ){
            direction.z++;
        }

        if (Input.GetAxis(AxisHorizontal) < 0 ){
            direction.z--;
        }

        if (Input.GetAxis(AxisVertical) > 0 ){
            direction.x--;
        }

        if (Input.GetAxis(AxisVertical) < 0 ){
            direction.x++;
        }

        if(!stunned)
            gameObject.transform.position += direction * Time.deltaTime * Speed;


        
    }

    public void Stuned (float StunDuration){
        StartCoroutine(Stun(StunDuration));
    }

    protected IEnumerator Stun(float StunDuration)
    {
        this.stunned=true;
        yield return new WaitForSeconds(StunDuration);
        this.stunned=false;
    }


}
