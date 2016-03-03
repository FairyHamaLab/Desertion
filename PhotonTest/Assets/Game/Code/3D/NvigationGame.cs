using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI.Extensions;

public class NvigationGame : MonoBehaviour {

	
	private bool select;
	private int player_layer_mask;
	private int wall_layer_mask;
	private int goal_layer_mask;
	private RaycastHit hit;
	private NavMeshAgent agent;
	private List<Vector3> my_list = new List<Vector3>();
	private int index;
    private int other_mask;

    public LineRenderer line;
    public LineRenderer templine;

    public List<Vector3> RelayPosList = new List<Vector3>();
	// Use this for initialization
	void Start() {

		select = false;
        player_layer_mask = FloorMgr.GetGroupToLayer("Hunter");
		index = -1;
        Debug.Log(this.transform.parent.name);
        agent = this.transform.parent.GetComponent<NavMeshAgent>();
            GetComponent<NavMeshAgent>();
        other_mask = ~(1 << 17);
	}

    public void Select()
    {
        Cancel();
        templine.enabled = true;
        select = true;
        return;
    }
    public void Cancel()
    {
        my_list.Clear();
        RelayPosList.Clear();
        line.enabled = false;
        index = -1;
        templine.enabled = false;
        templine.SetVertexCount(2);
        templine.SetPosition(0,new Vector3(0, 999, 0));
        templine.SetPosition(0, new Vector3(1, 999, 0));


    }
	
	// Update is called once per frame
	void Update () {
       
		if (select == false) {
            //左クリックを押したとき
			if (Input.GetMouseButtonDown(0)) {
                //クリック先にPlayerがいるか確認
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                if (Physics.Raycast(ray, 1000,player_layer_mask))
                {
                   // Select();
				}
			}
            //Agentの巡回移動
			if((index != -1)&&(agent.remainingDistance < 0.2f))
			{

                if (index >= my_list.Count)
                {

                    my_list.Clear();
                    RelayPosList.Clear();
                    line.enabled = false;
                    index = -1;

                    templine.SetVertexCount(2);
                    templine.SetPosition(0, new Vector3(0, 999, 0));
                    templine.SetPosition(0, new Vector3(1, 999, 0));
                }
                else
                {
                    agent.destination = my_list[index];
                    index++;
                }
			}

		} else if(select == true){

			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                //移動地点を決定
                if (Physics.Raycast(ray, out hit, 100, FloorMgr.instance.GetNowViewLayer() & other_mask))
                {
					
					
                    NavMeshPath path = new NavMeshPath();
                    Vector3 source = (my_list.Count == 0) ? transform.position : my_list[my_list.Count - 1];
                    if (NavMesh.CalculatePath(source, hit.point, agent.areaMask, path))
                    {
                        my_list.Add(hit.point);
                        AddDrawPosition(path.corners);
                        agent.destination = my_list[0];
                       
                        templine.enabled = false;
                        select = false;
                        index = 1;
                    }
				}
			}else{
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100, FloorMgr.instance.GetNowViewLayer()&other_mask))
                {
                 
						
                        //ルートがあるかチェック
                        NavMeshPath path = new NavMeshPath();
                        Vector3 source = (my_list.Count == 0) ? transform.position : my_list[my_list.Count - 1];
                        if (NavMesh.CalculatePath(source, hit.point, agent.areaMask, path))
                        {
                            
                                //右クリック
                                if (Input.GetMouseButtonDown(1))
                                {
                                    line.enabled = true;
                                    my_list.Add(hit.point);
                                    AddDrawPosition(path.corners);
                                }
                                else
                                {
                                    SetNonselectLine(path.corners);
                                }

                        }
                        
					

				}

			}
		}

	}

	void DrawLineMyRoot()
	{
        line.SetVertexCount(RelayPosList.Count);
        line.SetPositions(RelayPosList.ToArray());   
	}
    void AddDrawPosition(Vector3[] corners)
    {
        foreach(Vector3 value in corners)
        {
            RelayPosList.Add(value + new Vector3(0, 0.1F, 0));
        }
        line.SetVertexCount(RelayPosList.Count);
        line.SetPositions(RelayPosList.ToArray());
    }
    void SetNonselectLine(Vector3[] corners)
    {
        templine.SetVertexCount(corners.Length);
        templine.SetPositions(corners);
    }
    
    public void Wait()
    {
        //Navigationの停止
        Debug.Log("Wait未実装");
    }
}
