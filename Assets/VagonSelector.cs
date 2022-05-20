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


    [Header("���������� ����� ������� 1-2")]
    [Tooltip("��������� ��������������� ������������")]
    public Toggle GazorezkaEnable;  //������ �� ������� ����
    [Tooltip("�� ������")]
    public Toggle NeZazato;  //������ �� ������� ����

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
            {    vagIndexList = i;// ��������� ��� ���������� ��������� ������ ��� ������� ������ ��������� �� ����������
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
            case "addhftrgh":
                print("dfg");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    // ������� ���������� �� ���������� �������� � �������
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
    public void FillTelezka1(string vagName) // ����� ������� 1 ��� 2
    {
        string[] vagNames = fullVagPathName.Split('#'); Debug.Log("T1 " + vagNames[2]);
        if (vagNames[2] == "Telezka1") { 
        PoezdItems[vagIndexList].TelezkaMezduputAbool1 = TelezkaMezduputA.isOn;  //���� ������ 50 ��  � ������� ����������
        PoezdItems[vagIndexList].TelezkaKuvetAbool1 = TelezkaKuvetA.isOn;  //���� ������ 50 ��  � ������� ������� 
        PoezdItems[vagIndexList].TelezkaMezduputBbool1 = TelezkaMezduputB.isOn;  //���� ������ 50 ��  � ������� ����������
        PoezdItems[vagIndexList].TelezkaKuvetBbool1 = TelezkaKuvetB.isOn; //���� ������ 50 ��  � ������� ������� 
        PoezdItems[vagIndexList].UnderVagonbool1 = UnderVagon.isOn;  //��� ������� 
        PoezdItems[vagIndexList].NearTheWagonbool1 = NearTheWagon.isOn; //����� ������
        PoezdItems[vagIndexList].OutsideRailsbool1 = OutsideRails.isOn; //��� ����
        PoezdItems[vagIndexList].NakatnoeOborudovaniebool1 = NakatnoeOborudovanie.isOn; //���������� ������������
        PoezdItems[vagIndexList].GidroOborudovaniebool1 = GidroOborudovanie.isOn; //�������������� ������������
        PoezdItems[vagIndexList].LiftTheVagonbool1 = LiftTheVagon.isOn;  //������� �������
        PoezdItems[vagIndexList].LiftoneSidebool1 = LiftoneSide.isOn; //������� �� ���� �������
        PoezdItems[vagIndexList].UnloadCargebool1 = UnloadCarge.isOn; //��������� ���� � ������� �������
        PoezdItems[vagIndexList].OutToOveralSizebool1 = OutToOveralSize.isOn;  //������ �� ������� ���� Vibita
            PoezdItems[vagIndexList].Vibitabool1 = Vibita.isOn;
        }
    }
    public void FillTelezka2(string vagName) // ����� ������� 1 ��� 2
    {
        string[] vagNames = fullVagPathName.Split('#');  Debug.Log("T2 " + vagNames[2]);
        if (vagNames[2] == "Telezka2") {
        PoezdItems[vagIndexList].TelezkaMezduputAbool2 = TelezkaMezduputA.isOn;  //���� ������ 50 ��  � ������� ����������
        PoezdItems[vagIndexList].TelezkaKuvetAbool2 = TelezkaKuvetA.isOn;  //���� ������ 50 ��  � ������� ������� 
        PoezdItems[vagIndexList].TelezkaMezduputBbool2 = TelezkaMezduputB.isOn;  //���� ������ 50 ��  � ������� ����������
        PoezdItems[vagIndexList].TelezkaKuvetBbool2 = TelezkaKuvetB.isOn; //���� ������ 50 ��  � ������� ������� 
        PoezdItems[vagIndexList].UnderVagonbool2 = UnderVagon.isOn;  //��� ������� 
        PoezdItems[vagIndexList].NearTheWagonbool2 = NearTheWagon.isOn; //����� ������
        PoezdItems[vagIndexList].OutsideRailsbool2 = OutsideRails.isOn; //��� ����
        PoezdItems[vagIndexList].NakatnoeOborudovaniebool2 = NakatnoeOborudovanie.isOn; //���������� ������������
        PoezdItems[vagIndexList].GidroOborudovaniebool2 = GidroOborudovanie.isOn; //�������������� ������������
        PoezdItems[vagIndexList].LiftTheVagonbool2 = LiftTheVagon.isOn;  //������� �������
        PoezdItems[vagIndexList].LiftoneSidebool2 = LiftoneSide.isOn; //������� �� ���� �������
        PoezdItems[vagIndexList].UnloadCargebool2 = UnloadCarge.isOn; //��������� ���� � ������� �������
        PoezdItems[vagIndexList].OutToOveralSizebool2 = OutToOveralSize.isOn;  //������ �� ������� ����
        PoezdItems[vagIndexList].Vibitabool2 = Vibita.isOn;
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
        public bool TelezkaMezduputAbool1;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 1")]
        public bool TelezkaKuvetAbool1;  //���� ������ 50 ��  � ������� ������� 
        [Header("������ 50 �� 1")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 1")]
        public bool TelezkaMezduputBbool1;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 1")]
        public bool TelezkaKuvetBbool1; //���� ������ 50 ��  � ������� ������� 
        [Header("��������� 1")]
        [Tooltip("��� ������� 1")]
        public bool UnderVagonbool1;  //��� ������� 
        [Tooltip("����� ������ 1")]
        public bool NearTheWagonbool1; //����� ������
        [Tooltip("��� ���� 1")]
        public bool OutsideRailsbool1; //��� ����
        [Header("�������� ������� 1")]
        [Tooltip("��� ���� 1")]
        public bool NakatnoeOborudovaniebool1; //���������� ������������
        [Tooltip("��� ���� 1")]
        public bool GidroOborudovaniebool1; //�������������� ������������
        [Header("�������������� ���� 1")]
        [Tooltip("������� ������� 1")]
        public bool LiftTheVagonbool1;  //������� �������
        [Tooltip("������� �� ���� ������� 1")]
        public bool LiftoneSidebool1; //������� �� ���� �������
        [Tooltip("��������� ���� � ������� ������� 1")]
        public bool UnloadCargebool1; //��������� ���� � ������� �������
        [Header("������ �� ������� ���� 1")]
        [Tooltip("������ �� ������� ���� 1")]
        public bool OutToOveralSizebool1;  //������ �� ������� ����
        public bool Vibitabool1;
                                           //2
        [Header("���� ������ 50 �� 2")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 2")]
        public bool TelezkaMezduputAbool2;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 2")]
        public bool TelezkaKuvetAbool2;  //���� ������ 50 ��  � ������� ������� 
        [Header("������ 50 �� 2")]
        [Tooltip("���� ������ 50 ��  � ������� ���������� 2")]
        public bool TelezkaMezduputBbool2;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� 2")]
        public bool TelezkaKuvetBbool2; //���� ������ 50 ��  � ������� ������� 
        [Header("��������� 2")]
        [Tooltip("��� ������� 2")]
        public bool UnderVagonbool2;  //��� ������� 
        [Tooltip("����� ������ 2")]
        public bool NearTheWagonbool2; //����� ������
        [Tooltip("��� ���� 2")]
        public bool OutsideRailsbool2; //��� ����
        [Header("�������� ������� 2")]
        [Tooltip("��� ���� 2")]
        public bool NakatnoeOborudovaniebool2; //���������� ������������
        [Tooltip("��� ���� 2")]
        public bool GidroOborudovaniebool2; //�������������� ������������
        [Header("�������������� ���� 2")]
        [Tooltip("������� ������� 2")]
        public bool LiftTheVagonbool2;  //������� �������
        [Tooltip("������� �� ���� ������� 2")]
        public bool LiftoneSidebool2; //������� �� ���� �������
        [Tooltip("��������� ���� � ������� ������� 2")]
        public bool UnloadCargebool2; //��������� ���� � ������� �������
        [Header("������ �� ������� ���� 2")]
        [Tooltip("������ �� ������� ���� 2")]
        public bool OutToOveralSizebool2;  //������ �� ������� ����
        public bool Vibitabool2;

        [Header("���� � ������")]
        [Tooltip("���� ��������")]
        public bool DestroedRailbools;  //���� ��������
        [Tooltip("������� ������� �� ��������� ����")]
        public bool BoundsPathCorruptbool; //������� ������� �� ��������� ����
        [Tooltip("������ �����")]
        public bool FailsCargebool; //������ �����
        [Tooltip("������ � ������� �������")]
        public bool AngleVagonToKuvetbool;  //������ � ������� �������
        [Tooltip("������ � ������� ����������")]
        public bool AngleVagonToKuvetCenterbool; //������ � ������� ����������
        [Tooltip("����� �� ����")]
        public bool VagonOnLeftSidebool; //����� �� ����

        [Header("���������� ����� ������� 1-2")]
        [Tooltip("��������� ��������������� ������������")]
        public bool GazorezkaEnablebool1;  //������ �� ������� ����
        [Tooltip("�� ������")]
        public bool NeZazatobool1;  //������ �� ������� ����
        [Tooltip("��������� ��������������� ������������")]
        public bool GazorezkaEnablebool2;  //������ �� ������� ����
        [Tooltip("�� ������")]
        public bool NeZazatobool2;  //������ �� ������� ����
        public string ScepInfo1 = " � � "; public string ScepInfo2 = " � � "; // �������� ���������  ������� ����� �������
    }
}