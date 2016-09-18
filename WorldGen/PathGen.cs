using UnityEngine;
using System.Collections;
using System;

public class PathGen : BaseScript {

    #region vars
    static int scriptIterations = 0;

	public float scale = 30f;
	public int length = 40;
	int currentLength = 0;
	bool lockTurning = true;
    
    public Transform[] pathNodes;
	public Transform[] buildingNodes;
	public Transform[] largeNodes;
	public Transform[] connectors;
	public Transform slopeUp;
	public Transform slopeDown;
    public Transform world;
    
    const float NODESIZE = 80f;
	const int NODEHEIGHT = 40;
	int heightChange = 0;
	int oldHeight = 0;
	int correctHeight = 0;
	float frequency = 0.125f;
	float amplitude = 60f;
	int timeMod = 1;
	Transform temp;

    public delegate void EmptyEvent();
	public static event EmptyEvent EndWorldGen;
    #endregion

    void Start()
	{
		scriptIterations++;
		StartCoroutine(GenPathComponent());
		timeMod = DateTime.Now.Second;
	}

	IEnumerator GenPathComponent()
	{
		Vector3 pos = transform.position;
        if (pos.x <= (scale * NODESIZE) + 1 && pos.x > 0 && pos.z <= (scale * NODESIZE) + 1 && pos.z >= 0)   //check to see if with in wold bounds
        {
            currentLength++;
            oldHeight = heightChange;
            heightChange = (int)((Mathf.PerlinNoise((pos.x / NODESIZE) * frequency * timeMod, (pos.z / NODESIZE) * frequency * timeMod) * amplitude)); //generate new height value using perlin noise
                                                                                                                                                       //print(heightChange);
            heightChange = (heightChange / NODEHEIGHT) * NODEHEIGHT;
            correctHeight = heightChange;

            #region GenNewNode
            if (heightChange == oldHeight)   //gen new noded on the same level
            {
                generateRandomNumber(pos);
                temp = Instantiate(pathNodes[(int)((pathNodes.Length - 1) * (randomNumber / 100))], pos, Quaternion.identity) as Transform; //1, spawn

                temp.gameObject.GetComponent<BaseNode>().SetHeight(heightChange);
                temp.parent = world;

                generateRandomNumber(pos);
                if (randomNumber <= (12) && !lockTurning)
                {
                    transform.rotation *= Quaternion.FromToRotation(transform.forward, transform.right);    //2, rotate
                    lockTurning = true;
                }
                else if (randomNumber >= (100 - 12) && !lockTurning)
                {
                    transform.rotation *= Quaternion.FromToRotation(transform.forward, -transform.right);   //2, rotate
                    lockTurning = true;
                }
                else
                {
                    lockTurning = false;
                }
            }
            else    // gen a slope going up or down
            {
                if (heightChange > oldHeight)    //up
                {
                    temp = Instantiate(slopeUp, pos, transform.rotation) as Transform;
                    temp.gameObject.GetComponent<BaseNode>().SetHeight(oldHeight);
                    //print(heightChange);
                }
                else  //down
                {
                    temp = Instantiate(slopeDown, pos, transform.rotation) as Transform;
                    temp.gameObject.GetComponent<BaseNode>().SetHeight(heightChange);
                    correctHeight = oldHeight;
                    //print("down");
                }
                temp.parent = world;
                lockTurning = false;
            }
            #endregion


            #region Create new branching path
            if (!Physics.Raycast(pos, transform.right, NODESIZE))
			{
				generateRandomNumber(pos);
				if(randomNumber > 20)
				{
					generateRandomNumber(pos);
					int tempRand = (int)(randomNumber / 33.3f) + 1;
					generateRandomNumber(pos);
					temp = Instantiate(buildingNodes[(int)((buildingNodes.Length-1)*(randomNumber/100))], pos + (transform.right * NODESIZE), Quaternion.AngleAxis(90*tempRand,transform.up))as Transform;	//3, sides + rear
					temp.gameObject.GetComponent<BaseNode>().SetHeight(correctHeight);
				}
				else
				{
					temp = Instantiate(transform , pos + (transform.right * NODESIZE), transform.rotation * Quaternion.FromToRotation(transform.forward, transform.right))as Transform;
					temp.gameObject.GetComponent<PathGen>().SetHeights(correctHeight, oldHeight);
                }
                temp.parent = world;
            }
			if(!Physics.Raycast(pos, -transform.right, NODESIZE))
			{
				generateRandomNumber(pos);
				if(randomNumber > 20)
				{
					generateRandomNumber(pos);
					int tempRand = (int)(randomNumber / 33.3f) + 1;
					generateRandomNumber(pos);
					temp = Instantiate(buildingNodes[(int)((buildingNodes.Length-1)*(randomNumber/100))], pos - (transform.right * NODESIZE), Quaternion.AngleAxis(90*tempRand,transform.up))as Transform;	//3, sides + rear
					temp.gameObject.GetComponent<BaseNode>().SetHeight(correctHeight);
				}
				else
				{
					temp = Instantiate(transform , pos - (transform.right * NODESIZE), transform.rotation * Quaternion.FromToRotation(transform.forward, -transform.right))as Transform;
					temp.gameObject.GetComponent<PathGen>().SetHeights(correctHeight, oldHeight);
                }
                temp.parent = world;
            }
			if(!Physics.Raycast(pos, -transform.forward, NODESIZE) && correctHeight == 0f)
			{
				generateRandomNumber(pos);
				if(randomNumber > 20)
				{
					generateRandomNumber(pos);
					int tempRand = (int)(randomNumber / 33.3f) + 1;
					generateRandomNumber(pos);
					temp = Instantiate(buildingNodes[(int)((buildingNodes.Length-1)*(randomNumber/100))], pos - (transform.forward * NODESIZE), Quaternion.AngleAxis(90*tempRand,transform.up))as Transform;	//3, sides + rear
					temp.gameObject.GetComponent<BaseNode>().SetHeight(correctHeight);
				}
				else
				{
					temp = Instantiate(transform , pos - (transform.forward * NODESIZE), transform.rotation * Quaternion.FromToRotation(transform.forward, -transform.forward))as Transform;
					temp.gameObject.GetComponent<PathGen>().SetHeights(correctHeight, oldHeight);
                }
                temp.parent = world;
            }
            #endregion

            yield return new WaitForEndOfFrame();
			if(!Physics.Raycast(pos, transform.forward, NODESIZE) && currentLength <= length)   // if able to move forward to gen new node next frame
			{
				transform.position += transform.forward * NODESIZE;	//4, move
				StartCoroutine(GenPathComponent());
			}
			else
			{
				scriptIterations--;
				if(scriptIterations == 0)   // if max amount of nodes have been placed end world gen
				{
					EndWorldGen();
					print("Done");
				}
			}
		}
        else  //gen power station and connectors on outskirts (needs to be 300 away from gate)
        {
			if(!Physics.Raycast(transform.position, transform.forward, NODESIZE*3) && !Physics.Raycast(transform.position - (transform.right * NODESIZE), transform.forward, NODESIZE*3) && !Physics.Raycast(transform.position + (transform.right * NODESIZE), transform.forward, NODESIZE*3))
			{
				generateRandomNumber(transform.position);
				temp = Instantiate(connectors[(int)((connectors.Length-1)*(randomNumber/100))], pos, transform.rotation)as Transform;
				temp.gameObject.GetComponent<BaseNode>().SetHeight(heightChange);
				generateRandomNumber(transform.position);
				transform.position += transform.forward * (NODESIZE * 2);
                temp.parent = world;
                temp = Instantiate(largeNodes[(int)((largeNodes.Length-1)*(randomNumber/100))], transform.position, Quaternion.identity)as Transform;	//1, spawn
				temp.gameObject.GetComponent<BaseNode>().SetHeight(heightChange);
                temp.parent = world;
            }
			scriptIterations--;
			if(scriptIterations == 0)   // if max amount of nodes have been placed end world gen
            {
				EndWorldGen();
				print("Done");
			}
		}
	}

