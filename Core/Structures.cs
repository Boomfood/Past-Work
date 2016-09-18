using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Structures : MonoBehaviour {

	/*public struct Block
	{
		public string name;
		public Vector3 rotation;
		public Vector3 scale;
	}*/

	/*public struct Part
	{
		public string code;
		//public Block block;
		public Vector3 posistion;
		public Vector3 scale;
		public Vector3 rotation;
		public string name;
	}

	public struct Craft
	{
		public List<Part> parts;
		public string name;
	}*/

	[Serializable]
	public struct Part
	{
        public string code;
		//public Block block;
		public float posistionX;
		public float posistionY;
		public float posistionZ;
		public float scaleX;
		public float scaleY;
		public float scaleZ;
		public float rotationX;
		public float rotationY;
		public float rotationZ;
		public string name;
    }
	
	[Serializable]
	public struct Craft
	{
		public List<Part> parts;
		public string name;
	}

	[Serializable]
	public struct playerStructure
	{
		public Craft boneParts;
		public playerStructure[] children;
	}

	[System.Serializable]
	public struct Vector3S
	{
		public float x;
		public float y;
		public float z;
		
		public Vector3S(float rX, float rY, float rZ)
		{
			x = rX;
			y = rY;
			z = rZ;
		}
		
		public static implicit operator Vector3(Vector3S rValue)
		{
			return new Vector3(rValue.x, rValue.y, rValue.z);
		}
		
		public static implicit operator Vector3S(Vector3 rValue)
		{
			return new Vector3S(rValue.x, rValue.y, rValue.z);
		}
	}
	
	[System.Serializable]
	public struct QuaternionS
	{
		public float x;
		public float y;
		public float z;
		public float w;
		
		public QuaternionS(float rX, float rY, float rZ, float rW)
		{
			x = rX;
			y = rY;
			z = rZ;
			w = rW;
		}
		
		public static implicit operator Quaternion(QuaternionS rValue)
		{
			return new Quaternion(rValue.x, rValue.y, rValue.z, rValue.w);
		}
		
		public static implicit operator QuaternionS(Quaternion rValue)
		{
			return new QuaternionS(rValue.x, rValue.y, rValue.z, rValue.w);
		}
	}
}
