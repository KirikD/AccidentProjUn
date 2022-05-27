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
    [Tooltip("Доп пункт разрушенный путь")]
    public Toggle CorruptRails; public Toggle NoCorruptRails; //Вагон на боку

    [Header("АВТОСЦЕПКА МЕЖДУ ВАГОНОМ 1-2")]
    [Tooltip("Применить газорезательное оборудование")]
    public Toggle GazorezkaEnable;  //Уборка за габарит пути
    [Tooltip("Не зажато")]
    public Toggle NeZazato;  //Уборка за габарит пути

    public GameObject ToolsButtonPanel;
    public GameObject TelezkaPanel;
    public GameObject PathPanel;
    public GameObject UborkaPanel;
    public GameObject ScepkaPanel;
    UnityEvent ElementSetter_MyEvent; //  ElementSetter_MyEvent.Invoke();
    void Start()
    {
        ElementSetter.OnSelectedEvent += SetTogleFieldsToArry;
    }

    int vagIndexList; string fullVagPathName; string scepinf;
    GameObject setElemOtvet;
    public void SetTogleFieldsToArry(string vagName, GameObject Elem)
    {
        setElemOtvet = Elem;
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
                //  
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
            case "RailSeg": //RailPath
                PathPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Путь поврежден между №" + scepinf;
                PathPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                CorruptRails.isOn = false; NoCorruptRails.isOn = false;
                print("PathPanel" + setElemOtvet.name);
                break;
            default:
                //print("Incorrect intelligence level.");
                break;
        }
    }
    public int tryQuestions; // кол во правильных ответов
    // функции отвечающие за применение булеонов к спискам
    public void FillListScepkaA(string vagName)
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Scepka1")
        {
            PoezdItems[vagIndexList].GazorezkaEnablebool1 = GazorezkaEnable.isOn; PoezdItems[vagIndexList].sGazorezkaEnablebool1 = GazorezkaEnable.transform.GetChild(1).GetComponent<Text>().text;
            PoezdItems[vagIndexList].NeZazatobool1 = NeZazato.isOn; PoezdItems[vagIndexList].sNeZazatobool1 = NeZazato.transform.GetChild(1).GetComponent<Text>().text;
            // проверяем правильно ли прошли IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            if (PoezdItems[vagIndexList].GazorezkaEnablebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].GazorezkaEnablebool1 == IdealBaseItems[vagIndexList].GazorezkaEnablebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
            if (PoezdItems[vagIndexList].NeZazatobool1) // если элемент тру то проверяем сопоставление TestQuestionTruestFunc
                if (PoezdItems[vagIndexList].NeZazatobool1 == IdealBaseItems[vagIndexList].NeZazatobool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        }
    }
    public void FillListScepkaB(string vagName)
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Scepka2")
        {
            PoezdItems[vagIndexList].GazorezkaEnablebool2 = GazorezkaEnable.isOn; PoezdItems[vagIndexList].sGazorezkaEnablebool2 = GazorezkaEnable.transform.GetChild(1).GetComponent<Text>().text;
            PoezdItems[vagIndexList].NeZazatobool2 = NeZazato.isOn; PoezdItems[vagIndexList].sNeZazatobool2 = NeZazato.transform.GetChild(1).GetComponent<Text>().text;
            // проверяем правильно ли прошли IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            if (PoezdItems[vagIndexList].GazorezkaEnablebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].GazorezkaEnablebool2 == IdealBaseItems[vagIndexList].GazorezkaEnablebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
            if (PoezdItems[vagIndexList].NeZazatobool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].NeZazatobool2 == IdealBaseItems[vagIndexList].NeZazatobool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        } 
    }
    public void FillListPlatform(string vagName)
    {   
        PoezdItems[vagIndexList].DestroedRailbools = DestroedRails.isOn; PoezdItems[vagIndexList].sDestroedRailbools = DestroedRails.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].BoundsPathCorruptbool = BoundsPathCorrupt.isOn; PoezdItems[vagIndexList].sBoundsPathCorruptbool = BoundsPathCorrupt.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].FailsCargebool = FailsCarge.isOn; PoezdItems[vagIndexList].sFailsCargebool = FailsCarge.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].AngleVagonToKuvetbool = AngleVagonToKuvet.isOn; PoezdItems[vagIndexList].sAngleVagonToKuvetbool = AngleVagonToKuvet.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool = AngleVagonToKuvetCenter.isOn; PoezdItems[vagIndexList].sAngleVagonToKuvetCenterbool = AngleVagonToKuvetCenter.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].VagonOnLeftSidebool = VagonOnLeftSide.isOn; PoezdItems[vagIndexList].sVagonOnLeftSidebool = VagonOnLeftSide.transform.GetChild(1).GetComponent<Text>().text;

        // проверяем правильно ли прошли IdealBaseItems
        setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
        if (PoezdItems[vagIndexList].DestroedRailbools) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].DestroedRailbools == IdealBaseItems[vagIndexList].DestroedRailbools) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].BoundsPathCorruptbool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].BoundsPathCorruptbool == IdealBaseItems[vagIndexList].BoundsPathCorruptbool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].FailsCargebool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].FailsCargebool == IdealBaseItems[vagIndexList].FailsCargebool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
     
        if (PoezdItems[vagIndexList].AngleVagonToKuvetbool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].AngleVagonToKuvetbool == IdealBaseItems[vagIndexList].AngleVagonToKuvetbool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool == IdealBaseItems[vagIndexList].AngleVagonToKuvetCenterbool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].VagonOnLeftSidebool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].VagonOnLeftSidebool == IdealBaseItems[vagIndexList].VagonOnLeftSidebool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
    }
    public void FillListrails(string vagName)
    {
        PoezdItems[vagIndexList].CorruptedPathbool = CorruptRails.isOn; PoezdItems[vagIndexList].sCorruptedPathbool = CorruptRails.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].NoCorruptedPathbool = NoCorruptRails.isOn; PoezdItems[vagIndexList].sNoCorruptedPathbool = NoCorruptRails.transform.GetChild(1).GetComponent<Text>().text;
        // проверяем правильно ли прошли IdealBaseItems
        setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
        if (PoezdItems[vagIndexList].CorruptedPathbool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].CorruptedPathbool == IdealBaseItems[vagIndexList].CorruptedPathbool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].NoCorruptedPathbool) // если элемент тру то проверяем сопоставление
            if (PoezdItems[vagIndexList].NoCorruptedPathbool == IdealBaseItems[vagIndexList].NoCorruptedPathbool) // если в идеальной базе тоже этот элемент тру то мы ответили верно
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
    }
        public void FillTelezka1(string vagName) // номер тележки 1 или 2
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T1 " + vagNames[2]);
        if (vagNames[2] == "Telezka1") { 
            PoezdItems[vagIndexList].TelezkaMezduputAbool1 = TelezkaMezduputA.isOn; PoezdItems[vagIndexList].sTelezkaMezduputAbool1 = TelezkaMezduputA.transform.GetChild(1).GetComponent<Text>().text;//Сход меньше 50 см  в сторону междупутья
            PoezdItems[vagIndexList].TelezkaKuvetAbool1 = TelezkaKuvetA.isOn; PoezdItems[vagIndexList].sTelezkaKuvetAbool1 = TelezkaKuvetA.transform.GetChild(1).GetComponent<Text>().text;//Сход меньше 50 см  в сторону обочины 
            PoezdItems[vagIndexList].TelezkaMezduputBbool1 = TelezkaMezduputB.isOn; PoezdItems[vagIndexList].sTelezkaMezduputBbool1 = TelezkaMezduputB.transform.GetChild(1).GetComponent<Text>().text;//Сход больше 50 см  в сторону междупутья
           
            PoezdItems[vagIndexList].TelezkaKuvetBbool1 = TelezkaKuvetB.isOn; PoezdItems[vagIndexList].sTelezkaKuvetBbool1 = TelezkaKuvetB.transform.GetChild(1).GetComponent<Text>().text;//Сход больше 50 см  в сторону обочины 
            PoezdItems[vagIndexList].UnderVagonbool1 = UnderVagon.isOn; PoezdItems[vagIndexList].sUnderVagonbool1 = UnderVagon.transform.GetChild(1).GetComponent<Text>().text;//под вагоном 
            PoezdItems[vagIndexList].NearTheWagonbool1 = NearTheWagon.isOn; PoezdItems[vagIndexList].sNearTheWagonbool1 = NearTheWagon.transform.GetChild(1).GetComponent<Text>().text;//около вагона
           
            PoezdItems[vagIndexList].OutsideRailsbool1 = OutsideRails.isOn; PoezdItems[vagIndexList].sOutsideRailsbool1 = OutsideRails.transform.GetChild(1).GetComponent<Text>().text;//Вне пути
            PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 = NakatnoeOborudovanie.isOn; PoezdItems[vagIndexList].sNakatnoeOborudovaniebool1 = NakatnoeOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//Накаточное оборудование
            PoezdItems[vagIndexList].GidroOborudovaniebool1 = GidroOborudovanie.isOn; PoezdItems[vagIndexList].sGidroOborudovaniebool1 = GidroOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//Гидравлическое оборудование
           
            PoezdItems[vagIndexList].LiftTheVagonbool1 = LiftTheVagon.isOn; PoezdItems[vagIndexList].sLiftTheVagonbool1 = LiftTheVagon.transform.GetChild(1).GetComponent<Text>().text;//поднять целиком
            PoezdItems[vagIndexList].LiftoneSidebool1 = LiftoneSide.isOn; PoezdItems[vagIndexList].sLiftoneSidebool1 = LiftoneSide.transform.GetChild(1).GetComponent<Text>().text;//поднять за одну сторону
            PoezdItems[vagIndexList].UnloadCargebool1 = UnloadCarge.isOn; PoezdItems[vagIndexList].sUnloadCargebool1 = UnloadCarge.transform.GetChild(1).GetComponent<Text>().text;//выгрузить груз и поднять целиком
           
            PoezdItems[vagIndexList].OutToOveralSizebool1 = OutToOveralSize.isOn; PoezdItems[vagIndexList].sOutToOveralSizebool1 = OutToOveralSize.transform.GetChild(1).GetComponent<Text>().text;//Уборка за габарит пути Vibita
            PoezdItems[vagIndexList].Vibitabool1 = Vibita.isOn; PoezdItems[vagIndexList].sVibitabool1 = Vibita.transform.GetChild(1).GetComponent<Text>().text;
            // проверяем правильно ли прошли IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            int TryesSumm = 0;// проверяем правильно ли прошли IdealBaseItems 
            if (PoezdItems[vagIndexList].TelezkaMezduputAbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaMezduputAbool1 == IdealBaseItems[vagIndexList].TelezkaMezduputAbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaKuvetAbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaKuvetAbool1 == IdealBaseItems[vagIndexList].TelezkaKuvetAbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaMezduputBbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaMezduputBbool1 == IdealBaseItems[vagIndexList].TelezkaMezduputBbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].TelezkaKuvetBbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaKuvetBbool1 == IdealBaseItems[vagIndexList].TelezkaKuvetBbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].UnderVagonbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].UnderVagonbool1 == IdealBaseItems[vagIndexList].UnderVagonbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NearTheWagonbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].NearTheWagonbool1 == IdealBaseItems[vagIndexList].NearTheWagonbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutsideRailsbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].OutsideRailsbool1 == IdealBaseItems[vagIndexList].OutsideRailsbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 == IdealBaseItems[vagIndexList].NakatnoeOborudovaniebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].GidroOborudovaniebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].GidroOborudovaniebool1 == IdealBaseItems[vagIndexList].GidroOborudovaniebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].LiftTheVagonbool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].LiftTheVagonbool1 == IdealBaseItems[vagIndexList].LiftTheVagonbool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].LiftoneSidebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].LiftoneSidebool1 == IdealBaseItems[vagIndexList].LiftoneSidebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].UnloadCargebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].UnloadCargebool1 == IdealBaseItems[vagIndexList].UnloadCargebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].OutToOveralSizebool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].OutToOveralSizebool1 == IdealBaseItems[vagIndexList].OutToOveralSizebool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].Vibitabool1) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].Vibitabool1 == IdealBaseItems[vagIndexList].Vibitabool1) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            // сумму правильных ответов считаем и если больше порога то разрешаем
            if (TryesSumm > 3)
            {
                tryQuestions += 1;
                setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");
            }
        }
    }
    public void FillTelezka2(string vagName) // номер тележки 1 или 2
    {
        string[] vagNames = fullVagPathName.Split('#');  Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Telezka2") {
            PoezdItems[vagIndexList].TelezkaMezduputAbool2 = TelezkaMezduputA.isOn; PoezdItems[vagIndexList].sTelezkaMezduputAbool2 = TelezkaMezduputA.transform.GetChild(1).GetComponent<Text>().text;//Сход меньше 50 см  в сторону междупутья
            PoezdItems[vagIndexList].TelezkaKuvetAbool2 = TelezkaKuvetA.isOn; PoezdItems[vagIndexList].sTelezkaKuvetAbool2 = TelezkaKuvetA.transform.GetChild(1).GetComponent<Text>().text;//Сход меньше 50 см  в сторону обочины 
            PoezdItems[vagIndexList].TelezkaMezduputBbool2 = TelezkaMezduputB.isOn; PoezdItems[vagIndexList].sTelezkaMezduputBbool2 = TelezkaMezduputB.transform.GetChild(1).GetComponent<Text>().text;//Сход больше 50 см  в сторону междупутья
          
            PoezdItems[vagIndexList].TelezkaKuvetBbool2 = TelezkaKuvetB.isOn; PoezdItems[vagIndexList].sTelezkaKuvetBbool2 = TelezkaKuvetB.transform.GetChild(1).GetComponent<Text>().text;//Сход больше 50 см  в сторону обочины 
            PoezdItems[vagIndexList].UnderVagonbool2 = UnderVagon.isOn; PoezdItems[vagIndexList].sUnderVagonbool2 = UnderVagon.transform.GetChild(1).GetComponent<Text>().text;//под вагоном 
            PoezdItems[vagIndexList].NearTheWagonbool2 = NearTheWagon.isOn; PoezdItems[vagIndexList].sNearTheWagonbool2 = NearTheWagon.transform.GetChild(1).GetComponent<Text>().text;//около вагона
           
            PoezdItems[vagIndexList].OutsideRailsbool2 = OutsideRails.isOn; PoezdItems[vagIndexList].sOutsideRailsbool2 = OutsideRails.transform.GetChild(1).GetComponent<Text>().text;//Вне пути
            PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 = NakatnoeOborudovanie.isOn; PoezdItems[vagIndexList].sNakatnoeOborudovaniebool2 = NakatnoeOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//Накаточное оборудование
            PoezdItems[vagIndexList].GidroOborudovaniebool2 = GidroOborudovanie.isOn; PoezdItems[vagIndexList].sGidroOborudovaniebool2 = GidroOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//Гидравлическое оборудование
          
            PoezdItems[vagIndexList].LiftTheVagonbool2 = LiftTheVagon.isOn; PoezdItems[vagIndexList].sLiftTheVagonbool2 = LiftTheVagon.transform.GetChild(1).GetComponent<Text>().text;//поднять целиком
            PoezdItems[vagIndexList].LiftoneSidebool2 = LiftoneSide.isOn; PoezdItems[vagIndexList].sLiftoneSidebool2 = LiftoneSide.transform.GetChild(1).GetComponent<Text>().text;//поднять за одну сторону
            PoezdItems[vagIndexList].UnloadCargebool2 = UnloadCarge.isOn; PoezdItems[vagIndexList].sUnloadCargebool2 = UnloadCarge.transform.GetChild(1).GetComponent<Text>().text;//выгрузить груз и поднять целиком
          
            PoezdItems[vagIndexList].OutToOveralSizebool2 = OutToOveralSize.isOn; PoezdItems[vagIndexList].sOutToOveralSizebool2 = OutToOveralSize.transform.GetChild(1).GetComponent<Text>().text;//Уборка за габарит пути
            PoezdItems[vagIndexList].Vibitabool2 = Vibita.isOn; PoezdItems[vagIndexList].sVibitabool2 = Vibita.transform.GetChild(1).GetComponent<Text>().text;
            // проверяем правильно ли прошли IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            int TryesSumm = 0;// проверяем правильно ли прошли IdealBaseItems 
            if (PoezdItems[vagIndexList].TelezkaMezduputAbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaMezduputAbool2 == IdealBaseItems[vagIndexList].TelezkaMezduputAbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaKuvetAbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaKuvetAbool2 == IdealBaseItems[vagIndexList].TelezkaKuvetAbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaMezduputBbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaMezduputBbool2 == IdealBaseItems[vagIndexList].TelezkaMezduputBbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].TelezkaKuvetBbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].TelezkaKuvetBbool2 == IdealBaseItems[vagIndexList].TelezkaKuvetBbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].UnderVagonbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].UnderVagonbool2 == IdealBaseItems[vagIndexList].UnderVagonbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NearTheWagonbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].NearTheWagonbool2 == IdealBaseItems[vagIndexList].NearTheWagonbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutsideRailsbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].OutsideRailsbool2 == IdealBaseItems[vagIndexList].OutsideRailsbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 == IdealBaseItems[vagIndexList].NakatnoeOborudovaniebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].GidroOborudovaniebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].GidroOborudovaniebool2 == IdealBaseItems[vagIndexList].GidroOborudovaniebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].LiftTheVagonbool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].LiftTheVagonbool2 == IdealBaseItems[vagIndexList].LiftTheVagonbool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].LiftoneSidebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].LiftoneSidebool2 == IdealBaseItems[vagIndexList].LiftoneSidebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");TryesSumm++; }
            if (PoezdItems[vagIndexList].UnloadCargebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].UnloadCargebool2 == IdealBaseItems[vagIndexList].UnloadCargebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutToOveralSizebool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].OutToOveralSizebool2 == IdealBaseItems[vagIndexList].OutToOveralSizebool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].Vibitabool2) // если элемент тру то проверяем сопоставление
                if (PoezdItems[vagIndexList].Vibitabool2 == IdealBaseItems[vagIndexList].Vibitabool2) // если в идеальной базе тоже этот элемент тру то мы ответили верно
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            // сумму правильных ответов считаем и если больше порога то разрешаем
            if (TryesSumm > 3) {
                tryQuestions += 1;
                setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); 
            }
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
        public bool TelezkaMezduputAbool1; public string sTelezkaMezduputAbool1;//Сход меньше 50 см  в сторону междупутья
        [Tooltip("Сход меньше 50 см  в сторону обочины 1")]
        public bool TelezkaKuvetAbool1; public string sTelezkaKuvetAbool1;//Сход меньше 50 см  в сторону обочины 
        [Header("больше 50 см 1")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 1")]
        public bool TelezkaMezduputBbool1; public string sTelezkaMezduputBbool1;//Сход больше 50 см  в сторону междупутья
        [Tooltip("Сход больше 50 см  в сторону обочины 1")]
        public bool TelezkaKuvetBbool1; public string sTelezkaKuvetBbool1;//Сход больше 50 см  в сторону обочины 
        [Header("Разрушена 1")]
        [Tooltip("под вагоном 1")]
        public bool UnderVagonbool1; public string sUnderVagonbool1;//под вагоном 
        [Tooltip("около вагона 1")]
        public bool NearTheWagonbool1; public string sNearTheWagonbool1;//около вагона
        [Tooltip("Вне пути 1")]
        public bool OutsideRailsbool1; public string sOutsideRailsbool1;//Вне пути
        [Header("СРЕДСТВО ПОДЪЕМА 1")]
        [Tooltip("Вне пути 1")]
        public bool NakatnoeOborudovaniebool1; public string sNakatnoeOborudovaniebool1;//Накаточное оборудование
        [Tooltip("Вне пути 1")]
        public bool GidroOborudovaniebool1; public string sGidroOborudovaniebool1;//Гидравлическое оборудование
        [Header("Грузоподъемный кран 1")]
        [Tooltip("поднять целиком 1")]
        public bool LiftTheVagonbool1; public string sLiftTheVagonbool1;//поднять целиком
        [Tooltip("поднять за одну сторону 1")]
        public bool LiftoneSidebool1; public string sLiftoneSidebool1;//поднять за одну сторону
        [Tooltip("выгрузить груз и поднять целиком 1")]
        public bool UnloadCargebool1; public string sUnloadCargebool1;//выгрузить груз и поднять целиком
        [Header("Уборка за габарит пути 1")]
        [Tooltip("Уборка за габарит пути 1")]
        public bool OutToOveralSizebool1; public string sOutToOveralSizebool1;//Уборка за габарит пути
        public bool Vibitabool1; public string sVibitabool1;
        //2
        [Header("Сход меньше 50 см 2")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 2")]
        public bool TelezkaMezduputAbool2; public string sTelezkaMezduputAbool2;//Сход меньше 50 см  в сторону междупутья
        [Tooltip("Сход меньше 50 см  в сторону обочины 2")]
        public bool TelezkaKuvetAbool2; public string sTelezkaKuvetAbool2;//Сход меньше 50 см  в сторону обочины 
        [Header("больше 50 см 2")]
        [Tooltip("Сход меньше 50 см  в сторону междупутья 2")]
        public bool TelezkaMezduputBbool2; public string sTelezkaMezduputBbool2;//Сход больше 50 см  в сторону междупутья
        [Tooltip("Сход больше 50 см  в сторону обочины 2")]
        public bool TelezkaKuvetBbool2; public string sTelezkaKuvetBbool2;//Сход больше 50 см  в сторону обочины 
        [Header("Разрушена 2")]
        [Tooltip("под вагоном 2")]
        public bool UnderVagonbool2; public string sUnderVagonbool2;//под вагоном 
        [Tooltip("около вагона 2")]
        public bool NearTheWagonbool2; public string sNearTheWagonbool2;//около вагона
        [Tooltip("Вне пути 2")]
        public bool OutsideRailsbool2; public string sOutsideRailsbool2;//Вне пути
        [Header("СРЕДСТВО ПОДЪЕМА 2")]
        [Tooltip("Вне пути 2")]
        public bool NakatnoeOborudovaniebool2; public string sNakatnoeOborudovaniebool2;//Накаточное оборудование
        [Tooltip("Вне пути 2")]
        public bool GidroOborudovaniebool2; public string sGidroOborudovaniebool2;//Гидравлическое оборудование
        [Header("Грузоподъемный кран 2")]
        [Tooltip("поднять целиком 2")]
        public bool LiftTheVagonbool2; public string sLiftTheVagonbool2;//поднять целиком
        [Tooltip("поднять за одну сторону 2")]
        public bool LiftoneSidebool2; public string sLiftoneSidebool2;//поднять за одну сторону
        [Tooltip("выгрузить груз и поднять целиком 2")]
        public bool UnloadCargebool2; public string sUnloadCargebool2;//выгрузить груз и поднять целиком
        [Header("Уборка за габарит пути 2")]
        [Tooltip("Уборка за габарит пути 2")]
        public bool OutToOveralSizebool2; public string sOutToOveralSizebool2;//Уборка за габарит пути
        public bool Vibitabool2; public string sVibitabool2;

        [Header("Путь и наклон")]
        [Tooltip("Путь разрушен")]
        public bool DestroedRailbools; public string sDestroedRailbools;//Путь разрушен
        [Tooltip("Нарушен габарит по соседнему пути")]
        public bool BoundsPathCorruptbool; public string sBoundsPathCorruptbool;//Нарушен габарит по соседнему пути
        [Tooltip("Развал груза")]
        public bool FailsCargebool; public string sFailsCargebool;//Развал груза
        [Tooltip("Наклон в сторону обочины")]
        public bool AngleVagonToKuvetbool; public string sAngleVagonToKuvetbool;//Наклон в сторону обочины
        [Tooltip("Наклон в сторону междупутья")]
        public bool AngleVagonToKuvetCenterbool; public string sAngleVagonToKuvetCenterbool;//Наклон в сторону междупутья
        [Tooltip("Вагон на боку")]
        public bool VagonOnLeftSidebool; public string sVagonOnLeftSidebool;//Вагон на боку

        [Header("АВТОСЦЕПКА МЕЖДУ ВАГОНОМ 1-2")]
        [Tooltip("Применить газорезательное оборудование")]
        public bool GazorezkaEnablebool1; public string sGazorezkaEnablebool1;//Уборка за габарит пути
       [Tooltip("Не зажато")]
        public bool NeZazatobool1; public string sNeZazatobool1;//Уборка за габарит пути
       [Tooltip("Применить газорезательное оборудование")]
        public bool GazorezkaEnablebool2; public string sGazorezkaEnablebool2;//Уборка за габарит пути
       [Tooltip("Не зажато")]
        public bool NeZazatobool2; public string sNeZazatobool2;//Уборка за габарит пути
        public string ScepInfo1 = " И № "; public string ScepInfo2 = " И № "; // название ближайших  вагонов между сцепкой
        [Tooltip("Путь поврежден в этом месте?")]
        public bool CorruptedPathbool; public string sCorruptedPathbool;//
        public bool NoCorruptedPathbool; public string sNoCorruptedPathbool;//
    }
}