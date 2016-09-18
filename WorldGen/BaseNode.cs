using UnityEngine;
using System.Collections;

public class BaseNode : MonoBehaviour {

	float height = 0;
	float nodeY = 0f;
	public float size = 20f;

	void OnEnable()
	{
		PathGen.EndWorldGen += ApplyHeight;
	}

	void OnDisable()
	{
		PathGen.EndWorldGen -= ApplyHeight;
	}

	void ApplyHeight()
	{
		transform.position += transform.up * height;
		/*Transform nodeBase = BlockController.refference.SpawnBlock("Cube");
		size = (transform.position.y - -20f) - 10f;
		nodeBase.position = new Vector3(transform.position.x, transform.position.y - (size / 2f) - 5f, transform.position.z);
		nodeBase.localScale = new Vector3(20f, size, 20f);*/
	}

	public void SetHeight(float newHeight)
	{
		height = newHeight;
	}
}
