using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragOnSurfaces = true;

    private Dictionary<int, GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();
    private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();
    public GameObject InsideContentA, InsideContentB;
    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = transform.parent == null ? null : transform.parent.GetComponentInParent<Canvas>();
        if (canvas == null) { return; }

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        var draggingIcon = new GameObject("icon");
        m_DraggingIcons[eventData.pointerId] = draggingIcon;

        draggingIcon.transform.SetParent(canvas.transform, false);
        draggingIcon.transform.SetAsLastSibling();

        var draggingImage = draggingIcon.AddComponent<Image>();
        // The icon will be under the cursor.
        // We want it to be ignored by the event system.
        var draggingGroup = draggingIcon.AddComponent<CanvasGroup>();
        draggingGroup.blocksRaycasts = false;
        draggingImage.sprite = GetComponent<Image>().sprite;

        var rectTransform = GetComponent<RectTransform>();
        draggingImage.SetNativeSize();
        draggingImage.rectTransform.sizeDelta = rectTransform.rect.size;

        m_DraggingPlanes[eventData.pointerId] = canvas.GetComponent<RectTransform>();

        SetDraggedPosition(eventData);
        draggingImage.rectTransform.localScale = Vector3.one * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons.ContainsKey(eventData.pointerId))
        {
            SetDraggedPosition(eventData);
        }
       
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        GameObject draggingIcon;
        if (!m_DraggingIcons.TryGetValue(eventData.pointerId, out draggingIcon)) { return; }

        var rectTransform = draggingIcon.GetComponent<RectTransform>();
        var raycastResult = eventData.pointerCurrentRaycast;
        if (dragOnSurfaces && raycastResult.isValid && raycastResult.worldNormal.sqrMagnitude >= 0.0000001f)
        {
            // When raycast hit something, place the dragged image at the hit position
            // Notice that if raycast performed by GraphicRaycaster module, worldNormal is not assigned (see GraphicRaycaster for more detail)
            rectTransform.position = raycastResult.worldPosition + raycastResult.worldNormal * 0.001f; // add a little distance to avoid z-fighting
            rectTransform.rotation = Quaternion.LookRotation(raycastResult.worldNormal, raycastResult.gameObject.transform.up);
            // rectTransform.localEulerAngles = Vector3.zero;
            rectTransform.localScale = Vector3.one*0.5f;
        }
        else
        {
            RectTransform plane;
            if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform is RectTransform)
            {
                plane = eventData.pointerEnter.transform as RectTransform;
            }
            else
            {
                plane = m_DraggingPlanes[eventData.pointerId];
            }

            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(plane, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                rectTransform.position = globalMousePos;
                rectTransform.rotation = plane.rotation;
            }
        }
    }
    GameObject ClonedIco;
    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons[eventData.pointerId] != null)
        {
            ClonedIco = m_DraggingIcons[eventData.pointerId];
            ClonedIco.transform.localEulerAngles = Vector3.zero;
            ClonedIco.layer = 5; // Пятый слой где UI чтобы оно было интерактивно
            Destroy(m_DraggingIcons[eventData.pointerId].GetComponent<CanvasGroup>());
            // Destroy(m_DraggingIcons[eventData.pointerId]);
            transform.position = ClonedIco.transform.position;
            transform.rotation = ClonedIco.transform.rotation;
            transform.localScale = ClonedIco.transform.localScale;
            Invoke(nameof(MyFuncAddBittonsInside),0.1f);
        }

        m_DraggingIcons[eventData.pointerId] = null;
        ClonedIco.GetComponent<RectTransform>().localScale = Vector3.one * 0.5f;
    }
    void MyFuncAddBittonsInside() 
    {
        //////////
        GameObject G1 = Instantiate(InsideContentA);
        G1.transform.SetParent(ClonedIco.transform, false);
        GameObject G2 = Instantiate(InsideContentB);
        G2.transform.SetParent(ClonedIco.transform, false);
        Destroy(ClonedIco);
        ///////////
    }

}
