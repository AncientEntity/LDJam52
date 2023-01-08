using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceBody : MonoBehaviour
{
    public string bodyName = "Unnamed Celestial Body";
    public float collisionRadius = 0.5f;
    public bool isHovering { protected set; get; }
    public bool isPressed { protected set; get; }
    [Space]
    public Transform actualBody; //Body inside Pivot.
    public Transform pivot; //Pivot.
    public SpriteRenderer sR;
    [Space]
    public bool activeProduction = true;
    public float resourcePurity = 1f;
    public int drillCount = 0;
    public float startingResources = 800;
    public float currentResources = 800;
    public float minedWaiting = 0;
    public List<DeliveryShip> shipsCurrentlyHere = new List<DeliveryShip>();


    public int currentCores = 1;
    public int startingCores = 1;

    protected string desc;
    public void Init(float height, string bodyName)
    {
        actualBody.localPosition = new Vector3(0f, height, 0f);
        pivot.transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 360f)));
        pivot.GetComponent<ObjectRotator>().rotateSpeed *= 1f/((height* height)*0.5f);

        this.bodyName = bodyName;
    }

    private void Update()
    {
        if (isPressed)
        {
            LevelManager.instance.selectionRadial.transform.position = Camera.main.WorldToScreenPoint(actualBody.position);
        }
        if (!isHovering && !isPressed)
        {
            float percentHarvested = currentResources / startingResources;
            sR.color = new Color(percentHarvested, percentHarvested, percentHarvested);
        }
        if(activeProduction)
        {
            float mineTick = Mathf.Clamp(drillCount * (float)Drill.drill_mining * Time.deltaTime, 0f, currentResources);
            currentResources -= mineTick;
            minedWaiting += mineTick;
        }
    }

    public virtual void OnHover() { isHovering = true; sR.color = Color.cyan; }
    public virtual void OnPress() {
        if(isPressed) { return; }
        isPressed = true;  sR.color = Color.cyan - new Color(0f,0.25f,0.25f,0f);

        if (GetType() == typeof(Planet))
        {
            OpenRadial();
        }
    }
    public virtual void OnRelease() { isPressed = false; if (isHovering) { sR.color = Color.cyan; } else { sR.color = Color.white; } }
    public virtual void OnUnHover() { 
        isHovering = false; sR.color = Color.white; 
        if (GetType() == typeof(Planet))
        {
            CloseRadial();
        }
    }
    private void OpenRadial()
    {
        LevelManager.instance.selectionRadial.transform.position = Camera.main.WorldToScreenPoint(actualBody.position);
        LevelManager.instance.selectionRadial.titleText.text = bodyName;

        UpdateRadialStats();

        LevelManager.instance.selectionRadial.ForceOpen(actualBody.transform,this);
    }

    public void UpdateRadialStats()
    {
        LevelManager.instance.selectionRadial.segmentSubmenus[0].transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = desc; //Description Menu
        //Resource Menu Icon
        LevelManager.instance.selectionRadial.optionParent.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = sR.sprite;
        //Resource Menu
        LevelManager.instance.selectionRadial.segmentSubmenus[1].transform.GetChild(2).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (int)currentResources + "/" + (int)startingResources + " Ores";
        LevelManager.instance.selectionRadial.segmentSubmenus[1].transform.GetChild(3).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (int)currentCores + "/" + (int)startingCores + " Planet Cores";

        ToggleColorSet();
        
    }


    private void CloseRadial()
    {
        LevelManager.instance.selectionRadial.transform.position = new Vector3(0f, 9999999f, 0f);
        LevelManager.instance.selectionRadial.ForceClose();
    }

    public void OnRadialPressed(int index)
    {
        if(index == 8)
        {
            activeProduction = !activeProduction;
            ToggleColorSet();
        }
    }

    private void ToggleColorSet()
    {
        //Toggle Color
        if (activeProduction)
        {
            LevelManager.instance.toggleRadial.color = new Color32(53, 164, 33, 116);
        }
        else
        {
            LevelManager.instance.toggleRadial.color = new Color32(164, 33, 42, 116);
        }
    }
}
