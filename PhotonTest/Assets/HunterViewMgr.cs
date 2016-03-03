using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HunterViewMgr : MonoBehaviour {

    public static HunterViewMgr instance;
    public Camera hunter_view_camera;
    public Text hunter_name_text;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
     void Start()
    {
        
    }
     void Update()
     {
         
     }
    public void Select(Hunter hunter)
    {
        hunter_name_text.text = hunter.GetHunterName();
        
        hunter_view_camera.transform.SetParent(hunter.transform);
        hunter_view_camera.transform.localPosition = new Vector3(0,0.75F,0);
        
    }
}
