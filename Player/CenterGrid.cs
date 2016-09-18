using UnityEngine;
using System.Collections;

public class CenterGrid : MonoBehaviour {

    public Projector proj;
    Material mat;

    void Start()
    {
        mat = proj.material;
    }

	void Update ()
    {
        mat.mainTextureOffset = new Vector2(-(transform.position.x * transform.right.x) + (transform.position.z * transform.right.z), -transform.position.y);
        proj.material = mat;
    }
}
