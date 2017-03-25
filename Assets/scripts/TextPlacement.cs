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
    private DialogBackground[] dialogBackgrounds;

    // Use this for initialization
    void Start () {
        Shown = false;
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";

        // Here we use FindObjectsOfType to get everything in the scene we added a "DialogBackground" script to.
        dialogBackgrounds = FindObjectsOfType<DialogBackground>();
    }


    public void ShowText(string textToShow)
    {
        // Here we loop through each DialogBackground we got from FindObjectsOfType above, and call show on it to make it appear.
        foreach(DialogBackground bg in dialogBackgrounds)
        {
            bg.Show();
        }
        
        message = textToShow;
        StartCoroutine(TypeText());
    }

    public void HideText()
    {
        textComp.text = "";
        // Here we loop through each DialogBackground we got from FindObjectsOfType above, and call hide on it to make it disappear.
        foreach (DialogBackground bg in dialogBackgrounds)
        {
            bg.Hide();
        }
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

		while (Input.GetMouseButton(0) == false && Input.GetKeyDown(KeyCode.Space) == false && Input.GetKeyDown(KeyCode.Return) == false) {
			yield return null;
		}

        HideText();

        Shown = true;

	    Time.timeScale = 1f;
	}
}