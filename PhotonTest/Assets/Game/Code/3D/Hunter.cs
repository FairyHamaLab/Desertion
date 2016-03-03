using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hunter:MonoBehaviour{


    public int id;
    public int floor;
    private string hunter_name;
    private Button icon;
    private Text name_text;
    private HunterNameUI hunter_name_ui;
    private NvigationGame hunter_nav;
    private bool selected_coop = false;
    private int floor_mask;
    private NavMeshAgent my_agent;

    private GameObject target;
    

	// Use this for initialization
	//void Start () {
	    
	//}
    void Start()
    {
        
       icon =  PlayerUIMgr.instance.AddHunterIcon();
       icon.GetComponent<BoundObject>().SetBoundTranform(this.transform);
       //icon.onClick.AddListener(this.GetComponent<NvigationGame>().Select);
       
        hunter_nav = this.GetComponent<NvigationGame>();

       name_text = PlayerUIMgr.instance.AddText();
       name_text.GetComponent<BoundObject>().SetBoundTranform(this.transform);
       name_text.GetComponent<BoundObject>().SetGap(new Vector2(0,20));
       hunter_name_ui = HunterListPanel.instance.AddHunterName("hunter1");
       hunter_name_ui.hunter = this;

       SetName("hunter1");

       icon.GetComponent<HunterUI>().hunter = this;
       floor_mask = 1 << 8 + 1 << 9 + 1 << 10;

       my_agent = this.transform.parent.GetComponent<NavMeshAgent>();

        //追跡フラッグをoff
       target = null;
       
        
    }
	
	// Update is called once per frame
	void Update () {
	}

     public void SetName(string set_name)
    {
        name_text.text = set_name;
        hunter_name = set_name;
        hunter_name_ui.HunterNameText.text = set_name;
    }
    public void TotalSelect()
     {
        //HunterUIButtonにJoint
         icon.GetComponent<HunterUI>().Select();
         HunterViewMgr.instance.Select(this);
         hunter_name_ui.Select();
         HunterCommandUI.instance.SetTarget(this, icon.transform);
     }
    public string GetHunterName()
    {
        return hunter_name;
    }

    public void Wait()
    {
        hunter_nav.Wait();
    }
    public void Move()
    {
        hunter_nav.Select();
    }
    public void Coop()
    {
        if(selected_coop)
        {
            selected_coop = false;
        }
        else
        {
            selected_coop = true;
        }
        Debug.Log("Coop");
    }

    public void GoTarget(Transform set_transform,bool change = false)
    {
        //ターゲットを追跡中のとき
        if(target != null)
        {
            //追跡ターゲットが同じとき
            if (target == set_transform.gameObject)
            {
                my_agent.SetDestination(set_transform.position);
            }
            else
            {
                //強制的な切り替えならば
                if (change)
                {
                    target = set_transform.gameObject;
                    my_agent.SetDestination(set_transform.position);
                }
            }
        }
        else
        {
            target = set_transform.gameObject;
            my_agent.SetDestination(set_transform.position);
        }

        
    }

    public void LostTarget(GameObject lost_target)
    {
        if(lost_target == target)
        {
            target = null;
        }
        
    }
    public void NoneTarget()
    {
        //Target追跡を終了
        hunter_nav.Wait();
    }
    void OnCollisionEnter(Collision collision)
    {

        int layer_num = collision.gameObject.layer;

        if(8 <= layer_num && layer_num <= 10)
        {
            //階が変わったなら自分のレイヤーも変える！
            name_text.text = hunter_name + ":" + (layer_num - 7).ToString() + "F";
            icon.transform.GetComponentInChildren<Text>().text = hunter_name + "@" + (layer_num - 7).ToString() + "F";
            hunter_name_ui.SetFloor(layer_num - 7);
            this.gameObject.layer = layer_num + 6;
        }

  
    }

}
