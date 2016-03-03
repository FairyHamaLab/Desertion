using UnityEngine;
using System.Collections;

public class LayerMgr : MonoBehaviour {

    static public LayerMgr instance;
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
    static public int GetGroupToLayer(string group)
    {

        int return_layer = 0;
        for (int i = 8; i <= 31; i++)
        {
            //TODO:怪しい

            if (0 <= LayerMask.LayerToName(i).IndexOf(group))
            {
                return_layer += 1 << i;
            }


        }
        return return_layer;
    }
}
