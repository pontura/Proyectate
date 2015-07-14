using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	public void DeleteAll() {
        PlayerPrefs.DeleteAll();
        Application.Quit();
	}
	
	// Update is called once per frame
	public void Disciplinas () {
        Data.Instance.LoadLevel("Slides");
	}
}
