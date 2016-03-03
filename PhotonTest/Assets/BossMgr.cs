
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossMgr : MonoBehaviour {

    public static BossMgr instance;
    public Camera mycamera;
    public Transform canvas;
    private Transform target_point = null;
    public GameObject _hunte_obj;
    public GameObject _hunter_operator;
    void Awake()
    {
        //Application.LoadLevelAdditive("StageScene");
        
        if(instance == null)
        {
            instance = this;
        }else{
            Destroy(this);
        }
        SceneManager.LoadScene("StageScene", LoadSceneMode.Additive);
        FloorMgr.instance.camera = mycamera;
       
    }
	// Use this for initialization
	void Start () {

        AddHunter(new Vector3(4, 10, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (target_point != null)
        {

            mycamera.transform.position = new Vector3(target_point.position.x, mycamera.transform.position.y, target_point.position.z);
        }
	}
    public void Add()
    {
        Debug.Log("Add");
    }
    public void Scout()
    {
        Debug.Log("Scout");
    }
    
    public void JointCamera(Transform hunter_potision)
    {
        
        target_point = hunter_potision;
    }
    public void FreePointCamera()
    {
        target_point = null;
    }
    public void AddHunter(Vector3 potision)
    {
        GameObject new_obj = (GameObject)Instantiate(_hunte_obj);
        GameObject new_ope = (GameObject)Instantiate(_hunter_operator);

       
        new_ope.transform.SetParent(new_obj.transform);
        new_obj.transform.position = potision;
        
    }
}
