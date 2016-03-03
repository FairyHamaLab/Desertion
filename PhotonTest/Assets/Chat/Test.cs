using UnityEngine;
using System.Collections;
using UnityEngine.UI.Extensions;
public class Test : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
    void Update()
    {
        

    }
    public void push()
    {
        HUD_DesertionName new_hud =  HUD_DesertionNameList.instance.Add("aaaaaa");
        new_hud.SetPrizeText(123456789);
    }

    public void push2()
    {
        HUD_DesertionName new_hud = HUD_DesertionNameList.instance.Add("aaaaaa");
        new_hud.SetPrizeText(123456789);
        new_hud.ChangeDesrertion(false);
    }
    public void push3()
    {
        //HunterCommandUI.instance.SetUIPotision_NOMAL();
        //HunterCommandUI.instance.SetUIPotision_LEFT();
        //HunterCommandUI.instance.SetUIPotision_RIGHT();
        HunterCommandUI.instance.SetUIPotision_TOP();
        HunterCommandUI.instance.SetUIPotision_BUTTOM();
    }

}
