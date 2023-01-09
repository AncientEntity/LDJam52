using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeliveryShip : PlayerBuild
{
    public shipState state = shipState.Idle;
    public float stopDistance = 0.1f;
    public float moveSpeed = 0.1f;

    public ParticleSystem engineParticles;
    public SpaceBody targetPlanet;
    public Transform targetStation;
    [Space]
    public LineRenderer pathLine;
    public LineRenderer targetLine;

    public TextMeshPro valueText;



    public enum shipState
    {
        Retrieving,
        Selling,
        Idle,
    }

    private void Start()
    {
        maxResources = Ship.storage_amm;
        moveSpeed = (float) (0.03 * Ship.speed_power);
    }

    private void Update()
    {

        if (canMove)
        {
            pathLine.SetPosition(0, transform.position);
            pathLine.SetPosition(1, targetPosition);
            DoMovement();
        }
        if(isSelected && targetPlanet != null && targetStation != null)
        {
            targetLine.SetPosition(0, targetPlanet.actualBody.position);
            targetLine.SetPosition(1, targetStation.position);
            targetLine.enabled = true;
        } else
        {
            targetLine.enabled = false;
        }
        StateHandler();
        if(!canMove && state == shipState.Retrieving && targetPlanet != null)
        {
            if(!targetPlanet.shipsCurrentlyHere.Contains(this)) { targetPlanet.shipsCurrentlyHere.Add(this); }

            transform.SetParent(targetPlanet.actualBody);
            //At planet to retrieve
            if (targetPlanet.currentResources <= 0) { targetPlanet = null;transform.SetParent(null); return; }
            float oresTaken = Mathf.Clamp(1f,0f,targetPlanet.minedWaiting / targetPlanet.shipsCurrentlyHere.Count);
            targetPlanet.minedWaiting -= oresTaken;
            SetResources(resourceCount + oresTaken);

            if(resourceCount >= maxResources)
            {
                resourceCount = maxResources;
                state = shipState.Selling;
                transform.SetParent(null);
                targetPlanet.shipsCurrentlyHere.Remove(this);
            }
        }
        else if (!canMove && state == shipState.Selling && targetStation != null)
        {
            if(Vector2.Distance(targetStation.position,transform.position) >= 0.7f)
            {
                //canMove = true;
                //targetPosition = targetStation.position;
                DoMove(targetStation.position, false);
            } else
            {
                float price = 0;
                if(LevelManager.instance.tradeStations[0] == targetStation)
                {
                    price = FindObjectOfType<GreenTrade>().GreenCur;
                } else
                {
                    price = FindObjectOfType<GreenTrade>().PurpleCur;
                }

                LevelManager.instance.stageMoney += (int)(resourceCount * price);
                Summery.money_made =+ (int)(resourceCount * price);
                Summery.ore_mined =+ (int)(resourceCount);
                SetResources(0);
                state = shipState.Idle;
            }
        }
    }

    private void StateHandler()
    {

        if (state != shipState.Idle && targetPlanet == null)
        {
            state = shipState.Idle;
        }
        else if (state == shipState.Idle && targetPlanet != null)
        {
            if (resourceCount >= maxResources)
            {
                state = shipState.Selling;
            }
            else
            {
                state = shipState.Retrieving;
                DoMove(targetPlanet.actualBody.position,false);
                //targetPosition = targetPlanet.actualBody.position;
                //canMove = true;
            }
        }

    }

    private void DoMovement()
    {
        if(Vector2.Distance(transform.position,targetPosition) <= stopDistance)
        {
            engineParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            canMove = false;
            pathLine.enabled = false;
        } else
        {
            //Look At Target
            Vector3 diff = targetPosition - new Vector2(transform.position.x, transform.position.y);
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);


            //Todo: Movement Here
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    


    public override void DoMove(Vector2 position,bool overridePlanet=true)
    {
        canMove = true;
        targetPosition = position;
        if (overridePlanet)
        {
            targetPlanet = null;
            transform.SetParent(null);
        }

        engineParticles.Play();
        pathLine.enabled = true;

    }

    public override void SetSelected(bool selected)
    {
        base.SetSelected(selected);
        targetLine.enabled = selected;
    }

    public void SetResources(float v)
    {
        resourceCount = v;
        valueText.text = "" + v.ToString("F1");

        valueText.enabled = v > 0;

    }

}
