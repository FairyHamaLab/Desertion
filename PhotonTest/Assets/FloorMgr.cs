using UnityEngine;
using System.Collections;

public class FloorMgr : MonoBehaviour {

    static public FloorMgr instance;
    public Camera camera;
    public int NowViewFloor = 3;
    private int crrent_view_mask;
    private int camera_level;

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
        camera_level = 0;

    }
	// Use this for initialization
	void Start () {
        ChangeViewFloor(3);
       
	}

    public void ChangeViewFloor(int floor)
    {
        if(1 <= floor&&floor <= 3)
        {
            
            camera.cullingMask = crrent_view_mask = GetFloorNumberLayer(floor);
            NowViewFloor = floor;
            
        }
    }
	public int GetNowViewLayer()
    {
        return crrent_view_mask;
    }
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.A))
            ChangeViewFloor(1);
        if (Input.GetKeyDown(KeyCode.S))
            ChangeViewFloor(2);
        if (Input.GetKeyDown(KeyCode.D))
            ChangeViewFloor(3);
        if (Input.GetKeyDown(KeyCode.F))
            ChangeViewFloor(4);

        if (Input.GetKeyDown(KeyCode.Comma))MoveCamera(true);

        if (Input.GetKeyDown(KeyCode.Period)) MoveCamera(false);
	}

    static public  int GetGroupToLayer(string group)
    {
        
        int return_layer = 0;
        for (int i = 8; i <= 31; i++)
        {

            if (0<= LayerMask.LayerToName(i).IndexOf(group))
            {
                return_layer += 1 << i;
            }

            
        }
        return return_layer;
    }
    static public int GetFloorNumberLayer(int floor)
    {
        if (floor < 1 || 2 < floor) return ~0;
        int return_layer = 0;

        for (int i = 8; i <= 31; i++)
        {
          if(floor == 1 && LayerMask.LayerToName(i).EndsWith("/Second"))  return_layer += 1 << i;
          if(floor <= 2 && LayerMask.LayerToName(i).EndsWith("/Third")) return_layer += 1 << i;
        }
        
        return ~return_layer;
    }
    public void MoveCamera(bool zoom)
    {
        Vector3 tmp = camera.transform.position;
        if(!zoom)
        {

            if (camera_level < 2)
            {
                camera_level++;
            }
            tmp.y = 32.94f + camera_level * 5;
            
            
        }
        else
        {
            if (-2 < camera_level)
            {
                camera_level--;
            }
            tmp.y = 32.94f + camera_level * 5;
            
          
        }
        camera.transform.position = tmp;
    }
 
}
