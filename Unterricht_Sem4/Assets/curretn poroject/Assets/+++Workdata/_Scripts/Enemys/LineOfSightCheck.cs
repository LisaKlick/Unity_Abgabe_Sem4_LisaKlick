using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineOfSightCheck : MonoBehaviour
{

    [SerializeField] private LayerMask LayersToCover;

    private GameObject target;
    private Coroutine detectPlayerCoroutine;

   [SerializeField] private SimpleEnemyBehaviour seb;

    [SerializeField] private float viewAnlge = 60f;

    //Enemy can see player or not

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            Debug.Log("Player entered Awarenessarea");
            detectPlayerCoroutine = StartCoroutine(DetectPlayer());

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
            Debug.Log("Player exit area");
           StopCoroutine(detectPlayerCoroutine);
            seb.hasTarget = false;
        }
    }

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Detect Player...");

            float distanceToPlayer = Vector3.Distance(this.transform.position, target.transform.position);
            Vector3 directionToPlayer = target.transform.position - this.transform.position;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            bool isCovered = IsPlayerCovered(directionToPlayer, distanceToPlayer);
            Debug.Log("Player Covered?" + isCovered);
            if (!isCovered && angleToPlayer < viewAnlge)
            {
                seb.hasTarget = true;

            }
            else
            {
                seb.hasTarget = false;
            }

        }
       
    }

    bool IsPlayerCovered(Vector3 direction, float distanceToTarget)
    {
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position, direction, distanceToTarget, LayersToCover);

        foreach (RaycastHit hit in hits)
        {
            Debug.DrawRay(this.transform.position, direction.normalized * distanceToTarget,Color.green, 0.5f);
            return true;
        }

        Debug.DrawRay(this.transform.position, direction.normalized * distanceToTarget,Color.red, 0.5f);
        return false;

    }

}
