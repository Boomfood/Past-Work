using UnityEngine;
using System.Collections;

public class Protection : MonoBehaviour {

    int indexID = 0;
    public Transform shield; //purely for in game editor, only needs indexID to function in game
    Transform Shield
    {
        get
        {
            return shield;
        }
        set
        {
            for (int count = 0; count < transform.parent.childCount; count++)
            {
                if (transform.parent.GetChild(count) == value)
                {
                    indexID = count;
                    break;
                }
            }
            shield = value;
        }
    }

	void Start()
    {
        SendMessage("SetProtection", transform.GetChild(indexID));
    }
}
