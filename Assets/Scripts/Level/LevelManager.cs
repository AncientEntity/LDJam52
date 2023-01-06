using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    [Space]
    public GameObject sunPrefab;
    public List<GameObject> bodyPrefabs = new List<GameObject>();
    [Space]
    public Transform bodyParent;
    public GameObject[] orbits;
    [Space]
    private List<SpaceBody> solarBodies = new List<SpaceBody>();

    private bool isInit = false;

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
        if(isInit) { return; }
        isInit = true;

        GameObject star = Instantiate(sunPrefab, bodyParent.position,Quaternion.identity);
        star.transform.SetParent(bodyParent);
        solarBodies.Add(star.GetComponent<SpaceBody>());

        for (int i = 0; i < Random.Range(2,5); i++)
        {
            GameObject body = Instantiate(bodyPrefabs[Random.Range(0,solarBodies.Count-1)], bodyParent.position, Quaternion.identity);
            body.transform.SetParent(bodyParent);
            SpaceBody spaceBody = body.GetComponent<SpaceBody>();
            spaceBody.Init((i + 1.5f));
            solarBodies.Add(spaceBody);
            orbits[i].SetActive(true);
        }
        


    }



}
