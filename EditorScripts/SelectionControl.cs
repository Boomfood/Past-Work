using UnityEngine;
using System.Collections;

public class SelectionControl : MonoBehaviour 
{
	bool showing = true;
	GameObject bones;

	void Update()
	{
		if(Input.GetKey("v"))
		{
			if(showing)
			{
				showing = false;
				bones.SetActive(false);
			}
			else
			{
				showing = true;
				bones.SetActive(true);
			}
		}
	}
}
