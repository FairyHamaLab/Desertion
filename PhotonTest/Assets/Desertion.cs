using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Desertion : MonoBehaviour {

    public int floor;
    private Button icon;

    public Transform test;
    private GameObject target;
    public Camera my_camera;
    public bool can_move;
    public int trap_number = 1;//保有アイテム数
   
    void Start()
    {
        icon = PlayerUIMgr.instance.AddDesrtionIcon();
        icon.GetComponent<BoundObject>().SetBoundTranform(this.transform);
        can_move = true;
    }
    void OnCollisionEnter(Collision collision)
    {

        int layer_num = collision.gameObject.layer;

        if (8 <= layer_num && layer_num <= 10)
        {
            //階が変わったなら自分のレイヤーも変える！
            //name_text.text = hunter_name + ":" + (layer_num - 7).ToString() + "F";
            //hunter_name_ui.SetFloor(layer_num - 7);
            this.gameObject.layer = layer_num + 3;
        }


    }
}
