using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    [SerializeField] public string SceneTitle;
    [SerializeField] private float sliderMinValue;
    [SerializeField] private float sliderMaxValue;

    [SerializeField] private CameraController cameraCtrl;

    [SerializeField] private string nextScene;
    [SerializeField] private string previousScene;

    private bool isChangingScene;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetScene(this);
        isChangingScene = false;
    }

    public void CheckZoomValue(float _zoom)
    {
        if (isChangingScene)
            return;

        if (_zoom < sliderMinValue)
        {
            if (previousScene != null)
                ChangeScene(previousScene);
            return;
        }

        if (_zoom > sliderMaxValue)
        {
            if (nextScene != null)  
                ChangeScene(nextScene);
            return;
        }

        if (cameraCtrl != null)
            cameraCtrl.SetZoom(Mathf.InverseLerp(sliderMinValue, sliderMaxValue, _zoom));
    }

    private void ChangeScene(string _scene)
    {
        isChangingScene = true;

        SceneChanger.Instace.ChangeScene(_scene);
    }
}
