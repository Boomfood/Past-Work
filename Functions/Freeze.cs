using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {

	[Range(1,10)]
	public int overTime = 1;
	
	void OnTriggerEnter(Collider hit)
	{
		StartCoroutine (Frozen(hit.transform, Time.time));
	}
	
	void OnCollisionEnter(Collision hit)
	{
		StartCoroutine (Frozen(hit.transform, Time.time));
	}

	IEnumerator Frozen(Transform hit, float startTime)
	{
		Vector3 pos = hit.position;
		Vector3 rot = hit.eulerAngles;
		for(; (Time.time - startTime) <= overTime;)
		{
			hit.position = pos;
			hit.eulerAngles = rot;
			yield return null;
		}
	}

	void PowerUp()
	{
		overTime *= 10;
	}
}
