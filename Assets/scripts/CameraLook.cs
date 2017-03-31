using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;
    private float myShakeTimer = 0.0f;
    
	
	void Start () 
	{
        myShakeTimer = 0.0f;
    }

    public void TriggerCameraShake(float time)
    {
        myShakeTimer = time;
    }
    
	void LateUpdate () 
	{
        Vector3 cameraPos = transform.position;
        cameraPos.x = player.transform.position.x;
        cameraPos.y = player.transform.position.y;
        
        if (myShakeTimer > 0)
        {
            print("Shaking for: " + myShakeTimer.ToString());
            myShakeTimer -= 1.0f * Time.deltaTime;
            cameraPos.x += Random.Range(-0.1f, 0.1f);
        }

        transform.position = cameraPos;
    }
}
