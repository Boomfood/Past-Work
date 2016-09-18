using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CodeController : MonoBehaviour {

	public static CodeController refference;

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
	}

	public void AddCode(GameObject target, string code)
	{
		switch(code)
		{
			case "Damage":
				target.AddComponent<Damage>();
			break;
			case "Defence":
				target.AddComponent<Defence>();
			break;
			case "Heal":
				target.AddComponent<Heal>();
			break;
			case "PowerUp":
				//target.AddComponent<PowerUp>();
			break;
			case "Shine":
				target.AddComponent<Shine>();
			break;
			case "Gravity":
				target.AddComponent<Gravity>();
			break;
			case "Movement":
				target.AddComponent<Movement>();
			break;
			case "Phase":
				target.AddComponent<Phase>();
			break;
			case "Projectile":
				target.AddComponent<Projectile>();
			break;
			case "Freeze":
				target.AddComponent<Freeze>();
			break;
            case "Invis":
                target.AddComponent<Invis>();
            break;
            case "Protection":
                target.AddComponent<Protection>();
            break;
            case "Attach":
                target.AddComponent<Attach>();
            break;
            case "UsePhysiscs":
                target.AddComponent<UsePhysiscs>();
            break;
        }		
	}

	/*public T GetCode<T>(GameObject target, string name)
	{
		T rez;
		switch(name)
		{	
			case "Damage":
				if(target.GetComponent<Damage>() == null)
				rez = Damage();
			break;
			case "Buff":
				if(target.GetComponent<Defence>() == null)
				rez = Defence;
			break;
			case "Heal":
				if(target.GetComponent<Heal>() == null)
				rez = Heal;
			break;
			case "PowerUp":
				if(target.GetComponent<PowerUp>() == null)
				rez = PowerUp;
			break;
			case "Shine":
				if(target.GetComponent<Shine>() == null)
				rez = true;
			break;
		}
		rez = new Soul();
		return rez;
	}*/
	
	public void removeScript(GameObject target, string name)
	{
		switch(name)
		{
			case "Damage":
				Destroy(target.GetComponent<Damage>());
			break;
			case "Defence":
                Destroy(target.GetComponent<Defence>());
			break;
			case "Heal":
                Destroy(target.GetComponent<Heal>());
			break;
			/*case "PowerUp":
				target.GetComponent<PowerUp>().SendMessage("KILL");
			break;*/
			case "Shine":
                Destroy(target.GetComponent<Shine>());
			break;
            case "Phase":
                Destroy(target.GetComponent<Phase>());
            break;
            case "Invis":
                Destroy(target.GetComponent<Invis>());
            break;
            case "Movement":
                Destroy(target.GetComponent<Movement>());
            break;
            case "Attach":
                Destroy(target.GetComponent<Attach>());
            break;
            case "Freeze":
                Destroy(target.GetComponent<Freeze>());
            break;
            case "Protection":
                Destroy(target.GetComponent<Protection>());
            break;
            case "Projectile":
                Destroy(target.GetComponent<Projectile>());
            break;
            case "Gravity":
                Destroy(target.GetComponent<Gravity>());
            break;
            case "UsePhysiscs":
                Destroy(target.GetComponent<UsePhysiscs>());
            break;
        }		
	}
	
	public string ReturnAttachedCode(GameObject part)
	{
		if(part.GetComponent<Damage>() != null)
		{
			return "Damage";
		}
		if(part.GetComponent<Defence>() != null)
		{
			return "Defence";
		}
		if(part.GetComponent<Heal>() != null)
		{
			return "Heal";
		}
		/*if(part.GetComponent<PowerUp>() != null)
		{
			return "PowerUp";
		}*/
		if(part.GetComponent<Shine>() != null)
		{
			return "Shine";
		}
		if(part.GetComponent<Freeze>() != null)
		{
			return "Freeze";
		}
		if(part.GetComponent<Gravity>() != null)
		{
			return "Gravity";
		}
		if(part.GetComponent<Movement>() != null)
		{
			return "Movement";
		}
		if(part.GetComponent<Projectile>() != null)
		{
			return "Projectile";
		}
		if(part.GetComponent<Phase>() != null)
		{
			return "Phase";
		}
        if (part.GetComponent<Protection>() != null)
        {
            return "Protection";
        }
        if (part.GetComponent<Attach>() != null)
        {
            return "Attach";
        }
        if (part.GetComponent<Invis>() != null)
        {
            return "Invis";
        }
        if(part.GetComponent<UsePhysiscs>() != null)
        {
            return "UsePhysiscs";
        }
        return "";
	}
}
