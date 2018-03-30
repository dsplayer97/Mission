using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Data 2018/3/30 Author Ds
 * Function 碰撞音效控制
 * Version 1.0
 */
public class collisionaudio : MonoBehaviour {

    //音源
    public AudioClip audioClip;
    //Audiosource组件
    private AudioSource _audioSource;


    // Use this for initialization
    void Start () {

        //在添加此脚本的对象中添加AudioSource组件
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
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        _audioSource.Play();
    }
}
