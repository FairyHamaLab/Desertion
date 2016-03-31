using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Alert : MonoBehaviour {

    //hunterが範囲内に入ったとき用のcolと、警報器を起動するために押すキーの表示のためにcolの2つを用意

    public static int my_number = 1;
    private bool me_do = false;
    public float fadeInTime = 1.0f;
    public float inTime = 1.0f;
    public float fadeOutTime = 1.0f;
    public float outTime = 1.0f;
    private float fade_time = 0;
    public FADE_STATE fadeState = FADE_STATE.FADE_IN;
    public float currentTime = 0.0f;
    private Color textColor;
	// Use this for initialization
	void Start () {
        textColor = CanvasMgr.instance.alert.GetComponent<Image>().color;
    }
    public enum FADE_STATE
    {
        FADE_IN,
        IN,
        FADE_OUT,
        OUT
    }	void Update () {
        if (me_do)
        {
            // Update is called once per frame
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
            CanvasMgr.instance.alert.GetComponent<Image>().color = textColor*0.8f;
            fade_time += Time.deltaTime;
            if (fade_time > 5.0)
            {
                CanvasMgr.instance.alert.SetActive(false);
                Destroy(this.gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
            CanvasMgr.instance.alert.SetActive(true);
            me_do = true;
            Debug.Log("dwafhikvk,");
    }
}
