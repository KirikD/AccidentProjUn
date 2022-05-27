using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandMadeDropDown : MonoBehaviour
{
    public GameObject DropList;
    public Text DropText;
    void Start()
    {
        DropList.SetActive(false);
    }
    [Header("���� ������ ���������")]
    public string[] dropTxt;
    [Header("��������� �������")] [Tooltip("��������� �������")]
    public int selectedNum; 
    public string selectedStr;
    public void SetNum(string dropT)
    {
        for (int i = 0; i < dropTxt.Length; i++)
        {
            if (dropTxt[i] == dropT)
            {
                Debug.Log(i + " Creating enemy number: " + dropT);
                selectedNum = i+1;
                selectedStr = dropT;
                DropText.text = dropT;
            }
            
        }
        DropList.SetActive(false);
        DropText.color = Color.black;
    }
    bool isOpenDropList;
    public void OpenCloseDropList() //booleanVar = !booleanVar;
    {
        HandMadeDropDown[] allDrops = GameObject.FindObjectsOfType<HandMadeDropDown>();
        for (int i = 0; i < allDrops.Length; i++)
            allDrops[i].DropList.SetActive(false);
       // isOpenDropList = isOpenDropList ? false : true;
       // if (isOpenDropList)
            DropList.SetActive(true);
       // else
       //     DropList.SetActive(false);
    }
}
