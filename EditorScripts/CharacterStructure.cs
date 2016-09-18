using UnityEngine;
using System.Collections;

public class CharacterStructure : MonoBehaviour 
{
	public static CharacterStructure refference;
	Transform temp;

	void Start()
	{
		if(refference == null)
		{
			refference = this;
		}
		else
		{
			Destroy(this);
		}
		
		Load();
		//StartCoroutine(SetRefferences(transform));
	}
/*
	IEnumerator SetRefferences(Transform nextChild)
	{
		StartCoroutine(nextChild.name, nextChild);
		for(int count = 0; count < nextChild.childCount; count++)
		{
			StartCoroutine(SetRefferences(nextChild.GetChild(count)));
		}
		yield return null;
	}*/

	/*void Update()
	{
		if(Input.GetKeyDown("."))
		{
			Save();
		}
	}*/

	public void Save()
	{
		StartCoroutine(SaveLoop(transform));
	}
	
	IEnumerator SaveLoop(Transform nextChild)
	{
		Structures.Craft currentChar = new Structures.Craft();
		SaveLoad.saveLoad.SaveBone<Structures.Craft>(nextChild.name, CraftController.refference.StoreCraft(nextChild, nextChild.name));

		for(int count = 0; count < nextChild.childCount; count++)
		{
			StartCoroutine(SaveLoop(nextChild.GetChild(count)));
		}
		yield return null;
	}

	void Load()
	{
		StartCoroutine(LoadLoop(transform));
	}

	IEnumerator LoadLoop(Transform nextChild)
	{
		Structures.Craft currentChar = new Structures.Craft();
		SaveLoad.saveLoad.LoadBone<Structures.Craft>(nextChild.name,ref currentChar);
		
		yield return null;

		StartCoroutine(nextChild.name + "C", currentChar);
		for(int count = 0; count < nextChild.childCount; count++)   //spawn child bones
		{
			StartCoroutine(LoadLoop(nextChild.GetChild(count)));
		}
	}


    /*

        ALL CODE PAST THIS POINT WAS GENERATED USING ANOTHER SCRIPT

        THIS IS BECAUSE OF THE SHIER ABOUMOUT OF UNIQUE VARS THAT 
        ARE USED AND COULD NOT BE PAST THROUGH TO A SINGLE FUNCTION
        AS COROUTINES ONLY ALLOW ONE VAR TO BE PAST

        EACH BONE HAS TWO FUNCITON ASSINED TO IT SO AFTER LOOKING AT
        THE FIRST TWO THE REST IS JUST A COPY APPART FROM THE LAST 
        TWO PARAMATERS OF THE SPAWN BONE FUNCTION AND THE VAR 
        THAT IS ASSIGNED THE CURRENT TRANSFROM

    */
	public Transform MoverObj;

