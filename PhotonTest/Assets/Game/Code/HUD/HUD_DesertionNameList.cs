using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public struct DesrtionData
{
    
    public bool now_desertion;
    public HUD_DesertionName hud_desrtion_name;
    public DesrtionData(bool desertion, HUD_DesertionName set_hud)
    {
        now_desertion = desertion;
        hud_desrtion_name = set_hud;
    }
}

public class HUD_DesertionNameList : MonoBehaviour {

    public List<DesrtionData> desertion_list = new List<DesrtionData>();
    public GameObject desrtion_name_prefab;
    public Text custoday_text;
    public Text desertion_text;
    public static HUD_DesertionNameList instance;
   
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
	// Use this for initialization

    public HUD_DesertionName Add(string name)
    {
        GameObject new_obj = (GameObject)Instantiate(desrtion_name_prefab);
        new_obj.transform.SetParent(this.transform);
        desertion_list.Add(new DesrtionData(true, new_obj.GetComponent<HUD_DesertionName>()));
        new_obj.GetComponent<HUD_DesertionName>().SetName(name);
        UpdateListPoint();
        return new_obj.GetComponent<HUD_DesertionName>();
    }

    public void SetNowDesertion(HUD_DesertionName target,bool set)
    {
        for (int i = 0;i < desertion_list.Count;i ++)
        {
            if (desertion_list[i].hud_desrtion_name == target)
            {
                DesrtionData tmp = desertion_list[i];
                tmp.now_desertion = set;
                desertion_list[i] = tmp;
                UpdateListPoint();
                break;
            }
        }

      
    }

    private void UpdateListPoint()
    {
        //逃走者を配置
        float hud_size = desrtion_name_prefab.GetComponent<RectTransform>().sizeDelta.y;
        Vector2 point = new Vector2(1.700015F, desertion_text.GetComponent<RectTransform>().anchoredPosition.y + (desertion_text.GetComponent<RectTransform>().sizeDelta.y / 2 + hud_size / 2)*-1F);
       
        
        foreach (DesrtionData hud_data in desertion_list)
        {
            if (hud_data.now_desertion)
            {
                hud_data.hud_desrtion_name.GetComponent<RectTransform>().anchoredPosition = point;
                
                point += new Vector2(0,-57F);
            }
        }

        if (desertion_list.Count > 0)
        {
            //拘束者を配置
            custoday_text.GetComponent<RectTransform>().anchoredPosition = point;
            point.y += (custoday_text.GetComponent<RectTransform>().sizeDelta.y / 2 + hud_size / 2)*-1F;
        }

        foreach (DesrtionData hud_data in desertion_list)
        {
            if (!hud_data.now_desertion)
            {
                hud_data.hud_desrtion_name.GetComponent<RectTransform>().anchoredPosition = point;

                point += new Vector2(0, -57F);
            }
        }


    }
   
}
