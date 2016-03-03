using UnityEngine;
using System.Collections;

public class BackToTitle : MonoBehaviour {

public void OnClick()
    {
        Application.LoadLevelAsync("Title");
    }
}
