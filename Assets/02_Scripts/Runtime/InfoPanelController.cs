using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class InfoPanelController : MonoBehaviour
{
    private bool isActive;
    private CanvasGroup canvasGroup;
    [SerializeField] float fadeTime = 0.2f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void SetActive(bool _active = true)
    {
        isActive = _active;
        if (_active)
            StartCoroutine(fadeIn());
        else
            StartCoroutine(fadeOut());
    }

    IEnumerator fadeIn()
    {
        float _t = 0;
        float _initialAlpha = canvasGroup.alpha;

        while (_t< fadeTime)
        {
            _t += Time.deltaTime;
            float _alpha = Mathf.Lerp(_initialAlpha, 1, _t / fadeTime);
            canvasGroup.alpha = _alpha;
            yield return null;
        }
        canvasGroup.blocksRaycasts = true;
    }

    IEnumerator fadeOut()
    {
        float _t = 0;
        float _initialAlpha = canvasGroup.alpha;

        canvasGroup.blocksRaycasts = false;

        while (_t < fadeTime)
        {
            _t += Time.deltaTime;
            float _alpha = Mathf.Lerp(_initialAlpha, 0, _t / fadeTime);
            canvasGroup.alpha = _alpha;
            yield return null;
        }
    }
}
