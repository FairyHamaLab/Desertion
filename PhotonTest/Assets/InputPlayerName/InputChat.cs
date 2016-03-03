using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(PhotonView))]

public class InputChat : Photon.MonoBehaviour
{

    public ScrollController Content;
    public static readonly string ChatRPC = "AddChat";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void EndEdit()
    {
        var i = this.GetComponent<InputField>();
        string len = GetComponentInChildren<InputField>().text;
        this.photonView.RPC("AddChat", PhotonTargets.All, "ragrog", len);
        GetComponentInChildren<InputField>().text = "";
        GetComponent<InputField>().ActivateInputField();
    }
    public void OnValueChange()
    {
       // Debug.Log(GetComponentInChildren<InputField>().text);
    }

    [PunRPC]
    public void AddChat(string player_name, string chat_text, PhotonMessageInfo mi)
    {
        Content.AddChat(player_name, chat_text, Color.green);

    }

}
