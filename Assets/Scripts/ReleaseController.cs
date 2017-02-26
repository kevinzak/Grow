using UnityEngine;
using System.Collections;

public class ReleaseController : MonoBehaviour {
	GameObject mCurrentObstacle;
	public GameObject releaseTier;

	// Use this for initialization
	void Start () {
		AddObstacle ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void AddObstacle(){
		float toScale = 0.5f;
		mCurrentObstacle = Instantiate(Resources.Load("Obstacle")) as GameObject;
		mCurrentObstacle.gameObject.transform.SetParent (this.gameObject.transform);
		mCurrentObstacle.transform.localPosition = new Vector3 (0, 0.25f, 0);
		LeanTween.scaleY (mCurrentObstacle.gameObject, toScale, 2.0f);
		LeanTween.scaleX (mCurrentObstacle.gameObject, toScale, 2.0f).setOnComplete(ReleaseObject);;
		SphereCollider sphereCollider = mCurrentObstacle.GetComponent<SphereCollider> ();
		sphereCollider.radius = toScale/2;
	}

	void ReleaseObject(){
		LeanTween.moveLocalY (mCurrentObstacle, mCurrentObstacle.transform.localPosition.y + 0.5f, 0.2f).setDelay(1).setOnComplete(SwitchTier);
	}

	void SwitchTier(){
		GameObject newTier = new GameObject ();
		newTier.gameObject.transform.SetParent (this.gameObject.transform.parent.parent);
		newTier.AddComponent<RotationController> ();
		RotationController controller = newTier.GetComponent<RotationController> ();
		mCurrentObstacle.gameObject.transform.SetParent (newTier.transform);
		controller.AnimateSpeedTo (0.75f, 5.0f);

	}

}
