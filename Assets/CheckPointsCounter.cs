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

    public Text miniInteractResults;
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
        if (TeleportPointsCounter > 1 && finalScoreVagons > 12) // ������� ��� �� ������ ��������� ������ �������
        {
            preFinalPanel.SetActive(true);
            PanelTitle.text = "��������� ����������� ������� �������������� " + finalScoreVagons + " � ������ ��� " + TeleportPointsCounter + "�����!";
            preFinalPanelTitle.text = "������� � ����������� ����� ���"; 
            preFinalUndoBtt.SetActive(false); preFinalNextBtt.SetActive(true);
        }
        else
        {
            preFinalPanel.SetActive(true);
            PanelTitle.text = "�� ��������� ����� " + TeleportPointsCounter + " ����� �� 15 � ��� �� �� ��������� �������� ������������� �� " + "40" + " � �� �������� ����� " + finalScoreVagons;
            preFinalPanelTitle.text = "�� ��� ������������� ���������� �����. �������� ��������� ������ �������� ������� ���������� ������� ";
            preFinalUndoBtt.SetActive(true); preFinalNextBtt.SetActive(false);
        }

    }
    public void MiniInteractResultsF()
    {
        miniInteractResults.text ="���������= " + TeleportPointsCounter + "   �������= " + vagonSelector.tryQuestions;
    }
    }
