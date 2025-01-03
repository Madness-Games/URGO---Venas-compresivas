using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SceneType { main, vena, microcirculacion}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SceneType currentSceneType;
    private CurrentSceneManager currentScene;
    [SerializeField] private MenuManager menu;
    [SerializeField] private Slider slider;
    [SerializeField] private loadingScreen loading;

    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Destroy(this); }
        DontDestroyOnLoad(this);
    }
    public void SetScene(CurrentSceneManager _sceneManager)
    {
        currentScene = _sceneManager;
        menu.ChangeTitle(currentScene.SceneTitle);
        SetZoom(slider.value);
        HideLoading();
    }

    public void SetZoom(float _value)
    {
        currentScene.CheckZoomValue(_value);
    }

    public void HideLoading()
    {
        loading.FadeOut();
    }

    public void SetSliderValue(float _value)
    {
        slider.value = _value;
    }

    public float GetSliderValue()
    {
        return slider.value;
    }
}
