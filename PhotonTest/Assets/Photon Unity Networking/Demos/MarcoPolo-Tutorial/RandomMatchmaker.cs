using UnityEngine;

public class RandomMatchmaker : Photon.PunBehaviour
{
    private PhotonView myPhotonView;


    public bool StartOnLine(string player_name)
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
		if (string.IsNullOrEmpty (PhotonNetwork.playerName)) {
			PhotonNetwork.playerName = player_name;
            return true;
		}
        return false;
    }

    public PhotonView GetPhotonView()
    {
        return this.GetComponent<PhotonView>();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinRandom");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        // when AutoJoinLobby is off, this method gets called when PUN finished the connection (instead of OnJoinedLobby())
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
		
       // GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
        GameObject test = PhotonNetwork.Instantiate("test", new Vector3(3,10,0), Quaternion.identity, 0);
       // monster.GetComponent<myThirdPersonController>().isControllable = true;
        //myPhotonView = monster.GetComponent<PhotonView>();
        
    }

    public void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

        if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
        {
            bool shoutMarco = GameLogic.playerWhoIsIt == PhotonNetwork.player.ID;

            if (shoutMarco && GUILayout.Button("Marco!"))
            {
                myPhotonView.RPC("Marco", PhotonTargets.All);
            }
            if (!shoutMarco && GUILayout.Button("Polo!"))
            {
                myPhotonView.RPC("Polo", PhotonTargets.All);
            }
        }
    }
}
