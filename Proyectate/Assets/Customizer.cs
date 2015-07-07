using UnityEngine;
using System.Collections;

public class Customizer : MonoBehaviour {

   public CharacterManager manager;

	void Start () {
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
        print("Clicked: " + id + " - next: " + next);
        switch (id)
        {
            case 1:
                manager.ChangeColor(next);
                break;
            case 2:
                manager.ChangeHair(next);
                break;
            case 3:
                manager.ChangeFaces(next);
                break;
            case 4:
                manager.ChangeTop(next);
                break;
            case 5:
                manager.ChangeLegs(next);
                break;
            case 6:
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
