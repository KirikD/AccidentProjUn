using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VagonSelector : MonoBehaviour
{  // ��� ������ ��� ����� ������� ������
    [Header("����� �����")]
    public string nameVag; //��� ������ � ����� �� ���� �� ��������� ������ ������� �������    
    
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

    int vagIndexList; string fullVagPathName;
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
                if (vagNames[2] == "Scepka1")
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
                }
            }  
        }
    }
    // �������� ������ ������ ��� ��������� ��������


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
        PoezdItems[vagIndexList].OutToOveralSizebool1 = OutToOveralSize.isOn;  //������ �� ������� ����
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
        }
    }
    public List<VagonItem> PoezdItems = new List<VagonItem>();
    [System.Serializable]
    public class VagonItem
    {
        [Header("����� �����")]
        public string name; //��� ������ � ����� �� ���� �� ��������� ������ ������� �������       
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

    }
}

  