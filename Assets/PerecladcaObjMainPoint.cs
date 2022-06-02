using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerecladcaObjMainPoint : MonoBehaviour
{
    public GameObject objPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            objPoint.transform.position = this.transform.GetChild(0).position;
            objPoint.transform.rotation = this.transform.GetChild(0).rotation;
            // оутлайн
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            // оутлайн
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    // Update is called once per frame

}
