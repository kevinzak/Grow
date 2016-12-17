using UnityEngine;
using System.Collections;

public class CentralSphereController : MonoBehaviour {


	Vector3 speed = new Vector3(1,1,1);
	float rotationSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3(0,0,-1), speed.x * rotationSpeed, Space.Self);
	}

}
