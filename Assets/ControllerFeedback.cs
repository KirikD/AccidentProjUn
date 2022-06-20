using UnityEngine;

using Valve.VR;

public class ControllerFeedback : MonoBehaviour
{
    //[SteamVR_DefaultAction("Haptic")]
    public SteamVR_Action_Vibration hapticAction;
    public float microSecondsDuration = 1000;
    public SteamVR_Input_Sources handType;
    public GameObject pointInstrumentLineika; public GameObject MainHeadPoint;
    public Material OutlineSetWidth;

    Vector3 initpos; Vector3 initscal; Quaternion initRot; GameObject parObj; GameObject UiObj;
    void Start()
    {
        parObj = this.transform.parent.parent.parent.gameObject;
        UiObj = this.transform.parent.parent.gameObject;
        OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.0f);
        Application.quitting += Quit;
        initpos = UiObj.transform.localPosition; initscal = UiObj.transform.localScale; initRot = UiObj.transform.localRotation; parObj = UiObj.transform.parent.gameObject;
    }
    public void InstrumentSetPosLineika()
    {
        pointInstrumentLineika.transform.position = MainHeadPoint.transform.position;
        OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.0025f);
        Invoke("ReturnNullWidthOutline", 19);
        // Vibbbro();
     
    }
    public void detactFromHandTime()
    {  Invoke("detactFromHand", 1.5f);  }
    bool once = true;
    public bool activateFinalDetactFromHandEndScore = true;
    public void ActivateFinalDetactFromHandEndScoreFunc() { activateFinalDetactFromHandEndScore = false; }
    public void detactFromHand() {
     
            UiObj.transform.transform.SetParent(null);
            UiObj.transform.localScale *= 2.5f; once = false; 

            UiObj.transform.eulerAngles = new Vector3(0, -90, 0);
            UiObj.transform.position = parObj.transform.position; //Invoke("onceRestore", 29.25f);
            UiObj.transform.localPosition = new Vector3(UiObj.transform.localPosition.x-1, UiObj.transform.localPosition.y + 0.01f, UiObj.transform.localPosition.z);   
    }
    public void CancelInvokedetactFromHandTime() { CancelInvoke("detactFromHand"); CancelInvoke("detactFromHand"); }
    public void onceRestore() { once = true; }
    bool isTimeDetachHandBool = false;
    public void AttactToHand()
    {
       if (activateFinalDetactFromHandEndScore)
       {
          isTimeDetachHandBool = true;
           UiObj.transform.SetParent(parObj.transform, false);
           UiObj.transform.localPosition= initpos; UiObj.transform.localScale= initscal; UiObj.transform.localRotation= initRot ;
       //   CancelInvoke("detactFromHand"); CancelInvoke("detactFromHand");
        }
    }
    public void AttactToHandI() { Invoke(nameof(AttactToHand),4); }
    public void detactFromHandSimple()
    {
        if (activateFinalDetactFromHandEndScore)
        {
            CancelInvoke(nameof(AttactToHand));

            UiObj.transform.transform.SetParent(null);
            if (isTimeDetachHandBool)
            {
                UiObj.transform.localScale *= 1.25f; once = false;
                UiObj.transform.position = parObj.transform.position;
                isTimeDetachHandBool = false;
               // Invoke(nameof(AttactToHand), 14);
            }
        }
    }
    void ReturnNullWidthOutline()
    { OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.0f); }
        public void Vibbbro()
    {
        float seconds = (float)microSecondsDuration / 1000000f;
        hapticAction.Execute(0, seconds, 1f / seconds, 1, handType);
    }
    void OnApplicationQuit()
    {
        OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.006f);
        Debug.Log("Application ending after " + Time.time + " seconds");
      
    }
    static void Quit()
    {
        Debug.Log("Quitting the Player");
    }

    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        Application.quitting += Quit;
    }
}