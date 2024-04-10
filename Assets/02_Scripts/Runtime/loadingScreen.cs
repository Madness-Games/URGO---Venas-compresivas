using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class loadingScreen : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void FadeOut()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        float _t = 0;

        while (_t < fadeTime)
        {
            _t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, _t / fadeTime);
            yield return null;
        }

        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
