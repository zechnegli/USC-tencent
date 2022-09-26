
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using System;
using System.Linq;

public class GameDataController : MonoBehaviour
{

    public static GameDataController controller;

     string path ;
   //   private GameData gameData = new GameData();
      List<GameData> entries = new List<GameData>();

      void Awake(){
       // path = "C:/Users/lenovo/Desktop/GameData/gamedata.json";
       // path = Application.persistentDataPath + "/gamedata.json";
       /*
        gameData.deathReason = "deathZone";
        gameData.deathAmount = 0;
        Debug.Log("debug log line");
        string json = JsonUtility.ToJson(gameData);
        Debug.Log(json);

        GameData loadedData = JsonUtility.FromJson<GameData>(json);
        Debug.Log(loadedData.deathReason);
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        if(controller == null){
            controller = this;
         }
         path = Application.streamingAssetsPath + "/gamedata.json";

       //  entries = readListFromFile<GameData>();
   //    writeToFile(entries);
    }

  

    public void readFile(){
        Debug.Log("path is used");
        if(File.Exists(path)){
            string fileContents = File.ReadAllText(path);

           // gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    private void Save(){
        
    }

    public void addDeathReasonToList(string reason){
         List<GameData> content = readListFromFile();
         bool exist = false;
        foreach(var data in content){
            if(String.Equals(data.deathReason, reason)){
                exist = true;
                data.deathAmount += 1;
            }
        }
        if(exist == false){
            content.Add(new GameData(reason, 1));
        }
        writeToFile(content);
    }


    public List<GameData> readListFromFile(){
        Debug.Log("path is used");
        if(File.Exists(path) == false) return new List<GameData>();
        Debug.Log("path is used");
        string content = File.ReadAllText(path);

        if(string.IsNullOrEmpty(content) || content == "{}"){
            return new List<GameData>();
        }

        List<GameData> res = JsonHelper.FromJson<GameData>(content).ToList();

        return res;
    }

    public void writeToFile(List<GameData> content){
        string json = JsonHelper.ToJson<GameData>(content.ToArray());
        Debug.Log("path is used");
         File.WriteAllText(path, json);
      //  Debug.Log(path);
        Debug.Log(json);

    }
    /*
    public void writeFile(string deathReason){
        string json = "";
        if(File.Exists(path) == false){
            GameData idle = new GameData();
              idle.deathReason = "DeathZone1";
              idle.deathAmount = 0;
            
            json = JsonUtility.ToJson(idle);
            File.WriteAllText(path, json);
        }
            string saveString = File.ReadAllText(path);
            Debug.Log("original record: " + saveString);
            GameData deathData = JsonUtility.FromJson<GameData>(saveString); 
            deathData.deathAmount = deathData.deathAmount + 1;
            json = JsonUtility.ToJson(deathData);
            File.WriteAllText(path, json);
            Debug.Log(path);
            saveString = File.ReadAllText(path);
             Debug.Log(saveString);
        
        

        /*
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(path,jsonString);
        
    }*/
}

public static class JsonHelper{
        public static T[] FromJson<T>(string json){
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array){
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint){
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>{
            public T[] Items;
        }

}


