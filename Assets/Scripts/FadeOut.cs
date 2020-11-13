using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeOut : MonoBehaviour
{
    public bool IsFading;

    public RawImage image;
    public RawImage colorMultiplier;
    private float timer;
    private Color color;
    private Color color2;
    private bool IsCounting;

    void Start()
    {
        color = image.color;
        color.a = 0;
        image.color = color;

        color2 = colorMultiplier.color;
        color2.a = 0;
        colorMultiplier.color = color2;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFading)
        {
            color.a = 1f;
            image.color = color;

            color2.a = 0.75f; //add some transparency to see the screenshot
            colorMultiplier.color = color2;

            image.enabled = true;
            colorMultiplier.enabled = true;
            IsCounting = true;
            IsFading = false;
        }

        if (IsCounting)
        {
            timer += Time.deltaTime;

            if (timer > 4) //effectlength
            {
                color.a -= Time.deltaTime * 0.1f;
                image.color = color;

                color2.a -= Time.deltaTime * 0.05f;
                colorMultiplier.color = color2;

                if (image.color.a <= 0)
                {
                    timer = 0;
                    IsCounting = false;
                }
            }
        }
        else
        {
            image.enabled = false;
            colorMultiplier.enabled = false;
        }
    }
}
