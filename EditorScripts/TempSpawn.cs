using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class TempSpawn : MonoBehaviour {

	public Transform python;
	public Transform armatureStructureNeck;
	public Transform armatureStructureLeftThigh;
	public Transform armatureStructureRightThigh;
	public Transform armatureStructureLeftFoot;
	public Transform armatureStructureRightFoot;
	public Transform armatureStructureHips;
	public Transform armatureStructurethl;
	public Transform armatureStructurethr;
	public Transform armatureStructuremhl;
	public Transform armatureStructuremhr;
	public Transform armatureStructurebhl;
	public Transform armatureStructurebhr;
	public Transform armature;
	Transform tempObj;
	public Transform bones;

	string path = @"C:\Users\Boomfood\Documents\MyProjects\Legacy\ProjectLegacy\Editor\Assets\Scripts\EditorScripts\CharacterStructure.cs";

	void Start()
	{
		if (!File.Exists(path)) 
		{
			// Create a file to write to. 
			using (StreamWriter sw = File.CreateText(path)) 
			{
				/*sw.WriteLine("using UnityEngine;");
				sw.WriteLine("using System.Collections;");
				sw.WriteLine("public class CharacterStructure : MonoBehaviour {");
				sw.WriteLine("GameObject temp;");*/
			}	
		}
		StartCoroutine(ArmatureLoop(python));
	/*	StartCoroutine(ArmatureLoop(armatureStructureLeftThigh));
		StartCoroutine(ArmatureLoop(armatureStructureRightThigh));
		StartCoroutine(ArmatureLoop(armatureStructureLeftFoot));
		StartCoroutine(ArmatureLoop(armatureStructureRightFoot));
		StartCoroutine(ArmatureLoop(armatureStructureHips));
		StartCoroutine(ArmatureLoop(armatureStructurethl));
		StartCoroutine(ArmatureLoop(armatureStructurethr));
		StartCoroutine(ArmatureLoop(armatureStructuremhl));
		StartCoroutine(ArmatureLoop(armatureStructuremhr));
		StartCoroutine(ArmatureLoop(armatureStructurebhl));
		StartCoroutine(ArmatureLoop(armatureStructurebhr));*/
	}

	IEnumerator ArmatureLoop(Transform start)
	{
		yield return null;
		if(bones.Find(start.name))
		{
			bones.Find(start.name).SendMessage("SetPlayerStructure", start, SendMessageOptions.DontRequireReceiver);
		}
		using (StreamWriter sw = File.AppendText(path)) 
		{
			/*sw.WriteLine("");
			sw.WriteLine("GameObject " + start.name + "Obj;");
			sw.WriteLine("");
			sw.WriteLine("IEnumerator " + start.name + "C (Structures.Craft boneCraft)");
			sw.WriteLine("{");
			sw.WriteLine("\tyield return null;");
			sw.WriteLine("\ttemp = CraftController.refference.SpawnCraft(boneCraft, " + start.name +"Obj.position, " + start.name + "Obj.eulerAngles);");
			sw.WriteLine("\ttemp.transform.parent = " + start.name + "Obj;");
			sw.WriteLine("}");
			sw.WriteLine("");
			sw.WriteLine("IEnumerator " + start.name + "(GameObject current)");
			sw.WriteLine("{");
			sw.WriteLine("\tyield return null;");
			sw.WriteLine("\t" + start.name + "Obj = current;");
			sw.WriteLine("}");*/
		}

		/*float distance;
		Vector3 midPos = Vector3.zero;
		if(start.childCount > 0)
		{
			distance = Vector3.Distance(start.position, start.GetChild(0).position);
			midPos = Vector3.MoveTowards(start.position, start.GetChild(0).position, distance/2);
		}
		else
		{
			distance = 3f;
			midPos = Vector3.MoveTowards(start.position, start.position + (-start.right * 3), distance/2);
		}*/
		//createArmature(midPos, start.rotation, distance, start.name);
		
		for(int count = 0; count < start.childCount; count++)
		{
			//StartCoroutine(ArmatureLoop(start.GetChild(count)));
				StartCoroutine(ArmatureLoop(start.GetChild(count)));
		}
	}

	void createArmature(Vector3 pos, Quaternion rot, float xScale, string name)
	{
		tempObj = Instantiate(armature, pos, rot)as Transform;
		tempObj.localScale =  new Vector3(xScale, 0.5f, 0.5f);
		tempObj.name = name;
	}
}
