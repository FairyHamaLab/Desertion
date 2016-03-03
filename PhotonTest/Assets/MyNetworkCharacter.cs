using UnityEngine;
using System.Collections;

public class MyNetworkCharacter : Photon.MonoBehaviour
{
    private Vector3 m_correctPlayerPosition;            // 位置情報.
    private Quaternion m_m_correctPlayerRotation;       // 回転情報.

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.isMine)
        {       // photonViewが自分自身ではない場合、位置と回転を反映.
            transform.position = Vector3.Lerp(transform.position, this.m_correctPlayerPosition, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.m_m_correctPlayerRotation, Time.deltaTime * 5);
        }
    }

    /**
     * プレイヤー同士の位置/回転情報の同期をとる.
     * 自分のキャラクタの位置と回転を送信、自分以外のキャラクタの位置と回転を受信.
     */
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // 自分のプレイヤー情報を送信.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // 他のプレイヤー情報を受信.
            this.m_correctPlayerPosition = (Vector3)stream.ReceiveNext();
            this.m_m_correctPlayerRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}