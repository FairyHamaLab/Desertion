using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_DesertionName : MonoBehaviour {

    public Text prize_text;
    public Text desrtion_name_text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    public void SetPrizeText(int prize)
    {
        prize_text.text = "￥"+prize.ToString("n0");
    }
    public void SetName(string name)
    {
        desrtion_name_text.text = name;
    }

    public void ChangeDesrertion(bool set)
    {
        HUD_DesertionNameList.instance.SetNowDesertion(this,set);
    }
}
