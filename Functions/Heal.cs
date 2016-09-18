using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

	[Range(1,100)]
	public float power = 0;
	[Range(0,60)]
	public int overTime = 0;
	
	int healing = 2;
	int[] info = new int[2];
	
	void Start()
	{
		healing = (int)(healing * (power / 100));
		healing = Mathf.RoundToInt(healing / overTime + 1);
		info [0] = healing;
		info [1] = overTime;
	}
	
	void OnTriggerEnter(Collider hit)
	{
		hit.gameObject.SendMessage("TakeHealth", info);
	}
	
	void OnCollisionEnter(Collision hit)
	{
		hit.gameObject.SendMessage("TakeHealth", info);
	}
	
	void PowerUp()
	{
		healing = (int)(power / 5);
		healing = (int)healing * (overTime / 60);
		info [0] = healing;
	}
}
