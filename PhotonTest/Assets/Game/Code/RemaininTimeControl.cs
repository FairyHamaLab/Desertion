using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemaininTimeControl : MonoBehaviour {

    public static RemaininTimeControl instance;
    public Text time_text;
    public Text mirisecond_text;

    public float time = 1200;
    public bool stoped = false;

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

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void Update () {
        if (!stoped)
        {
            time -= Time.deltaTime;
            time_text.text = ((int)time / 60).ToString("00") + ":" + (time % 60).ToString("00");
            mirisecond_text.text = ((time % 1)*100).ToString("00");
        }
	}
    public float GetTime()
    {
        return time;
    }
    public void Rest()
    {
        time = 0;
    }
    public void Stop()
    {
        stoped = true;
    }
    public void ReStart()
    {
        stoped = false;
    }

    public bool Stoped()
    {
        return stoped;
    }

}
