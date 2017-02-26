using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
	public float rotationSpeed = 2.0f;
	public bool clockWise = true;
	public bool increaseSpeedObserver = false;
	public bool decreaseSpeedObserver = false;
	public int powerUpEffect = 3; // Note: The higher the power up effect, the slower the rotation

	Vector3 speed = new Vector3(1,1,1);
	float 	toRotationSpeed = - 1;
	float 	changeSpeedDuration = 5; // duration in seconds
	float 	t = 0;

	// Use this for initialization
	void Start () {
		if (toRotationSpeed == -1) {
			toRotationSpeed = rotationSpeed;
		}

		if (increaseSpeedObserver) {
			NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Increase_Speed, "IncreaseSpeed");
		}

		if (decreaseSpeedObserver) {
			NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Decrease_Speed, "DecreaseSpeed");
		}

		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Power_Up, "PowerUpActivated");
		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Reset_Power_Up, "PowerUpReset");

	}
	
	// Update is called once per frame
	void Update () {
		if (rotationSpeed != toRotationSpeed) {
			t += Time.deltaTime/changeSpeedDuration;
			rotationSpeed = Mathf.Lerp (rotationSpeed, toRotationSpeed, t);
		}

		int xRotation = 1;
		if (clockWise) {
			xRotation = -1;
		}
		this.transform.Rotate (new Vector3(0,0,xRotation), speed.x * rotationSpeed, Space.Self);
	}

	void IncreaseSpeed(){
		print ("Increasing speed!");
		rotationSpeed++;
		print (rotationSpeed);
	}

	void DecreaseSpeed(){
		if (rotationSpeed != 1) {
			rotationSpeed--;
		}
	}

	void PowerUpActivated(){
		print ("power up activated");
		for (int i = 0; i < this.powerUpEffect; i++) {
			DecreaseSpeed();
		}
	}

	void PowerUpReset() {
		for (int i = 0; i < this.powerUpEffect; i++) {
			IncreaseSpeed();
		}
	}


	public void AnimateSpeedTo(float toSpeed, float duration ){
		t = 0;
		toRotationSpeed = toSpeed;
		changeSpeedDuration = duration;
		print ("Aniamte call!");

	}
}


