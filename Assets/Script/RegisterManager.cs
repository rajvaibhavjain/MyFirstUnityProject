using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class RegisterManager : MonoBehaviour
{
    public OtpHandler otpHandler;
    //public AnimationHandler animationHandler;
    public InputField mobile;
    private string number;
    public InputField password;
    private string pass;
    private PanelHandler ph;
    private string json;
    private UserDetail _status;
    public Button loginButton;


    //private OtpHandler oh;

    //Sigup
    public InputField siName;
    public InputField siMobile;
    public InputField siEmail;
    public InputField siPass;
    public InputField siConformPass;
    public Button siButton;
    public Button forgotButton;

    string _siName;
    string _siEmail;
     string _siMobile;
    string _siPass;
    string _siConformPass;


    void Start()
    {

        ph = FindObjectOfType<PanelHandler>();
       // oh = FindObjectOfType<OtpHandler>();
      
        if (PlayerPrefs.GetString("mobile") == "")
        {
            ph.panel[0].SetActive(true);
        }
        else
        {
            ph.panel[0].SetActive(false);
            ph.panel[3].SetActive(true);
            mobile.text = PlayerPrefs.GetString("mobile");
            // pass = password.text;
        }
    }
    public void OnLogin()
    {
        // PlayerPrefs.SetString("mobile", mobile.text);

        //FindObjectOfType<AnimationHandler>().load.Play("loading");
        
        CheckFields();

    }
    public void OnSignIn()
    {
        

        print(siMobile.text);
        print("Registartion manager" + otpHandler.tempOTP);
        ////oh = FindObjectOfType<OtpHandler>();
        //print(siMobile.text);
        ////print(ph);
        ////print(oh);
        _siName = siName.text;
        _siEmail = siEmail.text;
        //print("SIGNIN");
        //siMobile.text = oh._mobileText;
        //_siMobile = oh._number.text;
        //print(siMobile.text);
        _siPass = siPass.text;
        _siConformPass = siConformPass.text;

        if (_siName != "" && _siEmail != "" &&  _siPass != "" && _siConformPass != "" && _siConformPass == _siPass)
        {
            print("SIGNIN2");
            StartCoroutine(SiginUser());
        }
        else
        {
            print("Please Enter All Vaid Details");
        }

    }

    public IEnumerator SiginUser()
    {

        print(_siMobile);
        WWWForm form = new WWWForm();
        form.AddField("name", _siName);
        form.AddField("mobile", _siMobile);
        form.AddField("email", _siEmail);
        form.AddField("password", _siPass);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/apisetuser.php", form);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);

    }

    public void CheckFields()
    {
        number = mobile.text;
        pass = password.text;
        if (number != "" && pass != "")
        {
            FindObjectOfType<AnimationHandler>().load.SetTrigger("On");
            StartCoroutine(LoginUser());
        }
        else
        {
            print("mobile is null");
        }
    }
    public IEnumerator LoginUser()
    {
        loginButton.interactable = false;
        //yield return new WaitForSeconds(5);
        WWWForm form = new WWWForm();
        form.AddField("mobile", number);
        form.AddField("password", pass);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/apigetlogin.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        json = www.downloadHandler.text;
        _status = JsonUtility.FromJson<UserDetail>(json);
        CheckStatus();
    }
    public void CheckStatus()
    {
        FindObjectOfType<AnimationHandler>().load.SetTrigger("Off");
        if (_status.status == "true" && _status.token != "")
        {
            
            //animation play right wrong credential
            PlayerPrefs.SetString("mobile", mobile.text);
            PlayerPrefs.SetString("token", _status.token);
            ph.panel[0].SetActive(false);
            ph.panel[3].SetActive(true);     //mainpanel active
        }
        else if (_status.status == "false")
        {
            loginButton.interactable = true;


            //animation play wrong credential
            //playerprefs.deleteall();
        }
        

    }

    void Update()
    {

    }

    public void ForgotButton()
    {

        ph.panel[0].SetActive(false);
        ph.panel[4].SetActive(true);
    }
}
public class UserDetail
{
    public string status;
    public string token;
    public string message;

}

