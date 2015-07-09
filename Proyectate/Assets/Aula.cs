using UnityEngine;
using System.Collections;

public class Aula : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadSprite();
	}
    public void LoadSprite()
    {
        string texture = "aulas/matematica";
        switch (Data.Instance.settings.disciplinaId)
        {
            case 0: texture = "aulas/matematica"; break;
            case 1: texture = "aulas/biologia"; break;
            case 2: texture = "aulas/matematica"; break;
            case 3: texture = "aulas/matematica"; break;
            case 4: texture = "aulas/matematica"; break;
            case 5: texture = "aulas/matematica"; break;
        }
        
        GetComponent<SpriteRenderer>().sprite = Resources.Load(texture, typeof(Sprite)) as Sprite;
    }
}
