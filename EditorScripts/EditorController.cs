using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EditorController : MonoBehaviour {

    static EditorController refference;
    string tempScriptName = "";
	public static bool saveble = true;
	public static GameObject bones;
	public GameObject Bones;
	public Transform playerController;
	public enum editorTypes{player, tool, vehicles, abilities, world, projectile};
	static editorTypes CurrentEditorType = editorTypes.world;
    bool changeToFromPlayer = true;
    public GameObject skeleton;
	public static editorTypes currentEditorType
	{
		set
		{
            if(CurrentEditorType != editorTypes.player && value == editorTypes.player)
            {
                currentCraftObj.gameObject.SetActive(false);
                showing = false;
                ToggleBones();
                refference.skeleton.SetActive(true);
            }
			else if(CurrentEditorType == editorTypes.player && value != editorTypes.player)
            {
                currentCraftObj.gameObject.SetActive(true);
                showing = true;
				ToggleBones();
                refference.skeleton.SetActive(false);

            }
            CurrentEditorType = value;
        }
		get
		{
			return CurrentEditorType;
		}
	}
	string craftName = "";
	float midScreen;
	float screenHeight;
	public static Transform currentCraftObj;
	Structures.Craft currentCraft = new Structures.Craft();
	bool exit = false;
	public Image flashImage;
	Color color = Color.white;
	static bool Showing = false;
	public static bool showing
	{
		get
		{
			return Showing;
		}
		set
		{
			if(currentEditorType == editorTypes.player)
			{
				Showing = value;
			}
			else
			{
				Showing = false;
			}
		}
	}

	void Start()
	{
        if(refference == null)
        {
            refference = this;
        }
        else if(refference != this)
        {
            Destroy(this);
        }
		currentCraftObj = new GameObject().transform;
		bones = Bones;
		currentCraftObj.position = Vector3.zero;
		currentCraftObj.eulerAngles = new Vector3(0f, 0f, 0f);
        SaveLoad createSL = new SaveLoad();
		midScreen = Screen.width/2;
		screenHeight = Screen.height;
		color.a = 0;
        currentCraftObj.parent = Menu.refference.currentParent;
    }

	void OnGUI()
	{
        if (GUI.Button(new Rect(midScreen - (Screen.width / 12)-40,0f, 80f, 40f), "Character"))
        {
            currentEditorType = editorTypes.player;
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 12) - 40, 0f, 80f, 40f), "World"))
        {
            print("clicked");
            currentEditorType = editorTypes.world;
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 5) - 40, 0f, 80f, 40f), "Tool"))
        {
            currentEditorType = editorTypes.tool;
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 5) - 40, 0f, 80f, 40f), "Vehicles"))
        {
            currentEditorType = editorTypes.vehicles;
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 3) - 40, 0f, 80f, 40f), "Projectile"))
        {
            currentEditorType = editorTypes.projectile;
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 3) - 40, 0f, 80f, 40f), "Abilities"))
        {
            currentEditorType = editorTypes.abilities;
        }

        if (Input.GetKeyDown("tab"))
		{
			Event.current.type = EventType.Ignore;
		}
		craftName = GUI.TextField(new Rect(midScreen - 100, screenHeight - 20, 200f, 20f), craftName);
		if(GUI.Button(new Rect(midScreen - 90, screenHeight - 40f, 60f, 20f), "Save"))
		{
			if(currentEditorType != editorTypes.player)
			{
				SaveLoad.saveLoad.SaveCustom<Structures.Craft>(craftName, CraftController.refference.StoreCraft(currentCraftObj, craftName));
			}
			else
			{
				CharacterStructure.refference.Save();
				//SaveLoad.saveLoad.SaveCustom<Structures.playerStructure>(craftName, CraftController.refference.StorePlayerStructure(playerController));
			}
			StartCoroutine(saveFlash());
		}
		else if(GUI.Button(new Rect(midScreen + 30, screenHeight - 40f, 60f, 20f), "Load") && currentEditorType != editorTypes.player)
		{
			if(currentEditorType != editorTypes.player)
			{
				SaveLoad.saveLoad.LoadCustom(craftName,ref currentCraft);
				Destroy(currentCraftObj.gameObject);
				currentCraftObj = CraftController.refference.SpawnEditorCraft(currentCraft, Vector3.zero, new Vector3(0f, 0f, 0f));
                currentCraftObj.parent = Menu.refference.currentParent.transform;
			}
			else
			{
				/*try
				{
					SaveLoad.saveLoad.LoadCustom<Structures.playerStructure>(craftName, ref CraftController.mainPlayerStructure);
					CraftController.refference.SpawnPlayer();
					Destroy(currentCraftObj.gameObject);
				}
				catch(Exception e)
				{
					return;
				}*/
			}
		}
        if (Input.mousePosition.x > (Screen.width - 160f) && EditortPart.selectedPart != null)
        {
            tempScriptName = CodeController.refference.ReturnAttachedCode(EditortPart.selectedPart.gameObject);
            if (GUI.Button(new Rect(Screen.width - 80f, 60f, 80f, 60f), "Damage"))
            {
                if(EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Damage"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Damage");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 80f, 120f, 80f, 60f), "Heal"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Heal"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Heal");
                    }
                }
                /* if (currentEditorType != editorTypes.player)
                 {
                 }
                 else
                 {
                 }*/
            }
            if (GUI.Button(new Rect(Screen.width - 80f, 180f, 80f, 60f), "Defence"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Defence"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Defence");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 80f, 240f, 80f, 60f), "Move"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Move"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Move");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 80f, 300f, 80f, 60f), "Phase"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Phase"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Phase");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 80f, 360f, 80f, 60f), "Invis"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Invis"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Invis");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 60f, 80f, 60f), "Freeze"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Freeze"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Freeze");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 120f, 80f, 60f), "Light"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("UsePhysiscs"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "UsePhysiscs");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 180f, 80f, 60f), "Attach"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Attach"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Attach");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 240f, 80f, 60f), "Gravity"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Gravity"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Gravity");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 300f, 80f, 60f), "Spawn"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Projectile"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Projectile");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
            if (GUI.Button(new Rect(Screen.width - 160f, 360f, 80f, 60f), "Protection"))
            {
                if (EditortPart.selectedPart != null)
                {
                    if (!tempScriptName.Equals(""))
                    {
                        CodeController.refference.removeScript(EditortPart.selectedPart.gameObject, tempScriptName);
                    }
                    if (!tempScriptName.Equals("Protection"))
                    {
                        CodeController.refference.AddCode(EditortPart.selectedPart.gameObject, "Protection");
                    }
                }
                /*if (currentEditorType != editorTypes.player)
                {
                }
                else
                {
                }*/
            }
        }
        if(Input.mousePosition.x < 80)
        {
		    if(GUI.Button(new Rect(0f, 60f, 80f, 60f), "Cube"))
		    {
			    BlockController.refference.SpawnBlock("Cube").gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
		    if(GUI.Button(new Rect(0f, 120f, 80f, 60f), "Sphere"))
		    {
			    BlockController.refference.SpawnBlock("Sphere").gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
		    if(GUI.Button(new Rect(0f, 180f, 80f, 60f), "Triangle"))
		    {
			    BlockController.refference.SpawnBlock("Triangle").gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
		    if(GUI.Button(new Rect(0f, 240f, 80f, 60f), "Cylinder"))
		    {
			    BlockController.refference.SpawnBlock("Cylinder").gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
		    if(GUI.Button(new Rect(0f, 300f, 80f, 60f), "Curve"))
		    {
			    BlockController.refference.SpawnBlock("Curve").gameObject.AddComponent<EditortPart>().gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
		    if(GUI.Button(new Rect(0f, 360f, 80f, 60f), "Slope"))
		    {
			    BlockController.refference.SpawnBlock("Slope").gameObject.AddComponent<EditortPart>().gameObject.SendMessage("OnMouseDown");
			    if(currentEditorType != editorTypes.player)
			    {
				    EditortPart.selectedPart.parent = currentCraftObj;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
			    else
			    {
				    EditortPart.selectedPart.parent = Bone.currentBone.playerStructure;
				    EditortPart.selectedPart.position = Bone.currentBone.playerStructure.position;
                    EditortPart.selectedPart.gameObject.layer = 8;
                }
		    }
        }

		if(Input.GetKeyDown("v"))
		{
			ToggleBones();
		}

		if(Input.GetKey("left shift") && Input.GetKeyDown("p") && CurrentEditorType == editorTypes.player)
		{
			EditortPart.selectedPart.parent = Bone.currentBone.transform;
		}

	}

	static void ToggleBones()
	{
		if(showing)
		{
			showing = false;
			bones.SetActive(false);
		}
		else
		{
			showing = true;
			bones.SetActive(showing);
		}
	}

	IEnumerator saveFlash()
	{
		for(color.a = 1; color.a > 0;)
		{
			color.a = Mathf.MoveTowards(color.a, 0f, Time.deltaTime);
			flashImage.color = color;
			yield return null;
		}
	}
}
