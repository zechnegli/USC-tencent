using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Ending : MonoBehaviour
{
    public static Ending controller;


   // [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSd1_rbrsD0jjcogr2lZZJ5CKV6cV0GdMsnSBudu59W4Rt9Nfw/formResponse";
   [SerializeField] private string URL; 
   private long sessionID;
    private string ending;

    private void Awake(){
      //  sessionID = System.DateTime.Now.Ticks;
        // Send();
    }

    void Start(){
       if(controller == null){
            controller = this;
         }
    }

    public void Send(string ending){
        sessionID = System.DateTime.Now.Ticks;
       // deathReason = "EnemyAttack";
        StartCoroutine(POST(sessionID.ToString(), ending));
    }

    private IEnumerator POST(string sessionID, string ending){
        WWWForm form = new WWWForm();
        form.AddField("entry.194573618",sessionID);
        form.AddField("entry.1244086073",ending);
       
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
