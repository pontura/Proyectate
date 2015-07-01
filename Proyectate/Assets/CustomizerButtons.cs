using UnityEngine;
using System.Collections;

public class CustomizerButtons : MonoBehaviour {

    public int id;

    public void Prev()
    {
        print(id);
        Events.OnCustomizerButtonPrevClicked(id);
    }
	public void Next () 
    {
        print(id);
        Events.OnCustomizerButtonNextClicked(id);
	}
}
