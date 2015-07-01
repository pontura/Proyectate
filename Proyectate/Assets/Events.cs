using UnityEngine;
using System.Collections;

public static class Events {

    public static System.Action<string> OnSoundFX = delegate { };
    public static System.Action<int> OnCustomizerButtonNextClicked = delegate { };
    public static System.Action<int> OnCustomizerButtonPrevClicked = delegate { };
}
