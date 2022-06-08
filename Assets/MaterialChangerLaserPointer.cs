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
        SetChildRendererCol(Color.white, Color.black, -0.1f);
        AllGuiVagonsPanels = GameObject.Find("CanvasOnHand").GetComponent<VagonSelector>() ;
        allColls = GameObject.FindObjectsOfType<MaterialChangerLaserPointer>(); 
        bodies = GetComponentsInChildren<MeshCollider>();
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
  public void MatLernInv() {
        for (int i = 0; i < 99; i++)
            Invoke(nameof(MatLern), 0.5f * i ); 
    }
    void MatLern()    { SetChildRendererCol(Color.white, Color.green, 1); }
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
    public VagonSelector AllGuiVagonsPanels;
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
                Hold = true; //если Hold тру то ответ верный если фалс то не верный
                once = false;  //Hold = Hold ? false : true;
                SetChildRendererCol(Color.magenta, Color.magenta, 2); // при зажатии выделяем ораньжевым
                PressedFuncs?.Invoke();
            }

        }
        else if (hovers.Count > 0)
        {
            once = true; onceB = true;
            // targetMat = Hovered; 

            SetChildRendererCol(Color.cyan, Color.blue, 1);
            HoveredFuncs?.Invoke();
        }
        else
        {

            if (onceB)
            {

                onceB = false;
                if (SelectedHold) 
                {
                    if (Hold)
                    { 
                        OutlCol = Color.white; w = 2;
                        Invoke(nameof(TestQuestionTruestFunc),0.001f);
                        // отключили все коллайдеры всей сцены всех активных элементов только если окно открыто Invoke(nameof(EnabAllColls), 0.5f);// это жесткий костыль принудительное включение
                        for (int i = 0; i < AllGuiVagonsPanels.GuiVagons.Length; i++)
                            if (AllGuiVagonsPanels.GuiVagons[i].activeSelf == false)
                                DisableAllColiders(true);
                        for (int i = 0; i < AllGuiVagonsPanels.GuiVagons.Length; i++)
                            if (AllGuiVagonsPanels.GuiVagons[i].activeSelf == true)
                                DisableAllColiders(false);
                        
                    }
                    else
                    {
                        SetChildRendererCol(Color.white, Color.black, -0.1f);// OutlCol = Color.red; w = 3;

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
    public string TestQuestionTruest = "white"; // правильность ответа на тест по конкретному элементу
    public void TestQuestionTruestFunc(string ColorBOOL)// правильный цвет именно тут 
    {
// ЕСЛИ требуется отметить что правильно а что нет лишь в конце то запоминаем этот бул на каждом эелементе и запускаем функцию присвоения цвета после прохождения по тагу в цикле всем эелементам
        TestQuestionTruest = ColorBOOL; // все что ниже убираем если хотем в конце запускать функцию
        if (ColorBOOL == "white") SetChildRendererCol(Color.white, Color.white, 2);
        if (ColorBOOL == "green") SetChildRendererCol(Color.white, Color.green, 2);
        if (ColorBOOL == "red")     SetChildRendererCol(Color.red, Color.red, 4);
        //DisableAllColiders(true);
    }
    public void TestQuestionTruestFunc() // отложенная функция вызываем вконце чтобы расставить цвета
    {
        if (TestQuestionTruest == "white") SetChildRendererCol(Color.white, Color.white, 2);
        if (TestQuestionTruest == "green") SetChildRendererCol(Color.white, Color.green, 2);
        if (TestQuestionTruest == "red") SetChildRendererCol(Color.red, Color.red, 4);
    }
    void EnabAllColls() { DisableAllColiders(true);  }
    MaterialChangerLaserPointer[] allColls;
    public void DisableAllColiders(bool isOn) // отключим все коллайдеры
    {//MaterialChangerLaserPointer[] allColls = GameObject.FindObjectsOfType<MaterialChangerLaserPointer>();
         
        for (int i = 0; i < allColls.Length; i++)
            allColls[i].disableThisColider(isOn);
    }
    MeshCollider[] bodies;
    void disableThisColider(bool isOn) // отключим коллайдер
    { // MeshCollider[] bodies = GetComponentsInChildren<MeshCollider>();
         
        foreach (MeshCollider body in bodies)
        {
            body.enabled = isOn;
        }
    }
    void EnabColiders() // включем  коллайдер
    { disableThisColider(true); }
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
