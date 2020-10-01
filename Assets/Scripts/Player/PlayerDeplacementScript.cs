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
    private bool invincible = false;

    // Update is called once per frame
    protected virtual void Update()
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

        if(!stunned && !invincible)
            gameObject.transform.position += direction * Time.deltaTime * Speed;


        
    }


    /*----Player States------*/
    public void Stuned (float StunDuration){
        StartCoroutine(Stun(StunDuration));
    }

    protected virtual IEnumerator Stun(float StunDuration)
    {
        this.stunned=true;
        //TODO changer le gameobject en jaune pendant le stun
        //gameObject.GetComponent<MeshRenderer>().material.SetTexture();
        yield return new WaitForSeconds(StunDuration);
        //TODO Prendre le material du gameObject comme variable pour remettre comme avant
        //gameObject.renderer.material = null;
        this.stunned=false;
    }

    public void Reborn (){
        StartCoroutine(Stun(0.25f));
        StartCoroutine(Invincible(1f));
    }

    protected virtual IEnumerator Invincible(float StunDuration)
    {
        this.invincible=true;
        yield return new WaitForSeconds(StunDuration);
        this.invincible=false;
    }

    public bool IsStunned(){return this.stunned;}
    public bool IsInvincible(){return this.invincible;}




}
