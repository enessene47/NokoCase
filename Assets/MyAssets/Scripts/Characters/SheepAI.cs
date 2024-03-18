using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SheepAI : CustomManager
{
    [SerializeField] private ParticleSystem _sleppingZZZ;

    private bool isMoving;

    private void Start()
    {
        Observer.Instance.Start += () => StartCoroutine(SetNewDestination(0f));
    }

    private void Update()
    {
        if (!GameManager.Instance.GameActive || !isMoving)
            return;

        if(!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance <= Constants.Instance.remainingDistanceThreshold) 
        {
            isMoving = false;

            NavMeshAgent.isStopped = true;

            StartCoroutine(SetNewDestination(Constants.Instance.wanderDelay));
        }


        Animator.SetBool("isMoving", isMoving);
    }

    IEnumerator SetNewDestination(float wait)
    {
        _sleppingZZZ.Play();

        yield return new WaitForSeconds(wait);

        NavMeshAgent.SetDestination(RandomNavmeshLocation(Constants.Instance.wanderRadius));

        NavMeshAgent.isStopped = false;

        isMoving = true;

        _sleppingZZZ.Stop();
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
