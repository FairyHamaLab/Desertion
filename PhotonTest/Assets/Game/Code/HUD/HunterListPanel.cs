using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HunterListPanel : MonoBehaviour {

    public static HunterListPanel instance;

    public GameObject HunterNameUIPrefab;

    public List<HunterNameUI> HunterList = new List<HunterNameUI>();

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public HunterNameUI AddHunterName(string name)
    {
        //新しいネームプレートを生成
        GameObject new_hunterUI = (GameObject)Instantiate(HunterNameUIPrefab);
        new_hunterUI.transform.SetParent(this.transform);

        //リストに追加
        HunterList.Add(new_hunterUI.GetComponent<HunterNameUI>());

        //座標を設定
        Vector2 size = new_hunterUI.GetComponent<RectTransform>().sizeDelta;
        new_hunterUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 65.4F + size.y * -1F *(HunterList.Count - 1));

        new_hunterUI.GetComponent<HunterNameUI>().SetHunterName(name);

        return new_hunterUI.GetComponent<HunterNameUI>();
    }
}
