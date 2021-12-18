using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDist = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPAth = false;

    Seeker seeker;
    Rigidbody2D rb;

  
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    //Enemy tracking and movement
    public void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);

        }
        
    }

    void OnPathComplete(Path _p)
    {
        if (!_p.error)
        {
            path = _p;
            currentWayPoint = 0;    
        }
    }

    void Update()
    {
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPAth = true;
            return;
        }

        else
        {
            reachedEndOfPAth = false;
        }

        Vector2 direction = (Vector2)path.vectorPath[currentWayPoint] - rb.position.normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWaypointDist)
        {
            currentWayPoint++;
        }

        //flips enemy to the direction it is moving towards
        if (force.x >= 0.01)
        {
            enemyGFX.localScale = new Vector3(-0.15f, 0.15f, 1f);
        }
        else if (force.x <= -0.01)
        {
            enemyGFX.localScale = new Vector3(0.15f, 0.15f, 1f);
        }

    }
}
