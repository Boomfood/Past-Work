using UnityEngine;
using System.Collections;

public class UsePhysiscs : MonoBehaviour {
	
	void Start ()
    {
        if (Menu.refference.GameScene.activeInHierarchy)
        {
            transform.parent.GetComponent<Rigidbody>().useGravity = true;
            transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
