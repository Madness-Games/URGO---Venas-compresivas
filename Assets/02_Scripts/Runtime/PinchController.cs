using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchController : MonoBehaviour
{
    [SerializeField] private Material material;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            material.SetFloat("_Transition", 1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            material.SetFloat("_Transition", 0);
        }*/

        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
            prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
            touchDelta = curDist.magnitude - prevDist.magnitude;
            speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
            speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

            if ((touchDelta + varianceInDistances <= 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
            {
                material.SetFloat("_Transition", 0);
            }

            if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
            {
                material.SetFloat("_Transition", 1);                
            }
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            material.SetFloat("_Transition", 0);
        }
    }
}
