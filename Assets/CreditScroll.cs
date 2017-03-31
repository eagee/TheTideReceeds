using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroll : MonoBehaviour {
    public bool isLastCredit = false;
    public bool isTitleCredit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        float speed = 3.0f;
        if(!isLastCredit && !isTitleCredit)
        {
            pos.y += speed * Time.deltaTime;
        }
        else if (isTitleCredit && (pos.y < 2))
        {
            pos.y += speed * Time.deltaTime;
        }
        else if (isTitleCredit && (pos.x > -3.5))
        {
            pos.x -= speed * Time.deltaTime;
        }
        else if(pos.y < 0)
        {
            pos.y += speed * Time.deltaTime;
        }

        if (pos.y > 9.0f)
        {
            Destroy(this);
        }

        transform.position = pos;
    }
}
