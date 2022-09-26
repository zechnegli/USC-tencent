using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadScript : MonoBehaviour
{
	public int breadNum = 1;
    private void OnTriggerEnter2D(Collider2D other)
   {
		if(other.gameObject.CompareTag("Player")){
			BreadCounterScript.instance.ChangeAmount(breadNum);
			Destroy(gameObject);
		}
   }
}