	public void SetHeights(int firstHeight, int secondHeight)
	{
		heightChange = firstHeight;
		oldHeight = secondHeight;
	}

    #region old code
    /*Vector3 v3y = new Vector3(0f, 1f, 0f);
	Vector3 sides;

	int mod = 40;

	void Start () 
	{
		StartCoroutine(GenPathComponent(pos, transform.forward));
	}
	
	IEnumerator GenPathComponent(Vector3 pos, Vector3 direction)
	{
		currentLength++;
		if(pos.x/mod < scale && pos.z/mod < scale && pos.x/mod >= 0 && pos.z/mod >= 0)
		{
			temp = Instantiate(pathNodes[Random.Range(0, pathNodes.Length-1)], pos, Quaternion.identity);
			
			if(currentLength < length && !Physics.Raycast(pos, direction, mod))
			{
				StartCoroutine(GenPathComponent(pos + (direction * mod), direction));
			}
			
			yield return null;
			
			Ray ray = new Ray(pos, sides);
			generateRandomNumber(pos);
			sides = Vector3.one;
			sides = (sides - (v3y + direction))* mod;
			if(!Physics.Raycast(ray, mod))
			{
				if(randomNumber/10 > 4)
				{
					temp = Instantiate(buildingNodes[Random.Range(0, buildingNodes.Length-1)], pos + sides, Quaternion.identity);
				}
				else
				{
					Branch(pos + sides, sides.normalized);//doesnt work
				}
			}
			generateRandomNumber(pos);
			if(randomNumber < 20f)
			{
				direction = sides;
			}
			generateRandomNumber(pos);
			sides = new Vector3(sides.x * -1, 0f, sides.z * -1);
			ray.direction = sides;
			if(!Physics.Raycast(ray, mod))
			{
				if(randomNumber/10 > 4)
				{
					temp = Instantiate(buildingNodes[Random.Range(0, buildingNodes.Length-1)], pos + sides, Quaternion.identity);
				}
				else
				{
					Branch(pos + sides, sides.normalized);//doesnt work
				}
			}
			generateRandomNumber(pos);
			if(randomNumber < 20f)
			{
				direction = sides;
			}
		}
		else
		{
			if(!Physics.Raycast(pos + (direction * mod), direction, mod * 3))
			{
				sides = Vector3.one;
				sides = (sides - (v3y + direction))* mod;
				if(!Physics.Raycast((pos - (direction * mod)) - sides, direction, mod * 3) && !Physics.Raycast((pos - (direction * mod)) + sides, direction, mod * 3))
				{
					pos += direction * mod;
					temp = Instantiate(largeNodes[Random.Range(0, largeNodes.Length-1)], pos, Quaternion.identity);
				}
			}
		}
	}

	void Branch(Vector3 pos, Vector3 direction)
	{
		StartCoroutine(GenPathComponent(pos, direction));
	}*/
    #endregion
}
