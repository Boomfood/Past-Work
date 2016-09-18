using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody))]
public class CharacterMovement : MonoBehaviour {

	Rigidbody rb;
	public float maxForwardVelocity = 40f;
	public float maxVerticlVelocity = 80f;
	public float maxHorizotalVelocity = 30f;
	public int doubleJumpMax = 2;
	public int doubleJump;
    
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		doubleJump = doubleJumpMax;
	}

    public void Idle(Vector3 direction, float currentVeloctiy)
    {
       // rb.velocity -= new Vector3(rb.velocity.x % direction.x, 0f, rb.velocity.z % direction.z);
    }

    public void Forwards(bool grounded, bool advanced, float currentVeloctiy, bool holding, bool wallup, bool wallRun, float wallupVelocity)
    {
        if (grounded)
        {
            if (advanced)
            {
                rb.AddForce(transform.forward * Mathf.Clamp((maxForwardVelocity) - currentVeloctiy, 0, maxForwardVelocity));
            }
            else
            {
                rb.AddForce(transform.forward * ((maxForwardVelocity / 2) - currentVeloctiy));
            }
        }
        else if (advanced)
        {
            rb.AddForce(transform.forward * Mathf.Clamp((maxForwardVelocity) - currentVeloctiy, 0, maxForwardVelocity));
            if (holding)
            {
                rb.AddForce(transform.up * 3.2f, ForceMode.Impulse);
            }
            else if(wallRun)
            {
                rb.AddForce(transform.up * ((Physics.gravity.y /2f)* -1));
                print(Physics.gravity);
            }
            else if (wallup)
            {
                Jump(true, false, wallupVelocity);
            }
        }
		else
		{
			rb.AddForce(transform.forward * Mathf.Clamp((maxForwardVelocity) - currentVeloctiy, 0, maxForwardVelocity));
		}
	}

	public void Backwards(bool grounded, bool advanced, float currentVeloctiy)
	{
		if(grounded)
		{
            if (advanced)
            {
                rb.AddForce(-transform.forward * (maxForwardVelocity - currentVeloctiy));
            }
            else
            {
                rb.AddForce(-transform.forward * ((maxForwardVelocity / 2) - currentVeloctiy));
            }
        }
		else
		{
			rb.AddForce(-transform.forward * Mathf.Clamp((maxForwardVelocity) - currentVeloctiy, 0, maxForwardVelocity));
		}
	}

	public void Right(bool grounded, bool advanced, float currentVeloctiy)
	{
		if(grounded)
		{
            if (advanced)
            {
                rb.AddForce(transform.right * (maxHorizotalVelocity - currentVeloctiy));
            }
            else
            {
                rb.AddForce(transform.right * ((maxHorizotalVelocity / 2) - currentVeloctiy));
            }
        }
		else
		{
			rb.AddForce(transform.right * Mathf.Clamp((maxForwardVelocity) - currentVeloctiy, 0, maxHorizotalVelocity));
		}
	}

	public void Left(bool grounded, bool advanced, float currentVeloctiy)
	{
		if(grounded)
		{
            if (advanced)
            {
                rb.AddForce(-transform.right * (maxHorizotalVelocity - currentVeloctiy));
            }
            else
            {
                rb.AddForce(-transform.right * ((maxHorizotalVelocity / 2) - currentVeloctiy));
            }
        }
		else
		{
			rb.AddForce(-transform.right * Mathf.Clamp((maxHorizotalVelocity) - currentVeloctiy, 0, maxHorizotalVelocity));
		}
	}

	public void Jump(bool grounded, bool advanced, float currentVeloctiy)
	{
        if(grounded)
        {
            doubleJump = doubleJumpMax;
        }
		if(doubleJump > 1)
		{
            Mathf.Clamp(doubleJump--, 0, doubleJumpMax);
			rb.AddForce((transform.up * (maxVerticlVelocity - currentVeloctiy)) + (rb.velocity * 0.1f));
        }
        else if(doubleJump > 0)
        {
            Mathf.Clamp(doubleJump--, 0, doubleJumpMax);
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce((transform.up * (maxVerticlVelocity - currentVeloctiy)) + (rb.velocity * 0.1f));
        }
	}

	public void Crouch(bool grounded, bool advanced, float currentVeloctiy)
	{


	}
}
