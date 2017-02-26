using UnityEngine;
using System.Collections;

public class DeadTreeController : MonoBehaviour { 


	// Use this for initialization
	void Start () {
		AddBranch ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddBranch () {
		GameObject branch = Instantiate(Resources.Load("DeadBranch")) as GameObject;
		branch.gameObject.transform.SetParent (this.gameObject.transform);
		DeadTreeBranchController variable = branch.GetComponent<DeadTreeBranchController> ();
		variable.Grow (true);
	}
}
