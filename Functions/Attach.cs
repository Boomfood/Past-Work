using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attach : MonoBehaviour {

    List<FixedJoint> joints = new List<FixedJoint>();
    FixedJoint tempJoint;
    public bool active = true;

    public enum ActivationType { Passive, Mian, Secondry };
    ActivationType type = ActivationType.Passive;

    delegate void Activation();
    Activation PassiveAction;
    Activation MainAction;
    Activation SecondryAction;

    void Start()
    {
        switch (type)
        {
            case ActivationType.Mian:
                MainAction = Toggle;
                break;
            case ActivationType.Secondry:
                SecondryAction = Toggle;
                break;
            case ActivationType.Passive:
                active = true;
                break;
        }
    }

    public void MainFun()
    {
        MainAction();
    }
    public void Secondry()
    {
        SecondryAction();
    }

    void Toggle()
    {
        if (active)
        {
            active = false;
            for(int count = 0; count < joints.Count; count++)
            {
                Destroy(joints[count]);
            }
        }
        else
        {
            active = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(active)
        {
            /*tempJoint = transform.parent.gameObject.AddComponent<FixedJoint>();
            tempJoint.connectedBody = hit.transform.parent.GetComponent<Rigidbody>();
            joints.Add(tempJoint);*/
        }
    }
    void OnCollisionEnter(Collision hit)
    {
        if(active)
        {
            tempJoint = transform.parent.gameObject.AddComponent<FixedJoint>();
            tempJoint.connectedBody = hit.contacts[0].otherCollider.transform.parent.GetComponent<Rigidbody>();
            joints.Add(tempJoint);

            print("added");
        }
    }

    void KILL()
    {
        for (int count = 0; count < joints.Count; count++)
        {
            Destroy(joints[count]);
        }
    }
}
