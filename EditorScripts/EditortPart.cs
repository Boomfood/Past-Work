using UnityEngine;
using System.Collections;
using System;

public class EditortPart : MonoBehaviour {

	public delegate void ActionClick(Vector3 parent);
	public static event ActionClick IWasClicked;
	public delegate void ActionDrag(Vector3 Pos);
	public static event ActionDrag IWasDragged;
	public delegate void ActionScale(float newScale);
	public static event ActionScale IWasScaled;
	public delegate void tool();
	public tool UseTool;
	public static Transform selectedPart;
	public static float snap = 0.25f;
	static int rotatoinSnap = 15;
	static Vector3 Orintation = Vector3.up;
	public enum Axis{xy,xz,yz};
	static Axis ChosenAxis;
	int loopCount;
    Vector2 tempSelectedPos;
	public static Axis chosenAxis
	{
		get
		{
			return ChosenAxis;
		}
		set
		{
			ChosenAxis = value;
			if(ChosenAxis == Axis.xz)// y
			{
				Orintation = Vector3.forward;
			}
			else if(ChosenAxis == Axis.xy)// z
			{
				Orintation = Vector3.up;
			}
			else if(ChosenAxis == Axis.yz)// x
			{
				Orintation = Vector3.up;
			}
			print(ChosenAxis);
		}
	}

	public enum EditType{transform, rotate, scale};
	public static EditType currentEditType;

	int dragLayerMask = 1 << 9;

	Ray ray;
	RaycastHit hit;
	RaycastHit[] hits;
	float x;
	float y;
	float z;
	int convertedFloat;
	Vector3 startingTransform;
	bool transformChanged = false;

	float startAngle = 0f;
	float currentAngle = 0f;
	float angleDifference = 0f;

	bool isSphere;
	//Vector3 startingScale;
	float scaleDifference;
	Vector3 heldScaleMod;
	public float scaleLimit = 20f;
	static GameObject startingScale;
	static GameObject currentScale;

	void Start()
	{
		if(startingScale == null)
		{
			startingScale = new GameObject();
			currentScale = new GameObject();
			UseTool = Transforming;
			chosenAxis = Axis.xz;
			print(startingScale.transform.position);
		}
		isSphere = gameObject.GetComponent<SphereCollider>();
	}

	void OnEnable()
	{
		EditorHandle.ChangeEditType += UpdateEditType;
	}
	
	void OnDisable()
	{
		EditorHandle.ChangeEditType -= UpdateEditType;
	}

	void UpdateEditType()
	{
		if(currentEditType == EditType.transform)// y
		{
			UseTool = Transforming;
		}
		else if(currentEditType == EditType.rotate)// z
		{
			UseTool = Rotating;
		}
		else if(currentEditType == EditType.scale)// x
		{
			UseTool = Scaling;
		}
	}

