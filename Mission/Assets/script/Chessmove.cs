using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Chessmove : MonoBehaviour {


    private int[,] chessmap = new int[8, 6];
    private int[,] rightchessmap = new int[8, 6];
    //private Animator chessani;
    //private Animator linkchessani;
    public GameObject[] chesslist;
    public GameObject Allchess;
    private GameObject gameobj;
    private GameObject linkgameobj;

    public GameObject noticePanel;
    public Text noticeText;

    private bool chessup = false;
    

    // Use this for initialization

     private float x1,x2, y, z;


    private int movestate = 0;
    // Use this for initialization
    void Start() {

        //创建棋盘表
        createchessmap(chessmap);
        //初始化棋盘表
        initchessmap(chessmap);
        //初始化正确棋盘
        initRightChessMap(rightchessmap);
    }

    // Update is called once per frame
    void Update() {
        //PC测试用代码
        /*
        if (!chessup)
        {
            //if (cameracontrol.levelpass[0] || cameracontrol.levelpass[1])
            //{
                Allchess.transform.DOMoveY(Allchess.transform.position.y + 0.35f, 1);
                chessup = true;
           // }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
               // GameObject gameObj = hitInfo.collider.gameObject;

                //gameObj.transform.Translate(new Vector3(0, 0.06f, 0));
                //iTween.MoveAdd(gameObj, chessmovetable);
                movestate = 1;
                gameobj = hitInfo.collider.gameObject;
                //chessani = gameobj.GetComponent<Animator>();
                linkgameobj = gameobj.GetComponent<linkchess>().linkobj;
                //linkchessani = linkgameobj.GetComponent<Animator>();
                //chessani.SetInteger("direction", movestate);
                //linkchessani.SetInteger("direction", movestate);
               
                float x3 = gameobj.transform.position.x;
                float x4 = linkgameobj.transform.position.x;
                z = gameobj.transform.position.z;
                linkgameobj = gameobj.GetComponent<linkchess>().linkobj;
                movestate = 1;
                if (CanMoveCheck(gameobj, linkgameobj, movestate))
                {
                    gameobj.transform.DOMoveX(x3 + 0.25f, 3);
                    linkgameobj.transform.DOMoveX(x4 - 0.25f, 3);
                }
                //Debug.Log(chessmap[1, 2]);
            }
        }    
        */
        
        if (!chessup)
        {
            //if(cameracontrol.levelpass[0] || cameracontrol.levelpass[1])
            //{
                Allchess.transform.DOMoveY(Allchess.transform.position.y + 0.35f, 1);
                chessup = true;
            //}
        }

        //棋子触屏移动控制
        if (Input.touchCount == 1)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    gameobj = hitInfo.collider.gameObject;
                    //chessani = gameobj.GetComponent<Animator>();
                    linkgameobj = gameobj.GetComponent<linkchess>().linkobj;
                    
                     x1 = gameobj.transform.position.x;
                     x2 = linkgameobj.transform.position.x;
                     z = gameobj.transform.position.z;
                    //linkchessani = linkgameobj.GetComponent<Animator>();
                    //Debug.Log(gameobj.name);

                }
            }

            if(Input.touches[0].phase == TouchPhase.Moved)
            {
                float s01 = Input.GetAxis("Mouse X");
                float s02 = Input.GetAxis("Mouse Y");
                if (Mathf.Abs(s01) > Mathf.Abs(s02))
                {
                    if (s01 > 0)
                    {

                        movestate = 4;
                    }
                    else
                    {
                        movestate = 3;
                    }
                }
                else
                {
                    if (s02 > 0)
                    {
                        movestate = 1;
                    }
                    else
                    {
                        movestate = 2;
                    }
                }
            }

            if(Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                //iTween.MoveAdd(gameobj, chessmovetable);
                //chessani.SetInteger("direction", movestate);
                //linkchessani.SetInteger("direction", movestate);
                if (CanMoveCheck(gameobj,linkgameobj,movestate))
                {
                    switch (movestate)
                    {
                        case 1:

                            gameobj.transform.DOMoveZ(z + 0.25f, 1);
                            linkgameobj.transform.DOMoveZ(z + 0.25f, 1);
                            movestate = 0;
                            break;

                        case 2:

                            gameobj.transform.DOMoveZ(z - 0.25f, 1);
                            linkgameobj.transform.DOMoveZ(z - 0.25f, 1);
                            movestate = 0;
                            break;
                        case 3:

                            gameobj.transform.DOMoveX(x1 - 0.25f, 1);
                            linkgameobj.transform.DOMoveX(x2 + 0.25f, 1);
                            movestate = 0;
                            break;
                        case 4:

                            gameobj.transform.DOMoveX(x1 + 0.25f, 1);
                            linkgameobj.transform.DOMoveX(x2 - 0.25f, 1);
                            movestate = 0;
                            break;
                        default:
                            movestate = 0;
                            break;


                    }
                }
                

                


            }

          }



        //通关检测
        if (chessPassDetect(chessmap, rightchessmap))
        {
            cameracontrol.levelpass[1] = true;
            PlayerPrefs.SetInt("passlevel2", 1);
            noticeText.text = "I find an old CD, and I will play it now";
            noticePanel.SetActive(true);

        }
      
       
    }
    


    public void createchessmap(int[,] chessmap)
    {
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                chessmap[i, j] = 0;
            }
        }
    }

    public void initchessmap(int[,] chessmap)
    {
        for (int i = 0; i < 16; i++)
        {
            //获取棋子x轴坐标
            int intx = chesslist[i].GetComponent<linkchess>().position[0];
           
            //获取棋子y轴坐标
            int inty = chesslist[i].GetComponent<linkchess>().position[1];
            //获取棋子编码
            int chesscode = chesslist[i].GetComponent<linkchess>().chessCode;
            chessmap[intx, inty] = chesscode;
        }
        
    }

    public bool CanMoveCheck(GameObject choseChess,GameObject linkChess, int movecode)
    {
        //获取棋子x轴坐标
        int cintx = choseChess.GetComponent<linkchess>().position[0];
        //获取棋子y轴坐标
        int cinty = choseChess.GetComponent<linkchess>().position[1];
        Debug.Log(cintx + "..." + cinty);

        //获取棋子x轴坐标
        int lintx = linkChess.GetComponent<linkchess>().position[0];
        //获取棋子y轴坐标
        int linty = linkChess.GetComponent<linkchess>().position[1];

        int choseChessCode = choseChess.GetComponent<linkchess>().chessCode;
        int lintxChoseCode = linkChess.GetComponent<linkchess>().chessCode;

        switch (movecode)
        {
            case 1:
                if (cinty < 8)
                {
                    //Debug.Log(chessmap[cintx, cinty + 1]);
                    
                    if (chessmap[cintx, cinty + 1] == 0 && chessmap[lintx, linty + 1] == 0)
                    {
                        choseChess.GetComponent<linkchess>().position[1] = cinty + 1;
                        linkChess.GetComponent<linkchess>().position[1] = linty + 1;
                        //Debug.Log(cinty);
                        //Debug.Log(choseChess.GetComponent<linkchess>().position[1]);
                        chessmap[cintx, cinty] = 0;
                        chessmap[lintx, linty] = 0;
                        chessmap[cintx, cinty + 1] = choseChessCode;
                        chessmap[lintx, linty + 1] = lintxChoseCode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
            case 2:
                if (cinty > 0)
                {
                    if (chessmap[cintx, cinty - 1] == 0 && chessmap[lintx, linty - 1] == 0)
                    {
                        choseChess.GetComponent<linkchess>().position[1] = choseChess.GetComponent<linkchess>().position[1] - 1;
                        linkChess.GetComponent<linkchess>().position[1] = linkChess.GetComponent<linkchess>().position[1] - 1;
                        chessmap[cintx, cinty] = 0;
                        chessmap[lintx, linty] = 0;
                        chessmap[cintx, cinty - 1] = choseChessCode;
                        chessmap[lintx, linty - 1] = lintxChoseCode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case 3:
                if (cintx > 0)
                {
                    if (chessmap[cintx - 1, cinty] == 0 && chessmap[lintx + 1, linty] == 0)
                    {
                        choseChess.GetComponent<linkchess>().position[0] = choseChess.GetComponent<linkchess>().position[0] - 1;
                        linkChess.GetComponent<linkchess>().position[0] = linkChess.GetComponent<linkchess>().position[0] + 1;
                        chessmap[cintx, cinty] = 0;
                        chessmap[lintx, linty] = 0;
                        chessmap[cintx-1, cinty] = choseChessCode;
                        chessmap[lintx+1, linty] = lintxChoseCode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else{
                    return false;
                }
            
            case 4:
                if (cintx < 8)
                {
                    if (chessmap[cintx + 1, cinty] == 0 && chessmap[lintx - 1, linty] == 0)
                    {
                        choseChess.GetComponent<linkchess>().position[0] = choseChess.GetComponent<linkchess>().position[0] + 1;
                        linkChess.GetComponent<linkchess>().position[0] = linkChess.GetComponent<linkchess>().position[0] - 1;
                        chessmap[cintx, cinty] = 0;
                        chessmap[lintx, linty] = 0;
                        chessmap[cintx+1, cinty] = choseChessCode;
                        chessmap[lintx-1, linty] = lintxChoseCode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            default:
                return false;
              

        }

       
    }

    public void initRightChessMap(int[,] chessmap)
    {
        //初始化第一排,国王皇后的排
        for(int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0:
                    chessmap[i, 0] = 2;
                    break;
                case 1:
                    chessmap[i, 0] = 3;
                    break;
                case 2:
                    chessmap[i, 0] = 4;
                    break;
                case 3:
                    chessmap[i, 0] = 5;
                    break;
                case 4:
                    chessmap[i, 0] = 5;
                    break;
                case 5:
                    chessmap[i, 0] = 4;
                    break;
                case 6:
                    chessmap[i, 0] = 3;
                    break;
                case 7:
                    chessmap[i, 0] = 2;
                    break;
            }
            
        }
        //初始化第二排，小兵
        for(int i = 0; i < 8; i++)
        {
            chessmap[i, 1] = 1;
        }
        //初始化剩余空白项
        for(int i = 2; i < 6; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                chessmap[j, i] = 0;
            }
        }
    }

    public bool chessPassDetect(int[,] chessmap, int[,] rightchessmap)
    {
        if (chessmap.Equals(rightchessmap))
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    }

