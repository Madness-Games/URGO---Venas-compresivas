using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instace;

    [SerializeField] public FadeController fade;
    [SerializeField] private float fadeTime;
    [SerializeField] private MenuManager menu;

    private int nextScene;
    public int previousScene;
    
    AsyncOperation loading;

    public bool isSceneActive { get; private set; }
    private void Awake()
    {
        if (Instace == null) { Instace = this; } else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(fade.FadeOut());
    }

    private void Update()
    {
        if (loading == null)
            return;
    }
    public void ChangeScene(int _scene)
    {
        previousScene = nextScene;
        nextScene = _scene;
        if (nextScene > previousScene)
        {
            Transition.Instance.Setup(previousScene);
            Transition.Instance.DoTransitionForward();
            Debug.Log("Forward");
        } else
        {
            Transition.Instance.Setup(nextScene);
            Transition.Instance.DoTransitionBackward();
            Debug.Log("Backward");
        }
        StartCoroutine(fade.FadeIn());
        fade.onHideComplete += LoadScene;
        menu.SetInactive();
    }

    public void ChangeSceneExtra(int _scene)
    {

        if (nextScene > _scene)
        {
            Transition.Instance.Setup(nextScene);
            Transition.Instance.DoTransitionForward();
            Debug.Log("Forward");
        }
        else
        {
            Transition.Instance.Setup(nextScene);
            Transition.Instance.DoTransitionBackward();
            Debug.Log("Backward");
        }

        nextScene = _scene;

        StartCoroutine(fade.FadeIn());
        fade.onHideComplete += LoadScene;
        menu.SetInactive();
    }

    private void LoadScene()
    {
        Debug.Log("Load Scene");
        loading = SceneManager.LoadSceneAsync(nextScene);
        loading.completed += Loading_completed;
    }

    private void Loading_completed(AsyncOperation obj)
    {
        Debug.Log("Loading complete");
        Transition.Instance.DoDisolve();
        StartCoroutine(fade.FadeOut());
        fade.onShowComplete += menu.SetActive;
        fade.onHideComplete -= LoadScene;
    }

    private void SetSceneLoadedAndActive()
    {
        isSceneActive = true;
    }
}
