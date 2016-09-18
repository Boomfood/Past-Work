using UnityEngine;
using System.Collections;

public class Seek :  AIInterface
{
    Vector3 waypoint;
    Vector2 Waypoint2D;
    Transform Target;
    RaycastHit rayHit;
    string firstCoroutine = "Path";
    public Transform target
    {
        get
        {
            return Target;
        }
        set
        {
            Target = value;
        }
    }

    IEnumerator Path()
    {
        for (;;)
        {
            for (bool valid = false; !valid;)
            {
                yield return new WaitForSeconds(1);
                Waypoint2D = Random.insideUnitCircle * triggerSize;
                waypoint = new Vector3(Waypoint2D.x, 0f, Waypoint2D.y) + transform.position;
                if(Physics.SphereCast(transform.position, width, waypoint - transform.position, out rayHit , Vector3.Distance(waypoint, transform.position), 1<<gameObject.layer) && !movementController.Grounded)
                {
                    yield return null;
                }
                else
                {
                    valid = true;
                    pet.transform.position = waypoint;
                    transform.LookAt(waypoint, Vector3.up);
                    SetMovement(0f, 1f);
                }

            }
            for (;Vector3.Distance(transform.position, waypoint) < 1f;)
            {
                yield return null;
            }
        }
    }

    IEnumerator Chase()
    {
        yield return null;
    }

    IEnumerator Attack()
    {
        for (;;)
        {
            if(Vector3.Distance(transform.position,target.position) > range)
            {
                break;
            }
            gameObject.SendMessage("MainFun", SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Chase");
    }

    void OnTriggerEnter(Collider hit)
    {
        if (!target && hit.tag.Contains("Bad"))
        {
            target = hit.transform;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.transform == target)
        {
            target = null;
        }
    }
}
