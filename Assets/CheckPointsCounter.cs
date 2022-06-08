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
    public GameObject preFinalPanel; public GameObject preFinalNextBtt; public GameObject preFinalUndoBtt; public Text preFinalPanelTitle; public Text PanelTitle;
    public void ReaultsFinalScore()
    {
        Debug.Log(TeleportPointsCounter + "ReaultsFinalScore  " + gameObject.name);
        finalScoreVagons = vagonSelector.tryQuestions; //TeleportPointsCounter
        if (TeleportPointsCounter > 1 && finalScoreVagons > 12) // условие что мы прошли симулятор осмотр вагонов
        {
            preFinalPanel.SetActive(true);
            PanelTitle.text = "Результат прохождения осмотра неисправностей " + finalScoreVagons + " и прошли все " + TeleportPointsCounter + "точек!";
            preFinalPanelTitle.text = "Перейти к составлению плана АВР"; 
            preFinalUndoBtt.SetActive(false); preFinalNextBtt.SetActive(true);
        }
        else
        {
            preFinalPanel.SetActive(true);
            PanelTitle.text = "вы осмотрели всего " + TeleportPointsCounter + " точек из 15 а так же не правильно отметили неисправности их " + "40" + " а вы отметили всего " + finalScoreVagons;
            preFinalPanelTitle.text = "Не все неисправности определены верно. Повторно осмотрите вагоны элементы которых подсвечены красным ";
            preFinalUndoBtt.SetActive(true); preFinalNextBtt.SetActive(false);
        }

    }

    }
