using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFloatingScript : MonoBehaviour {

    public float StartingY = -9f;
    public float EndingY = 9f;
    public float MinX = 3f;
    public float MaxX = 5f;
    private float Speed = 0f;

	// Use this for initialization
	void Start () {
        Speed = Random.Range(1.0f, 5.0f);        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += Speed * Time.deltaTime;
        
        if(pos.y > EndingY)
        {
            pos.y = StartingY;
            pos.x = Random.Range(MinX, MaxX);
            Speed = Random.Range(1.0f, 5.0f);
        }

        transform.position = pos;
    }
}
