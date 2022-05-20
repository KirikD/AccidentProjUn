//========= Copyright 2016-2022, HTC Corporation. All rights reserved. ===========

using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
// This component shows the status that interacting with ColliderEventCaster
public class MaterialChangerLaserPointer : MonoBehaviour
    , IColliderEventHoverEnterHandler
    , IColliderEventHoverExitHandler
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler
{
    private readonly static List<Renderer> s_rederers = new List<Renderer>();
    // gameObject.GetComponent<Renderer> ().material.color = Color.green;
    [NonSerialized]
    private Material currentMat;
    public UnityEvent StartsFuncs;
    public UnityEvent HoveredFuncs;
    public UnityEvent PressedFuncs;
    public UnityEvent HoveredEndFuncs;
    Material Normal;

    Material Hovered;
    Material Pressed;
    Material dragged;

    [Obsolete("Use hovered instead")]
    public Material Heightlight { get { return Hovered; } set { Hovered = value; } }

    [Obsolete]
    [HideInInspector]
    public ColliderButtonEventData.InputButton heighlightButton = ColliderButtonEventData.InputButton.Trigger;

    private HashSet<ColliderHoverEventData> hovers = new HashSet<ColliderHoverEventData>();
    private HashSet<ColliderButtonEventData> presses = new HashSet<ColliderButtonEventData>();
    private HashSet<ColliderButtonEventData> drags = new HashSet<ColliderButtonEventData>();

    [Obsolete]
    public static void SetAllChildrenHeighlightButton(GameObject parent, ColliderButtonEventData.InputButton button)
    {
        var matChangers = ListPool<MaterialChangerLaserPointer>.Get();
        parent.GetComponentsInChildren(matChangers);
        for (int i = matChangers.Count - 1; i >= 0; --i) { matChangers[i].heighlightButton = button; }
        ListPool<MaterialChangerLaserPointer>.Release(matChangers);
    }
    float[] currWidth;
    private void Start()
    {
        GetComponentsInChildren(true, s_rederers);
        if (s_rederers.Count > 0)
        {
            currWidth = new float[s_rederers.Count];
            for (int i = s_rederers.Count - 1; i >= 0; --i)
            {
                currWidth[i] = s_rederers[i].material.GetFloat("_ASEOutlineWidth");
            }
        }

        StartsFuncs?.Invoke();
        UpdateMaterialState();
    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        hovers.Add(eventData);

        UpdateMaterialState();
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        hovers.Remove(eventData);

        UpdateMaterialState();
    }

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        for (int i = eventData.pressedRawObjects.Count - 1; i >= 0; --i)
        {
            if (gameObject == eventData.pressedRawObjects[i] || eventData.pressedRawObjects[i].transform.IsChildOf(transform))
            {
                presses.Add(eventData);
            }
        }

        // check if this evenData is dragging me(or ancestry of mine)
        for (int i = eventData.draggingHandlers.Count - 1; i >= 0; --i)
        {
            if (gameObject == eventData.draggingHandlers[i] || transform.IsChildOf(eventData.draggingHandlers[i].transform))
            {
                drags.Add(eventData);
                break;
            }
        }

        UpdateMaterialState();
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        presses.Remove(eventData);
        drags.Remove(eventData);

        UpdateMaterialState();
    }

    private void LateUpdate()
    {
        UpdateMaterialState();
    }

    private void OnDisable()
    {
        hovers.Clear();
        presses.Clear();
        drags.Clear();
    }
    [FormerlySerializedAs("Если стоит то мы можем выделить красным наш обжект")]
    public bool SelectedHold; bool Hold = false; bool once = true; bool onceB = true;
    public void UpdateMaterialState()
    {
        Color OutlCol = Color.black;
        float w = -0.5f;
        Material targetMat;
        targetMat = Normal;
        if (drags.Count > 0)
        {
            // targetMat = dragged; 
            //SetChildRendererCol(Color.green, Color.red, 0.01f);
        }
        else if (presses.Count > 0)
        {
            // targetMat = Pressed; 

            //Hold = !Hold;

            if (once)
            {
                once = false; Hold = Hold ? false : true;
                SetChildRendererCol(Color.red, Color.red, 2);
                PressedFuncs?.Invoke();
            }

        }
        else if (hovers.Count > 0)
        {
            once = true; onceB = true;
            // targetMat = Hovered; 

            SetChildRendererCol(Color.yellow, Color.green, 1);
            HoveredFuncs?.Invoke();
        }
        else
        {
            if (onceB)
            {

                onceB = false;
                if (SelectedHold) 
                { 
                    if (Hold) {
                        OutlCol = Color.red; w = 3;
                        disableColiders();
                    }
                    else
                    {
                        OutlCol = Color.black; w = -0.01f; 
                    }
                }
                SetChildRendererCol(Color.white, OutlCol, w);
                HoveredEndFuncs?.Invoke();
            }
        }

        /* if (ChangeProp.Set(ref currentMat, targetMat))
         {
             SetChildRendererMaterial(targetMat);
         }*/
    }
    void disableColiders() // отключим все коллайдеры
    {
        MeshCollider[] bodies = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider body in bodies)
        {
            body.enabled = false;
        }
    }

    private void SetChildRendererCol(Color targetCol, Color outlColor, float width)
    {
        GetComponentsInChildren(true, s_rederers);

        if (s_rederers.Count > 0)
        {
            for (int i = s_rederers.Count - 1; i >= 0; --i)
            { // s_rederers[i].sharedMaterial.color = targetCol;
                List<Material> myMaterials = s_rederers[i].materials.ToList();
                Material[] tmpMat = new Material[myMaterials.Count];
                for (int ii = 0; ii < myMaterials.Count; ii++)
                {
                   
                    tmpMat[ii] = myMaterials[ii];
                    tmpMat[ii].SetColor("_Color", targetCol);
                    tmpMat[ii].SetColor("_ASEOutlineColor", outlColor);
                    tmpMat[ii].SetFloat("_ASEOutlineWidth", currWidth[i] * width);

                }
                s_rederers[i].GetComponent<Renderer>().materials = tmpMat;
                //s_rederers[i].material.SetColor("_Color", targetCol);
                //s_rederers[i].material.SetColor("_ASEOutlineColor", outlColor);
                //s_rederers[i].material.SetFloat("_ASEOutlineWidth", currWidth[i] * width );
            }

            s_rederers.Clear();
        }
    }
    private void SetChildRendererMaterial(Material targetMat)
    {
        GetComponentsInChildren(true, s_rederers);

        if (s_rederers.Count > 0)
        {
            for (int i = s_rederers.Count - 1; i >= 0; --i)
            {
                s_rederers[i].sharedMaterial = targetMat;
            }

            s_rederers.Clear();
        }
    }
}
