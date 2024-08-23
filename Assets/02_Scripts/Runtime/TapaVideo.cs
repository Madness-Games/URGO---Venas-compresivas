using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class TapaVideo : MonoBehaviour
{
    private CanvasGroup canvas;
    [SerializeField] private float duration;

    private void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        StartCoroutine(HideSequence());
    }

    public void Show()
    {
        StartCoroutine(ShowSequence());
    }
    IEnumerator HideSequence()
    {
        float _t = 0;

        canvas.interactable = false;
        canvas.blocksRaycasts = false;

        while (_t < duration)
        {
            _t += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(1, 0, _t / duration);
            yield return null;
        }
    }

    IEnumerator ShowSequence()
    {
        float _t = 0;

        canvas.interactable = true;
        canvas.blocksRaycasts = true;

        while (_t < duration)
        {
            _t += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(0, 1, _t / duration);
            yield return null;
        }
    }
}
