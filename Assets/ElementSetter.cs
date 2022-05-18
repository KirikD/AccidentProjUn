using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ElementSetter : MonoBehaviour
{
    public delegate void SetTogleFieldsToArry(string vagName);
    public static event SetTogleFieldsToArry OnSelectedEvent;

    void Start()
    {
       
    }
    public void ChangeElemUiName()
    {
        //  string[] array = xyz.Split(' ');  
        OnSelectedEvent(this.transform.parent.gameObject.name + "#"+ this.gameObject.name); // выполнили эвент
         //Debug.Log("Нажали на обжект " + this.gameObject.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
