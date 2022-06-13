using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlaccTimeFix : MonoBehaviour
{

    public Text DropText;

    void Start()
    {
        DropText = GetComponent<Text>();
        DropText.color = Color.black;

        
    }
    void Update()
    {
        DropText.color = Color.black;
        Destroy(GetComponent<BlaccTimeFix>());

    }
    }
