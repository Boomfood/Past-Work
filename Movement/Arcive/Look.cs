using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

    public enum activeAxis {x, y, xAndY};

    public float xLock = 0f;
    public float yLock = 0f;
    public activeAxis axis;

    void Start()
    {

    }

    void Update()
    {
        if (!Input.GetKey("left alt"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (axis == activeAxis.x || axis == activeAxis.xAndY)
            {
                transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 10, transform.up);
            }
            if (axis == activeAxis.y || axis == activeAxis.xAndY)
            {
                transform.rotation *= Quaternion.AngleAxis(-(Input.GetAxis("Mouse Y") * 10), Vector3.right);
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
