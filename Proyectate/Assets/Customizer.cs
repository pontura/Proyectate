using UnityEngine;
using System.Collections;

public class Customizer : MonoBehaviour {

    CharacterManager manager;
	void Start () {
        manager = GetComponent<CharacterManager>();
        Events.OnCustomizerButtonPrevClicked += OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked += OnCustomizerButtonNextClicked;
	}
    void OnDestroy()
    {
        Events.OnCustomizerButtonPrevClicked -= OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked -= OnCustomizerButtonNextClicked;
    }
    void OnCustomizerButtonNextClicked(int id)
    {
        Clicked(id, true);
    }
    void OnCustomizerButtonPrevClicked(int id)
    {
        Clicked(id, false);
    }
    void Clicked(int id, bool next)
    {
        switch (id)
        {
            case 1:
                manager.ChangeColor(next);
                break;
            case 2:
                manager.ChangeShoes(next);
                break;
        }
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
