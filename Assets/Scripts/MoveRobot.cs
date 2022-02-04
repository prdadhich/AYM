using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRobot : MonoBehaviour
{
    // Start is called before the first frame update
    
    private NavMeshAgent agent;
    private Animator animator;
    private bool _isWalking = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
            agent.SetDestination(PlayAudio.LocationTransform.position);
            animator.SetBool("isWalking", _isWalking);
            if (agent.remainingDistance > 0.2)
            {
                _isWalking = true;


            }
            else
            {
                
                _isWalking = false;
            }

        
       

    }
}
