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

    public void Init(float height, string bodyName)
    {
        actualBody.localPosition = new Vector3(0f, height, 0f);
        pivot.transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 360f)));
        pivot.GetComponent<ObjectRotator>().rotateSpeed *= 1f/((height* height)*0.5f);

        this.bodyName = bodyName;
    }

    private void Update()
    {
        if(isPressed)
        {
            LevelManager.instance.selectionRadial.transform.position = Camera.main.WorldToScreenPoint(actualBody.position);
        }
    }

    public virtual void OnHover() { isHovering = true; sR.color = Color.cyan; }
    public virtual void OnPress() {
        if(isPressed) { return; }
        isPressed = true;  sR.color = Color.cyan - new Color(0f,0.25f,0.25f,0f);

        OpenRadial();
    }
    public virtual void OnRelease() { isPressed = false; if (isHovering) { sR.color = Color.cyan; } else { sR.color = Color.white; } }
    public virtual void OnUnHover() { isHovering = false; sR.color = Color.white; CloseRadial(); }
    private void OpenRadial()
    {
        LevelManager.instance.selectionRadial.transform.position = Camera.main.WorldToScreenPoint(actualBody.position);
        LevelManager.instance.selectionRadial.titleText.text = bodyName;
        LevelManager.instance.selectionRadial.ForceOpen(actualBody.transform);
    }

    private void CloseRadial()
    {
        LevelManager.instance.selectionRadial.transform.position = new Vector3(0f, 9999999f, 0f);
        LevelManager.instance.selectionRadial.ForceClose();
    }
}
