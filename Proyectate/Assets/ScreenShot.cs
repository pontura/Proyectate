using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public Camera camera;

    private int resWidth = 1920;
    private int resHeight = 1080;

    private float dividedBy = 1.5f;

    public void TakePhoto()
    {
        RenderTexture rt = new RenderTexture((int)(resWidth / dividedBy), (int)(resHeight / dividedBy), 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D((int)(resWidth / dividedBy), (int)(resHeight / dividedBy), TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, (int)(resWidth / dividedBy), (int)(resHeight / dividedBy)), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + "/XXX.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }
}