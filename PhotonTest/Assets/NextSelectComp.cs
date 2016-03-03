using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextSelectComp : MonoBehaviour {

    public InputField playername;
	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame

    public void OnClick()
    {
        GameAdmin.instance.GetComponent<RandomMatchmaker>().StartOnLine(playername.text);
        Application.LoadLevelAsync("SelectCamp");
    }
}
