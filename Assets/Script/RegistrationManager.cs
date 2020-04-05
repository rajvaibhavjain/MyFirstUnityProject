using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class RegistrationManager : MonoBehaviour
{
    public InputField mobile;
    private string number;
    public InputField password;
    private string pass;
    private PanelHandler ph;
    private string json;
    private UserDetail _status;
    void Start()
    {
        ph = FindObjectOfType<PanelHandler>();
        if (PlayerPrefs.GetString("mobile") == "")
        {
            ph.panel[0].SetActive(true);
        }
        else
        {
            ph.panel[0].SetActive(false);
            ph.panel[2].SetActive(true);
            mobile.text = PlayerPrefs.GetString("mobile");
           // pass = password.text;
        }
    }
    public void OnLogin()
    {
        // PlayerPrefs.SetString("mobile", mobile.text);
        CheckFields();
       
    }
    public void CheckFields()
    {
        number = mobile.text;
        pass = password.text;
        if (number != "" && pass!="")
        {
            StartCoroutine(LoginUser());
        }
        else
        {
            print("mobile is null");
        }
    }
   public IEnumerator LoginUser()
   { 
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
        if(_status.status == "true" && _status.token != "")
        {
            //animation play right wrong credential
            PlayerPrefs.SetString("mobile", mobile.text);
            PlayerPrefs.SetString("token", _status.token);
            ph.panel[0].SetActive(false);
            ph.panel[2].SetActive(true);
        }
        //else if (_status.status == "false")
        //{
        //    //animation play wrong credential
        //    //playerprefs.deleteall();
        //}

    }

    void Update()
    {
        
    }
}
public class UserDetail
    {
    public string status;
    public string token;
    public string message;

    }
// private string serverIp;
//     public InputField iptext;
//     private string url;
//     if (PlayerPrefs.GetString("IPAddress") == "")
//         {
//             GetComponent<PanelManager>().panels[1].SetActive(true);
//             GetComponent<PanelManager>().panels[0].SetActive(false);
//         }
//         else
//         {
//             iptext.text = PlayerPrefs.GetString("IPAddress");          
//         }
//         Debug.Log(PlayerPrefs.GetString("IPAddress"));
//         url = "http://" + PlayerPrefs.GetString("IPAddress") + "/grohae/setstatus.php";
//         public void OnSubmit()
//     {
//         serverIp = iptext.text;
//         PlayerPrefs.SetString("IPAddress", serverIp);
//         url = "http://" + PlayerPrefs.GetString("IPAddress") + "/grohae/setstatus.php";
//         Debug.Log(url);
//         Invoke("ChangePanel", DelayTime);
//     }