using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScreen : MonoBehaviour
{
    public bool IsCapturing;
    public bool StartFading;

    private RawImage image;
    private FadeOut fadeout;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.FindGameObjectWithTag("OverallTexture").GetComponent<RawImage>();
        fadeout = image.transform.GetComponent<FadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFading)
        {
            fadeout.IsFading = true;
            StartFading = false;
        }
    }

    void OnPostRender()
    {
        if (IsCapturing)
        {
            image.texture = Capture(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            IsCapturing = false;
        }
    }

    public static Texture Capture(Rect captureZone, int destX, int destY)
    {
        Texture2D result = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        result.ReadPixels(captureZone, destX, destY, false);
        result.Apply();

        return result;
    }
}
