using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class InRoomChat : Photon.MonoBehaviour 
{
	//GUInoのサイズを設定
    public Rect GuiRect = new Rect(0,0, 250,300);
	//可視化
    public bool IsVisible = true;
	//チャット欄の位置
    public bool AlignBottom = false;
	//メッセージリスト
    public List<string> messages = new List<string>();
	//入力文字
    private string inputLine = "";
	//スクロールの二次元位置
    private Vector2 scrollPos = Vector2.zero;

    public static readonly string ChatRPC = "Chat";

    public void Start()
    {
        if (this.AlignBottom)
        {
            this.GuiRect.y = Screen.height - this.GuiRect.height;
        }
    }

    public void OnGUI()
    {
		//可視化していない又はルームに入っていない場合は接続を終了
        if (!this.IsVisible || PhotonNetwork.connectionStateDetailed != PeerState.Joined)
        {
            return;
        }
        //イベントが入力されている状態を確認後、エンターキーを入力されたのか、リターンキーが入力されているとき、
        if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
        {
			//入力文字列が、空白でないのであれば
            if (!string.IsNullOrEmpty(this.inputLine))
            {
				//全てのユーザへ、特定の関数を呼び出す
                this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
				//inputの初期化
                this.inputLine = "";
               // GUI.FocusControl("");
                return; // printing the now modified list would result in an error. to avoid this, we just skip this single frame
            }
            else
            {
                GUI.FocusControl("ChatInput");
            }
        }

        GUI.SetNextControlName("");
        //チャット文字欄の位置調整
        GUILayout.BeginArea(this.GuiRect);

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.FlexibleSpace();

        //レイアウトにラベルを追加
        for (int i = 0; i < messages.Count; i++)
        {
            GUILayout.Label(messages[i]);
        }
        GUILayout.EndScrollView();

        GUILayout.BeginHorizontal();
        GUI.SetNextControlName("ChatInput");
        inputLine = GUILayout.TextField(inputLine);
        if (GUILayout.Button("Send", GUILayout.ExpandWidth(false)))
        {
            this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
            this.inputLine = "";
            GUI.FocusControl("");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    [PunRPC]
    public void Chat(string newLine, PhotonMessageInfo mi)
    {
        string senderName = "anonymous";

        if (mi != null && mi.sender != null)
        {
            if (!string.IsNullOrEmpty(mi.sender.name))
            {
                senderName = mi.sender.name;
            }
            else
            {
                senderName = "player " + mi.sender.ID;
            }
        }

		this.messages.Add(senderName +": " + newLine);

    }

    public void AddLine(string newLine)
    {
        this.messages.Add(newLine);
    }
}
