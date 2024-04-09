using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class POIController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InfoPanelController info;
    [SerializeField] private SwapSprite swap;

    bool isActive;

    public static Action OnTurnOff;

    private void OnEnable()
    {
        OnTurnOff += DesactivatePOI;
    }

    private void OnDisable()
    {
        OnTurnOff -= DesactivatePOI;
    }

    void Start()
    {
        DesactivatePOI();
    }

    public void ActivatePOI()
    {
        info.SetActive(true);
        swap.SetActive(true);
        isActive = true;
    }

    public void DesactivatePOI()
    {
        info.SetActive(false);
        swap.SetActive(false);
        isActive = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool _hasToActivate = !isActive;

        OnTurnOff?.Invoke();

        if (_hasToActivate)
        {
            ActivatePOI();
        }
    }
}
