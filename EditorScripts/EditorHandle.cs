using UnityEngine;
using System.Collections;
using System;

public class EditorHandle : MonoBehaviour {

	new BoxCollider collider;
	public delegate void ActionPress();
	public static event ActionPress ChangeEditType;

	public Material plain;
	public Material active;
	Renderer render;
	public Renderer scaleRender;
	public Renderer moveRender;
	public Renderer rotateRender;
	
	bool showing = true;
	public GameObject bones;

	void Start()
	{
		render = gameObject.GetComponent<Renderer>();
		collider = gameObject.GetComponent<BoxCollider>();
		showing = false;
		bones.SetActive(false);
		print(Application.persistentDataPath);
	}

	void Update()
	{
		if(Input.GetKeyDown("tab") && EditortPart.selectedPart)
		{
			switch(EditortPart.currentEditType)
			{
				case EditortPart.EditType.transform:
					EditortPart.currentEditType = EditortPart.EditType.rotate;
					moveRender.enabled = false;
					rotateRender.enabled = true;
				break;
				case EditortPart.EditType.rotate:
					EditortPart.currentEditType = EditortPart.EditType.scale;
					rotateRender.enabled = false;
					scaleRender.enabled = true;
				break;
				case EditortPart.EditType.scale:
					EditortPart.currentEditType = EditortPart.EditType.transform;
					scaleRender.enabled = false;
					moveRender.enabled = true;
				break;
			}
			ChangeEditType();
		}
		
		if(Input.mouseScrollDelta.y < -0.1f)
		{
			if(EditortPart.currentEditType == EditortPart.EditType.scale)
			{
				transform.eulerAngles = EditortPart.selectedPart.eulerAngles;
			}
			else
			{
				transform.eulerAngles = Vector3.zero;
			}
			switch(EditortPart.chosenAxis)
			{
			case EditortPart.Axis.yz:
				EditortPart.chosenAxis = EditortPart.Axis.xy;
				break;
			case EditortPart.Axis.xy:
				EditortPart.chosenAxis = EditortPart.Axis.xz;
				transform.localEulerAngles += new Vector3(90f, 0f, 0f);
				break;
			case EditortPart.Axis.xz:
				EditortPart.chosenAxis = EditortPart.Axis.yz;
				transform.localEulerAngles += new Vector3(0f, 90f, 0f); 
				break;
			}
		}
		if(Input.mouseScrollDelta.y > 0.1f)
		{
			if(EditortPart.currentEditType == EditortPart.EditType.scale)
			{
				transform.eulerAngles = EditortPart.selectedPart.eulerAngles;
			}
			else
			{
				transform.eulerAngles = Vector3.zero;
			}
			switch(EditortPart.chosenAxis)
			{
			case EditortPart.Axis.xy:
				EditortPart.chosenAxis = EditortPart.Axis.yz;
				transform.localEulerAngles += new Vector3(0f, 90f, 0f);
				break;
			case EditortPart.Axis.xz:
				EditortPart.chosenAxis = EditortPart.Axis.xy;
				break;
			case EditortPart.Axis.yz:
				EditortPart.chosenAxis = EditortPart.Axis.xz;
				transform.localEulerAngles +=  new Vector3(90f, 0f, 0f);
				break;
			}
		}

		if(Input.GetKeyDown("delete"))
		{
			try
			{
				Destroy(EditortPart.selectedPart.gameObject);
			}
			catch(Exception e)
			{
			}
		}

		if(Input.GetKey("left shift") && !Input.GetMouseButton(1))
		{
			if(Input.GetKeyDown("d"))
			{
				string blockType = EditortPart.selectedPart.name;
				Vector3 pos = EditortPart.selectedPart.position;
				Vector3 rot = EditortPart.selectedPart.eulerAngles;
				Vector3 scale = EditortPart.selectedPart.localScale;
				Transform newBlock = transform;
				if(blockType.Contains("Cube"))
				{
					newBlock = BlockController.refference.SpawnBlock("Cube");
				}
				if(blockType.Contains("Sphere"))
				{
					newBlock = BlockController.refference.SpawnBlock("Sphere");
				}
				if(blockType.Contains("Triangle"))
				{
					newBlock = BlockController.refference.SpawnBlock("Triangle");
				}
				if(blockType.Contains("Cylinder"))
				{
					newBlock = BlockController.refference.SpawnBlock("Cylinder");
				}
				if(blockType.Contains("Curve"))
				{
					newBlock = BlockController.refference.SpawnBlock("Curve");
				}
				if(blockType.Contains("Slope"))
				{
					newBlock = BlockController.refference.SpawnBlock("Slope");
				}
                newBlock.parent = EditorController.currentCraftObj;
				newBlock.position = pos;
				newBlock.eulerAngles = rot;
				newBlock.localScale = scale;
                newBlock.gameObject.layer = EditortPart.selectedPart.gameObject.layer;
                newBlock.gameObject.AddComponent<EditortPart>();
				newBlock.gameObject.SendMessage("OnMouseDown");
                CodeController.refference.AddCode(newBlock.gameObject, CodeController.refference.ReturnAttachedCode(EditortPart.selectedPart.gameObject));
            }
		}

		if(Input.GetKeyDown("v"))
		{
			if(showing)
			{
				showing = false;
				bones.SetActive(false);
			}
			else
			{
				showing = true;
				bones.SetActive(true);
			}
		}
	}

	void OnEnable()
	{
		EditortPart.IWasClicked += MoveMe;
		EditortPart.IWasDragged += EnableCollider;
		EditortPart.IWasScaled += NewScale;
	}

	void OnDisable()
	{
		EditortPart.IWasClicked -= MoveMe;
		EditortPart.IWasDragged -= EnableCollider;
		EditortPart.IWasScaled -= NewScale;
	}

	void NewScale(float newScale)
	{
		newScale++;
		//transform.localScale = new Vector3(newScale, newScale, 1f);
	}

	void MoveMe(Vector3 newPos)
	{
		transform.position = newPos;
		if(EditortPart.currentEditType == EditortPart.EditType.scale)
		{
			transform.eulerAngles = EditortPart.selectedPart.eulerAngles;
		}
		else
		{
			transform.eulerAngles = Vector3.zero;
		}
		EditortPart.chosenAxis = EditortPart.Axis.xz;
		transform.localEulerAngles += new Vector3(90f, 0f, 0f);
	}

	void EnableCollider(Vector3 newPos)
	{
		render.material = active;
		collider.enabled = true;
		transform.position = newPos;
		StartCoroutine(ColliderOff());
	}

	IEnumerator ColliderOff()
	{
		yield return new WaitForSeconds(0.1f);
		if(!Input.GetMouseButton(0))
		{
			collider.enabled = false;
			render.material = plain;
		}
	}
}
