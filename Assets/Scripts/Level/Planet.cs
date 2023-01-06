using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SpaceBody
{
    public bool isGasGiant = false;
    public bool randomColor = false;
    public SpriteRenderer sR;
    public Sprite[] possibleSprites;

    private void Start()
    {
        Color c = new Color(1f,1f,1f);
        if (randomColor)
        {
            c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
            if(isGasGiant) { c.a = 0.8f; }
        sR.color = c;
        sR.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
    }

}
