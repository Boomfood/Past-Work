using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

	public Rigidbody parent;


	public enum Directions{forward,backward,left,right,up,down};
	public Directions directions;
	[Range(0, 600)]
	public float force = 200;
	public bool continues = true;
	delegate void Direction(bool on);
	Direction direction;
	public bool on = true;

	void Start()
	{
		if(continues)
		{
			force *= 10;
		}
		switch(directions)
		{
			case Directions.forward:
				direction = Forward;
			break;
			case Directions.backward:
				direction = Backward;
			break;
			case Directions.left:
				direction = Left;
			break;
			case Directions.right:
				direction = Right;
			break;
			case Directions.up:
				direction = Up;
			break;
			case Directions.down:
				direction = Down;
			break;
		}
	}

	void Update()
	{
		//direction ();
	}

	void Forward(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (transform.forward * force);
			}
		}
		else
		{
			parent.AddForce (transform.forward * (force - parent.velocity.magnitude));
		}
	}

	void Backward(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (-transform.forward * force);
			}
		}
		else
		{
			parent.AddForce (-transform.forward * (force - parent.velocity.magnitude));
		}
	}

	void Right(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (transform.right * force);
			}
		}
		else
		{
			parent.AddForce (transform.right * (force - parent.velocity.magnitude));
		}
	}

	void Left(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (-transform.right * force);
			}
		}
		else
		{
			parent.AddForce (-transform.right * (force - parent.velocity.magnitude));
		}
	}

	void Up(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (transform.up * force);
			}
		}
		else
		{
			parent.AddForce (transform.up * (force - parent.velocity.magnitude));
		}
	}

	void Down(bool on)
	{
		if(!continues)
		{
			if(Input.GetKeyDown("w"))
			{
				parent.AddForce (-transform.up * force);
			}
		}
		else
		{
			parent.AddForce (-transform.up * (force - parent.velocity.magnitude));
		}
	}
}
