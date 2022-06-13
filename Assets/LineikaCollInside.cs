using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineikaCollInside : MonoBehaviour
{
    public UnityEvent StartFuncsEnter;
    public UnityEvent CollFuncsEnter;
    public UnityEvent CollFuncsExit;
    public int lauer =7; public float Dauly = 1;
    void Start()
    {
        StartFuncsEnter?.Invoke();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == lauer)
        {
            Invoke(nameof(InvokeEnter), 11);
            CollFuncsEnter?.Invoke();
        }
    }
    void InvokeEnter() { Destroy(this.gameObject); } // очень тупой костыль удаляем обж после 16 секунд с ним взаимодействия чтоб он не занимал очередь...
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == lauer)
        {
           // Invoke(nameof(InvokeExit), Dauly*1.25f);
            CollFuncsExit?.Invoke();
        }
    }
    void InvokeExit() { CollFuncsExit?.Invoke(); }

}
