using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ������ ������� ��������� ���������� ������ finalScoreVagons
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
        if (TeleportPointsCounter > 15 && TeleportPointsCounter > 12) // ������� ��� �� ������ ��������� ������ �������
        {
            preFinalPanel.SetActive(true);
            preFinalPanelTitle.text = "�� �������� ��� ������������� " + TeleportPointsCounter + " � ������ ��� " + TeleportPointsCounter + "�����!";
            preFinalUndoBtt.SetActive(false); preFinalNextBtt.SetActive(true);
        }
        else
        {
            preFinalPanel.SetActive(true);
            preFinalPanelTitle.text = "�� ������ ����� " + TeleportPointsCounter + " �� 15 � ��� �� �� ��������� �������� ������������� �� " + TeleportPointsCounter + " � �� �������� �����";
            preFinalUndoBtt.SetActive(true); preFinalNextBtt.SetActive(false);
        }

    }

    }
