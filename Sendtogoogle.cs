using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sendtogoogle : MonoBehaviour
{
    //public static Sendtogoogle controller;
    
    public GameObject meatamount;
    public GameObject vegeamount;
    public GameObject breadamount;
    public GameObject coinamount;
   
    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfBsFFlbJc6ccvXSH-hnC1iCaQzM5LUnXFokSYEhSzMCGMukg/formResponse";

    private string Meatamount;
    private string Vegeamount;
    private string Breadamount;
    private string Coinamount;


    IEnumerator Post(string meat, string vege,string bread,string coin)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.366340186", meat);
        form.AddField("entry.151732038", vege);
        form.AddField("entry.100099410", bread);
        form.AddField("entry.667562814", coin);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void Send()
    {
        Meatamount = meatamount.GetComponent<MeatCounterScript>().text.text;
        Vegeamount = vegeamount.GetComponent<VegetableCounterScript>().text.text;
        Breadamount = breadamount.GetComponent<BreadCounterScript>().text.text;
        Coinamount = coinamount.GetComponent<CoinCounterScript>().text.text;


        StartCoroutine(Post(Meatamount,Vegeamount , Breadamount, Coinamount));

    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
