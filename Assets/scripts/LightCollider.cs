using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class LightCollider : MonoBehaviour {

    public Image TargetImage;
    public Color ColorToSet;

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("Player collision! Invoking text!");

        if(coll.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            TargetImage.color = ColorToSet;
        }
    }
	

}
