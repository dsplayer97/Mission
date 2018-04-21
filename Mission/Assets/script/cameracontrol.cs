using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour {

    public Animator cameraani;
    private int choselevel = 0;
    private bool back = false;
    private bool buttonclick = false;
    public GameObject basicplane;
    public GameObject levelplane;
    public 
    
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        if (buttonclick)
        {
             buttonclick = false;
            if(choselevel !=0)
            {
                cameraani.SetInteger("level", choselevel);
                cameraani.SetBool("back", back);
                basicplane.SetActive(false);

                //cameraani.SetInteger("level", choselevel);
                levelplane.SetActive(true);
                back = false;

            }
           else
            {
                cameraani.SetBool("back", back);
                cameraani.SetFloat("goback", -3);
                levelplane.SetActive(false);
                basicplane.SetActive(true);
                back = false;
                choselevel = 0;
            }

           
        }
      
        
    }

    public void click(int buttontype)
    {
        if(buttontype == 1)
        {
            back = false;
            Debug.Log("left");
            choselevel = 1;
            //basicplane.SetActive(false);
         
            //cameraani.SetInteger("level", choselevel);
            //levelplane.SetActive(true);
            buttonclick = true;
           
            
        }
        else if(buttontype ==2)
        {
            back = false;
            Debug.Log("right");
            choselevel = 2;
            //basicplane.SetActive(false);
         
            //cameraani.SetInteger("level", choselevel);
            //levelplane.SetActive(true);
            buttonclick = true;
        }
        else if(buttontype == 3)
        {
            back = true;
            //levelplane.SetActive(false);
            //cameraani.SetBool("back", back);
            //cameraani.SetFloat("goback", -3);
            //basicplane.SetActive(true);
            choselevel = 0;
            buttonclick = true;
           

        }
    }
    
    public void begin()
    {
        basicplane.SetActive(true);
    }
}
