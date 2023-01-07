using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TextMeshProUGUI timeLeftText;
    [Space]
    private List<SpaceBody> solarBodies = new List<SpaceBody>();
    private List<PlayerBuild> playerBuilds { get { return PlayerBuild.all; } }

    private bool isInit = false;
    private Vector2 lastMousePosition = Vector2.zero;
    private SpaceBody currentlyPressed = null;

    private float timeLeft = 60 * 5;

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
        
        timeLeft -= Time.deltaTime;
        timeLeftText.text = "Till Supernova: " + (timeLeft/60f).ToString("F2") +"yrs";
        
    }

    private void CheckPlanetSelect()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(currentMousePosition == lastMousePosition) { return; }

        bool leftClick = Input.GetMouseButtonDown(0);
        bool rightClick = Input.GetMouseButtonDown(1);

        foreach (SpaceBody body in solarBodies)
        {
            if(currentlyPressed != null && currentlyPressed != body) { continue; }

            float dis = Vector2.Distance(body.actualBody.position, currentMousePosition);
            if (dis <= body.collisionRadius)
            {
                if (!body.isHovering)
                {
                    body.OnHover();
                }
                if(leftClick) { currentlyPressed = body;  body.OnPress(); }
            }
            if((body.isPressed && dis > body.collisionRadius*5f) || ((!body.isPressed && dis > body.collisionRadius))) {
                if (body.isHovering)
                {
                    body.OnUnHover();
                }
                if(body.isPressed)
                {
                    body.OnRelease();
                    currentlyPressed = null;
                }
            }
        }
        if (leftClick)
        {
            bool anyShips = false;
            foreach (PlayerBuild build in playerBuilds.ToArray())
            {
                if (build == null) { playerBuilds.Remove(build); continue; }

                float dis = Vector2.Distance(build.transform.position, currentMousePosition);
                if (dis <= build.collisionRadius)
                {
                    build.SetSelected(!build.isSelected);
                    anyShips = true;
                }

            }
            if (!anyShips)
            {
                foreach (PlayerBuild build in playerBuilds)
                {
                    if (build.isSelected)
                    {
                        build.SetSelected(false);
                    }
                }
            }
        }

        if(rightClick && PlayerBuild.selectedBuilds.Count > 0)
        {
            SpaceBody hovering = CheckSpaceBodyHover();
            if(hovering == null)
            {
                foreach(PlayerBuild select in PlayerBuild.selectedBuilds)
                {
                    select.DoMove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            } else
            {
                //If planet, if trade station, etc.
            }
        }

    }


    public SpaceBody CheckSpaceBodyHover()
    {

        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (SpaceBody body in solarBodies)
        {
            if (currentlyPressed != null && currentlyPressed != body) { continue; }

            float dis = Vector2.Distance(body.actualBody.position, currentMousePosition);
            if (dis <= body.collisionRadius)
            {
                return body;
            }
        }
        return null;
    }

}
