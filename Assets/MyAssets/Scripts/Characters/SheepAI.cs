using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SheepAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator animator;

    public float wanderRadius = 10f;

    public float wanderDelay = 5f;

    private float remainingDistanceThreshold = 0.5f;

    private bool isMoving;

    private void Start()
    {
        Observer.Instance.Start += () => StartCoroutine(SetNewDestination(0f));
    }

    private void Update()
    {
        if (!GameManager.Instance.GameActive || !isMoving)
            return;

        if(!agent.pathPending && agent.remainingDistance <= remainingDistanceThreshold) 
        {
            isMoving = false;

            agent.isStopped = true;

            StartCoroutine(SetNewDestination(wanderDelay));
        }


        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator SetNewDestination(float wait)
    {
        yield return new WaitForSeconds(wait);

        agent.SetDestination(RandomNavmeshLocation(wanderRadius));

        agent.isStopped = false;

        isMoving = true;
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;

        randomDirection += transform.position;

        NavMeshHit hit;

        Vector3 finalPosition = transform.position;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
            finalPosition = hit.position;

        return finalPosition;
    }
}
