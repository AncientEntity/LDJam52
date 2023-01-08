using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SpaceBody
{
    public bool isGasGiant = false;
    public bool randomColor = false;
    public Sprite[] possibleSprites;
    public string[] possibleDescriptions;
    [Space]
    public Vector2 minMaxOres;
    public Vector2Int minMaxCores;

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

        startingResources = Random.Range(minMaxOres.x, minMaxOres.y);
        startingCores = Random.Range(minMaxCores.x, minMaxCores.y+1);
        currentResources = startingResources;
        currentCores = startingCores;


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
