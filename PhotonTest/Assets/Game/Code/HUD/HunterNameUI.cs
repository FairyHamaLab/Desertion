using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HunterNameUI : MonoBehaviour {

    public Button HunterNameButton;
    public Text HunterNameText;
    public Hunter hunter;
    private string HunterName;
    private int current_floor;


	// Use this for initialization
	void Start () {
        current_floor = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Nameの設定
    public void SetHunterName(string set_name)
    {
        
        HunterName = set_name ;
        UpdateText();
    }
    public void Select()
    {
       
    }
    public void PushButton()
    {
        BossMgr.instance.JointCamera(hunter.gameObject.transform);
        hunter.TotalSelect();
    }
    public void SetFloor(int i)
    {
        current_floor = i;
        UpdateText();

    }
    private void UpdateText()
    {
        HunterNameText.text = (HunterName + " @" + current_floor.ToString() + "F");
    }

}
