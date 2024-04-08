using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    [SerializeField] private float fadeTime = 1;

    public delegate void OnHideComplete();
    public event OnHideComplete onHideComplete;

    public delegate void OnShowComplete();
    public event OnShowComplete onShowComplete;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();

        canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    public void FadeInTrigger()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOutTrigger()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    public IEnumerator FadeIn()
    {
        float _t = 0;

        while (_t < fadeTime)
        {
            _t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, _t / fadeTime);
            yield return null;
        }
        onHideComplete?.Invoke();
    }
    public IEnumerator FadeOut()
    {
        float _t = 0;

        while (_t < fadeTime)
        {
            _t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, _t / fadeTime);
            yield return null;
        }
        onShowComplete?.Invoke();
    }
}
