using UnityEngine;
using System.Collections;

public class StickController : MonoBehaviour {
	public GameObject center;

	public float speed = 5.0f;
	bool didFire = false;
	bool monitorClick = true;
	bool isGrowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && monitorClick) {
			Fire ();
		}

		if (isGrowing) {
			float step = 100 * Time.deltaTime;
			Vector3.MoveTowards (this.gameObject.transform.position, new Vector3 (0, 0, 0), -step);
		}
	}

	void FixedUpdate(){
		if (didFire) {
			this.transform.position += new Vector3 (0, speed * Time.deltaTime);
		}
	}

	void Fire(){
		print ("Button did fire");
		didFire = true;
		monitorClick = false;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "CentralSphere") {
			NotificationCenter.DefaultCenter.PostNotification (this, EventManager.Generate_Stick);

			this.gameObject.transform.SetParent (col.gameObject.transform.parent);


			Grow();
			AddObstacle();
			this.gameObject.AddComponent<ObstacleController>();
			Destroy( this.gameObject.GetComponent<StickController>());
			print ("end of stick collision");
		}
	
		didFire = false;

	}

	void Grow(){
		float rotation_rad = Mathf.Deg2Rad * this.gameObject.transform.localEulerAngles.z;
		float rad = this.gameObject.transform.localEulerAngles.z * Mathf.Deg2Rad;

		double y = -1.75 * Mathf.Cos(rotation_rad);
		double x = 1.75 * Mathf.Sin(rotation_rad);

		float duration = 2.0f;
		float toScale = 1.5f;
		isGrowing = true;
		LeanTween.scaleY (this.gameObject, toScale, duration);
		LeanTween.moveLocalX (this.gameObject, (float)(x), 2.0f);
		LeanTween.moveLocalY (this.gameObject, (float)(y), 2.0f);
	}

	void AddObstacle(){
		GameObject obstacle = Instantiate(Resources.Load("Obstacle")) as GameObject;
		obstacle.gameObject.transform.SetParent (this.gameObject.transform);
		obstacle.transform.localPosition = new Vector3 (0, -0.5f, 0);
		LeanTween.scaleY (obstacle.gameObject, 0.5f, 2.0f);
		LeanTween.scaleX (obstacle.gameObject, 15.5f, 2.0f);
		SphereCollider sphereCollider = obstacle.GetComponent<SphereCollider> ();
		sphereCollider.radius = 0.34f;
	}
}
