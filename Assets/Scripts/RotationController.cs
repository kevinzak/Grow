using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
	public float rotationSpeed = 2.0f;
	public bool clockWise = true;
	public bool increaseSpeedObserver = false;
	public bool decreaseSpeedObserver = false;
	public int powerUpEffect = 3; // Note: The higher the power up effect, the slower the rotation

	Vector3 speed = new Vector3(1,1,1);


	// Use this for initialization
	void Start () {
		if (increaseSpeedObserver) {
			NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Increase_Speed, "IncreaseSpeed");
		}

		if (decreaseSpeedObserver) {
			NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Decrease_Speed, "DecreaseSpeed");
		}

		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Power_Up, "PowerUpActivated");
	}
	
	// Update is called once per frame
	void Update () {
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

}

