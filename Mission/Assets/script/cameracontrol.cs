using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameracontrol : MonoBehaviour {

    public Animator cameraani;
    private int choselevel = 0;
    private bool back = false;
    private bool buttonclick = false;
    private bool ballturnclick = false;
    private bool turnState = false;
    private bool gamecompelete = false;
    //相机当前状态，判断在哪个界面，主界面为0，小球为1，棋盘为2
    private int camerastate = 0;

    float alpha = 0;

    private bool musicplay = false;

    public AudioClip audioClip;
    //Audiosource组件
    private AudioSource _audioSource;

    public GameObject basicplane;
    public GameObject backbutton;
    public GameObject hintbutton;
    public GameObject ballpanel;
    public GameObject passPanel;
    //private GameObject camera;

    public GameObject noticePanel;
    public Text noticeText;

    public GameObject hintPanel;
    public Text hintText;

    //通关记录，两个部分
    public static bool[] levelpass = new bool[2];


    // Use this for initialization
    void Start () {
        this.GetComponent<control>().enabled = false;
        this.GetComponent<Chessmove>().enabled = false;
        //camera = GameObject.FindGameObjectWithTag("MainCamera");
        if (loadcontrol.lunchmode == 1)
        {
            levelpass[0] = false;
            levelpass[1] = false;
            PlayerPrefs.SetInt("passlevel1", 0);
            PlayerPrefs.SetInt("passlevel2", 0);
        }
        else
        {
            if(PlayerPrefs.GetInt("passlevel1",0) == 1)
            {
                levelpass[0] = true;
            }
            else
            {
                levelpass[0] = false;
            }


            if (PlayerPrefs.GetInt("passlevel2", 0) == 1)
            {
                levelpass[1] = true;
            }
            else
            {
                levelpass[1] = false;
            }

        }

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
        //Debug.Log(gamecompelete);
        if (gamecompelete)
        {
            //passPanel.SetActive(true);
            if (!musicplay)
            {
                _audioSource.Play();
                musicplay = true;
            }
            alpha = alpha + 0.005f;
            passPanel.GetComponent<Image>().color = new Color(passPanel.GetComponent<Image>().color.r, passPanel.GetComponent<Image>().color.g, passPanel.GetComponent<Image>().color.b, alpha);
        }
        if (buttonclick)
        {
             buttonclick = false;

            switch (choselevel)
            {
                case 0:
                    this.GetComponent<control>().enabled = false;
                    this.GetComponent<Chessmove>().enabled = false;
                    cameraani.SetBool("back", back);
                    cameraani.SetFloat("goback", -3);
                    camerastate = 0;
                    ballpanel.SetActive(false);
                    basicplane.SetActive(true);
                    backbutton.SetActive(false);
                    back = false;
                    choselevel = 0;
                    break;
                case 1:
                    this.GetComponent<control>().enabled = false;
                    if (!levelpass[1]) { 
                    this.GetComponent<Chessmove>().enabled = true;
                                       }
                    ballpanel.SetActive(false);
                    cameraani.SetInteger("level", choselevel);
                    cameraani.SetBool("back", back);
                    camerastate = 2;
                    basicplane.SetActive(false);

                    //cameraani.SetInteger("level", choselevel);
                    backbutton.SetActive(true);
                    back = false;
                    break;
                case 2:
                    if (!levelpass[0])
                    {
                        this.GetComponent<control>().enabled = true;
                    }
                    this.GetComponent<Chessmove>().enabled = false;
                    ballpanel.SetActive(true);
                    cameraani.SetInteger("level", choselevel);
                    cameraani.SetBool("back", back);
                    camerastate = 1;
                    basicplane.SetActive(false);
                    //cameraani.SetInteger("level", choselevel);
                    backbutton.SetActive(true);
                    back = false;
                    break;
                default:

                    break;


            }

           
        }
      
        
    }

    public void click(int buttontype)
    {
        

        switch (buttontype)
        {
            case 1:
                back = false;
                Debug.Log("left");
                choselevel = 1;
                //basicplane.SetActive(false);

                //cameraani.SetInteger("level", choselevel);
                //levelplane.SetActive(true);
                buttonclick = true;
                break;
            case 2:
                back = false;
                Debug.Log("right");
                choselevel = 2;
                //basicplane.SetActive(false);

                //cameraani.SetInteger("level", choselevel);
                //levelplane.SetActive(true);
                buttonclick = true;
                break;
            case 3:
                back = true;
                //levelplane.SetActive(false);
                //cameraani.SetBool("back", back);
                //cameraani.SetFloat("goback", -3);
                //basicplane.SetActive(true);
                choselevel = 0;
                buttonclick = true;
                break;
                //提示按钮
            case 4:
                
                switch (camerastate)
                {
                    case 0:
                        basicplane.SetActive(false);
                        hintText.text = "Look around\n\nTry to find something";
                        break;
                    case 1:
                        ballpanel.SetActive(false);
                            hintText.text = "My grandfather's favorite song was always with you\n\nEspecially the beginning part\n\nIt was the bell of his class when he was at school\n\nI remember it start with Do. ";
                        break;
                    case 2:
                        if (levelpass[0])
                        {
                            hintText.text = "Grandfather don't know how to play chess\n\nHe always puts it in neat order as an ornament. ";
                        }
                        else
                        {
                            hintText.text = "Look around\n\nTry to find something";
                        }
                        break;
                    default:
                        hintText.text = "Look around\n\nTry to find something";
                        break;


                }
             
                hintPanel.SetActive(true);
                break;
                //关闭提示页面
            case 5:
                Debug.Log("点到关闭了");
                switch (camerastate)
                {
                    case 0:
                        basicplane.SetActive(true);
                        break;
                    case 1:
                        ballpanel.SetActive(true);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                hintPanel.SetActive(false);
                hintText.text = "";
                break;
                //转视角
            case 6:

                ballturnclick = true;
                if (ballturnclick)
                {
                    ballturnclick = false;
                    if (turnState)
                    {
                        turnState = false;
                        //ballpanel.SetActive(true);
                        backbutton.SetActive(true);
                    }
                    else
                    {
                        turnState = true;
                        //ballpanel.SetActive(false);
                        backbutton.SetActive(false);
                    }
                    Debug.Log("执行动画");
                    cameraani.SetBool("balltoradio", turnState);
                }
                break;
                //关闭通知
            case 7:
                noticePanel.SetActive(false);
                noticeText.text = "";
                if(levelpass[0] && levelpass[1])
                {
                    hintbutton.SetActive(false);
                    backbutton.SetActive(false);
                    basicplane.SetActive(false);
                    ballpanel.SetActive(false);
                    passPanel.SetActive(true);
                    gamecompelete = true;
                }
                break;
            default:
                break;
        }
    }
    
    public void begin()
    {
        hintbutton.SetActive(true);
        basicplane.SetActive(true);
    }
}
