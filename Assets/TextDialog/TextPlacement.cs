using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPlacement : MonoBehaviour {

	public float letterPause = 0.001f;
	public AudioClip typeSound1;
	public AudioSource aSource;
    public bool Shown = false;

	string message;
	Text textComp;

	// Use this for initialization
	void Start () {
        Shown = false;
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
    }


    public void ShowText(string textToShow)
    {
        message = textToShow;
        StartCoroutine(TypeText());
    }

    public void HideText()
    {
        textComp.text = "";
    }

	IEnumerator TypeText () {

		Time.timeScale = 0f;
		char[] letters = message.ToCharArray ();

		for (int i = 0; i < letters.Length; i++) {
			textComp.text += letters[i];
			if (typeSound1 && aSource)
				aSource.PlayOneShot (typeSound1);
			yield return 0;
			//yield return new WaitForSeconds (letterPause);
		}

		while (Input.GetMouseButton(0) == false || Input.GetKeyDown(KeyCode.LeftControl)) {			
			yield return null;
		}

        Shown = true;

	    Time.timeScale = 1f;
	}
}