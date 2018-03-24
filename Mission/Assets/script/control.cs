using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class control : MonoBehaviour
{

    // Use this for initialization
    private float x, y;

    public Rigidbody squ;


    void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()

    {   x = Input.acceleration.x*30;
        y = Input.acceleration.y*30;
       /* speed = Mathf.Sqrt(x * x + y * y);
        //Vector3.right x zhou  
        horizontalMovement = Input.GetAxis("Horizontal") * Vector3.right * speed;

        //z zhou  
        verticalMovement = Input.GetAxis("Vertical") * Vector3.forward * speed;

        //小球的运动  
        Vector3 movement = horizontalMovement + verticalMovement;*/

        squ.AddForce(new Vector3(x, 0, y), ForceMode.Force);
    
       
  
        //z = Input.acceleration.z / 5;
        /*
        if (x < 0.5)
        {
            x = 0;
        }
        if (y < 0.5)
        {
            y = 0;
        }*/

        




    }
    
}
