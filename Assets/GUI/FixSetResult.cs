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
        Invoke(nameof(TimeToFalse),3);
        setTruePunct.isOn = true;
        //this.gameObject.GetComponent<ElementSetter>().ChangeElemUiName();

        vs.FillListScepkaA("1"); vs.FillListScepkaB("2");
    }

    // Update is called once per frame
    void TimeToFalse()
    {
        setTruePunct.transform.parent.parent.gameObject.SetActive(false);
    }
}
