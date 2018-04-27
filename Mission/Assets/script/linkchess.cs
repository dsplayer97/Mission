using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkchess : MonoBehaviour {

    public  GameObject linkobj;

    //1-pawn 2-knight 3-biship 4-rook 5-king@queen
    public int chessCode;

    public int[] position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public GameObject getlinkobj()
    {
        return linkobj;
    }
}
