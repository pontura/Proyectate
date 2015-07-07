using UnityEngine;
using System.Collections;
using System;

public class SavedSettings : MonoBehaviour {
    
    [Serializable]
    public class PlayerSettings
    {
        public string username;
        public int color;
        public int hair;
        public int face;
        public int body;
        public int bottom;
        public int shoes;
    }

    public PlayerSettings myPlayerSettings;

	void Start () {
        myPlayerSettings = new PlayerSettings();
        int disciplinaID = GetComponent<Settings>().disciplinaId;	    
	}
    public void AddPlayerCloth(string part, int clothID)
    {
        print("part " + part + " clothID " + clothID);
        switch (part)
        {
            case "color": myPlayerSettings.color = clothID; break;
            case "hair": myPlayerSettings.hair = clothID; break;
            case "face": myPlayerSettings.face = clothID; break;
            case "body": myPlayerSettings.body = clothID; break;
            case "bottom": myPlayerSettings.bottom = clothID; break;
            case "shoes": myPlayerSettings.shoes = clothID; break;
        }
    }
    void SavePlayer()
    {

    }
    void LoadSavedPlayers()
    {

    }
}
