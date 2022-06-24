using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetFront : MonoBehaviour
{
    public Text SetFrontText;
    void Start()
    {
        Invoke(nameof(SetT), 0.59f);
     GetComponent<Text>().text = SetFrontText.text;
    }

    // Update is called once per frame
    void SetT()
    {
        GetComponent<Text>().text = SetFrontText.text;
        GetComponent<Text>().color = Color.black;
    }
}
