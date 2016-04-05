using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EdgeMgr : MonoBehaviour
{

    public Cell[] cells = new Cell[4];
    public Camera edgecamera,playercamera;
    public GameObject Desertion;
    public float angle = 0;

    /*colの番号*/
    private int trigger_number;

    /*入ったcolに対応する左右のcolの番号*/
    private static int[] set_camera_numbers_left = new int[] { 2, 3, 1, 0, };
    private static int[] set_camera_numbers_right = new int[] { 3, 2, 0, 1, };

    /*覗いてる風にするためのずらす値*/
    private static Vector3 view_slide_x = new Vector3(0.4f, 0, 0);
    private static Vector3 view_slide_z = new Vector3(0, 0, 0.4f);
    private static Rect rect_of_center;
    private float[] vector_for_center = new float[] { 180, 0, 270, 90 };


    /*col内に居るかの判定*/
    private bool enable = false;

    private string right, left;

    // Use this for initialization
    void Awake()
    {
        foreach(Cell value in cells)
        {
            value.my_mgr = this;
        }

        rect_of_center = new Rect(0, 0, 0, 0);
    }
	void Start () {
        edgecamera.depth = 1;
	}
	
	// Update is called once per frame
	void Update () {
        edgecamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Desertion/First"));
        edgecamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Desertion/Second"));
        edgecamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Dplayercameraesertion/Third"));

        if (enable)
        {
            angle = Desertion.transform.eulerAngles.y;

            WardDisplay();

            /*左にのぞきみ*/
            if ( !Input.GetKey("up") && !Input.GetKey("down") && Input.GetKey(left) && cells[set_camera_numbers_left[trigger_number]].isActiveAndEnabled)
            {

                edgecamera.gameObject.SetActive(true);
                Desertion.GetComponent<Desertion>().can_move = false;

                Vector3 view_point = cells[set_camera_numbers_left[trigger_number]].transform.position;
                //view_point.y = 0.5F;

                //入ったcolによって処理
                switch (trigger_number)
                {
                    case 0:
                    edgecamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z + view_slide_z.z);
                    view_point = view_point + view_slide_z;
                    break;
                
                    case 1:
                    edgecamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z - view_slide_z.z);
                    view_point = view_point - view_slide_z;
                    break;

                    case 2:
                    edgecamera.transform.position = new Vector3(this.transform.position.x + view_slide_x.x, this.transform.position.y + 0.5f, this.transform.position.z);
                    view_point = view_point + view_slide_x;
                    break;
                
                    default:
                    edgecamera.transform.position = new Vector3(this.transform.position.x - view_slide_x.x, this.transform.position.y + 0.5f, this.transform.position.z);
                    view_point = view_point - view_slide_x;
                    break;
                }

                edgecamera.transform.LookAt(view_point);
                edgecamera.rect = new Rect(0.05f + rect_of_center.x, 0.23f, 0.4f, 0.5f);
            }

            else if ( !Input.GetKey("up") && !Input.GetKey("down") && Input.GetKey(right) && cells[set_camera_numbers_right[trigger_number]].isActiveAndEnabled)
            {

                edgecamera.gameObject.SetActive(true);
                Desertion.GetComponent<Desertion>().can_move = false;

                Vector3 view_point = cells[set_camera_numbers_right[trigger_number]].transform.position;

                /*入ったcolによって処理*/
                switch (trigger_number)
                {
                    case 0:
                        edgecamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z + view_slide_z.z);
                        view_point = view_point + view_slide_z;
                        break;

                    case 1:
                        edgecamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z - view_slide_z.z);
                        view_point = view_point - view_slide_z;
                        break;

                    case 2:
                    edgecamera.transform.position = new Vector3(this.transform.position.x + view_slide_x.x, this.transform.position.y + 0.5f, this.transform.position.z);
                        view_point = view_point + view_slide_x;
                        break;

                    default:
                    edgecamera.transform.position = new Vector3(this.transform.position.x - view_slide_x.x, this.transform.position.y + 0.5f, this.transform.position.z);
                        view_point = view_point - view_slide_x;
                        break;
                }

                edgecamera.transform.LookAt(view_point);
                edgecamera.rect = new Rect(0.55f - rect_of_center.x, 0.23f, 0.4f, 0.5f);
            }

            /*キーを押していないとき*/
            else
            {
                edgecamera.gameObject.SetActive(false);
                Desertion.GetComponent<Desertion>().can_move = true;
            }
        }
    }

    public void Trigger(int number)
    {
        trigger_number = number;
        enable = true;
        Debug.Log(trigger_number);
    }

    /*
     * CellのOntriggerExitで呼び出し
     */
    public void disTrigger()
    {
        CanvasMgr.instance.DirectionWord_hidden(0);
        CanvasMgr.instance.DirectionWord_hidden(1);
        CanvasMgr.instance.DirectionWord_hidden(2);
        enable = false;
    }


    /*
     * Angleで
     */
    public void WardDisplay()
    {
        /*左右のcolが稼働しているなら文字を表示*/
        CanvasMgr.instance.DirectionWord_hidden(0);
        CanvasMgr.instance.DirectionWord_hidden(1);
        CanvasMgr.instance.DirectionWord_hidden(2);
        if (angle - vector_for_center[trigger_number] < 0)
        {
            angle += 360;
        }
        if (angle - vector_for_center[trigger_number] > 360)
        {
            angle -=360;
        }
        /*左側*/
        if (cells[set_camera_numbers_left[trigger_number]].isActiveAndEnabled)
        {
            if (angle - vector_for_center[trigger_number] <= 45f || angle - vector_for_center[trigger_number] >= 315f)
            {
                CanvasMgr.instance.direction_word_left.GetComponent<Text>().text = "左を覗く\nA";
                left = "a";
                right = "d";
                CanvasMgr.instance.DirectionWord_display(0);
                rect_of_center = new Rect(0, 0, 0, 0);
            }

            else if (angle - vector_for_center[trigger_number] > 135f && angle - vector_for_center[trigger_number] <= 225f)
            {
                CanvasMgr.instance.direction_word_right.GetComponent<Text>().text = "右後ろを覗く\nD";
                left = "d";
                right = "a";
                CanvasMgr.instance.DirectionWord_display(1);
                rect_of_center = new Rect(0.51f, 0, 0, 0);
            }

            else if (angle - vector_for_center[trigger_number] > 225f && angle - vector_for_center[trigger_number] <= 315f)
            {
                CanvasMgr.instance.direction_word_forward.GetComponent<Text>().text = "覗く\nA";
                left = "a";
                right = "m";//dのキー入力を防ぐ
                CanvasMgr.instance.DirectionWord_display(2);
                rect_of_center = new Rect(0.2f, 0, 0, 0);
            }

        }

        /*右側*/
        if (cells[set_camera_numbers_right[trigger_number]].isActiveAndEnabled)
        {
            if (angle - vector_for_center[trigger_number] <= 45f || angle - vector_for_center[trigger_number] >= 315f)
            {
                CanvasMgr.instance.direction_word_right.GetComponent<Text>().text = "右を覗く\nD";
                left = "a";
                right = "d";
                CanvasMgr.instance.DirectionWord_display(1);
                rect_of_center = new Rect(0, 0, 0, 0);
            }

            else if (angle - vector_for_center[trigger_number] > 45f && angle - vector_for_center[trigger_number] <= 135f)
            {
                CanvasMgr.instance.direction_word_forward.GetComponent<Text>().text = "覗く\nD";
                left = "m";//aのキー入力を防ぐ
                right = "d";
                CanvasMgr.instance.DirectionWord_display(2);
                rect_of_center = new Rect(0.2f, 0, 0, 0);
            }

            else if (angle - vector_for_center[trigger_number] > 135f && angle - vector_for_center[trigger_number] <= 225f)
            {
                CanvasMgr.instance.direction_word_left.GetComponent<Text>().text = "左後ろを覗く\nA";
                left = "d";
                right = "a";
                CanvasMgr.instance.DirectionWord_display(0);
                rect_of_center = new Rect(0.51f, 0, 0, 0);
            }
        }

    }
}
