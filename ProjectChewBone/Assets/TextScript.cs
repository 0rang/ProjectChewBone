using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public static TextScript instance;

    // Start is called before the first frame update
    [HideInInspector]
    bool TextBoxOpen = false;
    private GameObject TextBox;
    private Text TextForTextBox;
    void Start()
    {
        instance = this;
        //find textbox
        var Canvas = GameObject.Find("Canvas");
        if (Canvas != null)
        {
            Debug.Log("Neato textbox has been located in textscripts");
            TextBox = Canvas.transform.Find("Textbox").gameObject;
            TextForTextBox = TextBox.GetComponentInChildren<Text>();
            if (TextBox != null && TextForTextBox != null)
            {
                Debug.Log("yeet the text in the textbox wooooorks");
            }
            else
            {
                Debug.Log("it broke can't find the text for the textbox :c");
            }
        }
        else
        { Debug.Log("Where be the textbox?"); }
    }

    public void OpenTheTextBox(string TextString)
    {
        //switch on textbox
        TextBoxOpen = true;
        //switch on the stop motion function
        TextBox.SetActive(true);
        StopGameMotion.instance.StopMotion();
        TextForTextBox.text = TextString;
        StartCoroutine(WaitForInput());
        Debug.Log("Opened Textbox");
    }

    private void CloseTextBox()
    {
        TextBoxOpen = false;
        StopGameMotion.instance.StartMotion();
        TextBox.SetActive(false);
        Debug.Log("Closed Textbox");
    }

    IEnumerator WaitForInput()
    {
        Debug.Log("Open Textbox");

        yield return new WaitUntil(() => (Input.GetButtonDown("Jump")));
        CloseTextBox();
        Debug.Log("Close Textbox");
    }
}
