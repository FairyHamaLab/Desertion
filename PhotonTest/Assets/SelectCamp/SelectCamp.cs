using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCamp : Photon.MonoBehaviour
{

    public SelectCamp partner;
    public Color color = Color.red;
    public bool selected = false;
    public Text Announcement;
    
    public bool Desrtion = true;
    public Text Numbers;
    
	// Update is called once per frame
   
    void Start()
    {
        if (Desrtion)
        {
            SelectCampNetwork.DesertionText = Numbers;
        }
        else
        {
            SelectCampNetwork.BossText = Numbers;
        }
    }
    public void ButtonState(bool state)
    {
        this.gameObject.GetComponent<Button>().interactable = state;
    }

    public void OnClick()
    {
        Select();
        if (partner.selected)
        {
            partner.Select();
        }
        else
        {
        }
    }
    public void Select()
    {
        var colors = this.GetComponent<Button>().colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.white;
        colors.pressedColor = Color.white;
        
       
       
        if(selected)
        {
            selected = false;
           // SelectCampAndSetText(false);
            PhotonView m_photonView = SelectCampNetwork.instance.GetPhotonView();
            m_photonView.RPC("SelectCampAndSetText", PhotonTargets.AllBuffered,PhotonNetwork.player.ID, Desrtion, false);
            if (!partner.selected) Announcement.text = "陣営を選択してください";
        }
        else
        {
            colors.normalColor = color;
            colors.highlightedColor = color;
            colors.pressedColor = color;
            selected = true;
           // SelectCampAndSetText(true);
            PhotonView m_photonView = SelectCampNetwork.instance.GetPhotonView();
            m_photonView.RPC("SelectCampAndSetText", PhotonTargets.AllBuffered,PhotonNetwork.player.ID, Desrtion, true);
            Announcement.text = "他のプレイヤーの選択を待っています";
            
        }
        this.GetComponent<Button>().colors = colors;

    }



}

