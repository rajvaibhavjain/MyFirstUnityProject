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
    void Start()
    {
    }
    public void OnLogin()
    {
         StartCoroutine(LoginUser());
    }
   public IEnumerator LoginUser()
  {
        number =mobile.text ;
        pass =  password.text ;
        WWWForm form = new WWWForm();
        form.AddField("mobile", number);
        form.AddField("password", pass);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/2019-11-13-etechmy/rechageunityapp/apigetlogin.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
  } 
    
    void Update()
    {
        
    }
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