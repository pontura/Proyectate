using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisciplinaButton : MonoBehaviour {

    public void Init(string name, int id, Disciplinas disciplinas)
    {
        GetComponentInChildren<Text>().text = name;
        GetComponent<Button>().onClick.AddListener(() => disciplinas.Select(id) );
    }
}
