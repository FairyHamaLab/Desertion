using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMgr : MonoBehaviour {
    public enum Item
    {
        BIND, ALERT
    }

    public static CanvasMgr instance = null;
    public Canvas canvas;

    public GameObject direction_word_left, direction_word_right, direction_word_forward;
    public GameObject item_name_text,alert;
    public GameObject contract,miss;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ViewItemText(Item item)
    {
        GameObject new_itemname = (GameObject)Instantiate(item_name_text);
        new_itemname.transform.SetParent(this.transform);
        new_itemname.transform.localPosition = Vector3.zero;
        new_itemname.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        new_itemname.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);

        switch (item)
        {
            case Item.BIND:
                item_name_text.GetComponent<Text>().text = "Bind Trap Get!!";

                break;
            case Item.ALERT:
            default:
                item_name_text.GetComponent<Text>().text = "Alert Get!!";
                break;
        }
    }

    /*
     * 文字を表示
     */
    public void DirectionWord_display( int derection )
    {
        if (derection == 0)
        {
            direction_word_left.gameObject.SetActive(true);
        }

        else if (derection == 1)
        {
            direction_word_right.gameObject.SetActive(true);
        }
        else if (derection == 2)
        {
            direction_word_forward.gameObject.SetActive(true);
        }

           
    }

    /*
     * 表示した文字を非表示に
     */
    public void DirectionWord_hidden(int derection)
    {
        if (derection == 0)
        {
            direction_word_left.gameObject.SetActive(false);
        }

        else if (derection == 1)
        {
            direction_word_right.gameObject.SetActive(false);
        }
        else if (derection == 2)
        {
            direction_word_forward.gameObject.SetActive(false);
        }
    }
}


