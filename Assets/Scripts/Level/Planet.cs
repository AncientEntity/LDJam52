using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SpaceBody
{
    public bool isGasGiant = false;
    public SpriteRenderer sR;

    private void Start()
    {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        if(isGasGiant) { c.a = 0.8f; }
        sR.color = c;
    }

}
