using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SelectCampNetwork : Photon.PunBehaviour
{
    static public SelectCampNetwork instance;
    public List<int> d_members = new List<int>();
    public int b_member = -1;
    public SelectCamp desertion;
    public SelectCamp boss;
    public Text room_numbers;
    public Text player_list;

    public bool CountDown = false;
    public Text CountDownText;
    public float CountDownTimer;
    public int CountDownNumber;
    //シングルトン用コード
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

    static public Text DesertionText;
    static public Text BossText;

    void OnJoinedRoom()
    {
        UpdatePlayerList();
    }
	// Use this for initialization
	void Start () {
        CountDownText.enabled = false;
	  
	}
	
	// Update is called once per frame
	void Update () {
        if (CountDown)
        {
            if (Time.realtimeSinceStartup - CountDownTimer > 1)
            {
                CountDownTimer = Time.realtimeSinceStartup;
                GetPhotonView().RPC("UpdateCountDownText", PhotonTargets.All, CountDownNumber);
                CountDownNumber--;
                if(CountDownNumber == 0)
                {
                    
                }
            }
        }
	}
    public PhotonView GetPhotonView()
    {
        return this.GetComponent<PhotonView>();
    }
    public void AddOrDeleteDesertion(int player_id, bool add)
    {
        if (add)
        {
        
            d_members.Add(player_id);
           if(!desertion.selected && PhotonNetwork.playerList.Length -1 == d_members.Count)
           {
               desertion.ButtonState(false);
           }
        }
        else
        {
            d_members.Remove(player_id);
             desertion.ButtonState(true);

        }

    }
    public void SetOrDeleteBoss(int player_id, bool set)
    {
        if (set)
        {
            b_member = player_id;
            if (!boss.selected) boss.ButtonState(false);
            
        }
        else
        {
            
            b_member = -1;
            if (!boss.selected) boss.ButtonState(true);
        }
    }
    //Player�̐�
    public int GetDesrtionNumber() { return d_members.Count; }
    //Boss�̐�
    public int GetBossNumber() { return (b_member != -1) ? 1 : 0; }
    //�Q�[�����J�n�\���ۂ�
    public bool CanGameStart() { return (GetBossNumber() + GetDesrtionNumber() == PhotonNetwork.playerList.Length && GetBossNumber() != 0) ? true : false; }


    
    [PunRPC]
    public void SelectCampAndSetText(int player_id,bool Desrtion,bool set)
    {
 
        if (Desrtion)
        {
           AddOrDeleteDesertion(player_id, set);
           DesertionText.text = d_members.Count.ToString();
        }
        else
        {
            SetOrDeleteBoss(player_id, set);
            BossText.text = GetBossNumber().ToString();
        }
        UpdatePlayerList();

        if (PhotonNetwork.player.isMasterClient)
        {
            if (GetDesrtionNumber() + GetBossNumber() == PhotonNetwork.playerList.Length && PhotonNetwork.playerList.Length >= 2)
            {
                CountDown = true;
                CountDownTimer = Time.realtimeSinceStartup;
                CountDownNumber = 9;
                GetPhotonView().RPC("CountDownView", PhotonTargets.All,true);
            }
            else
            {
                if (CountDown)
                {
                    CountDown = false;
                    GetPhotonView().RPC("CountDownView", PhotonTargets.All, false);
                }
            }
        }
         
    }
    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        
        bool Des;

        if (d_members.Contains(otherPlayer.ID))
        {
            Des = true;
        }
        else if (b_member == otherPlayer.ID)
        {
            Des = false;
        }
        else
        {
            return;
        }
        photonView.RPC("SelectCampAndSetText", PhotonTargets.AllBuffered, otherPlayer.ID, Des, false);
        UpdatePlayerList();
        CountDown = false;
        CountDownView(false);

    }
    void OnPhotonPlayerConnected()
    {
        UpdatePlayerList();
    }
    void UpdatePlayerList()
    {
       
        string text = "";
        foreach(PhotonPlayer player in PhotonNetwork.playerList)
        {
            text += player.name + " : ";
            if (d_members.Contains(player.ID))
            {
                text += "逃走者\n";
            }
            else if (b_member == player.ID)
            {
                text += "BOSS\n";
            }
            else
            {
                text += "\n";
            }
        }
        player_list.text = text;

        room_numbers.text = "InRoom " + PhotonNetwork.playerList.Length;
    }

    [PunRPC]
    public void UpdateCountDownText(int num)
    {
        CountDownText.text = num.ToString("D2") + " 秒後にゲームを開始します";
    }
    [PunRPC]
    public void CountDownView(bool yes)
    {
        CountDownText.text = "10 秒後にゲームを開始します";
        CountDownText.enabled = yes;
    }
}
