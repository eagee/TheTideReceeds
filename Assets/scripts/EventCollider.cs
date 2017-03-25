using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class EventCollider : MonoBehaviour {

    public UnityEvent onMyEvent;

	// Use this for initialization
	void Start () {
      
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("Player collision! Invoking text!");

        if(coll.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            onMyEvent.Invoke();
            
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        //     onMyEvent.Invoke();
	}
}
