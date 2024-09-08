using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// based on https://www.youtube.com/watch?v=-Iwsz4gdgyQ

public class Roaming : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    Vector3 destination;
    bool hasValidDestination;
    float idleTimer = 0.0f;

    public float range = 1.0f;
    public float minIdleTime = 0.5f;
    public float maxIdleTime = 15.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Roam();
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void Roam()
    {
        if (idleTimer > 0.0f)
        {
            idleTimer -= Time.deltaTime;
            return;
        }
        if (!hasValidDestination && idleTimer <= 0.0f)
        {
            idleTimer = 0.0f;
            FindDestination();
        }
        if(hasValidDestination)
        {
            if(agent.isOnNavMesh)
                agent.SetDestination(destination);
        }
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            hasValidDestination = false;
            idleTimer = Random.Range(minIdleTime, maxIdleTime);
        }
    }

    void FindDestination()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        destination = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        // Physics.Raycast(destination, Vector3.down, groundLayer)
        if(true)
        {
            hasValidDestination = true;
        }
    }
}
