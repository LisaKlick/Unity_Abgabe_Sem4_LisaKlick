using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class SimpleEnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform agentTarget;

    private UIManager uiManager;


    public bool hasTarget = false;
    [SerializeField] bool isRotating = false;
    [SerializeField] float rotatingSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        agentTarget = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
        //use this only if you are sure if there is only one Component of this kind in the Scene
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            agent.SetDestination(agentTarget.position);
        }
        else
        {
            if (isRotating)
            {
                transform.Rotate(transform.up, rotatingSpeed * Time.deltaTime);
            }
            
        }
      
    }
    //you lost if the enemy touching you
    private void OnCollisionEnter(Collision other)
    {
        uiManager.ShowLostPanel();
    }
}
