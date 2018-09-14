using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)//functions must be public to be accessed in other parts of Unity other then the object it's created in
	{
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest(string name)
	{
		Debug.Log("Level quit requested for: " + name);
		Application.Quit ();
	}

}