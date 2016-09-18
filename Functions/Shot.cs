using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	void Fired(Vector3 force)
	{
		GetComponent<Rigidbody> ().AddForce (force);
	}

}
