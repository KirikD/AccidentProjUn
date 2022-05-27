using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VagonSelector : MonoBehaviour
{  // ��� ������ ��� ����� ������� ������
    [Header("����� �����")]
    public string nameVag; //��� ������ � ����� �� ���� �� ��������� ������ ������� �������
    [Header("������� ��������� ������� �����")]
    public Text MainLabelText;// = "�������� ��������������� ��������� ��� ������� �1 ������ �1";
    public Text PlatformaUI_MainText; //����� �1
    public Text MainScepkaText; //���������� �����  ������� 1-2

    [Header("���� ������ 50 �� ")]
    [Tooltip("���� ������ 50 ��  � ������� ����������")]
    public Toggle TelezkaMezduputA;  //���� ������ 50 ��  � ������� ����������
    [Tooltip("���� ������ 50 ��  � ������� ������� ")]
    public Toggle TelezkaKuvetA;  //���� ������ 50 ��  � ������� ������� 
    [Header("������ 50 ��")]
    [Tooltip("���� ������ 50 ��  � ������� ����������")]
    public Toggle TelezkaMezduputB;  //���� ������ 50 ��  � ������� ����������
    [Tooltip("���� ������ 50 ��  � ������� ������� ")]
    public Toggle TelezkaKuvetB; //���� ������ 50 ��  � ������� ������� 
    [Header("���������")]
    [Tooltip("��� ������� ")]
    public Toggle UnderVagon;  //��� ������� 
    [Tooltip("����� ������")]
    public Toggle NearTheWagon; //����� ������
    [Tooltip("��� ����")]
    public Toggle OutsideRails; //��� ����
    [Header("�������� �������")]
    [Tooltip("��� ����")]
    public Toggle NakatnoeOborudovanie; //���������� ������������
    [Tooltip("��� ����")]
    public Toggle GidroOborudovanie; //�������������� ������������
    [Header("�������������� ����")]
    [Tooltip("������� �������")]
    public Toggle LiftTheVagon;  //������� �������
    [Tooltip("������� �� ���� �������")]
    public Toggle LiftoneSide; //������� �� ���� �������
    [Tooltip("��������� ���� � ������� �������")]
    public Toggle UnloadCarge; //��������� ���� � ������� �������
    [Header("������ �� ������� ����")]
    [Tooltip("������ �� ������� ����")]
    public Toggle OutToOveralSize;  //������ �� ������� ����
    [Tooltip("������")]
    public Toggle Vibita;  //������

    [Header("���� � ������")]
    [Tooltip("���� ��������")]
    public Toggle DestroedRails;  //���� ��������
    [Tooltip("������� ������� �� ��������� ����")]
    public Toggle BoundsPathCorrupt; //������� ������� �� ��������� ����
    [Tooltip("������ �����")]
    public Toggle FailsCarge; //������ �����
    [Tooltip("������ � ������� �������")]
    public Toggle AngleVagonToKuvet;  //������ � ������� �������
    [Tooltip("������ � ������� ����������")]
    public Toggle AngleVagonToKuvetCenter; //������ � ������� ����������
    [Tooltip("����� �� ����")]
    public Toggle VagonOnLeftSide; //����� �� ����
    [Tooltip("��� ����� ����������� ����")]
    public Toggle CorruptRails; public Toggle NoCorruptRails; //����� �� ����

    [Header("���������� ����� ������� 1-2")]
    [Tooltip("��������� ��������������� ������������")]
    public Toggle GazorezkaEnable;  //������ �� ������� ����
    [Tooltip("�� ������")]
    public Toggle NeZazato;  //������ �� ������� ����

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
            {    vagIndexList = i;// ��������� ��� ���������� ��������� ������ ��� ������� ������ ��������� �� ����������
                 Debug.Log("PoezdItems: " + PoezdItems[i].name + i);
                if (vagNames[2] == "Scepka1")  scepinf = PoezdItems[i].ScepInfo1; if (vagNames[2] == "Scepka2") scepinf = PoezdItems[i].ScepInfo2;
                OpenScreensToFill3Delements(vagNames[2]);
                //  
            }  
        }

    }
    // �������� ������ ������ ��� ��������� ��������
    void OpenScreensToFill3Delements(string ObjName)
    {
        switch (ObjName)
        {
            case "Scepka1":
                MainScepkaText.text = "���������� �����  ������� �" + scepinf;
                ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                GazorezkaEnable.isOn = false; NeZazato.isOn = false;
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case "Scepka2":
                MainScepkaText.text = "���������� �����  ������� �" + scepinf;
                ScepkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                GazorezkaEnable.isOn = false; NeZazato.isOn = false;
                print("Hello and good day!");
                break;
            case "Platform":
                    PlatformaUI_MainText.text = "����� �" + nameVag;
                    UborkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                    DestroedRails.isOn = false;  //���� ��������
                    BoundsPathCorrupt.isOn = false; //������� ������� �� ��������� ����
                    FailsCarge.isOn = false; //������ �����
                    AngleVagonToKuvet.isOn = false;  //������ � ������� �������
                    AngleVagonToKuvetCenter.isOn = false; //������ � ������� ����������
                    VagonOnLeftSide.isOn = false; //����� �� ����
    print("Whadya want?");
                break;
            case "Telezka1":
                MainLabelText.text = "�������� ��������������� ��������� ��� ������� �1 ������ �" + nameVag;
                TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                TelezkaMezduputA.isOn = false;  //���� ������ 50 ��  � ������� ����������
                TelezkaKuvetA.isOn = false;  //���� ������ 50 ��  � ������� ������� 
                TelezkaMezduputB.isOn = false;  //���� ������ 50 ��  � ������� ����������
                TelezkaKuvetB.isOn = false; //���� ������ 50 ��  � ������� ������� 
                UnderVagon.isOn = false;  //��� ������� 
                NearTheWagon.isOn = false; //����� ������
                OutsideRails.isOn = false; //��� ����
                NakatnoeOborudovanie.isOn = false; //���������� ������������
                GidroOborudovanie.isOn = false; //�������������� ������������
                LiftTheVagon.isOn = false;  //������� �������
                LiftoneSide.isOn = false; //������� �� ���� �������
                UnloadCarge.isOn = false; //��������� ���� � ������� �������
                OutToOveralSize.isOn = false;  //������ �� ������� ����
                Vibita.isOn = false;  //
                print("Grog SMASH!");
                break;
            case "Telezka2":
                MainLabelText.text = "�������� ��������������� ��������� ��� ������� �2 ������ �" + nameVag;
                TelezkaPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                    TelezkaMezduputA.isOn = false;  //���� ������ 50 ��  � ������� ����������
                         TelezkaKuvetA.isOn = false;  //���� ������ 50 ��  � ������� ������� 
          TelezkaMezduputB.isOn = false;  //���� ������ 50 ��  � ������� ����������
                         TelezkaKuvetB.isOn = false; //���� ������ 50 ��  � ������� ������� 
                     UnderVagon.isOn = false;  //��� ������� 
                      NearTheWagon.isOn = false; //����� ������
                OutsideRails.isOn = false; //��� ����
                      NakatnoeOborudovanie.isOn = false; //���������� ������������
              GidroOborudovanie.isOn = false; //�������������� ������������
                 LiftTheVagon.isOn = false;  //������� �������
                LiftoneSide.isOn = false; //������� �� ���� �������
    UnloadCarge.isOn = false; //��������� ���� � ������� �������
             OutToOveralSize.isOn = false;  //������ �� ������� ����
                Vibita.isOn = false;  //
                print("Ulg, glib, Pblblblblb");
                break;
            case "RailSeg": //RailPath
                PathPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "���� ��������� ����� �" + scepinf;
                PathPanel.SetActive(true); ToolsButtonPanel.SetActive(false);
                CorruptRails.isOn = false; NoCorruptRails.isOn = false;
                print("PathPanel" + setElemOtvet.name);
                break;
            default:
                //print("Incorrect intelligence level.");
                break;
        }
    }
    public int tryQuestions; // ��� �� ���������� �������
    // ������� ���������� �� ���������� �������� � �������
    public void FillListScepkaA(string vagName)
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Scepka1")
        {
            PoezdItems[vagIndexList].GazorezkaEnablebool1 = GazorezkaEnable.isOn; PoezdItems[vagIndexList].sGazorezkaEnablebool1 = GazorezkaEnable.transform.GetChild(1).GetComponent<Text>().text;
            PoezdItems[vagIndexList].NeZazatobool1 = NeZazato.isOn; PoezdItems[vagIndexList].sNeZazatobool1 = NeZazato.transform.GetChild(1).GetComponent<Text>().text;
            // ��������� ��������� �� ������ IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            if (PoezdItems[vagIndexList].GazorezkaEnablebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].GazorezkaEnablebool1 == IdealBaseItems[vagIndexList].GazorezkaEnablebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
            if (PoezdItems[vagIndexList].NeZazatobool1) // ���� ������� ��� �� ��������� ������������� TestQuestionTruestFunc
                if (PoezdItems[vagIndexList].NeZazatobool1 == IdealBaseItems[vagIndexList].NeZazatobool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
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
            // ��������� ��������� �� ������ IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            if (PoezdItems[vagIndexList].GazorezkaEnablebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].GazorezkaEnablebool2 == IdealBaseItems[vagIndexList].GazorezkaEnablebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
            if (PoezdItems[vagIndexList].NeZazatobool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].NeZazatobool2 == IdealBaseItems[vagIndexList].NeZazatobool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
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

        // ��������� ��������� �� ������ IdealBaseItems
        setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
        if (PoezdItems[vagIndexList].DestroedRailbools) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].DestroedRailbools == IdealBaseItems[vagIndexList].DestroedRailbools) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].BoundsPathCorruptbool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].BoundsPathCorruptbool == IdealBaseItems[vagIndexList].BoundsPathCorruptbool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].FailsCargebool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].FailsCargebool == IdealBaseItems[vagIndexList].FailsCargebool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
     
        if (PoezdItems[vagIndexList].AngleVagonToKuvetbool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].AngleVagonToKuvetbool == IdealBaseItems[vagIndexList].AngleVagonToKuvetbool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].AngleVagonToKuvetCenterbool == IdealBaseItems[vagIndexList].AngleVagonToKuvetCenterbool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].VagonOnLeftSidebool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].VagonOnLeftSidebool == IdealBaseItems[vagIndexList].VagonOnLeftSidebool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
    }
    public void FillListrails(string vagName)
    {
        PoezdItems[vagIndexList].CorruptedPathbool = CorruptRails.isOn; PoezdItems[vagIndexList].sCorruptedPathbool = CorruptRails.transform.GetChild(1).GetComponent<Text>().text;
        PoezdItems[vagIndexList].NoCorruptedPathbool = NoCorruptRails.isOn; PoezdItems[vagIndexList].sNoCorruptedPathbool = NoCorruptRails.transform.GetChild(1).GetComponent<Text>().text;
        // ��������� ��������� �� ������ IdealBaseItems
        setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
        if (PoezdItems[vagIndexList].CorruptedPathbool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].CorruptedPathbool == IdealBaseItems[vagIndexList].CorruptedPathbool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
        if (PoezdItems[vagIndexList].NoCorruptedPathbool) // ���� ������� ��� �� ��������� �������������
            if (PoezdItems[vagIndexList].NoCorruptedPathbool == IdealBaseItems[vagIndexList].NoCorruptedPathbool) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
            { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); tryQuestions += 1; }
    }
        public void FillTelezka1(string vagName) // ����� ������� 1 ��� 2
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T1 " + vagNames[2]);
        if (vagNames[2] == "Telezka1") { 
            PoezdItems[vagIndexList].TelezkaMezduputAbool1 = TelezkaMezduputA.isOn; PoezdItems[vagIndexList].sTelezkaMezduputAbool1 = TelezkaMezduputA.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ����������
            PoezdItems[vagIndexList].TelezkaKuvetAbool1 = TelezkaKuvetA.isOn; PoezdItems[vagIndexList].sTelezkaKuvetAbool1 = TelezkaKuvetA.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ������� 
            PoezdItems[vagIndexList].TelezkaMezduputBbool1 = TelezkaMezduputB.isOn; PoezdItems[vagIndexList].sTelezkaMezduputBbool1 = TelezkaMezduputB.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ����������
           
            PoezdItems[vagIndexList].TelezkaKuvetBbool1 = TelezkaKuvetB.isOn; PoezdItems[vagIndexList].sTelezkaKuvetBbool1 = TelezkaKuvetB.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ������� 
            PoezdItems[vagIndexList].UnderVagonbool1 = UnderVagon.isOn; PoezdItems[vagIndexList].sUnderVagonbool1 = UnderVagon.transform.GetChild(1).GetComponent<Text>().text;//��� ������� 
            PoezdItems[vagIndexList].NearTheWagonbool1 = NearTheWagon.isOn; PoezdItems[vagIndexList].sNearTheWagonbool1 = NearTheWagon.transform.GetChild(1).GetComponent<Text>().text;//����� ������
           
            PoezdItems[vagIndexList].OutsideRailsbool1 = OutsideRails.isOn; PoezdItems[vagIndexList].sOutsideRailsbool1 = OutsideRails.transform.GetChild(1).GetComponent<Text>().text;//��� ����
            PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 = NakatnoeOborudovanie.isOn; PoezdItems[vagIndexList].sNakatnoeOborudovaniebool1 = NakatnoeOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//���������� ������������
            PoezdItems[vagIndexList].GidroOborudovaniebool1 = GidroOborudovanie.isOn; PoezdItems[vagIndexList].sGidroOborudovaniebool1 = GidroOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//�������������� ������������
           
            PoezdItems[vagIndexList].LiftTheVagonbool1 = LiftTheVagon.isOn; PoezdItems[vagIndexList].sLiftTheVagonbool1 = LiftTheVagon.transform.GetChild(1).GetComponent<Text>().text;//������� �������
            PoezdItems[vagIndexList].LiftoneSidebool1 = LiftoneSide.isOn; PoezdItems[vagIndexList].sLiftoneSidebool1 = LiftoneSide.transform.GetChild(1).GetComponent<Text>().text;//������� �� ���� �������
            PoezdItems[vagIndexList].UnloadCargebool1 = UnloadCarge.isOn; PoezdItems[vagIndexList].sUnloadCargebool1 = UnloadCarge.transform.GetChild(1).GetComponent<Text>().text;//��������� ���� � ������� �������
           
            PoezdItems[vagIndexList].OutToOveralSizebool1 = OutToOveralSize.isOn; PoezdItems[vagIndexList].sOutToOveralSizebool1 = OutToOveralSize.transform.GetChild(1).GetComponent<Text>().text;//������ �� ������� ���� Vibita
            PoezdItems[vagIndexList].Vibitabool1 = Vibita.isOn; PoezdItems[vagIndexList].sVibitabool1 = Vibita.transform.GetChild(1).GetComponent<Text>().text;
            // ��������� ��������� �� ������ IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            int TryesSumm = 0;// ��������� ��������� �� ������ IdealBaseItems 
            if (PoezdItems[vagIndexList].TelezkaMezduputAbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaMezduputAbool1 == IdealBaseItems[vagIndexList].TelezkaMezduputAbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaKuvetAbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaKuvetAbool1 == IdealBaseItems[vagIndexList].TelezkaKuvetAbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaMezduputBbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaMezduputBbool1 == IdealBaseItems[vagIndexList].TelezkaMezduputBbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].TelezkaKuvetBbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaKuvetBbool1 == IdealBaseItems[vagIndexList].TelezkaKuvetBbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].UnderVagonbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].UnderVagonbool1 == IdealBaseItems[vagIndexList].UnderVagonbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NearTheWagonbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].NearTheWagonbool1 == IdealBaseItems[vagIndexList].NearTheWagonbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutsideRailsbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].OutsideRailsbool1 == IdealBaseItems[vagIndexList].OutsideRailsbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 == IdealBaseItems[vagIndexList].NakatnoeOborudovaniebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].GidroOborudovaniebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].GidroOborudovaniebool1 == IdealBaseItems[vagIndexList].GidroOborudovaniebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].LiftTheVagonbool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].LiftTheVagonbool1 == IdealBaseItems[vagIndexList].LiftTheVagonbool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].LiftoneSidebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].LiftoneSidebool1 == IdealBaseItems[vagIndexList].LiftoneSidebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].UnloadCargebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].UnloadCargebool1 == IdealBaseItems[vagIndexList].UnloadCargebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].OutToOveralSizebool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].OutToOveralSizebool1 == IdealBaseItems[vagIndexList].OutToOveralSizebool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].Vibitabool1) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].Vibitabool1 == IdealBaseItems[vagIndexList].Vibitabool1) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            // ����� ���������� ������� ������� � ���� ������ ������ �� ���������
            if (TryesSumm > 3)
            {
                tryQuestions += 1;
                setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");
            }
        }
    }
    public void FillTelezka2(string vagName) // ����� ������� 1 ��� 2
    {
        string[] vagNames = fullVagPathName.Split('#');  Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Telezka2") {
            PoezdItems[vagIndexList].TelezkaMezduputAbool2 = TelezkaMezduputA.isOn; PoezdItems[vagIndexList].sTelezkaMezduputAbool2 = TelezkaMezduputA.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ����������
            PoezdItems[vagIndexList].TelezkaKuvetAbool2 = TelezkaKuvetA.isOn; PoezdItems[vagIndexList].sTelezkaKuvetAbool2 = TelezkaKuvetA.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ������� 
            PoezdItems[vagIndexList].TelezkaMezduputBbool2 = TelezkaMezduputB.isOn; PoezdItems[vagIndexList].sTelezkaMezduputBbool2 = TelezkaMezduputB.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ����������
          
            PoezdItems[vagIndexList].TelezkaKuvetBbool2 = TelezkaKuvetB.isOn; PoezdItems[vagIndexList].sTelezkaKuvetBbool2 = TelezkaKuvetB.transform.GetChild(1).GetComponent<Text>().text;//���� ������ 50 ��  � ������� ������� 
            PoezdItems[vagIndexList].UnderVagonbool2 = UnderVagon.isOn; PoezdItems[vagIndexList].sUnderVagonbool2 = UnderVagon.transform.GetChild(1).GetComponent<Text>().text;//��� ������� 
            PoezdItems[vagIndexList].NearTheWagonbool2 = NearTheWagon.isOn; PoezdItems[vagIndexList].sNearTheWagonbool2 = NearTheWagon.transform.GetChild(1).GetComponent<Text>().text;//����� ������
           
            PoezdItems[vagIndexList].OutsideRailsbool2 = OutsideRails.isOn; PoezdItems[vagIndexList].sOutsideRailsbool2 = OutsideRails.transform.GetChild(1).GetComponent<Text>().text;//��� ����
            PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 = NakatnoeOborudovanie.isOn; PoezdItems[vagIndexList].sNakatnoeOborudovaniebool2 = NakatnoeOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//���������� ������������
            PoezdItems[vagIndexList].GidroOborudovaniebool2 = GidroOborudovanie.isOn; PoezdItems[vagIndexList].sGidroOborudovaniebool2 = GidroOborudovanie.transform.GetChild(1).GetComponent<Text>().text;//�������������� ������������
          
            PoezdItems[vagIndexList].LiftTheVagonbool2 = LiftTheVagon.isOn; PoezdItems[vagIndexList].sLiftTheVagonbool2 = LiftTheVagon.transform.GetChild(1).GetComponent<Text>().text;//������� �������
            PoezdItems[vagIndexList].LiftoneSidebool2 = LiftoneSide.isOn; PoezdItems[vagIndexList].sLiftoneSidebool2 = LiftoneSide.transform.GetChild(1).GetComponent<Text>().text;//������� �� ���� �������
            PoezdItems[vagIndexList].UnloadCargebool2 = UnloadCarge.isOn; PoezdItems[vagIndexList].sUnloadCargebool2 = UnloadCarge.transform.GetChild(1).GetComponent<Text>().text;//��������� ���� � ������� �������
          
            PoezdItems[vagIndexList].OutToOveralSizebool2 = OutToOveralSize.isOn; PoezdItems[vagIndexList].sOutToOveralSizebool2 = OutToOveralSize.transform.GetChild(1).GetComponent<Text>().text;//������ �� ������� ����
            PoezdItems[vagIndexList].Vibitabool2 = Vibita.isOn; PoezdItems[vagIndexList].sVibitabool2 = Vibita.transform.GetChild(1).GetComponent<Text>().text;
            // ��������� ��������� �� ������ IdealBaseItems
            setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("red");
            int TryesSumm = 0;// ��������� ��������� �� ������ IdealBaseItems 
            if (PoezdItems[vagIndexList].TelezkaMezduputAbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaMezduputAbool2 == IdealBaseItems[vagIndexList].TelezkaMezduputAbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaKuvetAbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaKuvetAbool2 == IdealBaseItems[vagIndexList].TelezkaKuvetAbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].TelezkaMezduputBbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaMezduputBbool2 == IdealBaseItems[vagIndexList].TelezkaMezduputBbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].TelezkaKuvetBbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].TelezkaKuvetBbool2 == IdealBaseItems[vagIndexList].TelezkaKuvetBbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].UnderVagonbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].UnderVagonbool2 == IdealBaseItems[vagIndexList].UnderVagonbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].NearTheWagonbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].NearTheWagonbool2 == IdealBaseItems[vagIndexList].NearTheWagonbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutsideRailsbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].OutsideRailsbool2 == IdealBaseItems[vagIndexList].OutsideRailsbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 == IdealBaseItems[vagIndexList].NakatnoeOborudovaniebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].GidroOborudovaniebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].GidroOborudovaniebool2 == IdealBaseItems[vagIndexList].GidroOborudovaniebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }

            if (PoezdItems[vagIndexList].LiftTheVagonbool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].LiftTheVagonbool2 == IdealBaseItems[vagIndexList].LiftTheVagonbool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); TryesSumm++; }
            if (PoezdItems[vagIndexList].LiftoneSidebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].LiftoneSidebool2 == IdealBaseItems[vagIndexList].LiftoneSidebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");TryesSumm++; }
            if (PoezdItems[vagIndexList].UnloadCargebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].UnloadCargebool2 == IdealBaseItems[vagIndexList].UnloadCargebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }

            if (PoezdItems[vagIndexList].OutToOveralSizebool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].OutToOveralSizebool2 == IdealBaseItems[vagIndexList].OutToOveralSizebool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            if (PoezdItems[vagIndexList].Vibitabool2) // ���� ������� ��� �� ��������� �������������
                if (PoezdItems[vagIndexList].Vibitabool2 == IdealBaseItems[vagIndexList].Vibitabool2) // ���� � ��������� ���� ���� ���� ������� ��� �� �� �������� �����
                { setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green");  TryesSumm++; }
            // ����� ���������� ������� ������� � ���� ������ ������ �� ���������
            if (TryesSumm > 3) {
                tryQuestions += 1;
                setElemOtvet.GetComponent<MaterialChangerLaserPointer>().TestQuestionTruestFunc("green"); 
            }
        }
    }
    public void BaseChecingOperation()
    {
        for (int i = 0; i < IdealBaseItems.Count; i++)
        {// ��������� ��� ����
        
        }
    }
    public List<VagonItem> PoezdItems = new List<VagonItem>(); // ���� ���� ��� �� �������� � ���
    public List<VagonItem> IdealBaseItems = new List<VagonItem>();// ��������� ���� � ����������� ��������
    [System.Serializable]
    public class VagonItem
    {
        [Header("����� �����")]
        public string name; //��� ������ � ����� �� ���� �� ��������� ������ ������� �������
        [Tooltip("�������� ����� ������ � �������")]
        public int VagIndex ;//
        //1
        [Header("���� ������ 50 �� 1")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 1")]
        public bool TelezkaMezduputAbool1; public string sTelezkaMezduputAbool1;//���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 1")]
        public bool TelezkaKuvetAbool1; public string sTelezkaKuvetAbool1;//���� ������ 50 ��  � ������� ������� 
        [Header("������ 50 �� 1")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 1")]
        public bool TelezkaMezduputBbool1; public string sTelezkaMezduputBbool1;//���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 1")]
        public bool TelezkaKuvetBbool1; public string sTelezkaKuvetBbool1;//���� ������ 50 ��  � ������� ������� 
        [Header("��������� 1")]
        [Tooltip("��� ������� 1")]
        public bool UnderVagonbool1; public string sUnderVagonbool1;//��� ������� 
        [Tooltip("����� ������ 1")]
        public bool NearTheWagonbool1; public string sNearTheWagonbool1;//����� ������
        [Tooltip("��� ���� 1")]
        public bool OutsideRailsbool1; public string sOutsideRailsbool1;//��� ����
        [Header("�������� ������� 1")]
        [Tooltip("��� ���� 1")]
        public bool NakatnoeOborudovaniebool1; public string sNakatnoeOborudovaniebool1;//���������� ������������
        [Tooltip("��� ���� 1")]
        public bool GidroOborudovaniebool1; public string sGidroOborudovaniebool1;//�������������� ������������
        [Header("�������������� ���� 1")]
        [Tooltip("������� ������� 1")]
        public bool LiftTheVagonbool1; public string sLiftTheVagonbool1;//������� �������
        [Tooltip("������� �� ���� ������� 1")]
        public bool LiftoneSidebool1; public string sLiftoneSidebool1;//������� �� ���� �������
        [Tooltip("��������� ���� � ������� ������� 1")]
        public bool UnloadCargebool1; public string sUnloadCargebool1;//��������� ���� � ������� �������
        [Header("������ �� ������� ���� 1")]
        [Tooltip("������ �� ������� ���� 1")]
        public bool OutToOveralSizebool1; public string sOutToOveralSizebool1;//������ �� ������� ����
        public bool Vibitabool1; public string sVibitabool1;
        //2
        [Header("���� ������ 50 �� 2")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 2")]
        public bool TelezkaMezduputAbool2; public string sTelezkaMezduputAbool2;//���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 2")]
        public bool TelezkaKuvetAbool2; public string sTelezkaKuvetAbool2;//���� ������ 50 ��  � ������� ������� 
        [Header("������ 50 �� 2")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 2")]
        public bool TelezkaMezduputBbool2; public string sTelezkaMezduputBbool2;//���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 2")]
        public bool TelezkaKuvetBbool2; public string sTelezkaKuvetBbool2;//���� ������ 50 ��  � ������� ������� 
        [Header("��������� 2")]
        [Tooltip("��� ������� 2")]
        public bool UnderVagonbool2; public string sUnderVagonbool2;//��� ������� 
        [Tooltip("����� ������ 2")]
        public bool NearTheWagonbool2; public string sNearTheWagonbool2;//����� ������
        [Tooltip("��� ���� 2")]
        public bool OutsideRailsbool2; public string sOutsideRailsbool2;//��� ����
        [Header("�������� ������� 2")]
        [Tooltip("��� ���� 2")]
        public bool NakatnoeOborudovaniebool2; public string sNakatnoeOborudovaniebool2;//���������� ������������
        [Tooltip("��� ���� 2")]
        public bool GidroOborudovaniebool2; public string sGidroOborudovaniebool2;//�������������� ������������
        [Header("�������������� ���� 2")]
        [Tooltip("������� ������� 2")]
        public bool LiftTheVagonbool2; public string sLiftTheVagonbool2;//������� �������
        [Tooltip("������� �� ���� ������� 2")]
        public bool LiftoneSidebool2; public string sLiftoneSidebool2;//������� �� ���� �������
        [Tooltip("��������� ���� � ������� ������� 2")]
        public bool UnloadCargebool2; public string sUnloadCargebool2;//��������� ���� � ������� �������
        [Header("������ �� ������� ���� 2")]
        [Tooltip("������ �� ������� ���� 2")]
        public bool OutToOveralSizebool2; public string sOutToOveralSizebool2;//������ �� ������� ����
        public bool Vibitabool2; public string sVibitabool2;

        [Header("���� � ������")]
        [Tooltip("���� ��������")]
        public bool DestroedRailbools; public string sDestroedRailbools;//���� ��������
        [Tooltip("������� ������� �� ��������� ����")]
        public bool BoundsPathCorruptbool; public string sBoundsPathCorruptbool;//������� ������� �� ��������� ����
        [Tooltip("������ �����")]
        public bool FailsCargebool; public string sFailsCargebool;//������ �����
        [Tooltip("������ � ������� �������")]
        public bool AngleVagonToKuvetbool; public string sAngleVagonToKuvetbool;//������ � ������� �������
        [Tooltip("������ � ������� ����������")]
        public bool AngleVagonToKuvetCenterbool; public string sAngleVagonToKuvetCenterbool;//������ � ������� ����������
        [Tooltip("����� �� ����")]
        public bool VagonOnLeftSidebool; public string sVagonOnLeftSidebool;//����� �� ����

        [Header("���������� ����� ������� 1-2")]
        [Tooltip("��������� ��������������� ������������")]
        public bool GazorezkaEnablebool1; public string sGazorezkaEnablebool1;//������ �� ������� ����
       [Tooltip("�� ������")]
        public bool NeZazatobool1; public string sNeZazatobool1;//������ �� ������� ����
       [Tooltip("��������� ��������������� ������������")]
        public bool GazorezkaEnablebool2; public string sGazorezkaEnablebool2;//������ �� ������� ����
       [Tooltip("�� ������")]
        public bool NeZazatobool2; public string sNeZazatobool2;//������ �� ������� ����
        public string ScepInfo1 = " � � "; public string ScepInfo2 = " � � "; // �������� ���������  ������� ����� �������
        [Tooltip("���� ��������� � ���� �����?")]
        public bool CorruptedPathbool; public string sCorruptedPathbool;//
        public bool NoCorruptedPathbool; public string sNoCorruptedPathbool;//
    }
}