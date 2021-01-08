﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NpcBehaviour : MonoBehaviour
{
    public enum State { Waiting, Walking, Sitting, Drinking };
    public State currentState;
    
    
    public float smoothing = 0.5f;
    public Transform target;
    public Transform caixa;

    public float speed = 5f;
    public float nextWaypointDistance = 1f;


    Seeker seeker;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath;

    public Vector2 direction;
    public delegate void OnArriveDelegate();



    private NpcAnimator animatorScript;

    // PROBLEMA: temos que esperar o path ser achado pra começar a andar
    void Start()
    {
        seeker = GetComponent<Seeker>();
        
        animatorScript = GetComponentInChildren<NpcAnimator>();
        path = seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(GoTo(target, PlaySitting));
        
    }


    IEnumerator GoTo(Transform target, OnArriveDelegate Arrived)
    {
        while (!path.IsDone()) yield return null;
        bool hasArrived = false;

        if (path != null)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                hasArrived = true;
                reachedEndofPath = true;
                
            }
            else
            {
                reachedEndofPath = false;
                currentState = State.Walking;
            }
        }

        while (!hasArrived)
        {

            if (currentWaypoint < path.vectorPath.Count)
            {
                direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)transform.position).normalized;
                Vector2 moveSpeed = direction * speed * Time.deltaTime;
                transform.position = new Vector2(transform.position.x + moveSpeed.x, transform.position.y + moveSpeed.y);
                float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                    print("current waypoint:" + currentWaypoint);
                }

            }
            else break;

            yield return null;
        }

        Arrived();
        yield return null;
    }

    void OnPathComplete(Path p)
    {
        if  (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void PlaySitting()
    {
        StartCoroutine("Sitting");
    }

    IEnumerator Sitting()
    {
        currentState = State.Sitting;
        transform.position = target.GetChild(0).position;
        print(currentState);

        yield return new WaitForSeconds(1);
        animatorScript.PlayReaction("BeerPlease");

        // fingir que ta com a beer agr
        yield return new WaitForSeconds(4);
        StartCoroutine(Drinking());
    }

    IEnumerator Drinking()
    {
        seeker.StartPath(transform.position, caixa.position, OnPathComplete);
        print("started drinking");
        animatorScript.StopReaction();
        currentState = State.Drinking;
        yield return new WaitForSeconds(6); // drinking time;

        StartCoroutine(GoTo(caixa, NotImplemented));
    }

    void NotImplemented()
    {
        print("pagar");
    }
}
