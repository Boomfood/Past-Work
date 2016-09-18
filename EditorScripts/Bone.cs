using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour {

	public Material norm;
	public Material hover;
	Renderer myRend;
	public GameObject collider { get; set; }
	public Transform[] children;
	static GameObject currenteCollider;
	public static Bone currentBone;
	public Transform playerStructure;

	void Start()
	{
		if(collider == null)
		{
			/*if(currenteCollider == null || currenteCollider == collider)
			{
				currenteCollider = collider;
				collider.SetActive(true);
			}
			else
			{
				collider.SetActive(false);
			}*/
		}
		myRend = gameObject.GetComponent<Renderer>();
		this.enabled = false;
	}

	void OnMouseOver()
	{
		myRend.material = hover;
	}

	void OnMouseExit()
	{
		myRend.material = norm;
	}

	void OnMouseDown()
	{
		if(currenteCollider != collider)
		{
			currenteCollider.SetActive(false);
			collider.SetActive(true);
			currenteCollider = collider;
		}
		currentBone = this;
	}

	void SetPlayerStructure(Transform playerPart)
	{
		playerStructure = playerPart;
	}
}
