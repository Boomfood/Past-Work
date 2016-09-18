using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CraftController : MonoBehaviour {
	
	public static CraftController refference;
	public Transform animatedBones;
	public static Transform spawnedAnimatedBones;
	public static Structures.playerStructure mainPlayerStructure;
	public PhysicMaterial zeroFriction;

	void Awake()
	{
		if(refference == null)
		{
			DontDestroyOnLoad(gameObject);
			refference = this;
		}
		else if(refference != this)
		{
			Destroy(gameObject);
		}
		if(spawnedAnimatedBones == null)
		{
			//spawnedAnimatedBones = Instantiate(animatedBones, Vector3.zero, Quaternion.identity)as Transform;
		}
		mainPlayerStructure = new Structures.playerStructure();
	}

	List<Structures.Craft> listOfCrafts = new List<Structures.Craft>();
	
	public Structures.Craft GetCraft(string craftName)
	{
		foreach(Structures.Craft currentCraft in listOfCrafts)
		{
			if(string.Equals(craftName,currentCraft))
			{
				return currentCraft;
			}
		}
		Structures.Craft nullCraft = new Structures.Craft();
		return nullCraft;
	}
	

    /// <summary>
    /// Spawns a craft at a specified location
    /// </summary>
    /// <param name="craftTemplate"></param>
    /// <param name="spawnPoint"></param>
    /// <param name="spawnRotation"></param>
    /// <returns></returns>
	public Transform SpawnCraft(Structures.Craft craftTemplate, Vector3 spawnPoint, Vector3 spawnRotation)
	{
		GameObject craft = new GameObject();
		Transform part;
		Vector3 vec3Temp = new Vector3();
		craft.name = craftTemplate.name;
		craft.transform.position = spawnPoint;
		craft.transform.eulerAngles = spawnRotation;
        craft.AddComponent<CHECKS>();
        Rigidbody temp = craft.AddComponent<Rigidbody>();
        temp.useGravity = false;
        temp.isKinematic = true;
        temp.mass = 0f;
        temp.drag = 0.001f;
		for(int count = craftTemplate.parts.Count; count > 0; count--)
		{
			Structures.Part partTemplate = craftTemplate.parts[count -1];
			part = BlockController.refference.SpawnBlock(partTemplate.name);
			part.parent = craft.transform;
			vec3Temp.x = partTemplate.posistionX;
			vec3Temp.y = partTemplate.posistionY;
			vec3Temp.z = partTemplate.posistionZ;
			part.localPosition = vec3Temp;
			vec3Temp.x = partTemplate.scaleX;
			vec3Temp.y = partTemplate.scaleY;
			vec3Temp.z = partTemplate.scaleZ;
			part.localScale = vec3Temp;
			vec3Temp.x = partTemplate.rotationX;
			vec3Temp.y = partTemplate.rotationY;
			vec3Temp.z = partTemplate.rotationZ;
			part.localEulerAngles = vec3Temp;
            temp.mass += part.localScale.magnitude*2;

            if (partTemplate.code != null)
			{
				CodeController.refference.AddCode(part.gameObject, partTemplate.code);
			}
		}
       // temp.drag = Mathf.Clamp(10f - (temp.mass, 0f, 5f);
        return craft.transform;
	}

	public Transform SpawnBone(Structures.Craft craftTemplate, Vector3 spawnPoint, Transform parent)
	{
		Transform part;
		Vector3 vec3Temp = new Vector3();
		for(int count = craftTemplate.parts.Count; count > 0; count--)
		{
			Structures.Part partTemplate = craftTemplate.parts[count -1];
			part = BlockController.refference.SpawnBlock(partTemplate.name);
			part.parent = parent;
			vec3Temp.x = partTemplate.posistionX;
			vec3Temp.y = partTemplate.posistionY;
			vec3Temp.z = partTemplate.posistionZ;
			part.localPosition = vec3Temp;
			vec3Temp.x = partTemplate.scaleX;
			vec3Temp.y = partTemplate.scaleY;
			vec3Temp.z = partTemplate.scaleZ;
			part.localScale = vec3Temp;
			vec3Temp.x = partTemplate.rotationX;
			vec3Temp.y = partTemplate.rotationY;
			vec3Temp.z = partTemplate.rotationZ;
			part.eulerAngles = vec3Temp;
			part.GetComponent<Collider>().material = zeroFriction;
            part.tag = parent.tag;
            part.gameObject.layer = parent.gameObject.layer;
            if(Menu.refference.EditorScene.activeInHierarchy)
            {
                part.gameObject.layer = 8;
                part.gameObject.AddComponent<EditortPart>();
            }
			/*if(partTemplate.code != null)
			{
				codeController.AddCode(part, partTemplate.code);
			}*/
		}

		return parent;
	}

	public Transform SpawnEditorCraft(Structures.Craft craftTemplate, Vector3 spawnPoint, Vector3 spawnRotation)
	{
		GameObject craft = new GameObject();
		Transform part;
		Vector3 vec3Temp = new Vector3();
		craft.name = craftTemplate.name;
		craft.transform.position = spawnPoint;
		craft.transform.eulerAngles = spawnRotation;

		for(int count = craftTemplate.parts.Count; count > 0; count--)
		{
			Structures.Part partTemplate = craftTemplate.parts[count -1];
			part = BlockController.refference.SpawnBlock(partTemplate.name);
			part.parent = craft.transform;
			vec3Temp.x = partTemplate.posistionX;
			vec3Temp.y = partTemplate.posistionY;
			vec3Temp.z = partTemplate.posistionZ;
			part.localPosition = vec3Temp;
			vec3Temp.x = partTemplate.scaleX;
			vec3Temp.y = partTemplate.scaleY;
			vec3Temp.z = partTemplate.scaleZ;
			part.localScale = vec3Temp;
			vec3Temp.x = partTemplate.rotationX;
			vec3Temp.y = partTemplate.rotationY;
			vec3Temp.z = partTemplate.rotationZ;
			part.eulerAngles = vec3Temp;
			part.gameObject.AddComponent<EditortPart>();
            part.gameObject.layer = 8;
			if(partTemplate.code != null)
			{
				CodeController.refference.AddCode(part.gameObject, partTemplate.code);
			}
		}
		return craft.transform;
	}

	public Structures.Craft StoreCraft(Transform craftObj, string name)
	{
		Structures.Craft craftStore = new Structures.Craft();
		craftStore.parts = new List<Structures.Part>();
		Structures.Part tempPart = new Structures.Part();
		Transform tempObj;
		craftStore.name = name;
		for(int count = craftObj.childCount; count > 0; count--)
		{
			if(BlockController.refference.GetBlock(craftObj.GetChild(count-1).name) != null)
			{
				tempPart.code = null;
				tempObj = craftObj.GetChild(count-1);
				tempPart.name = tempObj.name;
				tempPart.posistionX = tempObj.localPosition.x;
				tempPart.posistionY = tempObj.localPosition.y;
				tempPart.posistionZ = tempObj.localPosition.z;
				tempPart.rotationX = tempObj.eulerAngles.x;
				tempPart.rotationY = tempObj.eulerAngles.y;
				tempPart.rotationZ = tempObj.eulerAngles.z;
				tempPart.scaleX = tempObj.localScale.x;
				tempPart.scaleY = tempObj.localScale.y;
				tempPart.scaleZ = tempObj.localScale.z;
				tempPart.code = CodeController.refference.ReturnAttachedCode(tempObj.gameObject);
				craftStore.parts.Add(tempPart);
			}
		}
		return craftStore;
	}

	public Structures.playerStructure StorePlayerStructure(Transform newPlayer)
	{
		mainPlayerStructure = new Structures.playerStructure();
		StoreBone(newPlayer ,ref mainPlayerStructure);
		return mainPlayerStructure;
	}

	void StoreBone(Transform start, ref Structures.playerStructure newPlayer)
	{
		newPlayer.boneParts = StoreCraft(start, start.name);
		newPlayer.children = new Structures.playerStructure[start.childCount];
		for(int count = 0; count < start.childCount ; count++)
		{
			StoreBone(start.GetChild(count), ref newPlayer.children[count]);
		}
	}

	public void SpawnPlayer()
	{
		for(int count = 0; count < animatedBones.childCount; count++)
		{
			SpawnPlayer(animatedBones.GetChild(count), mainPlayerStructure.children[count]);
		}
	}
	void SpawnPlayer(Transform bone, Structures.playerStructure start)
	{
		if(start.boneParts.parts.Count > 0)
		{
			Transform tempBone = CraftController.refference.SpawnCraft(start.boneParts, animatedBones.position, animatedBones.eulerAngles);
			tempBone.parent = spawnedAnimatedBones;
            print("player");
            if (!Menu.refference.EditorScene.activeInHierarchy)
            {
                tempBone.gameObject.layer = 8;
            }
		}
		for(int count = 0; count < animatedBones.childCount; count++)
		{
			SpawnPlayer(animatedBones.GetChild(count), start.children[count]);
		}
	}
}
