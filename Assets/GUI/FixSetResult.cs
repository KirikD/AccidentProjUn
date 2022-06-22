using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FixSetResult : MonoBehaviour
{
    // принудительно забиваем результат по свободным автосцепкам  CanvasOnHand
    [Header("указываем тут правильный ответ по автосцепке")]
    public Toggle setTruePunct; // указываем тут правильный ответ
    
    private VagonSelector vs;
    void Start()
    { vs = GameObject.Find("CanvasOnHand").GetComponent<VagonSelector>(); }
    public void TruePunct()
    {
        CancelInvoke(nameof(TimeToFalse));
        Invoke(nameof(TimeToFalse),2);
        setTruePunct.isOn = true;
      

        vs.FillListScepkaA("1"); vs.FillListScepkaB("2");
       // this.gameObject.GetComponent<MaterialChangerLaserPointer>().DisableAllColiders(true);
    }

    // Update is called once per frame
    void TimeToFalse()
    {
        this.gameObject.GetComponent<MaterialChangerLaserPointer>().DisableAllColiders(true);
        setTruePunct.transform.parent.parent.gameObject.SetActive(false);
 
    }
}
