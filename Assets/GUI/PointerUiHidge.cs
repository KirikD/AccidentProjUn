using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUiHidge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject Pointer, Retice;
    // Update is called once per frame
    void Update()
    {
        if (Retice.activeSelf == true)
            Pointer.SetActive(false);
        else
            Pointer.SetActive(true);
    }
}
