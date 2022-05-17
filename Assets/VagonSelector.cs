using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetTogleFieldsToArry(string vagName)
    {
        for (int i = 0; i < PoezdItems.Count; i++)
        {
            if (PoezdItems[i].name == vagName)
            {  // ��������� ��� ���������� ��������� ������ ��� ������� ������ ��������� �� ����������
                 Debug.Log("PoezdItems: " + PoezdItems[i].name + i); 
            }  
        }
    }
    public List<VagonItem> PoezdItems = new List<VagonItem>();
    [System.Serializable]
    public class VagonItem
    {
        [Header("����� �����")]
        public string name; //��� ������ � ����� �� ���� �� ��������� ������ ������� �������
       


        [Header("���� ������ 50 �� ")]
        [Tooltip("���� ������ 50 ��  � ������� ����������")]
        public bool TelezkaMezduputAbool;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� ")]
        public bool TelezkaKuvetAbool;  //���� ������ 50 ��  � ������� ������� 
        [Header("������ 50 ��")]
        [Tooltip("���� ������ 50 ��  � ������� ����������")]
        public bool TelezkaMezduputBbool;  //���� ������ 50 ��  � ������� ����������
        [Tooltip("���� ������ 50 ��  � ������� ������� ")]
        public bool TelezkaKuvetBbool; //���� ������ 50 ��  � ������� ������� 
        [Header("���������")]
        [Tooltip("��� ������� ")]
        public bool UnderVagonbool;  //��� ������� 
        [Tooltip("����� ������")]
        public bool NearTheWagonbool; //����� ������
        [Tooltip("��� ����")]
        public bool OutsideRailsbool; //��� ����
        [Header("�������� �������")]
        [Tooltip("��� ����")]
        public bool NakatnoeOborudovaniebool; //���������� ������������
        [Tooltip("��� ����")]
        public bool GidroOborudovaniebool; //�������������� ������������
        [Header("�������������� ����")]
        [Tooltip("������� �������")]
        public bool LiftTheVagonbool;  //������� �������
        [Tooltip("������� �� ���� �������")]
        public bool LiftoneSidebool; //������� �� ���� �������
        [Tooltip("��������� ���� � ������� �������")]
        public bool UnloadCargebool; //��������� ���� � ������� �������
        [Header("������ �� ������� ����")]
        [Tooltip("������ �� ������� ����")]
        public bool OutToOveralSizebool;  //������ �� ������� ����

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
        public bool GazorezkaEnablebool;  //������ �� ������� ����
        [Tooltip("�� ������")]
        public bool NeZazatobool;  //������ �� ������� ����


    }
}

  