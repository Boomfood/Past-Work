using UnityEngine;
using System.Collections;

public class Defence : MonoBehaviour {

	[Range(1,5)]
	public int power = 1;

	void Start () 
	{
		gameObject.SendMessage ("IncreaseDefence", power);
	}
}
