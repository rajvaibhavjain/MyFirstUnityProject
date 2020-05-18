using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ForgotManager : MonoBehaviour
{

    public InputField _number;
    public InputField _otp;
    public InputField _password;
    public string mobileNumber;
    public string otp;
    public string password;
    public List<GameObject> inputFields;

    public PanelHandler ph;
    // Start is called before the first frame update
    void Start()
    {

        ph = FindObjectOfType<PanelHandler>();

        inputFields[0].SetActive(true);
        inputFields[1].SetActive(true);
        inputFields[2].SetActive(false);
        inputFields[3].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForgotPassword() {
        mobileNumber = _number.text;
        print("Forgot Password");
        print(mobileNumber);
        StartCoroutine(setOtp());

    }

    public IEnumerator setOtp() {
        WWWForm form = new WWWForm();
        form.AddField("mobile", mobileNumber);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/setforgotPasswordOtp.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        otp = www.downloadHandler.text;
        inputFields[0].SetActive(false);
        inputFields[1].SetActive(false);
        inputFields[2].SetActive(true);
        inputFields[3].SetActive(true);
        inputFields[4].SetActive(true);

    }

    public void resetPassword() 
    {

        password = _password.text;
        otp = _otp.text;
        
        StartCoroutine(setPassword());

    }
    public IEnumerator setPassword()
    {
        WWWForm form = new WWWForm();
        form.AddField("mobile", mobileNumber);
        form.AddField("otp", otp);
        form.AddField("password", password);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/setforgotPassword.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);

        if (www.downloadHandler.text== "UPDATED-PASSWORD") {
            print("SUCCESS");
        }

    }

    public void SignInButton() {

        print("SIGNIN");
        //ph.panel[0].SetActive(false);
        ph.panel[0].SetActive(true);
        ph.panel[4].SetActive(false);

    }




}
