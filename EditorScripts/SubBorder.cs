using UnityEngine;
using System.Collections;

public class SubBorder : MonoBehaviour {

	public Border borderRef;

	void OnTriggerExit(Collider diserter)
	{
		borderRef.SendMessage("OnTriggerExit", diserter);
	}
	
	void OnTriggerEnter(Collider returner)
	{
		borderRef.SendMessage("OnTriggerEnter", returner);
	}
}
