using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatrterLogic : MonoBehaviour
{
    GameObject player;
    void Start()
    {
         player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //
    public void DragAvaterTo3DgameScen(Transform pos) // ������ ����������� ������ � ����� ���� ����
    {
       
        player.transform.position = pos.position;
    }
}
