using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OtpHandler : MonoBehaviour
{
    private otpjsonHandler otpjson;
    private string json;
    public List<GameObject> field;
    public InputField _number;
    public InputField _otp;
    public string _mobileText;
    public string tempOTP;
    private string _otpText;
    private int randomOtp;


    //loading
    //private RectTransform rectComponent;
    //private float rotateSpeed = 200f;


    void Start()
    {
        //rectComponent = GetComponent<RectTransform>();
        //rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        field[0].SetActive(true);
        field[1].SetActive(true);
        field[2].SetActive(false);
        field[3].SetActive(false);
    }

    public void Generate()
    {
        tempOTP = "xyz";
        print("OTPHANDLER" + tempOTP);
        _mobileText = _number.text;
        //field[0].SetActive(false);
        //field[1].SetActive(false);
        //field[2].SetActive(true);
        //field[3].SetActive(true);
        randomOtp = Random.Range(1000, 9999);
        print(randomOtp);
        
        StartCoroutine(GenerateOtp());
        //print(otpjson.status);
        //if (otpjson.status == "true")
        //{
            field[0].SetActive(false);
            field[1].SetActive(false);
            field[2].SetActive(true);
            field[3].SetActive(true);
        //}
        //else
        //{
        //    //popup
        //}

    }

    public IEnumerator GenerateOtp()
    {
        WWWForm form = new WWWForm();
        form.AddField("mobile", _mobileText);
        form.AddField("otp", randomOtp);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/setotp.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        json = www.downloadHandler.text;
        otpjson = JsonUtility.FromJson<otpjsonHandler>(json);
        //print(otpjson.status);
    }

    public void OnVerify() 
    {
        _otpText = _otp.text;
        
        if (int.Parse(_otpText) == randomOtp)
        {
            FindObjectOfType<RegisterManager>().siMobile.GetComponent<InputField>().text = _mobileText;
            FindObjectOfType<PanelHandler>().panel[2].SetActive(true);
            FindObjectOfType<PanelHandler>().panel[1].SetActive(false);
        }
        else
        {
            print("INVALID_OTP");
        }
    }
    void Update()
    {
        
    }
}
public class otpjsonHandler
{
    public string status;
    public string type;

}