using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pathfinding;

public class NpcBehaviour : MonoBehaviour
{

    public static event Action<List<MesaBar>> TableInicialization;

    public enum State { Waiting, WaitingForDrink, Walking, Sitting, Drinking, WaitingForPayment };
    public State currentState;
    
    
    public float smoothing = 0.5f;
    public Transform target;
    public Transform caixa;

    public float speed = 5f;
    public float nextWaypointDistance = 1f;
    
    private List<MesaBar> mesas;
    private MesaBar _mesaBarAtual;
    
    Seeker seeker;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath;

    public Vector2 direction;
    public delegate void OnArriveDelegate();


    private NpcMoodManager moodManager;
    private NpcAnimator animatorScript;

    
    void Start()
    {
        seeker = GetComponent<Seeker>();

        moodManager = GetComponent<NpcMoodManager>();
        animatorScript = GetComponentInChildren<NpcAnimator>();

        path = seeker.StartPath(transform.position, target.position, OnPathComplete);
        mesas = new List<MesaBar>();
        TableInicialization?.Invoke(mesas);
        ChooseTarget();
        StartCoroutine(GoTo(target, PlaySitting));
    }

    private void ChooseTarget()
    {
        foreach (var mesa in mesas.Where(mesa => mesa.EmptyForClients))
        {
            target = mesa.GetComponentInChildren<Transform>();
            _mesaBarAtual = mesa;
            _mesaBarAtual.EmptyForClients = false;
            break;
        }
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
                Vector2 moveSpeed = direction * (speed * Time.deltaTime);
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
        StartCoroutine(Sitting());
    }

    private IEnumerator Sitting()
    {
        currentState = State.Sitting;
        transform.position = target.GetChild(0).GetChild(0).position;
        print(currentState);

        yield return new WaitForSeconds(1);
        animatorScript.PlayReaction("BeerPlease");
        currentState = State.WaitingForDrink;
        _mesaBarAtual.WaitingDrink = true;
        _mesaBarAtual.RecebeuCerveja += StartDrinking;
    }

    private void StartDrinking()
    {
        StartCoroutine(Drinking());
    }
    
    private IEnumerator Drinking()
    {
        moodManager.FeedbackReaction();
        seeker.StartPath(transform.position, caixa.position, OnPathComplete);
        print("started drinking");
        //nimatorScript.StopReaction();
        currentState = State.Drinking;
        yield return new WaitForSeconds(6); // drinking time;
        _mesaBarAtual.FinishedDrinking();
        StartCoroutine(GoTo(caixa, RequestPayment));
    }

    void RequestPayment()
    {
        currentState = State.WaitingForPayment;
        CaixaRegistradora.WaitInLine(this);
        print("Esperando pagamento");
    }

    public void FinishPayment()
    {
        print("Pagou");
    }
}
