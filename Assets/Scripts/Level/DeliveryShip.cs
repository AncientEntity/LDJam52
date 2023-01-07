using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryShip : PlayerBuild
{
    public float stopDistance = 0.1f;
    public float moveSpeed = 0.1f;

    public ParticleSystem engineParticles;
    public SpaceBody targetPlanet;


    private void Update()
    {
        if (canMove)
        {
            DoMovement();
        }
    }

    private void DoMovement()
    {
        if(Vector2.Distance(transform.position,targetPosition) <= stopDistance)
        {
            engineParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            canMove = false;
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

    


    public override void DoMove(Vector2 position)
    {
        canMove = true;
        targetPosition = position;

        engineParticles.Play();

    }
}
