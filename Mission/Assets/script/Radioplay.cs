using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioplay : MonoBehaviour {

    public AudioClip audioClip;
    //Audiosource组件
    private AudioSource _audioSource;

    private GameObject gameobj;


    private bool click = false;
    private bool play = false;

    // Use this for initialization
    void Start () {
        _audioSource = this.gameObject.AddComponent<AudioSource>();

        //设置循环播放  

        _audioSource.loop = false;

        //设置音量为最大，区间在0-1之间  

        _audioSource.volume = 1.0f;

        //设置audioClip  

        _audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
        if (cameracontrol.levelpass[1])
        {
            _audioSource.Stop();
        }
    
         if (Input.touchCount == 1)
         {
             if (Input.touches[0].phase == TouchPhase.Began)
             {
                 Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                 RaycastHit hitInfo;
                 if (Physics.Raycast(ray, out hitInfo))
                 {
                     gameobj = hitInfo.collider.gameObject;
                 }
             }


             if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
             {
                if(gameobj.name.Equals("colider"))
                 {
                 if (click)
                 {
                     click = false;
                 }
                 else
                 {
                     click = true;
                 }
                 
                     if (click)
                     {
                         _audioSource.Play();
                     }
                     else
                     {
                         _audioSource.Stop();
                     }
                 }


             }

         }

       /* if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("我点了！！！");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                gameobj = hitInfo.collider.gameObject;
                Debug.Log("name" + gameobj.tag);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("执行到这了！！！");
            if (gameobj.name.Equals("colider"))
            {
                if (click)
                {
                    click = false;
                }
                else
                {
                    click = true;
                }

                Debug.Log("相等了！！！到这了");
                if (click)
                {
                    _audioSource.Play();
                }
                else
                {
                    _audioSource.Stop();
                }
            }
            
        }*/



        }

    public void radioclick()
    {
        Debug.Log("点了");
        if (click)
        {
            click = false;
        }
        else
        {
            click = true;
        }

        if (click)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
