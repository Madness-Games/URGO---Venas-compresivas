using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PinchController : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Texture DefaultTexture;
    [SerializeField] private Texture PinchTexture;
    [SerializeField] private VideoPlayer vpDefault;
    [SerializeField] private VideoPlayer vpPinch;

    [SerializeField] private RawImage defaultImage;
    [SerializeField] private RawImage pinchImage;

    private Vector2 curDist;
    private Vector2 prevDist;
    private float touchDelta;
    private float speedTouch0;
    private float speedTouch1;
    private float minPinchSpeed;
    private float varianceInDistances;

    // Start is called before the first frame update
    void Start()
    {
        ShowPressed(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
            prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
            touchDelta = curDist.magnitude - prevDist.magnitude;
            speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
            speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

            if ((touchDelta + varianceInDistances <= 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
            {
                ShowPressed(false);
            }

            if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
            {
                ShowPressed();               
            }
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            ShowPressed(false);
        }
    }

    public void ShowPressed(bool _b = true)
    {
        int _i = _b ? 1 : 0;

        if (_b)
        {
            defaultImage.enabled = false;
            pinchImage.enabled = true;
        } 
        else
        {
            defaultImage.enabled = true;
            pinchImage.enabled = false;
        }
    }
}
