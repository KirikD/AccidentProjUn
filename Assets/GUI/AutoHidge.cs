using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHidge : MonoBehaviour
{
    public float timeH = 4;
    void Awake()
    {
        Invoke(nameof(HidgeTime), timeH);
    }
    void OnEnable()
    {
        Invoke(nameof(HidgeTime), timeH);
    }
    // Update is called once per frame
    void HidgeTime()
    {
        this.gameObject.SetActive(false);
    }
    public void TimeSetToPoint()
    {
      GameObject point =  GameObject.Find("PointTimeSet");
        GameObject TimePanel = GameObject.Find("TimePanelP");
        TimePanel.transform.position = point.transform.position;
        TimePanel.transform.rotation = point.transform.rotation;
        
    }
    public void StopTime()
    {
        GameObject TimePanel = GameObject.Find("TimePanelP");
        Destroy(TimePanel.GetComponent<TimerToEndGame>());
    }
    }
