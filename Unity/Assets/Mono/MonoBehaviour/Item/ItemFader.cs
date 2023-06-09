using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof (SpriteRenderer))]
public class ItemFader: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 逐渐恢复颜色
    /// </summary>
    public void FadeIn()
    {
        Color targetColor = new Color(1, 1, 1, 1);
        this.spriteRenderer.DOColor(targetColor, Settings.fadeDuration);
    }

    public void FadeOut()
    {
        Color targetColor = new Color(1, 1, 1, Settings.targetAlpha);
        this.spriteRenderer.DOColor(targetColor, Settings.fadeDuration);
    }
}