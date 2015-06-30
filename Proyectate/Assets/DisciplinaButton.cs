using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisciplinaButton : MonoBehaviour {

    public void Init(string name, int id)
    {
        GetComponentInChildren<Text>().text = name;
    }
}
