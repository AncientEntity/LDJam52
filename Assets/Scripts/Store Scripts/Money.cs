using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text ValueText;

    void Update()
    {
        ValueText.text = "$" + GameManager.money.ToString();
    }
}
