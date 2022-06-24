using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimplePererascet : MonoBehaviour
{
    public Text[] AutoReorderToggles;
    int numTog = 0;
    void SetPereschet()
    {
        numTog  = 0 ;
        int children = transform.childCount;
        AutoReorderToggles = new Text[children];
        for (int i = 0; i < children; ++i)
        {
            AutoReorderToggles[i] = transform.GetChild(i).GetChild(1).GetComponent<Text>();
            if (AutoReorderToggles[i].transform.parent.GetComponent<Toggle>().interactable)
            {
                numTog++;
                   AutoReorderToggles[i].text = "" + numTog; print("For AutoReorderToggles: " + transform.GetChild(i));
            }
            
        }
        for (int ii = 0; ii < children; ++ii)
        { AutoReorderToggles[ii].transform.parent.GetComponent<Toggle>().interactable = true; }
    }

    // Update is called once per frame
    void OnEnable()
    {
        SetPereschet();
    }
}
