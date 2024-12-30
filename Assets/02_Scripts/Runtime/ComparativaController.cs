using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ComparativaController : MonoBehaviour
{
    [SerializeField] private VideoPlayer vp;
    [SerializeField] private Image whiteImg;

    private bool isFadeStarted;
    // Start is called before the first frame update
    void Start()
    {
        Transition.Instance.DoDisolve();
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.isPlaying)
        {
            if (!isFadeStarted)
                StartCoroutine(FadeOut(1f));
        }
    }

    public void Quit()
    {
        SceneChanger.Instace.ChangeScene(SceneChanger.Instace.previousScene);
    }

    public void Temps()
    {
        SceneChanger.Instace.ChangeSceneExtra(5);
    }

    public void Return()
    {
        SceneChanger.Instace.ChangeSceneExtra(4);
    }

    IEnumerator FadeOut(float _duration)
    {
        isFadeStarted = true;

        float _t = 0;
        float _alpha = 1;

        while (_t < _duration)
        {
            _t += Time.deltaTime;
            _alpha = Mathf.Lerp(1, 0, _t / _duration);
            whiteImg.color = new Color(whiteImg.color.r, whiteImg.color.g, whiteImg.color.b, _alpha);
            yield return null;
        }
    }
}