	void OnMouseDown()
	{
		if(selectedPart != transform)
		{
			IWasClicked(transform.position);
			IWasScaled(Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z));
			selectedPart = transform;
		}
		try{
		startAngle = 0f;
		startingScale.transform.position = Vector3.zero;
		startingTransform = -Vector3.one * 100;
		}
		catch(NullReferenceException e)
		{
			print(e);
		}
	}

	void OnMouseDrag()
	{

		IWasDragged(transform.position);
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit, Mathf.Infinity, dragLayerMask);
		try
		{
			UseTool();
		}
		catch(NullReferenceException e)
		{
			UseTool = Transforming;
		}
	}

	void Transforming()
	{
		if(startingTransform == (-Vector3.one * 100))
		{
			startingTransform =  hit.point - transform.position;
		}
		else
		{
			if(chosenAxis == Axis.xz || chosenAxis == Axis.xy)
			{
				convertedFloat = (int)((hit.point.x - transform.position.x - startingTransform.x) / snap);
				x = (snap * convertedFloat)/* - (transform.position.x +(transform.position.x - hit.point.x))*/;
				print(x);
				if(x >= snap || x <= -snap)
				{
					transform.position += Vector3.right * x;
					transformChanged = true;
				}
			}
			if(chosenAxis == Axis.xy || chosenAxis == Axis.yz)
			{
				convertedFloat = (int)((hit.point.y - transform.position.y - startingTransform.y) / snap);
				y = (snap * convertedFloat)/* - (transform.position.y +(transform.position.y - hit.point.y))*/;
				print(y);
				if(y >= snap || y <= -snap)
				{
					transform.position += Vector3.up * y;
					transformChanged = true;
				}
			}
			if(chosenAxis == Axis.xz || chosenAxis == Axis.yz)
			{
				convertedFloat = (int)((hit.point.z - transform.position.z - startingTransform.z) / snap);
				z = (snap * convertedFloat)/* - (transform.position.z +(transform.position.z - hit.point.z))*/;
				print(z);
				if(z >= snap || z <= -snap)
				{
					transform.position += Vector3.forward * z;
					transformChanged = true;
				}
			}
			if(transformChanged)
			{
				startingTransform = hit.point - transform.position;
				transformChanged = false;
			}

		}
	}

	void Rotating()
	{
		
		if(startAngle == 0f)
		{
			startAngle = Vector3.Angle(Orintation, hit.point - transform.position);
		}

		currentAngle = Vector3.Angle(Orintation, hit.point - transform.position);
		angleDifference = currentAngle - startAngle;
		convertedFloat = (int)(angleDifference / rotatoinSnap);

		if(angleDifference >= rotatoinSnap || angleDifference <= -rotatoinSnap)
		{
			if(chosenAxis == Axis.xz)// y
			{
				if(hit.point.x < transform.position.x)
				{
					convertedFloat *= -1;
				}
				transform.rotation =  Quaternion.AngleAxis(rotatoinSnap * convertedFloat, Vector3.up) * transform.rotation;
			}
			else if(chosenAxis == Axis.xy)// z
			{
				if(hit.point.x < transform.position.x)
				{
					convertedFloat *= -1;
				}
				transform.rotation = Quaternion.AngleAxis(rotatoinSnap * convertedFloat, Vector3.forward) * transform.rotation;
			}
			else if(chosenAxis == Axis.yz)// x
			{
				if(hit.point.z < transform.position.z)
				{
					convertedFloat *= -1;
				}
				transform.rotation = Quaternion.AngleAxis(rotatoinSnap * convertedFloat, Vector3.right) * transform.rotation;
			}
			startAngle = 0f;
			print(convertedFloat);
		}
	}

	void Scaling()
	{
		if(startingScale.transform.position == Vector3.zero)
		{
			startingScale.transform.parent = selectedPart;
			currentScale.transform.parent = selectedPart;
			startingScale.transform.position = hit.point;
			x = 0f;
			y = 0f;
			z = 0f;
			
		}
		else
		{
			currentScale.transform.position = hit.point;

			x = currentScale.transform.localPosition.x - startingScale.transform.localPosition.x;
			y = currentScale.transform.localPosition.y - startingScale.transform.localPosition.y;
			z = currentScale.transform.localPosition.z - startingScale.transform.localPosition.z;

			if(isSphere)
			{
				if(y > x || y < -x)
				{
					x = y;
				}
				if(z > x || z < -x)
				{
					x = z;
				}
				if(x >= snap || x <= -snap)
				{
					if((transform.localScale.x + x) > 0 && (transform.localScale.x + x) <= scaleLimit)
					{
						convertedFloat = (int)(x / snap);
						x = snap * convertedFloat;
						transform.localScale += Vector3.one * x;
						print("x");
						x = 1f;
					}
				}
				print(x);
			}
			else
			{
				if(chosenAxis == Axis.xz || chosenAxis == Axis.xy)
				{
					if(x >= snap || x <= -snap)
					{
						if((transform.localScale.x + x) > 0 && (transform.localScale.x + x) <= scaleLimit)
						{
							convertedFloat = (int)(x / snap);
							x = snap * convertedFloat;
							transform.localScale += Vector3.right * x;
							print("x");
							x = 1f;
						}
					}
				}
				if(chosenAxis == Axis.xy || chosenAxis == Axis.yz)
				{
					if(y >= snap || y <= -snap)
					{
						if((transform.localScale.y + y) > 0 && (transform.localScale.y + y) <= scaleLimit)
						{
							convertedFloat = (int)(y / snap);
							y = snap * convertedFloat;
							transform.localScale += Vector3.up * y;
							print("y");
							y = 1f;
						}
					}
				}
				if(chosenAxis == Axis.xz || chosenAxis == Axis.yz)
				{
					if(z >= snap || z <= -snap)
					{
						convertedFloat = (int)(z / snap);
						z = snap * convertedFloat;
						if((transform.localScale.z + z) > 0 && (transform.localScale.z + z) <= scaleLimit)
						{
							transform.localScale += Vector3.forward * z;
							print("z");
							z = 1f;
						}
					}
				}
			}
			if(x == 1f || y == 1f || z == 1f)
			{
				startingScale.transform.position = hit.point;
				x = 0f;
				y = 0f;
				z = 0f;
				IWasScaled(Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z));
			}
		}
	}

	Vector3 TimesVector3(Vector3 vec1, Vector3 vec2)
	{
		Vector3 output = Vector3.zero;

		output.x = vec1.x * vec2.x;
		output.y = vec1.y * vec2.y;
		output.z = vec1.z * vec2.z;
		return output;
	}

    void OnGUI()
    {
        try
        {
            if (EditortPart.selectedPart == this.transform)
            {
                tempSelectedPos = Camera.current.WorldToScreenPoint(transform.position);
                GUI.Label(new Rect(tempSelectedPos.x - 40f, tempSelectedPos.y - 20f, 80f, 40f), CodeController.refference.ReturnAttachedCode(selectedPart.gameObject));
            }
        }
        catch(NullReferenceException e)
        {

        }
    }
}