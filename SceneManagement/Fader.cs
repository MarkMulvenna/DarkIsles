﻿using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeOutIn());
    }
    
    IEnumerator FadeOutIn()
    {
        yield return FadeOut(3f);
        yield return FadeIn(1f);
    }
    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }
    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
}
