using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Transform refference;
    public Transform editorSetProjectile;
    Structures.Craft projectile;
	Rigidbody tempRig;
	[Range(1,100)]
	public int power = 100;
	[Range(1,60)]
	public int overTime = 4;
    private Collider co;

	void OnEnable()
	{
        if (!editorSetProjectile)
        {
            SaveLoad.saveLoad.LoadCustom<Structures.Craft>("triangle", ref projectile);
        }
		StartCoroutine (Shoot ());
	}

	IEnumerator Shoot()
    {
        if(name.Contains("Cube"))
        {
            co = gameObject.GetComponent<BoxCollider>();
        }
        else if (name.Contains("Sphere"))
        {
            co = gameObject.GetComponent<SphereCollider>();
        }
        else
        {
            co = gameObject.GetComponent<MeshCollider>();
        }
        for (;;)
		{
            if (!editorSetProjectile)
            {
                refference = CraftController.refference.SpawnCraft(projectile, co.bounds.ClosestPoint(transform.position + transform.forward), transform.eulerAngles);
            }
            else
            {
                refference = Instantiate(editorSetProjectile, co.bounds.ClosestPoint(transform.position + transform.forward), transform.rotation)as Transform;
            }
            tempRig = refference.GetComponent<Rigidbody>();
            tempRig.useGravity = true;
            tempRig.isKinematic = false;
			tempRig.velocity = (transform.forward * power);
			tempRig.SendMessage("RigidBodyActive", tempRig, SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds (overTime);
		}
	}
}
