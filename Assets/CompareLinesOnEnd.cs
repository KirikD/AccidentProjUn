using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompareLinesOnEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Text TryLine;
    public Text SelectedLine;
    public Image CangeColor;
    // Update is called once per frame
    void Update()
    {
        if (TryLine.text == SelectedLine.text)
            CangeColor.color = Color.white;
        else
            CangeColor.color = Color.red;
    }
}
