using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameRequest : MonoBehaviour {

    public Text inputField;

	void Start () {
	
	}
	public void Ready()
    {
        if (inputField.text.Length > 0)
        {
            Data.Instance.username = inputField.text;
            Data.Instance.LoadLevel("Classroom");
        }
    }
    public void Back()
    {
         Data.Instance.LoadLevel("Customizer");
    }
}
