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
    void Start()
    {
        OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.0f);
        Application.quitting += Quit;
    }
    public void InstrumentSetPosLineika()
    {
        pointInstrumentLineika.transform.position = MainHeadPoint.transform.position;
        OutlineSetWidth.SetFloat("g_flOutlineWidth", 0.0025f);
        Invoke("ReturnNullWidthOutline",9);
        Vibbbro();

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