using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SpaceBody
{
    public bool isGasGiant = false;
    public bool randomColor = false;
    public Sprite[] possibleSprites;
    public string[] possibleDescriptions;

    private int spriteIndex = -1;

    private void Start()
    {
        Color c = new Color(1f,1f,1f);
        if (randomColor)
        {
            c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
            if(isGasGiant) { c.a = 0.8f; }
        sR.color = c;
        spriteIndex = Random.Range(0, possibleSprites.Length);
        sR.sprite = possibleSprites[spriteIndex];
        desc = possibleDescriptions[Random.Range(0, possibleDescriptions.Length)];
    }

    public override void OnHover()
    {
        base.OnHover();
    }

    public override void OnUnHover()
    {
        base.OnUnHover();
    }

}
