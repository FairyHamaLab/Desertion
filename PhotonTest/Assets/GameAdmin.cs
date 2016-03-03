using UnityEngine;
using System.Collections;

public class GameAdmin : MonoBehaviour {


    static public GameAdmin instance;
    //シングルトン用コード
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
