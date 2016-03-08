using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BehaviourScript : MonoBehaviour {

    private Animator animator;//アニメータ

    public float x, y;
    public bool can_move = true;//動作可能判定

    public int bind_trap_number = 1;//保有アイテム数
    public int alerm_number = 1;
    public bool trap_key = true;//トラップ配置動作制御
    public Transform Trap;

   // public Transform ;

  
    public Transform my_camera_potision;//自分のカメラの位置

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();
        
        if (Input.GetKeyDown("z") && bind_trap_number != 0)
        {
            Transform new_trap = (Transform)Instantiate(Trap);
            new_trap.transform.position = this.transform.position;
            new_trap.transform.position += my_camera_potision.forward + new Vector3(0f, 0.75f, 0f);
            new_trap.gameObject.GetComponent<Rigidbody>().useGravity = true;
            new_trap.gameObject.SetActive(true);

            //単位ベクトルの50倍の力+放物線っぽく
            new_trap.gameObject.GetComponent<Rigidbody>().AddForce(my_camera_potision.forward * 50 + new Vector3(0f, 100f, 0f));

            bind_trap_number--;
        }

        /*
         * 時間・賞金関係処理
         */
        //timer += Time.deltaTime;
        //Limit_time -= Time.deltaTime;
       // int minutes = (int)Limit_time / 60;
        //int seconds = (int)(Limit_time % 60);
        //int prize = (int)timer * 200;
        //this.transform.FindChild("Time").transform.FindChild("Text").GetComponent<Text>().text = "残り時間 : " + minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        //this.transform.FindChild("Prize").transform.FindChild("Text").GetComponent<Text>().text = "賞金 : ￥" + string.Format("{0:#,0}", prize);

    }

    void OnTriggerEnter(Collider other)
    {

    }
 
    void OnTriggerExit(Collider other)
    {

    }

    private void Move()
    {
        if(can_move){
            if (Input.GetKey("up"))
            {
                animator.SetBool("running", true);
            }

            else if (Input.GetKey("down")  )
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("walking", false);
            }


            if (Input.GetKey("right")  )
            {
                transform.Rotate(0, 5, 0);
            }
            if (Input.GetKey("left")  )
            {
                transform.Rotate(0, -5, 0);
            }
        }

        
        if (animator.GetBool("running"))
        {
            transform.position += transform.forward * 0.05f;
        }
        if (animator.GetBool("walking"))
        {
            transform.position -= transform.forward * 0.025f;
        }

    }
}
