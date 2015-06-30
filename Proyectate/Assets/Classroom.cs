using UnityEngine;
using System.Collections;

public class Classroom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void Replay()
    {
        Data.Instance.LoadLevel("Intro");
    }
    public void Email()
    {
        Data.Instance.LoadLevel("Email");
    }
}
