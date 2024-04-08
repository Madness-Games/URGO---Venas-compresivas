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

    private string nextScene;

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
    public void ChangeScene(string _scene)
    {
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
        StartCoroutine(fade.FadeOut());
        fade.onShowComplete += menu.SetActive;
        fade.onHideComplete -= LoadScene;
    }

    private void SetSceneLoadedAndActive()
    {
        isSceneActive = true;
    }
}
