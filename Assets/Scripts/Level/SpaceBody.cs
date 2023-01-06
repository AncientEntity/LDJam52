using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBody : MonoBehaviour
{
    public Transform actualBody; //Body inside Pivot.
    public Transform pivot; //Pivot.

    public void Init(float height)
    {
        actualBody.localPosition = new Vector3(0f, height, 0f);
        pivot.transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 360f)));
        pivot.GetComponent<ObjectRotator>().rotateSpeed *= 1f/((height* height)*0.5f);
    }
}
