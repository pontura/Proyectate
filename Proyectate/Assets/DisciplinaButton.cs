using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisciplinaButton : MonoBehaviour {

    void Start()
    {
        Text field = GetComponentInChildren<Text>();
        field.text = field.text.ToUpper();
    }
}
