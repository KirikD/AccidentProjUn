using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndParametrsCoper : MonoBehaviour
{

    // Копируем из первых экранов настройки сюда
    [Header("Инпут вводим данные из выбранной таблицы")]
    public Text VidUborki; public Text PoradokUborki; public Text FrontRabot; public Text SostavNum;

    [Header("Оутпут выводим данные")]
    public Text[] VidUborkiAR; public Text[] PoradokUborkiAR; public Text[] FrontRabotAR; public Text[] SostavNumAR;
    void Start()
    {

        for (int i = 0; i < VidUborkiAR.Length; i++)
        { VidUborkiAR[i].text = VidUborki.text; VidUborkiAR[i].color = Color.black; }
        for (int i = 0; i < PoradokUborkiAR.Length; i++)
        {   PoradokUborkiAR[i].text = PoradokUborki.text; PoradokUborkiAR[i].color = Color.black; }
        for (int i = 0; i < VidUborkiAR.Length; i++)
        {    FrontRabotAR[i].text = FrontRabot.text; FrontRabotAR[i].color = Color.black; }
        for (int i = 0; i < SostavNumAR.Length; i++)
        {      SostavNumAR[i].text = SostavNum.text; SostavNumAR[i].color = Color.black; }
        VidUborki.color = Color.black; PoradokUborki.color = Color.black; FrontRabot.color = Color.black; SostavNum.color = Color.black; 
        Debug.Log("Оутпут Оутпут" + gameObject.name);
    }


}
