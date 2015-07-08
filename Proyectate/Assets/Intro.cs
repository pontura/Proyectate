using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Disciplinas () {
        Data.Instance.LoadLevel("Slides");
	}
}
