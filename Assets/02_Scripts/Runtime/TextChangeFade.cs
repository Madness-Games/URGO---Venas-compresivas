using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextChangeFade : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private float fadeTime;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void ChangeText(string _s)
    {
        StartCoroutine(changeTextSequence(_s));
    }

    IEnumerator changeTextSequence(string _s)
    {
        float _t = 0;
        float _alpha;

        while(_t < fadeTime)
        {
            _t += Time.deltaTime;
            _alpha = Mathf.Lerp(1, 0, _t / fadeTime);
            Debug.Log("ALPHA 01: "+_alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, _alpha);
            yield return null;
        }

        Debug.Log("ended fade out");

        text.text = _s;
        _t = 0;

        while (_t < fadeTime)
        {
            _t += Time.deltaTime;
            _alpha = Mathf.Lerp(0, 1, _t / fadeTime);
            text.color = new Color(text.color.r, text.color.g, text.color.b, _alpha);
            yield return null;
        }
        Debug.Log("ended fade in");

    }
}
