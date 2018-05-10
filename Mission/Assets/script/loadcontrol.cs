using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadcontrol : MonoBehaviour {
    //接下来需要加载的场景ID
    public static int loadID;
    public static int lunchmode = 0;

    public GameObject basicPanel;
    public GameObject backGround;
    public GameObject AboutUs;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void click(int Buttontype)
    {
        switch (Buttontype)
        {
            case 1:
                loadID = 2;//0 mainscense  1 loadscense 2 elect
                SceneManager.LoadScene("loadscense");
                lunchmode = 1;
                break;
            case 2:
                loadID = 2;//0 mainscense  1 loadscense 2 elect
                SceneManager.LoadScene("loadscense");
                lunchmode = 2;
                break;
            case 3:
                Debug.Log("3");
                basicPanel.SetActive(true);
                backGround.SetActive(true);
                break;
            case 4:
                Debug.Log("4");
                basicPanel.SetActive(true);
                AboutUs.SetActive(true);
                break;
            case 5:          
                backGround.SetActive(false);
                basicPanel.SetActive(false);
                break;
            case 6:
                AboutUs.SetActive(false);
                basicPanel.SetActive(false);
                break;

            default:
                break;

        }
    }


    
}
