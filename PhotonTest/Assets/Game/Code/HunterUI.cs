using UnityEngine;
using System.Collections;

public class HunterUI : MonoBehaviour {

    public Hunter hunter;

    public void Select()
    {
        HunterCommandUI.instance.SetTarget(hunter, this.transform);
       
    }

    public void PushButton()
    {
        hunter.TotalSelect();
    }


}
