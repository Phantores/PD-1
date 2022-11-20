using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    // Definicja

    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float speed;

    int targetWaypointIndex;
    Transform previousWaypoint;
    Transform targetWaypoint;
    public float timeToWaypoint, elapsedTime;

    // Przypisanie na start
    void Start()
    {
        TargetNextPoint();
    }

    // mechanizm
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage);
        if (elapsedPercentage >= 1)
        {
            TargetNextPoint();
        }
    }

    void TargetNextPoint()
    {
        previousWaypoint = _waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = _waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = _waypointPath.GetWaypoint(targetWaypointIndex);
        elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(this.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
