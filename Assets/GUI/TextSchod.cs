using UnityEngine;
using UnityEngine.UI;
public class TextSchod : MonoBehaviour
{
    public Text SchodTupe;
    void Start() { SchodTupe.text = "";  }
    public void SetTextFunc()
    {
        SchodTupe.text = this.gameObject.GetComponent<Text>().text;
    }
    public void SetNull()
    {
        SchodTupe.text = "";
    }

}
