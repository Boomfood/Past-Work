using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float maxForce = 2;
	public Vector3 direction = Vector3.zero;
	public Vector3 worldGravityDirection;

	void Start()
	{
		worldGravityDirection = Physics.gravity;
	}

	void OnTriggerStay(Collider hit)
	{
		if(hit.attachedRigidbody.velocity.magnitude < maxForce)
		{
			if(direction == Vector3.zero)
			{
				hit.attachedRigidbody.AddForce((transform.position - hit.transform.position).normalized* maxForce, ForceMode.Acceleration);
			}
			else
			{
				hit.attachedRigidbody.AddForce(direction.normalized* maxForce, ForceMode.Acceleration);
			}
		}
	}
}
