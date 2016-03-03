using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("何も怒らない");
        int layer_num = collision.gameObject.layer;

        if (8 <= layer_num && layer_num <= 10)
        {
            ChangeLayer(layer_num);
        }
    }
     abstract public  void ChangeLayer(int layer_num);
}
