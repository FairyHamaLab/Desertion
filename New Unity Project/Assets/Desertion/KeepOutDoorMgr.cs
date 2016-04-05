using UnityEngine;
using System.Collections;

public class KeepOutDoorMgr : MonoBehaviour {

    public KeepOutDoorMgr instance;
    public GameObject SecondFromFirst, ThirdFromSecond;
    private int DesertionNumber;
	// Use this for initialization

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
	void Start () 
    {
        //DesertionNumber = "ここに逃走者の人数を入れる"
        /*
         * 人数によって行ける階層を設定
         */
        switch (DesertionNumber)
        {
            case 1 :
                SecondFromFirst.transform.position -= new Vector3(0f, 100f, 0f);
                ThirdFromSecond.transform.position -= new Vector3(0f, 100f, 0f);
                break;

            case 2 :
            case 3 :
                ThirdFromSecond.transform.position -= new Vector3(0f, 100f, 0f);
                break;

            default :
                break;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
