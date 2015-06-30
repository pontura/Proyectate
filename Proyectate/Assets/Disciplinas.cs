using UnityEngine;
using System.Collections;

public class Disciplinas : MonoBehaviour {

    [SerializeField]
    public GameObject container;
    [SerializeField]
    public DisciplinaButton button;

    public int buttonSeparation;

    private Settings settings;
	void Start () {
        settings = Data.Instance.settings;
        int a = 0;
        foreach (Settings.DisciplinaData data in settings.disciplinas)
        {
            print(data.name);
            DisciplinaButton disciplinaButton = Instantiate(button);
            disciplinaButton.transform.SetParent(container.transform);
            disciplinaButton.transform.localScale = Vector3.one;
            disciplinaButton.transform.localPosition = new Vector3(0, -buttonSeparation*a, 0);
            disciplinaButton.Init(data.name, a);
            a++;
        }
	}
}
