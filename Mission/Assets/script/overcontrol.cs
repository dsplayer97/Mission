using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overcontrol : MonoBehaviour
{
    //正确的音符序列
    private static int[] rightMelody = { 1,2,3,1,5,3,2,5,2};
    //输入的音符序列
    public static int[] inputMelody = new int[9];
    //碰撞顺序
    public static int serial_number = 0;
    // Use this for initializatio

    public GameObject noticePanel;
    public Text noticeText;
    
    public  GameObject cube1;
    public  GameObject cube2;
    public  GameObject cube3;
    public  GameObject cube4;
    public  GameObject cube5;
    
    public static bool origin = false;
    public static Texture before;
    public static Texture after;

    public Material m2;

	
	// Update is called once per frame
	void Update() {
        //initinputMelody();
        //Debug.Log(inputMelody[serial_number] + "...." + rightMelody[serial_number]);
        //
        if (serial_number.Equals(1))
        {
           Debug.Log("检测了检测了！！！");
            for (int i = 0; i < 9; i++)
            {
                //Debug.Log(inputMelody[serial_number - 1] + "...." + rightMelody[serial_number - 1]);
                //cubeControl.newinput = false;
                if (inputMelody[i] != rightMelody[i])
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
                else
                {
                    if (i == 8) {
                        //旋律匹配成功后续
                        cameracontrol.levelpass[0] = true;
                        PlayerPrefs.SetInt("passlevel1", 1);
                        noticeText.text = "Something just happend, I can hear it";
                        noticePanel.SetActive(true);
                    }

                }

            }
           
        }
	}


    public  void initinputMelody()
    {
        for (int i = 0; i < 9; i++)
        {
            inputMelody[i] = 0;
        }
    }


}
