using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardImages : MonoBehaviour
{
    
    public Sprite[] sprites;
    
    void Start()
    {
        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
