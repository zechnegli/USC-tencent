using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class OrdersController : MonoBehaviour
{
    //绑定订单类
    public GameObject order;
    //同时最多存在的订单数
    private int OrdersMaxNum = 4;
    //当前订单数
    private int OrdersNum = 0;
    //timer list
    List<float> Timers = new List<float>();
    //订单list
    List<GameObject> orders = new List<GameObject>();
    //keyboard输入list
    List<KeyCode> keyboardNums = new List<KeyCode>();
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < OrdersMaxNum; i++)
        {
            GameObject newOb = GenerateOrder(i);
            orders.Add(newOb);
            Timers.Add((float)20.0);
        }
        keyboardNums.Add(KeyCode.Alpha1);
        keyboardNums.Add(KeyCode.Alpha2);
        keyboardNums.Add(KeyCode.Alpha3);
        keyboardNums.Add(KeyCode.Alpha4);
        
    }

    GameObject GenerateOrder(int num){
    /*
        用来随机生成订单
    */
        //创建一个订单instance
        GameObject ob = Instantiate(order);
        //绑定parent，parent为此controller所属的Orders
        ob.transform.SetParent(this.transform);
        //根据parent的position调整位置
        ob.transform.position = this.transform.position + getOrderPosition(num);

        //生成订单编号
        TextMeshProUGUI number = ob.GetComponentsInChildren<TextMeshProUGUI>()[0];
        number.text = (num + 1).ToString();

        //随机生成订单奖励
        TextMeshProUGUI reward = ob.GetComponentsInChildren<TextMeshProUGUI>()[2];
        reward.text = Random.Range(50,150).ToString();

        //get ingredients

        return ob;
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        //check timers
        for (int i = 0; i < orders.Count; i++){
            if(Timers[i] > 0){
                Timers[i] -= Time.deltaTime;
                orders[i].GetComponentsInChildren<TextMeshProUGUI>()[3].text = ((int)Timers[i]).ToString();
            }else if(Timers[i] != -(float)1){
                hideOrder(i, 0);
                Timers[i] = -(float)1;
            }
        }
    
        //select order to fulfill
        for (int i = 0; i < keyboardNums.Count; i++)
        {
            if (Input.GetKeyDown(keyboardNums[i])) {
                hideOrder(i, 1);           
            }
        }

        //show a new order after one second 
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                GameObject currentOrder = orders[i];
                if (!currentOrder.active)
                {
                    displayNewOrder(i);
                }
            }
            timer = 0f;
        }
    }

    void hideOrder(int index, int mode)
    {
        if (index < orders.Count)
        {
            GameObject currentOrder = orders[index];
            
            bool finished = false;
            
            if(mode==1){
                finished =  currentOrder.transform.GetChild(5).gameObject.GetComponent<MenuIngredientsController>().checkIngredients();
                if (!finished)
                {
                    return;
                }
            }
  
            
            if (Timers[index]>0 & finished & currentOrder.active)
            {
                TextMeshProUGUI reward = currentOrder.GetComponentsInChildren<TextMeshProUGUI>()[2];
                getPoints(Int32.Parse(reward.text));
            }
            currentOrder.SetActive(false);
            
        }
        
    }


    void getPoints(int num)
    {
        CoinCounterScript.instance.ChangeAmount(num);
    }

    void updateOrderIngredients(GameObject currentIngredients)
    {
        currentIngredients.GetComponent<MenuIngredientsController>().randomResetIngredients();
    }

    void displayNewOrder(int index)
    {
        if (index < orders.Count)
        {
            GameObject currentOrder = orders[index];
            currentOrder.SetActive(true);
            GameObject currentIngredients = currentOrder.transform.GetChild(5).gameObject;
            updateOrderIngredients(currentIngredients);
            Timers[index] = (float)20.0;
        }

    }

    Vector3 getOrderPosition(int num) 
    {
        return new Vector3(-(float)2.0 + (float)num * (float)1 + (float) (num - 1.0) * (float)0.25, -(float)0.01, 0);
    }

}
