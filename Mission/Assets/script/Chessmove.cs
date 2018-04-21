using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessmove : MonoBehaviour {

    Hashtable chessmovetable = new Hashtable();

    /*触屏检测
    /*敏感度*/
    /* private float fingerActionSensitivity = Screen.width * 0.05f;
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
     private int FINGER_STATE_ADD = 2;*/
    // Use this for initialization

    // Use this for initialization
    void Start() {

        //移动的速度，  
        chessmovetable.Add("speed", 10f);
        //移动的整体时间。如果与speed共存那么优先speed  
        chessmovetable.Add("time", 2f);
        chessmovetable.Add("loopType", "none");
        chessmovetable.Add("delay", 0.1f);
        chessmovetable.Add("y", 0.04f);
        chessmovetable.Add("x", 0f);
        chessmovetable.Add("z", 0f);
        /*触屏检测*/
        /* fingerActionSensitivity = Screen.width * 0.05f;

         fingerBeginX = 0;
         fingerBeginY = 0;
         fingerCurrentX = 0;
         fingerCurrentY = 0;
         fingerSegmentX = 0;
         fingerSegmentY = 0;

         fingerTouchState = FINGER_STATE_NULL;*/


    }

    // Update is called once per frame
    void Update() {

        
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;

                //gameObj.transform.Translate(new Vector3(0, 0.06f, 0));
                iTween.MoveAdd(gameObj, chessmovetable);
                
            }
        }
        



        /*
        GameObject gameObj = new GameObject();

        if (Input.touchCount == 1)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    gameObj = hitInfo.collider.gameObject;

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
                        chessmovetable.Add("x", 0.04f);
                    }
                    else
                    {
                        chessmovetable.Add("x", -0.04f);
                    }
                }
                else
                {
                    if (s02 > 0)
                    {
                        chessmovetable.Add("y", 0.04f);
                    }
                    else
                    {
                        chessmovetable.Add("y", -0.04f);
                    }
                }
            }

            if(Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                iTween.MoveAdd(gameObj, chessmovetable);
            }

          }*/


        /*Ray ray = new Ray();
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (fingerTouchState == FINGER_STATE_NULL)
            {
                fingerTouchState = FINGER_STATE_TOUCH;
                fingerBeginX = Input.mousePosition.x;
                fingerBeginY = Input.mousePosition.y;
            }
        }
            if (fingerTouchState == FINGER_STATE_TOUCH)
            {
                fingerCurrentX = Input.mousePosition.x;
                fingerCurrentY = Input.mousePosition.y;
                fingerSegmentX = fingerCurrentX - fingerBeginX;
                fingerSegmentY = fingerCurrentY - fingerBeginY;

            }

            if (fingerTouchState == FINGER_STATE_TOUCH)
            {
                float fingerDistance = fingerSegmentX * fingerSegmentX + fingerSegmentY * fingerSegmentY;

                if (fingerDistance > (fingerActionSensitivity * fingerActionSensitivity))
                {
                    toAddFingerAction();
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                fingerTouchState = FINGER_STATE_NULL;
            }
           

           

            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                iTween.MoveAdd(gameObj, chessmovetable);
            }*/



    }

        /* private void toAddFingerAction()
         {

             fingerTouchState = FINGER_STATE_ADD;

             if (Mathf.Abs(fingerSegmentX) > Mathf.Abs(fingerSegmentY))
             {
                 fingerSegmentY = 0;
             }
             else
             {
                 fingerSegmentX = 0;
             }

             if (fingerSegmentX == 0)
             {
                 if (fingerSegmentY > 0)
                 {
                     chessmovetable.Add("y", 0.04f);
                 }
                 else
                 {
                     chessmovetable.Add("y", -0.04f);
                 }
             }
             else if (fingerSegmentY == 0)
             {
                 if (fingerSegmentX > 0)
                 {
                     chessmovetable.Add("x", 0.04f);
                 }
                 else
                 {
                     chessmovetable.Add("x", -0.04f);
                 }
             }

         }*/
    }

