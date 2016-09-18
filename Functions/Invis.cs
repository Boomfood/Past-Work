using UnityEngine;
using System.Collections;

public class Invis : MonoBehaviour {

    Renderer renderer;

    public enum ActivationType { Passive, Mian, Secondry };
    ActivationType type = ActivationType.Passive;

    delegate void Activation();
    Activation PassiveAction;
    Activation MainAction;
    Activation SecondryAction;

    void Awake()
    {
        renderer = GetComponent < Renderer>();
    }

    void Start()
    {
        switch (type)
        {
            case ActivationType.Mian:
                MainAction = Toggle;
                break;
            case ActivationType.Secondry:
                SecondryAction = Toggle;
                break;
            case ActivationType.Passive:
                renderer.enabled = false;
                break;
        }
    }

    public void MainFun()
    {
        MainAction();
    }
    public void Secondry()
    {
        SecondryAction();
    }

    void Toggle()
    {
        if (renderer.enabled)
        {
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
        }
    }
}
