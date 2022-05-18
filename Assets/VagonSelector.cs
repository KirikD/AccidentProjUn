using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VagonSelector : MonoBehaviour
{  // все данные для одной стороны вагона
    [Header("ВАГОН Номер")]
    public string nameVag; //Имя вагона и номер по нему мы заполняем нужный элемент таблицы    
    
    [Header("Сход меньше 50 см ")]
    [Tooltip("Сход меньше 50 см  в сторону междупутья")]
    public Toggle TelezkaMezduputA;  //Сход меньше 50 см  в сторону междупутья
    [Tooltip("Сход меньше 50 см  в сторону обочины ")]
    public Toggle TelezkaKuvetA;  //Сход меньше 50 см  в сторону обочины 
    [Header("больше 50 см")]
    [Tooltip("Сход меньше 50 см  в сторону междупутья")]
    public Toggle TelezkaMezduputB;  //Сход больше 50 см  в сторону междупутья
    [Tooltip("Сход больше 50 см  в сторону обочины ")]
    public Toggle TelezkaKuvetB; //Сход больше 50 см  в сторону обочины 
    [Header("Разрушена")]
    [Tooltip("под вагоном ")]
    public Toggle UnderVagon;  //под вагоном 
    [Tooltip("около вагона")]
    public Toggle NearTheWagon; //около вагона
    [Tooltip("Вне пути")]
    public Toggle OutsideRails; //Вне пути
    [Header("СРЕДСТВО ПОДЪЕМА")]
    [Tooltip("Вне пути")]
    public Toggle NakatnoeOborudovanie; //Накаточное оборудование
    [Tooltip("Вне пути")]
    public Toggle GidroOborudovanie; //Гидравлическое оборудование
    [Header("Грузоподъемный кран")]
    [Tooltip("поднять целиком")]
    public Toggle LiftTheVagon;  //поднять целиком
    [Tooltip("поднять за одну сторону")]
    public Toggle LiftoneSide; //поднять за одну сторону
    [Tooltip("выгрузить груз и поднять целиком")]
    public Toggle UnloadCarge; //выгрузить груз и поднять целиком
    [Header("Уборка за габарит пути")]
    [Tooltip("Уборка за габарит пути")]
    public Toggle OutToOveralSize;  //Уборка за габарит пути

    [Header("Путь и наклон")]
    [Tooltip("Путь разрушен")]
    public Toggle DestroedRails;  //Путь разрушен
    [Tooltip("Нарушен габарит по соседнему пути")]
    public Toggle BoundsPathCorrupt; //Нарушен габарит по соседнему пути
    [Tooltip("Развал груза")]
    public Toggle FailsCarge; //Развал груза
    [Tooltip("Наклон в сторону обочины")]
    public Toggle AngleVagonToKuvet;  //Наклон в сторону обочины
    [Tooltip("Наклон в сторону междупутья")]
    public Toggle AngleVagonToKuvetCenter; //Наклон в сторону междупутья
    [Tooltip("Вагон на боку")]
    public Toggle VagonOnLeftSide; //Вагон на боку


    [Header("АВТОСЦЕПКА МЕЖДУ ВАГОНОМ 1-2")]
    [Tooltip("Применить газорезательное оборудование")]
    public Toggle GazorezkaEnable;  //Уборка за габарит пути
    [Tooltip("Не зажато")]
    public Toggle NeZazato;  //Уборка за габарит пути

    public GameObject TelezkaPanel;
    public GameObject UborkaPanel;
    public GameObject ScepkaPanel;
    UnityEvent ElementSetter_MyEvent; //  ElementSetter_MyEvent.Invoke();
    void Start()
    {
        ElementSetter.OnSelectedEvent += SetTogleFieldsToArry;
    }

    // Update is called once per frame
    public void SetTogleFieldsToArry(string vagName)
    {
        string[] vagNames = vagName.Split('#');
        nameVag = vagNames[1]; Debug.Log(vagName + " ADgd: ");
        for (int i = 0; i < PoezdItems.Count; i++)
        {
            if (PoezdItems[i].name == vagNames[1])
            {  // реализуем тут присвоение состояний тоглов при нажатии кнопки применить на интерфейсе
                 Debug.Log("PoezdItems: " + PoezdItems[i].name + i);
                if (vagNames[2] == "Scepka1")
                { ScepkaPanel.SetActive(true); }
                if (vagNames[2] == "Platform")
                { UborkaPanel.SetActive(true); }

            }  
        }
    }
    public List<VagonItem> PoezdItems = new List<VagonItem>();
    [System.Serializable]
    public class VagonItem
    {
        [Header("ВАГОН Номер")]
        public string name; //Имя вагона и номер по нему мы заполняем нужный элемент таблицы       

        [Header("Сход меньше 50 см ")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья")]
        public bool TelezkaMezduputAbool;  //Сход меньше 50 см  в сторону междупутья
        [Tooltip("Сход меньше 50 см  в сторону обочины ")]
        public bool TelezkaKuvetAbool;  //Сход меньше 50 см  в сторону обочины 
        [Header("больше 50 см")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья")]
        public bool TelezkaMezduputBbool;  //Сход больше 50 см  в сторону междупутья
        [Tooltip("Сход больше 50 см  в сторону обочины ")]
        public bool TelezkaKuvetBbool; //Сход больше 50 см  в сторону обочины 
        [Header("Разрушена")]
        [Tooltip("под вагоном ")]
        public bool UnderVagonbool;  //под вагоном 
        [Tooltip("около вагона")]
        public bool NearTheWagonbool; //около вагона
        [Tooltip("Вне пути")]
        public bool OutsideRailsbool; //Вне пути
        [Header("СРЕДСТВО ПОДЪЕМА")]
        [Tooltip("Вне пути")]
        public bool NakatnoeOborudovaniebool; //Накаточное оборудование
        [Tooltip("Вне пути")]
        public bool GidroOborudovaniebool; //Гидравлическое оборудование
        [Header("Грузоподъемный кран")]
        [Tooltip("поднять целиком")]
        public bool LiftTheVagonbool;  //поднять целиком
        [Tooltip("поднять за одну сторону")]
        public bool LiftoneSidebool; //поднять за одну сторону
        [Tooltip("выгрузить груз и поднять целиком")]
        public bool UnloadCargebool; //выгрузить груз и поднять целиком
        [Header("Уборка за габарит пути")]
        [Tooltip("Уборка за габарит пути")]
        public bool OutToOveralSizebool;  //Уборка за габарит пути
        [Header("Путь и наклон")]
        [Tooltip("Путь разрушен")]
        public bool DestroedRailbools;  //Путь разрушен
        [Tooltip("Нарушен габарит по соседнему пути")]
        public bool BoundsPathCorruptbool; //Нарушен габарит по соседнему пути
        [Tooltip("Развал груза")]
        public bool FailsCargebool; //Развал груза
        [Tooltip("Наклон в сторону обочины")]
        public bool AngleVagonToKuvetbool;  //Наклон в сторону обочины
        [Tooltip("Наклон в сторону междупутья")]
        public bool AngleVagonToKuvetCenterbool; //Наклон в сторону междупутья
        [Tooltip("Вагон на боку")]
        public bool VagonOnLeftSidebool; //Вагон на боку

        [Header("АВТОСЦЕПКА МЕЖДУ ВАГОНОМ 1-2")]
        [Tooltip("Применить газорезательное оборудование")]
        public bool GazorezkaEnablebool;  //Уборка за габарит пути
        [Tooltip("Не зажато")]
        public bool NeZazatobool;  //Уборка за габарит пути


    }
}

  