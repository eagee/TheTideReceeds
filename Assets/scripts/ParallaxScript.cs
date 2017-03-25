using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

	public float VerticalSpeed = 0.1f;
	public float HorizontalSpeed = 0.1f;
	public Transform CameraPosition;
	private Vector3 InitialOffset;


	void Start () {
	
		InitialOffset = this.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = this.transform.position;
		pos.x = InitialOffset.x - (CameraPosition.position.x * HorizontalSpeed);
		pos.y = InitialOffset.x - (CameraPosition.position.y * VerticalSpeed);
		this.transform.position = pos;
	}
}
