using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandMadeDropDown : MonoBehaviour
{
    public GameObject DropList;
    public Text DropText;
    Toggle[] ToglessAll;
    HandMadeDropDown[] allDrops;
    public bool setnull;
    void Start()
    {
        Debug.LogError("DropList " + gameObject.name);
        DropList.SetActive(false);
        ToglessAll = DropList.GetComponentsInChildren<Toggle>();

        if (setnull)
            DropText.text = "-"; DropText.color = Color.red;
    }
    [Header("¬есь список Ёлементов")]
    public string[] dropTxt;
    [Header("¬ыбранный Ёлемент")] [Tooltip("¬ыбранный Ёлемент")]
    public int selectedNum;
    public string selectedStr;

    public void SetNumT(Transform dropT)
    {  
      selectedStr = dropT.GetChild(1).GetComponent<Text>().text;
        DropText.text = dropT.GetChild(1).GetComponent<Text>().text;
    }
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

        for (int ii = 0; ii < AllLinesArr.Length; ii++) // когда выбрали скрываем все! BttHandMadeDropDownB
        {
            AllLinesArr[ii].interactable = true;
            AllLinesArr[ii].blocksRaycasts = true;
        }
        if (gameObject.name == "BttHandMadeDropDownB")
        {
            int TogVal = 0;
            int.TryParse(dropT, out TogVal);
            allDrops = GameObject.FindObjectsOfType<HandMadeDropDown>();
            for (int i = 0; i < allDrops.Length; i++)
            {
                //if (allDrops[i].DropList.transform.GetChild(TogVal).GetComponent<Toggle>().isOn == true)
                if (allDrops[i].gameObject.name == "BttHandMadeDropDownB")
                {
                    if(allDrops[i].ToglessAll[TogVal - 1].isOn == false)
                    allDrops[i].ToglessAll[TogVal - 1].interactable = false;
                    //  allDrops[i].ToglessAll[TogVal - 1].gameObject.SetActive(false); 
                }

            }
            GetComponent<HandMadeDropDown>().ToglessAll[TogVal - 1].interactable = true; // этот конкретный тогл.

            if (GetComponent<HandMadeDropDown>().ToglessAll[TogVal - 1].isOn == false)
            {
                for (int i = 0; i < allDrops.Length; i++)
                {   if (allDrops[i].gameObject.name == "BttHandMadeDropDownB")  {       allDrops[i].ToglessAll[TogVal - 1].interactable = true; } DropText.text = "0"; DropText.color = Color.red; }
            }
        }
    }
    bool isOpenDropList;

    public CanvasGroup[] AllLinesArr;
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
        // когда выбрали скрываем все!
        DropList.transform.SetParent(this.gameObject.transform.parent.parent.transform, true);
        for (int ii = 0; ii < AllLinesArr.Length; ii++)
        {
            AllLinesArr[ii].interactable = false;
            AllLinesArr[ii].blocksRaycasts = false;
        }
    }
}
