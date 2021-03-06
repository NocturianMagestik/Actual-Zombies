﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HSlotItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Transform originalparent;

    Vector3 startposition;
    Item currentitem;
    Item newitem;


    public void Awake()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startposition = transform.position;
        originalparent = transform.parent.parent;
        transform.SetParent(transform.parent.parent.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startposition;
        transform.SetParent(originalparent.GetChild(0));
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            Debug.Log("Dropping onto Floor");
        }
        Inventory.instance.onItemChangedCallback.Invoke();
        Hotbar.instance.onItemChangedCallback.Invoke();
    }
}
