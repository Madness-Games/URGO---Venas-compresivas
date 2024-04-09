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
    }

    public void SetZoom(float _value)
    {
        currentScene.CheckZoomValue(_value);
    }
}
