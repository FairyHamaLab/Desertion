using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fade : MonoBehaviour {

    public float fadeInTime = 1.0f;
    public float inTime = 1.0f;
    public float fadeOutTime = 1.0f;
    public float outTime = 1.0f;
    private float fade_time = 0;
    public enum FADE_STATE
    {
        FADE_IN,
        IN,
        FADE_OUT,
        OUT
    }
    public FADE_STATE fadeState = FADE_STATE.FADE_IN;

    public float currentTime = 0.0f;
    private Color textColor;
	// Use this for initialization
	void Start () {
        textColor = this.GetComponent<Text>().color;
    }
	
	// Update is called once per frame
	void Update () {
        switch (fadeState)
        {
            case (FADE_STATE.FADE_IN):
                currentTime += Time.deltaTime * 2;
                if (currentTime > fadeInTime)
                {
                    currentTime -= fadeInTime;
                    fadeState = FADE_STATE.IN;
                    textColor.a = 1.0f;
                }
                else
                {
                    textColor.a = currentTime / fadeInTime;
                }
                break;
            case (FADE_STATE.IN):
                currentTime += Time.deltaTime * 2;
                if (currentTime > inTime)
                {
                    currentTime -= inTime;
                    fadeState = FADE_STATE.FADE_OUT;
                    textColor.a = 1.0f - currentTime / fadeOutTime;
                }
                else
                {
                    textColor.a = 1.0f;
                }
                break;
            case (FADE_STATE.FADE_OUT):
                currentTime += Time.deltaTime * 2;
                if (currentTime > fadeOutTime)
                {
                    currentTime -= fadeOutTime;
                    fadeState = FADE_STATE.OUT;
                    textColor.a = 0.0f;
                }
                else
                {
                    textColor.a = 1.0f - currentTime / fadeOutTime;
                }

                break;
            case (FADE_STATE.OUT):
                currentTime += Time.deltaTime * 2;
                if (currentTime > outTime)
                {
                    currentTime -= outTime;
                    fadeState = FADE_STATE.FADE_IN;
                    textColor.a = currentTime / fadeInTime;
                }
                else
                {
                    textColor.a = 0.0f;
                }

                break;
        }
        this.GetComponent<Text>().color = textColor;
        fade_time += Time.deltaTime;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + fade_time/400, this.transform.position.z);
        if (fade_time>1.5)
        {
            Destroy(this.gameObject);
        }
    }
}
