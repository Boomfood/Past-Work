using UnityEngine;
using System.Collections;
using System.IO;

[RequireComponent( typeof( Rigidbody))]
public class PlayerInput : MonoBehaviour {
	
	public CharacterMovement CM;
    public MainInterface MI;
	public MovementTrigger groundTrigger;
    public MovementRaycast holdTrigger;
    public MovementTrigger wallTrigger;
    public MovementTrigger sideTrigger;
    public bool grounded = false;
    public bool holding = false;
    public bool wallUp = false;
    public bool WallRun = false;
    string[] toolbarStr;
    Structures.Craft[] toolbar;
    float midScreen;
    public bool wallRun
    {
        get
        {
            return WallRun;
        }
        set
        {
            if(WallRun != value)
            {
                rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y*1, rb.velocity.z);// might beak stuff :S
            }
            WallRun = value;
        }
    }
    bool advanced = false;
	float currentForwardVelocity = 0f;
	float currentVerticalVelocity = 0f;
	Rigidbody rb;
    RaycastHit hit;

	void Start()
	{
        midScreen = Screen.width / 2;
		groundTrigger.ActiveToggle = ToggleGrounded;
        holdTrigger.ActiveToggle = ToggleHold;
        wallTrigger.ActiveToggle = ToggleWallUp;
        sideTrigger.ActiveToggle = ToggleWallRun;
        rb = GetComponent<Rigidbody>();
        toolbarStr = Directory.GetFiles(Application.persistentDataPath, "", SearchOption.TopDirectoryOnly);
        for (int count = 0; count < 6; count++)
        {
            SaveLoad.saveLoad.LoadCustom<Structures.Craft>(toolbarStr[count], ref toolbar[count]);
        }
	}

	void ToggleGrounded(bool value)
	{
		grounded = value;
	}

    void ToggleHold(bool value)
    {
        holding = value;
    }

    void ToggleWallUp(bool value)
    {
        wallUp = value;
    }

    void ToggleWallRun(bool value)
    {
        wallRun = value;
    }

    void Update ()
    {
        currentForwardVelocity = Mathf.Abs(rb.velocity.x + rb.velocity.z);
        currentForwardVelocity = Mathf.Abs(rb.velocity.y);

        if (grounded)
        {
            rb.AddForce(-(new Vector3(rb.velocity.x, 0f, rb.velocity.z) * 4));
        }
		

		if(Input.GetButton("Advanced"))
		{
			advanced = true;
		}
		else
		{
			advanced = false;
		}



		if(Input.GetButton("Forwards"))
		{
			CM.Forwards(grounded, advanced, currentForwardVelocity, holding, wallUp, wallRun, currentVerticalVelocity);
            if(wallUp)
            {
                wallUp = false;
            }
		}
		else if(Input.GetButton("Backwards"))
		{
			CM.Backwards(grounded, advanced, currentForwardVelocity);
		}
        else
        {
            CM.Idle(transform.forward, currentForwardVelocity);
        }
		if(Input.GetButton("Right"))
		{
			CM.Right(grounded, advanced, currentForwardVelocity);
		}
		else if(Input.GetButton("Left"))
		{
			CM.Left(grounded, advanced, currentForwardVelocity);
		}
        else
        {
            CM.Idle(transform.right, currentForwardVelocity);
        }



		if(Input.GetButtonDown("Jump"))
		{
			CM.Jump(grounded, advanced, currentVerticalVelocity);
		}
		if(Input.GetButton("Crouch"))
		{
			CM.Crouch(grounded, advanced, currentForwardVelocity);
		}
        if(Input.GetMouseButtonDown(0))
        {
            MI.MainAction();
        }
        if (Input.GetMouseButtonDown(1))
        {
            MI.Secondry();
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            MI.Scroll(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    void OnGUI()
    {
        if(!Physics.Raycast(Camera.current.ScreenPointToRay(Camera.current.transform.position), out hit, 20f))
        {
            hit = default(RaycastHit);
        }
        if (GUI.Button(new Rect(midScreen - (Screen.width / 12) - 40, Screen.height - 40f, 80f, 40f), toolbar[0].name))
        {
            CraftController.refference.SpawnCraft(toolbar[0], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 12) - 40, Screen.height - 40f, 80f, 40f), toolbar[1].name))
        {
            CraftController.refference.SpawnCraft(toolbar[1], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 5) - 40, Screen.height - 40f, 80f, 40f), toolbar[2].name))
        {
            CraftController.refference.SpawnCraft(toolbar[2], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 5) - 40, Screen.height - 40f, 80f, 40f), toolbar[3].name))
        {
            CraftController.refference.SpawnCraft(toolbar[3], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 3) - 40, Screen.height - 40f, 80f, 40f), toolbar[4].name))
        {
            CraftController.refference.SpawnCraft(toolbar[4], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 3) - 40, 0f, 80f, 40f), toolbar[5].name))
        {
            CraftController.refference.SpawnCraft(toolbar[5], hit.point, new Vector3(0f, Camera.current.transform.eulerAngles.y, 0f));
        }
    }
}
