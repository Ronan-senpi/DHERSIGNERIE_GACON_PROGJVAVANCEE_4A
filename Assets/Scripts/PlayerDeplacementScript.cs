using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacementScript : MonoBehaviour
{

    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private string AxisHorizontal;
    [SerializeField] private string AxisVertical;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Vector3.zero;


        if (Input.GetAxis(AxisHorizontal) > 0 ){
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


        gameObject.transform.position += direction * Time.deltaTime * Speed;
        
    }
}
