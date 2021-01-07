using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NpcBehaviour : MonoBehaviour
{
    public enum State { Waiting, Walking, Sitting, Drinking };
    public State currentState;
    
    
    public float smoothing = 0.5f;
    public Transform target;

    public float speed = 5f;
    public float nextWaypointDistance = 1f;

    Seeker seeker;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath;

    public Vector2 direction;

    private NpcAnimator animatorScript;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        animatorScript = GetComponentInChildren<NpcAnimator>();
    }

    
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            print("we here");
            if (currentState != State.Sitting)
            {
                StartCoroutine(Sitting());
            }

            return;
        }
        else
        {
            reachedEndofPath = false;
            currentState = State.Walking;
        }

        direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)transform.position).normalized;
        Vector2 moveSpeed = direction * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveSpeed.x, transform.position.y + moveSpeed.y);

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnPathComplete(Path p)
    {
        if  (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            
        }
    }

    IEnumerator Sitting()
    {
        currentState = State.Sitting;
        transform.position = target.GetChild(0).position;
        print(currentState);

        yield return new WaitForSeconds(1);

        animatorScript.PlayReaction("BeerPlease");
        print("BEER");
    }
}
