using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public Text ChatLog;
    public ScrollRect scrollRect;
    public Text textbox;
    public Image chatbubble;
    // Start is called before the first frame update
    void Start()
    {
        chatbubble.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSendButton(InputField SendInput)
    {
        if (!Input.GetButtonDown("Submit")) return;
        SendInput.ActivateInputField();
        if (SendInput.text.Trim() == "") return;

        string message = SendInput.text;
        SendInput.text = "";
        Sendbox(message);
        Send(message);
    }
    void Send(string data)  
    {
        ChatLog.text += "Masker: "+ data + "\n";
        scrollRect.verticalNormalizedPosition = 0.0f;
    }
    void Sendbox(string data)
    {
        chatbubble.gameObject.SetActive(true);
        textbox.text = data;
        StartCoroutine(WaitForIt());
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3.0f);
        chatbubble.gameObject.SetActive(false);
    }
}
