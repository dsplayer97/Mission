using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeControl : MonoBehaviour {

    public Material before;
    public Material after;
    private bool isfirst;

	// Use this for initialization
	void Start () {
        isfirst = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (isfirst)
        {
            this.GetComponent<MeshRenderer>().material = after;
            isfirst = false;
        }
        else{
            this.GetComponent<MeshRenderer>().material = before;
            isfirst = true;
        }

    }

}
