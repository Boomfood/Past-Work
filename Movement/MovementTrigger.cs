using UnityEngine;
using System.Collections;
using System;

public class MovementTrigger : MonoBehaviour {

	public delegate void Toggle(bool active);
	public Toggle ActiveToggle;
    public enum directions {up, down, left, right, forwards, backwards};
    public directions direction = directions.down;
    GameObject directionObj;
	public int Count = 0;
    public float qualifiable = 3f;
    public int count
	{
		get
		{
			return Count;
		}
		set
		{
			if(value <= 0)
			{
				ActiveToggle(false);
			}
			else
			{
				ActiveToggle(true);
			}
			Count = Mathf.Clamp(value, 0, value);
		}
	}

    void Start()
    {
        directionObj = new GameObject();
        directionObj.transform.parent = transform;
        directionObj.transform.localPosition = Vector3.zero;
        directionObj.transform.localEulerAngles = Vector3.zero;
    }

	void OnTriggerEnter(Collider hit)
	{
        if (hit.transform.lossyScale.magnitude > qualifiable && !hit.tag.Contains(tag))
        {
            count++;
        }
    }

	void OnTriggerExit(Collider hit)
    {
        if (hit.transform.lossyScale.magnitude > qualifiable && !hit.tag.Contains(tag))
        {
            count--;
        }
	}
}
