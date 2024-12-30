using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    [SerializeField] public string SceneTitle;
    [SerializeField] private float sliderMinValue;
    [SerializeField] private float sliderMaxValue;
    [SerializeField] private float sliderDefaultFloorValue;
    [SerializeField] private float sliderDefaultTopValue;


    [SerializeField] private CameraController cameraCtrl;

    [SerializeField] private int nextScene;
    [SerializeField] private int previousScene;

    private bool isChangingScene;

    // Start is called before the first frame update
    void Start()
    {
        float _sliderValue = GameManager.Instance.GetSliderValue();

        if (_sliderValue < sliderMinValue)
        {
            JumpToScene(previousScene);
            Debug.Log("Has to change to previous scene");
            return;
        }

        if (_sliderValue > sliderMaxValue)
        {
            JumpToScene(nextScene);
            Debug.Log("Has to change to next scene");
            return;
        }

        GameManager.Instance.SetScene(this);

        Transition.Instance.DoDisolve();
        float position = Mathf.InverseLerp(sliderMinValue, sliderMaxValue, _sliderValue);

        Debug.Log("slider position relative : " + position);
        if (position < 0.5)
            GameManager.Instance.SetSliderValue(sliderDefaultFloorValue);
        else
            GameManager.Instance.SetSliderValue(sliderDefaultTopValue);

        isChangingScene = false;
    }

    public void CheckZoomValue(float _zoom)
    {
        Debug.Log("Checking zoom value: "+_zoom);
        if (isChangingScene)
            return;

        if (_zoom < sliderMinValue)
        {
            if (previousScene >= 0)
                ChangeScene(previousScene);
            return;
        }

        if (_zoom > sliderMaxValue)
        {
            if (nextScene <= 3)  
                ChangeScene(nextScene);
            return;
        }

        if (cameraCtrl != null)
            cameraCtrl.SetZoom(Mathf.InverseLerp(sliderMinValue, sliderMaxValue, _zoom));
    }

    private void ChangeScene(int _scene)
    {
        isChangingScene = true;
        SceneChanger.Instace.ChangeScene(_scene);
    }
    private void JumpToScene(int _scene)
    {
        isChangingScene = true;
        SceneChanger.Instace.JumpScene(_scene);
    }
}
