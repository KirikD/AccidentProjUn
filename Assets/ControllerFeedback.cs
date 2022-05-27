using UnityEngine;

using Valve.VR;

public class ControllerFeedback : MonoBehaviour
{
    //[SteamVR_DefaultAction("Haptic")]
    public SteamVR_Action_Vibration hapticAction;
    public float microSecondsDuration = 1000;
    public SteamVR_Input_Sources handType;

    public void Vibbbro()
    {
        float seconds = (float)microSecondsDuration / 1000000f;
        hapticAction.Execute(0, seconds, 1f / seconds, 1, handType);
    }
}