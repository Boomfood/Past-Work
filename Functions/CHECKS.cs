using UnityEngine;
using System.Collections;
using System;

public class CHECKS : MonoBehaviour {

    void OnCollisionEnter(Collision hit)
    {
        try
        {
            hit.contacts[0].thisCollider.SendMessage("OnCollisionEnter", hit, SendMessageOptions.DontRequireReceiver);
        }
        catch(NullReferenceException)
        {
        }
    }

    void RigidBodyActive(Rigidbody element)
    {
        StartCoroutine(VelocityCheck(element));
    }

    public void LostPart()
    {
        if(transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator VelocityCheck(Rigidbody element)
    {
        for (;;)
        {
            yield return null;
            if (element.velocity.sqrMagnitude <= 0)
            {
                yield return new WaitForSeconds(1);
                if (element.velocity.sqrMagnitude <= 0)
                {
                    Destroy(element);
                    break;
                }
            }
        }
    }
}
