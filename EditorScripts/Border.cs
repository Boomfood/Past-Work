using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Border : MonoBehaviour {

	public List<int> outOfBounds = new List<int>();
	Renderer render;
	public Material ok;
	public Material bad;

	void Start()
	{
		render = gameObject.GetComponent<Renderer>();
	}

	void OnTriggerExit(Collider diserter)
	{
		if(diserter.gameObject.layer == 8 && !outOfBounds.Contains(diserter.GetInstanceID()))
		{
			outOfBounds.Add(diserter.GetInstanceID());
			EditorController.saveble = false;
			render.material = bad;
		}
	}

	void OnTriggerEnter(Collider returner)
	{
		if(outOfBounds.Contains(returner.GetInstanceID()))
		{
			outOfBounds.Remove(returner.GetInstanceID());
			if(outOfBounds.Count == 0)
			{
				EditorController.saveble = true;
				render.material = ok;
			}
		}
	}
}
