using UnityEngine;
using System.Collections;

public class StickGenerator : MonoBehaviour {


	public int numOfSticks = 4;

	// Use this for initialization
	void Start () {
//		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Generate_Stick, "GenerateStick");
//		GenerateStick ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GenerateStick(){
		GameObject stick = Instantiate(Resources.Load("UserStick")) as GameObject;
		stick.gameObject.transform.SetParent (this.gameObject.transform);
	}
}
