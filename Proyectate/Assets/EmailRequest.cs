using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;


public class EmailRequest : MonoBehaviour
{
    public GameObject CongratsSignal;
    public Button EmailButton;
    public GameObject canvasEmail;
    public GameObject signal;
    public Text inputField;

    void Start()
    {
        CongratsSignal.SetActive(false);
        canvasEmail.SetActive(false);
        signal.SetActive(false);
    }
    public void Open()
    {
        canvasEmail.SetActive(true);
        signal.SetActive(false);
    }
    public void Close()
    {
        CongratsSignal.SetActive(false);
        canvasEmail.SetActive(false);
        signal.SetActive(false);
    }
    public void Ready()
    {
        if (inputField.text.Length > 0)
        {
            if (IsValidEmail(inputField.text)) 
            {
                GetComponent<ScreenShot>().TakePhoto();

                canvasEmail.SetActive(false);
                CongratsSignal.SetActive(true);
                EmailButton.enabled = false;
            }
            else
                signal.SetActive(true);
        }
    }
    bool IsValidEmail(string strIn)
    {
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
    }
}
