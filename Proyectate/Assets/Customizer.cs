using UnityEngine;
using System.Collections;

public class Customizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void Ready()
    {
        Data.Instance.LoadLevel("NameRequest");
    }
    public void Back()
    {
        Data.Instance.LoadLevel("Disciplinas");
    }
}
