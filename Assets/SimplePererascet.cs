using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePererascet : MonoBehaviour
{
    // При активации включаем перерасчет исходя из неактивных вариантов
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            print("For loop: " + transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
