using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeScript : MonoBehaviour
{
    public Image curtain;
    [Range(0, 1)]
    public float fadeSpeed = 0.1f;

    public UnityEvent OnFinishFade;

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    IEnumerator Fade(float firstVal, float lastVal)
    {
        float currentVal;

        currentVal = firstVal;
        curtain.color = new Color(curtain.color.r, curtain.color.b, curtain.color.g, currentVal);

        while (currentVal != lastVal)
        {
            yield return new WaitForEndOfFrame();
            currentVal = Mathf.Lerp(firstVal, lastVal, currentVal + fadeSpeed);
            curtain.color = new Color(curtain.color.r, curtain.color.b, curtain.color.g, currentVal);
        }

        OnFinishFade.Invoke();
    }
}
