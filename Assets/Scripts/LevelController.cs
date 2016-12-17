using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public int powerUpCombo = 3;
	public int numOfSticks = 3;
	public StickGenerator generator;

	int sticksUsed = 0;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Generate_Stick, "GenerateNextStick");
		GenerateNextStick ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateNextStick(){
		if (sticksUsed < numOfSticks || numOfSticks < 0) {
			sticksUsed++;
			generator.GenerateStick ();	

			if(sticksUsed == powerUpCombo + 1){
				NotificationCenter.DefaultCenter.PostNotification(this, EventManager.Power_Up);
			}
		}
	}
}
