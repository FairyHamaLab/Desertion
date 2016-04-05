using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeviceMgr : MonoBehaviour {

    public static DeviceMgr instance;
    public GameObject door;
    public bool check,open;
    public Text input_admi, input_signer;
    private string admi, signer;
    private int my_number;

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
	void Start () {
        my_number = 0;
        check = false;
        admi = "BOSS";
        signer = "Desertion";
        Debug.Log("名前入力未実装");
        Debug.Log("administrator : " + admi);
        Debug.Log("signer : " + signer);
    }
	
	// Update is called once per frame
	void Update () {

        Submit();
        
        if (open && my_number > -90)
        {
            door.transform.Rotate(new Vector3(0, -10f, 0));
            my_number -= 10;
        }
        else if (open)
        {

        }
        else if (my_number < 0)
        {
            door.transform.Rotate(new Vector3(0, 10f, 0));
            my_number += 10;
        }
        else
        {

        }	
	}

    /*
     * DesertionFree (input_signer.text)の部分を実装お願いします
     */
    public void Submit()
    {
        if (check)
        {
            if ( input_admi.text == admi )// && DesertionFree (input_signer.text) )
            {
                Debug.Log("成功");
                open = true;
            }
            else
            {
                Debug.Log("失敗");
                CanvasMgr.instance.miss.SetActive(true);
            }
            check = false;
        }
    }

    void OnTriggerEnter()
    {
        CanvasMgr.instance.contract.SetActive(true);
    }

    void OnTriggerExit()
    {
        CanvasMgr.instance.contract.SetActive(false);
        CanvasMgr.instance.miss.SetActive(false);
        open = false;
    }
}
