using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyNaming : MonoBehaviour
{
        public string[] nameString;
        public TextMeshProUGUI systemName;
    
        void Start()
        {
                systemName.text = nameString[Random.Range(0, 7)];
        }

}