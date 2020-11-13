using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Flashbang : MonoBehaviour
{
    public float MaxTimer = 2;
    public Transform Player;

    private float timer;
    private bool IsCapturing;
    private CaptureScreen capScreen;
    private bool HasHappenedOnce;
    public CameraShake camShake;

    void Start()
    {
        capScreen = Camera.main.GetComponent<CaptureScreen>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > MaxTimer)
        {
            if (!HasHappenedOnce)
            {
                if (Vector3.Angle(Player.forward, transform.position - Player.position) < 110) //finds angle between 2 vectors
                {
                    capScreen.StartFading = true;
                    capScreen.IsCapturing = true;
                    //StartCoroutine(camShake.Shake(.15f, .7f));
                }
            }

            if (timer > MaxTimer + 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
