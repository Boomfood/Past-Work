using UnityEngine;
using System.Collections;

public class MaterialController : MonoBehaviour {
	
	public Color dark;
	public Color bright;
	bool direction = true;
	Camera cam;
	public AudioClip thunder;

	void Start()
	{
		cam = GetComponent<Camera>();
		StartCoroutine("MatUpdate");
	}

	IEnumerator MatUpdate() 
	{
		RenderSettings.fogColor = bright;
		cam.backgroundColor = bright;
		AudioSource.PlayClipAtPoint(thunder, transform.position);
		yield return new WaitForSeconds(0.2f);
		for(;RenderSettings.fogColor.b > dark.b;)
		{
			RenderSettings.fogColor = Vector4.MoveTowards(RenderSettings.fogColor, dark, Time.deltaTime);
			cam.backgroundColor = Vector4.MoveTowards(cam.backgroundColor, dark, Time.deltaTime);
			yield return null;
		}
		yield return new WaitForSeconds(Random.Range(13.3f,120f));

		StartCoroutine("MatUpdate");
	}
}
