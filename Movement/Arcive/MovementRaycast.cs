using UnityEngine;
using System.Collections;
using System;

public class MovementRaycast : MonoBehaviour {

	public delegate void Toggle(bool active);
	public Toggle ActiveToggle;
    Ray ray;
    RaycastHit hit;
	public bool Active = false;
	public bool active
	{
		get
		{
			return Active;
		}
		set
		{
            if (value != Active)
            {
                ActiveToggle(value);
                Active = value;
            }
		}
	}

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray,out hit, 3f))
        {
            if(!hit.transform.tag.Contains(tag))
            {
                Debug.DrawLine(ray.origin, hit.point);
                active = true;
            }
            else
            {
                active = false;
            }
        }
        else
        {
            active = false;
        }
    }
}
