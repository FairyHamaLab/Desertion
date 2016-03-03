using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputPlayerNameCheck : MonoBehaviour {

    public Button next;
    public float check_interval_s = 0.5F;
    private float check_timer;
    void Start()
    {
        check_timer = Time.time;
    }
    public void  ValueChange()
    {
        
  
    }
   void Update()
    {
        if (this.GetComponentInChildren<Text>().text == "")
        {

            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }
         
    }
}
