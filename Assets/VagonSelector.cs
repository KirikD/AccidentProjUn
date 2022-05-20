using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VagonSelector : MonoBehaviour
{  // все данные для одной стороны вагона
    [Header("ВАГОН Номер")]
    public string nameVag; //Имя вагона и номер по нему мы заполняем нужный элемент таблицы
    [Header("Главный заголовок тележки текст")]
    public Text MainLabelText;// = "ВЫБЕРИТЕ СООТВЕТСТВУЮЩИЕ ПАРАМЕТРЫ ДЛЯ ТЕЛЕЖКИ №1 ВАГОНА №1";
    public Text PlatformaUI_MainText; //ВАГОН №1
    public Text MainScepkaText; //АВТОСЦЕПКА МЕЖДУ  ВАГОНОМ 1-2

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
    [Tooltip("Выбита")]
    public Toggle Vibita;  //Выбита

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

    public GameObject ToolsButtonPanel;
    public GameObject TelezkaPanel;
    public GameObject UborkaPanel;
    public GameObject ScepkaPanel;
    UnityEvent ElementSetter_MyEvent; //  ElementSetter_MyEvent.Invoke();
    void Start()
    {
        ElementSetter.OnSelectedEvent += SetTogleFieldsToArry;
    }

    int vagIndexList; string fullVagPathName; string scepinf;
    public void SetTogleFieldsToArry(string vagName)
    {
        string[] vagNames = vagName.Split('#');
        fullVagPathName = vagName;
        nameVag = vagNames[1]; Debug.Log(vagName + " ADgd: ");
        for (int i = 0; i < PoezdItems.Count; i++)
        {
            if (PoezdItems[i].name == vagNames[1])
            {    vagIndexList = i;// реализуем тут присвоение состояний тоглов при нажатии кнопки применить на интерфейсе
                 Debug.Log("PoezdItems: " + PoezdItems[i].name + i);
                if (vagNames[2] == "Scepka1")  scepinf = PoezdItems[i].ScepInfo1; if (vagNames[2] == "Scepka2") scepinf = PoezdItems[i].ScepInfo2;
                OpenScreensToFill3Delements(vagNames[2]);
                /*if (vagNames[2] == "Scepka1")
                {
                    ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                }
                if (vagNames[2] == "Scepka2")
                {
                    ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                }
                if (vagNames[2] == "Platform")
                { 
                    UborkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                }
                if (vagNames[2] == "Telezka1")
                {
                    TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                }
                if (vagNames[2] == "Telezka2")
                {
                    TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                }*/
            }  
        }
    }
    // включаем нужные экраны для отмечания обжектов
    void OpenScreensToFill3Delements(string ObjName)
    {
        switch (ObjName)
        {
            case "Scepka1":

                MainScepkaText.text = "АВТОСЦЕПКА МЕЖДУ  ВАГОНОМ №" + scepinf;
                ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                GazorezkaEnable.isOn = false; NeZazato.isOn = false;
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case "Scepka2":
                MainScepkaText.text = "АВТОСЦЕПКА МЕЖДУ  ВАГОНОМ №" + scepinf;
                ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                GazorezkaEnable.isOn = false; NeZazato.isOn = false;
                print("Hello and good day!");
                break;
            case "Platform":
                    PlatformaUI_MainText.text = "ВАГОН №" + nameVag;
                    UborkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                    DestroedRails.isOn = false;  //Путь разрушен
                    BoundsPathCorrupt.isOn = false; //Нарушен габарит по соседнему пути
                    FailsCarge.isOn = false; //Развал груза
                    AngleVagonToKuvet.isOn = false;  //Наклон в сторону обочины
                    AngleVagonToKuvetCenter.isOn = false; //Наклон в сторону междупутья
                    VagonOnLeftSide.isOn = false; //Вагон на боку
    print("Whadya want?");
                break;
            case "Telezka1":
                MainLabelText.text = "ВЫБЕРИТЕ СООТВЕТСТВУЮЩИЕ ПАРАМЕТРЫ ДЛЯ ТЕЛЕЖКИ №1 ВАГОНА №" + nameVag;
                TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                TelezkaMezduputA.isOn = false;  //Сход меньше 50 см  в сторону междупутья
                TelezkaKuvetA.isOn = false;  //Сход меньше 50 см  в сторону обочины 
                TelezkaMezduputB.isOn = false;  //Сход больше 50 см  в сторону междупутья
                TelezkaKuvetB.isOn = false; //Сход больше 50 см  в сторону обочины 
                UnderVagon.isOn = false;  //под вагоном 
                NearTheWagon.isOn = false; //около вагона
                OutsideRails.isOn = false; //Вне пути
                NakatnoeOborudovanie.isOn = false; //Накаточное оборудование
                GidroOborudovanie.isOn = false; //Гидравлическое оборудование
                LiftTheVagon.isOn = false;  //поднять целиком
                LiftoneSide.isOn = false; //поднять за одну сторону
                UnloadCarge.isOn = false; //выгрузить груз и поднять целиком
                OutToOveralSize.isOn = false;  //Уборка за габарит пути
                Vibita.isOn = false;  //
                print("Grog SMASH!");
                break;
            case "Telezka2":
                MainLabelText.text = "ВЫБЕРИТЕ СООТВЕТСТВУЮЩИЕ ПАРАМЕТРЫ ДЛЯ ТЕЛЕЖКИ №2 ВАГОНА №" + nameVag;
                TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                    TelezkaMezduputA.isOn = false;  //Сход меньше 50 см  в сторону междупутья
                         TelezkaKuvetA.isOn = false;  //Сход меньше 50 см  в сторону обочины 
          TelezkaMezduputB.isOn = false;  //Сход больше 50 см  в сторону междупутья
                         TelezkaKuvetB.isOn = false; //Сход больше 50 см  в сторону обочины 
                     UnderVagon.isOn = false;  //под вагоном 
                      NearTheWagon.isOn = false; //около вагона
                OutsideRails.isOn = false; //Вне пути
                      NakatnoeOborudovanie.isOn = false; //Накаточное оборудование
              GidroOborudovanie.isOn = false; //Гидравлическое оборудование
                 LiftTheVagon.isOn = false;  //поднять целиком
                LiftoneSide.isOn = false; //поднять за одну сторону
    UnloadCarge.isOn = false; //выгрузить груз и поднять целиком
             OutToOveralSize.isOn = false;  //Уборка за габарит пути
                Vibita.isOn = false;  //
                print("Ulg, glib, Pblblblblb");
                break;
            case "addhftrgh":
                print("dfg");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    // функции отвечающие за применение булеонов к спискам
    public void FillListScepkaA(string vagName)
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Scepka1")
        {
            PoezdItems[vagIndexList].GazorezkaEnablebool1 = GazorezkaEnable.isOn;
            PoezdItems[vagIndexList].NeZazatobool1 = NeZazato.isOn;
        }
    }
    public void FillListScepkaB(string vagName)
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Scepka2")
        {
            PoezdItems[vagIndexList].GazorezkaEnablebool2 = GazorezkaEnable.isOn;
            PoezdItems[vagIndexList].NeZazatobool2 = NeZazato.isOn;
        }
    }
    public void FillListPlatform(string vagName)
    {   
        PoezdItems[vagIndexList].DestroedRailbools = DestroedRails.isOn;
        PoezdItems[vagIndexList].BoundsPathCorruptbool = BoundsPathCorrupt.isOn;
        PoezdItems[vagIndexList].FailsCargebool = FailsCarge.isOn;
        PoezdItems[vagIndexList].AngleVagonToKuvetbool = AngleVagonToKuvet.isOn;
        PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool = AngleVagonToKuvetCenter.isOn;
        PoezdItems[vagIndexList].VagonOnLeftSidebool = VagonOnLeftSide.isOn;
    }
    public void FillTelezka1(string vagName) // номер тележки 1 или 2
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T1 " + vagNames[2]);
        if (vagNames[2] == "Telezka1") { 
        PoezdItems[vagIndexList].TelezkaMezduputAbool1 = TelezkaMezduputA.isOn;  //Сход меньше 50 см  в сторону междупутья
        PoezdItems[vagIndexList].TelezkaKuvetAbool1 = TelezkaKuvetA.isOn;  //Сход меньше 50 см  в сторону обочины 
        PoezdItems[vagIndexList].TelezkaMezduputBbool1 = TelezkaMezduputB.isOn;  //Сход больше 50 см  в сторону междупутья
        PoezdItems[vagIndexList].TelezkaKuvetBbool1 = TelezkaKuvetB.isOn; //Сход больше 50 см  в сторону обочины 
        PoezdItems[vagIndexList].UnderVagonbool1 = UnderVagon.isOn;  //под вагоном 
        PoezdItems[vagIndexList].NearTheWagonbool1 = NearTheWagon.isOn; //около вагона
        PoezdItems[vagIndexList].OutsideRailsbool1 = OutsideRails.isOn; //Вне пути
        PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 = NakatnoeOborudovanie.isOn; //Накаточное оборудование
        PoezdItems[vagIndexList].GidroOborudovaniebool1 = GidroOborudovanie.isOn; //Гидравлическое оборудование
        PoezdItems[vagIndexList].LiftTheVagonbool1 = LiftTheVagon.isOn;  //поднять целиком
        PoezdItems[vagIndexList].LiftoneSidebool1 = LiftoneSide.isOn; //поднять за одну сторону
        PoezdItems[vagIndexList].UnloadCargebool1 = UnloadCarge.isOn; //выгрузить груз и поднять целиком
        PoezdItems[vagIndexList].OutToOveralSizebool1 = OutToOveralSize.isOn;  //Уборка за габарит пути Vibita
            PoezdItems[vagIndexList].Vibitabool1 = Vibita.isOn;
        }
    }
    public void FillTelezka2(string vagName) // номер тележки 1 или 2
    {
        string[] vagNames = fullVagPathName.Split('#');  Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Telezka2") {
        PoezdItems[vagIndexList].TelezkaMezduputAbool2 = TelezkaMezduputA.isOn;  //Сход меньше 50 см  в сторону междупутья
        PoezdItems[vagIndexList].TelezkaKuvetAbool2 = TelezkaKuvetA.isOn;  //Сход меньше 50 см  в сторону обочины 
        PoezdItems[vagIndexList].TelezkaMezduputBbool2 = TelezkaMezduputB.isOn;  //Сход больше 50 см  в сторону междупутья
        PoezdItems[vagIndexList].TelezkaKuvetBbool2 = TelezkaKuvetB.isOn; //Сход больше 50 см  в сторону обочины 
        PoezdItems[vagIndexList].UnderVagonbool2 = UnderVagon.isOn;  //под вагоном 
        PoezdItems[vagIndexList].NearTheWagonbool2 = NearTheWagon.isOn; //около вагона
        PoezdItems[vagIndexList].OutsideRailsbool2 = OutsideRails.isOn; //Вне пути
        PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 = NakatnoeOborudovanie.isOn; //Накаточное оборудование
        PoezdItems[vagIndexList].GidroOborudovaniebool2 = GidroOborudovanie.isOn; //Гидравлическое оборудование
        PoezdItems[vagIndexList].LiftTheVagonbool2 = LiftTheVagon.isOn;  //поднять целиком
        PoezdItems[vagIndexList].LiftoneSidebool2 = LiftoneSide.isOn; //поднять за одну сторону
        PoezdItems[vagIndexList].UnloadCargebool2 = UnloadCarge.isOn; //выгрузить груз и поднять целиком
        PoezdItems[vagIndexList].OutToOveralSizebool2 = OutToOveralSize.isOn;  //Уборка за габарит пути
        PoezdItems[vagIndexList].Vibitabool2 = Vibita.isOn;
        }
    }
    public void BaseChecingOperation()
    {
        for (int i = 0; i < IdealBaseItems.Count; i++)
        {// проверяем всю базу
        
        }
    }
    public List<VagonItem> PoezdItems = new List<VagonItem>(); // база того что мы отмечаем и где
    public List<VagonItem> IdealBaseItems = new List<VagonItem>();// Идеальная база с правильными ответами
    [System.Serializable]
    public class VagonItem
    {
        [Header("ВАГОН Номер")]
        public string name; //Имя вагона и номер по нему мы заполняем нужный элемент таблицы
        [Tooltip("реальный номер вагона в составе")]
        public int VagIndex ;//
        //1
        [Header("Сход меньше 50 см 1")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 1")]
        public bool TelezkaMezduputAbool1;  //Сход меньше 50 см  в сторону междупутья
        [Tooltip("Сход меньше 50 см  в сторону обочины 1")]
        public bool TelezkaKuvetAbool1;  //Сход меньше 50 см  в сторону обочины 
        [Header("больше 50 см 1")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 1")]
        public bool TelezkaMezduputBbool1;  //Сход больше 50 см  в сторону междупутья
        [Tooltip("Сход больше 50 см  в сторону обочины 1")]
        public bool TelezkaKuvetBbool1; //Сход больше 50 см  в сторону обочины 
        [Header("Разрушена 1")]
        [Tooltip("под вагоном 1")]
        public bool UnderVagonbool1;  //под вагоном 
        [Tooltip("около вагона 1")]
        public bool NearTheWagonbool1; //около вагона
        [Tooltip("Вне пути 1")]
        public bool OutsideRailsbool1; //Вне пути
        [Header("СРЕДСТВО ПОДЪЕМА 1")]
        [Tooltip("Вне пути 1")]
        public bool NakatnoeOborudovaniebool1; //Накаточное оборудование
        [Tooltip("Вне пути 1")]
        public bool GidroOborudovaniebool1; //Гидравлическое оборудование
        [Header("Грузоподъемный кран 1")]
        [Tooltip("поднять целиком 1")]
        public bool LiftTheVagonbool1;  //поднять целиком
        [Tooltip("поднять за одну сторону 1")]
        public bool LiftoneSidebool1; //поднять за одну сторону
        [Tooltip("выгрузить груз и поднять целиком 1")]
        public bool UnloadCargebool1; //выгрузить груз и поднять целиком
        [Header("Уборка за габарит пути 1")]
        [Tooltip("Уборка за габарит пути 1")]
        public bool OutToOveralSizebool1;  //Уборка за габарит пути
        public bool Vibitabool1;
                                           //2
        [Header("Сход меньше 50 см 2")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 2")]
        public bool TelezkaMezduputAbool2;  //Сход меньше 50 см  в сторону междупутья
        [Tooltip("Сход меньше 50 см  в сторону обочины 2")]
        public bool TelezkaKuvetAbool2;  //Сход меньше 50 см  в сторону обочины 
        [Header("больше 50 см 2")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 2")]
        public bool TelezkaMezduputBbool2;  //Сход больше 50 см  в сторону междупутья
        [Tooltip("Сход больше 50 см  в сторону обочины 2")]
        public bool TelezkaKuvetBbool2; //Сход больше 50 см  в сторону обочины 
        [Header("Разрушена 2")]
        [Tooltip("под вагоном 2")]
        public bool UnderVagonbool2;  //под вагоном 
        [Tooltip("около вагона 2")]
        public bool NearTheWagonbool2; //около вагона
        [Tooltip("Вне пути 2")]
        public bool OutsideRailsbool2; //Вне пути
        [Header("СРЕДСТВО ПОДЪЕМА 2")]
        [Tooltip("Вне пути 2")]
        public bool NakatnoeOborudovaniebool2; //Накаточное оборудование
        [Tooltip("Вне пути 2")]
        public bool GidroOborudovaniebool2; //Гидравлическое оборудование
        [Header("Грузоподъемный кран 2")]
        [Tooltip("поднять целиком 2")]
        public bool LiftTheVagonbool2;  //поднять целиком
        [Tooltip("поднять за одну сторону 2")]
        public bool LiftoneSidebool2; //поднять за одну сторону
        [Tooltip("выгрузить груз и поднять целиком 2")]
        public bool UnloadCargebool2; //выгрузить груз и поднять целиком
        [Header("Уборка за габарит пути 2")]
        [Tooltip("Уборка за габарит пути 2")]
        public bool OutToOveralSizebool2;  //Уборка за габарит пути
        public bool Vibitabool2;

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
        public bool GazorezkaEnablebool1;  //Уборка за габарит пути
        [Tooltip("Не зажато")]
        public bool NeZazatobool1;  //Уборка за габарит пути
        [Tooltip("Применить газорезательное оборудование")]
        public bool GazorezkaEnablebool2;  //Уборка за габарит пути
        [Tooltip("Не зажато")]
        public bool NeZazatobool2;  //Уборка за габарит пути
        public string ScepInfo1 = " И № "; public string ScepInfo2 = " И № "; // название ближайших  вагонов между сцепкой
    }
}