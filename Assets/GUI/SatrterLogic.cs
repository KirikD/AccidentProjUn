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
    }

    public Text EndTextTest;
    public void TestResults()
    {
        int MistakesCount = 0;
        for (int i = 0; i < loot.Count; i++)
        {
            for (int ii = 0; ii < loot.Count; ii++)
            {
                if (loot[i].questionsObjs[i].isOn != loot[i].questTrues[i])
                {
                    MistakesCount += 1; 
                }
                

            }

        }
        Debug.Log("MistakesCount "  + MistakesCount);
        EndTextTest.text = "MistakesCount " + MistakesCount;
    }
    //
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
