using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform minZoom;
    [SerializeField] private Transform maxZoom;

    public void SetZoom(float _value)
    {
        transform.position = Vector3.Lerp(minZoom.position, maxZoom.position, _value);
    }
}
