using UnityEngine;
using System.Collections;

public class Shine : MonoBehaviour {

	[Range(1,8)]
	public int power = 1;
	public LightType Shape = LightType.Point;
	Light light;

	void OnEnable()
	{
		light = gameObject.GetComponent<Light> ();
		if(light == null)
		{
			light = gameObject.AddComponent<Light>();
		}
		light.type = Shape;
		light.intensity = power;
	}

	void OnDisable()
	{
		Destroy (light);
	}
}
