using UnityEngine;
using System.Collections;
using System.IO;

public class MainInterface : MonoBehaviour {

    RaycastHit hit;
    RaycastHit[] hitList;
    public string[] toolbarStr;
    public Structures.Craft[] toolbar = new Structures.Craft[6];
    Structures.Craft tempToolbarEl;
    float midScreen;
    public Transform playerMainCam;
    delegate void Click();
    Click click;
    Structures.Craft selectedCraft;

    void Start()
    {
        toolbarStr = Directory.GetFiles(Application.persistentDataPath);
        for (int count = 0; count < 6; count++)
        {
            print(Path.GetFileNameWithoutExtension(toolbarStr[count]));
            SaveLoad.saveLoad.LoadCustom<Structures.Craft>(Path.GetFileNameWithoutExtension(toolbarStr[count]), ref toolbar[count]);
        }
        midScreen = Screen.width / 2;
        selectedCraft = toolbar[0];
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hitList = Physics.RaycastAll(playerMainCam.position, playerMainCam.forward, 40f, ~(1 << gameObject.layer));
            if(hitList.Length > 0) hit = hitList[0];
            for (int count = 1; count < hitList.Length; count++)
            {
                if ((!hitList[count].transform.tag.Equals(tag)) && hitList[count].distance < hit.distance)
                {
                    hit = hitList[count];
                }
                else
                {
                    hit = default(RaycastHit);
                }
            }
            print(transform.eulerAngles);
            CraftController.refference.SpawnCraft(selectedCraft, hit.point, new Vector3(0f, transform.eulerAngles.y, 0f));
        }
    }

    public void MainAction()
    {

    }

    public void Secondry()
    {

    }

    public void Scroll(float value)
    {

    }

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(midScreen - (Screen.width / 12) - 40, Screen.height - 40f, 80f, 40f), toolbar[0].name))
        {
            selectedCraft = toolbar[0];
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 12) - 40, Screen.height - 40f, 80f, 40f), toolbar[1].name))
        {
            selectedCraft = toolbar[1];
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 5) - 40, Screen.height - 40f, 80f, 40f), toolbar[2].name))
        {
            selectedCraft = toolbar[2];
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 5) - 40, Screen.height - 40f, 80f, 40f), toolbar[3].name))
        {
            selectedCraft = toolbar[3];
        }
        else if (GUI.Button(new Rect(midScreen - (Screen.width / 3) - 40, Screen.height - 40f, 80f, 40f), toolbar[4].name))
        {
            selectedCraft = toolbar[4];
        }
        else if (GUI.Button(new Rect(midScreen + (Screen.width / 3) - 40, Screen.height - 40f, 80f, 40f), toolbar[5].name))
        {
            selectedCraft = toolbar[5];
        }
    }
}
