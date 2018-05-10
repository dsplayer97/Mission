using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class control : MonoBehaviour
{

    // Use this for initialization
    private float x, y;
    //rigbody
    private Rigidbody squ;
    //音源
    public AudioClip audioClip;
    //Audiosource组件
    private AudioSource _audioSource;

    public GameObject ball;

    private bool audioisplay;


    void Start()
    {
        //小球速度设置初始化
        x = 0;
        y = 0;

        squ = ball.GetComponent<Rigidbody>();

        //小球移动音效初始化

        //在添加此脚本的对象中添加AudioSource组件

        _audioSource = this.gameObject.AddComponent<AudioSource>();

        //设置循环播放  

        _audioSource.loop = true;

        //设置音量为最大，区间在0-1之间  

        _audioSource.volume = 1.0f;

        //设置audioClip  

        _audioSource.clip = audioClip;

        audioisplay = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        x = Input.acceleration.x*10;
        y = Input.acceleration.y*10;
        
        //测试用代码
        /*
        if (Input.GetKeyDown(KeyCode.W)){
            x = 0.3f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            x = -0.3f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            y = 0.3f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            y = -0.3f;
        }
        */

        /* speed = Mathf.Sqrt(x * x + y * y);
         //Vector3.right x zhou  
         horizontalMovement = Input.GetAxis("Horizontal") * Vector3.right * speed;

         //z zhou  
         verticalMovement = Input.GetAxis("Vertical") * Vector3.forward * speed;

         //小球的运动  
         Vector3 movement = horizontalMovement + verticalMovement;*/




        /* 使小球在力作用下移动，以便小球运动符合物理规律
         * 受力来源于重力感应
         * 重力感应的X，Y分别控制小球的X,Z，具体原因参见关于收集重力感应的叙述
         */

        moveAudioControl(moveDetect());
        squ.AddForce(new Vector3(x, 0, y), ForceMode.Force);

        //移动音效控制
        
    
       
  
   

    }
    //移动检测
    public bool moveDetect()
    {
        if(squ.velocity.x < 0.1f && squ.velocity.x > -0.1f)
        {
            if (squ.velocity.z < 0.1f && squ.velocity.z > -0.1f)
            {
                         return false;
            }
            else
            {
                return true;
            }
                
        }
        else
        {
            return true;
        }
       
       
    }
    //移动音效控制
    public void moveAudioControl(bool ismove)
    {
        if (!audioisplay)
        {
            if (ismove)
            {
                _audioSource.Play();
                audioisplay = true;
               // Debug.Log("Play");
            }
        }
        else
        {
            if (!ismove)
            {
                _audioSource.Stop();
                audioisplay = false;
                //Debug.Log("Stop");
            }
        }
    }
}
