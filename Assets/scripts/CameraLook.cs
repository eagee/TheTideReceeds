using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
	
	public GameObject player;       
	
	private Vector3 offset;         
	
	
	void Start () 
	{
	}
	
	
	void LateUpdate () 
	{

		Vector3 cameraPos = transform.position;
		cameraPos.x = player.transform.position.x;
		cameraPos.y = player.transform.position.y;
		transform.position = cameraPos;
	}
}
