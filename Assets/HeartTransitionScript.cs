using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HeartTransitionScript : MonoBehaviour {
    private bool started = false;
    public bool TransitionIn = false;
    private float speed = 100.0f;
    // Use this for initialization
    void Start ()
    {
        if(TransitionIn == true)
        {
            speed = -100.0f;
            this.transform.localScale = new Vector3(100f, 100f, 100f);
            started = true;
        }
        else
        {
            speed = 100.0f;
            this.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            started = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && !TransitionIn)
        {
            started = true;
        }

        if(started)
        {
            if (TransitionIn) speed -= 1.0f;
            else speed += 1.0f;
            Vector3 scale = this.transform.localScale;
            print("Scaling down!" + scale.x.ToString());
            scale.x += speed * Time.deltaTime;
            scale.y += speed * Time.deltaTime;
            if (!TransitionIn && scale.x > 500.0f)
            {
                SceneManager.LoadScene("MainScene");
            }
            else if (TransitionIn && scale.x <= 0.001f)
            {
                Destroy(gameObject);
            }
            this.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
	}
}
