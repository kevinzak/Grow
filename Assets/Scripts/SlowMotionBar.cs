using UnityEngine;
using System.Collections;

public class SlowMotionBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver (this, EventManager.Power_Up, "Foo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Foo(){
		LeanTween.scaleX (this.gameObject, 7.5f, 0.5f);
		LeanTween.scaleX (this.gameObject, 0.0f, 10.0f).setDelay (0.5f).setOnComplete(CompleteFunction);
	}

	void CompleteFunction(){
		NotificationCenter.DefaultCenter.PostNotification (this, EventManager.Reset_Power_Up);
	}

}
