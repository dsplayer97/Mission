using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class control : MonoBehaviour
{

    // Use this for initialization
    private float x, y;
    //rigbody
    public Rigidbody squ;
    //音源
    public AudioClip audioClip;
    //Audiosource组件
    private AudioSource _audioSource;


    void Start()
    {
        //小球速度设置初始化
        x = 0;
        y = 0;

        //小球移动音效初始化

        //在添加此脚本的对象中添加AudioSource组件

        _audioSource = this.gameObject.AddComponent<AudioSource>();

        //设置循环播放  

        _audioSource.loop = true;

        //设置音量为最大，区间在0-1之间  

        _audioSource.volume = 1.0f;

        //设置audioClip  

        _audioSource.clip = audioClip;
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




        /* 使小球在力作用下移动，以便小球运动符合物理规律
         * 受力来源于重力感应
         * 重力感应的X，Y分别控制小球的X,Z，具体原因参见关于收集重力感应的叙述
         */
        squ.AddForce(new Vector3(x, 0, y), ForceMode.Force);

        //判断是否播放音效，使用rigbody.velocity获取刚体的速度，该速度为一个Velocity3
        if(squ.velocity != new Vector3(0, 0, 0))
        {
            //没速度时暂停
            _audioSource.Pause();

            //没速度时停止（从头播放）
            //_audioSource.Stop();
        }
        else
        {  //有速度时播放
            _audioSource.Play();
        }
    
       
  
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
