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
           // Invoke(nameof(InvokeEnter), Dauly);
            CollFuncsEnter?.Invoke();
        }
    }
    void InvokeEnter() { CollFuncsEnter?.Invoke(); }
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
