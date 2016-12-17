using UnityEngine;
using System.Collections;

public class CentralSphere : MonoBehaviour {
	public bool increaseSpeed = false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Generate_Stick, "GenerateStick");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains ("UserStick")) {
			col.gameObject.name = "Obstacle";
			if(increaseSpeed){
				NotificationCenter.DefaultCenter.PostNotification (this, EventManager.Increase_Speed);
			}
		}
	}



}
