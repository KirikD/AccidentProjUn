using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// скрипт который финальные результаты выдает finalScoreVagons
public class CheckPointsCounter : MonoBehaviour
{
    public int TeleportPointsCounter = 0;
    void Start()
    {
        
    }
    public VagonSelector vagonSelector;
    public int finalScoreVagons = 0;
    // Update is called once per frame
    public void PointAdded(GameObject TeleportObj)
    {
        TeleportPointsCounter++;
        Debug.Log(TeleportPointsCounter + "PointAdded  " + TeleportObj.name);
        if (TeleportPointsCounter > 13) { }
    }
    public GameObject preFinalPanel; public GameObject preFinalNextBtt; public GameObject preFinalUndoBtt; public Text preFinalPanelTitle;
    public void ReaultsFinalScore()
    {
        finalScoreVagons = vagonSelector.tryQuestions; //TeleportPointsCounter
        if (TeleportPointsCounter > 15 && TeleportPointsCounter > 12) // условие что мы прошли симулятор осмотр вагонов
        {
            preFinalPanel.SetActive(true);
            preFinalPanelTitle.text = "вы отметили все неисправности " + TeleportPointsCounter + " и прошли все " + TeleportPointsCounter + "точек!";
            preFinalUndoBtt.SetActive(false); preFinalNextBtt.SetActive(true);
        }
        else
        {
            preFinalPanel.SetActive(true);
            preFinalPanelTitle.text = "вы прошли всего " + TeleportPointsCounter + " из 15 а так же не правильно отметили неисправности их " + TeleportPointsCounter + " а вы отметили всего";
            preFinalUndoBtt.SetActive(true); preFinalNextBtt.SetActive(false);
        }

    }

    }
