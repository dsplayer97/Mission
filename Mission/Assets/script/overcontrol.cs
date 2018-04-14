using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overcontrol : MonoBehaviour {
    //正确的音符序列
    private int[] rightMelody = { 1,2,3,1,5,3,2,5,2};
    //输入的音符序列
    public static int[] inputMelody = new int[9];
    //碰撞顺序
    public static int serial_number = 0;
    // Use this for initialization
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;

    public static bool origin = false;
    public Texture before;
    public Texture after;

    public Material m2;

    void Start () {

        initinputMelody();
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(inputMelody[serial_number] + "...." + rightMelody[serial_number]);
        if (serial_number == 9)
        {
            for (int i = 0; i < 9; i++)
            {
                Debug.Log(inputMelody[serial_number - 1] + "...." + rightMelody[serial_number - 1]);
                //cubeControl.newinput = false;
                if (inputMelody[serial_number] != rightMelody[serial_number])
                {
                    /*cube1.GetComponent<Renderer>().material.mainTexture = before;
                    cube2.GetComponent<Renderer>().material.mainTexture = before;
                    cube3.GetComponent<Renderer>().material.mainTexture = before;
                    cube4.GetComponent<Renderer>().material.mainTexture = before;
                    cube5.GetComponent<Renderer>().material.mainTexture = before;*/

                    cube1.GetComponent<Renderer>().material = m2;
                    cube2.GetComponent<Renderer>().material = m2;
                    cube3.GetComponent<Renderer>().material = m2;
                    cube4.GetComponent<Renderer>().material = m2;
                    cube5.GetComponent<Renderer>().material = m2;
                    origin = true;

                    initinputMelody();


                    serial_number = 0;

                    break;
                }
                else if (inputMelody[8] != rightMelody[8])
                {
                    //旋律匹配成功后续

                }

            }
        }
	}


    public void initinputMelody()
    {
        for (int i = 0; i < 9; i++)
        {
            inputMelody[i] = 0;
        }
    }


}
