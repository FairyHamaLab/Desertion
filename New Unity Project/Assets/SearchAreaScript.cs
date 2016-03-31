using UnityEngine;
using System.Collections;
    enum State {
	walk,
	wait,
	chase,
};
public class Chase_Script : MonoBehaviour {
    /*
    private Transform player;
    private Transform hunter;
    float squareFarRange = 2.125f;
    bool del = false;
    private string mode;
    Vector3 position;
    Collider col;


    
    // Use this for initialization
	void Start ()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        hunter = GameObject.Find("hunter").GetComponent<Transform>();
    }
	
	// Update is called once per frame



    void setState(GameObject) 
    {
	    if(mode == "walk") 
        {
		    hunter.state = State.walk;
		    setPos.setDestination();
		    destination = setPos.getDestination();
	    }
        else if(mode == "chase") 
        {
		    state = State.chase;
		    arrived = false;	//　待機状態から追いかける場合もあるのでOff
		    playerChara = col;	//　追いかける対象をセット
	    }
        else if(mode == "wait") 
        {
		    currentTime = 0.0f;
		    state = State.wait;
		    arrived = true;
	    }
    }

void Update () 
{
    if(state == State.walk) 
    {
        if(!arrived)
        {
            walk(destination);	//　見回り、目的地を再設定
            if(Vector3.Distance(destination, transform.position) < 0.3)
            {
                arrived = true;
                state = State.wait;
            }
        }
    }
    else if(state == State.wait) 
    {
        wait();
    }
    else if(state == State.chase) 
    {
        if(!arrived) 
        {
            walk(playerChara.transform.position);	//　プレイヤーを目的地に設定
            //　以下はいずれ攻撃の状態に遷移する処理を作る（現在は待機状態にする）
            if(Vector3.Distance(destination, transform.position) < 1.0) 
            {
                arrived = true;
                animator.SetFloat("Speed", 0.0f);
                state = State.wait;
            }
        }
    }
}
void walk() 
{
    if(state == State.chase) 
    {
        setPos.setDestination(position);
        destination = setPos.getDestination();
    }
    if(eCon.isGrounded) {
        velocity = Vector3.zero;
        animator.SetFloat("Speed", 2.0f);
        direction = (destination - transform.position).normalized;
        transform.LookAt(Vector3(destination.x, transform.position.y, destination.z));
        velocity = direction * speed;
    }
    velocity.y += Physics.gravity.y * Time.deltaTime;
    eCon.Move(velocity * Time.deltaTime);
}

void setDestination()
{
    var randDestination = Random.insideUnitCircle * 8;
	destination = current + Vector3(randDestination.x, 0, randDestination.y);
	Debug.Log("セット");
}
void setDestination(position : Vector3) 
{
	destination = position;
}

void OnTriggerStay() 
{
	if(col.tag == "Player" && moveE.getState() != State.chase) 
{
		Debug.Log("発見");
		moveE.setState("chase", col.gameObject);
	}
}
function OnTriggerExit() 
{
	if(col.tag == "Player") 
{
		Debug.Log("見失う");
		moveE.setState("wait", null);
	}
}
    */
}
