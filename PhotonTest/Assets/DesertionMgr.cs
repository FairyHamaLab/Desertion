using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DesertionMgr : MonoBehaviour {

    static public DesertionMgr instance = null;
    public Camera mycamera;
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
        SceneManager.LoadScene("StageScene", LoadSceneMode.Additive);
       // FloorMgr.instance.camera = mycamera;
    }
   
}
