using UnityEngine;
using System.Collections;

public class exitreset : MonoBehaviour {

	
	void Update ()
    {
	    if(Input.GetKeyDown("p"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(0);
        }
    }
}
