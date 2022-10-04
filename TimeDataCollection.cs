using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TimeDataCollection : MonoBehaviour
{
    public static TimeDataCollection controller;


   // [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvtT54UjKPsm3Odq082PAP8nsf1roHByPAMQfrl-XsGnxrGg/formResponse";
   [SerializeField] private string URL; 
   private long sessionID;
    private string time;

    private void Awake(){
      //  sessionID = System.DateTime.Now.Ticks;
        // Send();
    }

    void Start(){
       if(controller == null){
            controller = this;
         }
    }

    public void Send(string time){
        sessionID = System.DateTime.Now.Ticks;
       // deathReason = "EnemyAttack";
        StartCoroutine(POST(sessionID.ToString(), time));
    }

    private IEnumerator POST(string sessionID, string time){
        WWWForm form = new WWWForm();
        form.AddField("entry.16651844",sessionID);
        form.AddField("entry.688772289",time);
       
        using(UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
           // Debug.Log("url is: " + URL);
            yield return www.SendWebRequest();
            
            if(www.result != UnityWebRequest.Result.Success)
            {
               // Debug.Log(www.error);
            }
            /*
            if(www.error != null){
                Debug.Log(www.error);
            }*/
            else{
              //  Debug.Log("Form uploaded complete!");
            }
         }
    }
}
