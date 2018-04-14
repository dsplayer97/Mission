using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeControl : MonoBehaviour {
    //切换的材质
    public Texture before;
    public Texture after;
    //寄偶次碰撞判断
    public  bool isfirst;
    //获取对象
    public GameObject cube;
    //判断碰撞后是否离开，离开才可再次改变
    public bool canchange;
    // Use this for initialization
    public int cubeMelody;
    //还原控制量

    public Material m1;
    public Material m2;

    public static bool newinput;
    



	void Start () {
        //条件初始化
        isfirst = true;
        canchange = true;
        newinput = false;
		
	}
	
	// Update is called once per frame
	void Update () {
    

		
	}

     private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(isfirst);
        if (canchange)
        {
            if (isfirst)
            {
                cube.GetComponent<Renderer>().material = m1;
                isfirst = false;
            }
            else
            {
                //cube.GetComponent<Renderer>().material.mainTexture = before;
                cube.GetComponent<Renderer>().material = m2;
                isfirst = true;
            }


            canchange = false;

            //当前音阶存入当前序列
            overcontrol.inputMelody[overcontrol.serial_number] = cubeMelody;

            newinput = true;

            //序列号加1
            overcontrol.serial_number = overcontrol.serial_number + 1;
            if (overcontrol.origin)
            {
                isfirst = true;
                overcontrol.origin = false;
            }

            
            

        }
        
            
        
        

    }

    private void OnCollisionExit(Collision collision)
    {
        canchange = true;
    }


    
}
