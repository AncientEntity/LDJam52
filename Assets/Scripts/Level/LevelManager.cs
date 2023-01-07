using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static readonly string[] bodySuffixes = { "A", "B", "C", "D", "E", "F", "G", "H", "I"};

    public static LevelManager instance = null;
    [Space]
    public GameObject sunPrefab;
    public List<GameObject> bodyPrefabs = new List<GameObject>();
    public string[] possibleBodyNames;
    [Space]
    public Transform bodyParent;
    public GameObject[] orbits;
    public RadialSelection selectionRadial;
    [Space]
    private List<SpaceBody> solarBodies = new List<SpaceBody>();

    private bool isInit = false;
    private Vector2 lastMousePosition = Vector2.zero;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (isInit) { return; }
        isInit = true;

        GameObject star = Instantiate(sunPrefab, bodyParent.position, Quaternion.identity);
        star.transform.SetParent(bodyParent);
        SpaceBody starBody = star.GetComponent<SpaceBody>();
        solarBodies.Add(starBody);

        string systemName = possibleBodyNames[Random.Range(0, possibleBodyNames.Length)];
        if (Random.Range(0, 100) <= 20)
        {
            systemName = "" + Random.Range(1000, 100000);
        }

        starBody.bodyName = systemName + " A";


        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            GameObject body = Instantiate(bodyPrefabs[Random.Range(0, solarBodies.Count)], bodyParent.position, Quaternion.identity);
            body.transform.SetParent(bodyParent);
            SpaceBody spaceBody = body.GetComponent<SpaceBody>();
            spaceBody.Init((i + 1.5f), systemName + " " + bodySuffixes[i + 1]);
            solarBodies.Add(spaceBody);
            orbits[i].SetActive(true);
        }



    }

    private void Update()
    {
        CheckPlanetSelect();
    }

    private void CheckPlanetSelect()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(currentMousePosition == lastMousePosition) { return; }

        foreach(SpaceBody body in solarBodies)
        {
            float dis = Vector2.Distance(body.actualBody.position, currentMousePosition);
            if (dis <= body.collisionRadius)
            {
                if (!body.isHovering)
                {
                    body.OnHover();
                }
                if(Input.GetMouseButtonDown(0)) { body.OnPress(); }
            }
            if((body.isPressed && dis > body.collisionRadius*5f) || ((!body.isPressed && dis > body.collisionRadius))) {
                if (body.isHovering)
                {
                    body.OnUnHover();
                }
                if(body.isPressed)
                {
                    body.OnRelease();
                }
            }
        }

    }


}
