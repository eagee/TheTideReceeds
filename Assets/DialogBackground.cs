using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBackground : MonoBehaviour {

    private bool myBackgroundIsVisible = false;

	// Use this for initialization
	void Start () {
        myBackgroundIsVisible = false;
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
            currentColor.a += fadeSpeed;
            if (currentColor.a > targetAlpha) currentColor.a = targetAlpha;
        }
        else if (currentColor.a > targetAlpha)
        {
            currentColor.a -= fadeSpeed;
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
        if(myBackgroundIsVisible)
        {
            FadeAlphaToTarget(0.05f, 1.0f);
        }
        else
        {
            FadeAlphaToTarget(0.05f, 0.0f);
        }
    }
}
