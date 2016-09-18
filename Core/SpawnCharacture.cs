using UnityEngine;
using System.Collections;

public class SpawnCharacture : MonoBehaviour {

	IEnumerator Spawn(Transform animatedBones, Structures.playerStructure start)
	{
		Transform tempBone = CraftController.refference.SpawnCraft(start.boneParts, animatedBones.position, animatedBones.eulerAngles);
		for(int count = 0; count < tempBone.childCount; count++)
		{
			tempBone.GetChild(count).parent = animatedBones;
		}
		Destroy(tempBone.gameObject);
		yield return null;
		for(int count = 0; count < animatedBones.childCount; count++)
		{
			StartCoroutine(Spawn(animatedBones.GetChild(count), start.children[count]));
		}
	}
}
