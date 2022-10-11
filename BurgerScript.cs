using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class BurgerScript : MonoBehaviour
{
    public int burgernum = 1;
    //public Sprite[] sprites;
    //private int oldSprite;
    //private int newSprite;
    //private List<int> availableSprites = new List<int>();
    //public GameObject[] food;

    /*void Start() {
  oldSprite = 0;
  for (int i = 0; i < sprites.Length; i++) {
   availableSprites.Add(i);
  }
  GameObject gameObject = Instantiate(food[Random.Range(0, sprites.Length)]);
 }*/


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
          
            BurgerCounterScript.instance.ChangeAmount(burgernum);
            CoinCounterScript.instance.ChangeAmount(20);
       
          
            float x_coordinate = Random.Range(-4.3f, 45f);
            float y_coordinate = 0f;
            if (x_coordinate < 14.95)
            {
                y_coordinate = Random.Range(-0.7f, 0.5f);
            }
            else if (x_coordinate < 20.23)
            {
                y_coordinate = Random.Range(-0.58f, 1.68f);
            }
            else if (x_coordinate < 24.97)
            {
                y_coordinate = Random.Range(1.26f, 2.65f);
            }
            else if (x_coordinate < 28.47)
            {
                y_coordinate = Random.Range(-0.24f, 1.51f);
            }
            else if (x_coordinate < 31.37)
            {
                y_coordinate = Random.Range(-1.75f, 2.36f);
            }
            else if (x_coordinate <= 45)
            {
                y_coordinate = Random.Range(-1.84f, -0.34f);
            }


            this.gameObject.transform.localPosition = new Vector3(x_coordinate, y_coordinate, 0);
            //GameObject.Find("RandomHandler").GetComponent<RandomHandler>().SpawnNewMaterial();
        }
        /*availableSprites.Remove(oldSprite);
  newSprite = availableSprites[Random.Range(0,availableSprites.Count)];
  GetComponent<SpriteRenderer>().sprite = sprites[newSprite];
  
  availableSprites.Add(oldSprite);
  oldSprite = newSprite;*/
    }


}