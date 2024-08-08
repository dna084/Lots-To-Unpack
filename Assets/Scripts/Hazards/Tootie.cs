using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tootie : Pickup
{
    [SerializeField] public int damage = 1;
    [SerializeField] private float speed = 2.0f;

    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;
    private bool forward = true;
    private bool isWaiting = false;
    private float waitTime = 4.0f;

    void Start()
    {
        waypoints = new Vector3[]
        {
            new Vector3(7f, 2.5f, 0f),
            new Vector3(0f, -1.5f, 0f),
            new Vector3(-7f, 2.5f, 0f)
        };

        transform.position = waypoints[0];
    }
    void FixedUpdate()
    {
        if (!isWaiting)
        {
            MoveToNextWaypoint();
        }

    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
            UpdateWaypointIndex();
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    private void UpdateWaypointIndex()
    {
        if (forward)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex -= 2;
                forward = false;
            }
        }
        else
        {
            currentWaypointIndex--;
            if (currentWaypointIndex < 0)
            {
                currentWaypointIndex = 1;
                forward = true;
            }
        }
    }

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Player>().TakeDamage(damage);
    }
}
