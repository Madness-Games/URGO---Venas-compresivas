using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float rotationSpeedMultiplier = 1;
    private bool isSwipping;
    private bool isTouching;

    private Vector2 lastFramePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        isSwipping = true;
        isTouching = false;
        if (lastFramePosition == Vector2.zero)
            lastFramePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!isTouching)
            {
                lastFramePosition = Vector2.zero;
                isSwipping = false;
            }
        }

        if (Input.touchCount > 0)
        {
            isSwipping = true;
            isTouching = true;
            if (lastFramePosition == Vector2.zero)
                lastFramePosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount == 0)
        {
            if (isTouching)
            {
                lastFramePosition = Vector2.zero;
                isSwipping = false;
            }
        }

        if (!isSwipping)
            return;

        float _deltaPosition = 0;

        if (isTouching)
        {
            _deltaPosition = lastFramePosition.x - Input.GetTouch(0).position.x;
            lastFramePosition = Input.GetTouch(0).position;
        } else 
        {
            _deltaPosition = lastFramePosition.x - Input.mousePosition.x;
            lastFramePosition = Input.mousePosition;
        }

        transform.Rotate(new Vector3(0,_deltaPosition * rotationSpeedMultiplier,0));
    }
}
