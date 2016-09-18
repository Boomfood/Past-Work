using UnityEngine;
using System.Collections;

public class Phase : MonoBehaviour {

	Collider collider;

	void Awake()
	{
		if(name.Contains("Cube"))
		{
			collider = gameObject.GetComponent<BoxCollider> ();
		}
		else if(name.Contains("Sphere"))
		{
			collider = gameObject.GetComponent<SphereCollider> ();
		}
		else
		{
			collider = gameObject.GetComponent<MeshCollider> ();
		}
	}

	void OnEnable()
	{
		collider.isTrigger = true;
	}

	void OnDisable()
	{
		collider.isTrigger = false;
	}
}
