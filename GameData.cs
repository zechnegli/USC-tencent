using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
   public string deathReason;
   public int deathAmount;

   public GameData(string reason, int amount){
	deathReason = reason;
	deathAmount = amount;
   }
}
