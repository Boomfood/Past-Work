using UnityEngine;
using System.Collections;
using System;

public class BaseScript : MonoBehaviour {

	public static float randomNumber;

	void Update()
	{
		if(Input.GetKey("e"))
		{
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
			generateRandomNumber(Input.mousePosition);
		}
	}

	static public void generateRandomNumber(Vector3 locatoin)
	{
		float randOne = Mathf.PerlinNoise (locatoin.x, locatoin.y);

		DateTime currentTime = DateTime.Now;
		int milliSeconds = currentTime.Millisecond;
		milliSeconds = milliSeconds / 10;
		int seconds = currentTime.Second;
		string minsS = currentTime.ToString("mm");
		string hoursS = currentTime.ToString("HH");
		int mins = int.Parse (minsS);
		int hours = int.Parse (hoursS);
		float randTwo = Mathf.PerlinNoise ((float)mins,(float)seconds);
		randomNumber = randOne + randTwo;
		//randomNumber = randomNumber / milliSeconds;
		randomNumber = randomNumber * UnityEngine.Random.Range(2,6999);
		randomNumber = Frequency (randomNumber);
		//if(randomNumber < 10)
		//print (randomNumber);
	}

	static float Frequency(float newRand)
	{
		while(newRand >= 100)
		{
			newRand = newRand/10;
		}

		string tempRand = newRand.ToString ();
		if(tempRand.Length < 5)
		{
			tempRand = "0" + tempRand;
		}
		tempRand = tempRand.Substring (0, 5);
		return float.Parse (tempRand);
	}
}
