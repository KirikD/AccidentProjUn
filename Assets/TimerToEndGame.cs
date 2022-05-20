using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerToEndGame : MonoBehaviour
{
    [Header("Ёлемент текст")]  [Tooltip("—колько до конца секунд")]
    public Text TimerTxt;
    [Header("—колько до конца секунд")] [Tooltip("—колько до конца секунд")]
    public float totalTime = 120f; //2 minutes

    private void Update()
    {
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime);
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        TimerTxt.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    void Start()
    {
        
    }

}
