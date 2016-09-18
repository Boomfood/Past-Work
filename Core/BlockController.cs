using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockController : MonoBehaviour {
	
	public Transform Cube;
	public Transform Sphere;
	public Transform Cureve;
	public Transform Cylinder;
	public Transform Triangle;
	public Transform Slope;
	Transform empty;
	public static BlockController refference;

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

	public Transform GetBlock(string name)
	{
		switch(name)
		{
			case "Cube(Clone)":
				return Cube;
			case "Cube":
				return Cube;
			case "Sphere(Clone)":
				return Sphere;
			case "Sphere":
				return Sphere;
			case "Curve(Clone)":
				return Cureve;
			case "Curve":
				return Cureve;
			case "Cylinder":
				return Cylinder;
			case "Cylinder(Clone)":
				return Cylinder;
			case "Triangle":
				return Triangle;
			case "Triangle(Clone)":
				return Triangle;
			case "Slope":
				return Slope;
			case "Slope(Clone)":
				return Slope;
		}
        return empty;
	}
	
	public Transform SpawnBlock(string passedBlock)
	{
		Transform spawnedBlock;
		spawnedBlock = Instantiate(GetBlock(passedBlock),Vector3.zero,Quaternion.identity) as Transform;
		spawnedBlock.name = passedBlock;
		return spawnedBlock;
	}
}
