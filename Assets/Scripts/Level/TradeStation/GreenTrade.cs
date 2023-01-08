using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenTrade : MonoBehaviour
{
    public TextMeshPro GreenText;
    public TextMeshPro PurpleText;
    float time = 0;
    int inc1 = 60;
    int inc2 = 50;

    //Green range 50 - 250
    public float GreenCur = 100;
    float GreenTo = 100;
    float GreenFrom = 100;
    float GreenTime = 0;

    //purple range 75-175
    public float PurpleCur = 100;
    float PurpleTo = 100;
    float PurpleFrom = 100;
    float PurpleTime = 0;


    void Start()
    {
        GreenCur = Random.Range(75, 150);
        GreenFrom = GreenCur;
        
        PurpleCur = Random.Range(75, 150);
        PurpleFrom = PurpleCur;

        InvokeRepeating("Green_To_Update" , 5, inc1);
        InvokeRepeating("Purple_To_Update" , 5, inc2);
    }


    // Update is called once per frame
    void Update()
    {
        GreenText.text = GreenCur.ToString("F0");
        PurpleText.text = PurpleCur.ToString("F0");

        time += Time.deltaTime;
        Green_Update();
        Purple_Update();
    }



    void Green_To_Update(){
        GreenFrom = GreenCur;
        GreenTo = Random.Range(50,300);
        GreenTime = time; 
    }

    void Green_Update(){
        GreenCur = GreenFrom + ((GreenTo - GreenCur) * ((time - GreenTime) / (float)inc1));
    }




    void Purple_To_Update(){
        PurpleFrom = PurpleCur;
        PurpleTo = Random.Range(75,300);
        PurpleTime = time; 
    }

    void Purple_Update(){
        PurpleCur = PurpleFrom + ((PurpleTo - PurpleCur) * ((time - PurpleTime) / (float)inc2));
    }
    



}
