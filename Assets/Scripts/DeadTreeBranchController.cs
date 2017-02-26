using UnityEngine;
using System.Collections;

public class DeadTreeBranchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Grow (bool spawnChild) {
		float rotation_rad = Mathf.Deg2Rad * this.gameObject.transform.localEulerAngles.z;
		float rad = this.gameObject.transform.localEulerAngles.z * Mathf.Deg2Rad;
		
		double y = -1.75 * Mathf.Cos(rotation_rad);
		double x = 1.75 * Mathf.Sin(rotation_rad);
		
		// isGrowing = true;
		float duration = 2.0f;
		float toScale = 1.5f;
		LeanTween.scaleY (this.gameObject, toScale, duration);
		LeanTween.moveLocalX (this.gameObject, (float)(x), 2.0f);
		LeanTween.moveLocalY (this.gameObject, (float)(y), 2.0f);
		if (spawnChild) {
			Spawn();
		}
	}

	// Spawns a child branch
	public void Spawn () {
		GameObject branch = Instantiate(Resources.Load("DeadBranch")) as GameObject;
		branch.gameObject.transform.SetParent (this.gameObject.transform);
		DeadTreeBranchController variable = branch.GetComponent<DeadTreeBranchController> ();
		variable.Grow (false);
	}
}
