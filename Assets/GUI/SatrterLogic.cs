using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SatrterLogic : MonoBehaviour
{
    GameObject player;
    [Header("Окна начального интерфейса")]
    public GameObject StartGame, TextPanel, ShodPanel, NapravleniePanel, OsnastPanel, OsnastPanel2, TestPanelA, TestPanelB, TestPanelC, TestPanelD, EndTestPanel;
    void Start()
    {
         player = GameObject.Find("Player");
        playerCam = Camera.main.transform;
        panelCanvas = GameObject.Find("CanvasOnHand").transform;

    }
    [Header("Текст окончания теста в конце теста")]
    public Text EndTextTest;
    [Header("Кнопочка продолжить тест и вернуться назад")]
    public GameObject NextBtt, TestAgain;
    public void TestResults()
    {
        int MistakesCount = 0;
        for (int i = 0; i < loot.Count; i++)
        {
            for (int ii = 0; ii < loot.Count; ii++)
            {
                Debug.Log(i+" "+loot[i].questionsObjs[ii].isOn +" + " + loot[i].questTrues[ii]);
                if (loot[i].questionsObjs[ii].isOn != loot[i].questTrues[ii])
                {
                    MistakesCount += 1; 
                }                
            }
        }
        Debug.Log("MistakesCount "  + MistakesCount/2);
        EndTextTest.text = "Вы не прошли тест и допустили " + (MistakesCount/2) + " ошибки ";
        if (MistakesCount/2 == 1)   EndTextTest.text = "Вы не прошли тест и допустили " + (MistakesCount / 2) + " ошибку ";
        if (MistakesCount == 0)
        {
            EndTextTest.text = "Тест пройден. Для прололжения нажмите кнопку Далее";
            NextBtt.SetActive(true);
        }
        else
        { TestAgain.SetActive(true); }
    }
    [Header("Костыль притягивающий интерфейс к руке если мы далеко отошли от него")]
    public Transform playerCam;
    public Transform panelCanvas;
    public ControllerFeedback controllerFeedback;
    void Update()
    {
        if (Vector3.Distance(playerCam.position, panelCanvas.position) > 2)
        { controllerFeedback.AttactToHand(); }
    }
        public void DragAvaterTo3DgameScen(Transform pos) // просто передвигаем плеера в старт игры ивсе
    {
       
        player.transform.position = pos.position;
    }
    public List<LootDrop> loot = new List<LootDrop>();
    [System.Serializable]
    public class LootDrop
    {
        public string name;
        public Toggle[] questionsObjs;
        public bool[] questTrues;

    }
}
