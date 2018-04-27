using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chessmove : MonoBehaviour {

    
    private int[,] chessmap = new int[8,6];
    private int[,] rightchessmap = new int[8, 6];
    //private Animator chessani;
    //private Animator linkchessani;
    public GameObject[] chesslist;

    private GameObject gameobj;
    private GameObject linkgameobj;

    /*触屏检测
    /*敏感度*/
     private float fingerActionSensitivity = Screen.width * 0.05f;
     //
     private float fingerBeginX;
     private float fingerBeginY;
     private float fingerCurrentX;
     private float fingerCurrentY;
     private float fingerSegmentX;
     private float fingerSegmentY;
     //
     private int fingerTouchState;
     //
     private int FINGER_STATE_NULL = 0;
     private int FINGER_STATE_TOUCH = 1;
     private int FINGER_STATE_ADD = 2;
    // Use this for initialization

     private float x1,x2, y, z;


    private int movestate = 0;
    // Use this for initialization
    void Start() {

        //创建棋盘表
        createchessmap(chessmap);
        //初始化棋盘表
        initchessmap(chessmap);

        /*触屏检测*/
         fingerActionSensitivity = Screen.width * 0.05f;

         fingerBeginX = 0;
         fingerBeginY = 0;
         fingerCurrentX = 0;
         fingerCurrentY = 0;
         fingerSegmentX = 0;
         fingerSegmentY = 0;

         fingerTouchState = FINGER_STATE_NULL;


    }

    // Update is called once per frame
    void Update() {

        /*
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
                    gameobj.transform.DOMoveX(x3 + 0.065f, 3);
                    linkgameobj.transform.DOMoveX(x4 - 0.065f, 3);
                }
                //Debug.Log(chessmap[1, 2]);
            }
        }    */
        


        
        
       
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

                            gameobj.transform.DOMoveZ(z + 0.065f, 1);
                            linkgameobj.transform.DOMoveZ(z + 0.06f, 1);
                            break;

                        case 2:

                            gameobj.transform.DOMoveZ(z - 0.065f, 1);
                            linkgameobj.transform.DOMoveZ(z - 0.065f, 1);
                            break;
                        case 3:

                            gameobj.transform.DOMoveX(x1 - 0.065f, 1);
                            linkgameobj.transform.DOMoveX(x2 + 0.065f, 1);
                            break;
                        case 4:

                            gameobj.transform.DOMoveX(x1 + 0.065f, 1);
                            linkgameobj.transform.DOMoveX(x2 - 0.065f, 1);
                            break;
                        default:
                            break;


                    }
                }
                

                movestate = 0;


            }

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


    }

