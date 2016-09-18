using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject GameScene;
    public GameObject EditorScene;
    public GameObject MenuCam;
    public Transform currentParent;
    public static Menu refference;
    bool on = true;
    bool exit = false;

    void Start()
    {
        if (refference == null)
        {
            refference = this;
        }
        else if (refference != this)
        {
            Destroy(this);
        }
    }


    void Update()
    {
        if(Input.GetKeyDown("escape") && !on)
        {
            on = true;
            GameScene.SetActive(false);
            EditorScene.SetActive(false);
            MenuCam.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

	void OnGUI()
    {
        if(on)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 30f, Screen.height/2f, 60f, 40f),"Editor"))
            {
                EditorScene.SetActive(true);
                MenuCam.SetActive(false);
                currentParent = EditorScene.transform;
                on = false;
            }
            else if (GUI.Button(new Rect(Screen.width / 2 - 30f, Screen.height / 2 - 80f, 60f, 40f), "Game"))
            {
                GameScene.SetActive(true);
                MenuCam.SetActive(false);
                currentParent = GameScene.transform;
                on = false;
            }
            if(!exit)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 30f, Screen.height / 2 + 80f, 60f, 40f), "exit"))
                {
                    exit = true;
                }
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 90f, Screen.height / 2 + 80f, 60f, 40f), "no"))
                {
                    Application.CancelQuit();
                    exit = false;
                }
                if (GUI.Button(new Rect(Screen.width / 2 + 30f, Screen.height / 2 + 80f, 60f, 40f), "yes"))
                {
                    Application.Quit();
                }
            }
        }
    }
}
