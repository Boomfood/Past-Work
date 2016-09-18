using UnityEngine;
using System.Collections;

public class FreeCam : MonoBehaviour {
	
	public float horizontalSpeed = 2f;
	public float verticalSpeed = 2f;
	public const float startingMovementSpeed = 5f;
	public float movementSpeed = 0f;

	void Update()
	{
		if(Input.GetMouseButton(1))
		{
			float h = horizontalSpeed * Input.GetAxis("Mouse X");
			float v = verticalSpeed * Input.GetAxis("Mouse Y");
			transform.Rotate(0, h, 0, Space.World);
			transform.Rotate(-v, 0, 0);

			if(Input.GetKey("left shift"))
			{
				movementSpeed = startingMovementSpeed * 2;
			}
			else
			{
				movementSpeed = startingMovementSpeed;
			}

			if(Input.GetKey("w"))
			{
				transform.position += transform.forward * movementSpeed * Time.deltaTime;
			}
			else if(Input.GetKey("s"))
			{
				transform.position -= transform.forward * movementSpeed * Time.deltaTime;
			}

			if(Input.GetKey("d"))
			{
				transform.position += transform.right * movementSpeed * Time.deltaTime;
			}
			else if(Input.GetKey("a"))
			{
				transform.position -= transform.right * movementSpeed * Time.deltaTime;
			}

			if(Input.GetKey("e"))
			{
				transform.position += transform.up * movementSpeed * Time.deltaTime;
			}
			else if(Input.GetKey("q"))
			{
				transform.position -= transform.up * movementSpeed * Time.deltaTime;
			}
		}
	}
}
