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
    {  Invoke("detactFromHand", 0.5f);  }
    bool once = true;
    public void detactFromHand() {
      
        if (once)
        {
            UiObj.transform.transform.SetParent(null);
            UiObj.transform.localScale *= 2; once = false; UiObj.transform.localPosition = new Vector3(UiObj.transform.localPosition.x, 
            UiObj.transform.localPosition.y+0.4f, UiObj.transform.localPosition.z);
            UiObj.transform.eulerAngles = new Vector3(0, -90, 0);
            UiObj.transform.position = parObj.transform.position; Invoke("onceRestore", 19.25f);
        }

        
    }
    void onceRestore() { once = true; }
    public void AttactToHand()
    {

        UiObj.transform.SetParent(parObj.transform, false);
        UiObj.transform.localPosition= initpos; UiObj.transform.localScale= initscal; UiObj.transform.localRotation= initRot ;
        CancelInvoke("detactFromHand"); CancelInvoke("detactFromHand"); 
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