    #region Bone creation and assigning functions
    IEnumerator MoverC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, MoverObj.transform.position, MoverObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = MoverObj;
	}

	IEnumerator Mover(Transform current)
	{
		yield return null;
		MoverObj = current;
	}

	public Transform ControllerObj;

	IEnumerator ControllerC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, ControllerObj.transform.position, ControllerObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = ControllerObj;
	}

	IEnumerator Controller(Transform current)
	{
		yield return null;
		ControllerObj = current;
	}

	public Transform Foor_R_ControllerObj;

	IEnumerator Foor_R_ControllerC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Foor_R_ControllerObj.transform.position, Foor_R_ControllerObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Foor_R_ControllerObj;
	}

	IEnumerator Foor_R_Controller(Transform current)
	{
		yield return null;
		Foor_R_ControllerObj = current;
	}

	public Transform Foot_L_ControllerObj;

	IEnumerator Foot_L_ControllerC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Foot_L_ControllerObj.transform.position, Foot_L_ControllerObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Foot_L_ControllerObj;
	}

	IEnumerator Foot_L_Controller(Transform current)
	{
		yield return null;
		Foot_L_ControllerObj = current;
	}

	public Transform hand_L_ControlObj;

	IEnumerator hand_L_ControlC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_L_ControlObj.transform.position, hand_L_ControlObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_L_ControlObj;
	}

	IEnumerator hand_L_Control(Transform current)
	{
		yield return null;
		hand_L_ControlObj = current;
	}

	public Transform hand_L_Control_001Obj;

	IEnumerator hand_L_Control_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_L_Control_001Obj.transform.position, hand_L_Control_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_L_Control_001Obj;
	}

	IEnumerator hand_L_Control_001(Transform current)
	{
		yield return null;
		hand_L_Control_001Obj = current;
	}

	public Transform hand_L_Control_002Obj;

	IEnumerator hand_L_Control_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_L_Control_002Obj.transform.position, hand_L_Control_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_L_Control_002Obj;
	}

	IEnumerator hand_L_Control_002(Transform current)
	{
		yield return null;
		hand_L_Control_002Obj = current;
	}

	public Transform hand_R_ControlObj;

	IEnumerator hand_R_ControlC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_R_ControlObj.transform.position, hand_R_ControlObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_R_ControlObj;
	}

	IEnumerator hand_R_Control(Transform current)
	{
		yield return null;
		hand_R_ControlObj = current;
	}

	public Transform hand_R_Control_001Obj;

	IEnumerator hand_R_Control_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_R_Control_001Obj.transform.position, hand_R_Control_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_R_Control_001Obj;
	}

	IEnumerator hand_R_Control_001(Transform current)
	{
		yield return null;
		hand_R_Control_001Obj = current;
	}

	public Transform hand_R_Control_002Obj;

	IEnumerator hand_R_Control_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_R_Control_002Obj.transform.position, hand_R_Control_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_R_Control_002Obj;
	}

	IEnumerator hand_R_Control_002(Transform current)
	{
		yield return null;
		hand_R_Control_002Obj = current;
	}

	public Transform hips_001Obj;

	IEnumerator hips_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hips_001Obj.transform.position, hips_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hips_001Obj;
	}

	IEnumerator hips_001(Transform current)
	{
		yield return null;
		hips_001Obj = current;
	}

	public Transform Spine_ControlObj;

	IEnumerator Spine_ControlC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Spine_ControlObj.transform.position, Spine_ControlObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Spine_ControlObj;
	}

	IEnumerator Spine_Control(Transform current)
	{
		yield return null;
		Spine_ControlObj = current;
	}

	public Transform thigh_LObj;

	IEnumerator thigh_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thigh_LObj.transform.position, thigh_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thigh_LObj;
	}

	IEnumerator thigh_L(Transform current)
	{
		yield return null;
		thigh_LObj = current;
	}

	public Transform thigh_RObj;

	IEnumerator thigh_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thigh_RObj.transform.position, thigh_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thigh_RObj;
	}

	IEnumerator thigh_R(Transform current)
	{
		yield return null;
		thigh_RObj = current;
	}

	public Transform foot_RObj;

	IEnumerator foot_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, foot_RObj.transform.position, foot_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = foot_RObj;
	}

	IEnumerator foot_R(Transform current)
	{
		yield return null;
		foot_RObj = current;
	}

	public Transform foot_LObj;

	IEnumerator foot_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, foot_LObj.transform.position, foot_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = foot_LObj;
	}

	IEnumerator foot_L(Transform current)
	{
		yield return null;
		foot_LObj = current;
	}

	public Transform hand_LObj;

	IEnumerator hand_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_LObj.transform.position, hand_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_LObj;
	}

	IEnumerator hand_L(Transform current)
	{
		yield return null;
		hand_LObj = current;
	}

	public Transform hand_L_001Obj;

	IEnumerator hand_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_L_001Obj.transform.position, hand_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_L_001Obj;
	}

	IEnumerator hand_L_001(Transform current)
	{
		yield return null;
		hand_L_001Obj = current;
	}

	public Transform hand_L_002Obj;

	IEnumerator hand_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_L_002Obj.transform.position, hand_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_L_002Obj;
	}

	IEnumerator hand_L_002(Transform current)
	{
		yield return null;
		hand_L_002Obj = current;
	}

	public Transform hand_RObj;

	IEnumerator hand_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_RObj.transform.position, hand_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_RObj;
	}

	IEnumerator hand_R(Transform current)
	{
		yield return null;
		hand_RObj = current;
	}

	public Transform hand_R_001Obj;

	IEnumerator hand_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_R_001Obj.transform.position, hand_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_R_001Obj;
	}

	IEnumerator hand_R_001(Transform current)
	{
		yield return null;
		hand_R_001Obj = current;
	}

	public Transform hand_R_002Obj;

	IEnumerator hand_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, hand_R_002Obj.transform.position, hand_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = hand_R_002Obj;
	}

	IEnumerator hand_R_002(Transform current)
	{
		yield return null;
		hand_R_002Obj = current;
	}

	public Transform spineObj;

	IEnumerator spineC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, spineObj.transform.position, spineObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = spineObj;
	}

	IEnumerator spine(Transform current)
	{
		yield return null;
		spineObj = current;
	}

	public Transform TaileRootObj;

	IEnumerator TaileRootC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, TaileRootObj.transform.position, TaileRootObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = TaileRootObj;
	}

	IEnumerator TaileRoot(Transform current)
	{
		yield return null;
		TaileRootObj = current;
	}

	public Transform TaileRoot_001Obj;

	IEnumerator TaileRoot_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, TaileRoot_001Obj.transform.position, TaileRoot_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = TaileRoot_001Obj;
	}

	IEnumerator TaileRoot_001(Transform current)
	{
		yield return null;
		TaileRoot_001Obj = current;
	}

	public Transform TaileRoot_002Obj;

	IEnumerator TaileRoot_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, TaileRoot_002Obj.transform.position, TaileRoot_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = TaileRoot_002Obj;
	}

	IEnumerator TaileRoot_002(Transform current)
	{
		yield return null;
		TaileRoot_002Obj = current;
	}

	public Transform neckObj;

	IEnumerator neckC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, neckObj.transform.position, neckObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = neckObj;
	}

	IEnumerator neck(Transform current)
	{
		yield return null;
		neckObj = current;
	}

	public Transform shin_LObj;

	IEnumerator shin_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, shin_LObj.transform.position, shin_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = shin_LObj;
	}

	IEnumerator shin_L(Transform current)
	{
		yield return null;
		shin_LObj = current;
	}

	public Transform shin_RObj;

	IEnumerator shin_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, shin_RObj.transform.position, shin_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = shin_RObj;
	}

	IEnumerator shin_R(Transform current)
	{
		yield return null;
		shin_RObj = current;
	}

	public Transform toe_RObj;

	IEnumerator toe_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, toe_RObj.transform.position, toe_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = toe_RObj;
	}

	IEnumerator toe_R(Transform current)
	{
		yield return null;
		toe_RObj = current;
	}

	public Transform toe_LObj;

	IEnumerator toe_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, toe_LObj.transform.position, toe_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = toe_LObj;
	}

	IEnumerator toe_L(Transform current)
	{
		yield return null;
		toe_LObj = current;
	}

	public Transform f_index_01_LObj;

	IEnumerator f_index_01_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_LObj.transform.position, f_index_01_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_LObj;
	}

	IEnumerator f_index_01_L(Transform current)
	{
		yield return null;
		f_index_01_LObj = current;
	}

	public Transform f_middle_01_LObj;

	IEnumerator f_middle_01_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_LObj.transform.position, f_middle_01_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_LObj;
	}

	IEnumerator f_middle_01_L(Transform current)
	{
		yield return null;
		f_middle_01_LObj = current;
	}

	public Transform f_pinky_01_LObj;

	IEnumerator f_pinky_01_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_LObj.transform.position, f_pinky_01_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_LObj;
	}

	IEnumerator f_pinky_01_L(Transform current)
	{
		yield return null;
		f_pinky_01_LObj = current;
	}

	public Transform f_ring_01_LObj;

	IEnumerator f_ring_01_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_LObj.transform.position, f_ring_01_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_LObj;
	}

	IEnumerator f_ring_01_L(Transform current)
	{
		yield return null;
		f_ring_01_LObj = current;
	}

	public Transform thumb_01_LObj;

	IEnumerator thumb_01_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_LObj.transform.position, thumb_01_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_LObj;
	}

	IEnumerator thumb_01_L(Transform current)
	{
		yield return null;
		thumb_01_LObj = current;
	}

	public Transform f_index_01_L_001Obj;

	IEnumerator f_index_01_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_L_001Obj.transform.position, f_index_01_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_L_001Obj;
	}

	IEnumerator f_index_01_L_001(Transform current)
	{
		yield return null;
		f_index_01_L_001Obj = current;
	}

	public Transform f_middle_01_L_001Obj;

	IEnumerator f_middle_01_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_L_001Obj.transform.position, f_middle_01_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_L_001Obj;
	}

	IEnumerator f_middle_01_L_001(Transform current)
	{
		yield return null;
		f_middle_01_L_001Obj = current;
	}

	public Transform f_pinky_01_L_001Obj;

	IEnumerator f_pinky_01_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_L_001Obj.transform.position, f_pinky_01_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_L_001Obj;
	}

	IEnumerator f_pinky_01_L_001(Transform current)
	{
		yield return null;
		f_pinky_01_L_001Obj = current;
	}

	public Transform f_ring_01_L_001Obj;

	IEnumerator f_ring_01_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_L_001Obj.transform.position, f_ring_01_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_L_001Obj;
	}

	IEnumerator f_ring_01_L_001(Transform current)
	{
		yield return null;
		f_ring_01_L_001Obj = current;
	}

	public Transform thumb_01_L_001Obj;

	IEnumerator thumb_01_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_L_001Obj.transform.position, thumb_01_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_L_001Obj;
	}

	IEnumerator thumb_01_L_001(Transform current)
	{
		yield return null;
		thumb_01_L_001Obj = current;
	}

	public Transform f_index_01_L_002Obj;

	IEnumerator f_index_01_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_L_002Obj.transform.position, f_index_01_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_L_002Obj;
	}

	IEnumerator f_index_01_L_002(Transform current)
	{
		yield return null;
		f_index_01_L_002Obj = current;
	}

	public Transform f_middle_01_L_002Obj;

	IEnumerator f_middle_01_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_L_002Obj.transform.position, f_middle_01_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_L_002Obj;
	}

	IEnumerator f_middle_01_L_002(Transform current)
	{
		yield return null;
		f_middle_01_L_002Obj = current;
	}

	public Transform f_pinky_01_L_002Obj;

	IEnumerator f_pinky_01_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_L_002Obj.transform.position, f_pinky_01_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_L_002Obj;
	}

	IEnumerator f_pinky_01_L_002(Transform current)
	{
		yield return null;
		f_pinky_01_L_002Obj = current;
	}

	public Transform f_ring_01_L_002Obj;

	IEnumerator f_ring_01_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_L_002Obj.transform.position, f_ring_01_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_L_002Obj;
	}

	IEnumerator f_ring_01_L_002(Transform current)
	{
		yield return null;
		f_ring_01_L_002Obj = current;
	}

	public Transform thumb_01_L_002Obj;

	IEnumerator thumb_01_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_L_002Obj.transform.position, thumb_01_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_L_002Obj;
	}

	IEnumerator thumb_01_L_002(Transform current)
	{
		yield return null;
		thumb_01_L_002Obj = current;
	}

	public Transform f_index_01_RObj;

	IEnumerator f_index_01_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_RObj.transform.position, f_index_01_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_RObj;
	}

	IEnumerator f_index_01_R(Transform current)
	{
		yield return null;
		f_index_01_RObj = current;
	}

	public Transform f_middle_01_RObj;

	IEnumerator f_middle_01_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_RObj.transform.position, f_middle_01_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_RObj;
	}

	IEnumerator f_middle_01_R(Transform current)
	{
		yield return null;
		f_middle_01_RObj = current;
	}

	public Transform f_pinky_01_RObj;

	IEnumerator f_pinky_01_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_RObj.transform.position, f_pinky_01_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_RObj;
	}

	IEnumerator f_pinky_01_R(Transform current)
	{
		yield return null;
		f_pinky_01_RObj = current;
	}

	public Transform f_ring_01_RObj;

	IEnumerator f_ring_01_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_RObj.transform.position, f_ring_01_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_RObj;
	}

	IEnumerator f_ring_01_R(Transform current)
	{
		yield return null;
		f_ring_01_RObj = current;
	}

	public Transform thumb_01_RObj;

	IEnumerator thumb_01_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_RObj.transform.position, thumb_01_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_RObj;
	}

	IEnumerator thumb_01_R(Transform current)
	{
		yield return null;
		thumb_01_RObj = current;
	}

	public Transform f_index_01_R_001Obj;

	IEnumerator f_index_01_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_R_001Obj.transform.position, f_index_01_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_R_001Obj;
	}

	IEnumerator f_index_01_R_001(Transform current)
	{
		yield return null;
		f_index_01_R_001Obj = current;
	}

	public Transform f_middle_01_R_001Obj;

	IEnumerator f_middle_01_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_R_001Obj.transform.position, f_middle_01_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_R_001Obj;
	}

	IEnumerator f_middle_01_R_001(Transform current)
	{
		yield return null;
		f_middle_01_R_001Obj = current;
	}

	public Transform f_pinky_01_R_001Obj;

	IEnumerator f_pinky_01_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_R_001Obj.transform.position, f_pinky_01_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_R_001Obj;
	}

	IEnumerator f_pinky_01_R_001(Transform current)
	{
		yield return null;
		f_pinky_01_R_001Obj = current;
	}

	public Transform f_ring_01_R_001Obj;

	IEnumerator f_ring_01_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_R_001Obj.transform.position, f_ring_01_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_R_001Obj;
	}

	IEnumerator f_ring_01_R_001(Transform current)
	{
		yield return null;
		f_ring_01_R_001Obj = current;
	}

	public Transform thumb_01_R_001Obj;

	IEnumerator thumb_01_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_R_001Obj.transform.position, thumb_01_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_R_001Obj;
	}

	IEnumerator thumb_01_R_001(Transform current)
	{
		yield return null;
		thumb_01_R_001Obj = current;
	}

	public Transform f_index_01_R_002Obj;

	IEnumerator f_index_01_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_01_R_002Obj.transform.position, f_index_01_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_01_R_002Obj;
	}

	IEnumerator f_index_01_R_002(Transform current)
	{
		yield return null;
		f_index_01_R_002Obj = current;
	}

	public Transform f_middle_01_R_002Obj;

	IEnumerator f_middle_01_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_01_R_002Obj.transform.position, f_middle_01_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_01_R_002Obj;
	}

	IEnumerator f_middle_01_R_002(Transform current)
	{
		yield return null;
		f_middle_01_R_002Obj = current;
	}

	public Transform f_pinky_01_R_002Obj;

	IEnumerator f_pinky_01_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_01_R_002Obj.transform.position, f_pinky_01_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_01_R_002Obj;
	}

	IEnumerator f_pinky_01_R_002(Transform current)
	{
		yield return null;
		f_pinky_01_R_002Obj = current;
	}

	public Transform f_ring_01_R_002Obj;

	IEnumerator f_ring_01_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_01_R_002Obj.transform.position, f_ring_01_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_01_R_002Obj;
	}

	IEnumerator f_ring_01_R_002(Transform current)
	{
		yield return null;
		f_ring_01_R_002Obj = current;
	}

	public Transform thumb_01_R_002Obj;

	IEnumerator thumb_01_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_01_R_002Obj.transform.position, thumb_01_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_01_R_002Obj;
	}

	IEnumerator thumb_01_R_002(Transform current)
	{
		yield return null;
		thumb_01_R_002Obj = current;
	}

	public Transform spine_001Obj;

	IEnumerator spine_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, spine_001Obj.transform.position, spine_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = spine_001Obj;
	}

	IEnumerator spine_001(Transform current)
	{
		yield return null;
		spine_001Obj = current;
	}

	public Transform WingBaceBot_LObj;

	IEnumerator WingBaceBot_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceBot_LObj.transform.position, WingBaceBot_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceBot_LObj;
	}

	IEnumerator WingBaceBot_L(Transform current)
	{
		yield return null;
		WingBaceBot_LObj = current;
	}

	public Transform WingBaceBot_RObj;

	IEnumerator WingBaceBot_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceBot_RObj.transform.position, WingBaceBot_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceBot_RObj;
	}

	IEnumerator WingBaceBot_R(Transform current)
	{
		yield return null;
		WingBaceBot_RObj = current;
	}

	public Transform Tail_1Obj;

	IEnumerator Tail_1C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_1Obj.transform.position, Tail_1Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_1Obj;
	}

	IEnumerator Tail_1(Transform current)
	{
		yield return null;
		Tail_1Obj = current;
	}

	public Transform Tail_2Obj;

	IEnumerator Tail_2C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_2Obj.transform.position, Tail_2Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_2Obj;
	}

	IEnumerator Tail_2(Transform current)
	{
		yield return null;
		Tail_2Obj = current;
	}

	public Transform Tail_002Obj;

	IEnumerator Tail_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_002Obj.transform.position, Tail_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_002Obj;
	}

	IEnumerator Tail_002(Transform current)
	{
		yield return null;
		Tail_002Obj = current;
	}

	public Transform Tail_003Obj;

	IEnumerator Tail_003C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_003Obj.transform.position, Tail_003Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_003Obj;
	}

	IEnumerator Tail_003(Transform current)
	{
		yield return null;
		Tail_003Obj = current;
	}

	public Transform Tail_016Obj;

	IEnumerator Tail_016C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_016Obj.transform.position, Tail_016Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_016Obj;
	}

	IEnumerator Tail_016(Transform current)
	{
		yield return null;
		Tail_016Obj = current;
	}

	public Transform Tail_017Obj;

	IEnumerator Tail_017C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_017Obj.transform.position, Tail_017Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_017Obj;
	}

	IEnumerator Tail_017(Transform current)
	{
		yield return null;
		Tail_017Obj = current;
	}

	public Transform neck_001_L_001Obj;

	IEnumerator neck_001_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, neck_001_L_001Obj.transform.position, neck_001_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = neck_001_L_001Obj;
	}

	IEnumerator neck_001_L_001(Transform current)
	{
		yield return null;
		neck_001_L_001Obj = current;
	}

	public Transform neck_001_R_001Obj;

	IEnumerator neck_001_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, neck_001_R_001Obj.transform.position, neck_001_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = neck_001_R_001Obj;
	}

	IEnumerator neck_001_R_001(Transform current)
	{
		yield return null;
		neck_001_R_001Obj = current;
	}

	public Transform f_index_02_LObj;

	IEnumerator f_index_02_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_LObj.transform.position, f_index_02_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_LObj;
	}

	IEnumerator f_index_02_L(Transform current)
	{
		yield return null;
		f_index_02_LObj = current;
	}

	public Transform f_middle_02_LObj;

	IEnumerator f_middle_02_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_LObj.transform.position, f_middle_02_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_LObj;
	}

	IEnumerator f_middle_02_L(Transform current)
	{
		yield return null;
		f_middle_02_LObj = current;
	}

	public Transform f_pinky_02_LObj;

	IEnumerator f_pinky_02_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_LObj.transform.position, f_pinky_02_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_LObj;
	}

	IEnumerator f_pinky_02_L(Transform current)
	{
		yield return null;
		f_pinky_02_LObj = current;
	}

	public Transform f_ring_02_LObj;

	IEnumerator f_ring_02_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_LObj.transform.position, f_ring_02_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_LObj;
	}

	IEnumerator f_ring_02_L(Transform current)
	{
		yield return null;
		f_ring_02_LObj = current;
	}

	public Transform thumb_02_LObj;

	IEnumerator thumb_02_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_LObj.transform.position, thumb_02_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_LObj;
	}

	IEnumerator thumb_02_L(Transform current)
	{
		yield return null;
		thumb_02_LObj = current;
	}

	public Transform f_index_02_L_001Obj;

	IEnumerator f_index_02_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_L_001Obj.transform.position, f_index_02_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_L_001Obj;
	}

	IEnumerator f_index_02_L_001(Transform current)
	{
		yield return null;
		f_index_02_L_001Obj = current;
	}

	public Transform f_middle_02_L_001Obj;

	IEnumerator f_middle_02_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_L_001Obj.transform.position, f_middle_02_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_L_001Obj;
	}

	IEnumerator f_middle_02_L_001(Transform current)
	{
		yield return null;
		f_middle_02_L_001Obj = current;
	}

	public Transform f_pinky_02_L_001Obj;

	IEnumerator f_pinky_02_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_L_001Obj.transform.position, f_pinky_02_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_L_001Obj;
	}

	IEnumerator f_pinky_02_L_001(Transform current)
	{
		yield return null;
		f_pinky_02_L_001Obj = current;
	}

	public Transform f_ring_02_L_001Obj;

	IEnumerator f_ring_02_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_L_001Obj.transform.position, f_ring_02_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_L_001Obj;
	}

	IEnumerator f_ring_02_L_001(Transform current)
	{
		yield return null;
		f_ring_02_L_001Obj = current;
	}

	public Transform thumb_02_L_001Obj;

	IEnumerator thumb_02_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_L_001Obj.transform.position, thumb_02_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_L_001Obj;
	}

	IEnumerator thumb_02_L_001(Transform current)
	{
		yield return null;
		thumb_02_L_001Obj = current;
	}

	public Transform f_index_02_L_002Obj;

	IEnumerator f_index_02_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_L_002Obj.transform.position, f_index_02_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_L_002Obj;
	}

	IEnumerator f_index_02_L_002(Transform current)
	{
		yield return null;
		f_index_02_L_002Obj = current;
	}

	public Transform f_middle_02_L_002Obj;

	IEnumerator f_middle_02_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_L_002Obj.transform.position, f_middle_02_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_L_002Obj;
	}

	IEnumerator f_middle_02_L_002(Transform current)
	{
		yield return null;
		f_middle_02_L_002Obj = current;
	}

	public Transform f_pinky_02_L_002Obj;

	IEnumerator f_pinky_02_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_L_002Obj.transform.position, f_pinky_02_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_L_002Obj;
	}

	IEnumerator f_pinky_02_L_002(Transform current)
	{
		yield return null;
		f_pinky_02_L_002Obj = current;
	}

	public Transform f_ring_02_L_002Obj;

	IEnumerator f_ring_02_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_L_002Obj.transform.position, f_ring_02_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_L_002Obj;
	}

	IEnumerator f_ring_02_L_002(Transform current)
	{
		yield return null;
		f_ring_02_L_002Obj = current;
	}

	public Transform thumb_02_L_002Obj;

	IEnumerator thumb_02_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_L_002Obj.transform.position, thumb_02_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_L_002Obj;
	}

	IEnumerator thumb_02_L_002(Transform current)
	{
		yield return null;
		thumb_02_L_002Obj = current;
	}

	public Transform f_index_02_RObj;

	IEnumerator f_index_02_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_RObj.transform.position, f_index_02_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_RObj;
	}

	IEnumerator f_index_02_R(Transform current)
	{
		yield return null;
		f_index_02_RObj = current;
	}

	public Transform f_middle_02_RObj;

	IEnumerator f_middle_02_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_RObj.transform.position, f_middle_02_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_RObj;
	}

	IEnumerator f_middle_02_R(Transform current)
	{
		yield return null;
		f_middle_02_RObj = current;
	}

	public Transform f_pinky_02_RObj;

	IEnumerator f_pinky_02_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_RObj.transform.position, f_pinky_02_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_RObj;
	}

	IEnumerator f_pinky_02_R(Transform current)
	{
		yield return null;
		f_pinky_02_RObj = current;
	}

	public Transform f_ring_02_RObj;

	IEnumerator f_ring_02_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_RObj.transform.position, f_ring_02_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_RObj;
	}

	IEnumerator f_ring_02_R(Transform current)
	{
		yield return null;
		f_ring_02_RObj = current;
	}

	public Transform thumb_02_RObj;

	IEnumerator thumb_02_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_RObj.transform.position, thumb_02_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_RObj;
	}

	IEnumerator thumb_02_R(Transform current)
	{
		yield return null;
		thumb_02_RObj = current;
	}

	public Transform f_index_02_R_001Obj;

	IEnumerator f_index_02_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_R_001Obj.transform.position, f_index_02_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_R_001Obj;
	}

	IEnumerator f_index_02_R_001(Transform current)
	{
		yield return null;
		f_index_02_R_001Obj = current;
	}

	public Transform f_middle_02_R_001Obj;

	IEnumerator f_middle_02_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_R_001Obj.transform.position, f_middle_02_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_R_001Obj;
	}

	IEnumerator f_middle_02_R_001(Transform current)
	{
		yield return null;
		f_middle_02_R_001Obj = current;
	}

	public Transform f_pinky_02_R_001Obj;

	IEnumerator f_pinky_02_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_R_001Obj.transform.position, f_pinky_02_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_R_001Obj;
	}

	IEnumerator f_pinky_02_R_001(Transform current)
	{
		yield return null;
		f_pinky_02_R_001Obj = current;
	}

	public Transform f_ring_02_R_001Obj;

	IEnumerator f_ring_02_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_R_001Obj.transform.position, f_ring_02_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_R_001Obj;
	}

	IEnumerator f_ring_02_R_001(Transform current)
	{
		yield return null;
		f_ring_02_R_001Obj = current;
	}

	public Transform thumb_02_R_001Obj;

	IEnumerator thumb_02_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_R_001Obj.transform.position, thumb_02_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_R_001Obj;
	}

	IEnumerator thumb_02_R_001(Transform current)
	{
		yield return null;
		thumb_02_R_001Obj = current;
	}

	public Transform f_index_02_R_002Obj;

	IEnumerator f_index_02_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_02_R_002Obj.transform.position, f_index_02_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_02_R_002Obj;
	}

	IEnumerator f_index_02_R_002(Transform current)
	{
		yield return null;
		f_index_02_R_002Obj = current;
	}

	public Transform f_middle_02_R_002Obj;

	IEnumerator f_middle_02_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_02_R_002Obj.transform.position, f_middle_02_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_02_R_002Obj;
	}

	IEnumerator f_middle_02_R_002(Transform current)
	{
		yield return null;
		f_middle_02_R_002Obj = current;
	}

	public Transform f_pinky_02_R_002Obj;

	IEnumerator f_pinky_02_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_02_R_002Obj.transform.position, f_pinky_02_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_02_R_002Obj;
	}

	IEnumerator f_pinky_02_R_002(Transform current)
	{
		yield return null;
		f_pinky_02_R_002Obj = current;
	}

	public Transform f_ring_02_R_002Obj;

	IEnumerator f_ring_02_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_02_R_002Obj.transform.position, f_ring_02_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_02_R_002Obj;
	}

	IEnumerator f_ring_02_R_002(Transform current)
	{
		yield return null;
		f_ring_02_R_002Obj = current;
	}

	public Transform thumb_02_R_002Obj;

	IEnumerator thumb_02_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_02_R_002Obj.transform.position, thumb_02_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_02_R_002Obj;
	}

	IEnumerator thumb_02_R_002(Transform current)
	{
		yield return null;
		thumb_02_R_002Obj = current;
	}

	public Transform chestObj;

	IEnumerator chestC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chestObj.transform.position, chestObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chestObj;
	}

	IEnumerator chest(Transform current)
	{
		yield return null;
		chestObj = current;
	}

	public Transform upper_arm_L_002Obj;

	IEnumerator upper_arm_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_L_002Obj.transform.position, upper_arm_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_L_002Obj;
	}

	IEnumerator upper_arm_L_002(Transform current)
	{
		yield return null;
		upper_arm_L_002Obj = current;
	}

	public Transform upper_arm_R_002Obj;

	IEnumerator upper_arm_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_R_002Obj.transform.position, upper_arm_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_R_002Obj;
	}

	IEnumerator upper_arm_R_002(Transform current)
	{
		yield return null;
		upper_arm_R_002Obj = current;
	}

	public Transform chest1_L_011Obj;

	IEnumerator chest1_L_011C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_011Obj.transform.position, chest1_L_011Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_011Obj;
	}

	IEnumerator chest1_L_011(Transform current)
	{
		yield return null;
		chest1_L_011Obj = current;
	}

	public Transform chest1_L_012Obj;

	IEnumerator chest1_L_012C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_012Obj.transform.position, chest1_L_012Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_012Obj;
	}

	IEnumerator chest1_L_012(Transform current)
	{
		yield return null;
		chest1_L_012Obj = current;
	}

	public Transform chest1_L_013Obj;

	IEnumerator chest1_L_013C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_013Obj.transform.position, chest1_L_013Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_013Obj;
	}

	IEnumerator chest1_L_013(Transform current)
	{
		yield return null;
		chest1_L_013Obj = current;
	}

	public Transform chest1_L_014Obj;

	IEnumerator chest1_L_014C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_014Obj.transform.position, chest1_L_014Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_014Obj;
	}

	IEnumerator chest1_L_014(Transform current)
	{
		yield return null;
		chest1_L_014Obj = current;
	}

	public Transform chest1_R_011Obj;

	IEnumerator chest1_R_011C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_011Obj.transform.position, chest1_R_011Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_011Obj;
	}

	IEnumerator chest1_R_011(Transform current)
	{
		yield return null;
		chest1_R_011Obj = current;
	}

	public Transform chest1_R_012Obj;

	IEnumerator chest1_R_012C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_012Obj.transform.position, chest1_R_012Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_012Obj;
	}

	IEnumerator chest1_R_012(Transform current)
	{
		yield return null;
		chest1_R_012Obj = current;
	}

	public Transform chest1_R_013Obj;

	IEnumerator chest1_R_013C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_013Obj.transform.position, chest1_R_013Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_013Obj;
	}

	IEnumerator chest1_R_013(Transform current)
	{
		yield return null;
		chest1_R_013Obj = current;
	}

	public Transform chest1_R_014Obj;

	IEnumerator chest1_R_014C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_014Obj.transform.position, chest1_R_014Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_014Obj;
	}

	IEnumerator chest1_R_014(Transform current)
	{
		yield return null;
		chest1_R_014Obj = current;
	}

	public Transform Tail_3Obj;

	IEnumerator Tail_3C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_3Obj.transform.position, Tail_3Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_3Obj;
	}

	IEnumerator Tail_3(Transform current)
	{
		yield return null;
		Tail_3Obj = current;
	}

	public Transform Tail_5Obj;

	IEnumerator Tail_5C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_5Obj.transform.position, Tail_5Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_5Obj;
	}

	IEnumerator Tail_5(Transform current)
	{
		yield return null;
		Tail_5Obj = current;
	}

	public Transform Tail_004Obj;

	IEnumerator Tail_004C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_004Obj.transform.position, Tail_004Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_004Obj;
	}

	IEnumerator Tail_004(Transform current)
	{
		yield return null;
		Tail_004Obj = current;
	}

	public Transform Tail_006Obj;

	IEnumerator Tail_006C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_006Obj.transform.position, Tail_006Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_006Obj;
	}

	IEnumerator Tail_006(Transform current)
	{
		yield return null;
		Tail_006Obj = current;
	}

	public Transform Tail_018Obj;

	IEnumerator Tail_018C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_018Obj.transform.position, Tail_018Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_018Obj;
	}

	IEnumerator Tail_018(Transform current)
	{
		yield return null;
		Tail_018Obj = current;
	}

	public Transform Tail_020Obj;

	IEnumerator Tail_020C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_020Obj.transform.position, Tail_020Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_020Obj;
	}

	IEnumerator Tail_020(Transform current)
	{
		yield return null;
		Tail_020Obj = current;
	}

	public Transform f_index_03_LObj;

	IEnumerator f_index_03_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_LObj.transform.position, f_index_03_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_LObj;
	}

	IEnumerator f_index_03_L(Transform current)
	{
		yield return null;
		f_index_03_LObj = current;
	}

	public Transform f_middle_03_LObj;

	IEnumerator f_middle_03_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_LObj.transform.position, f_middle_03_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_LObj;
	}

	IEnumerator f_middle_03_L(Transform current)
	{
		yield return null;
		f_middle_03_LObj = current;
	}

	public Transform f_pinky_03_LObj;

	IEnumerator f_pinky_03_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_LObj.transform.position, f_pinky_03_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_LObj;
	}

	IEnumerator f_pinky_03_L(Transform current)
	{
		yield return null;
		f_pinky_03_LObj = current;
	}

	public Transform f_ring_03_LObj;

	IEnumerator f_ring_03_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_LObj.transform.position, f_ring_03_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_LObj;
	}

	IEnumerator f_ring_03_L(Transform current)
	{
		yield return null;
		f_ring_03_LObj = current;
	}

	public Transform thumb_03_LObj;

	IEnumerator thumb_03_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_LObj.transform.position, thumb_03_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_LObj;
	}

	IEnumerator thumb_03_L(Transform current)
	{
		yield return null;
		thumb_03_LObj = current;
	}

	public Transform f_index_03_L_001Obj;

	IEnumerator f_index_03_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_L_001Obj.transform.position, f_index_03_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_L_001Obj;
	}

	IEnumerator f_index_03_L_001(Transform current)
	{
		yield return null;
		f_index_03_L_001Obj = current;
	}

	public Transform f_middle_03_L_001Obj;

	IEnumerator f_middle_03_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_L_001Obj.transform.position, f_middle_03_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_L_001Obj;
	}

	IEnumerator f_middle_03_L_001(Transform current)
	{
		yield return null;
		f_middle_03_L_001Obj = current;
	}

	public Transform f_pinky_03_L_001Obj;

	IEnumerator f_pinky_03_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_L_001Obj.transform.position, f_pinky_03_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_L_001Obj;
	}

	IEnumerator f_pinky_03_L_001(Transform current)
	{
		yield return null;
		f_pinky_03_L_001Obj = current;
	}

	public Transform f_ring_03_L_001Obj;

	IEnumerator f_ring_03_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_L_001Obj.transform.position, f_ring_03_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_L_001Obj;
	}

	IEnumerator f_ring_03_L_001(Transform current)
	{
		yield return null;
		f_ring_03_L_001Obj = current;
	}

	public Transform thumb_03_L_001Obj;

	IEnumerator thumb_03_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_L_001Obj.transform.position, thumb_03_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_L_001Obj;
	}

	IEnumerator thumb_03_L_001(Transform current)
	{
		yield return null;
		thumb_03_L_001Obj = current;
	}

	public Transform f_index_03_L_002Obj;

	IEnumerator f_index_03_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_L_002Obj.transform.position, f_index_03_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_L_002Obj;
	}

	IEnumerator f_index_03_L_002(Transform current)
	{
		yield return null;
		f_index_03_L_002Obj = current;
	}

	public Transform f_middle_03_L_002Obj;

	IEnumerator f_middle_03_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_L_002Obj.transform.position, f_middle_03_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_L_002Obj;
	}

	IEnumerator f_middle_03_L_002(Transform current)
	{
		yield return null;
		f_middle_03_L_002Obj = current;
	}

	public Transform f_pinky_03_L_002Obj;

	IEnumerator f_pinky_03_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_L_002Obj.transform.position, f_pinky_03_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_L_002Obj;
	}

	IEnumerator f_pinky_03_L_002(Transform current)
	{
		yield return null;
		f_pinky_03_L_002Obj = current;
	}

	public Transform f_ring_03_L_002Obj;

	IEnumerator f_ring_03_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_L_002Obj.transform.position, f_ring_03_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_L_002Obj;
	}

	IEnumerator f_ring_03_L_002(Transform current)
	{
		yield return null;
		f_ring_03_L_002Obj = current;
	}

	public Transform thumb_03_L_002Obj;

	IEnumerator thumb_03_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_L_002Obj.transform.position, thumb_03_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_L_002Obj;
	}

	IEnumerator thumb_03_L_002(Transform current)
	{
		yield return null;
		thumb_03_L_002Obj = current;
	}

	public Transform f_index_03_RObj;

	IEnumerator f_index_03_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_RObj.transform.position, f_index_03_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_RObj;
	}

	IEnumerator f_index_03_R(Transform current)
	{
		yield return null;
		f_index_03_RObj = current;
	}

	public Transform f_middle_03_RObj;

	IEnumerator f_middle_03_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_RObj.transform.position, f_middle_03_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_RObj;
	}

	IEnumerator f_middle_03_R(Transform current)
	{
		yield return null;
		f_middle_03_RObj = current;
	}

	public Transform f_pinky_03_RObj;

	IEnumerator f_pinky_03_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_RObj.transform.position, f_pinky_03_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_RObj;
	}

	IEnumerator f_pinky_03_R(Transform current)
	{
		yield return null;
		f_pinky_03_RObj = current;
	}

	public Transform f_ring_03_RObj;

	IEnumerator f_ring_03_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_RObj.transform.position, f_ring_03_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_RObj;
	}

	IEnumerator f_ring_03_R(Transform current)
	{
		yield return null;
		f_ring_03_RObj = current;
	}

	public Transform thumb_03_RObj;

	IEnumerator thumb_03_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_RObj.transform.position, thumb_03_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_RObj;
	}

	IEnumerator thumb_03_R(Transform current)
	{
		yield return null;
		thumb_03_RObj = current;
	}

	public Transform f_index_03_R_001Obj;

	IEnumerator f_index_03_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_R_001Obj.transform.position, f_index_03_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_R_001Obj;
	}

	IEnumerator f_index_03_R_001(Transform current)
	{
		yield return null;
		f_index_03_R_001Obj = current;
	}

	public Transform f_middle_03_R_001Obj;

	IEnumerator f_middle_03_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_R_001Obj.transform.position, f_middle_03_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_R_001Obj;
	}

	IEnumerator f_middle_03_R_001(Transform current)
	{
		yield return null;
		f_middle_03_R_001Obj = current;
	}

	public Transform f_pinky_03_R_001Obj;

	IEnumerator f_pinky_03_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_R_001Obj.transform.position, f_pinky_03_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_R_001Obj;
	}

	IEnumerator f_pinky_03_R_001(Transform current)
	{
		yield return null;
		f_pinky_03_R_001Obj = current;
	}

	public Transform f_ring_03_R_001Obj;

	IEnumerator f_ring_03_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_R_001Obj.transform.position, f_ring_03_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_R_001Obj;
	}

	IEnumerator f_ring_03_R_001(Transform current)
	{
		yield return null;
		f_ring_03_R_001Obj = current;
	}

	public Transform thumb_03_R_001Obj;

	IEnumerator thumb_03_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_R_001Obj.transform.position, thumb_03_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_R_001Obj;
	}

	IEnumerator thumb_03_R_001(Transform current)
	{
		yield return null;
		thumb_03_R_001Obj = current;
	}

	public Transform f_index_03_R_002Obj;

	IEnumerator f_index_03_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_index_03_R_002Obj.transform.position, f_index_03_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_index_03_R_002Obj;
	}

	IEnumerator f_index_03_R_002(Transform current)
	{
		yield return null;
		f_index_03_R_002Obj = current;
	}

	public Transform f_middle_03_R_002Obj;

	IEnumerator f_middle_03_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_middle_03_R_002Obj.transform.position, f_middle_03_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_middle_03_R_002Obj;
	}

	IEnumerator f_middle_03_R_002(Transform current)
	{
		yield return null;
		f_middle_03_R_002Obj = current;
	}

	public Transform f_pinky_03_R_002Obj;

	IEnumerator f_pinky_03_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_pinky_03_R_002Obj.transform.position, f_pinky_03_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_pinky_03_R_002Obj;
	}

	IEnumerator f_pinky_03_R_002(Transform current)
	{
		yield return null;
		f_pinky_03_R_002Obj = current;
	}

	public Transform f_ring_03_R_002Obj;

	IEnumerator f_ring_03_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, f_ring_03_R_002Obj.transform.position, f_ring_03_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = f_ring_03_R_002Obj;
	}

	IEnumerator f_ring_03_R_002(Transform current)
	{
		yield return null;
		f_ring_03_R_002Obj = current;
	}

	public Transform thumb_03_R_002Obj;

	IEnumerator thumb_03_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, thumb_03_R_002Obj.transform.position, thumb_03_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = thumb_03_R_002Obj;
	}

	IEnumerator thumb_03_R_002(Transform current)
	{
		yield return null;
		thumb_03_R_002Obj = current;
	}

	public Transform chest1Obj;

	IEnumerator chest1C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1Obj.transform.position, chest1Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1Obj;
	}

	IEnumerator chest1(Transform current)
	{
		yield return null;
		chest1Obj = current;
	}

	public Transform upper_arm_L_001Obj;

	IEnumerator upper_arm_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_L_001Obj.transform.position, upper_arm_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_L_001Obj;
	}

	IEnumerator upper_arm_L_001(Transform current)
	{
		yield return null;
		upper_arm_L_001Obj = current;
	}

	public Transform upper_arm_R_001Obj;

	IEnumerator upper_arm_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_R_001Obj.transform.position, upper_arm_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_R_001Obj;
	}

	IEnumerator upper_arm_R_001(Transform current)
	{
		yield return null;
		upper_arm_R_001Obj = current;
	}

	public Transform WingBaceMid_LObj;

	IEnumerator WingBaceMid_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceMid_LObj.transform.position, WingBaceMid_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceMid_LObj;
	}

	IEnumerator WingBaceMid_L(Transform current)
	{
		yield return null;
		WingBaceMid_LObj = current;
	}

	public Transform WingBaceMid_RObj;

	IEnumerator WingBaceMid_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceMid_RObj.transform.position, WingBaceMid_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceMid_RObj;
	}

	IEnumerator WingBaceMid_R(Transform current)
	{
		yield return null;
		WingBaceMid_RObj = current;
	}

	public Transform forearm_L_002Obj;

	IEnumerator forearm_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_L_002Obj.transform.position, forearm_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_L_002Obj;
	}

	IEnumerator forearm_L_002(Transform current)
	{
		yield return null;
		forearm_L_002Obj = current;
	}

	public Transform forearm_R_002Obj;

	IEnumerator forearm_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_R_002Obj.transform.position, forearm_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_R_002Obj;
	}

	IEnumerator forearm_R_002(Transform current)
	{
		yield return null;
		forearm_R_002Obj = current;
	}

	public Transform Tail_4Obj;

	IEnumerator Tail_4C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_4Obj.transform.position, Tail_4Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_4Obj;
	}

	IEnumerator Tail_4(Transform current)
	{
		yield return null;
		Tail_4Obj = current;
	}

	public Transform Tail_6Obj;

	IEnumerator Tail_6C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_6Obj.transform.position, Tail_6Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_6Obj;
	}

	IEnumerator Tail_6(Transform current)
	{
		yield return null;
		Tail_6Obj = current;
	}

	public Transform Tail_9Obj;

	IEnumerator Tail_9C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_9Obj.transform.position, Tail_9Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_9Obj;
	}

	IEnumerator Tail_9(Transform current)
	{
		yield return null;
		Tail_9Obj = current;
	}

	public Transform Tail_005Obj;

	IEnumerator Tail_005C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_005Obj.transform.position, Tail_005Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_005Obj;
	}

	IEnumerator Tail_005(Transform current)
	{
		yield return null;
		Tail_005Obj = current;
	}

	public Transform Tail_007Obj;

	IEnumerator Tail_007C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_007Obj.transform.position, Tail_007Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_007Obj;
	}

	IEnumerator Tail_007(Transform current)
	{
		yield return null;
		Tail_007Obj = current;
	}

	public Transform Tail_010Obj;

	IEnumerator Tail_010C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_010Obj.transform.position, Tail_010Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_010Obj;
	}

	IEnumerator Tail_010(Transform current)
	{
		yield return null;
		Tail_010Obj = current;
	}

	public Transform Tail_019Obj;

	IEnumerator Tail_019C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_019Obj.transform.position, Tail_019Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_019Obj;
	}

	IEnumerator Tail_019(Transform current)
	{
		yield return null;
		Tail_019Obj = current;
	}

	public Transform Tail_021Obj;

	IEnumerator Tail_021C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_021Obj.transform.position, Tail_021Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_021Obj;
	}

	IEnumerator Tail_021(Transform current)
	{
		yield return null;
		Tail_021Obj = current;
	}

	public Transform Tail_024Obj;

	IEnumerator Tail_024C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_024Obj.transform.position, Tail_024Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_024Obj;
	}

	IEnumerator Tail_024(Transform current)
	{
		yield return null;
		Tail_024Obj = current;
	}

	public Transform upper_arm_LObj;

	IEnumerator upper_arm_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_LObj.transform.position, upper_arm_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_LObj;
	}

	IEnumerator upper_arm_L(Transform current)
	{
		yield return null;
		upper_arm_LObj = current;
	}

	public Transform upper_arm_RObj;

	IEnumerator upper_arm_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, upper_arm_RObj.transform.position, upper_arm_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = upper_arm_RObj;
	}

	IEnumerator upper_arm_R(Transform current)
	{
		yield return null;
		upper_arm_RObj = current;
	}

	public Transform WingBaceTop_LObj;

	IEnumerator WingBaceTop_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceTop_LObj.transform.position, WingBaceTop_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceTop_LObj;
	}

	IEnumerator WingBaceTop_L(Transform current)
	{
		yield return null;
		WingBaceTop_LObj = current;
	}

	public Transform WingBaceTop_RObj;

	IEnumerator WingBaceTop_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, WingBaceTop_RObj.transform.position, WingBaceTop_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = WingBaceTop_RObj;
	}

	IEnumerator WingBaceTop_R(Transform current)
	{
		yield return null;
		WingBaceTop_RObj = current;
	}

	public Transform forearm_L_001Obj;

	IEnumerator forearm_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_L_001Obj.transform.position, forearm_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_L_001Obj;
	}

	IEnumerator forearm_L_001(Transform current)
	{
		yield return null;
		forearm_L_001Obj = current;
	}

	public Transform forearm_R_001Obj;

	IEnumerator forearm_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_R_001Obj.transform.position, forearm_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_R_001Obj;
	}

	IEnumerator forearm_R_001(Transform current)
	{
		yield return null;
		forearm_R_001Obj = current;
	}

	public Transform chest1_L_001Obj;

	IEnumerator chest1_L_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_001Obj.transform.position, chest1_L_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_001Obj;
	}

	IEnumerator chest1_L_001(Transform current)
	{
		yield return null;
		chest1_L_001Obj = current;
	}

	public Transform chest1_L_002Obj;

	IEnumerator chest1_L_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_002Obj.transform.position, chest1_L_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_002Obj;
	}

	IEnumerator chest1_L_002(Transform current)
	{
		yield return null;
		chest1_L_002Obj = current;
	}

	public Transform chest1_L_003Obj;

	IEnumerator chest1_L_003C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_003Obj.transform.position, chest1_L_003Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_003Obj;
	}

	IEnumerator chest1_L_003(Transform current)
	{
		yield return null;
		chest1_L_003Obj = current;
	}

	public Transform chest1_L_004Obj;

	IEnumerator chest1_L_004C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_004Obj.transform.position, chest1_L_004Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_004Obj;
	}

	IEnumerator chest1_L_004(Transform current)
	{
		yield return null;
		chest1_L_004Obj = current;
	}

	public Transform chest1_R_001Obj;

	IEnumerator chest1_R_001C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_001Obj.transform.position, chest1_R_001Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_001Obj;
	}

	IEnumerator chest1_R_001(Transform current)
	{
		yield return null;
		chest1_R_001Obj = current;
	}

	public Transform chest1_R_002Obj;

	IEnumerator chest1_R_002C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_002Obj.transform.position, chest1_R_002Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_002Obj;
	}

	IEnumerator chest1_R_002(Transform current)
	{
		yield return null;
		chest1_R_002Obj = current;
	}

	public Transform chest1_R_003Obj;

	IEnumerator chest1_R_003C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_003Obj.transform.position, chest1_R_003Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_003Obj;
	}

	IEnumerator chest1_R_003(Transform current)
	{
		yield return null;
		chest1_R_003Obj = current;
	}

	public Transform chest1_R_004Obj;

	IEnumerator chest1_R_004C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_004Obj.transform.position, chest1_R_004Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_004Obj;
	}

	IEnumerator chest1_R_004(Transform current)
	{
		yield return null;
		chest1_R_004Obj = current;
	}

	public Transform Tail_7Obj;

	IEnumerator Tail_7C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_7Obj.transform.position, Tail_7Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_7Obj;
	}

	IEnumerator Tail_7(Transform current)
	{
		yield return null;
		Tail_7Obj = current;
	}

	public Transform Tail_10Obj;

	IEnumerator Tail_10C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_10Obj.transform.position, Tail_10Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_10Obj;
	}

	IEnumerator Tail_10(Transform current)
	{
		yield return null;
		Tail_10Obj = current;
	}

	public Transform Tail_14Obj;

	IEnumerator Tail_14C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_14Obj.transform.position, Tail_14Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_14Obj;
	}

	IEnumerator Tail_14(Transform current)
	{
		yield return null;
		Tail_14Obj = current;
	}

	public Transform Tail_008Obj;

	IEnumerator Tail_008C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_008Obj.transform.position, Tail_008Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_008Obj;
	}

	IEnumerator Tail_008(Transform current)
	{
		yield return null;
		Tail_008Obj = current;
	}

	public Transform Tail_011Obj;

	IEnumerator Tail_011C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_011Obj.transform.position, Tail_011Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_011Obj;
	}

	IEnumerator Tail_011(Transform current)
	{
		yield return null;
		Tail_011Obj = current;
	}

	public Transform Tail_015Obj;

	IEnumerator Tail_015C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_015Obj.transform.position, Tail_015Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_015Obj;
	}

	IEnumerator Tail_015(Transform current)
	{
		yield return null;
		Tail_015Obj = current;
	}

	public Transform Tail_022Obj;

	IEnumerator Tail_022C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_022Obj.transform.position, Tail_022Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_022Obj;
	}

	IEnumerator Tail_022(Transform current)
	{
		yield return null;
		Tail_022Obj = current;
	}

	public Transform Tail_025Obj;

	IEnumerator Tail_025C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_025Obj.transform.position, Tail_025Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_025Obj;
	}

	IEnumerator Tail_025(Transform current)
	{
		yield return null;
		Tail_025Obj = current;
	}

	public Transform Tail_029Obj;

	IEnumerator Tail_029C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_029Obj.transform.position, Tail_029Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_029Obj;
	}

	IEnumerator Tail_029(Transform current)
	{
		yield return null;
		Tail_029Obj = current;
	}

	public Transform forearm_LObj;

	IEnumerator forearm_LC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_LObj.transform.position, forearm_LObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_LObj;
	}

	IEnumerator forearm_L(Transform current)
	{
		yield return null;
		forearm_LObj = current;
	}

	public Transform forearm_RObj;

	IEnumerator forearm_RC (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, forearm_RObj.transform.position, forearm_RObj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = forearm_RObj;
	}

	IEnumerator forearm_R(Transform current)
	{
		yield return null;
		forearm_RObj = current;
	}

	public Transform chest1_L_006Obj;

	IEnumerator chest1_L_006C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_006Obj.transform.position, chest1_L_006Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_006Obj;
	}

	IEnumerator chest1_L_006(Transform current)
	{
		yield return null;
		chest1_L_006Obj = current;
	}

	public Transform chest1_L_007Obj;

	IEnumerator chest1_L_007C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_007Obj.transform.position, chest1_L_007Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_007Obj;
	}

	IEnumerator chest1_L_007(Transform current)
	{
		yield return null;
		chest1_L_007Obj = current;
	}

	public Transform chest1_L_008Obj;

	IEnumerator chest1_L_008C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_008Obj.transform.position, chest1_L_008Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_008Obj;
	}

	IEnumerator chest1_L_008(Transform current)
	{
		yield return null;
		chest1_L_008Obj = current;
	}

	public Transform chest1_L_009Obj;

	IEnumerator chest1_L_009C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_L_009Obj.transform.position, chest1_L_009Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_L_009Obj;
	}

	IEnumerator chest1_L_009(Transform current)
	{
		yield return null;
		chest1_L_009Obj = current;
	}

	public Transform chest1_R_006Obj;

	IEnumerator chest1_R_006C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_006Obj.transform.position, chest1_R_006Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_006Obj;
	}

	IEnumerator chest1_R_006(Transform current)
	{
		yield return null;
		chest1_R_006Obj = current;
	}

	public Transform chest1_R_007Obj;

	IEnumerator chest1_R_007C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_007Obj.transform.position, chest1_R_007Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_007Obj;
	}

	IEnumerator chest1_R_007(Transform current)
	{
		yield return null;
		chest1_R_007Obj = current;
	}

	public Transform chest1_R_008Obj;

	IEnumerator chest1_R_008C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_008Obj.transform.position, chest1_R_008Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_008Obj;
	}

	IEnumerator chest1_R_008(Transform current)
	{
		yield return null;
		chest1_R_008Obj = current;
	}

	public Transform chest1_R_009Obj;

	IEnumerator chest1_R_009C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, chest1_R_009Obj.transform.position, chest1_R_009Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = chest1_R_009Obj;
	}

	IEnumerator chest1_R_009(Transform current)
	{
		yield return null;
		chest1_R_009Obj = current;
	}

	public Transform Tail_8Obj;

	IEnumerator Tail_8C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_8Obj.transform.position, Tail_8Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_8Obj;
	}

	IEnumerator Tail_8(Transform current)
	{
		yield return null;
		Tail_8Obj = current;
	}

	public Transform Tail_11Obj;

	IEnumerator Tail_11C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_11Obj.transform.position, Tail_11Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_11Obj;
	}

	IEnumerator Tail_11(Transform current)
	{
		yield return null;
		Tail_11Obj = current;
	}

	public Transform Tail_009Obj;

	IEnumerator Tail_009C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_009Obj.transform.position, Tail_009Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_009Obj;
	}

	IEnumerator Tail_009(Transform current)
	{
		yield return null;
		Tail_009Obj = current;
	}

	public Transform Tail_012Obj;

	IEnumerator Tail_012C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_012Obj.transform.position, Tail_012Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_012Obj;
	}

	IEnumerator Tail_012(Transform current)
	{
		yield return null;
		Tail_012Obj = current;
	}

	public Transform Tail_023Obj;

	IEnumerator Tail_023C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_023Obj.transform.position, Tail_023Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_023Obj;
	}

	IEnumerator Tail_023(Transform current)
	{
		yield return null;
		Tail_023Obj = current;
	}

	public Transform Tail_026Obj;

	IEnumerator Tail_026C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_026Obj.transform.position, Tail_026Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_026Obj;
	}

	IEnumerator Tail_026(Transform current)
	{
		yield return null;
		Tail_026Obj = current;
	}

	public Transform Tail_12Obj;

	IEnumerator Tail_12C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_12Obj.transform.position, Tail_12Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_12Obj;
	}

	IEnumerator Tail_12(Transform current)
	{
		yield return null;
		Tail_12Obj = current;
	}

	public Transform Tail_013Obj;

	IEnumerator Tail_013C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_013Obj.transform.position, Tail_013Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_013Obj;
	}

	IEnumerator Tail_013(Transform current)
	{
		yield return null;
		Tail_013Obj = current;
	}

	public Transform Tail_027Obj;

	IEnumerator Tail_027C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_027Obj.transform.position, Tail_027Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_027Obj;
	}

	IEnumerator Tail_027(Transform current)
	{
		yield return null;
		Tail_027Obj = current;
	}

	public Transform Tail_13Obj;

	IEnumerator Tail_13C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_13Obj.transform.position, Tail_13Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_13Obj;
	}

	IEnumerator Tail_13(Transform current)
	{
		yield return null;
		Tail_13Obj = current;
	}

	public Transform Tail_014Obj;

	IEnumerator Tail_014C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_014Obj.transform.position, Tail_014Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_014Obj;
	}

	IEnumerator Tail_014(Transform current)
	{
		yield return null;
		Tail_014Obj = current;
	}

	public Transform Tail_028Obj;

	IEnumerator Tail_028C (Structures.Craft boneCraft)
	{
		yield return null;
		temp = CraftController.refference.SpawnBone(boneCraft, Tail_028Obj.transform.position, Tail_028Obj);
		//temp.gameObject.AddComponent<Soul>(); // temp.parent = Tail_028Obj;
	}

	IEnumerator Tail_028(Transform current)
	{
		yield return null;
		Tail_028Obj = current;
	}
    #endregion
}
