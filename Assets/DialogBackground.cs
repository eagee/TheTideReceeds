using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBackground : MonoBehaviour {

    private bool myBackgroundIsVisible = false;

    private float lastUpdateTime = 0f;
    private float myDeltaTime = 0f;

    // Use this for initialization
    void Start () {
        myBackgroundIsVisible = false;
        lastUpdateTime = 0f;
        myDeltaTime = 0f;
    }

    void CalculateDeltaTime()
    {
        if (lastUpdateTime != 0)
        {
            myDeltaTime = Time.realtimeSinceStartup - lastUpdateTime;
        }
        lastUpdateTime = Time.realtimeSinceStartup;
    }

    private void SetAlpha(float value)
    {
        Color currentColor = GetComponent<Image>().color;
        currentColor.a = value;
        GetComponent<Image>().color = currentColor;
    }

    private void FadeAlphaToTarget(float fadeSpeed, float targetAlpha)
    {
        Color currentColor = GetComponent<Image>().color;
        if (currentColor.a < targetAlpha)
        {
            currentColor.a += fadeSpeed * myDeltaTime;
            if (currentColor.a > targetAlpha) currentColor.a = targetAlpha;
        }
        else if (currentColor.a > targetAlpha)
        {
            currentColor.a -= fadeSpeed * myDeltaTime;
            if (currentColor.a < targetAlpha) currentColor.a = targetAlpha;
        }
        GetComponent<Image>().color = currentColor;
    }

    public void Show()
    {
        //SetAlpha(1f);
        myBackgroundIsVisible = true;
    }

    public void Hide()
    {
        //SetAlpha(0f);
        myBackgroundIsVisible = false;
    }
	
	// Update is called once per frame
	void Update () {
        CalculateDeltaTime();
        if (myBackgroundIsVisible)
        {
            FadeAlphaToTarget(3f, 1.0f);
        }
        else
        {
            FadeAlphaToTarget(3f, 0.0f);
        }
    }
}
