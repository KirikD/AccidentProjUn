using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerToEndGame : MonoBehaviour
{
    [Header("Ёлемент текст")]  [Tooltip("—колько до конца секунд")]
    public Text TimerTxt;
    [Header("—колько до конца секунд")] [Tooltip("—колько до конца секунд")]
    public float totalTime = 900f; //2 minutes
    public float ForwardTime = 9000f;
    public Text TimeCur;
    private void Update()
    {
        totalTime -= Time.deltaTime; 
        UpdateLevelTimer(totalTime);

        ForwardTime += Time.deltaTime;
        TimeCur.text = FormatSeconds(ForwardTime);

        if (totalTime < 60)
            TimerTxt.color = Color.red;
        if (totalTime < 0.3f)
            TimerTxt.color = Color.red;
    }
    void RestartAllGame() 
    {
     
    }
    string FormatSeconds(float elapsed)
    {
        elapsed = Mathf.Max(0, elapsed - Time.deltaTime);
        var timeSpan = System.TimeSpan.FromSeconds(elapsed);
        return   timeSpan.Hours.ToString("00") + ":" +
                        timeSpan.Minutes.ToString("00") + ":" +
                        timeSpan.Seconds.ToString("00") + "." +
                        timeSpan.Milliseconds / 100;
        //return string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hours, hours, minutes, seconds);
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
