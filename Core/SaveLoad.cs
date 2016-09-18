using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Newtonsoft.Json;

public class SaveLoad : MonoBehaviour 
{
	JsonSerializerSettings m_SerializationSettings = new JsonSerializerSettings
	{
		TypeNameHandling = TypeNameHandling.Objects,
		TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full
	};

	public static SaveLoad saveLoad;
	Settings settings;
	Profile profile;

	void Awake()
	{
		if(saveLoad == null)
		{
			DontDestroyOnLoad(gameObject);
			saveLoad = this;
		}
		else if(saveLoad != this)
		{
			Destroy(gameObject);
		}
		DirectoryInfo di = Directory.CreateDirectory(Application.persistentDataPath + "/Bones");
	}

//******************************************************************	Load Classes	***********************************************************************************************

	void Start()
	{
		LoadSettings ();
		LoadProfile ();
	}

//*******************************************************************	Save and Load Functions	****************************************************************************************

	public void SaveSettings()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Settings.dat");

		bf.Serialize (file, settings);
		file.Close();
	}

	public void LoadSettings()
	{
		if(File.Exists(Application.persistentDataPath + "/Settings.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Settings.dat", FileMode.Open);
			settings = (Settings)bf.Deserialize(file);
			file.Close();
		}
	}

	public void SaveProfile()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Profile.dat");
		
		bf.Serialize (file, profile);
		file.Close();
	}
	
	public void LoadProfile()
	{
		if(File.Exists(Application.persistentDataPath + "/Profile.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Profile.dat", FileMode.Open);

			profile = (Profile)bf.Deserialize(file);
			file.Close();
		}
	}



	public void SaveCustom<T>(string fileName, T customClass)
	{
		string data = JsonConvert.SerializeObject(customClass, m_SerializationSettings);
		/*BinaryFormatter bf = new BinaryFormatter ();*/
		FileStream file = File.Create (Application.persistentDataPath + "/" + fileName +".dat");
		StreamWriter ssw = new StreamWriter(file);
		ssw.Write(data);
		
		//bf.Serialize (file, customClass);
		ssw.Close();
		file.Close();
	}
	
	public void LoadCustom<T>(string fileName,ref T customClass)
	{
		if(File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
		{
			//BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + fileName + ".dat", FileMode.Open);
			StreamReader ssr = new StreamReader(file);
			
			//customClass = (T)bf.Deserialize(file);
			customClass = JsonConvert.DeserializeObject<T>(ssr.ReadToEnd(), m_SerializationSettings);
			ssr.Close();
			file.Close();
		}
		else
		{
			customClass = default(T);
		}
	}

	public void SaveBone<T>(string fileName, T customClass)
	{
		string data = JsonConvert.SerializeObject(customClass, m_SerializationSettings);
		/*BinaryFormatter bf = new BinaryFormatter ();*/
		FileStream file = File.Create (Application.persistentDataPath + "/Bones/" + fileName +".dat");
		StreamWriter ssw = new StreamWriter(file);
		ssw.Write(data);
		
		//bf.Serialize (file, customClass);
		ssw.Close();
		file.Close();
	}
	
	public void LoadBone<T>(string fileName,ref T customClass)
	{
		if(File.Exists(Application.persistentDataPath + "/Bones/" + fileName + ".dat"))
		{
			//BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Bones/" + fileName + ".dat", FileMode.Open);
			StreamReader ssr = new StreamReader(file);
			
			//customClass = (T)bf.Deserialize(file);
			customClass = JsonConvert.DeserializeObject<T>(ssr.ReadToEnd(), m_SerializationSettings);
			ssr.Close();
			file.Close();
		}
		else
		{
			customClass = default(T);
		}
	}

	public void DeleteCustom(string fileName)
	{
		if(File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
		{
			File.Delete (Application.persistentDataPath + "/" + fileName + ".dat");
		}
	}


//**********************************************************************	Save Class Formats	*********************************************************************************************
	[Serializable]
	public class Settings
	{
		//graphics
		public string renderDistance;	//convert to flaot
		public string FOV;	//convert to flaot
		public bool HDR;
		// or (can not have both HDR and AA)
		public int antiAnalysing; // 0 2 4 8
		public bool softParticals;
		//key bindings
		public char forwards;
		public char backwards;
		public char left;
		public char right;
		public char jump;
		public char sprint;
		public char crouch;
		public char num1;
		public char num2;
		public char num3;
		public char num4;
		public char num5;
		public char num6;
		public char num7;
		public char num8;
		public char num9;
		public char num0;
		//Mouse
		public bool invertXAxis;
		public bool invertYAxis;
		public string lookSensitivity;	//convert to float
		//Audio 
		public string masterVolume;
		public string musicVolume;
		public string ambientVolume;
		public string effectVolume;
	}

	[Serializable]
	public class Profile
	{
		public int health;
		public int expirence;
		public string name;
	}
}


