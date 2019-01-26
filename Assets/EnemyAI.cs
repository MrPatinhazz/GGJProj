using System.Collections;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    //Chase target
    public Transform target;

    //Path update rate
    public float updateRate = 2f;

    private Seeker _seeker;
    private Rigidbody2D rb;

    //Calculated path
    public Path path;

    //Ai speed/s
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //Max distance from AI to waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3f;

    //We're moving towards here
    private int _currentWaypoint = 0;

    //private void Start()
    //{
    //    _seeker = GetComponent<Seeker>();
    //    rb = GetComponent<Rigidbody2D>();

    //    if(target == null)
    //    {
    //        Debug.LogError("No player found");
    //        return;
    //    }

    //    //Starts a new path
    //    _seeker.StartPath(transform.position, target.position, OnPathComplete);

    //    StartCoroutine(UpdatePath());
    //}

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            //Search Player
            yield return false;
        }

        _seeker.StartPath(transform.position, target.position, OnPathComplete);
    
        yield return new WaitForSeconds (1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log(p.error);
        if(!p.error)
        {
            path = p;
        }

        _currentWaypoint = 0;        
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            //Search Player
            return;
        }

        if(path == null)
        {
            return;
        }

        if (_currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        // Vector3 dir = path.vectorPath(_currentWaypoint) - transform.position;
    }
}
