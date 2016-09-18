using UnityEngine;
using System.Collections;
using System;

public class Damage : MonoBehaviour {

	[Range(1,100)]
	public float power = 100;
	[Range(0,60)]
	public int overTime = 0;

	public int damage = 10;
	int[] info = new int[2];

	void Start()
	{
		damage = (int)(damage * (power / 100));
		damage = Mathf.RoundToInt(damage / (overTime + 1));
		info [0] = damage;
		info [1] = overTime;
	}

	void OnTriggerEnter(Collider hit)
    {
        if (!hit.transform.tag.Contains(this.tag))
        {
            hit.gameObject.SendMessage("TakeDamage", info, SendMessageOptions.DontRequireReceiver);
        }
	}

	void OnCollisionEnter(Collision hit)
	{
        if (!hit.transform.tag.Contains(this.tag))
        {
            hit.gameObject.SendMessage("TakeDamage", info, SendMessageOptions.DontRequireReceiver);
        }
	}

	void PowerUp()
	{
		damage = (int)power;
		damage = (int)damage * (overTime / 60);
		info [0] = damage;
	}
}
