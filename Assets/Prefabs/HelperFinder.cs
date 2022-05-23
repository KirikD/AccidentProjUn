using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParentObj = transform.parent.gameObject;
    }

    public GameObject ParentObj;
    public void DestroyThisElem()
    {
        Destroy(ParentObj);
    }
    public void AppyThisElem()
    { // удаляем сами кнопочки
        Destroy( transform.parent.GetChild(0).gameObject );
        Destroy(this.gameObject);
    }
}
