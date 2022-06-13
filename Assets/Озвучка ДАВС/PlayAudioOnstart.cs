using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnstart : MonoBehaviour
{
    AudioSource audioData;// Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        GetComponent<PlayAudioOnstart>().enabled = false;
    }

    public void DestroyClassRoom()
    {
        GameObject gg = GameObject.Find("CLASSROOM");
        Destroy(gg);
        Resources.UnloadUnusedAssets();
        Invoke("ClearClass",1);
    }
    void ClearClass()
    { Resources.UnloadUnusedAssets(); }
}
