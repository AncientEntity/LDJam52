using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBuild : MonoBehaviour
{
    public static List<PlayerBuild> all = new List<PlayerBuild>();
    public static List<PlayerBuild> selectedBuilds = new List<PlayerBuild>();

    public GameObject selectionCircle;
    [Space]
    public bool canMove = false;
    public Vector2 targetPosition = Vector2.zero;
    public float collisionRadius = 0.5f;
    public float resourceCount = 0;
    public int maxResources = 0;

    public bool isSelected { get; protected set; }
    

    private void Awake()
    {
        all.Add(this);
    }
    private void OnDestroy()
    {
        all.Remove(this);
    }


    public abstract void DoMove(Vector2 position, bool overridePlanet);
    public virtual void SetSelected(bool selected)
    {
        isSelected = selected;
        selectionCircle.SetActive(selected);
        if(selected)
        {
            selectedBuilds.Add(this);
        } else
        {
            selectedBuilds.Remove(this);
        }
    }


}
