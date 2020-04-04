using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelHandler : MonoBehaviour
{
    // Cool
    /
    public GameObject[] panel;
    void Start()
    {      
        panel[0].SetActive(true);   
         
    }

  //on click active respective panel
  public void SelectPanel(int x)
  {
      for(int i =0; i<panel.Length; i++)
      {
         if(i==x)
         {
             panel[i].SetActive(true);
         }
         else
         {
             panel[i].SetActive(false);
         }
      }
  }
  
 
    void Update()
    {
        
    }
}
