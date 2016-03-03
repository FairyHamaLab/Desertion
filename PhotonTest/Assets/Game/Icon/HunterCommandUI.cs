using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HunterCommandUI : MonoBehaviour {


    public Button Wait;
    public Button Move;
    public Button Coop;
    public Button Add;
    public Button Scout;
    

    private Hunter current_target_hunter;
    public static HunterCommandUI instance;
    private Transform canvas;
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
	// Use this for initialization
	void Start () {
        SetInteractable(false);
        canvas = BossMgr.instance.canvas;
	}
	
	// Update is called once per frame
	void Update () {
       /*
        * この状態だと、Canvasの中心からの位置を取得することができる。
        * 左右のCanvas範囲はCanvasのRectTransformに依存し、左は-CanvasWidth、右はCanvasWidth 上はCanvasHeight、下は-CanvasHeight
        */
        //Debug.Log(canvas.InverseTransformPoint(this.transform.position));
	}
    public void SetInteractable(bool set)
    {
        if (!set) this.GetComponent<RectTransform>().anchoredPosition = new Vector2(999, 999);
        Wait.interactable = set;
        Move.interactable = set;
        Coop.interactable = set;
        Add.interactable = set;
        Scout.interactable = set;
        
    }
    public void SetTarget(Hunter target,Transform target_ui_potision)
    {
        current_target_hunter = target;
        this.transform.SetParent(target_ui_potision);
        this.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        SetInteractable(true);
    }
    public void Remove()
    {
        this.transform.SetParent(null);
        SetInteractable(false);
    }

    public void PushMove()
    {
        current_target_hunter.Move();
    }
    public void PushCoop()
    {
        current_target_hunter.Coop();
    }
    public void PushWait()
    {
        current_target_hunter.Wait();
    }
    public void PushAdd()
    {
        BossMgr.instance.Add();
    }
    public void PushScout()
    {
        BossMgr.instance.Scout();
    }
    

    public void SetUIPotision_LEFT()
    {
        //左にあるとき
        Coop.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, 0);
        Scout.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 0);
        Add.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 0);
    }
    public void SetUIPotision_RIGHT()
    {
        //右にあるとき
        Coop.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40, 0);
        Scout.GetComponent<RectTransform>().anchoredPosition = new Vector2(-80, 0);
        Add.GetComponent<RectTransform>().anchoredPosition = new Vector2(-120, 0);

        
    }
    public void SetUIPotision_TOP()
    {
        //上にあるとき
        Move.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -72);
        Wait.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -36);
    }
    public void SetUIPotision_BUTTOM()
    {
        //下にあるとき;
        Wait.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 72);
        Move.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 36);

    }
    public void SetUIPotision_NOMAL()
    {
        //通常
        Wait.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -36);
        Move.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 36);
        Coop.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40, 0);
        Add.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 0);
        Scout.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 0);
    }
   
}
