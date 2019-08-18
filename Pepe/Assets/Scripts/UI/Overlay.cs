using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    public Image image;

    private const float fadeStepAmount = 0.1f;
    private const float fadeStepDuration = 0.05f;

    public IEnumerator FadeIn()
    {
        while(image.color.a < 1f)
        {
            Color color = image.color;
            color.a += fadeStepAmount;
            if (color.a > 1f)
                color.a = 1f;
            image.color = color;
            yield return new WaitForSeconds(fadeStepDuration);
        }
    }

    public IEnumerator FadeOut()
    {
        while (image.color.a > 0f)
        {
            Color color = image.color;
            color.a -= fadeStepAmount;
            if (color.a < 0f)
                color.a = 0f;
            image.color = color;
            yield return new WaitForSeconds(fadeStepDuration);
        }
    }
}
