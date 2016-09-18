using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

	private int healthCap = 10;
	public int health = 10;
	public int defence = 0;
	private int damage = 0;
    Transform protection;
    private Transform isBone;
	private GameObject parent;

	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_MainTex";
	private Material mainMat;
	private float emissionMax = 1f;
	private float emissionMin = 0.05f;
	private float emissionTarget = 0.05f;
	private float x;
	private float z;
	private Renderer gObjR;
	private Color baseColor;
	public float emission;
	private Color finalColor;
	private  float timeOffset = 0f;
	
	private Vector2 uvOffset = Vector2.zero;

	void Start()
	{
		//this. = false;
		gObjR = GetComponent<Renderer>();
		healthCap = (int)((transform.lossyScale.x + transform.lossyScale.z + transform.lossyScale.y) * 10);
		health = healthCap;
		mainMat = gObjR.materials[0];
		x = transform.position.x;
		z = transform.position.z;
		baseColor = mainMat.color;
	}

	void TakeDamage(int[] info)
	{
		TakingDamge (info);
	}

    void TakingDamge(int[] info)
	{
        if (protection)
        {
            protection.SendMessage("TakingDamage", info);
        }
        else
        {
            damage = Mathf.Clamp(info[0] - defence, 0, info[0]);
            health -= damage;
            if (health <= 0)
            {
               // parent.SendMessage("LostPart");
                Destroy(gameObject);
            }
        }
	}

	void TakeHealth(int[] info)
	{
		health += info [0];
		if(health > healthCap)
		{
			health = healthCap;
		}
		else
		{
			StartCoroutine (TakingHealth (info));
		}
	}
	
	IEnumerator TakingHealth(int[] info)
	{
		for(int count = info[1]; count > 0; count--)
		{
			yield return new WaitForSeconds(1f);
			health += info [0];
			if(health > healthCap)
			{
				health = healthCap;
			}
		}
	}

	void IncreaseDefence(int power)
	{
		defence += power;
	}

    void SetProtection(Transform sheild)
    {
        protection = sheild;
    }

	void OnBecameInvisible()
	{
			StopCoroutine("MatUpdate");
	}

	void OnBecameVisible()
	{
		if(healthCap >= 100)
		{
			StartCoroutine("MatUpdate");
		}
	}

	IEnumerator MatUpdate() 
	{
        //uvOffset += ( uvAnimationRate * Time.deltaTime );

        //mainMat.SetTextureOffset( "_MainTex", uvOffset );
        /*emission = emissionMin + Mathf.PingPong (((Time.time - timeOffset) + x + z)* 0.6f, emissionMax - emissionMin);

		finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
		mainMat.SetColor ("_EmissionColor", finalColor);

		if(emission < 0.88f)
		{
			yield return null;
		}
		else
		{
			timeOffset = Time.time;
			yield return new WaitForSeconds(Random.Range(0,5));
			timeOffset = Time.time - timeOffset;
		}
		StartCoroutine("MatUpdate");*/
        yield return null;
	}
}
