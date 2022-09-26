using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SendToGoogle : MonoBehaviour
{
    public static SendToGoogle controller;
/*
    void Start(){
        StartCoroutine(PostData("Death reason test"));
    }
    

    IEnumerator PostData(string data){
        WWWForm form = new WWWForm();
       form.AddField("name", data);

       UnityWebRequest www = UnityWebRequest.Post("http://httpbin.org/post", form);

       yield return www.SendWebRequest();

       if(www.result != UnityWebRequest.Result.Success){
            Debug.Log(www.error);
       }
       else
       {
            string result = www.downloadHandler.text;
            Debug.Log(result);
       }
       www.Dispose();
    }
*/


   // [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSceSwrLei8_KauT0D9f6w_rnrzQQIVi-rbGjx5DhHa4JJytGA/formResponse";
   [SerializeField] private string URL; 
   private long sessionID;
    private string deathReason;

    private void Awake(){
      //  sessionID = System.DateTime.Now.Ticks;
        // Send();
    }

    void Start(){
       if(controller == null){
            controller = this;
         }
    }

    public void Send(string reason){
        sessionID = System.DateTime.Now.Ticks;
       // deathReason = "EnemyAttack";
        StartCoroutine(POST(sessionID.ToString(), reason));
    }

    private IEnumerator POST(string sessionID, string reason){
        WWWForm form = new WWWForm();
        form.AddField("entry.559194700",sessionID);
        form.AddField("entry.2089474490",reason);
        /*
        using(UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else{
                Debug.Log("Form uploaded complete!");
            }
        }*/
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
