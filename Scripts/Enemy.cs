﻿
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; //permet de creer le vecteur vers lequ'elle il doit aller
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //applique le déplacement, le normalize * speed permet d aller a la vitesse spped et * time.deltatime dans le temps

        float error = Mathf.Min(0.5f, 0.1f + 0.05f * speed);

        if(Vector3.Distance(transform.position, target.position) <= error)// permet de prendre une compte les erreur de déplacement liée a unité
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint() // fonction passant au prochain waypoint
    {  
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
